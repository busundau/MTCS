#include "GUI.h"
#include "PTT_Global.h"
#include <stdint.h>

#include "DIALOG.h"
#include "TEXT.h"


/*
首頁 button文字中英16 微軟正黑體
首頁其他都是19微軟正黑體

其他頁面 button文字中英16 微軟正黑體
*/
void Show_FW_Version(uint16_t FWVerion, uint16_t SAFWVerion);
void Show_FW_Version2(uint16_t FWVerion, uint16_t SAFWVerion);
void ShowFreeMem(void);
void Nm_unit_Display_x_xxx(int32_t Data);
void Kgf_m_unit_Display_x_xxxx(int32_t Data);
void Kgf_cm_unit_Display_xx_xx(int32_t Data);
void Lbs_In_unit_Display_x_xx(int32_t Data);
void cN_m_unit_Display_xxx_x(int32_t Data);
void Delay_us(uint32_t us);
void Delay_ms(uint32_t ms);
//extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese17B;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese19B;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Pg_Language_MicrosoftJhengHei_22B;
	extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B;
	extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_26B;
	extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Pg_JS_2_Step2_2_MicrosoftJhengHei_22B;
		extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Pg_JS_2_Step2_1_MicrosoftJhengHei_22B;
		extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B;
			extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B;
			extern GUI_CONST_STORAGE GUI_FONT GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B;
uint8_t Show_Tool_FW_Version(uint16_t FWVerion, char *outBuf);
uint8_t DisplayOByDigitIndex(uint8_t textIndex, int8_t value);
uint8_t DisplayOByDigitIndex2(uint8_t textIndex, int8_t value);
void Format_IP_String_Variable(char *output, uint8_t ip1, uint8_t ip2,
                               uint8_t ip3, uint8_t ip4);
void Number32s_to_ASCII_xx_xxx_ptr(char *LCM_Data_Addr, int32_t Data);
extern WM_HWIN hWin_Temp;
TEXT_Handle hText;
void Update_Or_Create_Text(int index, const char *text, int x, int y,
                           WM_HWIN parent);
void negative_ItemValue_Left_Alignment(void);
// void Update_TextItem(WM_HWIN hText);
void Update_TextItem(int textid, int8_t value, int baseX, int baseY);
extern uint8_t language_version;
uint8_t Temp_language_version = 255;
uint8_t Main_Page;
uint8_t Main_Page_Temp = 0;
uint8_t Main_Page_Chg_F;
uint8_t Main_Page_Item;
uint8_t Main_Page_Item_Chg_F;
void ButtonLabelChange(WM_HWIN hWin, uint8_t ButtonId, uint8_t ButtonLabel);
void colorchange(uint8_t colortype, uint8_t loopvar);
void textchange(uint8_t fonttype, uint8_t loopvar);
void Number32s_to_ASCII_xx_xxxx_ptr(char *LCM_Data_Addr, int32_t Data);
uint8_t Step;
#define lightDelay 100 // 50:30min,100:80min 250ms:4min black screen flash
extern void DMA_WaitDone(void);
extern void main_language_template();
extern WM_MESSAGE *pMsgaaa;
extern WM_MESSAGE *pMsgaaa222;
char U0RX[250];
uint8_t U0RX_Index;
uint16_t U0RX_CT;
char U1RX[250];
uint8_t U1RX_Index;
uint16_t U1RX_CT;
uint8_t U1RX_Process_1T;
uint8_t U1RX_Pre[25]; //
uint8_t U0TX[4];
uint8_t U1TX[255];
uint8_t U1TX_Index;
void PageValue_Clear(uint8_t size, char arr[]);
extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese22;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese16;
Timer_TypeDef BarcodeScan_Timer;
uint8_t CMD_Check;
uint8_t Page_Check;
uint8_t Protocol_CheckSum;
uint8_t PTM_Log_EN; // 1=�}�ҡA��L=����(�w�])
uint8_t CheckSum_Index;
uint8_t T1_50mS_F;
uint8_t Match_F;
uint8_t Action_CT;
uint8_t Itme_Point;
uint8_t Itme_Point_Temp;
Pg_Home_TypeDef Pg_Home, Temp_Pg_Home;                         // jacob 20250613
Pg_Language_0_TypeDef Pg_Language_0, Temp_Pg_Language_0;       // jacob 20250613
Pg_Call_Job_0_TypeDef Pg_Call_Job_0, Temp_Pg_Call_Job_0;       // jacob 20250613
Pg_JS_0_Job_TypeDef Pg_JS_0_Job, Temp_Pg_JS_0_Job;             // jacob 20250613
Pg_JS_1_JobSEQ_TypeDef Pg_JS_1_JobSEQ, Temp_Pg_JS_1_JobSEQ;    // jacob 20250613
Pg_JS_2_Step2_1_TypeDef Pg_JS_2_Step2_1, Temp_Pg_JS_2_Step2_1; // jacob 20250613
Pg_JS_3_Step2_2_TypeDef Pg_JS_3_Step2_2, Temp_Pg_JS_3_Step2_2; // jacob 20250613
Pg_Net_AP_Info_0_TypeDef Pg_Net_AP_Info_0,
    Temp_Pg_Net_AP_Info_0;                                  // jacob 20250108
Pg_Tool_Info_0_TypeDef Pg_Tool_Info_0, Temp_Pg_Tool_Info_0; // jacob 20250108
Pg_Tool_Mode_0_TypeDef Pg_Tool_Mode_0, Temp_Pg_Tool_Mode_0; // jacob 20250108

Pg_Net_Info_0_TypeDef Pg_Net_Info_0, Temp_Pg_Net_Info_0; // jacob 20250108

// Page71_TypeDef Page71; //jacob 20250108

uint8_t for_i8b;
uint16_t for_i16b;
uint8_t Batt; // test
uint8_t PROGBAR_Color_1T;
Fucn_WM_HWIN hItems;
WM_HWIN hWin_MPage;
uint8_t Data_2D2[8];
char ItemValue[50];
char ItemValue2[50];
char buffer[100]; // 根據您的需求調整大小
void build_title_string(char *ItemValue, const char *JobPrefix,
                        const char *SeqPrefix, const char *StepPrefix,
                        int Job_ID, int Seq_ID, int Step_ID);

extern const char *CW_Big5;
extern const char *CW_GB;
extern const char *CCW_Big5;
extern const char *CCW_GB;
extern const char *On_Big5;
extern const char *On_GB;
extern const char *Off_Big5;
extern const char *Off_GB;
extern const char *CW_Big5;
extern const char *CW_GB;
extern const char *CCW_Big5;
extern const char *CCW_GB;
extern const char *Clear_BIG5;
extern const char *SeqClear_BIG5;
extern const char *Clear_GB;
extern const char *SeqClear_GB;
extern const char *Page_Big5;
extern const char *Barcode_Big5;
extern const char *Confirm_Big5;
extern const char *Page_Up_Big5;
extern const char *Page_Down_Big5;
extern const char *Enter_Big5;
extern const char *Page_Up_GB;
extern const char *Page_Down_GB;
extern const char *Enter_GB;
extern const char *Back_Big5;
extern const char *Select_Big5;
extern const char *Back_GB;
extern const char *Select_GB;
extern const char *Page_GB;
extern const char *Barcode_GB;
extern const char *Confirm_GB;
extern const char *Sequence_Big5;
extern const char *Sequence_GB;
extern const char *Step_Big5;
extern const char *Step_GB;
extern const char *English_Big5;
extern const char *Big5_Big5;
extern const char *GB_Big5;
extern const char *English_GB;
extern const char *Big5_GB;
extern const char *GB_GB;
extern char Thresholde_Ang_Big5222[];
extern char Downshift_Ang_Big5222[];
extern char Thresholde_Ang_GB222[];
extern char Downshift_Ang_GB222[];
extern char Big5_GB222[];
extern char GB_GB222[];
extern char Big5_GB222[];
extern char GB_GB222[];
extern char DHCP_GB222[];
extern char SS_GB222[];
extern char DHCP_Big5222[];
extern char SS_Big5222[];
extern char Mute_Big5222[];
extern char Mute_GB222[];
extern const char *Target_Tor_Big5;
extern const char *Target_Ang_Big5;
extern const char *Target_Tor_GB;
extern const char *Target_Ang_GB;
extern const char *Kgf_m_Big5;
extern const char *Nm_Big5;
extern const char *Kgf_cm_Big5;
extern const char *In_lbs_Big5;
extern const char *cN_m_Big5;
extern const char *Kgf_m_GB;
extern const char *Nm_GB;
extern const char *Kgf_cm_GB;
extern const char *In_lbs_GB;
extern const char *cN_m_GB;
extern const char *Degree_Big5;
extern const char *Degree_GB;
extern const char *RPM_Big5;
extern const char *RPM_GB;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese16;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese4;
// main
extern const char *Data_Upload_Big5;
extern const char *Data_Upload_GB;
extern const char *Data_Fulld_Big5;
extern const char *Setting_Big5;
extern const char *Data_Fulld_GB;
extern const char *Setting_GB;
extern const char *Page_Big5;
extern const char *Barcode_Big5;
extern const char *Confirm_Big5;
extern const char *Page_Up_Big5;
extern const char *Page_Down_Big5;
extern const char *Enter_Big5;
extern const char *Page_Up_GB;
extern const char *Page_Down_GB;
extern const char *Enter_GB;
extern const char *Back_Big5;
extern const char *Select_Big5;
extern const char *Back_GB;
extern const char *Select_GB;
extern const char *Page_GB;
extern const char *Barcode_GB;
extern const char *Confirm_GB;
extern const char *Sequence_Big5;
extern const char *Sequence_GB;
extern const char *Step_Big5;
extern char Step_Big5222[];
extern const char *Step_GB;
extern const char *Mute_Big5;
extern const char *Mute_GB;
extern const char *Kgf_m_Big5;
extern const char *Nm_Big5;
extern const char *Kgf_cm_Big5;
extern const char *In_lbs_Big5;
extern const char *cN_m_Big5;
extern const char *RPM_Big5;
extern const char *Kgf_m_GB;
extern const char *Nm_GB;
extern const char *Kgf_cm_GB;
extern const char *In_lbs_GB;
extern const char *cN_m_GB;
extern const char *RPM_GB;
// 10
extern const char *Tool_Mode_Big5;
extern const char *Tool_Mode_GB;
// 20
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese16;
extern const char *Switch_Job_Big5;
extern const char *Switch_Job_GB;
// 30
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese16;
extern const char *Job_Big5;
extern const char *Job_GB;
// 31
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese16;
extern const char *Job_GB;
extern const char *Seq_GB;
extern const char *Job_Big5;
extern const char *Seq_Big5;
extern const char *Sequence_GB;
extern const char *Sequence_Big5;
// 32
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese16;
extern const char *Next_Big5;
extern const char *Back_Big5;
extern const char *Step_Big5;
extern const char *Next_GB;
extern const char *Back_GB;
extern const char *Step_GB;
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese16;
extern const char *RPM_Big5; //????
extern const char *Nm_Big5;  //????
extern const char *Sec_Big5;
extern const char *RPM_GB; //????
extern const char *Nm_GB;  //????
extern const char *Sec_GB;
extern const char *Degree_Big5;
extern const char *Degree_GB;
//
// 33
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontTitleChinese16;
extern const char *Step_Big5;
extern const char *Step_GB;
extern const char *Back_Big5;
extern const char *Next_Big5;
extern const char *Step_Big5;
extern const char *Back_GB;
extern const char *Next_GB;
extern const char *Step_GB;
/////////////////////////////
extern char English_Big5222[];
extern char Big5_Big5222[];
extern char GB_Big5222[];
extern char English_GB222[];
extern char Big5_GB222[];
extern char GB_GB222[];

/////////////////////////////
extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese22;
// main
extern const char *Job_Big5;
extern const char *Seq_Big5;
extern const char *Step_Big5;
extern const char *Job_GB;
extern const char *Seq_GB;
extern const char *Step_GB;
// 10
extern const char *Stand_Alone_Big5;
extern const char *Controlled_Big5;
extern const char *Tool_Big5;
extern const char *WIFI_Big5;
extern const char *Stand_Alone_GB;
extern const char *Controlled_GB;
extern const char *Tool_GB;
extern const char *WIFI_GB;
// 20
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese22;
extern const char *Job_ID_Big5;
extern const char *Job_ID_GB;
// 30
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese22;
extern const char *Job_Name_Big5;
extern const char *Job_OK_Big5;
extern const char *Stop_Job_on_OK_Big5;
extern const char *More_Big5;
extern const char *Job_Name_GB;
extern const char *Job_OK_GB;
extern const char *Stop_Job_on_OK_GB;
extern const char *More_GB;
// 31
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese22;
extern const char *SeqName_Big5;
extern const char *Select_Tool_Name_Big5;
extern const char *Ti_Repeat_Big5;
extern const char *Stop_on_NG_Big5;
extern const char *Sequence_OK_Big5;
extern const char *Stop_Seq_on_OK_Big5;
extern const char *Sequence_Big5;
extern const char *SeqName_GB;
extern const char *Select_Tool_Name_GB;
extern const char *Ti_Repeat_GB;
extern const char *Stop_on_NG_GB;
extern const char *Sequence_OK_GB;
extern const char *Stop_Seq_on_OK_GB;
extern const char *Sequence_GB;
// 32
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese22;
extern const char *Step_ID_Big5;
extern const char *Target_Tor_Big5;
extern const char *Direction_Big5;
extern const char *Joint_Offset_Big5;
extern const char *Delay_Time_Big5;
extern const char *Speed_Big5;
extern const char *Step_ID_GB;
extern const char *Target_Tor_GB;
extern const char *Direction_GB;
extern const char *Joint_Offset_GB;
extern const char *Delay_Time_GB;
extern const char *Speed_GB;
// 33
// extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese22;
extern const char *High_Torque_Big5;
extern const char *Low_Torque_Big5;
extern const char *High_Angle_Big5;
extern const char *Low_Angle_Big5;
extern const char *Thresholde_Tor_Big5;
extern const char *Downshift_Tor_Big5;
extern const char *Downshift_Spd_Big5;
extern const char *High_Torque_GB;
extern const char *Low_Torque_GB;
extern const char *High_Angle_GB;
extern const char *Low_Angle_GB;
extern const char *Thresholde_Tor_GB;
extern const char *Downshift_Tor_GB;
extern const char *Downshift_Spd_GB;
extern GUI_CONST_STORAGE GUI_FONT GUI_FontChinese26;
// main
extern const char *Counter_Big5;
extern const char *Torque_Big5;
extern const char *Angle_Big5;
extern const char *Speed_Big5;
extern const char *Counter_GB;
extern const char *Torque_GB;
extern const char *Angle_GB;
extern const char *Speed_GB;
extern const char *Defaults_Setting_Resets_Big5;
extern const char *Defaults_Setting_Resets_GB;
extern const char *Thresholde_Ang_Big5;
extern const char *Downshift_Ang_Big5;
extern const char *Thresholde_Ang_GB;
extern const char *Downshift_Ang_GB;
//??-??
extern char Job_Big5222[];
extern char Seq_Big5222[];
extern char Job_GB222[];
extern char Seq_GB222[];
extern char Step_GB222[];
extern char Kgf_m_GB222[];
extern char Nm_GB222[];
extern char Kgf_cm_GB222[];
extern char In_lbs_GB222[];
extern char cN_m_GB222[];
extern char Kgf_m_Big5222[];
extern char Nm_Big5222[];
extern char Kgf_cm_Big5222[];
extern char In_lbs_Big5222[];
extern char cN_m_Big5222[];
extern const char *Downshift_Spd_GB;

extern const char *E02_EN;
extern const char *E02_Big5;
extern const char *E02_GB;

extern const char *E03_EN;
extern const char *E03_Big5;
extern const char *E03_GB;

extern const char *E04_EN;
extern const char *E04_Big5;
extern const char *E04_GB;

extern const char *E05_EN;
extern const char *E05_Big5;
extern const char *E05_GB;

extern const char *E06_EN;
extern const char *E06_Big5;
extern const char *E06_GB;

extern const char *E08_EN;
extern const char *E08_Big5;
extern const char *E08_GB;

extern const char *E09_EN;
extern const char *E09_Big5;
extern const char *E09_GB;

extern const char *E10_EN;
extern const char *E10_Big5;
extern const char *E10_GB;

extern const char *E11_EN;
extern const char *E11_Big5;
extern const char *E11_GB;

extern const char *E12_EN;
extern const char *E12_Big5;
extern const char *E12_GB;

extern const char *E14_EN;
extern const char *E14_Big5;
extern const char *E14_GB;

extern const char *E16_EN;
extern const char *E16_Big5;
extern const char *E16_GB;

extern const char *E18_EN;
extern const char *E18_Big5;
extern const char *E18_GB;

extern const char *E23_EN;
extern const char *E23_Big5;
extern const char *E23_GB;

extern const char *E23_NS_EN;
extern const char *E23_NS_Big5;
extern const char *E23_NS_GB;

extern const char *E24_EN;
extern const char *E24_Big5;
extern const char *E24_GB;

extern const char *E24_NS_EN;
extern const char *E24_NS_Big5;
extern const char *E24_NS_GB;

extern const char *E25_EN;
extern const char *E25_Big5;
extern const char *E25_GB;

extern const char *E25_NS_EN;
extern const char *E25_NS_Big5;
extern const char *E25_NS_GB;

extern const char *E26_EN;
extern const char *E26_Big5;
extern const char *E26_GB;

extern const char *E26_NS_EN;
extern const char *E26_NS_Big5;
extern const char *E26_NS_GB;

extern const char *E27_EN;
extern const char *E27_Big5;
extern const char *E27_GB;

extern const char *E27_NS_EN;
extern const char *E27_NS_Big5;
extern const char *E27_NS_GB;


extern const char *C32_EN;
extern const char *C32_Big5;
extern const char *C32_GB;

extern const char *C33_EN;
extern const char *C33_Big5;
extern const char *C33_GB;

extern const char *C35_EN;
extern const char *C35_Big5;
extern const char *C35_GB;

extern const char *E36_EN;
extern const char *E36_Big5;
extern const char *E36_GB;

extern const char *E37_EN;
extern const char *E37_Big5;
extern const char *E37_GB;

extern const char *C130_EN ;
extern const char *C130_Big5 ;
extern const char *C130_GB ;

extern const char *C129_EN ;
extern const char *C129_Big5 ;
extern const char *C129_GB ;

extern const char *C109_EN ;
extern const char *C109_Big5 ;
extern const char *C109_GB ;

extern const char *C124_EN ;
extern const char *C124_Big5 ;
extern const char *C124_GB ;

extern const char *C125_EN ;
extern const char *C125_Big5;
extern const char *C125_GB ;

extern const char *C126_EN ;
extern const char *C126_Big5;
extern const char *C126_GB ;

extern const char *C128_EN ;
extern const char *C128_Big5;
extern const char *C128_GB ;

extern const char *C132_EN ;
extern const char *C132_Big5;
extern const char *C132_GB ;

extern const char *C133_EN ;
extern const char *C133_Big5 ;
extern const char *C133_GB ;

extern const char *C134_EN ;
extern const char *C134_Big5 ;
extern const char *C134_GB ;

extern const char *C135_EN ;
extern const char *C135_Big5 ;
extern const char *C135_GB;
uint8_t saveindex = 0;
/////////////////////////
char s_Buf[20];
WM_KEY_INFO My_KEY;
int X0, Y0;
FRAMEWIN_SKINFLEX_PROPS FRAMEWIN_MySKIN_ACT0;
FRAMEWIN_SKINFLEX_PROPS FRAMEWIN_MySKIN_ACT1;
PROGBAR_SKINFLEX_PROPS PROGBAR_MySKIN_ACT0;
PROGBAR_SKINFLEX_PROPS PROGBAR_MySKIN_ACT1;
uint8_t Temp8b;
uint16_t Temp16b;
uint32_t Temp32b;
extern uint8_t change_GUI_flag;
extern GUI_WIDGET_CREATE_INFO _aDialogCreate222[];
extern GUI_WIDGET_CREATE_INFO _aDialogCreate1[];
#define changePagedelay 30
extern void WriteDataFlash(uint32_t u32Data);
void FRAMEWIN_Change_Check(void)
{
  int i;
  uint8_t testData;
  uint8_t testAddr;
  // 這段程式碼主要用於判斷頁面切換及語言設定變更，並根據不同情況執行相應的操作
  if ((Main_Page != Main_Page_Temp) || (change_GUI_flag == 1)) // 如果主頁(Main_Page)有變，或是切換GUI的旗標(change_GUI_flag)被設為1，則進入此判斷。
  {
    if (change_GUI_flag == 1)
    {
      testData = language_version;
      WriteDataFlash(testData); // 把語言版本寫入Flash
      Delay_NmS(3);             // 延遲3毫秒
      change_GUI_flag = 0;      // 重置旗標
      //	WM_DeleteWindow(hWin_MPage);
      //	GUI_SetBkColor(GUI_WHITE);
      //	GUI_Clear();
      //	WM_ExecIdle();
    }
    else
    {
      // 特定頁面切換例外處理：
      if ((Main_Page == 10 && Main_Page_Temp == 11) ||
          (Main_Page == 11 && Main_Page_Temp == 10) ||
          (Main_Page == 20 && Main_Page_Temp == 21) ||
          (Main_Page == 21 && Main_Page_Temp == 20) ||
          (Main_Page == 30 && Main_Page_Temp == 31 ||
           (Main_Page == 31 && Main_Page_Temp == 30)))
      {
        Main_Page_Temp = Main_Page;
        U1RX_Process_1T = 1;
        return; //// 直接結束本次處理,不做切換頁面處理
      }
      else
      {
        //	WM_DeleteWindow(hWin_MPage);
        //	GUI_Clear();
        //	WM_ExecIdle();
      }
    }
    // 這一行用來刪除（關閉）舊的視窗，確保資源不會重複佔用。
    WM_DeleteWindow(hWin_MPage);
    // 這段程式碼的作用是依據目前語言（language_version）和主頁編號（Main_Page），動態建立對應的 GUI 畫面，並在切換頁面時完成刷新與資源釋放
    /*
    依語言和主頁選擇對應畫面：

    語言分為三種：英文(0)、繁體中文(1)、簡體中文(2)。

    根據主頁數字（Main_Page），呼叫不同語言版本的建立函式。
     */
    if (language_version == 0)
    {
      switch (Main_Page)
      {
      case 0:
        hWin_MPage = CreateMain_EN();
        break;
      case 10:
      case 11:
        hWin_MPage = CreateS7_1_Language_EN();
        break;
      case 20:
      case 21:
        hWin_MPage = CreateS1_Tool_Mode_EN();
        break;
      case 30:
      case 31:
        hWin_MPage = CreateS2_Switch_Job_EN();
        break;
      case 40:
        hWin_MPage = CreateS3_Job_EN();
        break;
      case 41:
        hWin_MPage = CreateS3_1_Sequence_EN();
        break;
      case 42:
        hWin_MPage = CreateS3_1A_Step1_1_EN();
        break;
      case 43:
        hWin_MPage = CreateS3_2_Step1_2A_EN();
        break;
      case 50:
        hWin_MPage = CreateS6_Driver_Info_EN();
        break;
      case 60:
        hWin_MPage = CreateS4_Network_Info_EN();
        break;
      case 70:
        hWin_MPage = CreateS5_Network_AP_Info_EN();
        break;
      default:
        hWin_MPage = CreateMain_EN();
        break;
      }
    }
    else if (language_version == 1)
    {
      switch (Main_Page)
      {
      case 0:
        hWin_MPage = CreateMain_BIG5();
        break;
      case 10:
      case 11:
        hWin_MPage = CreateS7_1_Language_BIG5();
        break;
      case 20:
      case 21:
        hWin_MPage = CreateS1_Tool_Mode_BIG5();
        break;
      case 30:
      case 31:
        hWin_MPage = CreateS2_Switch_Job_BIG5();
        break;
      case 40:
        hWin_MPage = CreateS3_Job_BIG5();
        break;
      case 41:
        hWin_MPage = CreateS3_1_Sequence_BIG5();
        break;
      case 42:
        hWin_MPage = CreateS3_1A_Step1_1_BIG5();
        break;
      case 43:
        hWin_MPage = CreateS3_2_Step1_2A_BIG5();
        break;
      case 50:
        hWin_MPage = CreateS6_Driver_Info_BIG5();
        break;
      case 60:
        hWin_MPage = CreateS4_Network_Info_BIG5();
        break;
      case 70:
        hWin_MPage = CreateS5_Network_AP_Info_BIG5();
        break;
      default:
        hWin_MPage = CreateMain_BIG5();
        break;
      }
    }
    else if (language_version == 2)
    {
      switch (Main_Page)
      {
      case 0:
        hWin_MPage = CreateMain_GB();
        break;
      case 10:
      case 11:
        hWin_MPage = CreateS7_1_Language_GB();
        break;
      case 20:
      case 21:
        hWin_MPage = CreateS1_Tool_Mode_GB();
        break;
      case 30:
      case 31:
        hWin_MPage = CreateS2_Switch_Job_GB();
        break;
      case 40:
        hWin_MPage = CreateS3_Job_GB();
        break;
      case 41:
        hWin_MPage = CreateS3_1_Sequence_GB();
        break;
      case 42:
        hWin_MPage = CreateS3_1A_Step1_1_GB();
        break;
      case 43:
        hWin_MPage = CreateS3_2_Step1_2A_GB();
        break;
      case 50:
        hWin_MPage = CreateS6_Driver_Info_GB();
        break;
      case 60:
        hWin_MPage = CreateS4_Network_Info_GB();
        break;
      case 70:
        hWin_MPage = CreateS5_Network_AP_Info_GB();
        break;
      default:
        hWin_MPage = CreateMain_GB();
        break;
      }
    }
    // 更新GUI畫面：
    // 這幾行用來強制執行並刷新新建立的GUI畫面，確保顯示內容是最新的。
    WM_Update(hWin_MPage);
    GUI_Exec();
    GUI_Delay(1);
    Main_Page_Temp = Main_Page;
    U1RX_Process_1T = 1;
  }
  else
  {
    if (U1RX_Process_1T == 1)
    {
      GUI_StoreKeyMsg(GUI_KEY_ENTER, 1);
      GUI_Delay(1);
    }
  }
}

const char *unit_strings[][5] = {
    {"Kgf.m", Nm_Big5222, Nm_GB222},          // Unit = 0
    {"N.m", Nm_Big5222, Nm_GB222},            // Unit = 1
    {"Kgf.cm", Kgf_cm_Big5222, Kgf_cm_GB222}, // Unit = 2
    {"In.lbs", In_lbs_Big5222, In_lbs_GB222}, // Unit = 3
    {"cN.m", cN_m_Big5222, cN_m_GB222}        // Unit = 4
};

uint8_t *current_modes[5] = {
    &Pg_Tool_Mode_0.StandAlone, &Pg_Tool_Mode_0.Controlled,
    &Pg_Tool_Mode_0.Default, &Pg_Tool_Mode_0.Tool, &Pg_Tool_Mode_0.WIFI};

uint8_t *temp_modes[5] = {&Temp_Pg_Tool_Mode_0.StandAlone,
                          &Temp_Pg_Tool_Mode_0.Controlled,
                          &Temp_Pg_Tool_Mode_0.Default,
                          &Temp_Pg_Tool_Mode_0.Tool, &Temp_Pg_Tool_Mode_0.WIFI};

#define TOOL_NAME_LEN 20
#define IP_LEN 4
#define MAC_LEN 6
#define SSID_EXT_OFFSET 19
#define SSID_EXT_LEN 13 // 31 - 19 + 1
#define TOOL_SN_OFFSET 12
#define TOOL_SN_EXT_LEN 8
#define TYPE_NAME_LEN 12
#define TYPE_NAME_EXT_OFFSET 12
#define TYPE_NAME_EXT_LEN 8

void FRAMEWIN_Display(uint8_t Item_Num)
{
  uint8_t TEXT_Index;
  uint8_t xPos;
  uint8_t for_i;
  uint16_t total_joint_int, total_joint_point;
  uint32_t total_toque_ALL_32bit;
  int32_t total_toque_ALL_32bit222;
  float float_tq;
  uint16_t total_toque_int;
  uint16_t total_toque_point;
  uint16_t total_angle, total_Speed, total_joint;
  int32_t total_angle222;
  uint8_t mac1;
  uint8_t mac2, fw1, fw2, fw3;
  int8_t temp;
  uint8_t colortype_item, loopvar_item;
  uint8_t colortype_choice, loopvar_choice;

  int i;

  if (U1RX_Process_1T == 0)
    return;
  U1RX_Process_1T = 0;
  TEXT_Index = 1;
  switch (Main_Page)
  {
  case 0:
    break;

    /*
    專門處理「主頁為 10 或 11」時，根據不同狀態變數來更新標題、按鈕文字，以及語言選擇的外觀顯示。這是典型的差異更新邏輯（只改有變化的地方，減少重繪負擔）
     */
  case 10:
  case 11:
    // TEXT_Index = 1;
    /*
    如果標題有變，或語言切換，再檢查如果Title == 0，就把標題設為空字串（清空標題）。

    這通常是為了切換語言或頁面時，避免顯示錯誤文字。
     */
    if ((Pg_Language_0.Title != Temp_Pg_Language_0.Title) ||
        (language_version != Temp_language_version))
    {
      if (Pg_Language_0.Title == 0)
      {
        FRAMEWIN_SetText(hItems.hWin, " ");
      }
    }
    // 只要三個按鈕的任一標籤有變，或語言版本有變，就依序更新三個按鈕的文字。
    if ((Pg_Language_0.Button1 != Temp_Pg_Language_0.Button1) ||
        (Pg_Language_0.Button2 != Temp_Pg_Language_0.Button2) ||
        (Pg_Language_0.Button3 != Temp_Pg_Language_0.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_Language_0.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_Language_0.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_Language_0.Button3);
    }

    /*
    檢查三個語言選項（英文、繁中、簡中）是否有變。
    先把三個選項底色全設為白色，然後根據當前語言，執行colorchange和textchange，之後強制刷新視窗內容（WM_InvalidateWindow和WM_Update）。
     */
    if ((Pg_Language_0.EN_Item_P != Temp_Pg_Language_0.EN_Item_P) ||
        (Pg_Language_0.TC_Item_P != Temp_Pg_Language_0.TC_Item_P) ||
        (Pg_Language_0.SC_Item_P != Temp_Pg_Language_0.SC_Item_P))
    {
      for (for_i = 0; for_i < 3; for_i++)
      {
        TEXT_SetBkColor(hItems.TEXT[for_i + 1], GUI_WHITE);
      }

      colorchange((Pg_Language_0.EN_Item_P), 0);
      textchange(Pg_Language_0.EN_Item_P, 0);
      WM_InvalidateWindow(hItems.TEXT[1]);
      WM_Update(hItems.TEXT[1]);
      colorchange((Pg_Language_0.TC_Item_P), 1);
      textchange(Pg_Language_0.TC_Item_P, 1);
      WM_InvalidateWindow(hItems.TEXT[2]);
      WM_Update(hItems.TEXT[2]);
      colorchange((Pg_Language_0.SC_Item_P), 2);
      textchange(Pg_Language_0.SC_Item_P, 2);
      WM_InvalidateWindow(hItems.TEXT[3]);
      WM_Update(hItems.TEXT[3]);
    }
    // 把目前顯示狀態備份到Temp_*，供下次檢查差異用。
    memcpy(&Temp_Pg_Language_0, &Pg_Language_0, sizeof(Pg_Language_0));
    Temp_language_version = language_version;
    break;
  // 做「工具模式頁」的動態顯示
  case 20:
  case 21:
    // 設定目前的文字索引（通常與UI顯示有關）。清空顯示用的變數或項目，確保每次進入頁面時狀態乾淨。
    TEXT_Index = 1;
    ItemValue_Clear();
    // 只要按鈕標題有變，或語言切換，就會重新設定三個按鈕的文字。
    if ((Pg_Tool_Mode_0.Button1 != Temp_Pg_Tool_Mode_0.Button1) ||
        (Pg_Tool_Mode_0.Button2 != Temp_Pg_Tool_Mode_0.Button2) ||
        (Pg_Tool_Mode_0.Button3 != Temp_Pg_Tool_Mode_0.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_Tool_Mode_0.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_Tool_Mode_0.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_Tool_Mode_0.Button3);
    }
    /////////////////////////////////////////////////////////Pg_Home.Title
    // 如果標題內容或語言有異動且為0（應該表示不顯示），就把主視窗標題清空。
    if ((language_version != Temp_language_version) ||
        (Pg_Tool_Mode_0.Title != Temp_Pg_Tool_Mode_0.Title))
    {
      if (Pg_Tool_Mode_0.Title == 0)
      {
        FRAMEWIN_SetText(hItems.hWin, " ");
      }
    }
    // 只要這五個項目的其中一個有異動，或語言切換，就會依序把五個選項的底色、內容重新設置與刷新。
    if ((Pg_Tool_Mode_0.StandAlone != Temp_Pg_Tool_Mode_0.StandAlone) ||
        (Pg_Tool_Mode_0.Controlled != Temp_Pg_Tool_Mode_0.Controlled) ||
        (Pg_Tool_Mode_0.Default != Temp_Pg_Tool_Mode_0.Default) ||
        (Pg_Tool_Mode_0.Tool != Temp_Pg_Tool_Mode_0.Tool) ||
        (Pg_Tool_Mode_0.WIFI != Temp_Pg_Tool_Mode_0.WIFI) ||
        (language_version != Temp_language_version))
    {
      for (for_i = 0; for_i < 5; for_i++)
      {
        TEXT_SetBkColor(hItems.TEXT[for_i + 1], GUI_WHITE);
      }
      colorchange(Pg_Tool_Mode_0.StandAlone, 0);
      textchange(Pg_Tool_Mode_0.StandAlone, 0);
      WM_InvalidateWindow(hItems.TEXT[1]);
      WM_Update(hItems.TEXT[1]);
      colorchange(Pg_Tool_Mode_0.Controlled, 1);
      textchange(Pg_Tool_Mode_0.Controlled, 1);
      WM_InvalidateWindow(hItems.TEXT[2]);
      WM_Update(hItems.TEXT[2]);
      colorchange(Pg_Tool_Mode_0.Default, 2);
      textchange(Pg_Tool_Mode_0.Default, 2);
      WM_InvalidateWindow(hItems.TEXT[3]);
      WM_Update(hItems.TEXT[3]);
      colorchange(Pg_Tool_Mode_0.Tool, 3);
      textchange(Pg_Tool_Mode_0.Tool, 3);
      WM_InvalidateWindow(hItems.TEXT[4]);
      WM_Update(hItems.TEXT[4]);
      colorchange(Pg_Tool_Mode_0.WIFI, 4);
      textchange(Pg_Tool_Mode_0.WIFI, 4);
      WM_InvalidateWindow(hItems.TEXT[5]);
      WM_Update(hItems.TEXT[5]);
    }
    // 把當前狀態複製到暫存，方便下次進來時做差異比對。
    memcpy(&Temp_Pg_Tool_Mode_0, &Pg_Tool_Mode_0, sizeof(Pg_Tool_Mode_0));
    Temp_language_version = language_version;
    break;
    ;
  default:
    break;
  }

  switch (Main_Page)
  {
  case 0:
    // printf("1 stage");
    TEXT_Index = 1;
    // 當三個按鈕內容有任一個改變，或語言有切換，就會分別刷新三個按鈕的顯示文字。
    if ((Pg_Home.Button1 != Temp_Pg_Home.Button1) ||
        (Pg_Home.Button2 != Temp_Pg_Home.Button2) ||
        (Pg_Home.Button3 != Temp_Pg_Home.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_Home.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_Home.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_Home.Button3);
    }
    // 這段會根據 APPLink 狀態的bit，去顯示「A0/S0」或「A1/S1」，即「A+S」哪個被啟用。設定內容到 EDIT[0] 控件。
#ifdef APPLINK_ShowA1S1 // 2025/06/12
    if (Pg_Home.APPLink_color != Temp_Pg_Home.APPLink_color)
    {
      // 2025/06/11 ???
      ItemValue_Clear();
      memcpy(ItemValue, "A0 + S0", 7);
      if ((Pg_Home.APPLink_color & 0x08) == 0x08)
        ItemValue[1] = '1';
      if ((Pg_Home.APPLink_color & 0x04) == 0x04)
        ItemValue[6] = '1';
      EDIT_SetText(hItems.EDIT[0], ItemValue);
      Temp_Pg_Home.APPLink_color = Pg_Home.APPLink_color;
    }
#else
    /*
    這段依 APPLink_color 內容，設置底色和字色。

    0x00 → 白底黑字

    0x01 → 紅底白字

    0x02 → 綠底白字
     */
    if (Pg_Home.APPLink_color != Temp_Pg_Home.APPLink_color)
    {
      ItemValue_Clear();
      if ((Pg_Home.APPLink_color & 0x03) == 0x00)
      {
        EDIT_SetBkColor(hItems.EDIT[0], EDIT_CI_ENABLED, GUI_WHITE);
        EDIT_SetTextColor(hItems.EDIT[0], EDIT_CI_ENABLED, GUI_BLACK);
      }
      else if ((Pg_Home.APPLink_color & 0x01) == 0x01)
      {
        EDIT_SetBkColor(hItems.EDIT[0], EDIT_CI_ENABLED, GUI_RED);
        EDIT_SetTextColor(hItems.EDIT[0], EDIT_CI_ENABLED, GUI_WHITE);
      }
      else if ((Pg_Home.APPLink_color & 0x02) == 0x02)
      {
        EDIT_SetBkColor(hItems.EDIT[0], EDIT_CI_ENABLED, GUI_DARKGREEN);
        EDIT_SetTextColor(hItems.EDIT[0], EDIT_CI_ENABLED, GUI_WHITE);
      }
      else
      {
      }
    }
#endif
/*
這是檢查特定內容（如馬達溫度、MOS溫度等），如果有異動才會把內容複製並更新到UI。避免不必要的畫面刷新。
 */
#ifdef LCD_Pg00_Edit0_ShowADC // 2025/06/12 LCD???1??????ADC
    if ((Pg_Home.TitleChar[18] != Temp_Pg_Home.TitleChar[18]) ||
        (Pg_Home.TitleChar[19] != Temp_Pg_Home.TitleChar[19]) ||
        (Pg_Home.TitleChar[29] != Temp_Pg_Home.TitleChar[29]) ||
        (Pg_Home.TitleChar[30] != Temp_Pg_Home.TitleChar[30]))
    {
      // 012345678901234567890123456789012345
      // 					memcpy(&Page0.TitleChar[0],
      // "__________  Mot=     , MOS=         ", 35); 					Number16b_to_BCD4b((char
      // *)&Page0.TitleChar[16], AD.u16MotorTemp, 4); 					Number16b_to_BCD4b((char
      // *)&Page0.TitleChar[27], AD.u16MosTemp, 4); 					EDIT_SetText(hItems.EDIT[1],
      // ItemValue);
      ItemValue_Clear();
      memcpy(ItemValue, &Pg_Home.TitleChar[0], 35);
      // 					FRAMEWIN_SetText(hItems.hWin,
      // ItemValue);	//????????
      EDIT_SetText(hItems.EDIT[2], ItemValue); //??BAR??
                                               // 					GUI_Delay(20);
      Temp_Pg_Home.TitleChar[18] = Pg_Home.TitleChar[18];
      Temp_Pg_Home.TitleChar[19] = Pg_Home.TitleChar[19];
      Temp_Pg_Home.TitleChar[29] = Pg_Home.TitleChar[29];
      Temp_Pg_Home.TitleChar[30] = Pg_Home.TitleChar[30];
    }
#endif
    /////////////////////////////////////////////////////////Pg_Home.Title
    /*
    如果首頁標題有變，且為0（代表不顯示或清空），就把視窗標題設為空字串。完成後馬上同步備份狀態。
     */
    if ((memcmp(Pg_Home.TitleASCII, Temp_Pg_Home.TitleASCII, 20) != 0))
    {
      if (Pg_Home.Title == 0)
      {
        FRAMEWIN_SetText(hItems.hWin, " ");
      }
      ItemValue_Clear();
      memcpy(ItemValue, Pg_Home.TitleASCII, 20);
      FRAMEWIN_SetText(hItems.hWin, ItemValue);
      // WM_InvalidateWindow(hItems.hWin);
      // WM_Update(hItems.hWin);

      Temp_Pg_Home.Title = Pg_Home.Title;
    }
    /*
    這段會依據 Mute 狀態的 bit 來決定顯示文字，依序填入三個 UI 控件。

    TT/DT/Mute 字樣根據位元判斷，也會根據語言改變（DT/TT）。

    沒變化時直接跳過三個 index。
     */

    if (Pg_Home.Mute != Temp_Pg_Home.Mute)
    {
      const char *textTT = "TT";
      const char *textDT = "DT";
      const char *textMute = "Mute";
      const char *textBlank = "    ";

      for (int i = 0; i < 3; ++i)
      {
        const char *valueToSet = textBlank;
        switch (i)
        {
        case 0: // Bit 1 << 1 = 0x2 (TT)
          if (Pg_Home.Mute & 0x2)
            valueToSet = textTT;
          break;

        case 1: // Bit 1 << 2 = 0x4 (DT)
          if (Pg_Home.Mute & 0x4)
            valueToSet = (language_version == 0) ? textDT : textTT;
          break;

        case 2: // Bit 1 << 0 = 0x1 (Mute)
          if (Pg_Home.Mute & 0x1)
            valueToSet = textMute;
          break;
        }

        ItemValue_Clear();
        memcpy(ItemValue, valueToSet, strlen(valueToSet) + 1);
        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;
      }
    }
    else
    {
      TEXT_Index += 3;
    }
    /////////////////////////////////////////////////////////Pg_Home.Battery
    /*
    只要電池電量變化就會依數值設定不同的顏色組合。

    大於20一般色，20以下警告色。

    設定皮膚屬性並刷新。
     */
    if (PROGBAR_Color_1T != Pg_Home.Battery)
    {
      PROGBAR_Color_1T = Pg_Home.Battery;
      if (Pg_Home.Battery > 20)
      {
        PROGBAR_GetSkinFlexProps(&PROGBAR_MySKIN_ACT0, 0);
        PROGBAR_MySKIN_ACT0.aColorUpperL[0] = GUI_MAKE_COLOR(0x00F0FFF0);
        PROGBAR_MySKIN_ACT0.aColorUpperL[1] =
            GUI_MAKE_COLOR(0x00B0FFB0); //??????
        PROGBAR_MySKIN_ACT0.aColorLowerL[0] = GUI_MAKE_COLOR(0x0050FF50);
        PROGBAR_MySKIN_ACT0.aColorLowerL[1] = GUI_MAKE_COLOR(0x0020FF20);

        PROGBAR_MySKIN_ACT0.aColorUpperR[0] = GUI_LIGHTGRAY;
        PROGBAR_MySKIN_ACT0.aColorUpperR[1] = GUI_LIGHTGRAY;
        PROGBAR_MySKIN_ACT0.aColorLowerR[0] = GUI_LIGHTGRAY;
        PROGBAR_MySKIN_ACT0.aColorLowerR[1] = GUI_LIGHTGRAY;
        PROGBAR_SetSkinFlexProps(&PROGBAR_MySKIN_ACT0, 0);
        PROGBAR_SetValue(hItems.PROGBAR[0], Pg_Home.Battery);
        WM_InvalidateWindow(hItems.PROGBAR[0]);
      }
      else
      {
        PROGBAR_GetSkinFlexProps(&PROGBAR_MySKIN_ACT0, 0);
        PROGBAR_MySKIN_ACT0.aColorUpperL[0] =
            GUI_MAKE_COLOR(0x00F0F0FF); //?????<30%
        PROGBAR_MySKIN_ACT0.aColorUpperL[1] = GUI_MAKE_COLOR(0x00B0B0FF);
        PROGBAR_MySKIN_ACT0.aColorLowerL[0] = GUI_MAKE_COLOR(0x005050FF);
        PROGBAR_MySKIN_ACT0.aColorLowerL[1] = GUI_MAKE_COLOR(0x002020FF);
        PROGBAR_MySKIN_ACT0.aColorUpperR[0] = GUI_LIGHTGRAY;
        PROGBAR_MySKIN_ACT0.aColorUpperR[1] = GUI_LIGHTGRAY;
        PROGBAR_MySKIN_ACT0.aColorLowerR[0] = GUI_LIGHTGRAY;
        PROGBAR_MySKIN_ACT0.aColorLowerR[1] = GUI_LIGHTGRAY;
        PROGBAR_SetSkinFlexProps(&PROGBAR_MySKIN_ACT0, 0);
        PROGBAR_SetValue(hItems.PROGBAR[0], Pg_Home.Battery);
        WM_InvalidateWindow(hItems.PROGBAR[0]); // ???? ????????????????
      }
    }
    /*
    如果工作ID有變，則轉碼後顯示。沒變化就直接略過這個index。
     */
    /////////////////////////////////////////////////////////Pg_Home.Job_ID
    if (Pg_Home.Job_ID != Temp_Pg_Home.Job_ID)
    {
      ItemValue_Clear();
      Number16b_to_BCD3b(&ItemValue[0], Pg_Home.Job_ID, 1);
      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    ///////////////////////////////////////////////////////////////Seq_Current/Seq_Sum
    /*
    首頁上「序列數/步驟數/計數器/單位」等多個重要顯示項目的動態更新。每個項目都只有在資料有變動時才更新UI（顯示）
     */
    // 這段是判斷「目前序列」或「總序列」有變動才顯示「0 / 0」這種格式。
    if ((Pg_Home.Seq_Current != Temp_Pg_Home.Seq_Current) ||
        (Pg_Home.Seq_Sum != Temp_Pg_Home.Seq_Sum))
    {
      ItemValue_Clear();
      Number8b_to_BCD2b(&ItemValue[0], Pg_Home.Seq_Current, 2);
      ItemValue[2] = ' ';
      ItemValue[3] = '/';
      ItemValue[4] = ' ';
      Number8b_to_BCD2b(&ItemValue[5], Pg_Home.Seq_Sum, 2);
      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
    這段只顯示「個位數」的步驟，%10 只取個位。

    顯示格式「n / m」，適合步驟數少於10的流程。
    */
    ///////////////////////////////////////////////////////////////Step_Current//Step_Sum
    if ((Pg_Home.Step_Current != Temp_Pg_Home.Step_Current) ||
        (Pg_Home.Step_Sum != Temp_Pg_Home.Step_Sum))
    {
      ItemValue_Clear();
      ItemValue[0] = (Pg_Home.Step_Current % 10) + 0x30;
      ItemValue[1] = ' ';
      ItemValue[2] = '/';
      ItemValue[3] = ' ';
      ItemValue[4] = (Pg_Home.Step_Sum % 10) + 0x30;
      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    ////////////////////////////////////////////////////Counter_Current//Counter_Sum
    /*
    是「00 / 00」的格式，適合較大數字，會補0到兩位數。
     */
    if ((Pg_Home.Counter_Current != Temp_Pg_Home.Counter_Current) ||
        (Pg_Home.Counter_Sum != Temp_Pg_Home.Counter_Sum))
    {
      ItemValue_Clear();
      Number8b_to_BCD2b(&ItemValue[0], Pg_Home.Counter_Current, 2);
      ItemValue[2] = ' ';
      ItemValue[3] = '/';
      ItemValue[4] = ' '; //??? 00?/?00
      Number8b_to_BCD2b(&ItemValue[5], Pg_Home.Counter_Sum, 2);
      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    //////////////////////////////////////////////////////	unit
    /*
    單位顯示根據 Unit 值（0~4）和語言做對應顯示。

    三種語言分開管理字串，適合多語言需求。
    */
    if ((Pg_Home.Unit != Temp_Pg_Home.Unit) ||
        (language_version != Temp_language_version))
    {
      ItemValue_Clear();
      if (Pg_Home.Unit == 0)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "Kgf.m", 6);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          memcpy(ItemValue, Kgf_m_Big5222, strlen(Kgf_m_Big5222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          memcpy(ItemValue, Kgf_m_GB222, strlen(Kgf_m_GB222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
      }
      else if (Pg_Home.Unit == 1)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "N.m", 4);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          memcpy(ItemValue, Nm_Big5222, strlen(Nm_Big5222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          memcpy(ItemValue, Nm_GB222, strlen(Nm_GB222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
      }
      else if (Pg_Home.Unit == 2)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "Kgf.cm", 7);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          memcpy(ItemValue, Kgf_cm_Big5222, strlen(Kgf_cm_Big5222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          memcpy(ItemValue, Kgf_cm_GB222, strlen(Kgf_cm_GB222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
      }
      else if (Pg_Home.Unit == 3)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "In.lbs", 6);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          memcpy(ItemValue, In_lbs_Big5222, strlen(In_lbs_Big5222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          memcpy(ItemValue, In_lbs_GB222, strlen(In_lbs_GB222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
      }
      else if (Pg_Home.Unit == 4)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "cN.m", 5);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          memcpy(ItemValue, cN_m_Big5222, strlen(cN_m_Big5222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          memcpy(ItemValue, cN_m_GB222, strlen(cN_m_GB222) + 1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
      }
      else
      {
      }
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
    這一段是首頁狀態顯示的「動態資訊區」，包含扭力、角度、轉速、狀態碼等顯示更新。你依然採用「只有變動才更新」的設計，
     */
    // 扭力顯示依照不同單位（Kgf.m、Nm、Kgf.cm、In.lbs、cN.m）呼叫對應格式的顯示函式，把數字格式化後寫到UI。
    // 只要數值或單位有異動才重繪，避免不必要的UI刷新。
    //////////////////////////////////////////////////////	Tourqe
    if ((Pg_Home.u32Tourqe != Temp_Pg_Home.u32Tourqe) || (Pg_Home.u32TarTrq != Temp_Pg_Home.u32TarTrq) ||
        (Pg_Home.Unit != Temp_Pg_Home.Unit))
    {
      ItemValue_Clear();
      total_toque_ALL_32bit222 = Pg_Home.u32Tourqe;

      if (Pg_Home.Unit == 0)
      {
        Kgf_m_unit_Display_x_xxxx(total_toque_ALL_32bit222);
      }
      else if (Pg_Home.Unit == 1)
      {
        Nm_unit_Display_x_xxx(total_toque_ALL_32bit222);
      }
      else if (Pg_Home.Unit == 2)
      {
        Kgf_cm_unit_Display_xx_xx(total_toque_ALL_32bit222);
      }
      else if (Pg_Home.Unit == 3)
      {
        Lbs_In_unit_Display_x_xx(total_toque_ALL_32bit222);
      }
      else if (Pg_Home.Unit == 4)
      {
        cN_m_unit_Display_xxx_x(total_toque_ALL_32bit222);
      }
      else
      {
      }
      ItemValue2_Clear();
      memcpy(ItemValue2, ItemValue, 20);
      ItemValue_Clear();
      total_toque_ALL_32bit222 = Pg_Home.u32TarTrq;

      if (Pg_Home.Unit == 0)
      {
        Kgf_m_unit_Display_x_xxxx(total_toque_ALL_32bit222);
      }
      else if (Pg_Home.Unit == 1)
      {
        Nm_unit_Display_x_xxx(total_toque_ALL_32bit222);
      }
      else if (Pg_Home.Unit == 2)
      {
        Kgf_cm_unit_Display_xx_xx(total_toque_ALL_32bit222);
      }
      else if (Pg_Home.Unit == 3)
      {
        Lbs_In_unit_Display_x_xx(total_toque_ALL_32bit222);
      }
      else if (Pg_Home.Unit == 4)
      {
        cN_m_unit_Display_xxx_x(total_toque_ALL_32bit222);
      }
      else
      {
      }

      sprintf(buffer, "%s / %s", ItemValue2, ItemValue);
      TEXT_SetText(hItems.TEXT[TEXT_Index], buffer);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]); //
      WM_Update(hItems.TEXT[TEXT_Index]);           //
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 處理角度時考慮到負數，顯示前自動補負號並左對齊。
    // 角度為0時直接顯示「0」，避免出現一堆0或奇怪的格式。只在數值有變時才刷新。
    //////////////////////////////////////////////////////	angle
    if (Pg_Home.i32Angle != Temp_Pg_Home.i32Angle)
    {
      ItemValue_Clear();
      total_angle222 = Pg_Home.i32Angle;
      if (total_angle222 < 0)
      {
        total_angle222 = -total_angle222;
        ItemValue[0] = '-';
        Number32b_to_BCD5b(&ItemValue[1], total_angle222, 1);
        negative_ItemValue_Left_Alignment();
      }
      else
      {
        Number32b_to_BCD5b(&ItemValue[0], total_angle222, 1);
        ItemValue_Left_Alignment();
      }
      if (Pg_Home.i32Angle == 0)
      {
        ItemValue_Clear();
        ItemValue[0] = '0';
      }
      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 類似角度，轉速為0直接顯示「0」。其他數值則格式化轉成固定寬度，左對齊，顯示美觀。只在資料變動時才重繪。
    //////////////////////////////////////////////////////	Speed
    if (Pg_Home.u16Speed != Temp_Pg_Home.u16Speed)
    {
      ItemValue_Clear();
      total_Speed = Pg_Home.u16Speed;
      Number16b_to_BCD5b(&ItemValue[0], total_Speed,
                         1);
      ItemValue_Left_Alignment();
      if (Pg_Home.u16Speed == 0)
      {
        ItemValue_Clear();
        ItemValue[0] = '0';
      }
      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
    狀態碼（Statuecode）最多20個字元，有改變時就更新顯示內容。

    根據APPLink_color高四位決定顏色（黑、紅、綠、藍、黃）。

    這讓現場維護/使用者很直觀看到不同連線或狀態時的顏色提示。
     */
    //////////////////////////////////////////////////////
    if ((Pg_Home.u16ErrCodeEng != Temp_Pg_Home.u16ErrCodeEng) || (Pg_Home.u16ErrCodeNum != Temp_Pg_Home.u16ErrCodeNum) || (language_version != Temp_language_version) ||
        (Pg_Home.APPLink_color != Temp_Pg_Home.APPLink_color))
    {
      ItemValue_Clear();
      if (Pg_Home.u16ErrCodeEng == 0 && Pg_Home.u16ErrCodeNum == 0)
      {
        memcpy(ItemValue, Pg_Home.Statuecode, 20);
        GUI_COLOR color;
        switch (Pg_Home.APPLink_color & 0xF0)
        {
        case 0x00:
          color = GUI_BLACK;
          break;
        case 0x10:
          color = GUI_RED;
          break;
        case 0x20:
          color = GUI_DARKGREEN;
          break;
        case 0x40:
          color = GUI_BLUE;
          break;
        case 0x80:
          color = GUI_YELLOW;
          break;
        default:
          color = GUI_BLACK;
          break;
        }
        EDIT_SetTextColor(hItems.EDIT[1], EDIT_CI_ENABLED, color);
        EDIT_SetText(hItems.EDIT[1], ItemValue);
      }
      else
      {
        GUI_COLOR color;
        switch (Pg_Home.APPLink_color & 0xF0)
        {
        case 0x00:
          color = GUI_BLACK;
          break;
        case 0x10:
          color = GUI_RED;
          break;
        case 0x20:
          color = GUI_DARKGREEN;
          break;
        case 0x40:
          color = GUI_BLUE;
          break;
        case 0x80:
          color = GUI_YELLOW;
          break;
        default:
          color = GUI_BLACK;
          break;
        }
        EDIT_SetTextColor(hItems.EDIT[1], EDIT_CI_ENABLED, color);
				if (language_version == 0)
        {
						EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
						
						 memcpy(ItemValue, Pg_Home.Statuecode, 20);
						EDIT_SetText(hItems.EDIT[1], ItemValue);
					}
       else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 2)
        {
         
           if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E02_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E02_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 3)
        {
        if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E03_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E03_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 4)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E04_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E04_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 5)
        {
         if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E05_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E05_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 6)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E06_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E06_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 8)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E08_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E08_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 9)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E09_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E09_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 10)
        {
				
				
						if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E10_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E10_GB);
          }
					else
					
					{}
					
         
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 11)
        {
         if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E11_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E11_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 12)
        {
         if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E12_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E12_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 14)
        {
         if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E14_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E14_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 16)
        {
           if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E16_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E16_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 18)
        {
           if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E18_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E18_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 23)
        {
						if(Pg_Home.Statuecode[4]=='N'&&Pg_Home.Statuecode[5]=='S')
					{
						 if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E23_NS_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E23_NS_GB);
          }
					else
					
					{}
					}else
					{
						 if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E23_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E23_GB);
          }
					else
					
					{}
					}
          
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 24)
        {
					if(Pg_Home.Statuecode[4]=='N'&&Pg_Home.Statuecode[5]=='S')
					{
						 if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E24_NS_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E24_NS_GB);
          }
					else
					
					{}
					}else
					{
						 if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E24_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E24_GB);
          }
					else
					
					{}
					}
          
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 25)
        {
					if(Pg_Home.Statuecode[4]=='N'&&Pg_Home.Statuecode[5]=='S')
					{
						if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E25_NS_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E25_NS_GB);
          }
					else
					
					{}
					}
					else
					{
						if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E25_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E25_GB);
          }
					else
					
					{}
					}
         
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 26)
        {
					if(Pg_Home.Statuecode[4]=='N'&&Pg_Home.Statuecode[5]=='S')
					{
						if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E26_NS_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E26_NS_GB);
          }
					else
					
					{}

					}
					else
					{
if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E26_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E26_GB);
          }
					else
					
					{}

					}
                  }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 27)
        {
					if(Pg_Home.Statuecode[4]=='N'&&Pg_Home.Statuecode[5]=='S')
					{
						if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E27_NS_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E27_NS_GB);
          }
					else
					
					{}
					}
					else
					{
						if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E27_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E27_GB);
          }
					else
					
					{}
					}
          
        }
        else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 32)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C32_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C32_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 33)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C33_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C33_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 35)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C35_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C35_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 36)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E36_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E36_GB);
          }
					else
					
					{}
        }
        else if (Pg_Home.u16ErrCodeEng == 'E' && Pg_Home.u16ErrCodeNum == 37)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E37_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], E37_GB);
          }
					else
					
					{}
        }

        else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 130)
        {
         if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C130_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C130_GB);
          }
					else
					
					{}
        }

         else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 129)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C129_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C129_GB);
          }
					else
					
					{}
        }

         else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 109)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C109_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C109_GB);
          }
					else
					
					{}
        }

         else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 124)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C124_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C124_GB);
          }
					else
					
					{}
        }

            else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 125)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C125_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C125_GB);
          }
					else
					
					{}
        }

            else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 126)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C126_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C126_GB);
          }
					else
					
					{}
        }

          else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 128)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C128_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C128_GB);
          }
					else
					
					{}
        }

              else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 132)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C132_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C132_GB);
          }
					else
					
					{}
        }

         else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 133)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C133_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C133_GB);
          }
					else
					
					{}
        }
            else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 134)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C134_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C134_GB);
          }
					else
					
					{}
        }

              else if (Pg_Home.u16ErrCodeEng == 'C' && Pg_Home.u16ErrCodeNum == 135)
        {
          if (language_version == 1)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C135_Big5);
          }
          else if (language_version == 2)
          {
            EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
            EDIT_SetText(hItems.EDIT[1], C135_GB);
          }
					else
					
					{}
        }
				else
				{
						EDIT_SetFont(hItems.EDIT[1], &GUI_FontFont_Pg_Home_MicrosoftJhengHei_19B);
						
						 memcpy(ItemValue, Pg_Home.Statuecode, 20);
						EDIT_SetText(hItems.EDIT[1], ItemValue);
				}
				
				

      }
    }
    /*
    最後一定要做狀態結構同步，把目前顯示過的資料存成 Temp，避免下次進來時又重複刷新。

    語言也同步，維持判斷正確。
     */
    memcpy(&Temp_Pg_Home, &Pg_Home, sizeof(Pg_Home));
    Temp_language_version = language_version;
    break;
  /*
  這一段 case 30: / case 31: 的程式，主要是在處理呼叫工單（Call Job）頁面的 UI 動態更新。跟前面的頁面一樣，是典型的「資料異動才更新顯示」寫法
   */
  case 30:
  case 31:
    TEXT_Index = 1;
    // ItemValue_Clear();
    /////////////////////////////////////////////////////////Pg_Home.Title
    // 如果標題有變化且值為0，則把視窗標題清空。這在頁面切換或語言切換時很常見。
    if (Pg_Call_Job_0.Title != Temp_Pg_Call_Job_0.Title)
    {
      if (Pg_Call_Job_0.Title == 0)
      {
        FRAMEWIN_SetText(hItems.hWin, " ");
      }
    }
    // 只要三個按鈕的標籤有異動，或語言版本有變，都會重新設定按鈕的顯示內容。
    if ((Pg_Call_Job_0.Button1 != Temp_Pg_Call_Job_0.Button1) ||
        (Pg_Call_Job_0.Button2 != Temp_Pg_Call_Job_0.Button2) ||
        (Pg_Call_Job_0.Button3 != Temp_Pg_Call_Job_0.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_Call_Job_0.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_Call_Job_0.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_Call_Job_0.Button3);
    }
    /*
    如果有選中的工單或已選擇的工單欄位有異動，就會：

    先將6個TEXT底色全設白色（還原所有選項顏色）。

    針對 Item_Job_ID_P 與 Choice_Job_ID_P 這兩個欄位，

    根據低兩位（& 0x3）決定顏色型態（可能代表狀態色）。

    高四位（>> 4）決定是哪一個選項（-1 是因為選項從1開始？）

    計算 index 後，用 colorchange() 改變顏色，並刷新對應的 TEXT 欄位。
     */
    if ((Pg_Call_Job_0.Item_Job_ID_P != Temp_Pg_Call_Job_0.Item_Job_ID_P) ||
        (Pg_Call_Job_0.Choice_Job_ID_P != Temp_Pg_Call_Job_0.Choice_Job_ID_P))
    {
      for (for_i = 0; for_i < 28; for_i++)
      {
        TEXT_SetBkColor(hItems.TEXT[for_i + 1], GUI_WHITE);
      }
      colortype_item = (Pg_Call_Job_0.Item_Job_ID_P & 0x03);
      loopvar_item = (Pg_Call_Job_0.Item_Job_ID_P >> 2) - 1;
      saveindex = loopvar_item + 1;
      colorchange(colortype_item, loopvar_item);
      WM_InvalidateWindow(hItems.TEXT[saveindex]);
      WM_Update(hItems.TEXT[saveindex]);
      colortype_choice = (Pg_Call_Job_0.Choice_Job_ID_P & 0x03);
      loopvar_choice = (Pg_Call_Job_0.Choice_Job_ID_P >> 2) - 1;
      saveindex = loopvar_choice + 1;
      colorchange(colortype_choice, loopvar_choice);
      WM_InvalidateWindow(hItems.TEXT[saveindex]);
      WM_Update(hItems.TEXT[saveindex]);
    }
    // 將目前狀態備份，確保下次只對比有沒有新變動。
    memcpy(&Temp_Pg_Call_Job_0, &Pg_Call_Job_0, sizeof(Pg_Call_Job_0));
    Temp_language_version = language_version;
    break;
  case 40:
    TEXT_Index = 1;
    // 只要三個按鈕任一內容變化，或語言變化，會立即更新按鈕顯示。
    if ((Pg_JS_0_Job.Button1 != Temp_Pg_JS_0_Job.Button1) ||
        (Pg_JS_0_Job.Button2 != Temp_Pg_JS_0_Job.Button2) ||
        (Pg_JS_0_Job.Button3 != Temp_Pg_JS_0_Job.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_JS_0_Job.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_JS_0_Job.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_JS_0_Job.Button3);
    }
    /////////////////////////////////////////////////////////Pg_Home.Title
    // 標題內容或語言版本有變時才會刷新。支援英文、繁體、簡體，分別用對應變數顯示標題。
    if (Pg_JS_0_Job.Title != Temp_Pg_JS_0_Job.Title ||
        Temp_language_version != language_version)
    {
      ItemValue_Clear();
      if (Pg_JS_0_Job.Title == 0)
      {

        FRAMEWIN_SetText(hItems.hWin, " ");
      }
      else
      {
        if (language_version == 0)
          FRAMEWIN_SetText(hItems.hWin, "Job");
        else if (language_version == 1)
          FRAMEWIN_SetText(hItems.hWin, Job_Big5);
        else if (language_version == 2)
          FRAMEWIN_SetText(hItems.hWin, Job_GB);
      }
    }
    // 3. Job名稱顯示（比對記憶體內容）
    // 比對目前和舊的 Job_Name（應該是 char[12]），有異動才顯示，避免沒意義的重畫。
    if (memcmp(&Pg_JS_0_Job.Job_Name[0], &Temp_Pg_JS_0_Job.Job_Name[0],
               sizeof(Pg_JS_0_Job.Job_Name)) != 0)
    {
      ItemValue_Clear();
      memcpy(ItemValue, &Pg_JS_0_Job.Job_Name[0], 12);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // Job OK/NG 狀態多語言切換
    // 判斷 Job 狀態顯示 ON / OFF（或中文），並根據語言變換字體與內容。
    // 每次設定後記得刷新該欄位。
    if (Pg_JS_0_Job.u8Job_OK_En != Temp_Pg_JS_0_Job.u8Job_OK_En)
    {
      ItemValue_Clear();
      if (Pg_JS_0_Job.u8Job_OK_En == 1)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "ON", 3);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
      else if (Pg_JS_0_Job.u8Job_OK_En == 0)
      {

        if (language_version == 0)
        {
          memcpy(ItemValue, "OFF", 4);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
      else
      {
      }
    }
    else
    {
      TEXT_Index++;
    }
    /*
    這段是針對 Pg_JS_0_Job.u8Job_OK_Stop_En 狀態顯示（通常是某種允許停止或停用功能開關），依照不同語言與開啟/關閉狀態切換字樣及字型。
    最後還有正確的狀態備份。
    只要「允許停止」狀態有變動才會更新UI，這是高效做法。

    根據語言切換不同顯示內容：

    英文顯示 "ON"/"OFF"

    繁體顯示 On_Big5/Off_Big5

    簡體顯示 On_GB/Off_GB

    並針對不同語言切換不同字型，確保顯示正確。
    */
    if (Pg_JS_0_Job.u8Job_OK_Stop_En != Temp_Pg_JS_0_Job.u8Job_OK_Stop_En)
    {
      ItemValue_Clear();
      if (Pg_JS_0_Job.u8Job_OK_Stop_En == 1)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "ON", 3);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
      else if (Pg_JS_0_Job.u8Job_OK_Stop_En == 0)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "OFF", 4);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_0_Job_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
    }
    // 最後將目前狀態做備份，讓下次能正確比對。
    memcpy(&Temp_Pg_JS_0_Job, &Pg_JS_0_Job, sizeof(Pg_JS_0_Job));
    Temp_language_version = language_version;
    break;
  case 41:
    TEXT_Index = 1;
    /////////////////////////////////////////////////////////Pg_Home.Title
    // 按鈕內容或語言有變動就會更新，保證三種語言和資料都能正確顯示。
    if ((Pg_JS_1_JobSEQ.Button1 != Temp_Pg_JS_1_JobSEQ.Button1) ||
        (Pg_JS_1_JobSEQ.Button2 != Temp_Pg_JS_1_JobSEQ.Button2) ||
        (Pg_JS_1_JobSEQ.Button3 != Temp_Pg_JS_1_JobSEQ.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_JS_1_JobSEQ.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_JS_1_JobSEQ.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_JS_1_JobSEQ.Button3);
    }
    ItemValue_Clear();
    // 根據語言切換「Job」「Seq」「Step」這三個字串（也許還有ID等數值），合併成一個大標題顯示在視窗最上方。
    // build_title_string 是你自己寫的組合字串函式，方便三語切換與ID顯示。
    if ((language_version != Temp_language_version) ||
        (Pg_JS_1_JobSEQ.Title_Job_ID != Temp_Pg_JS_1_JobSEQ.Title_Job_ID) ||
        (Pg_JS_1_JobSEQ.Title_Seq_ID != Temp_Pg_JS_1_JobSEQ.Title_Seq_ID))
    {
      if (language_version == 0)
        build_title_string(ItemValue, "Job", "Seq", "Step",
                           Pg_JS_1_JobSEQ.Title_Job_ID,
                           Pg_JS_1_JobSEQ.Title_Seq_ID, 255);
      else if (language_version == 1)
        build_title_string(ItemValue, Job_Big5222, Seq_Big5222, Step_Big5222,
                           Pg_JS_1_JobSEQ.Title_Job_ID,
                           Pg_JS_1_JobSEQ.Title_Seq_ID, 255);
      else if (language_version == 2)
        build_title_string(ItemValue, Job_GB222, Seq_GB222, Step_GB222,
                           Pg_JS_1_JobSEQ.Title_Job_ID,
                           Pg_JS_1_JobSEQ.Title_Seq_ID, 255);

      FRAMEWIN_SetText(hItems.hWin, ItemValue);
    }
    // 如果名稱有異動就會更新，否則就往下一格。這種做法避免多餘刷新
    if (memcmp(&Pg_JS_1_JobSEQ.u8Seq_Name[0],
               &Temp_Pg_JS_1_JobSEQ.u8Seq_Name[0],
               sizeof(Pg_JS_1_JobSEQ.u8Seq_Name)) != 0)
    {
      ItemValue_Clear();
      for (for_i = 0; for_i < 12; for_i++)
        ItemValue[for_i] = Pg_JS_1_JobSEQ.u8Seq_Name[for_i];

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);

      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
    同理，只要有異動才會更新畫面內容。

    你把長度明確用for處理（避免結尾亂碼或漏字），是好習慣。
     */
    if (memcmp(&Pg_JS_1_JobSEQ.u8Tool_Name[0],
               &Temp_Pg_JS_1_JobSEQ.u8Tool_Name[0],
               sizeof(Pg_JS_1_JobSEQ.u8Tool_Name)) != 0)
    {
      ItemValue_Clear();
      for (for_i = 0; for_i <= 19; for_i++)
        ItemValue[for_i] = Pg_JS_1_JobSEQ.u8Tool_Name[for_i];

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
    緊固次數顯示（通常是步驟/工序執行數），只有異動才顯示。你用轉換與左對齊，顯示更美觀一致。
    */
    if (Pg_JS_1_JobSEQ.u8Tighten_Cnt != Temp_Pg_JS_1_JobSEQ.u8Tighten_Cnt)
    {
      ItemValue_Clear();
      Number8b_to_BCD2b(&ItemValue[0], Pg_JS_1_JobSEQ.u8Tighten_Cnt, 1);
      ItemValue_Left_Alignment();

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
     1. NG停止使能（u8NG_Stop_En）狀態有異動才會刷新內容。
    ON/OFF 依語言切換字串與字型（英文、繁體、簡體）。
     */
    if (Pg_JS_1_JobSEQ.u8NG_Stop_En != Temp_Pg_JS_1_JobSEQ.u8NG_Stop_En)
    {
      ItemValue_Clear();
      if (Pg_JS_1_JobSEQ.u8NG_Stop_En == 1)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "ON", 3);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
      else if (Pg_JS_1_JobSEQ.u8NG_Stop_En == 0)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "OFF", 4);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
    }
    else
    {
      TEXT_Index++;
    }
    /*
    SEQ OK使能（u8SEQ_OK_En）
    也是一樣只在狀態有變化時才會更新UI。

    依語言切換顯示 ON/OFF 或是 On_Big5 / Off_Big5 / On_GB / Off_GB。
     */
    if (Pg_JS_1_JobSEQ.u8SEQ_OK_En != Temp_Pg_JS_1_JobSEQ.u8SEQ_OK_En)
    {
      ItemValue_Clear();
      if (Pg_JS_1_JobSEQ.u8SEQ_OK_En == 1)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "ON", 3);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
      else if (Pg_JS_1_JobSEQ.u8SEQ_OK_En == 0)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "OFF", 4);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
      else
      {
      }
    }
    else
    {
      TEXT_Index++;
    }
    /*
    方式完全一樣。

    三種語言三種顯示。

    都有字型切換，確保字體顯示正確。
    */
    if (Pg_JS_1_JobSEQ.u8SEQ_OK_Stop_En !=
        Temp_Pg_JS_1_JobSEQ.u8SEQ_OK_Stop_En)
    {
      ItemValue_Clear();
      if (Pg_JS_1_JobSEQ.u8SEQ_OK_Stop_En == 1)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "ON", 3);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], On_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
      else if (Pg_JS_1_JobSEQ.u8SEQ_OK_Stop_En == 0)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "OFF", 4);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_1_JobSEQ_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
    }
    else
    {
      TEXT_Index++;
    }
    /*
    每次完成後同步狀態資料，避免UI重複刷新，這是必要步驟。
     */
    memcpy(&Temp_Pg_JS_1_JobSEQ, &Pg_JS_1_JobSEQ, sizeof(Pg_JS_1_JobSEQ));
    Temp_language_version = language_version;
    break;

  case 42:
    TEXT_Index = 1;
    // 只要有任一按鈕或語言變更，就批次刷新三個按鈕。
    if ((Pg_JS_2_Step2_1.Button1 != Temp_Pg_JS_2_Step2_1.Button1) ||
        (Pg_JS_2_Step2_1.Button2 != Temp_Pg_JS_2_Step2_1.Button2) ||
        (Pg_JS_2_Step2_1.Button3 != Temp_Pg_JS_2_Step2_1.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_JS_2_Step2_1.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_JS_2_Step2_1.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_JS_2_Step2_1.Button3);
    }

    /////////////////////////////////////////////////////////Pg_JS_2_Step2_1.Title
    /* 根據語言組合標題內容，動態顯示 Job/Seq/Step 的名稱和編號。build_title_string 讓多語言標題處理更方便。
     */
    if ((language_version != Temp_language_version) ||

        (Pg_JS_2_Step2_1.Title_Job_ID != Temp_Pg_JS_2_Step2_1.Title_Job_ID) ||
        (Pg_JS_2_Step2_1.Title_Seq_ID != Temp_Pg_JS_2_Step2_1.Title_Seq_ID) ||
        (Pg_JS_2_Step2_1.Title_Step_ID != Temp_Pg_JS_2_Step2_1.Title_Step_ID))
    {
      ItemValue_Clear();

      if (language_version == 0)
        build_title_string(
            ItemValue, "Job", "Seq", "Step", Pg_JS_2_Step2_1.Title_Job_ID,
            Pg_JS_2_Step2_1.Title_Seq_ID, Pg_JS_2_Step2_1.Title_Step_ID);
      else if (language_version == 1)
        build_title_string(ItemValue, Job_Big5222, Seq_Big5222, Step_Big5222,
                           Pg_JS_2_Step2_1.Title_Job_ID,
                           Pg_JS_2_Step2_1.Title_Seq_ID,
                           Pg_JS_2_Step2_1.Title_Step_ID);
      else if (language_version == 2)
        build_title_string(ItemValue, Job_GB222, Seq_GB222, Step_GB222,
                           Pg_JS_2_Step2_1.Title_Job_ID,
                           Pg_JS_2_Step2_1.Title_Seq_ID,
                           Pg_JS_2_Step2_1.Title_Step_ID);
      else
      {
      }
      FRAMEWIN_SetText(hItems.hWin, ItemValue);
    }
    // 只要步驟編號有異動就顯示（B三位數，左對齊），如果是0直接顯示"0"。
    if (Pg_JS_2_Step2_1.Step_ID != Temp_Pg_JS_2_Step2_1.Step_ID)
    {
      ItemValue_Clear();
      Number16b_to_BCD3b(&ItemValue[0], Pg_JS_2_Step2_1.Step_ID, 3);
      ItemValue_Left_Alignment();
      if (Pg_JS_2_Step2_1.Step_ID == 0)
      {
        ItemValue_Clear();
        ItemValue[0] = '0';
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 根據 Target_Title 判斷顯示「目標角度」或「目標扭力」，並根據語言切換字串。
    if ((language_version != Temp_language_version) ||
        (Pg_JS_2_Step2_1.Target_Title != Temp_Pg_JS_2_Step2_1.Target_Title))
    {
      if (Pg_JS_2_Step2_1.Target_Title == 1)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "Target Ang.");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Target_Ang_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Target_Ang_GB);
        }
        else
        {
        }
      }
      else if (Pg_JS_2_Step2_1.Target_Title == 2)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "Target Tor.");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Target_Tor_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Target_Tor_GB);
        }
        else
        {
        }
      }
      else
      {
      }
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 目標值內容顯示（依標題型態與單位判斷）
    /*
    重點：只要任一「目標值、目標標題型態、目標單位」有變化，才更新。

    Target_Title == 1 時顯示角度數值，Target_Title == 2 時顯示扭力數值且會根據單位格式化。

    各單位對應的顯示格式要用到你事先定義好的 function（例：Kgf_m_unit_Display_x_xxxx()），確保小數位及寬度一致。

    畫面上用 TEXT_SetText、WM_InvalidateWindow、WM_Update 做刷新。
     */
    if ((Pg_JS_2_Step2_1.u32Target_Trq != Temp_Pg_JS_2_Step2_1.u32Target_Trq) ||
        (Pg_JS_2_Step2_1.Target_Title != Temp_Pg_JS_2_Step2_1.Target_Title) ||
        (Pg_JS_2_Step2_1.Target_unit != Temp_Pg_JS_2_Step2_1.Target_unit))
    {
      if (Pg_JS_2_Step2_1.Target_Title == 1)
      {
        ItemValue_Clear();
        Number16b_to_BCD5b(&ItemValue[0], Pg_JS_2_Step2_1.u32Target_Trq,
                           1); // Zero_Padding=��0���?=1~5(>5�Y���ɡA�Ӧ�?�j���?0)
        ItemValue_Left_Alignment();
        if (Pg_JS_2_Step2_1.u32Target_Trq == 0)
        {
          ItemValue_Clear();
          ItemValue[0] = '0';
        }

        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      }
      /////////////////////////////////////////////////////////////////
      if (Pg_JS_2_Step2_1.Target_Title == 2)
      {
        //////////////////////////////////////////////////////	Tourqe
        ItemValue_Clear();
        total_toque_ALL_32bit222 = Pg_JS_2_Step2_1.u32Target_Trq;

        if (Pg_JS_2_Step2_1.Target_unit == 0)
        {
          Kgf_m_unit_Display_x_xxxx(total_toque_ALL_32bit222);
        }
        else if (Pg_JS_2_Step2_1.Target_unit == 1)
        {
          Nm_unit_Display_x_xxx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_2_Step2_1.Target_unit == 2)
        {
          Kgf_cm_unit_Display_xx_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_2_Step2_1.Target_unit == 3)
        {
          Lbs_In_unit_Display_x_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_2_Step2_1.Target_unit == 4)
        {

          cN_m_unit_Display_xxx_x(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else
        {
        }

        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      }
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 根據 Target_unit（04, 9）與語言（02）切換顯示內容。
    if ((Pg_JS_2_Step2_1.Target_unit != Temp_Pg_JS_2_Step2_1.Target_unit) ||
        (language_version != Temp_language_version))
    {

      if (Pg_JS_2_Step2_1.Target_unit == 0)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "Kgf.m");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Kgf_m_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Kgf_m_GB);
        }
      }
      else if (Pg_JS_2_Step2_1.Target_unit == 1)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "N.m");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Nm_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Nm_GB);
        }
        else
        {
        }
      }
      else if (Pg_JS_2_Step2_1.Target_unit == 2)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "Kgf.cm");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Kgf_cm_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Kgf_cm_GB);
        }
      }
      else if (Pg_JS_2_Step2_1.Target_unit == 3)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "In.lbs");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], In_lbs_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], In_lbs_GB);
        }
        else
        {
        }
      }
      else if (Pg_JS_2_Step2_1.Target_unit == 4)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "cN.m");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], cN_m_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], cN_m_GB);
        }
        else
        {
        }
      }
      else if (Pg_JS_2_Step2_1.Target_unit == 9)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "Degree");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Degree_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Degree_GB);
        }
        else
        {
        }
      }

      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }

    // 根據「方向」(0=CW, 1=CCW) 與語言動態顯示內容與字型。
    if (Pg_JS_2_Step2_1.u8Step_Dir != Temp_Pg_JS_2_Step2_1.u8Step_Dir)
    {
      ItemValue_Clear();
      if (Pg_JS_2_Step2_1.u8Step_Dir == 0)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "CW", 3);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_2_Step2_1_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], CW_Big5);
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_2_Step2_1_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], CW_GB);
        }
      }
      else if (Pg_JS_2_Step2_1.u8Step_Dir == 1)
      {
        if (language_version == 0)
        {
          memcpy(ItemValue, "CCW", 4);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_2_Step2_1_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], CCW_Big5);
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_2_Step2_1_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], CCW_GB);
        }
      }
      else
      {
      }

      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 轉速RPM顯示
    if (Pg_JS_2_Step2_1.u16Step_RPM != Temp_Pg_JS_2_Step2_1.u16Step_RPM)
    {
      ItemValue_Clear();
      Number16b_to_BCD5b(
          &ItemValue[0], Pg_JS_2_Step2_1.u16Step_RPM,
          1); // Zero_Padding=¸É0¦ì¼Æ=1~5(>5§Y¥þ¸É¡A­Ó¦ì¼Æ±j¨î¸É0)
      ItemValue_Left_Alignment();
      if (Pg_JS_2_Step2_1.u16Step_RPM == 0)
      {
        ItemValue_Clear();
        ItemValue[0] = '0';
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }

    // 補正量（Trq_Offset）與單位顯示  補正量數值（根據單位格式化）
    /*
    不同單位用不同格式化函式，這和你主程式邏輯一致，維護性也很高。
    Target_unit == 9 可能是角度類型（例如 degree）。
     */
    if ((Pg_JS_2_Step2_1.s32Trq_Offset != Temp_Pg_JS_2_Step2_1.s32Trq_Offset) ||
        (Pg_JS_2_Step2_1.Offset_unit != Temp_Pg_JS_2_Step2_1.Offset_unit))
    {
      ItemValue_Clear();
      total_toque_ALL_32bit222 = Pg_JS_2_Step2_1.s32Trq_Offset;

      if (Pg_JS_2_Step2_1.Offset_unit == 0)
      {
        Kgf_m_unit_Display_x_xxxx(total_toque_ALL_32bit222);
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 1)
      {
        Nm_unit_Display_x_xxx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 2)
      {
        Kgf_cm_unit_Display_xx_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 3)
      {
        Lbs_In_unit_Display_x_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 4)
      {

        cN_m_unit_Display_xxx_x(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 9)
      {

        Number32b_to_BCD7b_00D000X(&ItemValue[0],
                                   total_toque_ALL_32bit222); // 1.111 or 11.111
        // cN_m_unit_Display_xxx_x( total_toque_ALL_32bit);	//1.111
        // or 11.111
      }
      else
      {
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);

      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 補正量單位顯示（多語言）
    if ((Pg_JS_2_Step2_1.Offset_unit != Temp_Pg_JS_2_Step2_1.Offset_unit) ||
        (language_version != Temp_language_version))
    {
      ItemValue_Clear();

      if (Pg_JS_2_Step2_1.Offset_unit == 0)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "Kgf.m");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Kgf_m_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Kgf_m_GB);
        }
        else
        {
        }
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 1)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "N.m");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Nm_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Nm_GB);
        }
        else
        {
        }
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 2)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "Kgf.cm");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Kgf_cm_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], Kgf_cm_GB);
        }
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 3)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "In.lbs");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], In_lbs_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], In_lbs_GB);
        }
        else
        {
        }
      }
      else if (Pg_JS_2_Step2_1.Offset_unit == 4)
      {
        if (language_version == 0)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], "cN.m");
        }
        else if (language_version == 1)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], cN_m_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetText(hItems.TEXT[TEXT_Index], cN_m_GB);
        }
        else
        {
        }
      }
      else
      {
      }

      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 你這段是用來顯示 Delay Time（延遲時間，應該單位是秒，且小數點後兩位），當延遲時間有異動時，動態更新到對應的 UI 欄位。
    /*
    假如 u16Delay_Time = 123，輸出就是字串 "1.23"

    你用 0x30 做 ascii 字元轉換，這是C語言中手動組字串的標準作法

    順序也完全正確，不會產生多餘數字

    缺點： 若超過 999（例如 1000 會顯示成 "10.00"），需注意顯示長度夠不夠
     */
    if (Pg_JS_2_Step2_1.u16Delay_Time != Temp_Pg_JS_2_Step2_1.u16Delay_Time)
    {
      ItemValue_Clear();
      ItemValue[0] = Pg_JS_2_Step2_1.u16Delay_Time / 100 + 0x30;
      ItemValue[1] = '.';
      ItemValue[2] = Pg_JS_2_Step2_1.u16Delay_Time % 100 / 10 + 0x30;
      ItemValue[3] = Pg_JS_2_Step2_1.u16Delay_Time % 100 % 10 + 0x30;

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);

      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }

    memcpy(&Temp_Pg_JS_2_Step2_1, &Pg_JS_2_Step2_1, sizeof(Pg_JS_2_Step2_1));
    Temp_language_version = language_version;
    break;
  ////////////////////////////////////////////////////////////
  case 43:
    TEXT_Index = 1;
    /////////////////////////////////////////////////////////Pg_Home.Title
    if ((Pg_JS_3_Step2_2.Button1 != Temp_Pg_JS_3_Step2_2.Button1) ||
        (Pg_JS_3_Step2_2.Button2 != Temp_Pg_JS_3_Step2_2.Button2) ||
        (Pg_JS_3_Step2_2.Button3 != Temp_Pg_JS_3_Step2_2.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_JS_3_Step2_2.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_JS_3_Step2_2.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_JS_3_Step2_2.Button3);
    }
    /////////////////////////////////////////////////////////Pg_Home.Title
    // 用 build_title_string() 這種設計方便，動態組標題字串。
    if ((language_version != Temp_language_version) ||
        (Pg_JS_3_Step2_2.Title_Job_ID != Temp_Pg_JS_3_Step2_2.Title_Job_ID) ||
        (Pg_JS_3_Step2_2.Title_Seq_ID != Temp_Pg_JS_3_Step2_2.Title_Seq_ID) ||
        (Pg_JS_3_Step2_2.Title_Step_ID != Temp_Pg_JS_3_Step2_2.Title_Step_ID)

    )
    {
      ItemValue_Clear();
      if (language_version == 0)
        build_title_string(
            ItemValue, "Job", "Seq", "Step", Pg_JS_3_Step2_2.Title_Job_ID,
            Pg_JS_3_Step2_2.Title_Seq_ID, Pg_JS_3_Step2_2.Title_Step_ID);
      else if (language_version == 1)
        build_title_string(ItemValue, Job_Big5222, Seq_Big5222, Step_Big5222,
                           Pg_JS_3_Step2_2.Title_Job_ID,
                           Pg_JS_3_Step2_2.Title_Seq_ID,
                           Pg_JS_3_Step2_2.Title_Step_ID);
      else if (language_version == 2)
        build_title_string(ItemValue, Job_GB222, Seq_GB222, Step_GB222,
                           Pg_JS_3_Step2_2.Title_Job_ID,
                           Pg_JS_3_Step2_2.Title_Seq_ID,
                           Pg_JS_3_Step2_2.Title_Step_ID);

      FRAMEWIN_SetText(hItems.hWin, ItemValue);
    }
    /*
    Threshold 門檻類型（u8ThrSh_Mode）多語言顯示
    依不同模式與語言動態顯示：

    0：Threshold

    1：Threshold Ang.

    2：Threshold Tor.

    中文/英文字串分開維護，日後擴充更方便。
     */
    if ((language_version != Temp_language_version) ||
        (Pg_JS_3_Step2_2.u8ThrSh_Mode != Temp_Pg_JS_3_Step2_2.u8ThrSh_Mode))
    {
      ////////////////////////////////
      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 0)
      {
        if (language_version == 0)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], "Threshold");
        }
        else if (language_version == 1)
        {
          memcpy(ItemValue, Thresholde_Ang_Big5222,
                 strlen(Thresholde_Ang_Big5222) + 1);

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          memcpy(ItemValue, Thresholde_Ang_GB222,
                 strlen(Thresholde_Ang_GB222) + 1);

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else
        {
        }
      }

      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 1)
      {
        if (language_version == 0)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], "Threshold Ang.");
        }
        else if (language_version == 1)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Thresholde_Ang_Big5);
        }
        else if (language_version == 2)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Thresholde_Ang_GB);
        }
        else
        {
        }
      }

      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 2)
      {
        if (language_version == 0)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], "Threshold Tor.");
        }
        else if (language_version == 1)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Thresholde_Tor_Big5);
        }
        else if (language_version == 2)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Thresholde_Tor_GB);
        }
        else
        {
        }
      }
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
    你這段是在「門檻 & Downshift 功能」頁面動態顯示「Downshift 模式」、「Threshold 狀態」以及「高門檻扭力數值」等內容，並支援三語言切換。你每個區塊都判斷是否需要刷新、然後才動作
     */
    // 三語言分別用不同的字串變數管理，設計正確。如果想簡化、日後好維護，建議用二維陣列管理所有語言內容，呼叫時用陣列索引即可。
    if ((language_version != Temp_language_version) ||
        (Pg_JS_3_Step2_2.u8DS_Mode != Temp_Pg_JS_3_Step2_2.u8DS_Mode))
    {

      if (Pg_JS_3_Step2_2.u8DS_Mode == 0)
      {
        if (language_version == 0)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], "Downshift");
        }
        else if (language_version == 1)
        {
          ItemValue_Clear();
          memcpy(ItemValue, Downshift_Ang_Big5222,
                 strlen(Downshift_Ang_Big5222) + 1);

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          ItemValue_Clear();
          memcpy(ItemValue, Downshift_Ang_GB222,
                 strlen(Downshift_Ang_GB222) + 1);

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else
        {
        }
      }

      if (Pg_JS_3_Step2_2.u8DS_Mode == 1)
      {
        if (language_version == 0)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], "Downshift Ang.");
        }
        else if (language_version == 1)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Downshift_Ang_Big5);
        }
        else if (language_version == 2)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Downshift_Ang_GB);
        }
        else
        {
        }
      }

      if (Pg_JS_3_Step2_2.u8DS_Mode == 2)
      {
        if (language_version == 0)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], "Downshift Tor.");
        }
        else if (language_version == 1)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Downshift_Tor_Big5);
        }
        else if (language_version == 2)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Downshift_Tor_GB);
        }
        else
        {
        }
      }
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // Threshold 狀態判斷及「空白」或「o」符號顯示
    /*
    這裡你是根據狀態顯示不同「符號」和空欄，讓 UI 有清楚的視覺分隔。索引管理沒問題。
     */
    if (Pg_JS_3_Step2_2.u8ThrSh_Mode != Temp_Pg_JS_3_Step2_2.u8ThrSh_Mode)
    {

      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 0)
      {

        TEXT_SetText(hItems.TEXT[TEXT_Index], ""); // «×
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;

        TEXT_SetText(hItems.TEXT[TEXT_Index], " "); // «×
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;

        TEXT_Index++;
        TEXT_Index++;
      }
      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 1)
      {

        TEXT_SetText(hItems.TEXT[TEXT_Index], "o"); // «×
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;

        TEXT_SetText(hItems.TEXT[TEXT_Index], "o"); // «×
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;

        TEXT_Index++;
        TEXT_Index++;
      }
      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 2)
      {

        TEXT_SetText(hItems.TEXT[TEXT_Index], " "); // «×
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;

        TEXT_SetText(hItems.TEXT[TEXT_Index], " "); // «×
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;

        TEXT_Index++;
        TEXT_Index++;
      }
    }
    else
    {
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
    }
    // 高門檻扭力（u32Trq_H）多單位顯示
    // 每種單位用不同格式函式輸出，這在你所有頁面都很一致，這是好習慣。
    //////////////////////////////////////////////////////	Tourqe
    if ((Pg_JS_3_Step2_2.u32Trq_H != Temp_Pg_JS_3_Step2_2.u32Trq_H) ||
        (Pg_JS_3_Step2_2.Target_unit != Temp_Pg_JS_3_Step2_2.Target_unit))
    {
      ItemValue_Clear();
      total_toque_ALL_32bit222 = Pg_JS_3_Step2_2.u32Trq_H;

      if (Pg_JS_3_Step2_2.Target_unit == 0)
      {
        Kgf_m_unit_Display_x_xxxx(total_toque_ALL_32bit222);
      }
      else if (Pg_JS_3_Step2_2.Target_unit == 1)
      {
        Nm_unit_Display_x_xxx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_3_Step2_2.Target_unit == 2)
      {
        Kgf_cm_unit_Display_xx_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_3_Step2_2.Target_unit == 3)
      {
        Lbs_In_unit_Display_x_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_3_Step2_2.Target_unit == 4)
      {

        cN_m_unit_Display_xxx_x(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else
      {
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 你這一段是在**門檻頁（Step2_2）**裡處理下限/上限扭力、上下限角度、以及 Threshold（門檻）狀態的 UI 顯示
    // 1. 扭力下限 (u32Trq_L) 顯示（多單位格式）
    /*
    判斷下限扭力或單位變動時才更新。

    呼叫各單位的格式化 function，確保數值小數點顯示正確。

    多單位支援好維護！
     */
    if ((Pg_JS_3_Step2_2.u32Trq_L != Temp_Pg_JS_3_Step2_2.u32Trq_L) ||
        (Pg_JS_3_Step2_2.Target_unit != Temp_Pg_JS_3_Step2_2.Target_unit))
    {
      ItemValue_Clear();
      total_toque_ALL_32bit222 = Pg_JS_3_Step2_2.u32Trq_L;

      if (Pg_JS_3_Step2_2.Target_unit == 0)
      {
        Kgf_m_unit_Display_x_xxxx(total_toque_ALL_32bit222);
      }
      else if (Pg_JS_3_Step2_2.Target_unit == 1)
      {
        Nm_unit_Display_x_xxx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_3_Step2_2.Target_unit == 2)
      {
        Kgf_cm_unit_Display_xx_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_3_Step2_2.Target_unit == 3)
      {
        Lbs_In_unit_Display_x_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else if (Pg_JS_3_Step2_2.Target_unit == 4)
      {

        cN_m_unit_Display_xxx_x(total_toque_ALL_32bit222); // 1.111 or 11.111
      }
      else
      {
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }

    ////////////////////////////////////////////////////
    if (Pg_JS_3_Step2_2.u16Ang_H != Temp_Pg_JS_3_Step2_2.u16Ang_H)
    {
      ItemValue_Clear();
      total_angle = Pg_JS_3_Step2_2.u16Ang_H;
      Number16b_to_BCD5b(&ItemValue[0], total_angle, 1);
      ItemValue_Left_Alignment();
      if (total_angle == 0)
      {
        ItemValue_Clear();
        ItemValue[0] = '0';
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }

    if (Pg_JS_3_Step2_2.u16Ang_L != Temp_Pg_JS_3_Step2_2.u16Ang_L)
    {
      ItemValue_Clear();
      total_angle = Pg_JS_3_Step2_2.u16Ang_L;
      Number16b_to_BCD5b(&ItemValue[0], total_angle, 1);
      ItemValue_Left_Alignment();
      if (total_angle == 0)
      {
        ItemValue_Clear();
        ItemValue[0] = '0';
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // Threshold（門檻值）狀態顯示
    /*
    根據 u8ThrSh_Mode 來判斷是「關閉」、「角度門檻」或「扭力門檻」。

    多語言 ON/OFF 顯示沒問題。

    扭力、角度門檻都根據內容正確格式化。

    全部都做了零值特判，避免顯示空白或亂碼，這是很細心的設計。
     */
    ///////////////////////////////////////////////////
    if ((Pg_JS_3_Step2_2.u8ThrSh_Mode != Temp_Pg_JS_3_Step2_2.u8ThrSh_Mode) ||
        (Pg_JS_3_Step2_2.u32ThrSh_TrqAng !=
         Temp_Pg_JS_3_Step2_2.u32ThrSh_TrqAng) ||
        (Pg_JS_3_Step2_2.Target_unit != Temp_Pg_JS_3_Step2_2.Target_unit))
    {
      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 0)
      {
        ItemValue_Clear();
        if (language_version == 0)
        {
          memcpy(ItemValue, "OFF", 4);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
					
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_2_Step2_2_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_Big5);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_2_Step2_2_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_GB);
          WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
          WM_Update(hItems.TEXT[TEXT_Index]);
          TEXT_Index++;
        }
      }
      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 1)
      {
        ItemValue_Clear();
        total_angle = Pg_JS_3_Step2_2.u32ThrSh_TrqAng;

        Number16b_to_BCD5b(&ItemValue[0], total_angle, 1);
        ItemValue_Left_Alignment();
        if (total_angle == 0)
        {
          ItemValue_Clear();
          ItemValue[0] = '0';
        }

        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;
      }

      if (Pg_JS_3_Step2_2.u8ThrSh_Mode == 2)
      {
        ItemValue_Clear();
        total_toque_ALL_32bit222 = Pg_JS_3_Step2_2.u32ThrSh_TrqAng;

        if (Pg_JS_3_Step2_2.Target_unit == 0)
        {
          Kgf_m_unit_Display_x_xxxx(total_toque_ALL_32bit222);
        }
        else if (Pg_JS_3_Step2_2.Target_unit == 1)
        {
          Nm_unit_Display_x_xxx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_3_Step2_2.Target_unit == 2)
        {
          Kgf_cm_unit_Display_xx_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_3_Step2_2.Target_unit == 3)
        {
          Lbs_In_unit_Display_x_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_3_Step2_2.Target_unit == 4)
        {

          cN_m_unit_Display_xxx_x(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else
        {
        }

        if (total_toque_ALL_32bit222 == 0)
        {
          ItemValue_Clear();
          ItemValue[0] = '0';
        }

        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;
      }
    }
    else
    {
      TEXT_Index++;
    }
    // 你這段處理 Downshift 模式 相關的數值、單位、文字多語言顯示，和 Downshift 轉速 顯示
    /*
    Downshift 模式數值/狀態顯示（TrqAng）
    你依 u8DS_Mode 來決定顯示型態（關閉、角度、扭力），並考慮多語言與單位。

    OFF 狀態直接顯示 OFF 多語言，模式 1 顯示角度、模式 2 顯示扭力，數值格式化都正確。
     */
    if ((Pg_JS_3_Step2_2.u8DS_Mode != Temp_Pg_JS_3_Step2_2.u8DS_Mode) ||
        (Pg_JS_3_Step2_2.u32DS_TrqAng != Temp_Pg_JS_3_Step2_2.u32DS_TrqAng) ||
        (Pg_JS_3_Step2_2.Target_unit != Temp_Pg_JS_3_Step2_2.Target_unit))
    {
      if (Pg_JS_3_Step2_2.u8DS_Mode == 0)
      {
        ItemValue_Clear();
        if (language_version == 0)
        {
          memcpy(ItemValue, "OFF", 4);
          TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_2_Step2_2_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_Big5);
        }
        else
        {
          TEXT_SetFont(hItems.TEXT[TEXT_Index], &GUI_FontFont_Pg_JS_2_Step2_2_MicrosoftJhengHei_22B);
          TEXT_SetText(hItems.TEXT[TEXT_Index], Off_GB);
        }
      }

      if (Pg_JS_3_Step2_2.u8DS_Mode == 1)
      {

        //////////////////////////////////////////////////////////////
        ItemValue_Clear();
        total_angle = Pg_JS_3_Step2_2.u32DS_TrqAng;
        Number16b_to_BCD5b(&ItemValue[0], total_angle, 1);
        ItemValue_Left_Alignment();
        if (total_toque_ALL_32bit222 == 0)
        {
          ItemValue_Clear();
          ItemValue[0] = '0';
        }

        TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      }

      if (Pg_JS_3_Step2_2.u8DS_Mode == 2)
      {

        ItemValue_Clear();
        total_toque_ALL_32bit222 = Pg_JS_3_Step2_2.u32DS_TrqAng;

        if (Pg_JS_3_Step2_2.Target_unit == 0)
        {
          Kgf_m_unit_Display_x_xxxx(total_toque_ALL_32bit222);
        }
        else if (Pg_JS_3_Step2_2.Target_unit == 1)
        {
          Nm_unit_Display_x_xxx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_3_Step2_2.Target_unit == 2)
        {
          Kgf_cm_unit_Display_xx_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_3_Step2_2.Target_unit == 3)
        {
          Lbs_In_unit_Display_x_xx(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else if (Pg_JS_3_Step2_2.Target_unit == 4)
        {

          cN_m_unit_Display_xxx_x(total_toque_ALL_32bit222); // 1.111 or 11.111
        }
        else
        {
        }
        if (total_toque_ALL_32bit222 == 0)
        {
          ItemValue_Clear();
          ItemValue[0] = '0';
        }

        TEXT_SetFont(hItems.TEXT[TEXT_Index], GUI_FONT_20_1);
        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      }

      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*2. Downshift RPM 顯示
    若 Downshift 關閉，顯示 0 與空白欄。否則顯示實際值+單位名稱（多語言）。
    顯示時 index 推進都符合畫面欄位數。
    */
    ////////////////////////////////////////////////////
    if ((Pg_JS_3_Step2_2.u8DS_Mode != Temp_Pg_JS_3_Step2_2.u8DS_Mode) ||
        (Pg_JS_3_Step2_2.u16DS_Rpm != Temp_Pg_JS_3_Step2_2.u16DS_Rpm))
    {
      if (Pg_JS_3_Step2_2.u8DS_Mode == 0)
      {
        ItemValue_Clear();
        Pg_JS_3_Step2_2.u16DS_Rpm = 0;
        ItemValue[0] = '0';
        ItemValue_Left_Alignment();

        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;

        TEXT_SetText(hItems.TEXT[TEXT_Index], "");
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;
      }
      else
      {
        ItemValue_Clear();
        Number16b_to_BCD3b(&ItemValue[0], Pg_JS_3_Step2_2.u16DS_Rpm, 1);
        ItemValue_Left_Alignment();
        if (Pg_JS_3_Step2_2.u16DS_Rpm == 0)
        {
          ItemValue_Clear();
          ItemValue[0] = '0';
        }

        TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;

        if (language_version == 0)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], "Downshift Spd.");
        }
        else if (language_version == 1)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Downshift_Spd_Big5);
        }
        else if (language_version == 2)
        {

          TEXT_SetText(hItems.TEXT[TEXT_Index], Downshift_Spd_GB);
        }
        else
        {
        }
        WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
        WM_Update(hItems.TEXT[TEXT_Index]);
        TEXT_Index++;
      }
    }
    else
    {
      TEXT_Index++;
      TEXT_Index++;
    }
    // 很標準，這樣每次都能比對新舊值做差異化刷新。
    memcpy(&Temp_Pg_JS_3_Step2_2, &Pg_JS_3_Step2_2, sizeof(Pg_JS_3_Step2_2));
    Temp_language_version = language_version;
    break;
  // 你這段是在顯示「工具資訊頁」（通常是「驅動器/工具」的資訊），這些欄位都屬於軟體版本、工具序號、類型名稱等基礎資訊，基本每欄都支援資料變更即時刷新
  case 50:
    TEXT_Index = 1;
    // 用 ButtonLabelChange 來即時更新按鈕文字，這在多語言切換時非常實用。
    if ((Pg_Tool_Info_0.Button1 != Temp_Pg_Tool_Info_0.Button1) ||
        (Pg_Tool_Info_0.Button2 != Temp_Pg_Tool_Info_0.Button2) ||
        (Pg_Tool_Info_0.Button3 != Temp_Pg_Tool_Info_0.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_Tool_Info_0.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_Tool_Info_0.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_Tool_Info_0.Button3);
    }
    /////////////////////////////////////////////////////////Pg_Home.Title
    ItemValue_Clear();
    if ((Pg_Tool_Info_0.Title != Temp_Pg_Tool_Info_0.Title) ||
        (language_version != Temp_language_version))
    {
      if (Pg_Tool_Info_0.Title == 0)
      {

        FRAMEWIN_SetText(hItems.hWin, " ");
      }
    }
    // 韌體版本組成如 123.456（前3碼、後3碼），格式化很標準。
    if ((Pg_Tool_Info_0.FW1 != Temp_Pg_Tool_Info_0.FW1) ||
        (Pg_Tool_Info_0.FW2 != Temp_Pg_Tool_Info_0.FW2))
    {
      ItemValue_Clear();
      // Number16b_to_BCD3b(&ItemValue[0], Pg_Tool_Info_0.FW1, 1);

      // ItemValue[3] = '.';
      // Number16b_to_BCD3b(&ItemValue[4], Pg_Tool_Info_0.FW2, 1);
      // ItemValue_Left_Alignment();
      Show_Tool_FW_Version(Pg_Tool_Info_0.FW1 + Pg_Tool_Info_0.FW2 * 256, ItemValue);
      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);

      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 序號用兩欄顯示（12 bytes + 8 bytes），這是常見設計。
    ///////////////////////////////////////
    if (memcmp(&Pg_Tool_Info_0.u8Tool_SN[0], &Temp_Pg_Tool_Info_0.u8Tool_SN[0],
               sizeof(Pg_Tool_Info_0.u8Tool_SN)) != 0)
    {
      ItemValue_Clear();
      memcpy(ItemValue, &Pg_Tool_Info_0.u8Tool_SN[0],
             12);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;

      ItemValue_Clear();
      memcpy(ItemValue, &Pg_Tool_Info_0.u8Tool_SN[11],
             9);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
      TEXT_Index++;
    }
    // 5. 工具類型名稱 Tool_Type_Name
    ///////////////////////////////////////
    if (memcmp(&Pg_Tool_Info_0.u8Type_Name[0],
               &Temp_Pg_Tool_Info_0.u8Type_Name[0],
               sizeof(Pg_Tool_Info_0.u8Type_Name)) != 0)
    {
      ItemValue_Clear();
      memcpy(ItemValue, &Pg_Tool_Info_0.u8Type_Name[0], 11);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;

      ItemValue_Clear();
      memcpy(ItemValue, &Pg_Tool_Info_0.u8Type_Name[11], 9);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
      TEXT_Index++;
    }
    // 你這段是工具資訊頁的「PCB 溫度」、「電池溫度」以及「歷史最大扭力」等數值顯示，而且已經加上負數顯示邏輯，以及延伸的多欄資料填補（DisplayOByDigitIndex）。
    // 負數溫度會顯示負號，資料正確填入。ItemValue_Left_Alignment() 做左靠齊，負號特別有 negative_ItemValue_Left_Alignment()。
    if (Pg_Tool_Info_0.PCB_T != Temp_Pg_Tool_Info_0.PCB_T)
    {
      ItemValue_Clear();
      if (Pg_Tool_Info_0.PCB_T < 0)
      {
        temp = -Pg_Tool_Info_0.PCB_T;

        ItemValue[0] = '-';
        Number16b_to_BCD3b(&ItemValue[1], temp, 1);
        negative_ItemValue_Left_Alignment();
      }
      else
      {

        Number16b_to_BCD3b(&ItemValue[0], Pg_Tool_Info_0.PCB_T, 1);
        ItemValue_Left_Alignment();
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 跟 PCB 溫度一樣做法，無誤。
    //////////////////////////////////////////////
    if (Pg_Tool_Info_0.Batt_Temp != Temp_Pg_Tool_Info_0.Batt_Temp)
    {
      ItemValue_Clear();
      if (Pg_Tool_Info_0.Batt_Temp < 0)
      {
        temp = -Pg_Tool_Info_0.Batt_Temp;

        ItemValue[0] = '-';
        Number16b_to_BCD3b(&ItemValue[1], temp, 1);
        negative_ItemValue_Left_Alignment();
      }
      else
      {
        temp = Pg_Tool_Info_0.Batt_Temp;
        Number16b_to_BCD3b(&ItemValue[0], Pg_Tool_Info_0.Batt_Temp, 1);
        ItemValue_Left_Alignment();
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    ////////////////////////////////////////////////////////////

    if (Pg_Tool_Info_0.u32Hi_Tourqe != Temp_Pg_Tool_Info_0.u32Hi_Tourqe)
    {
      ItemValue_Clear();
      total_toque_ALL_32bit222 = Pg_Tool_Info_0.u32Hi_Tourqe;
      Number32b_to_BCD7b_00D000X(
          &ItemValue[0], total_toque_ALL_32bit222); // 1.111 or 11.111

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 顯示角度的符號,多欄顯示與補齊（進階擴展）
    /*
    這裡應該是你要一個數值分多欄顯示（可能是每一個 digit 一欄）。

    如果溫度沒變就跳過 6 欄，否則執行你的分欄顯示 function。

    這是表格式數值顯示常用技巧，配合大字體時很好用。
     */
    if (Pg_Tool_Info_0.PCB_T != Temp_Pg_Tool_Info_0.PCB_T)
    {
      TEXT_Index = DisplayOByDigitIndex(TEXT_Index, Pg_Tool_Info_0.PCB_T);
    }
    else
    {
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
    }

    if (Pg_Tool_Info_0.Batt_Temp != Temp_Pg_Tool_Info_0.Batt_Temp)
    {
      TEXT_Index = DisplayOByDigitIndex2(TEXT_Index, Pg_Tool_Info_0.Batt_Temp);
    }
    else
    {
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
      TEXT_Index++;
    }
    // 每頁結尾資料同步，這樣下次判斷才能準確。
    memcpy(&Temp_Pg_Tool_Info_0, &Pg_Tool_Info_0, sizeof(Pg_Tool_Info_0));
    Temp_language_version = language_version;

    break;
    // 「網路資訊頁」的狀態/模式顯示（AP/STA模式與Static/DHCP切換，多語言）
  case 60:
    TEXT_Index = 1;
    if ((Pg_Net_Info_0.Title != Temp_Pg_Net_Info_0.Title) ||
        (language_version != Temp_language_version))
    {
      if (Pg_Net_Info_0.Title == 0)
      {
        FRAMEWIN_SetText(hItems.hWin, " ");
      }
    }

    ////////////////////////////////
    // 按鈕語言變化，確保畫面及資料同步，這樣下次就能用 != 正確判斷。
    if ((Pg_Net_Info_0.Button1 != Temp_Pg_Net_Info_0.Button1) ||
        (Pg_Net_Info_0.Button2 != Temp_Pg_Net_Info_0.Button2) ||
        (Pg_Net_Info_0.Button3 != Temp_Pg_Net_Info_0.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_Net_Info_0.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_Net_Info_0.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_Net_Info_0.Button3);
      Temp_Pg_Net_Info_0.Button3 = Pg_Net_Info_0.Button3;
      Temp_Pg_Net_Info_0.Button2 = Pg_Net_Info_0.Button2;
      Temp_Pg_Net_Info_0.Button1 = Pg_Net_Info_0.Button1;
    }
    /*
    四種模式：Static(AP)、DHCP(AP)、Static(STA)、DHCP(STA)。

   英文直接複製字串，繁體與簡體都取前 6 bytes 進行拼接「（AP）/（STA）」。

   字串處理方式很直觀，如果未來要支援更多語言，建議全部搬到一個 2D 陣列（語言 x 模式）。
     */
    if ((Pg_Net_Info_0.Mode != Temp_Pg_Net_Info_0.Mode) ||
        (language_version != Temp_language_version))
    {
      if (Pg_Net_Info_0.Mode == 1)
      {
        if (language_version == 0)
        {
          ItemValue_Clear();
          memcpy(ItemValue, "Static (AP)", 12);

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
          ;
        }
        else if (language_version == 1)
        {
          ItemValue_Clear();
          memcpy(ItemValue, &SS_Big5222, 6);
          ItemValue[6] = '(';
          ItemValue[7] = 'A';
          ItemValue[8] = 'P';
          ItemValue[9] = ')';

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          ItemValue_Clear();
          memcpy(ItemValue, &SS_GB222, 6);
          ItemValue[6] = '(';
          ItemValue[7] = 'A';
          ItemValue[8] = 'P';
          ItemValue[9] = ')';

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else
        {
        }
      }
      else if (Pg_Net_Info_0.Mode == 2)
      {
        if (language_version == 0)
        {
          ItemValue_Clear();
          memcpy(ItemValue, "DHCP (AP)", 10);

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          ItemValue_Clear();
          memcpy(ItemValue, DHCP_Big5222, 6);
          ItemValue[6] = '(';
          ItemValue[7] = 'A';
          ItemValue[8] = 'P';
          ItemValue[9] = ')';

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          ItemValue_Clear();
          memcpy(ItemValue, DHCP_GB222, 6);
          ItemValue[6] = '(';
          ItemValue[7] = 'A';
          ItemValue[8] = 'P';
          ItemValue[9] = ')';

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else
        {
        }
      }
      else if (Pg_Net_Info_0.Mode == 3)
      {
        if (language_version == 0)
        {

          ItemValue_Clear();
          memcpy(ItemValue, "Static (STA)", 13);

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          ItemValue_Clear();
          memcpy(ItemValue, SS_Big5222, 6);
          ItemValue[6] = '(';
          ItemValue[7] = 'S';
          ItemValue[8] = 'T';
          ItemValue[9] = 'A';
          ItemValue[10] = ')';

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          ItemValue_Clear();
          memcpy(ItemValue, SS_GB222, 6);
          ItemValue[6] = '(';
          ItemValue[7] = 'S';
          ItemValue[8] = 'T';
          ItemValue[9] = 'A';
          ItemValue[10] = ')';

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else
        {
        }
      }
      else if (Pg_Net_Info_0.Mode == 4)
      {
        if (language_version == 0)
        {
          ItemValue_Clear();
          memcpy(ItemValue, "DHCP (STA)", 11);

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 1)
        {
          ItemValue_Clear();
          memcpy(ItemValue, DHCP_Big5222, 6);
          ItemValue[6] = '(';
          ItemValue[7] = 'S';
          ItemValue[8] = 'T';
          ItemValue[9] = 'A';
          ItemValue[10] = ')';

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else if (language_version == 2)
        {
          ItemValue_Clear();
          memcpy(ItemValue, DHCP_GB222, 6);
          ItemValue[6] = '(';
          ItemValue[7] = 'S';
          ItemValue[8] = 'T';
          ItemValue[9] = 'A';
          ItemValue[10] = ')';

          TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
        }
        else
        {
        }
      }
      else
      {
      }
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }

    ////////////////////////////////
    // 你這段是「網路資訊頁」裡網路參數（IP、Gateway、Mask、MAC、TCP Server IP）的即時顯示刷新
    /*
    1. IP/子網/閘道資訊顯示
    利用 memcmp 來判斷是否需要刷新（有效避免重複操作）。

    用 Format_IP_String_Variable 來將 4 bytes 轉成 xxx.xxx.xxx.xxx 格式（例如：192.168.1.1）。

    刷新操作就是 SetText→InvalidateWindow→Update，正確無誤。

     */
    if (memcmp(&Pg_Net_Info_0.STA_IP[0], &Temp_Pg_Net_Info_0.STA_IP[0],
               sizeof(Pg_Net_Info_0.STA_IP)) != 0)
    {
      ItemValue_Clear();
      Format_IP_String_Variable(
          ItemValue, Pg_Net_Info_0.STA_IP[0], Pg_Net_Info_0.STA_IP[1],
          Pg_Net_Info_0.STA_IP[2], Pg_Net_Info_0.STA_IP[3]);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }

    if (memcmp(&Pg_Net_Info_0.STA_Gateway[0],
               &Temp_Pg_Net_Info_0.STA_Gateway[0],
               sizeof(Pg_Net_Info_0.STA_Gateway)) != 0)
    {
      ItemValue_Clear();
      Format_IP_String_Variable(
          ItemValue, Pg_Net_Info_0.STA_Gateway[0], Pg_Net_Info_0.STA_Gateway[1],
          Pg_Net_Info_0.STA_Gateway[2], Pg_Net_Info_0.STA_Gateway[3]);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /////////////////////////////////////////////////////////
    if (memcmp(&Pg_Net_Info_0.STA_Subnet_Mask[0],
               &Temp_Pg_Net_Info_0.STA_Subnet_Mask[0],
               sizeof(Pg_Net_Info_0.STA_Subnet_Mask)) != 0)
    {
      ItemValue_Clear();
      Format_IP_String_Variable(ItemValue, Pg_Net_Info_0.STA_Subnet_Mask[0],
                                Pg_Net_Info_0.STA_Subnet_Mask[1],
                                Pg_Net_Info_0.STA_Subnet_Mask[2],
                                Pg_Net_Info_0.STA_Subnet_Mask[3]);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
     MAC Address 顯示
    MAC 通常是 6 bytes，你用三格一組，XX:XX:XX:XX:XX:XX 這樣組合，做法正確。

    Number8b_to_HexBCD2b 應該是將 byte 轉成 2 位 HEX 字元。
     */
    ////////////////////////////////
    if (memcmp(&Pg_Net_Info_0.MAC[0], &Temp_Pg_Net_Info_0.MAC[0],
               sizeof(Pg_Net_Info_0.MAC)) != 0)
    {
      ItemValue_Clear();
      for (int i = 0; i < MAC_LEN; i++)
      {
        Number8b_to_HexBCD2b((uint8_t *)&ItemValue[i * 3],
                             Pg_Net_Info_0.MAC[i]);
        if (i < MAC_LEN - 1)
        {
          ItemValue[i * 3 + 2] = ':';
        }
      }

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    /*
    1. TCP Server IP
    使用 memcmp 判斷 IP 是否異動。

    用 Format_IP_String_Variable 將 4 bytes 組成「xxx.xxx.xxx.xxx」格式。

    組好後透過 TEXT_SetText、WM_InvalidateWindow、WM_Update 更新對應欄位。

    避免未變化時多餘刷新。
     */
    /////////////////////////////////////////////////////////////////
    if (memcmp(&Pg_Net_Info_0.STA_TCP_Server_IP[0],
               &Temp_Pg_Net_Info_0.STA_TCP_Server_IP[0],
               sizeof(Pg_Net_Info_0.STA_TCP_Server_IP)) != 0)
    {
      ItemValue_Clear();
      Format_IP_String_Variable(&ItemValue[0],
                                Pg_Net_Info_0.STA_TCP_Server_IP[0],
                                Pg_Net_Info_0.STA_TCP_Server_IP[1],
                                Pg_Net_Info_0.STA_TCP_Server_IP[2],
                                Pg_Net_Info_0.STA_TCP_Server_IP[3]);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    ///////////////////////////////////////////////////////
    /*
    . TCP Server Port
    直接比對 STA_Port 變動（這通常是 uint16_t 或 uint32_t，不需 memcmp）。

    使用 Number16b_to_BCD5b 格式化，這應該是將 Port 轉成右對齊、帶前導零的字串（最長 5碼）。

    同樣更新畫面。
     */
    ///////////////////////////////////////////////
    if (Pg_Net_Info_0.STA_Port != Temp_Pg_Net_Info_0.STA_Port)
    {
      ItemValue_Clear();
      Number16b_to_BCD5b(&ItemValue[0], Pg_Net_Info_0.STA_Port, 1);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
    }
    // 同步 temp
    memcpy(&Temp_Pg_Net_Info_0, &Pg_Net_Info_0, sizeof(Pg_Net_Info_0));
    Temp_language_version = language_version;
    break;
  // 這段是處理WiFi AP 網路資訊頁面（Page 70）的畫面刷新與多語言，格式與前面一致，
  //  針對SSID（路由器名稱）分段顯示、按鈕標籤、標題同步刷新
  case 70:
    TEXT_Index = 1;
    ItemValue_Clear();
    /////////////////////////////////////////////////////////Pg_Home.Title
    if ((Pg_Net_AP_Info_0.Title != Temp_Pg_Net_AP_Info_0.Title) ||
        (language_version != Temp_language_version))
    {
      if (Pg_Net_AP_Info_0.Title == 0)
      {

        FRAMEWIN_SetText(hItems.hWin, " ");
      }
    }

    if ((Pg_Net_AP_Info_0.Button1 != Temp_Pg_Net_AP_Info_0.Button1) ||
        (Pg_Net_AP_Info_0.Button2 != Temp_Pg_Net_AP_Info_0.Button2) ||
        (Pg_Net_AP_Info_0.Button3 != Temp_Pg_Net_AP_Info_0.Button3) ||
        (language_version != Temp_language_version))
    {
      ButtonLabelChange(hItems.hWin, 0, Pg_Net_AP_Info_0.Button1);
      ButtonLabelChange(hItems.hWin, 1, Pg_Net_AP_Info_0.Button2);
      ButtonLabelChange(hItems.hWin, 2, Pg_Net_AP_Info_0.Button3);
      Temp_Pg_Net_AP_Info_0.Button3 = Pg_Net_AP_Info_0.Button3;
      Temp_Pg_Net_AP_Info_0.Button2 = Pg_Net_AP_Info_0.Button2;
      Temp_Pg_Net_AP_Info_0.Button1 = Pg_Net_AP_Info_0.Button1;
    }
    if (memcmp(&Pg_Net_AP_Info_0.Router_SSID[0],
               &Temp_Pg_Net_AP_Info_0.Router_SSID[0],
               sizeof(Pg_Net_AP_Info_0.Router_SSID)) != 0)
    {
      ItemValue_Clear();
      memcpy(ItemValue, &Pg_Net_AP_Info_0.Router_SSID[0],
             19);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;

      ItemValue_Clear();
      memcpy(ItemValue, &Pg_Net_AP_Info_0.Router_SSID[19],
             13);

      TEXT_SetText(hItems.TEXT[TEXT_Index], ItemValue);
      WM_InvalidateWindow(hItems.TEXT[TEXT_Index]);
      WM_Update(hItems.TEXT[TEXT_Index]);
      TEXT_Index++;
    }
    else
    {
      TEXT_Index++;
      TEXT_Index++;
    }

    memcpy(&Temp_Pg_Net_AP_Info_0, &Pg_Net_AP_Info_0, sizeof(Pg_Net_AP_Info_0));
    Temp_language_version = language_version;
    break;
  default:
    break;
  }
}

void ItemValue_Clear(void)
{
  uint8_t for_i;

  for (for_i = 0; for_i < sizeof(ItemValue); for_i++)
    ItemValue[for_i] = 0;
}

void ItemValue2_Clear(void)
{
  uint8_t for_i;

  for (for_i = 0; for_i < sizeof(ItemValue2); for_i++)
    ItemValue2[for_i] = 0;
}

void PageValue_Clear(uint8_t size, char arr[])
{
  uint8_t for_i;

  for (for_i = 0; for_i < size; for_i++)
    arr[for_i] = 0;
}

void ItemValue_Left_Alignment(void)
{
  // 	uint8_t for_i;
  uint8_t Highest;

  for (Highest = 0; Highest < sizeof(ItemValue); Highest++)
  {
    if ((ItemValue[Highest] >= 0x31) && (ItemValue[Highest] <= 0x39)) // 1~9
    {
      break; // exit for
    }
  }
  if (Highest > 0)
  {
    memcpy(&ItemValue[0], &ItemValue[Highest],
           (sizeof(ItemValue) - Highest));
    for (Highest = (sizeof(ItemValue) - Highest); Highest < sizeof(ItemValue);
         Highest++)
      ItemValue[Highest] = 0;
  }
}

void negative_ItemValue_Left_Alignment(void)
{
  uint8_t i, Highest;

  for (Highest = 1; Highest < sizeof(ItemValue); Highest++)
  {
    if ((ItemValue[Highest] >= 0x31) &&
        (ItemValue[Highest] <= 0x39))
    { // '1'~'9'
      break;
    }
  }

  if (Highest > 1)
  {

    memmove(&ItemValue[1], &ItemValue[Highest], sizeof(ItemValue) - Highest);

    for (i = sizeof(ItemValue) - (Highest - 1); i < sizeof(ItemValue); i++)
    {
      ItemValue[i] = 0;
    }
  }
}

void Number16b_to_BCD6b_00D00X(char *LCM_Data_Addr,
                               uint16_t Data)
{
  uint8_t Digit_Temp;
  uint8_t i;

  if (Data < 10)
    Digit_Temp = 1;
  else if (Data < 100)
    Digit_Temp = 2;
  else if (Data < 1000)
    Digit_Temp = 3;
  else if (Data < 10000)
    Digit_Temp = 4;
  else if (Data <= 65535)
    Digit_Temp = 5;
  else
    Digit_Temp = 0;

  for (i = 0; i < 7; i++)
  {
    Data_2D2[i] = 0x00;
  }
  switch (Digit_Temp)
  {
  case 5:
    Data_2D2[0] = ((Data % 100000) / 10000);
  case 4:
    Data_2D2[1] = ((Data % 10000) / 1000);
  case 3:
    Data_2D2[3] = ((Data % 1000) / 100);
  case 2:
    Data_2D2[4] = ((Data % 100) / 10);
  case 1:
    Data_2D2[5] = (Data % 10);

    for (i = 0; i < 6; i++)
    {
      Data_2D2[i] += 0x30;
    }
    break;

  default:
    for (i = 0; i < 7; i++)
      Data_2D2[i] = '0';

    break;
  }
  Data_2D2[2] = 0x2E;
  Data_2D2[6] = 0x20;
  if (Data_2D2[0] == '0')
  {
    memcpy(&Data_2D2[0], &Data_2D2[1], 5);
    Data_2D2[5] = 0x20;
  }
  for (i = 0; i < 6; i++)
  {
    *LCM_Data_Addr++ = Data_2D2[i];
  }
}

void Number32b_to_BCD7b_00D000X(char *LCM_Data_Addr,
                                uint32_t Data)
{
  uint8_t Digit_Temp;
  uint8_t i;

  if (Data < 10)
    Digit_Temp = 1;
  else if (Data < 100)
    Digit_Temp = 2;
  else if (Data < 1000)
    Digit_Temp = 3;
  else if (Data < 10000)
    Digit_Temp = 4;
  else if (Data < 100000)
    Digit_Temp = 5;
  else if (Data < 1000000)
    Digit_Temp = 6;
  else
    Digit_Temp = 0;

  for (i = 0; i < 8; i++)
  {
    Data_2D2[i] = 0x00;
  }
  switch (Digit_Temp)
  {

  case 6:
    Data_2D2[0] = ((Data % 1000000) / 100000);
  case 5:
    Data_2D2[1] = ((Data % 100000) / 10000);
  case 4:
    Data_2D2[3] = ((Data % 10000) / 1000);
  case 3:
    Data_2D2[4] = ((Data % 1000) / 100);
  case 2:
    Data_2D2[5] = ((Data % 100) / 10);
  case 1:
    Data_2D2[6] = (Data % 10);

    for (i = 0; i < 7; i++)
    {
      Data_2D2[i] += 0x30;
    }
    break;

  default:
    for (i = 0; i < 8; i++)
      Data_2D2[i] = '0';

    break;
  }
  Data_2D2[2] = 0x2E;
  Data_2D2[7] = 0x20;
  if (Data_2D2[0] == '0')
  {
    memcpy(&Data_2D2[0], &Data_2D2[1], 6);
    Data_2D2[6] = 0x20;
  }
  for (i = 0; i < 7; i++)
  {
    *LCM_Data_Addr++ = Data_2D2[i];
  }
}

void Number8b_to_BCD2b(
    char *LCM_Data_Addr, uint8_t Data,
    uint8_t Zero_Padding)
{
  uint8_t Digit_Temp;

  *LCM_Data_Addr = 0x20;
  Digit_Temp = (Data / 10) % 10;
  if ((Zero_Padding >= 2) ||
      (Digit_Temp > 0))
    *LCM_Data_Addr = Digit_Temp + 0x30;

  LCM_Data_Addr++;
  *LCM_Data_Addr = (Data % 10) + 0x30;
}

void Number16b_to_BCD3b(
    char *LCM_Data_Addr, uint16_t Data,
    uint8_t Zero_Padding)
{
  uint8_t Digit_Temp;

  *LCM_Data_Addr = 0x20;
  Digit_Temp = (Data / 100) % 10;
  if ((Zero_Padding >= 3) ||
      (Digit_Temp > 0))
  {
    *LCM_Data_Addr = Digit_Temp + 0x30;
    Zero_Padding = 3;
  }

  LCM_Data_Addr++;
  *LCM_Data_Addr = 0x20;
  Digit_Temp = (Data / 10) % 10;
  if ((Zero_Padding >= 2) ||
      (Digit_Temp > 0))
    *LCM_Data_Addr = Digit_Temp + 0x30;

  LCM_Data_Addr++;
  *LCM_Data_Addr = (Data % 10) + 0x30;
}

void Format_IP_String_Variable(char *output, uint8_t ip1, uint8_t ip2,
                               uint8_t ip3, uint8_t ip4)
{
  uint8_t ip[4] = {ip1, ip2, ip3, ip4};
  char *ptr = output;

  for (int i = 0; i < 4; i++)
  {
    uint8_t val = ip[i];

    if (val >= 100)
      *ptr++ = (val / 100) + '0';
    if (val >= 10)
      *ptr++ = ((val / 10) % 10) + '0';

    *ptr++ = (val % 10) + '0';

    if (i != 3)
      *ptr++ = '.';
  }

  *ptr = '\0';
}

void Number16b_to_BCD4b(
    char *LCM_Data_Addr, uint16_t Data,
    uint8_t Zero_Padding)
{
  uint8_t Digit_Temp;
  uint8_t i;
  uint8_t Data_Ary[4] = {0x20, 0x20, 0x20, 0x20};

  Digit_Temp = 3;
  if ((Zero_Padding >= 1) && (Zero_Padding <= 4))
  {
    for (i = 0; i < Zero_Padding; i++)
      Data_Ary[Digit_Temp--] = 0x30;
  }

  if (Data < 10)
    Digit_Temp = 1;
  else if (Data < 100)
    Digit_Temp = 2;
  else if (Data < 1000)
    Digit_Temp = 3;
  else if (Data < 10000)
    Digit_Temp = 4;
  else
    Digit_Temp = 0;

  switch (Digit_Temp)
  {
  case 4:
    Data_Ary[0] = ((Data % 10000) / 1000);
  case 3:
    Data_Ary[1] = ((Data % 1000) / 100);
  case 2:
    Data_Ary[2] = ((Data % 100) / 10);
  case 1:
    Data_Ary[3] = (Data % 10);

    for (i = (4 - Digit_Temp); i < 4; i++)
      Data_Ary[i] += 0x30;
    for (i = 0; i < 4; i++)
      LCM_Data_Addr[i] = Data_Ary[i];

    break;

  default:
    for (i = 0; i < 4; i++)
      Data_Ary[i] = ' ';

    break;
  }
}

void Number16b_to_BCD5b(
    char *LCM_Data_Addr, uint16_t Data,
    uint8_t Zero_Padding)
{
  uint8_t Digit_Temp;
  uint8_t i;
  uint8_t Data_Ary[5] = {0x20, 0x20, 0x20, 0x20, 0x20};

  Digit_Temp = 4;
  if ((Zero_Padding >= 1) && (Zero_Padding <= 5))
  {
    for (i = 0; i < Zero_Padding; i++)
      Data_Ary[Digit_Temp--] = 0x30;
  }

  if (Data < 10)
    Digit_Temp = 1;
  else if (Data < 100)
    Digit_Temp = 2;
  else if (Data < 1000)
    Digit_Temp = 3;
  else if (Data < 10000)
    Digit_Temp = 4;

  else if (Data <= 65535)
    Digit_Temp = 5;
  else
    Digit_Temp = 0;

  switch (Digit_Temp)
  {
  case 5:
    Data_Ary[0] = ((Data % 100000) / 10000);
  case 4:
    Data_Ary[1] = ((Data % 10000) / 1000);
  case 3:
    Data_Ary[2] = ((Data % 1000) / 100);
  case 2:
    Data_Ary[3] = ((Data % 100) / 10);
  case 1:
    Data_Ary[4] = (Data % 10);

    for (i = (5 - Digit_Temp); i < 5; i++)
      Data_Ary[i] += 0x30;
    for (i = 0; i < 5; i++)
      LCM_Data_Addr[i] = Data_Ary[i];

    break;

  default:
    for (i = 0; i < 5; i++)
      Data_Ary[i] = ' ';

    break;
  }
}
void Number32b_to_BCD5b(
    char *LCM_Data_Addr, uint32_t Data,
    uint8_t Zero_Padding)
{
  uint8_t Digit_Temp;
  uint8_t i;
  uint8_t Data_Ary[5] = {0x20, 0x20, 0x20, 0x20, 0x20};
  // 	uint8_t Data_Ary[5] = {0x30,0x30,0x30,0x30,0x30};

  Digit_Temp = 4;
  if ((Zero_Padding >= 1) && (Zero_Padding <= 5))
  {
    for (i = 0; i < Zero_Padding; i++)
      Data_Ary[Digit_Temp--] = 0x30;
  }

  if (Data < 10)
    Digit_Temp = 1;
  else if (Data < 100)
    Digit_Temp = 2;
  else if (Data < 1000)
    Digit_Temp = 3;
  else if (Data < 10000)
    Digit_Temp = 4;
  // 	else if(Data < 100000)
  else if (Data <= 65535) //
    Digit_Temp = 5;
  else
    Digit_Temp = 0;

  switch (Digit_Temp)
  {
  case 5:
    Data_Ary[0] = ((Data % 100000) / 10000);
  case 4:
    Data_Ary[1] = ((Data % 10000) / 1000);
  case 3:
    Data_Ary[2] = ((Data % 1000) / 100);
  case 2:
    Data_Ary[3] = ((Data % 100) / 10);
  case 1:
    Data_Ary[4] = (Data % 10);

    for (i = (5 - Digit_Temp); i < 5; i++)
      Data_Ary[i] += 0x30;
    for (i = 0; i < 5; i++)
      LCM_Data_Addr[i] = Data_Ary[i];

    break;

  default:
    for (i = 0; i < 5; i++)
      Data_Ary[i] = ' ';

    break;
  }
}

void Number32b_to_BCD10b(
    char *LCM_Data_Addr, uint32_t Data,
    uint8_t Zero_Padding)
{
  uint8_t Digit_Temp;
  uint8_t i;
  uint8_t Data_Ary[10] = {0x20, 0x20, 0x20, 0x20, 0x20,
                          0x20, 0x20, 0x20, 0x20, 0x20};

  Digit_Temp = 9;
  if ((Zero_Padding >= 1) && (Zero_Padding <= 10))
  {
    for (i = 0; i < Zero_Padding; i++)
      Data_Ary[Digit_Temp--] = 0x30;
  }

  if (Data < 10)
    Digit_Temp = 1;
  else if (Data < 100)
    Digit_Temp = 2;
  else if (Data < 1000)
    Digit_Temp = 3;
  else if (Data < 10000)
    Digit_Temp = 4;
  else if (Data < 100000)
    Digit_Temp = 5;
  else if (Data < 1000000)
    Digit_Temp = 6;
  else if (Data < 10000000)
    Digit_Temp = 7;
  else if (Data < 100000000)
    Digit_Temp = 8;
  else if (Data < 1000000000)
    Digit_Temp = 9;
  else if (Data <= 4294967295)
    Digit_Temp = 10;
  else
    Digit_Temp = 0;

  switch (Digit_Temp)
  {
  case 10:
    Data_Ary[0] = (Data / 1000000000);
  case 9:
    Data_Ary[1] = ((Data % 1000000000) / 100000000);
  case 8:
    Data_Ary[2] = ((Data % 100000000) / 10000000);
  case 7:
    Data_Ary[3] = ((Data % 10000000) / 1000000);
  case 6:
    Data_Ary[4] = ((Data % 1000000) / 100000);
  case 5:
    Data_Ary[5] = ((Data % 100000) / 10000);
  case 4:
    Data_Ary[6] = ((Data % 10000) / 1000);
  case 3:
    Data_Ary[7] = ((Data % 1000) / 100);
  case 2:
    Data_Ary[8] = ((Data % 100) / 10);
  case 1:
    Data_Ary[9] = (Data % 10);

    for (i = (10 - Digit_Temp); i < 10; i++)
      Data_Ary[i] += 0x30;
    for (i = 0; i < 10; i++)
      LCM_Data_Addr[i] = Data_Ary[i];

    break;

  default:
    for (i = 0; i < 10; i++)
      Data_Ary[i] = ' ';

    break;
  }
}
void Number8b_to_HexBCD2b(uint8_t *LCM_Data_Addr, uint8_t Data) // 0=0x00,??0??
{
  uint8_t Number8b = Data;
  uint8_t i;
  LCM_Data_Addr += 1; //????(LSB)
  for (i = 0; i < 2; i++)
  {
    if ((Number8b & 0x0F) < 10)
      *LCM_Data_Addr = ((Number8b & 0x0F) + 0x30);
    else
      *LCM_Data_Addr = ((Number8b & 0x0F) + 0x37);
    LCM_Data_Addr--;
    Number8b = Number8b >> 4;
  }
}
void Number16b_to_HexBCD4b(uint8_t *LCM_Data_Addr,
                           uint16_t Data) // 0=0x0000,??0??
{
  Number8b_to_HexBCD2b(LCM_Data_Addr, (Data >> 8)); // 0=0x00,??0??
  LCM_Data_Addr += 2;
  Number8b_to_HexBCD2b(LCM_Data_Addr, (Data & 0x00FF)); // 0=0x00,??0??
}
#define BTN_None 0
#define BTN_Page 1
#define BTN_Page_Up 2
#define BTN_Page_Down 3
#define BTN_Barcode 4
#define BTN_Comfirm 5
#define BTN_Enter 6
#define BTN_Select 7
#define BTN_Back 8
#define BTN_Next 9
#define BTN_Step 10
#define BTN_Sequence 11
#define BTN_Clear 12
#define BTN_Seq_Clear 13
void ButtonLabelChange(WM_HWIN hWin, uint8_t ButtonId, uint8_t ButtonLabel)
{
  if (language_version == 0)
  {
    ItemValue_Clear();
    if (ButtonLabel == BTN_None)
    {
    }
    else if (ButtonLabel == BTN_Page)
    {
      ItemValue[0] = 'P';
      ItemValue[1] = 'a';
      ItemValue[2] = 'g';
      ItemValue[3] = 'e';
    }
    else if (ButtonLabel == BTN_Page_Up)
    {
      ItemValue[0] = 'P';
      ItemValue[1] = 'a';
      ItemValue[2] = 'g';
      ItemValue[3] = 'e';
      ItemValue[4] = ' ';
      ItemValue[5] = 'U';
      ItemValue[6] = 'p';
    }
    else if (ButtonLabel == BTN_Page_Down)
    {
      ItemValue[0] = 'P';
      ItemValue[1] = 'a';
      ItemValue[2] = 'g';
      ItemValue[3] = 'e';
      ItemValue[4] = ' ';
      ItemValue[5] = 'D';
      ItemValue[6] = 'o';
      ItemValue[7] = 'w';
      ItemValue[8] = 'n';
    }
    else if (ButtonLabel == BTN_Barcode)
    {
      ItemValue[0] = 'B';
      ItemValue[1] = 'a';
      ItemValue[2] = 'r';
      ItemValue[3] = 'c';
      ItemValue[4] = 'o';
      ItemValue[5] = 'd';
      ItemValue[6] = 'e';
    }
    else if (ButtonLabel == BTN_Comfirm)
    {
      ItemValue[0] = 'C';
      ItemValue[1] = 'o';
      ItemValue[2] = 'm';
      ItemValue[3] = 'f';
      ItemValue[4] = 'i';
      ItemValue[5] = 'r';
      ItemValue[6] = 'm';
    }
    else if (ButtonLabel == BTN_Enter)
    {
      ItemValue[0] = 'E';
      ItemValue[1] = 'n';
      ItemValue[2] = 't';
      ItemValue[3] = 'e';
      ItemValue[4] = 'r';
    }
    else if (ButtonLabel == BTN_Select)
    {
      ItemValue[0] = 'S';
      ItemValue[1] = 'e';
      ItemValue[2] = 'l';
      ItemValue[3] = 'e';
      ItemValue[4] = 'c';
      ItemValue[5] = 't';
    }
    else if (ButtonLabel == BTN_Back)
    {
      ItemValue[0] = 'B';
      ItemValue[1] = 'a';
      ItemValue[2] = 'c';
      ItemValue[3] = 'k';
    }
    else if (ButtonLabel == BTN_Next)
    {
      ItemValue[0] = 'N';
      ItemValue[1] = 'e';
      ItemValue[2] = 'x';
      ItemValue[3] = 't';
    }
    else if (ButtonLabel == BTN_Step)
    {
      ItemValue[0] = 'S';
      ItemValue[1] = 't';
      ItemValue[2] = 'e';
      ItemValue[3] = 'p';
    }
    else if (ButtonLabel == BTN_Sequence)
    {
      ItemValue[0] = 'S';
      ItemValue[1] = 'e';
      ItemValue[2] = 'q';
      ItemValue[3] = 'u';
      ItemValue[4] = 'e';
      ItemValue[5] = 'n';
      ItemValue[6] = 'c';
      ItemValue[7] = 'e';
    }
    else if (ButtonLabel == BTN_Clear)
    {
      ItemValue[0] = 'C';
      ItemValue[1] = 'l';
      ItemValue[2] = 'e';
      ItemValue[3] = 'a';
      ItemValue[4] = 'r';
    }
    else if (ButtonLabel == BTN_Seq_Clear)
    {
      ItemValue[0] = 'S';
      ItemValue[1] = 'e';
      ItemValue[2] = 'q';
      ItemValue[3] = ' ';
      ItemValue[4] = 'C';
      ItemValue[5] = 'l';
      ItemValue[6] = 'e';
      ItemValue[7] = 'a';
      ItemValue[8] = 'r';
    }
    else
    {
    }
    BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

    BUTTON_SetText(hItems.BUTTON[ButtonId], ItemValue);
  }
  else if (language_version == 1)
  {
    ItemValue_Clear();
    if (ButtonLabel == BTN_None)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], " ");
    }
    else if (ButtonLabel == BTN_Page)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Page_Big5);
    }
    else if (ButtonLabel == BTN_Page_Up)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Page_Up_Big5);
    }
    else if (ButtonLabel == BTN_Page_Down)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Page_Down_Big5);
    }
    else if (ButtonLabel == BTN_Barcode)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Barcode_Big5);
    }
    else if (ButtonLabel == BTN_Comfirm)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Confirm_Big5);
    }
    else if (ButtonLabel == BTN_Enter)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Enter_Big5);
    }
    else if (ButtonLabel == BTN_Select)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Select_Big5);
    }
    else if (ButtonLabel == BTN_Back)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Back_Big5);
    }
    else if (ButtonLabel == BTN_Next)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Next_Big5);
    }
    else if (ButtonLabel == BTN_Step)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Step_Big5);
    }
    else if (ButtonLabel == BTN_Sequence)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Sequence_Big5);
    }
    else if (ButtonLabel == BTN_Clear)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Clear_BIG5);
    }
    else if (ButtonLabel == BTN_Seq_Clear)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], SeqClear_BIG5);
    }
    else
    {
    }
  }
  else if (language_version == 2)
  {
    if (ButtonLabel == BTN_None)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], " ");
    }
    else if (ButtonLabel == BTN_Page)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Page_GB);
    }
    else if (ButtonLabel == BTN_Page_Up)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Page_Up_GB);
    }
    else if (ButtonLabel == BTN_Page_Down)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Page_Down_GB);
    }
    else if (ButtonLabel == BTN_Barcode)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Barcode_GB);
    }
    else if (ButtonLabel == BTN_Comfirm)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Confirm_GB);
    }
    else if (ButtonLabel == BTN_Enter)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Enter_GB);
    }
    else if (ButtonLabel == BTN_Select)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Select_GB);
    }
    else if (ButtonLabel == BTN_Back)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Back_GB);
    }
    else if (ButtonLabel == BTN_Next)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Next_GB);
    }
    else if (ButtonLabel == BTN_Step)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Step_GB);
    }
    else if (ButtonLabel == BTN_Sequence)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Sequence_GB);
    }
    else if (ButtonLabel == BTN_Clear)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], Clear_GB);
    }
    else if (ButtonLabel == BTN_Seq_Clear)
    {
      BUTTON_SetFont(hItems.BUTTON[ButtonId], &GUI_FontFont_ALLPage_Button_MicrosoftJhengHei_16B);

      BUTTON_SetText(hItems.BUTTON[ButtonId], SeqClear_GB);
    }
    else
    {
    }
  }
}

void colorchange(uint8_t colortype, uint8_t loopvar)
{

  if (colortype == 0x00 || colortype == 0x09)
  {
  }
  else if (colortype == 0x01 || colortype == 0xa)
  {
    TEXT_SetBkColor(hItems.TEXT[loopvar + 1], GUI_BLUE);
  }
  else if (colortype == 0x02 || colortype == 0xb)
  {
    TEXT_SetBkColor(hItems.TEXT[loopvar + 1], GUI_RED);
  }
  else if (colortype == 0x03 || colortype == 0xc)
  {
    TEXT_SetBkColor(hItems.TEXT[loopvar + 1], GUI_GRAY);
  }
  else
  {
  }
  return;
}

void textchange(uint8_t fonttype, uint8_t loopvar)
{
  if (fonttype >= 0x9)
  {
    ItemValue_Clear();
    TEXT_SetText(hItems.TEXT[loopvar + 1], ItemValue);
  }
  else
  {
    if (Main_Page == 20 || Main_Page == 21)
    {
      if (loopvar == 0)
      {
        if (language_version == 0)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], GUI_FONT_20_1);

          TEXT_SetText(hItems.TEXT[loopvar + 1], "Stand Alone");
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Stand_Alone_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Stand_Alone_GB);
        }
        else
        {
        }
      }
      else if (loopvar == 1)
      {
        if (language_version == 0)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], GUI_FONT_20_1);

          TEXT_SetText(hItems.TEXT[loopvar + 1], "Controlled");
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Controlled_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Controlled_GB);
        }
        else
        {
        }
      }
      else if (loopvar == 2)
      {
        if (language_version == 0)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], GUI_FONT_20_1);

          TEXT_SetText(hItems.TEXT[loopvar + 1], "Default Setting Reset");
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_26B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Defaults_Setting_Resets_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_26B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Defaults_Setting_Resets_GB);
        }
        else
        {
        }
      }
      else if (loopvar == 3)
      {
        if (language_version == 0)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], GUI_FONT_20_1);

          TEXT_SetText(hItems.TEXT[loopvar + 1], "Tool ");
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Tool_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Tool_GB);
        }
      }
      else if (loopvar == 4)
      {
        if (language_version == 0)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], GUI_FONT_20_1);

          TEXT_SetText(hItems.TEXT[loopvar + 1], "WIFI");
        }
        else if (language_version == 1)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], WIFI_Big5);
        }
        else if (language_version == 2)
        {
          TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Tool_Mode_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], WIFI_GB);
        }
        else
        {
        }
      }
      else
      {
      }
    }
    if (Main_Page == 10 || Main_Page == 11)
    {
      if (loopvar == 0)
      {
        if (language_version == 0)
        {
        //  TEXT_SetFont(hItems.TEXT[loopvar + 1], GUI_FONT_20_1);

          TEXT_SetText(hItems.TEXT[loopvar + 1], "English");
        }
        else if (language_version == 1)
        {
        //  TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Language_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], English_Big5);
        }
        else if (language_version == 2)
        {
        //  TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Language_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], English_GB);
        }
        else
        {
        }
      }
      else if (loopvar == 1)
      {
        if (language_version == 0)
        {
       //   TEXT_SetFont(hItems.TEXT[loopvar + 1], GUI_FONT_20_1);

          TEXT_SetText(hItems.TEXT[loopvar + 1], "Traditional Chinese");
        }
        else if (language_version == 1)
        {
        //  TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Language_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Big5_Big5);
        }
        else if (language_version == 2)
        {
        //  TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Language_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], Big5_GB);
        }
        else
        {
        }
      }
      else if (loopvar == 2)
      {
        if (language_version == 0)
        {
         // TEXT_SetFont(hItems.TEXT[loopvar + 1], GUI_FONT_20_1);

          TEXT_SetText(hItems.TEXT[loopvar + 1], "Simplified Chinese");
        }
        else if (language_version == 1)
        {
         // TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Language_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], GB_Big5);
        }
        else if (language_version == 2)
        {
       //   TEXT_SetFont(hItems.TEXT[loopvar + 1], &GUI_FontFont_Pg_Language_MicrosoftJhengHei_22B);

          TEXT_SetText(hItems.TEXT[loopvar + 1], GB_GB);
        }
        else
        {
        }
      }
      else
      {
      }
    }
  }
  return;
}

void build_title_string(char *ItemValue, const char *JobPrefix,
                        const char *SeqPrefix, const char *StepPrefix,
                        int Job_ID, int Seq_ID, int Step_ID)
{
  int pos = 0;

  if (Job_ID != 255)
  {
    for (int i = 0; JobPrefix[i] != '\0'; ++i)
      ItemValue[pos++] = JobPrefix[i];
    ItemValue[pos++] = '-';
    ItemValue[pos++] = (Job_ID % 10) + '0';
  }

  if (Seq_ID != 255)
  {
    if (pos > 0)
      ItemValue[pos++] = ' ';
    for (int i = 0; SeqPrefix[i] != '\0'; ++i)
      ItemValue[pos++] = SeqPrefix[i];
    ItemValue[pos++] = '-';
    if (Seq_ID >= 10)
      ItemValue[pos++] = (Seq_ID / 10) % 10 + '0';
    ItemValue[pos++] = (Seq_ID % 10) + '0';
  }

  if (Step_ID != 255)
  {
    if (pos > 0)
      ItemValue[pos++] = ' ';
    for (int i = 0; StepPrefix[i] != '\0'; ++i)
      ItemValue[pos++] = StepPrefix[i];
    ItemValue[pos++] = (Step_ID % 10) + '0';
    ItemValue[pos++] = '-';
    if (Main_Page == 42)
      ItemValue[pos++] = '1';
    else
      ItemValue[pos++] = '2';
  }

  // ??
  ItemValue[pos] = '\0';
}

void Number32s_to_ASCII_xx_xxxx_ptr(char *LCM_Data_Addr, int32_t Data)
{
  uint32_t abs_val;
  uint32_t int_part, frac_part;
  char *p = LCM_Data_Addr;

  if (Data > 999999)
    Data = 999999;
  if (Data < -999999)
    Data = -999999;

  if (Data < 0)
  {
    *p++ = '-';
    abs_val = -Data;
  }
  else
  {
    abs_val = Data;
  }

  int_part = abs_val / 10000;
  frac_part = abs_val % 10000;

  if (Data < 0)
  {
    *p++ = (int_part / 10) + '0';
    *p++ = (int_part % 10) + '0';
  }
  else
  {
    if (int_part < 10)
    {
      *p++ = ' ';
      *p++ = int_part + '0';
    }
    else
    {
      *p++ = (int_part / 10) + '0';
      *p++ = (int_part % 10) + '0';
    }
  }

  *p++ = '.';
  *p++ = (frac_part / 1000) % 10 + '0';
  *p++ = (frac_part / 100) % 10 + '0';
  *p++ = (frac_part / 10) % 10 + '0';
  *p++ = frac_part % 10 + '0';
}

void Number32s_to_ASCII_xx_xxx_ptr(char *LCM_Data_Addr, int32_t Data)
{
  uint32_t abs_val;
  uint32_t int_part, frac_part;
  char *p = LCM_Data_Addr;

  if (Data > 999999)
    Data = 999999;
  if (Data < -999999)
    Data = -999999;

  if (Data < 0)
  {
    *p++ = '-';
    abs_val = -Data;
  }
  else
  {
    abs_val = Data;
  }

  int_part = abs_val / 1000;
  frac_part = abs_val % 1000;

  if (Data < 0)
  {

    *p++ = (int_part / 10) + '0';
    *p++ = (int_part % 10) + '0';
  }
  else
  {
    if (int_part < 10)
    {
      *p++ = int_part + '0';
    }
    else
    {
      *p++ = (int_part / 10) + '0';
      *p++ = (int_part % 10) + '0';
    }
  }

  *p++ = '.';

  *p++ = (frac_part / 100) % 10 + '0';
  *p++ = (frac_part / 10) % 10 + '0';
  *p++ = frac_part % 10 + '0';

  *p = '\0';
}

uint8_t DisplayOByDigitIndex(uint8_t textIndex, int8_t value)
{
  const char *texts[6] = {" ", " ", " ", " ", " ", " "};
  const char *marker = "o";
  int absValue = (value < 0) ? -value : value;

  if (value != 0)
  {
    int markerPos = 0;

    if (absValue >= 100 && absValue <= 127)
    {
      markerPos = 2;
    }
    else if (absValue >= 10 && absValue <= 99)
    {
      markerPos = 1;
    }
    else if (absValue >= 1 && absValue <= 9)
    {
      markerPos = 0;
    }

    if (value < 0)
    {
      markerPos += 3;
    }

    texts[markerPos] = marker;
  }

  for (int i = 0; i < 6; i++)
  {
    TEXT_SetText(hItems.TEXT[textIndex], texts[i]);
    if (i == 5)
    {
      WM_InvalidateWindow(hItems.TEXT[textIndex]);
      WM_Update(hItems.TEXT[textIndex]);
    }

    textIndex++;
  }
  return textIndex;
}

uint8_t DisplayOByDigitIndex2(uint8_t textIndex, int8_t value)
{
  const char *texts[6] = {" ", " ", " ", " ", " ", " "};
  const char *marker = "o";
  int absValue = (value < 0) ? -value : value;

  if (value != 0)
  {
    int markerPos = 0;

    if (absValue >= 100 && absValue <= 127)
    {
      markerPos = 2;
    }
    else if (absValue >= 10 && absValue <= 99)
    {
      markerPos = 1;
    }
    else if (absValue >= 1 && absValue <= 9)
    {
      markerPos = 0;
    }

    if (value < 0)
    {
      markerPos += 3;
    }

    texts[markerPos] = marker;
  }

  for (int i = 0; i < 6; i++)
  {
    TEXT_SetText(hItems.TEXT[textIndex], texts[i]);
    if (i == 5)
    {
      WM_InvalidateWindow(hItems.TEXT[textIndex]);
      WM_Update(hItems.TEXT[textIndex]);
    }

    textIndex++;
  }
  return textIndex;
}

void Delay_us(uint32_t us)
{
  SysTick->LOAD = us * 48; // 1us = 48 clock (?? HCLK = 48MHz)
  SysTick->VAL = 0;
  SysTick->CTRL |= SysTick_CTRL_ENABLE_Msk;

  while (!(SysTick->CTRL & SysTick_CTRL_COUNTFLAG_Msk))
    ;

  SysTick->CTRL &= ~SysTick_CTRL_ENABLE_Msk;
}

void Delay_ms(uint32_t ms)
{
  while (ms--)
    Delay_us(1000);
}
// 12345
// 1Nm=1.000Nm   (小數3位)通訊CMD會丟10000，要顯示1.000(小數3位)
void Nm_unit_Display_x_xxx(int32_t data)
{
  uint32_t abs_data = (data < 0) ? -data : data;

  uint32_t int_part = abs_data / 10000;   // 整數部分
  uint32_t remainder = abs_data % 10000;  // 小數部分：最多 4 位
  uint32_t decimal_part = remainder / 10; // 小數前 3 位
  uint32_t round_digit = remainder % 10;  // 第 4 位

  // 四捨五入
  if (round_digit >= 5)
  {
    decimal_part++;
    if (decimal_part >= 1000)
    {
      decimal_part = 0;
      int_part++; // 進位
    }
  }

  // 輸出字串，根據正負號決定
  if (data < 0)
    snprintf(ItemValue, sizeof(ItemValue), "-%u.%03u", int_part, decimal_part);
  else
    snprintf(ItemValue, sizeof(ItemValue), "%u.%03u", int_part, decimal_part);
}

/*void Nm_unit_Display_x_xxx(uint32_t data)
{
  uint32_t int_part = data / 10000;       // 取整數部分，例如 11
  uint32_t remainder = data % 10000;      // 小數部分：最多 4 位，例如 3300
  uint32_t decimal_part = remainder / 10; // 小數前 3 位：3300 / 10 = 330
  uint32_t round_digit = remainder % 10;  // 第 4 位數字：3300 % 10 = 0

  // 四捨五入判斷：第 4 位數字 >= 5 時進位
  if (round_digit >= 5)
  {
    decimal_part++;
    if (decimal_part >= 1000)
    {
      decimal_part = 0;
      int_part++; // 小數進位造成整數部分也進位，例如 9.999 ➜ 10.000
    }
  }

  snprintf(ItemValue, sizeof(ItemValue), "%u.%03u", int_part, decimal_part);
}
*/
// 1Nm=0.1020Kgf.m(小數4位)通訊CMD會丟1020，要顯示0.1020(小數4位)

void Kgf_m_unit_Display_x_xxxx(int32_t data)
{
  uint32_t abs_data = (data < 0) ? -data : data;

  uint32_t int_part = abs_data / 10000;     // 整數部分
  uint32_t decimal_part = abs_data % 10000; // 小數部分

  if (data < 0)
    snprintf(ItemValue, sizeof(ItemValue), "-%u.%04u", int_part, decimal_part);
  else
    snprintf(ItemValue, sizeof(ItemValue), "%u.%04u", int_part, decimal_part);
}

/*void Kgf_m_unit_Display_x_xxxx(uint32_t data)
{
  uint32_t int_part = data / 10000;     // 整數部分：111
  uint32_t decimal_part = data % 10000; // 小數部分：0781

  snprintf(ItemValue, sizeof(ItemValue), "%u.%04u", int_part, decimal_part);
}
*/
// 1Nm=8.85Lbs.In(小數2位)通訊CMD會丟88500，要顯示8.85(小數2位)

// data 120顯示120.0 通訊CMD會丟1210000
void cN_m_unit_Display_xxx_x(int32_t data)
{
  uint32_t abs_data = (data < 0) ? -data : data;

  uint32_t int_part = abs_data / 10000;
  uint32_t remainder = abs_data % 10000;
  uint32_t decimal_part = remainder / 1000;
  uint32_t round_digit = (remainder % 1000) / 100;

  // 四捨五入
  if (round_digit >= 5)
  {
    decimal_part++;
    if (decimal_part >= 10)
    {
      decimal_part = 0;
      int_part++;
    }
  }

  // 根據正負號輸出
  if (data < 0)
    snprintf(ItemValue, sizeof(ItemValue), "-%u.%u", int_part, decimal_part);
  else
    snprintf(ItemValue, sizeof(ItemValue), "%u.%u", int_part, decimal_part);
}

/*void cN_m_unit_Display_xxx_x(uint32_t data)
{
  uint32_t int_part = data / 10000;                // 整數部分，例如：1133100000 ➜ 113310
  uint32_t remainder = data % 10000;               // 小數部分（0.0001 ~ 0.9999 對應 0000~9999）
  uint32_t decimal_part = remainder / 1000;        // 小數第一位（十分位）
  uint32_t round_digit = (remainder % 1000) / 100; // 小數第二位（百分位）

  // 四捨五入
  if (round_digit >= 5)
  {
    decimal_part++;
    if (decimal_part >= 10)
    {
      decimal_part = 0;
      int_part++; // 進位，如 999.9 ➜ 1000.0
    }
  }

  snprintf(ItemValue, sizeof(ItemValue), "%u.%u", int_part, decimal_part);
}
*/
// 1Nm=10.20Kgf.cm(小數2位)，通訊CMD會丟102000 要顯示10.20(小數2位)
void Kgf_cm_unit_Display_xx_xx(int32_t data)
{
  uint32_t abs_data = (data < 0) ? -data : data;

  uint32_t int_part = abs_data / 10000;
  uint32_t remainder = abs_data % 10000;
  uint32_t decimal_part = remainder / 100;
  uint32_t round_digit = (remainder % 100) / 10;

  // 四捨五入邏輯
  if (round_digit >= 5)
  {
    decimal_part++;
    if (decimal_part >= 100)
    {
      decimal_part = 0;
      int_part++;
    }
  }

  // 加入正負號處理
  if (data < 0)
    snprintf(ItemValue, sizeof(ItemValue), "-%u.%02u", int_part, decimal_part);
  else
    snprintf(ItemValue, sizeof(ItemValue), "%u.%02u", int_part, decimal_part);
}

/*void Kgf_cm_unit_Display_xx_xx(uint32_t data)
{
  uint32_t int_part = data / 10000;              // 整數部分，例如 115（表示 115.xx）
  uint32_t remainder = data % 10000;             // 取出小數部分：xx.xx
  uint32_t decimal_part = remainder / 100;       // 小數前兩位
  uint32_t round_digit = (remainder % 100) / 10; // 小數第 3 位（用來判斷是否要進位）

  // 四捨五入邏輯
  if (round_digit >= 5)
  {
    decimal_part++;
    if (decimal_part >= 100) // 小數部分進位，例如從 99 ➜ 100
    {
      decimal_part = 0;
      int_part++; // 整數也要加 1，例如 115.99 ➜ 116.00
    }
  }

  snprintf(ItemValue, sizeof(ItemValue), "%u.%02u", int_part, decimal_part);
}
*/

/*
void Lbs_In_unit_Display_x_xx(uint32_t data)
{
  uint32_t int_part = data / 10000;              // 整數部分，例如：99
  uint32_t remainder = data % 10000;             // 取出小數相關部分，例如：9999
  uint32_t decimal_part = (remainder / 100);     // 小數前兩位，例如：99
  uint32_t round_digit = (remainder % 100) / 10; // 第三位，例如：9

  // 四捨五入
  if (round_digit >= 5)
  {
    decimal_part++;
    if (decimal_part >= 100)
    {
      decimal_part = 0;
      int_part++; // 小數進位導致整數也要加 1（例如 99.99 ➜ 100.00）
    }
  }

  snprintf(ItemValue, sizeof(ItemValue), "%u.%02u", int_part, decimal_part);
}
*/

void Lbs_In_unit_Display_x_xx(int32_t data)
{
  uint32_t abs_data = (data < 0) ? -data : data;

  uint32_t int_part = abs_data / 10000;
  uint32_t remainder = abs_data % 10000;
  uint32_t decimal_part = (remainder / 100);
  uint32_t round_digit = (remainder % 100) / 10;

  // 四捨五入
  if (round_digit >= 5)
  {
    decimal_part++;
    if (decimal_part >= 100)
    {
      decimal_part = 0;
      int_part++;
    }
  }

  // 加入正負號處理
  if (data < 0)
    snprintf(ItemValue, sizeof(ItemValue), "-%u.%02u", int_part, decimal_part);
  else
    snprintf(ItemValue, sizeof(ItemValue), "%u.%02u", int_part, decimal_part);
}
void ShowFreeMem(void);
void ShowFreeMem(void)
{
  int free = GUI_ALLOC_GetNumFreeBytes();
  printf("Free emWin memory: %d bytes\n", free);
}

//       顯示      最大值
// 0.Kgf.m	    111.0780    1110780
// 1.N.m	        11.330 	    113300
// 2.Kgf.cm	    115.56	    1155660
// 3.In.lbs	    99.99	    999900
// 4.cN.m	    1133.1	    1133100000

uint8_t Show_Tool_FW_Version(uint16_t FWVerion, char *outBuf)
{
  // 分解整數部分與小數部分
  size_t needed;
  uint16_t intPart = FWVerion / 1000;
  uint16_t fracPart = FWVerion % 1000;

  // 格式化到陣列
  needed = snprintf(NULL, 0, "V%u.%03u", intPart, fracPart);
  snprintf(outBuf, needed + 1, "V%u.%03u", intPart, fracPart);
  return (needed + 1);
}

void Show_FW_Version(uint16_t FWVerion, uint16_t SAFWVerion)
{
  int i;
  U1TX[0] = 0x3b;
  U1TX[1] = 0x2c;
  U1TX[2] = 6;
  U1TX[3] = 0xbb;

  // FWVerion (低位 → 高位)
  U1TX[4] = (uint8_t)(FWVerion & 0xFF);
  U1TX[5] = (uint8_t)((FWVerion >> 8) & 0xFF);

  // SAFWVerion (低位 → 高位)
  U1TX[6] = (uint8_t)(SAFWVerion & 0xFF);
  U1TX[7] = (uint8_t)((SAFWVerion >> 8) & 0xFF);

  // 發送 4 bytes

  for (i = 2; i < 7; i++)
    U1TX[8] += U1TX[i];
  UART_Write(UART1, &U1TX[0], 9);
  return;
}

void Show_FW_Version2(uint16_t FWVerion, uint16_t SAFWVerion)
{
  char buf[32]; // 暫存顯示字串

  // 主韌體版本分成整數與小數部分
  uint16_t intPart = FWVerion / 1000;
  uint16_t fracPart = FWVerion % 1000;

  // 先把 FW 版本轉成字串
  sprintf(buf, "V%u.%03u ", intPart, fracPart);
  GUI_DispString(buf);

  // 再顯示 SA 版本
  sprintf(buf, "SA%u", SAFWVerion);
  GUI_DispString(buf);
}