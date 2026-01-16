#include <stdint.h>				//for uint8_t、uint16_t、uint32_t

extern uint8_t Main_Page;				//主頁面編號
extern uint8_t Main_Page_Temp;			//主頁面編號比較變更用
extern uint8_t Main_Page_Chg_F;			//主頁面變更
extern uint8_t Main_Page_Item;			//主頁面內項目編號
extern uint8_t Main_Page_Item_Chg_F;		//主頁面內項目變更

extern uint8_t Step;

extern char U0RX[250];
extern uint8_t U0RX_Index;
extern uint16_t U0RX_CT;
// extern uint8_t U0RX_Process_1T;
// extern uint8_t U0RX_Pre[25];			//前後筆差異比對，最大值暫定25，Debug時，視起子傳來的最大傳輸值自行調整。
//BLE UART
// extern uint8_t U1RX[250];			//BLE，for strstr warning:  #167-D: argument of type "uint8_t *" is incompatible with parameter of type "const char *"
extern char U1RX[250];					//BLE，C-Library原型char *strstr(const char *haystack, const char *needle)。
extern uint8_t U1RX_Index;
extern uint16_t U1RX_CT;
extern uint8_t U1RX_Process_1T;
extern uint8_t U1RX_Pre[25];			//前後筆差異比對，最大值暫定25，Debug時，視起子傳來的最大傳輸值自行調整。
extern uint8_t U1TX[255];				//EEPROM通訊
extern uint8_t U1TX_Index;
// extern uint8_t U1RXData_CLR_F;

extern Timer_TypeDef BarcodeScan_Timer;

extern uint8_t CMD_Check;
extern uint8_t Page_Check;
extern uint8_t PTM_Log_EN;				//1=開啟，其他=關閉(預設)

extern uint8_t Protocol_CheckSum;
extern uint8_t CheckSum_Index;

extern uint8_t T1_50mS_F;					//1=執行發送CMD函式

extern uint8_t	Match_F;
// extern uint8_t	Change_line_CT;
extern uint8_t Action_CT;					//啟動訊號點放輔助參考(PTM每次點放必+1，轉向切中段亦同+1)
#ifdef Timing_Debug_J	//測試用，顯示時序
extern uint16_t Cnt16b_10mS;
extern uint8_t Cnt8b_1Min;
extern uint8_t Cnt8b_1Hour;

extern uint32_t BLE_TXRX_Time1;			//量測BLE MasterTX後實際SlaveRX收到時間
extern uint32_t BLE_TXRX_Time2;
#endif


extern uint8_t Itme_Point;		//>128設定中，<128選項，0=全白。
extern uint8_t Itme_Point_Temp;	//EDIT專用，紀錄前次變更，避免大面積清除閃動

extern Pg_Home_TypeDef Pg_Home;
extern Pg_Tool_Mode_0_TypeDef Pg_Tool_Mode_0;
//extern Page11_TypeDef Page11;
extern Pg_Call_Job_0_TypeDef Pg_Call_Job_0;
//extern Page21_TypeDef Page21;
extern Pg_JS_0_Job_TypeDef Pg_JS_0_Job;
extern Pg_JS_1_JobSEQ_TypeDef Pg_JS_1_JobSEQ;
extern Pg_JS_2_Step2_1_TypeDef Pg_JS_2_Step2_1;
extern Pg_JS_3_Step2_2_TypeDef Pg_JS_3_Step2_2;
//extern Page36_TypeDef Page36;
extern Pg_Net_Info_0_TypeDef Pg_Net_Info_0;
extern Pg_Net_AP_Info_0_TypeDef Pg_Net_AP_Info_0;
extern Pg_Tool_Info_0_TypeDef Pg_Tool_Info_0;
extern Pg_Language_0_TypeDef Pg_Language_0;
extern Page1_TypeDef Page1;
extern Page2_TypeDef Page2;
extern Page3_TypeDef Page3;
extern Page4_TypeDef Page4;
extern Page5_TypeDef Page5;
extern Page6_TypeDef Page6;
extern Page7_TypeDef Page7;
extern Page8_TypeDef Page8;
extern uint8_t for_i8b;
extern uint16_t for_i16b;

extern uint8_t Batt;			//test
extern uint8_t PROGBAR_Color_1T;		//for API瑕疵變更顏色需先清除設定值為0，否則切換顏色會固定在20%進度點以下，保留原有色系。2022/02/09

//for PTT_ISR.c
extern volatile GUI_TIMER_TIME OS_TimeMS;
extern int g_enable_Touch;
extern int Key;

extern Fucn_WM_HWIN hItems;				//預存每個Page物件
extern WM_HWIN hWin_MPage;				//主頁面

extern uint8_t Data_2D2[8];				//設定值00.00X專用
extern char ItemValue[50];

extern char s_Buf[20];
extern WM_KEY_INFO My_KEY;

extern int X0, Y0;						//Y0=標題列Y高，修正取得物件位置為絕對值(從LCD邊算起為Y=0)，但物件編輯位置為相對值(從標題列算起為Y=0)

extern FRAMEWIN_SKINFLEX_PROPS FRAMEWIN_MySKIN_ACT0;	//FRAMEWIN外框色調 
extern FRAMEWIN_SKINFLEX_PROPS FRAMEWIN_MySKIN_ACT1;
extern PROGBAR_SKINFLEX_PROPS PROGBAR_MySKIN_ACT0;		//PROGBAR外框色調 
extern PROGBAR_SKINFLEX_PROPS PROGBAR_MySKIN_ACT1; 

extern uint8_t Temp8b; 
extern uint16_t Temp16b; 
extern uint32_t Temp32b;

// extern uint16_t pD_TP[1000]; 

// void EDIT_Set_Bk_Text_Color(WM_HWIN hDialog, int Id, int MsgId);
void EDIT_Set_Bk_Text_Color(WM_HWIN hItem_Id, int MsgId);

void FRAMEWIN_Change_Check(void);
void FRAMEWIN_Display(uint8_t Item_Num);

void Page_Select(U8 M_Page, U8 P_Item);
void Page_Select2(U8 M_Page, U8 P_Item);
// void Page_Select3(U8 M_Page, U8 P_Item);

void ItemValue_Clear(void);
void ItemValue_Left_Alignment(void);	//左對齊處理
void Number32b_to_BCD7b_00D000X(char *LCM_Data_Addr, uint32_t Data);
void Number16b_to_BCD6b_00D00X(char *LCM_Data_Addr, uint16_t Data);
void Number8b_to_BCD2b(char *LCM_Data_Addr, uint8_t Data, uint8_t Zero_Padding);		//Zero_Padding=補0位數=1~2(>2即全補，個位數強制補0)
void Number16b_to_BCD3b(char *LCM_Data_Addr, uint16_t Data, uint8_t Zero_Padding);		//Zero_Padding=補0位數=1~3(>3即全補，個位數強制補0)
void Number16b_to_BCD4b(char *LCM_Data_Addr, uint16_t Data, uint8_t Zero_Padding);		//Zero_Padding=補0位數=1~4(>4即全補，個位數強制補0)
void Number16b_to_BCD5b(char *LCM_Data_Addr, uint16_t Data, uint8_t Zero_Padding);		//Zero_Padding=補0位數=1~4(>4即全補，個位數強制補0)
void Number32b_to_BCD10b(char *LCM_Data_Addr, uint32_t Data, uint8_t Zero_Padding);	//Zero_Padding=補0位數=1~8(>8即全補)
void Number32b_to_BCD5b(char *LCM_Data_Addr, uint32_t Data, uint8_t Zero_Padding);	//Zero_Padding=補0位數=1~5(>5即全補，個位數強制補0)
void Number8b_to_HexBCD2b(uint8_t *LCM_Data_Addr, uint8_t Data);
