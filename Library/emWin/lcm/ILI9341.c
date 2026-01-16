/**
 * @file     ILI9341.c
 * @version  V1.00
 * @brief    Display controller configuration.
 *
 * SPDX-License-Identifier: Apache-2.0
 * @copyright (C) 2020 Nuvoton Technology Corp. All rights reserved.
 *****************************************************************************/
#include <stddef.h>
#include <stdio.h>

#include "GUI.h"
#include "GUIDRV_FlexColor.h"

#include "NuMicro.h"
#ifdef __DEMO_320x240__
#include "TouchPanel.h"

#include "lcm.h"
#include "PTT_Global.h" //2022/10/05 for SPI_3wire_EN
//
// Hardware related
//
#define SPI_LCD_PORT USPI0

#define GPIO_SPI_SS PA8
#define GPIOPORT_SPI_SS PA
#define PINMASK_SPI_SS BIT8

#define GPIO_LCM_DC PB2
#define GPIOPORT_LCM_DC PB
#define PINMASK_LCM_DC BIT2

#define GPIO_LCM_RESET PB3
#define GPIOPORT_LCM_RESET PB
#define PINMASK_LCM_RESET BIT3

#define SPI_CS_SET GPIO_SPI_SS = 1
#define SPI_CS_CLR GPIO_SPI_SS = 0

#define LCM_DC_SET GPIO_LCM_DC = 1
#define LCM_DC_CLR GPIO_LCM_DC = 0

#define LCM_RESET_SET GPIO_LCM_RESET = 1
#define LCM_RESET_CLR GPIO_LCM_RESET = 0

#define ILI9341_LED PA6

#define USPI_MASTER_TX_DMA_CH 0
__attribute__((aligned(4))) uint16_t pD_16b[1000];
volatile uint8_t pdma_busy;
void _Open_PDMA(void);
static void DMA_WaitDone(void)
{
    while (pdma_busy || USPI_IS_BUSY(SPI_LCD_PORT))
        ;
}

void Restart_System(void);
//__align(4) uint16_t pD_16b[1000];

/*********************************************************************
 *
 *       _Read1
 */
U8 _Read1(void)
{
    DMA_WaitDone(); // ?? CPU ? DMA ????? SPI
#if 1
    /* FIXME if panel supports read back feature */
    return 0;
#else
    // 	USPI0->TXDAT |= 0x00010000;	//0 = output / 1 = input�CUSPI_TXDAT_PORTDIR_Pos=(16)�C2022/09/28
    // 	USPI0->TXDAT &= 0xFFFEFFFF;	//0 = output / 1 = input�CUSPI_TXDAT_PORTDIR_Pos=(16)�C2022/09/28

    LCM_DC_SET;
    SPI_CS_CLR;
    // 	USPI_WRITE_TX(SPI_LCD_PORT, 0x00);
    USPI_WRITE_TX(SPI_LCD_PORT, 0x100);
    USPI_READ_RX(SPI_LCD_PORT);
    SPI_CS_SET;
    return (USPI_READ_RX(SPI_LCD_PORT));
#endif
}

volatile uint8_t pdma_error = 0;
volatile uint32_t dma_ok_count = 0;
volatile uint32_t dma_err_count = 0;
volatile uint8_t dma_error_flag = 0;
static void Reset_SPI_DMA_Channel(void)
{
    // 關閉指定的 DMA Channel，避免重設時有資料還在傳送。
    PDMA->CHCTL &= ~(1 << USPI_MASTER_TX_DMA_CH);
    // 重新設定傳送長度
    PDMA_SET_TRANS_CNT(PDMA, USPI_MASTER_TX_DMA_CH, PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL & PDMA_DSCT_CTL_TXCNT_Msk);
    // 重新設定 Source Address
    PDMA_SET_SRC_ADDR(PDMA, USPI_MASTER_TX_DMA_CH, (uint32_t)&pD_16b[0]);
    // 設定為基本模式
    PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL = (PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL & ~PDMA_DSCT_CTL_OPMODE_Msk) | PDMA_OP_BASIC;
    // SPI 片選拉低（開始傳送）
    SPI_CS_CLR;
    USPI_TRIGGER_TX_PDMA(SPI_LCD_PORT);
    // 內部狀態重設 記錄 PDMA 已啟動，錯誤歸零。
    pdma_busy = 1;
    pdma_error = 0;
}
/*
建議與提醒
Reset 這段可用於傳送異常/Timeout 時「強制重發」用。

如果你要「多次連續傳送不同長度資料」，建議直接把長度寫死或當參數傳進來，避免用 PDMA->DSCT[].CTL 這種不明確值，這樣更安全。

若SPI DMA 結束有中斷，請記得在 ISR 把 pdma_busy = 0、SPI 片選拉高等都一起寫進去，避免遺漏。
 */
extern void ShowFreeMem(void);
void PDMA_IRQHandler(void)
{
    /*
    status 主要判斷整體的 PDMA 中斷來源（完成、異常）。

    intsts 是更細緻的中斷來源（位址錯誤、timeout）。

    abtsts 與 tdsts 方便下面 for loop 判斷各 channel 的狀態。
     */
    uint32_t status = PDMA_GET_INT_STATUS(PDMA);
    uint32_t intsts = PDMA->INTSTS;
    uint32_t abtsts = PDMA->ABTSTS;
    uint32_t tdsts = PDMA->TDSTS;

    // 傳輸完成（Transfer Done）
    /*
    標準寫法，完成清 flag、統計次數、關 busy、重新允許 UART RX。

    **注意：**如果你 DMA 有多個 channel，其實這裡要用 for 或 while 去檢查每個 channel，這裡只針對一個。
     */
    if (status & PDMA_INTSTS_TDIF_Msk)
    {
        if (PDMA_GET_TD_STS(PDMA) & (1 << USPI_MASTER_TX_DMA_CH))
        {
            PDMA_CLR_TD_FLAG(PDMA, 1 << USPI_MASTER_TX_DMA_CH);
            pdma_busy = 0;
            dma_ok_count++;
            dma_error_flag = 0; // ??????
            NVIC_EnableIRQ(UART1_IRQn);
        }
    }
    // 3. 異常（Abort）處理
    /*
    建議：if (dma_error_flag == 1) dma_error_flag = 1;
    這一行其實沒意義，建議直接寫 dma_error_flag = 1;

    _Open_PDMA() 這個通常是重新 enable/initialize DMA，有些人會 reset FIFO 或暫停 SPI，請確認傳送內容已經更新完再呼叫。
     */
    else if (status & PDMA_INTSTS_ABTIF_Msk)
    {
        PDMA_CLR_ABORT_FLAG(PDMA, PDMA_GET_ABORT_STS(PDMA));
        pdma_busy = 0;
        dma_err_count++;
        if (dma_error_flag == 1)
            dma_error_flag = 1; // ??????
        printf("[DMA] Abort! ok=%lu err=%lu\n", dma_ok_count, dma_err_count);
        ShowFreeMem();
        _Open_PDMA(); // ????? DMA
        NVIC_EnableIRQ(UART1_IRQn);
    }

    // 傳輸完成
    /*
    現在寫 ch < 1 只有一個 channel，如果日後有多 channel，建議改 PDMA_CH_MAX 或 MAX_PDMA_CH，以免忘記。

    裡面內容為傳送完成或 Abort 個別 channel 的清除與 log。
     */
    for (int ch = 0; ch < 1; ch++)
    {
        if (tdsts & (1ul << ch))
        {
            PDMA->TDSTS = (1ul << ch);
            // printf("PDMA ch%d transfer done\n", ch);
        }
    }

    // 傳輸中止
    for (int ch = 0; ch < 1; ch++)
    {
        if (abtsts & (1ul << ch))
        {
            PDMA->ABTSTS = (1ul << ch);
            printf("PDMA ch%d aborted\n", ch);
        }
    }
    // 對齊錯誤、timeout 清中斷＋印出訊息。這種通常很少見（資料源設定錯誤、時脈問題）。
    //  Align Error
    if (intsts & PDMA_INTSTS_ALIGNF_Msk)
    {
        PDMA->INTSTS |= PDMA_INTSTS_ALIGNF_Msk;
        printf("PDMA alignment error\n");
    }

    // Request Timeout
    if (intsts & (PDMA_INTSTS_REQTOF0_Msk | PDMA_INTSTS_REQTOF1_Msk))
    {
        PDMA->INTSTS |= (PDMA_INTSTS_REQTOF0_Msk | PDMA_INTSTS_REQTOF1_Msk);
        printf("PDMA request timeout\n");
    }
}

/*
1. 各種異常處理與排除
RX FIFO overflow：

清除溢位旗標 + 立即重置 RX FIFO（避免下一次溢位）。

TX FIFO underflow：

清除溢位旗標 + 立即重置 TX FIFO（避免 FIFO 狀態錯亂）。

RX timeout：

這是 FIFO 在一段時間未收到資料觸發。多半是 SPI 傳輸異常或對方沒資料。

SS (Slave Select) inactive during transfer：

這種情況常見於 SPI slave/主機在未完成傳輸時被斷線。

Transfer complete (UNITIF)：

SPI 單次傳輸完成，可視情況做下一步（啟動下一次、通知任務等等）。


 */
void SPI0_IRQHandler(void)
{
    uint32_t status = SPI0->STATUS;

    if (status & SPI_STATUS_RXOVIF_Msk)
    {
        SPI0->STATUS = SPI_STATUS_RXOVIF_Msk;
        SPI0->FIFOCTL |= SPI_FIFOCTL_RXRST_Msk;
        printf("SPI RX FIFO overflow\n");
    }
    if (status & SPI_STATUS_TXUFIF_Msk)
    {
        SPI0->STATUS = SPI_STATUS_TXUFIF_Msk;
        SPI0->FIFOCTL |= SPI_FIFOCTL_TXRST_Msk;
        printf("SPI TX FIFO underflow\n");
    }
    if (status & SPI_STATUS_RXTOIF_Msk)
    {
        SPI0->STATUS = SPI_STATUS_RXTOIF_Msk;
        printf("SPI RX timeout\n");
    }
    if (status & SPI_STATUS_SSINAIF_Msk)
    {
        SPI0->STATUS = SPI_STATUS_SSINAIF_Msk;
        printf("SPI SS inactive during transfer\n");
    }
    if (status & SPI_STATUS_UNITIF_Msk)
    {
        SPI0->STATUS = SPI_STATUS_UNITIF_Msk;
        printf("SPI transfer complete\n");
    }
    // …可依需要加入其他 flag 處理
}

/*********************************************************************
 *
 *       _ReadM1
 */
void _ReadM1(U8 *pData, int NumItems)
{
    DMA_WaitDone(); // ?? DMA ??,????
#if 1
    /* FIXME if panel supports read back feature */
#else
    // 	USPI0->TXDAT |= 0x00010000;	//0 = output / 1 = input�CUSPI_TXDAT_PORTDIR_Pos=(16)�C2022/09/28
    // 	USPI0->TXDAT &= 0xFFFEFFFF;	//0 = output / 1 = input�CUSPI_TXDAT_PORTDIR_Pos=(16)�C2022/09/28

    LCM_DC_SET;
    SPI_CS_CLR;
    while (NumItems--)
    {
        // 		USPI_WRITE_TX(SPI_LCD_PORT, 0x00);
        USPI_WRITE_TX(SPI_LCD_PORT, 0x100);
        while (SPI_IS_BUSY(SPI_LCD_PORT))
            ;
        *pData++ = USPI_READ_RX(SPI_LCD_PORT);
    }
    SPI_CS_SET;
#endif
}

/*********************************************************************
 *
 *       _Write0 Cmd
 */
void _Write0(U8 Cmd)
{
    U32 CMD;
    // 	USPI0->TXDAT &= 0xFFFEFFFF;	//0 = output / 1 = input�CUSPI_TXDAT_PORTDIR_Pos=(16)�C2022/09/28
    // 	USPI0->TXDAT |= 0x00010000;	//0 = output / 1 = input�CUSPI_TXDAT_PORTDIR_Pos=(16)�C2022/09/28
    CMD = 0x00000000; // 2022/09/29 CMD DC=0
    CMD += Cmd;       // 2022/09/29
    DMA_WaitDone();   // ?? DMA ??,????
    LCM_DC_CLR;

    SPI_CS_CLR;

    while (USPI_GET_TX_FULL_FLAG(SPI_LCD_PORT))
        ;
    // 	USPI_WRITE_TX(SPI_LCD_PORT, Cmd);			//=>(SPI_LCD_PORT)->TXDAT = (Cmd)�C2022/09/29
    USPI_WRITE_TX(SPI_LCD_PORT, CMD); //=>(SPI_LCD_PORT)->TXDAT = (CMD)�C2022/09/29
    while (USPI_IS_BUSY(SPI_LCD_PORT))
        ;

    SPI_CS_SET;
}

/*********************************************************************
 *
 *       _Write1	Data
 */
void _Write1(U8 Data)
{
    U32 DATA;
    // 	USPI0->TXDAT &= 0xFFFEFFFF;	//0 = output / 1 = input�CUSPI_TXDAT_PORTDIR_Pos=(16)�C2022/09/28
    // 	USPI0->TXDAT |= 0x00010000;	//0 = output / 1 = input�CUSPI_TXDAT_PORTDIR_Pos=(16)�C2022/09/28
    DATA = 0x00000100; // 2022/09/29 DATA DC=1
    DATA += Data;      // 2022/09/29
    DMA_WaitDone();    // ?? DMA ??,????
    LCM_DC_SET;

    SPI_CS_CLR;

    while (USPI_GET_TX_FULL_FLAG(SPI_LCD_PORT))
        ;
    // 	USPI_WRITE_TX(SPI_LCD_PORT, Data);			//=>(SPI_LCD_PORT)->TXDAT = (DATA)�C2022/09/29
    USPI_WRITE_TX(SPI_LCD_PORT, DATA); //=>(SPI_LCD_PORT)->TXDAT = (DATA)�C2022/09/29
    while (USPI_IS_BUSY(SPI_LCD_PORT))
        ;

    SPI_CS_SET;
}
#define DMA_BUF_LEN 1000
/*********************************************************************
 *
 *       _WriteM1
 */
extern uint8_t pdma_stop_error_flag;
extern uint8_t pdma_start_flag;
void _WriteM1(U8 *pData, int NumItems)
{
    uint32_t i;

    if (NumItems > DMA_BUF_LEN)
    {
        printf("DMA buffer overflow!\n");
        return;
    }

    if (pdma_busy || dma_error_flag)
    {
        printf("[DMA] Busy or error\n");
        return;
    }

    DMA_WaitDone(); // 確保上一次傳輸完成

    // 轉換 8bit → 9bit 資料 (bit8=1 表示資料)
    for (i = 0; i < NumItems; i++)
    {
        pD_16b[i] = 0x0100 | *pData++;
    }

    // 設定資料模式與準備 DMA
    LCM_DC_SET;    // D/C = 1 表示資料
    SPI_CS_CLR;    // ⭐ 先拉低 CS
    pdma_busy = 1; // 標記傳輸中

    PDMA_SET_TRANS_CNT(PDMA, USPI_MASTER_TX_DMA_CH, NumItems);
    PDMA_SET_SRC_ADDR(PDMA, USPI_MASTER_TX_DMA_CH, (uint32_t)pD_16b);

    PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL =
        (PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL & ~PDMA_DSCT_CTL_OPMODE_Msk) |
        PDMA_OP_BASIC;

    USPI_TRIGGER_TX_PDMA(SPI_LCD_PORT); // 啟用 DMA

    while (pdma_busy)
        ; // 等待 DMA 完成（中斷清除）
    while (USPI_IS_BUSY(SPI_LCD_PORT))
        ; // 等 SPI 傳輸完成

    CLK_SysTickDelay(2); // LCD 必要等待
    SPI_CS_SET;          // ✅ 傳輸後再拉高 CS
}
static void _Open_SPI(void)
{
    GPIO_SetMode(GPIOPORT_LCM_DC, PINMASK_LCM_DC, GPIO_MODE_OUTPUT);
    GPIO_SetMode(GPIOPORT_LCM_RESET, PINMASK_LCM_RESET, GPIO_MODE_OUTPUT);
    GPIO_SetMode(PA, BIT6, GPIO_MODE_OUTPUT);
    GPIO_SetMode(GPIOPORT_SPI_SS, PINMASK_SPI_SS, GPIO_MODE_OUTPUT); // cs pin for gpiod

    /* Setup USPI0 multi-function pins */
    SYS->GPA_MFPH &= ~(SYS_GPA_MFPH_PA9MFP_Msk);
    SYS->GPA_MFPH |= (SYS_GPA_MFPH_PA9MFP_USCI0_DAT1);

    SYS->GPA_MFPH &= ~(SYS_GPA_MFPH_PA11MFP_Msk | SYS_GPA_MFPH_PA10MFP_Msk);
    SYS->GPA_MFPH |= (SYS_GPA_MFPH_PA11MFP_USCI0_CLK | SYS_GPA_MFPH_PA10MFP_USCI0_DAT0);

    /* Enable USCI0 peripheral clock */
    CLK_EnableModuleClock(USCI0_MODULE);

    /*---------------------------------------------------------------------------------------------------------*/
    /* Init USCI_SPI                                                                                                */
    /*---------------------------------------------------------------------------------------------------------*/
    /* Configure USCI_SPI0 */
    /* Configure USCI_SPI0 as a master, USCI_SPI clock rate 48MHz,
       clock idle low, 4~15-bit transaction, drive output on falling clock edge and latch input on rising edge. */
#ifndef SPI_3wire_EN                                         // �ҥ�SPI_4wire
    USPI_Open(USPI0, USPI_MASTER, USPI_MODE_0, 8, 72000000); // ��lSPI_4wire
#else                                                        // �ҥ�SPI_3wire
    USPI_Open(USPI0, USPI_MASTER, USPI_MODE_0, 9, 20000000); // 2022/10/04 OK SPI 3wire 9bit�CMaster = fPCLK / 2�A�Y72M/2=36MHz�CSPCE.P862 jacob

#endif
    USPI_DisableAutoSS(SPI_LCD_PORT);
}

void Restart_System(void)
{
    NVIC_SystemReset(); // ???? MCU,????????
}
void _Open_PDMA(void)
{
    /* Reset PDMA module */
    SYS_ResetModule(PDMA_RST);

    /* Enable PDMA channel */
    PDMA_Open(PDMA, (1 << USPI_MASTER_TX_DMA_CH));

    PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL = (PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL & ~PDMA_DSCT_CTL_TXWIDTH_Msk) | PDMA_WIDTH_16; // 2022/10/07 OK 3wire or 4wire

    /* Set destination address */
    PDMA_SET_DST_ADDR(PDMA, USPI_MASTER_TX_DMA_CH, (uint32_t)&SPI_LCD_PORT->TXDAT); // �ت���USPI-TXDAT(16bit)�A���ȼg�J�Y�}�l�e�XSPI�A�e�Xbit�ƨ��MSPI�]�w4~16bit�C
    /* Set source/destination attributes */
    PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL = (PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL & ~(PDMA_DSCT_CTL_SAINC_Msk | PDMA_DSCT_CTL_DAINC_Msk)) | (PDMA_SAR_INC | PDMA_DAR_FIX);
    /* Set request source; set basic mode. */
    PDMA_SetTransferMode(PDMA, USPI_MASTER_TX_DMA_CH, PDMA_USCI0_TX, FALSE, 0);
    /* Single request type. SPI only support PDMA single request type. */
    PDMA_SetBurstType(PDMA, USPI_MASTER_TX_DMA_CH, PDMA_REQ_SINGLE, 0);
    /* Disable table interrupt */
    PDMA->DSCT[USPI_MASTER_TX_DMA_CH].CTL |= PDMA_TBINTDIS_DISABLE;

    // PDMA TX done interrupt enable
    PDMA_EnableInt(PDMA, USPI_MASTER_TX_DMA_CH, PDMA_INT_TRANS_DONE); // jacob
                                                                      //  ??????(Transfer Abort)
    PDMA->INTEN |= (1 << USPI_MASTER_TX_DMA_CH);                      // Transfer Done
    PDMA->INTEN |= (1 << (USPI_MASTER_TX_DMA_CH + 8));                // Transfer Abort/Error
    NVIC_EnableIRQ(PDMA_IRQn);
}

/*********************************************************************
*
*       _InitController
*
y Pu??  e:
*   Initializes the display controller
*/
void _InitController(void)
{
    static uint8_t s_InitOnce = 0;

    if (s_InitOnce == 0)
        s_InitOnce = 1;
    else
        return;

    _Open_SPI();
    _Open_PDMA();

    /* Configure DC/RESET/LED pins */
    GPIO_LCM_DC = 0;
    GPIO_LCM_RESET = 0;
    ILI9341_LED = 0;

    /* Configure LCD */
    GPIO_LCM_DC = 1;

    GPIO_LCM_RESET = 0;
    GUI_X_Delay(20);

    GPIO_LCM_RESET = 1;
    GUI_X_Delay(40);

    //************* Start Initial Sequence **********//
#if 1 // ��l
    _Write0(0xCF);
    _Write1(0x00);
    _Write1(0xD9);
    _Write1(0X30);

    _Write0(0xED);
    _Write1(0x64);
    _Write1(0x03);
    _Write1(0X12);
    _Write1(0X81);

    _Write0(0xE8);
    _Write1(0x85);
    _Write1(0x10);
    _Write1(0x78);

    _Write0(0xCB);
    _Write1(0x39);
    _Write1(0x2C);
    _Write1(0x00);
    _Write1(0x34);
    _Write1(0x02);

    _Write0(0xF7);
    _Write1(0x20);

    _Write0(0xEA);
    _Write1(0x00);
    _Write1(0x00);

    _Write0(0xC0); // LCMCTRL(C0h)�GLCM Control�CST7789VI�ݭn�]�wXREV(C0.4=1): XOR inverse setting in command 21h�CSPEC.P275
#ifdef ST7789VI_G4
    _Write1(0x31); // VRH[5:0]�AGTF240320-020002 OK�A�P�ª�GTF240320-0240C3 �C��ۦP
// 	_Write1(0x01);
// 	_Write1(0x11);
// 	_Write1(0x21);
#else // ST7789V
    _Write1(0x21); // VRH[5:0]�A�ª�GTF240320-0240C3��l�]�w�AGTF240320-020002 GUI_MAKE_COLOR(0x00FFE6BC)�L�����ܩ@��
#endif
    // 	_Write1(0x01);		//VRH[5:0]�AGTF240320-020002 GUI_MAKE_COLOR(0x00FFE6BC)�L�����ܲ`��
    // 	_Write1(0x11);		//VRH[5:0]�AGTF240320-020002 GUI_MAKE_COLOR(0x00FFE6BC)�L�����ܥֽ���

    _Write0(0xC1); // Power control
    _Write1(0x12); // SAP[2:0];BT[3:0]

    _Write0(0xC5); // VCM control
    _Write1(0x32);
    _Write1(0x3C);

    _Write0(0xC7); // VCM control2�CLED�X�ʤ覡
    _Write1(0XC1);

    _Write0(0x36); // Memory Access Control�C��V�PRGB�w�q
    _Write1(0xe8);

    _Write0(0x3A); // Data Color Coding�AST7789VI_SPEC_V1.4_J.pdf.P224
    _Write1(0x55); // 0x05=65K�A0x06=262K�CGTF240320-0240C3 �ª�OK�CGTF240320-020002�s���C�⤣��
    // 	_Write1(0x05);		//0x05=65K�A0x06=262K�CGTF240320-020002 OK�A�C�⤣��
    // 	_Write1(0x06);		//0x05=65K�A0x06=262K�CGTF240320-020002 NG
    // 	_Write1(0x66);		//0x05=65K�A0x06=262K�CGTF240320-020002 NG

    _Write0(0xB1); // RGB Interface Control
    _Write1(0x00); // MCU interface=D6:D5=00
    _Write1(0x18);

    _Write0(0xB6); // Display Function Control
    _Write1(0x0A);
    _Write1(0xA2);

    _Write0(0xF2); // 3Gamma Function Disable
    _Write1(0x00);

    _Write0(0x26); // Gamma curve selected
    _Write1(0x01);

    _Write0(0xE0); // Set Gamma
    _Write1(0x0F);
    _Write1(0x20);
    _Write1(0x1E);
    _Write1(0x09);
    _Write1(0x12);
    _Write1(0x0B);
    _Write1(0x50);
    _Write1(0XBA);
    _Write1(0x44);
    _Write1(0x09);
    _Write1(0x14);
    _Write1(0x05);
    _Write1(0x23);
    _Write1(0x21);
    _Write1(0x00);

    _Write0(0XE1); // Set Gamma
    _Write1(0x00);
    _Write1(0x19);
    _Write1(0x19);
    _Write1(0x00);
    _Write1(0x12);
    _Write1(0x07);
    _Write1(0x2D);
    _Write1(0x28);
    _Write1(0x3F);
    _Write1(0x02);
    _Write1(0x0A);
    _Write1(0x08);
    _Write1(0x25);
    _Write1(0x2D);
    _Write1(0x0F);

    _Write0(0x11); // Exit Sleep
    GUI_X_Delay(120);
    _Write0(0x29); // Display on
#endif
    // 	ILI9341_LED = 1;	//�קK�}���{�@�U�A���B������

#if 0
//---------------- ST7735S 2023/09/01 ----------//
//------------------------------------ST7735S Frame Rate-----------------------------------------//
	_Write0(0xB1);		//SPEC.P159
	_Write1(0x05);
	_Write1(0x3A);
	_Write1(0x3A);

	_Write0(0xB2);
	_Write1(0x05);
	_Write1(0x3A);
	_Write1(0x3A);

	_Write0(0xB3);
	_Write1(0x05);
	_Write1(0x3A);
	_Write1(0x3A);
	_Write1(0x05);
	_Write1(0x3A);
	_Write1(0x3A);
//------------------------------------End ST7735S Frame Rate-----------------------------------------//
	_Write0(0xB4);		//INVCTR (B4h): Display Inversion Control
	_Write1(0x03);      //Dot inversion
// 	_Write1(0x07);
// 	_Write1(0x00);
//------------------------------------ST7735S Power Sequence-----------------------------------------//
	_Write0(0xC0);
	_Write1(0x62);
	_Write1(0x02);
	_Write1(0x04);

	_Write0(0xC1);
	_Write1(0xC0);

	_Write0(0xC2);
	_Write1(0x0D);
	_Write1(0x00);

	_Write0(0xC3);
	_Write1(0x8D);
	_Write1(0x6A);

	_Write0(0xC4);
	_Write1(0x8D);
	_Write1(0xEE);
//---------------------------------End ST7735S Power Sequence-------------------------------------//
	_Write0(0xC5);		//VCOM
	_Write1(0x12);
//------------------------------------ST7735S Gamma Sequence-----------------------------------------//
	_Write0(0xE0);
	_Write1(0x03);
	_Write1(0x1B);
	_Write1(0x12);
	_Write1(0x11);
	_Write1(0x3F);
	_Write1(0x3A);
	_Write1(0x32);
	_Write1(0x34);
	_Write1(0x2F);
	_Write1(0x2B);
	_Write1(0x30);
	_Write1(0x3A);
	_Write1(0x00);
	_Write1(0x01);
	_Write1(0x02);
	_Write1(0x05);

	_Write0(0xE1);
	_Write1(0x03);
	_Write1(0x1B);
	_Write1(0x12);
	_Write1(0x11);
	_Write1(0x32);
	_Write1(0x2F);
	_Write1(0x2A);
	_Write1(0x2F);
	_Write1(0x2E);
	_Write1(0x2C);
	_Write1(0x35);
	_Write1(0x3F);
	_Write1(0x00);
	_Write1(0x00);
	_Write1(0x01);
	_Write1(0x05);

	_Write0(0xFC);		//Enable Gate power save mode
	_Write1(0x8C);

	_Write0(0x3A);		//65k mode
	_Write1(0x05);		//16-bit/pixel
// 	_Write1(0x55);		//16-bit/pixel

	_Write0(0x29);		//Display on
	GUI_X_Delay(10);
// 	_Write0(0x39);		//IDMON (39h): Idle Mode On�C�C��S�����h
// 	_Write0(0x38);		//IDMON (38h): Idle Mode Off�C�C��i���h
// 	_Write0(0x21);		//Display Inversion On
// 	_Write0(0x20);		//Display Inversion Off
//------------------------------------End ST7735S Gamma Sequence-----------------------------------------//

#endif
//---------------- ST7789 Reset Sequence Start Initial Sequence ----------//
#if 0 // �ݫHLCD�A����e�����աA�i��P�s��API���ۮe�C
	_Write0(0x01); 		//Software reset

	_Write0(0x11);     
	GUI_X_Delay(120);                

	_Write0(0x36);     
	_Write1(0x00);   

	_Write0(0x3A);     
	_Write1(0x05);   	 //0x06

	_Write0(0xB2);     
	_Write1(0x0C);   
	_Write1(0x0C);   
	_Write1(0x00);   
	_Write1(0x33);   
	_Write1(0x33);   

	_Write0(0xB7);     
	_Write1(0x25);   //VGH=12.89V,VGL=-10.43V

	_Write0(0xBB);     
	_Write1(0x1C);   

	_Write0(0xC0);     
	_Write1(0x2C);   

	_Write0(0xC2);     
	_Write1(0x01);   

	_Write0(0xC3);     
	_Write1(0x13);   //GVDD=4.5V,GVCL=-4.5V

	_Write0(0xC4);     
	_Write1(0x20);   

	_Write0(0xC6);     
	_Write1(0x0F);   

	_Write0(0xD0);     
	_Write1(0xA4);   
	_Write1(0xA1);   

	_Write0(0xE0);     
	_Write1(0xD0);   
	_Write1(0x07);   
	_Write1(0x11);   
	_Write1(0x10);   
	_Write1(0x11);   
	_Write1(0x2B);   
	_Write1(0x3F);   
	_Write1(0x54);   
	_Write1(0x4D);   
	_Write1(0x2A);   
	_Write1(0x16);   
	_Write1(0x15);   
	_Write1(0x20);   
	_Write1(0x24);   

	_Write0(0xE1);     
	_Write1(0xD0);   
	_Write1(0x06);   
	_Write1(0x11);   
	_Write1(0x0F);   
	_Write1(0x10);   
	_Write1(0x2A);   
	_Write1(0x3C);   
	_Write1(0x44);   
	_Write1(0x4F);   
	_Write1(0x29);   
	_Write1(0x15);   
	_Write1(0x14);   
	_Write1(0x1F);   
	_Write1(0x23);  

	_Write0(0x2a); 
	_Write1(0x00);    
	_Write1(0x00);    
	_Write1(0x00);  
	_Write1(0xef); //240-1
	_Write0(0x2b);
	_Write1(0x00);    
	_Write1(0x00);   
	_Write1(0x01); 
	_Write1(0x3f); //320-1
	_Write0(0x29);     //Display ON
#endif
}
#endif
