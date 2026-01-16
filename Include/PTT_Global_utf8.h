#include <stdio.h>			//for sprintf() Library
// #include <stdlib.h>
#include <stdint.h>			//for uint8_t、uint16_t、uint32_t
#include <string.h>			//for memcpy

#include "M031Series.h"
#include "NuMicro.h"		//for PB14

#include "PTT_TypeDef.h"	//2022/01/19

#include "TouchPanel.h"
#include "GUI.h"
#include "DIALOG.h"
#include "FRAMEWIN.h"
#include "WM.h"
#include "lcm.h"			//2021/10/20
#include "IMAGE.h"			//for IMAGE_SetPNG()

// #ifdef    _MAINMODUL
// uint8_t extern_test;			//由main.c定義_MAINMODUL。OK    
// #else
// extern uint8_t extern_test;		//直接extern使用變數，沒有先定義測試。結果：Error: L6218E: Undefined symbol extern_test (referred from main.o). 
// #endif

// #define Debug_BLE_SlaveMode_J		//測試用，BLE在控制器上模擬SLAVE模式
// #define Debug_BLE_TxRx_Time_J		//測試用，量測BLE MasterTX後，再由Slave回傳完整訊息後的總時間(PTM CMD1當測試點)

// #define AutoTest_Mode_J			//耐久自動測試用
// #define Debug_Mode_J			//測試用LOG
// #define Timing_Debug_J			//測試用，顯示時序
// #define Show_CheckSum_J		"1124"			//開機版本後面顯示CheckSum

// #define Ignore_CMD_CheckSum_J	//測試用，忽略CMD的CheckSum檢查
// #define Debug_PA8_ExtInPin13	//測試用，外部IO有電容，無法觀測高速切換 2020/04/20
// #define BZ_Is_PB0_RXD0		//測試用
// #define Debug_PB0			//PB0(BZ)測試用
// #define Debug_PA9_LED7		//PA9(LED7電源燈)測試用
// #define BZ_Disable		//將BZ的IO設為Input

#define SPI_3wire_EN		1//預設SPI_4wire，宣告後為SPI_3wire。2022/10/06
#define ST7789VI_G4			//for GTF240320-020002(240x320)、GTF240240-0154A3(240x240)。取消宣告等於預設ST7789V
// #define ST7789V				//for GTF240320-0240C3(240x320)。預設無其他宣告使用ST7789V


// #include "M031Series.h"
// #include "Global.h"			//for U8、U16、U32。I8、I16、I32
#include "PTT_NVRAM.h"			//2021/11/24
#include "DialogFunction.h"


// #include "PTMCtrl_Init.h"

// #define Delay_NmS(x)	CLK_SysTickDelay((x*1000))
// #define Delay_NuS(x)	CLK_SysTickDelay(x)			//include clk.h

//8Bit上限255=1.275S
//16Bit上限65535=327675S
#define T0Unit		5		//1=5mS, 1000=Hold for 4995mS~5000mS by Timer.
#define T0_50mS		(  50 / T0Unit)
#define T0_100mS	( 100 / T0Unit)
#define T0_250mS	( 250 / T0Unit)
#define T0_300mS	( 300 / T0Unit)
#define T0_500mS	( 500 / T0Unit)                                                      
#define T0_900mS	( 900 / T0Unit)                                                      
#define T0_1S		(1000 / T0Unit)
#define T0_2S		(2000 / T0Unit)

WM_HWIN CreateFramewin(void);
WM_HWIN CreateSetting(void);	//2021/10/25
WM_HWIN CreateWindow(void);		//2021/10/25
WM_HWIN CreateMain_EN(void);		//2021/11/11
WM_HWIN CreateMain_BIG5(void);		//2021/11/11
WM_HWIN CreateMain_GB(void);		//2021/11/11
WM_HWIN CreateS1_Tool_Mode_EN(void);		//2021/12/21
WM_HWIN CreateS1_Tool_Mode_BIG5(void);		//2021/12/21
WM_HWIN CreateS1_Tool_Mode_GB(void);		//2021/12/21
WM_HWIN CreateS2_Switch_Job_EN(void);		//2021/12/21
WM_HWIN CreateS2_Switch_Job_BIG5(void);		//2021/12/22
WM_HWIN CreateS2_Switch_Job_GB(void);		//2021/12/22
WM_HWIN CreateS3_Job_EN(void);		//2021/12/23
WM_HWIN CreateS3_Job_BIG5(void);		//2021/12/23
WM_HWIN CreateS3_Job_GB(void);
WM_HWIN CreateS4_Network_Info_EN(void);
WM_HWIN CreateS4_Network_Info_BIG5(void);
WM_HWIN CreateS4_Network_Info_GB(void);
WM_HWIN CreateS3_1_Sequence_EN(void);
WM_HWIN CreateS3_1_Sequence_BIG5(void);
WM_HWIN CreateS3_1_Sequence_GB(void);
WM_HWIN CreateS3_2_Step1_2A_EN(void);
WM_HWIN CreateS3_2_Step1_2A_BIG5(void);
WM_HWIN CreateS3_2_Step1_2A_GB(void);
WM_HWIN CreateS3_1A_Step1_1_EN(void);
WM_HWIN CreateS3_1A_Step1_1_BIG5(void);
WM_HWIN CreateS3_1A_Step1_1_GB(void);
WM_HWIN CreateS5_Network_AP_Info_EN(void);
WM_HWIN CreateS5_Network_AP_Info_BIG5(void);
WM_HWIN CreateS5_Network_AP_Info_GB(void);
WM_HWIN CreateS6_Driver_Info_EN(void);
WM_HWIN CreateS6_Driver_Info_BIG5(void);
WM_HWIN CreateS6_Driver_Info_GB(void);
WM_HWIN CreateS7_1_Language_EN(void);
WM_HWIN CreateS7_1_Language_BIG5(void);
WM_HWIN CreateS7_1_Language_GB(void);


void UART1_RX_Process(void);

int ExecMain(int x0, int y0);	//2022/09/02 test
WM_HWIN CreateWinMain(void);	//2022/09/08 test
