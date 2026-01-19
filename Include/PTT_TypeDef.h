

#define Delay_NmS(x)	CLK_SysTickDelay((x*1000))
#define Delay_NuS(x)	CLK_SysTickDelay(x)			//include clk.h

#define ON  1
#define OFF 0

//GPIO
#define   Set_High                        1
#define   Set_Low                         0

// #define UserPressBtn        ((P25 )?(FALSE):(TRUE)) //?��Start LED�O �?P�O�O�_���O�Q���U
//�z---------------------------------------------
#define		LCD_Version		1002
#define		SA_Version		0
//�|---------------------------------------------

// #define	APPLINK_ShowA1S1		//2025/06/12 �s�u�����A1+S1
// #define	LCD_Pg00_Edit0_ShowADC	//2025/06/12 LCD������1�?���??�ADC

//��W��gEEPROM�A�L�?�s��EEPROM�A���B���?��c��RAM������D�C2020/04/01
//RD_EE_Program()�?�s��EEPROM�A��uint16_t Password;�b�e���A���L����S�t�C2020/05/06

#include "WM.h"
typedef struct
{
	WM_HWIN hWin;
	WM_HWIN TEXT[30];
	WM_HWIN TEXT_Torque_Unit[4];	
	WM_HWIN TEXT_Angle_Unit;
	WM_HWIN EDIT[10];
	WM_HWIN CHECKBOX[1];
	WM_HWIN PROGBAR[1];
	WM_HWIN IMAGE[1];
	WM_HWIN BUTTON[3];
}Fucn_WM_HWIN;

typedef struct
{
	uint8_t	L;
	uint8_t	H;
} HL_16b_TypeDef;

typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31
{
	uint8_t Title;
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;
	uint8_t APPLink_color;
	uint8_t Mute;
	uint8_t Battery;
	uint8_t Job_ID;
	uint8_t Seq_Current;
	uint8_t Seq_Sum;
	uint8_t Step_Current;
	uint8_t Step_Sum;
	uint8_t Counter_Current;
	uint8_t Counter_Sum;
	uint8_t Unit;
	uint32_t u32Tourqe;
  uint32_t u32TarTrq;
	int32_t i32Angle;
	uint16_t u16Speed;
	uint8_t u16ErrCodeEng;
	uint8_t u16ErrCodeNum;
	uint8_t Statuecode[20];
	uint32_t TitleASCII[20];
	#ifdef	LCD_Pg00_Edit0_ShowADC	//2025/06/12 LCD???1??????ADC
	uint8_t TitleChar[35];
	#endif
} Pg_Home_TypeDef;

typedef __PACKED_STRUCT		//KEIL C Arm??__packed?????RAM?????2020/03/31	
{
	uint8_t Title;
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;
	uint8_t StandAlone;
	uint8_t Controlled;
	uint8_t Default;
	uint8_t Tool;
	uint8_t WIFI;

} Pg_Tool_Mode_0_TypeDef;


typedef __PACKED_STRUCT		//KEIL C Arm??__packed?????RAM?????2020/03/31		
{
	uint8_t Title;
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;

	uint8_t Item_Job_ID_P;
	uint8_t Choice_Job_ID_P;

} Pg_Call_Job_0_TypeDef;

typedef struct		
{
	uint8_t Title;
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;
	
	uint8_t Job_Name[12];
	uint8_t u8Job_OK_En;
	uint8_t u8Job_OK_Stop_En;

} Pg_JS_0_Job_TypeDef;

typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31		
{
	uint8_t Title_Job_ID;
	uint8_t Title_Seq_ID;			//Enter�i�J�s���w�]SEQ-1
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;

	uint8_t u8Seq_Name[12];			//�i��?^��j�p�g�B�?r�P����A�u�?W��
	uint8_t u8Tool_Name[20];		//�i��?^��j�p�g�B�?r�P����A�?H�i�??s��
	uint8_t u8Tighten_Cnt;			//1~99�A�]�w����
	uint8_t u8NG_Stop_En;			//0=OFF�A1 ~ 9=NG����ANG ����ANG����??��
	uint8_t u8SEQ_OK_En;			//0=OFF�A1=ON�COFF�?Au8SEQ_OK_Stop_En�j��OFF�A�u�?����H���A�p�PJob�CSEQ�������A�AOFF�N�u��OK�T���P�u�?A��X�����_�l�u��0.1S�A��������??h���W�B��C
	uint8_t u8SEQ_OK_Stop_En;		//0=OFF�A1=ON(u8SEQ_OK_En�nON)�A�u�?����T�{�A�p�PJob�CSEQ�������A�T�{�CSEQ_OK_En���}�~��??C����AS��Confirm�?��A�O���POK�u�O�W��P��?t���C
	uint8_t	FRAMEWIN_SetText[18];
} Pg_JS_1_JobSEQ_TypeDef;

typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31
{
	uint8_t  Title_Job_ID;
	uint8_t  Title_Seq_ID;			//Enter�i�J�s���w�]SEQ-1
	uint8_t  Title_Step_ID;			//Enter�i�J�s���w�]Step-1

	uint8_t  Button1;
	uint8_t  Button2;
	uint8_t  Button3;
// 	u8  u8Trq_Unit;					//0=kgf-m�A1=N.m�A2=kgf.cm�A3=In.lbs�A4=cN.m�A��O���
	uint8_t  Target_Title;			//0=Target Ang.�A1=Target Tor.
	uint8_t  Target_unit;			//0.Kgf.m�A1.N.m�A2.Kgf.cm�A3.In.lbs�A4.cN.m�A9.Degree
	uint8_t  Offset_unit;			//0.Kgf.m�A1.N.m�A2.Kgf.cm�A3.In.lbs�A4.cN.m

	uint8_t  Step_ID;				//Enter�i�J�s���w�]Step-1

	uint32_t u32Target_Trq;			//�??�O�A1bit=0.001Nm�A�?j�?��B�w��O�C
	uint8_t  u8Step_Dir;			//0=CW�A1=CCW�A�_�l�B���V
	uint16_t u16Step_RPM;			//�?_�l�?�A��t
	int32_t  s32Trq_Offset;			//�?_�l�?�A1bit=0.001Nm�A��O���v�?��[�k�A�n��n���t�?C�����v�?A��?����??�O�?C�P�B���v��O����(�W�U���Bthreshold�BDS)
	uint16_t u16Delay_Time;			//0.00~10.00���A1bit=0.01���A��Step�����?����?��A�j��0�?U��Step��V�??N�O�?�

} Pg_JS_2_Step2_1_TypeDef;

typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31		
{
	uint8_t Title_Job_ID;
	uint8_t Title_Seq_ID;
	uint8_t Title_Step_ID;

	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;
    uint8_t Target_unit;
	uint32_t u32Trq_H;				//����??A�p��W���O110%�A1bit=0.001Nm�A��O�W��(����?�)�A0=OFF
	uint32_t u32Trq_L;				//����??A1bit=0.001Nm�A��O�U��(����?�)�A0=OFF
	uint16_t u16Ang_H;				//����??A1~30600�A1bit=1�?A���?W��(����?�)�A0=OFF
	uint16_t u16Ang_L;				//����??A0~30599�A1bit=1�?A���?U��(����?�)�A0=OFF

	uint8_t  u8ThrSh_Mode;			//0=Threshold + �?�=OFF�A1=Threshold Ang. + ��??���A2=Threshold Tor. + ����??��
	uint32_t u32ThrSh_TrqAng;		//�?_�l�?�A1bit=0.001Nm�A���e�I��O�C0~30600�A1bit=1�?A���e�I����
	uint8_t  u8DS_Mode;				//0=Downshift + �?�=OFF + Speed����?A1=Downshift Ang. + ��??���A2=Downshift Tor. + ����??��
	uint32_t u32DS_TrqAng;			//�?_�l�?�A1bit=0.001Nm�A���t�I��O�C0~30600�A1bit=1�?A���t�I����
	uint16_t u16DS_Rpm;				//�?_�l�?�A���t�I��t

} Pg_JS_3_Step2_2_TypeDef;

typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31		
{
	uint8_t Title;
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;

	uint8_t Mode;
	uint8_t STA_IP[4];
	uint8_t STA_Gateway[4];
	uint8_t STA_Subnet_Mask[4];
	uint8_t MAC[6];
	uint8_t STA_TCP_Server_IP[4];
	uint16_t STA_Port;

} Pg_Net_Info_0_TypeDef;

typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31
{
	uint8_t Title;
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;

	uint8_t Router_SSID[32];		//WIFI.Router_SSID

} Pg_Net_AP_Info_0_TypeDef;


typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31		
{
	uint8_t Title;
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;

	uint8_t  FW1;
	uint8_t  FW2;
	uint8_t  u8Tool_SN[20];			//�u��?��A�~�O�i�s��u��?�
	uint8_t  u8Type_Name[20];		//�i��?^��j�p�g�B�?r�P����A�~�O�i�s�?���W��
	int8_t  PCB_T;
	int8_t  Batt_Temp;
	uint32_t u32Hi_Tourqe;


} Pg_Tool_Info_0_TypeDef;


typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31		
{
	uint8_t Title;
	uint8_t Button1;
	uint8_t Button2;
	uint8_t Button3;
	uint8_t EN_Item_P;
	uint8_t TC_Item_P;
	uint8_t SC_Item_P;

} Pg_Language_0_TypeDef;





typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C
{
	uint8_t	Text_Status2;
	uint8_t	Text_Status3;

	uint8_t	Text_Job;
	uint8_t	Text_ProgCnt;
// 	uint8_t	Text_Job_OK_Cfm;		//Status3.0
// 	uint8_t	Text_NG_Confirm;		//Status3.1

	uint8_t	Text_Program;
	uint8_t	Text_Step_Cnt;
	uint8_t	Text_Count;
// 	uint8_t	Text_Prog_OK_Cfm;		//Status3.2

	uint8_t	Text_Step;
// 	uint8_t	Text_Tourqe_L;
// 	uint8_t	Text_Tourqe_H;
// 	uint8_t	Text_Angle_L;
// 	uint8_t	Text_Angle_H;
// 	uint8_t	Text_Speed_L;
// 	uint8_t	Text_Speed_H;
// 	uint8_t	Text_Cycle_L;
// 	uint8_t	Text_Cycle_H;
	uint16_t Text_Tourqe;
	uint16_t Text_Angle;
	uint16_t Text_Speed;
	uint16_t Text_Cycle;

// 	uint8_t	Text_Reverse;			//Status3.3

} Page1_TypeDef;

typedef struct
{
	uint8_t	Text_Status2;
	uint8_t	Text_Status3;

	uint8_t	Text_Job;
	uint8_t	Text_JobCnt;
// 	uint8_t	Text_Job_OK_Cfm;		//Status3.0
// 	uint8_t	Text_NG_Confirm;		//Status3.1
// 	uint8_t	Text_Reverse;			//Status3.3

} Page2_TypeDef;

typedef struct
{
	uint8_t	Text_Status2;
	uint8_t	Text_Status3;

	uint8_t	Text_Program;
	uint8_t	Text_Step_Cnt;
// 	uint8_t	Text_Prog_OK_Cfm;		//Status3.2

} Page3_TypeDef;

typedef __PACKED_STRUCT		//Step�]�w
{
	uint8_t	Text_Status2;
	uint8_t	Text_Status3;

	uint8_t	Text_Step;
	uint8_t	Text_Direction;			//���OStatus3.3
// 	uint8_t	Text_Speed_L;
// 	uint8_t	Text_Speed_H;
// 	uint8_t	Text_Tourqe_L;
// 	uint8_t	Text_Tourqe_H;
// 	uint8_t	Text_Hi_Tourqe_L;
// 	uint8_t	Text_Hi_Tourqe_H;
// 	uint8_t	Text_Lo_Tourqe_L;
// 	uint8_t	Text_Lo_Tourqe_H;
	uint16_t Text_Speed;
	uint16_t Text_Tourqe;
	uint16_t Text_Hi_Tourqe;
	uint16_t Text_Lo_Tourqe;

// 	uint8_t	Text_Angle_L;
// 	uint8_t	Text_Angle_H;
// 	uint8_t	Text_Hi_Angle_L;
// 	uint8_t	Text_Hi_Angle_H;
// 	uint8_t	Text_Lo_Angle_L;
// 	uint8_t	Text_Lo_Angle_H;
	uint16_t Text_Angle;
	uint16_t Text_Hi_Angle;
	uint16_t Text_Lo_Angle;

// 	uint8_t	Text_Stop_Mode;			//Status3.4
// 	uint8_t	Text_Delay_L;
// 	uint8_t	Text_Delay_H;
// 	uint8_t	Text_Stop_Comp_L;
// 	uint8_t	Text_Stop_Comp_H;
	uint16_t Text_Delay;
	uint16_t Text_Stop_Comp;
	uint8_t	Text_Acceleration;

} Page4_TypeDef;

typedef __PACKED_STRUCT		//�???�
{
	uint8_t	Text_Status2;
	//�??e�??]�w
	uint8_t	Text_Learn_Mode;
	uint8_t	Text_Direction;			//���OStatus3.3
// 	uint8_t	Text_Tourqe_L;
// 	uint8_t	Text_Tourqe_H;
// 	uint8_t	Text_Speed_L;
// 	uint8_t	Text_Speed_H;
	uint16_t Text_Tourqe;
	uint16_t Text_Speed;

	//�??�?�
// 	uint8_t	Text_Tourqe2_L;
// 	uint8_t	Text_Tourqe2_H;
// 	uint8_t	Text_Angle_L;
// 	uint8_t	Text_Angle_H;
	uint16_t Text_Tourqe2;
	uint16_t Text_Angle;

	uint8_t	Text_Stop_Mode;			//���OStatus3.4
// 	uint8_t	Text_Delay_L;
// 	uint8_t	Text_Delay_H;
// 	uint8_t	Text_Stop_Comp_L;
// 	uint8_t	Text_Stop_Comp_H;
	uint16_t Text_Delay;
	uint16_t Text_Stop_Comp;

} Page5_TypeDef;
       
typedef __PACKED_STRUCT		//��L�]�w
{
	uint8_t	Text_Status2;
	uint8_t	Text_Status3;

// 	uint8_t	Text_Running_Time_L;
// 	uint8_t	Text_Running_Time_H;
// 	uint8_t	Text_Sleep_Time_L;
// 	uint8_t	Text_Sleep_Time_H;
	uint16_t Text_Running_Time;
	uint16_t Text_Sleep_Time;
// 	uint8_t	Text_BLE_OnOff;			//Status3.5
// 	uint8_t	Edit_PW_1000_L;
// 	uint8_t	Edit_PW_1000_H;
	uint16_t Edit_PW_1000;

	uint8_t	Text_Language;
  
} Page6_TypeDef;
       
typedef __PACKED_STRUCT		//�u�{�]�w
{
	uint8_t	Text_Status2;

// 	uint8_t	Text_Speed_Range_L;
// 	uint8_t	Text_Speed_Range_H;
	uint16_t Text_Speed_Range;

	uint8_t	Text_Motor_H_Temp;
	uint8_t	Text_Motor_L_Temp;
	uint8_t	Text_PCB_H_Temp;
	uint8_t	Text_PCB_L_Temp;
// 	uint8_t	Text_Maintainount_L;
// 	uint8_t	Text_Maintainount_H;
// 	uint8_t	Text_Over_Current_L;
// 	uint8_t	Text_Over_Current_H;
// 	uint8_t	Text_Over_Current_Time_L;
// 	uint8_t	Text_Over_Current_Time_H;
// 	uint8_t	Text_Stall_Protect_L;
// 	uint8_t	Text_Stall_Protect_H;
// 	uint8_t	Text_Stall_Protect_Time_L;
// 	uint8_t	Text_Stall_Protect_Time_H;
// 	uint8_t	Text_Over_Tourqe_L;
// 	uint8_t	Text_Over_Tourqe_H;
	uint16_t Text_Maintainount;
	uint16_t Text_Over_Current;
	uint16_t Text_Over_Current_Time;
	uint16_t Text_Stall_Protect;
	uint16_t Text_Stall_Protect_Time;
	uint16_t Text_Over_Tourqe;
    
} Page7_TypeDef;
       
typedef __PACKED_STRUCT		//�?��]�w
{
	uint8_t	Text_Status2;

	uint16_t Text_Lo_Speed_AD;
	uint16_t Text_Lo_Speed_Tourqe;
	uint16_t Text_Hi_Speed_AD;
	uint16_t Text_Hi_Speed_Tourqe;

	uint16_t Text_HT_Lo_Speed_AD;
	uint16_t Text_HT_Lo_Speed_Tourqe;
	uint16_t Text_HT_Hi_Speed_AD;
	uint16_t Text_HT_Hi_Speed_Tourqe;
	uint16_t Text_Gear_Ratio;

// 	uint8_t	Text_Lo_Speed_AD_L;
// 	uint8_t	Text_Lo_Speed_AD_H;
// 	uint8_t	Text_Lo_Speed_Tourqe_L;
// 	uint8_t	Text_Lo_Speed_Tourqe_H;
// 	uint8_t	Text_Hi_Speed_AD_L;
// 	uint8_t	Text_Hi_Speed_AD_H;
// 	uint8_t	Text_Hi_Speed_Tourqe_L;
// 	uint8_t	Text_Hi_Speed_Tourqe_H;
// 
// 	uint8_t	Text_HT_Lo_Speed_AD_L;
// 	uint8_t	Text_HT_Lo_Speed_AD_H;
// 	uint8_t	Text_HT_Lo_Speed_Tourqe_L;
// 	uint8_t	Text_HT_Lo_Speed_Tourqe_H;
// 	uint8_t	Text_HT_Hi_Speed_AD_L;
// 	uint8_t	Text_HT_Hi_Speed_AD_H;
// 	uint8_t	Text_HT_Hi_Speed_Tourqe_L;
// 	uint8_t	Text_HT_Hi_Speed_Tourqe_H;
// 	uint8_t	Text_Gear_Ratio_L;
// 	uint8_t	Text_Gear_Ratio_H;

} Page8_TypeDef;


//��---------------------------------------------���?�_�l�?�(EEPROM) �P �q�T��w�_�l�?��union�?
//���?�]�w��Setting.XX�A�{���P�_�?�S_CMD2Setting.EEPROM.XX�C(���J�??|�@�?A�pOKALL_Stop�BNG_Stop�BRev_Thread�A�?O�??|���?O?��������)
typedef struct
{
	//�_�l�??����A���?��i�?C15+1Byte
	uint8_t  Program;			//�C��8�?�+4�?O�d�\��?�(�@12+1(At)Byte)
	uint8_t  OKALL_Alarm;		//EEPROM�_�l��}�C�D�_�l�???�A����Program��C2020/05/06 �?�?i����
	uint8_t  Batch_Count;		//����
	uint8_t  Force;				//�����O��
	uint8_t  Impacts;			//��������(���)
	uint8_t  Limit;				//�B����(�]�w��?��i�J�����PNG)
	uint8_t  Ignore_Thread;		//�������(�]�w��?��i�J�����P����NG)

	//3�?���?�(�?e�O�d���??jProgram�A���h�q�??�� 2020/06/01)�ARev_Thread���j 2020/12/04
	uint8_t  OKALL_Stop;		//0=OFF�A1=ON
	uint8_t  NG_Stop;
	uint8_t  Rev_Thread;		//����/�f�� ����A�Y�`�A����C

	//4�?O�d�\��?�
	uint8_t  Pt;				//������(�w��Pre-fastening)
	uint8_t  rr;				//��������(rr)�A�A�??���(�_�l������Y�i�A�����?�`�A����\��)
	uint8_t  rt; 				//������H����A�??�����(rt)�A����?`�������?�����A�??���rt���
	uint8_t  rL;

	uint8_t  Status;			//��wByte 9�AAdd Protocol�A��l���?��i��
	uint8_t  Status2;			//��wByte14�AAdd Protocol�A��l���?��i��
} CMD2_EEPROM_TypeDef;			//S_CMD2Setting.EEPROM.OKALL_Alarm
typedef struct
{	//�����Setting_Para_Transfer_TypeDef��16Byte�w�q�A�]�@��RAM
	//CMD2 CCB2WSCBSN
	uint8_t  Program;			//�s�?]�w (0~5) 0:����
	uint8_t  Reserve_AT;		//�_�l�q�T�L�w�q(�_�l�T�w�N�O�?@�q�?�)�A���?���n�~�i�?C
	uint8_t  Screw_Number;		//�����]�w���� (0~100) 0:���� 100:����
	uint8_t  Motor_Speed;		//�O�?]�w (0~6)  0:����
	uint8_t  Hit_Number;		//�������?]�w(0~100) 0:���� 100:����
	uint8_t  Floating;			//�B��]�w (0~100) 0:���� 100:����
	uint8_t  Ignore;			//�e�?�� ��?F��e����������

	//3�?���?�(�?e�O�d���??jProgram�A���h�q�??�� 2020/06/01)
	uint8_t  Reserve_AS;		//�_�l�q�TAS�W���bStatus Bit�C
	uint8_t  Reserve_NS;		//�_�l�q�TNS�bStatus
	uint8_t  Reserve_Rev_Thread;//0����/1�f�� ����A�Y�`�A����A�q�???L�??A�W���bStatus Bit�C

	uint8_t  Limit_Cycle;		//������ 0~255 0�����A�YPt
	uint8_t  After_Reverce;		//������� 0~255 0�����A�Yrt
	uint8_t  Before_Reverce;	//�e������ 0~255 0�����A�Yrr
	uint8_t  Reserve_rL;		//����?���������}�� 1�}��(�P��?Y����) 0����)�A�W���bStatus Bit�C

	uint8_t  Status;			//��wByte 9�AAdd Protocol�A��l���?��i��
	uint8_t  Status2;			//��wByte14�AAdd Protocol�A��l���?��i��
} CMD2_Protocol_TypeDef;		//S_CMD2Setting.Protocol.Reserve_AT
typedef union	//EEPROM�W�?P�_�l��w�W�?�?A�]�w�?@��RAM
{
	CMD2_EEPROM_TypeDef		EEPROM;
	CMD2_Protocol_TypeDef	Protocol;
}ScrewSetting_TypeDef;		//S_CMD2Setting.EEPROM.�AS_CMD2Setting.Protocol.
//��---------------------------------------------

typedef __PACKED_STRUCT	//S_CMD1States.		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31
{
	//CMD1 CCB2WSCBSN
	uint8_t  Run_Status;	//�PCMD4
	uint8_t  Action_Counter;
	uint16_t Running_Cycle;
	uint16_t Temperature;
	uint8_t  Hit_Counter;
	uint8_t  Stop_Reason;
	uint8_t  SC_Value;
	uint16_t Voltage;
	uint16_t Current;
	uint16_t Action_Time;
	uint8_t  Run_Status2;	//�PCMD4
} S_CMD1_States_TypeDef;	//Screw

typedef __PACKED_STRUCT	//S_CMD2States.		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31
{
	//CMD2 CCB2WSCBSN
	uint8_t  Screw_Number;		//�����]�w���� (0~100) 0:���� 100:����
	uint8_t  Motor_Speed;		//�O�?]�w (0~6)  0:����
	uint8_t  Hit_Number;		//�������?]�w(0~100) 0:���� 100:����
	uint8_t  Floating;			//�B��]�w (0~100) 0:���� 100:����
	uint8_t  Program;			//�s�?]�w (0~5) 0:����
	uint8_t  Status;			//���A�]�w
	uint8_t  Ignore;			//�e�?�� ��?F��e����������
	uint8_t  Limit_Cycle;		//������ 0~255 0�����A�YPt
	uint8_t  Before_Reverce;	//�e������ 0~255 0�����A�Yrr
	uint8_t  After_Reverce;		//������� 0~255 0�����A�Yrt
	uint8_t  Status2;			//���A�]�w2�C2020/05/26
	uint8_t  Group_Arrangement;	//�_�l����`���?O�]�w(B.0=P01�AB.1=P01�A�K�AB.4=P05)�A�]1�~����C
} S_CMD2_States_TypeDef;	//Screw

typedef __PACKED_STRUCT	//S_CMD3States.		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31
{
	//CMD3 CCB2WSCBSN
	uint8_t  Model;
	uint16_t MCB_Version;
	uint16_t CCB_Version;
} S_CMD3_States_TypeDef;	//Screw

typedef struct	//S_CMD4States.
{
	//CMD4 CCB2WSCBSN
	uint8_t Ctrl1_Set;		//CMD4�]�w��(�D�n���O)�A�@��typedef

	uint8_t Ctrl1_Status;	//CMD4�]�w�������A�^��
	uint8_t Run_Status;		//�PCMD1
	uint8_t Run_Status2;	//�PCMD1	

} S_CMD4_States_TypeDef;	//Screw


enum	//�����s�� for Main_Page�C�s��CMD205�?�N�X�A�����?��d�N 2020/10/06
{
//�u---------------------�s�u����
	NormalPg_Connecting = 1,
	NormalPg_Connected,

	NormalPg_Input_password,
//�u---------------------�D�]�w����-���?�P�_�l�??��
	SetPg_Ctrl_Screw_Sellect,	//004(CMD205)
//�u---------------------���?�??���
	CtrlPg_Init = 10,		//��?��d�N���?e��������(CtrlPg_Init < ScrewPg_Init���i��)
	CtrlPg_Query_Tool,		//011(CMD205)�A����1�}�l��K�???����[1]~[1X]
	CtrlPg_Tool_Pair,
	CtrlPg_SEQ_Numbers,
	CtrlPg_Job_Sequence,
	CtrlPg_Gate_Mode,
	CtrlPg_OKALL_Signal,	//OKALL�T�� (0=Each SEQ�A1=All SEQ Done) 2020/12/25
	CtrlPg_Barcode,
	CtrlPg_Ext_Input,
	CtrlPg_Ext_Output,
	CtrlPg_Device_ID,
	CtrlPg_Ext_SEQ_Ctrl,
	CtrlPg_Operator,
	CtrlPg_Password,
	CtrlPg_Default_Value,	//024(CMD205)�C����CtrlPg_Password�A�?�X�t�?t�K�X�C2020/05/21�C�???�2020/11/17
	CtrlPg_Data_Port,		//����Default����A���bDefault�d�??A�???�2020/11/17
	CtrlPg_System_Date,		//026(CMD205)�C�P�BDAS����?��?�?�C�?�G�~���(8Char)�A�?���(6Char�A24�p�?�)�A�@��(3Char)
	CtrlPg_System_Time,
	CtrlPg_Product_No,
	CtrlPg_Screw_BT_MAC,
	CtrlPg_Screw_FW_Ver,	//030(CMD205)
	CtrlPg_Ctrl_BT_MAC,
	CtrlPg_Ctrl_FW_Ver,		//032(CMD205)
	CtrlPg_SDcard_Capacity,	//033(CMD205) 2020/10/14
	CtrlPg_USR_K3_IP,		//034
	CtrlPg_MaxPage,
//�u---------------------�_�l�??���
	ScrewPg_Init = 50,		//��?��d�N���?e��������(CtrlPg_Init < ScrewPg_Init���i��)
	ScrewPg_Program,		//����1�}�l��K�???����[1]~[1X]
	ScrewPg_OKALL_Alarm,
	ScrewPg_Batch_Count,
	ScrewPg_Force,
	ScrewPg_Impacts,
	ScrewPg_Limit,
	ScrewPg_Ignore_Thread,

	ScrewPg_Pt,				//Pt�w��A�}�?\�� 2021/01/25�ARev_Thread�����
// 	ScrewPg_rt_By_C,
// 	ScrewPg_rr_By_C,
// 	ScrewPg_rL,

	ScrewPg_Rev_Thread,		//��Program�?� 2020/06/09
	ScrewPg_OKALL_Stop,

	ScrewPg_NG_Stop,		//�q�???L�?�
// 	ScrewPg_Rev_Thread,		//�q�???L�?�


	ScrewPg_Sync_Program,	//062(CMD) 2021/03/22
	ScrewPg_Sel_Program,
	ScrewPg_Copy_Program,
	ScrewPg_MaxPage,
//�u---------------------�T������
	WindowPg_MsgBox = 100,


};


enum	//#for BLE_STEP
{
//���?��i���N�?�
	BLE_STEP_Init,			//�p�?M��
	BLE_Power_OFF_to_ON,	//�_�q�A�W�q
	BLE_Wait_RX_OK,			//����BLE�?�RX�}Pull-Hi�A�~�}�l�eCMD
	BLE_Read_Mode,			//?��BLE�??@�~�?�
	BLE_Check_Master_Mode,	//�T�wBLE�??�Master�?�
	BLE_SET_BAUD8,			//�w�]119200���?AMCU��9600���?�^119200
	BLE_Check_BAUD8,		//�T�wBLE�??�119200
	BLE_Get_Module_MAC,		//?��BLE�?�MAC�X
	BLE_Connecting,			//�s�u����wSlave�?m
	BLE_Connected,			//�w�s�u
//�u-------------------------�j�M�A���?bBLE_Connected���i�?�
    BLE_Start_Query,		//�j�MBLE
    BLE_Stop_Query,			//����j�M

    BLE_Power_OFF,			//12
};

typedef struct
{
	uint8_t Pair_MAC[20][12];		//Tool_Pair�A�����_�l1~19�s���G[0][0~11]���?�
	uint8_t Query_MAC[21][12];		//Query�A�����j�M�`��1~19�A[0]�?s�_�l��lMAC�]�w�A�?�1�?T�w��0�M���?A[20]���j�M��19�w�d�M���?�

}BLE_TypeDef;		//BLE.Pair_MAC�ABLE.Query_MAC


// typedef struct
//     BC                                       0x2000080c   Data         220  ptmctrl_main.o(.bss)�CD:\Nuvoton\PTMController\Listings\PTMCtrl.map
typedef __PACKED_STRUCT		//KEIL C Arm�?�__packed�������c��RAM������D�C2020/03/31
//     BC                                       0x2000080c   Data         210  ptmctrl_main.o(.bss)�CD:\Nuvoton\PTMController\Listings\PTMCtrl.map
{
	uint16_t BC_CMD;
	uint8_t BC_T;			//���B����������A�|�Q�s?��uint16_t(H-Byte���??��p)
	uint16_t BC_Mask;		//Barcode�B�n�X
	uint8_t Code[16];

}Barcode_TypeDef;		//BC.BC_CMD�ABC.BC_T�A���cstruct�?i���}�CBC[10]


enum	//#for Function_Page
{
	PowerOn_Period,
	Normal,					//T00 Connecting..���q
	Setting_Mode,
	Setting_View,

// 	Auto_Learning_Mode,
// 	My_ExtIO_Define_Mode,

// 	Ut_Timeout,
// 	Ut_Period,

	Error_Period,

// 	Display_OFF,		//#Power ON Default
// 	Reset_Default,

// 	Err_Return_Normal,	//#�?��_�l�T����?� 2019/04/26
};

enum 	//�W�q��� for PowerOn_Sequence PowerOn_Period_Sub
{
	PowerOn_Init,

	PowerOn_SpVer1,		//Add 2019/05/31
	PowerOn_SpVer2,
	PowerOn_SpVerdF,	//for My_ExtIO_Define ���d0~d5

	PowerOn_Ver1,
	PowerOn_Ver2,
	PowerOn_msg11,
	PowerOn_msg22,
	PowerOn_msg33,
	PowerOn_msg44,
	PowerOn_msg55,
	PowerOn_msg66,
	PowerOn_msgHi,
};

// enum	//#for ErrorCode
// {
// 	Err_Normal,
// 	Err_RunNG,			//�B��NG
// 	Err_BrakeNG,		//�?�NG
// 	Err_BrakeNG_AMS,	//�?�NG�A�u�W�?�����{��
// 
// };

enum 	//���~��� for Error_Period_Sub
{
	Err_None		= 0,
	Err_E3_Volt		= 3,
	Err_E4_Temp,
	Err_E5_Block,

	Err_E7_Dir		= 7,
	Err_E8_PreBrake,
	Err_E9_EEPROM,
	Err_PC_VoltLock,		//�W���q������
	Err_PC_ScrewPlug,		//���_�l���J
	Err_PC_VoltError,		//�q�����~
	Err_Back_Normal,		//�����^�?��?dSW9���A
};

enum 	//Gate Once�PTwice�?� for Gate_Status
{
	GateON = 1,				//1=ON(�u��Low)�A0=OFF(�_��High)
	GateOFF = 0,			//1=ON(�u��Low)�A0=OFF(�_��High)
//�u---------------------------------------------
//Once(SW4=OFF)���?�(Setting.SA)�~���?G
//Setting.SA=Hi Active�AGate=ON(�u��Low)���|�s�AGate=OFF(�_��High)�|�s�C
//Setting.SA=Lo Active�AGate=ON(�u��Low)�|�s�AGate=OFF(�_��High)���|�s�C
	GateOFF_Twice_Normal = 0,			//Once�PTwice��Normal���O0�A��l�W��
	GateON_Once_Normal = 0,
	GateOFF_ErrON_BzON,
	GateON_ErrON_BzOFF,

	GateON_C1C4,
	GateOFF_WaitONtoComplete_InC1C4,	//���?�ON
	GateON_Completed_InC1C4,			//Gate��ON�AGATE����OFF��ON�A���}C1��C4(+CONFIRM)

//Twice(SW4=ON)�AGate=ON(�u��Low)�|�s�AGate=OFF(�_��High)���|�s�C
// 	GateOFF_Twice_Normal = 0,
	GateON_ErrON_BzON,
	GateOFF_ErrON_BzOFF,

	GateOFF_C2C5,
	GateON_WaitOFFtoComplete1_InC2C5,
	GateOFF_Completed_1_WaitON_InC2C5,
	GateON_WaitOFFtoComplete2_InC2C5,
	GateOFF_Completed_2_InC2C5,			//Gate��OFF�AGATE����OFF��ON(��2��)�A�?����}C2��C5(+CONFIRM)

	Gate_C3_AS,
	Gate_SW2_OFF_Err,		//C1�BC2�BC4�BC5�AEr���q�ASW2=OFF�����A����SW2Er�A�u��CONFIRM�?��C
};

enum 	//?�??� for Alarm_Mode
{
	Alarm_ON = 0,
	Alarm_OF,
	Alarm_FF,
	Alarm_EF,

	Alarm_OK = 0,	//�POK_OKALL_F�w�q
	Alarm_OKALL,	//�POK_OKALL_F�w�q
	Alarm_NG,
};

enum 	//Show_XX_In_Normal�CWSCBSN Gate�����u��BC40�w�q 2020/05/22
{
	Show_SC_Now_In_Normal = 0,	//�YNormal���A
	Show_SL_In_Normal,
// 	Show_Alarm_Mode_In_Normal,
// 	Show_Key_LC_In_Normal,		//�n�?������
// 	Show_UN_In_Normal,
// 	Show_Key_HL_In_Normal,		//�_�?�

	Show_NS_In_Normal,
// 	Show_dt_In_Normal,
// 	Show_tt_In_Normal,

	Show_Er_In_Normal,
	Show_C1_In_Normal,
	Show_C2_In_Normal,
	Show_C3_In_Normal,
	Show_C4_In_Normal,
	Show_C5_In_Normal,

// 	Show_PC_In_Normal,		//for �_�l�������PC�A���OErr PC�C

};


typedef struct				//Main_Key
{
	uint8_t Up_KEY_F;			//Main_Key.Up_KEY_F
	uint8_t Down_KEY_F;			//Main_Key.Down_KEY_F
	uint8_t Left_KEY_F;			//Main_Key.Left_KEY_F
	uint8_t Right_KEY_F;		//Main_Key.Right_KEY_F
	uint8_t Enter_KEY_F;		//Main_Key.Enter_KEY_F
	uint8_t Ese_KEY_F;			//Main_Key.Ese_KEY_F

// 	uint8_t M_Start_KEY_F;		//Main_Key.M_Start_KEY_F
// 	uint8_t M_Brake_KEY_F;		//Main_Key.M_Brake_KEY_F
// 	uint8_t Auto_Start_KEY_F;	//Main_Key.Auto_Start_KEY_F
// 	uint8_t Reserve_KEY_F;		//Main_Key.Reserve_KEY_F

} Main_Key_TypeDef;

// typedef struct				//Ext_IO
// {
// 
// } Ext_IO_TypeDef;

enum 	//�p�??� for Timer_Step
{
	T_Step_None,
	T_Step_LT,
	T_Step_PT,
	T_Step_PreBT,
	T_Step_BT,
	T_Step_IT,
};

typedef struct
{
	uint8_t  	Count_C;
	uint16_t  	Count;
	uint8_t  	OnOff;
	uint8_t  	Timeout_F;		//Timeout=1
	uint8_t  	Start_1T;		//1���??���(���m=1)
} Timer_TypeDef;

typedef struct
{
	uint16_t  	Count;
	uint8_t  	OnOff;
	uint8_t  	Timeout_F;		//1=Timeout!
	uint8_t  	Start_1T;		//���B�|�����16b(�O�����}��������)

	uint16_t  	Period_Count;
	uint8_t  	Period_LoopCnt;	//>0�Y�??g���A1=�@��ON�POFF�C���B�|�����16b(�O�����}��������)
	uint16_t  	On_Time;
	uint16_t  	Off_Time;
} Buzzer_TypeDef;

typedef struct
{
	uint8_t  	TX_PT;
	uint8_t 	PT[5];
	uint8_t 	Start_Stop;
	uint8_t 	PT_Index;

} BN_Protocol_CMD_TypeDef;

typedef struct
{
	uint16_t year;
	uint8_t month;
	uint8_t day;
	uint8_t hour;
	uint8_t min;
	uint8_t sec;
	uint8_t old_sec;
} nowtime_data;



