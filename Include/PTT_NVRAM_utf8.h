/*---------------------------------------------------------------------------------------------------------*/
/*                                                                                                         */
/* Copyright(c) 2009 Nuvoton Technology Corp. All rights reserved.                                         */
/*                                                                                                         */
/*---------------------------------------------------------------------------------------------------------*/

#ifndef __NVRAM
#define __NVRAM

// #define uint8_t (unsigned 

//24LC64 = 64Kbits = 8KBytes (0x0000~0x1F00)
//參規劃檔EEPROM頁面
//真實使用量					組數量	每組Byte	Bytes
// 保留	保留					1		32		32
// 通用	介面					96		1		96
// [2]Tool Pair		MAC			20		12		240
// [4]Sequence		SEQ199		200		2		400
// [6]BC-1  000-00	Barcode		9		21		189
// [7]Ext Input		MyExtInput	5		14		70
// [8]Ext Output	MyExtOutput	5		6		30
// 起子參數			Program		100		13		1300
// 組別名稱			ProgramName	100		12		1200

//Page規劃使用量				組數量	每組Byte	Bytes
// 保留	保留					1		32		32
// 通用	介面					96		1		96
// [2]Tool Pair		MAC			20		16		320		//每Page存2組MAC，只用前24Byte
// [4]Sequence		SEQ199		208		2		416
// [6]BC-1  000-00	Barcode		9		32		288
// [7]Ext Input		MyExtInput	5		16		80+16(補齊3Page)
// [8]Ext Output	MyExtOutput	5		6		30+2(補齊2Page)
// 起子參數			Program		100		32		3200
// 組別名稱			ProgramName	100		16		3200
#define EE_Init_RAM_Size			32
#define General_RAM_Size			96
#define MAC_RAM_Size				320		//實際用228，12+12(1Page存2組MAC)
#define SEQ_RAM_Size				416		//實際用398
#define Barcode_RAM_Size			288		//實際用189
#define MyExtInput_RAM_Size		96		//實際用70(14x5)
#define MyExtOutput_RAM_Size		32		//實際用30(6 x5)
#define Program_RAM_Size			3200	//實際用13x99
#define ProgramName_RAM_Size		1600	//實際用12x99，12+12(1Page存2組名稱，位址對半切不採連續)，2020/08/14

#define EE_Init_RAM						0x0020				//保留0x0000~0x001F(1Page)不用
#define General_Init_RAM				EE_Init_RAM
#define MAC_Init_RAM					(General_Init_RAM 		+ General_RAM_Size)
#define SEQ_Init_RAM					(MAC_Init_RAM 			+ MAC_RAM_Size)
#define Barcode_Init_RAM				(SEQ_Init_RAM 			+ SEQ_RAM_Size)
#define MyExtInput_Init_RAM				(Barcode_Init_RAM 		+ Barcode_RAM_Size)		//由ISet0_RAM控制組別
#define MyExtOutput_Init_RAM			(MyExtInput_Init_RAM 	+ MyExtInput_RAM_Size)		//由OSet0_RAM控制組別
#define Program_Init_RAM				(MyExtOutput_Init_RAM 	+ MyExtOutput_RAM_Size)
#define ProgramName_Init_RAM			(Program_Init_RAM 		+ Program_RAM_Size)
#define EE_End_RAM						(ProgramName_Init_RAM 	+ ProgramName_RAM_Size - 1)	//0~0x17BF(共 6080 Byte)，2020/08/14
//需驗證EE_End_RAM值是否吻合。

//EEPROM位址(WSCBSN-PTM)，保留0x0000~0x001F(1Page)不用
#define NVRam_Ident			0x5A	//初始化比較值
#define	NVRamAddr_Ident		0x05	//Address

enum	//控制器通用參數，EERPOM起始位址EE_Init_RAM
{
	//Product_No_RAM使用16Byte，會用Page寫入，故其他參數擴增須留意湊滿一個Page(32Byte)
//---------------------Page1(控制器用)
	SEQ_Now_RAM = General_Init_RAM,		//保留可存EEPROM，若採紀錄則需考慮寫入次數 2020/04/17
	SEQ_Start_RAM,		//[3]SEQ Numbers
	SEQ_End_RAM,		//[3]SEQ Numbers
	SEQ_RAM,			//[4]Sequence，組別設定
	Gate_Mode_RAM,		//[5]Gate Mode
	ISet0_RAM,			//[7]Ext Input組別
	OSet0_RAM,			//[8]Ext Output組別
	Device_ID_RAM,		//[9]Device ID
	Ext_SEQ_Ctrl_RAM,
	Operator_RAM,
	Data_Port_RAM,
// 	Program_RAM,		//起子Program組別()
// Reserve_12,			//給控制器參數擴增，(13+3)+16Product_No=32(1Page)
	OKALL_Signal_RAM,	//2020/12/25
// Reserve_13,
	PWR_ON_Name_RAM,	//2021/02/24 晶元開機型號(2)，奇力速(1)，與切換方式同TCG。
Reserve_14,
	Password_RAM,						//2Byte
	Product_No_RAM = Password_RAM + 2,	//16Byte
//---------------------Page2(控制器上與起子相關)
	Program_RAM = Product_No_RAM + 16,	//起子Program組別
	//控制器起子參數的3個全域參數
	OKALL_Stop_G_RAM,		//0=OFF，1=ON
	NG_Stop_G_RAM,
	Rev_Thread_G_RAM,		//0正牙/1逆牙 鎖附，即常態反轉，通用參數無排序

	SyncP_S_Start_RAM,
	SyncP_S_End_RAM,
	SyncP_D_Start_RAM,
	SyncP_D_End_RAM,
	SelProgram_RAM,
// 	_RAM,
// 	General_Init_End_RAM = Product_No_RAM + 16,
};
//控制器初始化值(只定義分散參數，批次直接由Default_SettingValue寫死)
#define SEQ_Now_RAM_InitVal		1		//0=OFF(=SEQ001)	
#define SEQ_Start_InitVal		0		//0=OFF(=SEQ001)	
#define SEQ_End_InitVal			5
#define SEQ_InitVal				1		//[4]Sequence，組別設定
#define Gate_Mode_InitVal		0		//0=None、1=Once(Hi)、2=Twice、3=Once(Lo)
#define OKALL_Signal_InitVal	0		//OKALL訊號(0=Each SEQ，1=All SEQ Done)。2020/12/25
#define ISet0_InitVal			1
#define OSet0_InitVal			1
#define Device_ID_InitVal		1
#define Ext_SEQ_Ctrl_InitVal 	0		//0=OFF、1=YES
#define Operator_InitVal		1		//模式確認(0: ADV, 1: STD, 2: ALI, 3: SET)
#define Data_Port_InitVal		0		//Data輸出介面(0: RS232, 1: Ethernet, 2: RS232(Ack), 3: Ethernet(Ack)) 
#define Program_InitVal			1
#define Password_InitVal		0		//2Byte
#define Product_No_InitVal		"                "	//ASCII空白x16，16Byte
// #define Password_InitVal		1234		//2Byte，測試用
// #define Product_No_InitVal		"1111111111111111"	//ASCII空白x16，16Byte，測試用
//起子初始化值，預設值同步單機2020/11/20
#define OKALL_Alarm_InitVal		10		//1=0.1S
#define Batch_Count_InitVal		5		//顆數
#define Force_InitVal			1		//力度
#define Impacts_InitVal			10		//打擊圈數
#define Limit_InitVal			0		//浮鎖圈數；起子預設=1，調整後無法設定1，因偵測就需要1圈故，<=1就是OFF。2020/03/30
#define Ignore_Thread_InitVal	0		//忽略圈數，0=OFF。
#define OKALL_Stop_InitVal		0		//0=OFF，1=ON
#define NG_Stop_InitVal			0		//0=OFF，1=ON
#define Rev_Thread_InitVal		0		//正牙/逆牙，0=FWD、1=REV
#define Pt_InitVal				0		//4個保留功能參數
#define rt_InitVal				0
#define rr_InitVal				0
#define rL_InitVal				0
//起子頁面初始化值
#define SyncP_S_Start_InitVal	01		//同步P來源
#define SyncP_S_End_InitVal		05		//同步P來源
#define SyncP_D_Start_InitVal	1		//同步P目的
#define SyncP_D_End_InitVal		5		//同步P目的
#define SelProgram_InitVal		0x01	//選擇起子P循環，循環組別設定(B.0=P01，B.1=P01，…，B.4=P05)，設1才執行。
// #define CopyP_S_InitVal			1		//複製P來源，開機後記錄順序
// #define CopyP_D_InitVal			2		//複製P目的，開機後記錄順序

enum	//起子參數，每組Program(Page)內的參數相對位址偏移量，順序對應Setting變數宣告
{
	//Program_Init_RAM，3200 Byte(100Page)，每Page存1組13 Byte，只用前13Byte，實際共用13x99=1287 Byte。
	OKALL_Alarm_RAM,		//位址偏移量起始=0
	Batch_Count_RAM,
	Force_RAM,
	Impacts_RAM,
	Limit_RAM,
	Ignore_Thread_RAM,
	OKALL_Stop_RAM,			//0=OFF，1=ON，改全域變數，但仍先保留位址。2020/05/29

	NG_Stop_RAM,			//改全域變數，但仍先保留位址。2020/05/29
	Rev_Thread_RAM,			//改全域變數，但仍先保留位址。2020/05/29

	Pt_RAM,					//4個保留功能參數
	rt_RAM,
	rr_RAM,
	rL_RAM,

	Program_Init_End_RAM,	//此值就是起子參數數量
};

extern uint8_t KeyEvent_EEPROM_STEP;	//按鍵事件的EEPROM讀寫程序in main()，KEY的T0中斷=5mS，沒有足夠時間寫入。
// extern uint32_t DataFlash_dF[6][4];		//讀取Data Flash用，6 x 16Byte。d0~d5=6組
extern uint16_t EE_Addr_Offset;


extern uint8_t g_u8DeviceAddr;
// extern uint8_t g_au8TxData[3];
extern uint8_t g_au8TxData[34];		//Page Write支援1次32Byte。2020/03/27
extern uint8_t g_u8RxData;
extern uint8_t g_u8DataLen;
extern uint8_t g_u8DataLen_32B;		//Page Write支援1次32Byte。2020/03/27
extern uint8_t g_u8EndFlag;
//┌---------------------------------------------
//寫入時間測試
// extern uint16_t TWC[5];				//連續寫入5Byte(Write_24LC64連續5行)，TWC寫入時間測試，Write cycle time (byte or page)
// extern uint8_t TWC_Index;
// extern uint8_t testData[5];
// extern uint8_t testAddr;
// void Write_cycle_time_test(void);	//24LC64寫入時間測試
//└---------------------------------------------

void I2C_MasterRx(uint32_t u32Status);
void I2C_MasterTx(uint32_t u32Status);	//SI=I2C Interrupt Flag，AA=Assert Acknowledge Control，SPEC.P504
void Page_Write_24LC64(uint16_t address, uint8_t *data_addr, uint8_t DataX_Len);	//DataX_Len(1~32，不含2Addr)
void Write_24LC64(uint16_t address, uint8_t data);
uint8_t Read_24LC64(uint16_t address);
void Default_SettingValue(void);
void WR_EE_SettingValue(void);
void WR_EE_TestCount(void);				//儲存測試次數與NG次數

// void RD_EE_All_Setting(void);
// void RD_EE_General(void);
// void RD_EE_MAC(void);
// void RD_EE_Barcode(void);
// void RD_EE_MyExtInput(void);
// void RD_EE_MyExtOutput(void);
// void RD_EE_Program(uint8_t P, uint8_t *Set_8b);
// void RD_EE_ProgramName(uint8_t P, uint8_t *Set_8b);	//依Setting.Program組別讀取該名稱。

void RD_EE_TestCount(void);	//讀取總測試次數、測試次數與NG次數

void I2C_Init(void);

// int8_t SetDataFlashBase(uint32_t u32DFBA);
#endif
 
 
 
