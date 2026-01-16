/*
📦 Firmware Release

版本號 (Version)：v1.000 [Keil Build] fe7a

日期 (Release Date)：2025-10-02

版本摘要(Release Notes)

修正首頁顯示字串為正式版發版字串

*/

/**
 * @file     main.c
 * @version  V1.00
 * @brief    To utilize emWin library to demonstrate interactive feature.
 *
 * SPDX-License-Identifier: Apache-2.0
 * @copyright (C) 2020 Nuvoton Technology Corp. All rights reserved.
 *****************************************************************************/

#include "PTT_Global.h" //2021/11/24
#include "fmc.h"
#include "NuMicro.h"
#define DATA_FLASH_ADDR 0x0003F000
extern int ts_writefile(void);
extern int ts_readfile(void);
extern void ts_init(void);
int ts_calibrate(int xsize, int ysize);
void ts_test(int xsize, int ysize);

extern void Show_FW_Version(uint16_t FWVerion, uint16_t SAFWVerion);
extern void Show_FW_Version2(uint16_t FWVerion, uint16_t SAFWVerion);
unsigned int Get_Free_Stack_Size(void);
GUI_WIDGET_CREATE_INFO _aDialogCreate222[50];
void I2C_Init(void);
void UART_Init(void);
void TIMER_Init(void);

WM_HWIN hWin;
WM_HWIN hWin_G;
WM_HWIN hWin_Temp;
WM_HWIN hWin_Desktop;
WM_HWIN hWin_Active;
WM_HWIN hWin_Focused;
WM_HWIN hWin_FirstChild;

GUI_COLOR Bar_Color;
int Text_Value;
char Text_Value_Buf[20];

U8 i, j, k;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Boot_Menu_MicrosoftJhengHei_22B;
extern GUI_CONST_STORAGE GUI_FONT BM_Font_ChineseFont;
extern const char *apStringsKilews[];
extern const char *apStringsKilews2[];
uint32_t Read_DataFlash(uint32_t u32Addr);
void WriteDataFlash(uint32_t u32Data);
WM_MESSAGE My_Msg;
WM_KEY_INFO My_KEY_INFO;
extern Pg_Home_TypeDef Pg_Home, Temp_Pg_Home;					// jacob 20250108
extern Pg_Language_0_TypeDef Pg_Language_0, Temp_Pg_Language_0; // jacob 20250108
extern Pg_Call_Job_0_TypeDef Pg_Call_Job_0, Temp_Pg_Call_Job_0;
extern Pg_JS_0_Job_TypeDef Pg_JS_0_Job, Temp_Pg_JS_0_Job;
extern Pg_JS_1_JobSEQ_TypeDef Pg_JS_1_JobSEQ, Temp_Pg_JS_1_JobSEQ;	  // jacob 20250613
extern Pg_JS_2_Step2_1_TypeDef Pg_JS_2_Step2_1, Temp_Pg_JS_2_Step2_1; // jacob 20250108
extern Pg_JS_3_Step2_2_TypeDef Pg_JS_3_Step2_2, Temp_Pg_JS_3_Step2_2; // jacob 20250613

extern Pg_Tool_Info_0_TypeDef Pg_Tool_Info_0, Temp_Pg_Tool_Info_0;		 // jacob 20250108
extern Pg_Tool_Mode_0_TypeDef Pg_Tool_Mode_0, Temp_Pg_Tool_Mode_0;		 // jacob 20250108
extern Pg_Net_Info_0_TypeDef Pg_Net_Info_0, Temp_Pg_Net_Info_0;			 // jacob 20250108
extern Pg_Net_AP_Info_0_TypeDef Pg_Net_AP_Info_0, Temp_Pg_Net_AP_Info_0; // jacob 20250108
void Pg_home_array_init(void);
void Pg_Language_0_array_init(void);
void Pg_Call_Job_0_array_init(void);
void Pg_JS_0_Job_array_init(void);
void Pg_JS_1_JobSEQ_array_init(void);
void Pg_JS_2_Step2_1_array_init(void);
void Pg_JS_3_Step2_2_array_init(void);
void Pg_Net_AP_Info_0_array_init(void);
void Pg_Tool_Info_0_array_init(void);
void Pg_Tool_Mode_0_array_init(void);
void Pg_Net_Info_0_array_init(void);
/*********************************************************************
 *
 *       Static code
 *
 **********************************************************************
 */
/*********************************************************************
 *
 *       _SYS_Init
 */
void _SYS_Init(void)
{
	/*---------------------------------------------------------------------------------------------------------*/
	/* Init System Clock                                                                                       */
	/*---------------------------------------------------------------------------------------------------------*/
	/* Unlock protected registers */
	SYS_UnlockReg();
	/* Enable HIRC clock (Internal RC 48MHz) */
	CLK_EnableXtalRC(CLK_PWRCTL_HIRCEN_Msk);
	/* Wait for HIRC clock ready */
	CLK_WaitClockReady(CLK_STATUS_HIRCSTB_Msk);
	/* Select HCLK clock source as HIRC and HCLK source divider as 1 */
	CLK_SetHCLK(CLK_CLKSEL0_HCLKSEL_HIRC, CLK_CLKDIV0_HCLK(1));
	/* Select HCLK clock source from PLL. PLL will be configured to twice specified frequency. */
	CLK_SetCoreClock(72000000); // PLL = 72MHz
	CLK_EnableModuleClock(USCI0_MODULE);
	CLK_EnableModuleClock(PDMA_MODULE);
	// 	CLK_EnableModuleClock(I2C0_MODULE);
	CLK_EnableModuleClock(PWM1_MODULE);
	/* Switch UARTx clock source to HIRC */
	CLK_SetModuleClock(UART0_MODULE, CLK_CLKSEL1_UART0SEL_PLL, CLK_CLKDIV0_UART0(1));
	CLK_SetModuleClock(UART1_MODULE, CLK_CLKSEL1_UART1SEL_PLL, CLK_CLKDIV0_UART1(1));
	SystemCoreClockUpdate();
	SYS->GPA_MFPH = (SYS->GPA_MFPH & ~(SYS_GPA_MFPH_PA9MFP_Msk | SYS_GPA_MFPH_PA10MFP_Msk | SYS_GPA_MFPH_PA11MFP_Msk)) |
					(SYS_GPA_MFPH_PA9MFP_USCI0_DAT1 | SYS_GPA_MFPH_PA10MFP_USCI0_DAT0 | SYS_GPA_MFPH_PA11MFP_USCI0_CLK);
	SYS->GPA_MFPL &= ~SYS_GPA_MFPL_PA6MFP_Msk;
	SYS->GPA_MFPL |= SYS_GPA_MFPL_PA6MFP_GPIO;

	GPIO_SetMode(PA, BIT6, GPIO_MODE_OUTPUT);
	/* Lock protected registers */
	SYS_LockReg();

	GPIO_SetMode(PA, BIT6, GPIO_MODE_OUTPUT);

	GPIO_SetMode(PB, BIT14, GPIO_MODE_OUTPUT);
	GPIO_SetMode(PC, BIT14, GPIO_MODE_OUTPUT);
	PC0 = 1; // 0=ON
	GPIO_SetMode(PC, BIT0, GPIO_MODE_OUTPUT);
	GPIO_SetMode(PF, BIT2, GPIO_MODE_OUTPUT);
}

extern U8 _acImage_0[];

/*********************************************************************
 *
 *       main
 */
int main(void)
{

	_SYS_Init();
	UART_Init();
	Delay_NmS(100);
	g_enable_Touch = 0;
	TIMER_Init();
	I2C_Init();
	MainTask();
	return 0;
}
uint8_t language_version = 0;
#define APROM_SIZE (512 * 1024) // 512 KB
#define APROM_END (0x00000000 + APROM_SIZE - 1)
extern uint8_t record_language;
void MainTask(void)
{

	extern GUI_CONST_STORAGE GUI_BITMAP bmnuvoton_logo;
	extern GUI_CONST_STORAGE GUI_BITMAP My_logo;
	extern GUI_CONST_STORAGE GUI_BITMAP bmjpg;
	extern GUI_CONST_STORAGE GUI_BITMAP bmgirl;
	extern GUI_CONST_STORAGE GUI_FONT GUI_font;
	extern GUI_CONST_STORAGE GUI_FONT GUI_Font28x28c28;
	extern GUI_CONST_STORAGE GUI_FONT GUI_Fon14x14;
	extern GUI_CONST_STORAGE GUI_FONT GUI_Fon25x25c;
	extern GUI_CONST_STORAGE GUI_FONT GUI_Fon22x22c;
	extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese22;
	extern uint8_t pdma_start_flag;
	extern const char *init_En;
	extern const char *init_Big5;
	extern const char *version_En;
	uint8_t testData;

	printf("Run MainTask()....\n");
	GUI_Delay(100);
	WM_SetCreateFlags(WM_CF_MEMDEV); // 必須在 GUI_Init() 前
	GUI_Init();
	WM_MULTIBUF_Enable(1);
	GUI_SetBkColor(GUI_BLACK);
	GUI_Clear();
	GUI_Delay(100);

	/////////////////////////////////////
	/*GUI_SetFont(&GUI_Fon22x22c);
	GUI_UC_SetEncodeUTF8();
	for (i = 0; i < 5; i++)
		GUI_DispNextLine();
	GUI_DispString(apStringsKilews2[0]);
*/

	/*GUI_DispNextLine();
	GUI_DispNextLine();
	GUI_SetFont(GUI_FONT_24_1);
	Show_FW_Version2(LCD_Version,SA_Version);
	*/
	////////////////////////////////////
	/*GUI_SetFont(&GUI_FontChinese22);
	GUI_UC_SetEncodeUTF8();

GUI_DispNextLine();
GUI_DispNextLine();
GUI_DispNextLine();
GUI_DispNextLine();
GUI_DispNextLine();
	GUI_DispString(init_Big5);

	GUI_SetFont(&GUI_FontChinese22);
	GUI_UC_SetEncodeUTF8();
GUI_DispNextLine();
GUI_DispNextLine();
	GUI_DispString(init_En);

	GUI_SetFont(&GUI_FontChinese22);
	GUI_UC_SetEncodeUTF8();
GUI_DispNextLine();
GUI_DispNextLine();
	GUI_DispString(version_En);
	*/
	GUI_SetFont(&GUI_FontFont_Boot_Menu_MicrosoftJhengHei_22B);
	GUI_UC_SetEncodeUTF8();
	GUI_DispNextLine();
	GUI_DispNextLine();
	GUI_DispNextLine();
	GUI_DispNextLine();
	GUI_DispNextLine();
	GUI_DispNextLine();

	GUI_SetTextAlign(GUI_TA_HCENTER);
	GUI_DispStringAt(init_Big5, LCD_GetXSize() / 2, GUI_GetDispPosY());

	// 英文初始化
	GUI_SetFont(&GUI_FontFont_Boot_Menu_MicrosoftJhengHei_22B);
	GUI_UC_SetEncodeUTF8();
	GUI_DispNextLine();
	GUI_DispNextLine();
	GUI_SetTextAlign(GUI_TA_HCENTER);
	GUI_DispStringAt(init_En, LCD_GetXSize() / 2, GUI_GetDispPosY());

	// 版本號
	GUI_SetFont(&GUI_FontFont_Boot_Menu_MicrosoftJhengHei_22B);
	GUI_UC_SetEncodeUTF8();
	GUI_DispNextLine();
	GUI_DispNextLine();
	GUI_SetTextAlign(GUI_TA_HCENTER);
	GUI_DispStringAt(version_En, LCD_GetXSize() / 2, GUI_GetDispPosY());

	////////////////////////////////////

	PA6 = 1;

	GUI_Delay(1500);
	//	 while(1){};測試代碼
	GUI_SetBkColor(GUI_WHITE);

	GUI_Clear();
	GUI_Delay(100);

	Pg_home_array_init();
	language_version = Read_DataFlash(APROM_END);
	Delay_NmS(3);
	if (language_version > 2)
	{
		language_version = 0;
		testData = language_version;
		WriteDataFlash(testData);
		Delay_NmS(3);
	}
	pdma_start_flag = 1;

	if (language_version == 0)
		hWin_Temp = CreateMain_EN(); //
	else if (language_version == 1)
		hWin_Temp = CreateMain_BIG5();
	else
		hWin_Temp = CreateMain_GB();


	hWin_MPage = hWin_Temp;
	Main_Page = 0;
	// hWin_Temp = CreateS3_1_Sequence_EN();
	//	hWin_Temp = CreateMain_BIG5();//
	// hWin_Temp = CreateMain_GB();//
	// hWin_Temp = CreateS1_Tool_Mode_EN();
	// hWin_Temp = CreateS1_Tool_Mode_BIG5();
	// hWin_Temp = CreateS1_Tool_Mode_GB();
	//	hWin_Temp = 	CreateS2_Switch_Job_EN();
	//	hWin_Temp = 	CreateS2_Switch_Job_BIG5();
	//	hWin_Temp = 	CreateS2_Switch_Job_GB();
	//	hWin_Temp = 	CreateS3_Job_EN();
	//		hWin_Temp = 	CreateS3_Job_BIG5();
	//		hWin_Temp = 	CreateS3_Job_GB();
	//	hWin_Temp = 	CreateS4_Network_Info_EN();
	//	hWin_Temp = 	CreateS4_Network_Info_BIG5();
	//	hWin_Temp = 	CreateS4_Network_Info_GB();
	// hWin_Temp = 	CreateS3_1_Sequence_EN();
	//	hWin_Temp = 	CreateS3_1_Sequence_BIG5();
	//	hWin_Temp = 	CreateS3_1_Sequence_GB();
	// hWin_Temp = 	CreateS3_2_Step1_2A_EN();
	// hWin_Temp = 	CreateS3_2_Step1_2A_BIG5();
	//	hWin_Temp = 	CreateS3_2_Step1_2A_GB();
	// hWin_Temp = 	CreateS3_1A_Step1_1_EN();
	// hWin_Temp = 	CreateS3_1A_Step1_1_BIG5();
	// hWin_Temp = 	CreateS3_1A_Step1_1_GB();
	// hWin_Temp = 	CreateS5_Network_AP_Info_EN();
	// hWin_Temp = 	CreateS5_Network_AP_Info_BIG5();
	// hWin_Temp = 	CreateS5_Network_AP_Info_GB();
	//	hWin_Temp = 	CreateS6_Driver_Info_EN();
	// hWin_Temp = 	CreateS6_Driver_Info_BIG5();
	//	hWin_Temp = 	CreateS6_Driver_Info_GB();
	//	hWin_Temp = 	CreateS7_1_Language_EN();
	// hWin_Temp = 	CreateS7_1_Language_BIG5();
	//	hWin_Temp = 	CreateS7_1_Language_GB();
	// GUI_Delay(1000);
	PF2 = 0; // jacob 20241223 barcode power on

	while (1)
	{
		FRAMEWIN_Change_Check();
		UART1_RX_Process();
		if ((U0RX_CT >= 30) && (U0RX_Index > 0))
		{
			U1TX[0] = 0x3B;
			U1TX[1] = 0x2C;
			U1TX[2] = U0RX_Index + 2;
			U1TX[3] = 0xB1;
			memcpy(&U1TX[4], &U0RX[0], U0RX_Index);
			U1TX[4 + U0RX_Index] = 0;

			for (i = 2; i < (2 + 2 + U0RX_Index); i++)
				U1TX[4 + U0RX_Index] += U1TX[i];

			UART_Write(UART1, &U1TX[0], (4 + U0RX_Index + 1));
			for (i = 0; i < sizeof(U0RX); i++)
				U0RX[i] = 0;

			U0RX_CT = 0;
			U0RX_Index = 0;
			PC0 = 1;
		}
		if (BarcodeScan_Timer.Timeout_F == 1)
		{
			BarcodeScan_Timer.Timeout_F = 0;
			PC0 = 1;
		}
		GUI_Exec();
		WM_Exec();
		GUI_Delay(10);
	}
}

void I2C_Init(void)
{
	/* Set I2C0 multi-function pins */
	SYS->GPB_MFPL = (SYS->GPB_MFPL & ~(SYS_GPB_MFPL_PB4MFP_Msk | SYS_GPB_MFPL_PB5MFP_Msk)) |
					(SYS_GPB_MFPL_PB4MFP_I2C0_SDA | SYS_GPB_MFPL_PB5MFP_I2C0_SCL);
	/* Enable I2C0 module clock */
	CLK_EnableModuleClock(I2C0_MODULE);
	/* Open I2C module and set bus clock */
	I2C_Open(I2C0, 100000);
	I2C_EnableInt(I2C0);
	NVIC_EnableIRQ(I2C0_IRQn);
}

void UART_Init(void)
{
	/* Enable peripheral clock */
	CLK_EnableModuleClock(UART0_MODULE);
	CLK_EnableModuleClock(UART1_MODULE);

	/* Set PB multi-function pins for UART0 RXD=PB.12(�}�o��P119) and TXD=PB.13(�}�o��P118) */
	SYS->GPB_MFPH = (SYS->GPB_MFPH & ~(SYS_GPB_MFPH_PB12MFP_Msk | SYS_GPB_MFPH_PB13MFP_Msk)) |
					(SYS_GPB_MFPH_PB12MFP_UART0_RXD | SYS_GPB_MFPH_PB13MFP_UART0_TXD);
	/* Set PA multi-function pins for UART1 RXD=PA.2(�}�o��P58�ANU4-Pin6) and TXD=PA.3(�}�o��P57�ANU4-Pin3) */
	SYS->GPA_MFPL = (SYS->GPA_MFPL & ~(SYS_GPA_MFPL_PA2MFP_Msk | SYS_GPA_MFPL_PA3MFP_Msk)) |
					(SYS_GPA_MFPL_PA2MFP_UART1_RXD | SYS_GPA_MFPL_PA3MFP_UART1_TXD);

	UART_SetLine_Config(UART0, 115200, UART_WORD_LEN_8, UART_PARITY_NONE, UART_STOP_BIT_1);
	UART_EnableInt(UART0, UART_INTEN_RDAIEN_Msk);
	NVIC_EnableIRQ(UART02_IRQn);

	UART_SetLine_Config(UART1, 115200, UART_WORD_LEN_8, UART_PARITY_NONE, UART_STOP_BIT_1);
	UART_EnableInt(UART1, UART_INTEN_RDAIEN_Msk);
	NVIC_EnableIRQ(UART13_IRQn);
}

void TIMER_Init(void)
{
	//
	// Enable Timer0 clock and select Timer0 clock source
	//
	CLK_EnableModuleClock(TMR0_MODULE);
	//    CLK_SetModuleClock(TMR0_MODULE, CLK_CLKSEL1_TMR0SEL_HXT, 0);
	CLK_SetModuleClock(TMR0_MODULE, CLK_CLKSEL1_TMR0SEL_HIRC, 80);
	//
	// Initial Timer0 to periodic mode with 1000Hz
	//
	TIMER_Open(TIMER0, TIMER_PERIODIC_MODE, 1000); // 1mS�A2022/09/01
	//
	// Enable Timer0 interrupt
	//
	TIMER_EnableInt(TIMER0);
	NVIC_SetPriority(TMR0_IRQn, 1);
	NVIC_EnableIRQ(TMR0_IRQn);
	//
	// Start Timer0
	//
	TIMER_Start(TIMER0);
}

void WriteDataFlash(uint32_t u32Data)
{
	SYS_UnlockReg();
	FMC_Open();
	FMC_ENABLE_AP_UPDATE();
	FMC_Erase(APROM_END);
	FMC_Write(APROM_END, u32Data);
	FMC_Close();

	SYS_LockReg();
}

uint32_t Read_DataFlash(uint32_t u32Addr)
{
	uint32_t data;
	SYS_UnlockReg();
	FMC_Open();
	data = FMC_Read(u32Addr);
	FMC_Close();
	SYS_LockReg();

	return data;
}
extern uint8_t Temp_language_version;
void Pg_home_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_Language_0_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_Call_Job_0_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_JS_0_Job_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_JS_1_JobSEQ_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_JS_2_Step2_1_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_JS_3_Step2_2_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_Net_AP_Info_0_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_Tool_Info_0_array_init(void)
{

	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_Tool_Mode_0_array_init(void)
{

	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void Pg_Net_Info_0_array_init(void)
{
	memset(&Temp_Pg_Home, 255, sizeof(Pg_Home_TypeDef));
	memset(&Temp_Pg_Language_0, 255, sizeof(Pg_Language_0_TypeDef));
	memset(&Temp_Pg_Call_Job_0, 255, sizeof(Pg_Call_Job_0_TypeDef));
	memset(&Temp_Pg_JS_0_Job, 255, sizeof(Pg_JS_0_Job_TypeDef));
	memset(&Temp_Pg_JS_1_JobSEQ, 255, sizeof(Pg_JS_1_JobSEQ_TypeDef));
	memset(&Temp_Pg_JS_2_Step2_1, 255, sizeof(Pg_JS_2_Step2_1_TypeDef));
	memset(&Temp_Pg_JS_3_Step2_2, 255, sizeof(Pg_JS_3_Step2_2_TypeDef));
	memset(&Temp_Pg_Net_AP_Info_0, 255, sizeof(Pg_Net_AP_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Info_0, 255, sizeof(Pg_Tool_Info_0_TypeDef));
	memset(&Temp_Pg_Tool_Mode_0, 255, sizeof(Pg_Tool_Mode_0_TypeDef));
	memset(&Temp_Pg_Net_Info_0, 255, sizeof(Pg_Net_Info_0_TypeDef));
	Temp_language_version = 255;
	Temp_Pg_Tool_Info_0.PCB_T = 127;
	Temp_Pg_Tool_Info_0.Batt_Temp = 127;
	Temp_language_version = 255;
}
void ShowGUI_MemoryUsage(void)
{
	U32 numFree = GUI_ALLOC_GetNumFreeBytes();								  // ?????
	U32 numUsed = GUI_ALLOC_GetNumUsedBytes();								  // ??????
	U32 numTotal = GUI_ALLOC_GetNumFreeBytes() + GUI_ALLOC_GetNumUsedBytes(); // ????
	U32 maxFree = GUI_ALLOC_GetMaxSize();									  // ???????????

	char buf[128];
	sprintf(buf,
			"GUI Memory:\n"
			" Total: %lu bytes\n"
			" Used : %lu bytes\n"
			" Free : %lu bytes\n"
			" MaxFreeBlock: %lu bytes\n",
			numTotal, numUsed, numFree, maxFree);

	GUI_DispStringAt(buf, 10, 10); // ????? (10,10)
}
