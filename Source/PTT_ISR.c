/*---------------------------------------------------------------------------------------------------------*/
/*                                                                                                         */
/* Copyright(c) 2009 Nuvoton Technology Corp. All rights reserved. */
/*                                                                                                         */
/*---------------------------------------------------------------------------------------------------------*/
#include "PTT_Global.h"
// #ifdef DEBUG_ENABLE_SEMIHOST
// #endif

int g_enable_Touch;
int Key;
extern Pg_Call_Job_0_TypeDef Pg_Call_Job_0;
extern void Show_FW_Version(uint16_t FWVerion, uint16_t SAFWVerion);
extern void Show_FW_Version2(uint16_t FWVerion, uint16_t SAFWVerion);
extern unsigned int Get_Free_Stack_Size(void);
void UART02_IRQHandler(void)
{

  if (UART_GET_INT_FLAG(UART0, UART_INTSTS_RDAINT_Msk))
  {
    if (UART_IS_RX_READY(UART0))
    {
      U0RX[U0RX_Index] = UART_READ(UART0);

      U0RX_Index++;
      if (U0RX_Index >= sizeof(U0RX)) // Check if buffer full 250
        U0RX_Index = sizeof(U0RX) - 1;

      U0RX_CT = 0;
    }
  }
}

void UART13_IRQHandler(void)
{
  uint32_t intStatus = UART1->INTSTS;

  // 	if(u32IntSts & UART_ISR_RDA_INT_Msk)
  if (UART_GET_INT_FLAG(UART1, UART_INTSTS_RDAINT_Msk))
  {
    if (UART_IS_RX_READY(UART1))
    {
      U1RX[U1RX_Index++] = UART_READ(UART1);
      if (U1RX_Index >= sizeof(U1RX)) // Check if buffer full 250
        U1RX_Index = sizeof(U1RX) - 1;

      U1RX_CT = 0;
    }
  }

  if (intStatus & (UART_INTSTS_RDAINT_Msk | UART_INTSTS_RXTOINT_Msk))
  {
    while (!(UART1->FIFOSTS & UART_FIFOSTS_RXEMPTY_Msk))
    {
      uint8_t u8InChar = UART1->DAT;
    }
  }

  // Parity Error
  if (UART1->FIFOSTS & UART_FIFOSTS_PEF_Msk)
  {
    UART1->FIFOSTS = UART_FIFOSTS_PEF_Msk;
    printf("UART1 Parity Error\n");
  }

  // Framing Error
  if (UART1->FIFOSTS & UART_FIFOSTS_FEF_Msk)
  {
    UART1->FIFOSTS = UART_FIFOSTS_FEF_Msk;
    printf("UART1 Framing Error\n");
  }

  // Break Interrupt
  if (UART1->FIFOSTS & UART_FIFOSTS_BIF_Msk)
  {
    UART1->FIFOSTS = UART_FIFOSTS_BIF_Msk;
    printf("UART1 Break Interrupt Detected\n");
  }

  // RX FIFO Overflow
  if (UART1->FIFOSTS & UART_FIFOSTS_RXOVIF_Msk)
  {
    UART1->FIFOSTS = UART_FIFOSTS_RXOVIF_Msk;
    printf("UART1 RX FIFO Overflow\n");
    UART1->FIFO |= UART_FIFO_RXRST_Msk;
  }

  // TX FIFO Overflow
  if (UART1->FIFOSTS & UART_FIFOSTS_TXOVIF_Msk)
  {
    UART1->FIFOSTS = UART_FIFOSTS_TXOVIF_Msk;
    printf("UART1 TX FIFO Overflow\n");
    UART1->FIFO |= UART_FIFO_TXRST_Msk;
  }

} // UART1_IRQHandler
extern uint8_t language_version;
extern uint8_t Temp_language_version;
uint8_t change_GUI_flag = 0;
uint8_t pdma_start_flag = 0;
extern Pg_Home_TypeDef Pg_Home, Temp_Pg_Home;                   // jacob 20250613
extern Pg_Language_0_TypeDef Pg_Language_0, Temp_Pg_Language_0; // jacob
                                                                // 20250613
extern Pg_Call_Job_0_TypeDef Pg_Call_Job_0, Temp_Pg_Call_Job_0; // jacob
                                                                // 20250613
extern Pg_Tool_Mode_0_TypeDef Pg_Tool_Mode_0,
    Temp_Pg_Tool_Mode_0;                                  // jacob 20250108
extern Pg_JS_0_Job_TypeDef Pg_JS_0_Job, Temp_Pg_JS_0_Job; // jacob 20250613
extern Pg_JS_1_JobSEQ_TypeDef Pg_JS_1_JobSEQ,
    Temp_Pg_JS_1_JobSEQ; // jacob 20250613
extern Pg_JS_2_Step2_1_TypeDef Pg_JS_2_Step2_1,
    Temp_Pg_JS_2_Step2_1; // jacob 20250108
extern Pg_JS_3_Step2_2_TypeDef Pg_JS_3_Step2_2,
    Temp_Pg_JS_3_Step2_2;                                       // jacob 20250613
extern Pg_Net_Info_0_TypeDef Pg_Net_Info_0, Temp_Pg_Net_Info_0; // jacob
                                                                // 20250108
extern Pg_Net_AP_Info_0_TypeDef Pg_Net_AP_Info_0,
    Temp_Pg_Net_AP_Info_0; // jacob 20250108
extern Pg_Tool_Info_0_TypeDef Pg_Tool_Info_0,
    Temp_Pg_Tool_Info_0; // jacob 20250108
uint8_t record_language = 0;
void ShowFreeMem(void);
void UART1_RX_Process(void)
{
  uint16_t for_i;
  uint16_t Addr_temp;
  static uint16_t Before_Protocol_CheckSum = 2555;

  if (((U1RX[0] == 0x3B) && (U1RX[1] == 0x2C)) &&
      ((U1RX_Index == (U1RX[2] + 3)) && (U1RX_Index >= 5)))
  {

    Protocol_CheckSum = 0;
    for (for_i = 2; for_i <= (2 + U1RX[2] - 1); for_i++)
      Protocol_CheckSum += U1RX[for_i];

    CheckSum_Index = U1RX[2] + 2;

    if (Protocol_CheckSum == (U1RX[CheckSum_Index]))
    {

      if (Main_Page == U1RX[3])
        U1RX_Process_1T = 1;

      // 2021/05/10 �NCMD5�P�_���Ԩ�̫e���A�_�h�|�~�P��CMD2 OK�C
      if ((U1RX[0] == 0x05) && (U1RX[4] == 0x55) && (U1RX[5] == 0xAA)) // CCB to WSCBSN (CCB Can't Decode)�A�_�l���䴩��CMD�A�����^�еL�k�ѽX�A�٥h���Timeout�ʴ��C
      {
        // �쪩����A������ϥηs�WCMD�A�ӵ{���qScrew_Crtl_Moniter_V0()���~�n�ˬd�A�èM�w�p�����(�p�G��ܰ_�l��������)�C
        // 				CMD_Check = 0x5A;
#ifdef Debug_Mode_J
        // 00-5719,05 3B 2C 02 55 AA 68 ��ڦ���

        printf("CCB Can't Decode CMD %d\n", U1RX[3]);
        // �w�����᪺�����A�Y���s�WCMD�A�h�s�W��CMD�~�ݭn�ˬd�䴩�ʡC
#endif

        // 2021/04/22 �_�l�A���X�{��v�C���s�s�u���]���q�TM3->M2->M1�A�q�`�o�ͦbM2�d���A���]��������~�X05 3B 2C 02 55 AA 68�A�N���s�o�_�s�u�C
        // 				if(First_CMD1_F == 0)
        // 				{
        // 					BLE_Timeout_1S_CT = 10;	//�j��O���_�u�C
        // 				}
      }
      else if (U1RX[3] == 0) // Pg_Home jacob 20250109
      {
        memcpy(&Pg_Home.Title, &U1RX[4], (U1RX[2] - 2)); // �ಾ��ƼƬ�����-2(�S�ﶵ����)
        if ((memcmp(&Pg_Home, &Temp_Pg_Home, sizeof(Pg_Home_TypeDef)) != 0))
        {
          pdma_start_flag = 1;
          Main_Page = 0;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }
      else if (U1RX[3] == 0xa) // Pg_Language_0 jacob 20250109
      {
        memcpy(&Pg_Language_0.Title, &U1RX[4], (U1RX[2] - 2));
        if (memcmp(&Pg_Language_0, &Temp_Pg_Language_0,
                   sizeof(Pg_Language_0_TypeDef)) != 0)
        {
          Main_Page = 10;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }
      else if (U1RX[3] == 0xb) // Page71 jacob 20250109
      {
        memcpy(&Pg_Language_0.Title, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_Language_0, &Temp_Pg_Language_0,
                    sizeof(Pg_Language_0_TypeDef)) != 0))
        {
          Main_Page = 11;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }

      else if (U1RX[3] == 0x14)
      {
        memcpy(&Pg_Tool_Mode_0.Title, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_Tool_Mode_0, &Temp_Pg_Tool_Mode_0,
                    sizeof(Pg_Tool_Mode_0_TypeDef)) != 0))
        {

          Main_Page = 20;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }

      else if (U1RX[3] == 0x15)
      {
        memcpy(&Pg_Tool_Mode_0.Title, &U1RX[4], (U1RX[2] - 2));

        if ((memcmp(&Pg_Tool_Mode_0, &Temp_Pg_Tool_Mode_0,
                    sizeof(Pg_Tool_Mode_0_TypeDef)) != 0))
        {
          Main_Page = 21;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }

      else if (U1RX[3] == 0x1e)
      {
        memcpy(&Pg_Call_Job_0.Title, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_Call_Job_0, &Temp_Pg_Call_Job_0,
                    sizeof(Pg_Call_Job_0_TypeDef)) != 0))
        {

          Main_Page = 30;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }
      else if (U1RX[3] == 0x1f)
      {
        memcpy(&Pg_Call_Job_0.Title, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_Call_Job_0, &Temp_Pg_Call_Job_0,
                    sizeof(Pg_Call_Job_0_TypeDef)) != 0))
        {
          Main_Page = 31;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }

      else if (U1RX[3] == 0x28) // Pg_JS_0_Job jacob 20250109
      {

        memcpy(&Pg_JS_0_Job.Title, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_JS_0_Job, &Temp_Pg_JS_0_Job,
                    sizeof(Pg_JS_0_Job_TypeDef)) != 0))
        {
          Main_Page = 40;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }

      else if (U1RX[3] == 0x29)
      {
        memcpy(&Pg_JS_1_JobSEQ.Title_Job_ID, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_JS_1_JobSEQ, &Temp_Pg_JS_1_JobSEQ,
                    sizeof(Pg_JS_1_JobSEQ_TypeDef)) != 0))
        {
          Main_Page = 41;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }
      else if (U1RX[3] == 0x2a) // Pg_JS_2_Step2_1 jacob 20250109
      {
        memcpy(&Pg_JS_2_Step2_1.Title_Job_ID, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_JS_2_Step2_1, &Temp_Pg_JS_2_Step2_1,
                    sizeof(Pg_JS_2_Step2_1_TypeDef)) != 0))
        {
          Main_Page = 42;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }

      else if (U1RX[3] == 0x2b) // Pg_JS_3_Step2_2 jacob 20250109
      {
        memcpy(&Pg_JS_3_Step2_2.Title_Job_ID, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_JS_3_Step2_2, &Temp_Pg_JS_3_Step2_2,
                    sizeof(Pg_JS_3_Step2_2_TypeDef)) != 0))
        {
          Main_Page = 43;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }
      else if (U1RX[3] == 0x3c) // Pg_Net_Info_0 jacob 20250109
      {
        memcpy(&Pg_Net_Info_0.Title, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_Net_Info_0, &Temp_Pg_Net_Info_0,
                    sizeof(Pg_Net_Info_0_TypeDef)) != 0))
        {
          Main_Page = 60;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }
      else if (U1RX[3] == 0x46) // Pg_Net_AP_Info_0 jacob 20250109
      {
        memcpy(&Pg_Net_AP_Info_0.Title, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_Net_AP_Info_0, &Temp_Pg_Net_AP_Info_0,
                    sizeof(Pg_Net_AP_Info_0_TypeDef)) != 0))
        {
          Main_Page = 70;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }
      else if (U1RX[3] == 0x32) // Pg_Tool_Info_0 jacob 20250109
      {
        memcpy(&Pg_Tool_Info_0.Title, &U1RX[4], (U1RX[2] - 2));
        if ((memcmp(&Pg_Tool_Info_0, &Temp_Pg_Tool_Info_0,
                    sizeof(Pg_Tool_Info_0_TypeDef)) != 0))
        {
          Main_Page = 50;

          Before_Protocol_CheckSum = Protocol_CheckSum;
        }
      }

      else if (U1RX[3] == 0xB1) // �}�lŪ��Barcode
      {
        PC0 = 0;
        BarcodeScan_Timer.Timeout_F = 0;
        BarcodeScan_Timer.Count = 0;
        BarcodeScan_Timer.OnOff = 1; // 10����۰ʰ���y
        printf("PC0 = 0\n");
      }
      else if (U1RX[3] == 0xB0) // ����Ū��Barcode
      {
        PC0 = 1;
        printf("PC0 = 1\n");
      }
      else if (U1RX[3] == 0xB2) // jacob 20241223 barcode power on
      {
        PF2 = 0;
        // ShowFreeMem();

        // Get_Free_Stack_Size();
        /*_Write0(0x11);    //Exit Sleep
        GUI_X_Delay(120);
        _Write0(0x29);    //Display on
        */
      }
      else if (U1RX[3] == 0xB3) // jacob 20241223 barcode power off
      {
        PF2 = 1;
      }
      else if (U1RX[3] == 0xB4) // jacob 20241223 english font
      {

        language_version = 0;
        change_GUI_flag = 1;
        record_language = 1;
      }
      else if (U1RX[3] == 0xB5) // jacob 20241223 big5 font
      {

        language_version = 1;
        change_GUI_flag = 1;
        record_language = 1;
      }
      else if (U1RX[3] == 0xB6) // jacob 20241223 gb font
      {

        language_version = 2;
        change_GUI_flag = 1;
        record_language = 1;
      }
      else if (U1RX[3] == 0xB9) // jacob 20241223 gb font
      {
        PA6 = 1; // jacob 20250111 lcd backgroundlight enable
      }
      else if (U1RX[3] == 0xBA) // jacob 20241223 gb font
      {
        PA6 = 0; // jacob 20250111 lcd backgroundlight enable
      }
      else if (U1RX[3] == 0xBB) //
      {
        Show_FW_Version(LCD_Version, SA_Version);
      }
// �z---------------------------------------------
#ifdef Debug_PA9_LED7
// 			PA9 = 0;
#endif
      // #ifdef DEBUG_ENABLE_SEMIHOST
      // #ifdef Debug_Mode_J	//��bCheckSum���T���C//��PTM_Log_EN�ѼƱ���C2020/11/03
      if (PTM_Log_EN != 1) // 1=�}�ҡA��L=����(�w�])
        goto _PTM_Log_UART1_RX_Process;

      Match_F = 1;
      if (memcmp(&U1RX[0], &U1RX_Pre[0], (U1RX[0] + 2)) != 0) // �e�ᵧ�t�����Cmemcmp�۵�=0
        Match_F = 0;

      if (Match_F == 0) // �ƭ��ܧ�~��X
      {
        for (for_i = 0; for_i < (U1RX[0] + 2); for_i++)
          U1RX_Pre[for_i] = U1RX[for_i]; // Restore Pre

#ifdef Timing_Debug_J // JohnsonTest
        // 				printf("%02X-", Cnt8b_1Hour);		//1=1�p��
        printf("%02X-", Cnt8b_1Min);  // 1=1��
        printf("%04X,", Cnt16b_10mS); // 1=16.7mS
#endif

        for (for_i = 0; for_i < (U1RX[0] + 2); for_i++)
        {
          printf("%02X", U1RX[for_i]); // 2��L���Q���i���ơA�H0~F����
          if (for_i != (U1RX[0] + 1))
            printf(" "); // ���j�ť�,�̫�@�����[
        }
        printf("\n");

        // �ɶ��t,T3�n�}��,�i���}���_
        // 				T3_TDR = TIMER3->TDR;
        // 				T3_TDR_Diff = T3_TDR - T3_TDR_Pre;
        // 				printf(",%d.%d mS\n", T3_TDR_Diff/1000, (T3_TDR_Diff%1000)/100);
        // 				T3_TDR_Pre = T3_TDR;
      }
    _PTM_Log_UART1_RX_Process:
      // #endif
      // �|---------------------------------------------

      U1RX_Index = 0;
    } // if(Protocol_CheckSum == (U0RX[CheckSum_Index]))	//CheckSum���T
    else // CheckSum�����T
    {
#ifdef Timing_Debug_J // JohnsonTest
      // 		printf("%02X-", Cnt8b_1Hour);		//1=1�p��
      printf("%02X-", Cnt8b_1Min);    // 1=1��
      printf("%04X,00", Cnt16b_10mS); // 1=16.7mS
      printf("\n");
#endif
      if (PTM_Log_EN == 1) // 1=�}�ҡA��L=����(�w�])
      {
        Match_F = 1;
        if (memcmp(&U1RX[0], &U1RX_Pre[0], (U1RX[0] + 2)) != 0) // �e�ᵧ�t�����Cmemcmp�۵�=0
          Match_F = 0;

        if (Match_F == 0) // �ƭ��ܧ�~��X
        {
          for (for_i = 0; for_i < (U1RX[0] + 2); for_i++)
            U1RX_Pre[for_i] = U1RX[for_i]; // Restore Pre

#ifdef Timing_Debug_J // JohnsonTest
          // 					printf("%02X-", Cnt8b_1Hour);		//1=1�p��
          printf("%02X-", Cnt8b_1Min);  // 1=1��
          printf("%04X,", Cnt16b_10mS); // 1=16.7mS
#endif

          for (for_i = 0; for_i < (U1RX[0] + 2); for_i++)
          {
            printf("%02X", U1RX[for_i]); // 2��L���Q���i���ơA�H0~F����
            if (for_i != (U1RX[0] + 1))
              printf(" "); // ���j�ť�,�̫�@�����[
          }
          printf("[CheckSum NG]\n");
        }
      }

      U1RX_Index = 0;
    }
  } // �����榡���T
  // 	else	//�����榡���~
  // 	{
  //
  // 	}

  // 	Disalbe_LED();		//BLE�_�u���G�ABLE�P�_�l�T���L���A��~��(main loop)�C

  // 	U1RX_Index = 0;
  // 	UART1_RX_INT_F = 0;				//UART1_RX���_
  // 	UART1_RX_TimeBuf_CT = 0;		//UART1_RX���_��3mS�L��s�~�B�z���
}

void TimerCount(void)
{

  // �u---------------------------------------------
  if (BarcodeScan_Timer.OnOff == 1)
  {
    BarcodeScan_Timer.Count++;
    if (BarcodeScan_Timer.Count >= 60000) // 1=1mS
    {
      BarcodeScan_Timer.Count = 0;
      BarcodeScan_Timer.OnOff = 0;
      BarcodeScan_Timer.Timeout_F = 1;
    }
  }
  else
    BarcodeScan_Timer.Count = 0;
}

#if 0
void BZCount(void)	//��T0���_�Ͽ�XBZ
{
/*	2020/09/16 BC40�s��ֳt����⦸�A���n�|�����C
	�ѪR�GOK���n��Off_Time�ɶ��L���A�bOff_Time�ɧǤ��S�Ұ�Timer�A�]�Ұʳ]�w�èS���M��BZ_Timer.Period_Count=0�A�G�L�kĲ�oON�C 
	�Ѫk�GBZ_Out_By_Alarm_Mode(1, Alarm_OK)//�����Ӧa�趷�ץ�BZ_Timer.Off_Time�ɶ�
	BZ_Timer.Off_Time = 2;	//2020/09/16 �s��ֳt����⦸�A���n�|�����C10(50mS ��30���i���{1�B2��)�A5(25mS ��50���L�k���{) */

	if(BZ_Timer.OnOff == 1)		//1����X�u���A�g�����n
	{
		BUZZER_ON;
		if(BZ_Timer.Count > 0)
			BZ_Timer.Count--;
		if(BZ_Timer.Count == 0)
		{
			BZ_Timer.OnOff = 0;
			BUZZER_OFF;
		}
	}
	else if(BZ_Timer.Period_LoopCnt > 0)	//�g�����n
	{
		if(BZ_Timer.Period_Count == 0)
			BUZZER_ON;

		BZ_Timer.Period_Count++;
		if(BZ_Timer.Period_Count == BZ_Timer.On_Time)		//ON->OFF
			BUZZER_OFF;
// 		else if(BZ_Timer.Period_Count == (BZ_Timer.On_Time + BZ_Timer.Off_Time))  //OFF->ON?	//BZ_Timer.Off_Time���i��0
// 		if(BZ_Timer.Period_Count == (BZ_Timer.On_Time + BZ_Timer.Off_Time))  //OFF->ON?			//BZ_Timer.Off_Time�i��0
		if(BZ_Timer.Period_Count >= (BZ_Timer.On_Time + BZ_Timer.Off_Time))  //OFF->ON?	//AT��X��������Ĳ�o�u��(�pErr_PC_VoltLock)�|�s���� 2019/11/18
		{
			BZ_Timer.Period_LoopCnt--;
			if(BZ_Timer.Period_LoopCnt != 0)	//OFF->ON for next loop
			{
				BUZZER_ON;
				BZ_Timer.Period_Count = 0;
			}
			else
				BZ_Timer.Timeout_F = 1;		//1=Timeout!
		}
	}

	if(BZ_Timer.Period_LoopCnt == 0)	//Auto Reset
	{
		BZ_Timer.Period_Count = 0;
		BZ_Timer.Timeout_F = 0;		//1=Timeout!
	}
#ifdef BZ_Is_PB0_RXD0
if(PE6 == 1)
	PB13 = 1;	//�P�BBZ I/O
else
	PB13 = 0;
#endif
}
#endif

// TIMER0 1mS
void TMR0_IRQHandler(void) // #7Seg display by function
{
  /* Clear Timer0 time-out interrupt flag */
  // 	TIMER_ClearIntFlag(TIMER0);

  TimerCount();

  if (U0RX_CT < 2000)
    U0RX_CT++;

  U1RX_CT++;
  // 	if(U1RX_CT > 2000)		//UART1�۰ʭ��m
  if (U1RX_CT > 20) // 2025/01/13
                    //
                    // jacob 20250422
  // if(U1RX_CT > 200)		//2022/11/25
  //
  {
    U1RX_CT = 0;
    U1RX_Index = 0;
  }

  OS_TimeMS++;
#if GUI_SUPPORT_TOUCH
  if (OS_TimeMS % 10 == 0)
  {
    if (g_enable_Touch == 1)
    {
      GUI_TOUCH_Exec();
    }
  }
#endif
  if ((g_enable_Touch == 1) && (OS_TimeMS % 200 == 0))
  {

    PB14 = 1;

    if (PB1 == 0)
    {

      Key = GUI_KEY_ESCAPE;
      GUI_StoreKeyMsg(GUI_KEY_ESCAPE, 1);
    }
    if ((PB0 == 0) || (PC4 == 0))
    {
      Key = GUI_KEY_ENTER;
      GUI_StoreKeyMsg(Key, 1);
    }
    if (PC2 == 0)
    {

      Key = GUI_KEY_RIGHT;
    }
    if (PC5 == 0)
    {

      Key = GUI_KEY_LEFT;

      Key = 'A';
      GUI_StoreKeyMsg(Key, 1);
    }
    if (PC3 == 0)
    {

      Key = GUI_KEY_UP;
      GUI_StoreKeyMsg(Key, 1);
    }
    if (PA7 == 0)
    {

      Key = GUI_KEY_DOWN;
      GUI_StoreKeyMsg(Key, 1);
    }
  }

  /* Clear Timer0 time-out interrupt flag */
  TIMER_ClearIntFlag(TIMER0);
}

// TIMER1 50mS BLE TX+RX�A�`�A���b30mS
void TMR1_IRQHandler(void) // #KEY + UART CMD Process
{
  /* Clear Timer1 time-out interrupt flag */
  TIMER_ClearIntFlag(TIMER1);
// �z---------------------------------------------
//	�u������禡�|�]�wCMD,��Screw_Crtl_Moniter_V0()�o�e
#ifdef Debug_BLE_SlaveMode_J // ���ե�

#else
#ifdef Debug_PA9_LED7
  // 		PA9 = 1;
  // 		PA9 = ~PA9;
#endif
  // 	Screw_Crtl_Moniter_V0();		//�_�l�ʴ��P����50mS���_��
  T1_50mS_F = 1; // 1=����o�eCMD�禡
                 // OKALL��X�ʴ�OKALL�OOFF
#endif

#ifdef AutoTest_Mode_J // �ϥ�SelBit0_eKEY�}����OKALL�}�T������ 2021/01/20
  // �z---------------------------------------------�۰ʥ�����{
  if (Trigger_CT < 120) // 6000mS
    // 	if(Trigger_CT < 140)	//6000mS 2021/04/01 ��7���@�Ӧ�{
    Trigger_CT++;

  if (Trigger_CT == 100)
  // 	if(Trigger_CT == 120)	//2021/04/01 ��7���@�Ӧ�{
  {
    if (Trigger_Port == 0) // 0=CN1-2�A1=CN5-6
    {
      SEQBit_Code = 0x02; // GotoSEQBit_Process()���۰��I�G�q
      Trigger_Port = 1;
    }
    else
    {
      SEQBit_Code = 0x04; // GotoSEQBit_Process()���۰��I�G�q
      Trigger_Port = 0;
    }
  }
  else if (Trigger_CT >= 120)
  // 	else if(Trigger_CT >= 140)	//2021/04/01 ��7���@�Ӧ�{
  {
    Trigger_CT = 0;
    SEQBit_Code = 0x00; // GotoSEQBit_Process()���۰��I�G�q
  }
  // �u---------------------------------------------OK�T������
  if (SelBit0_eKEY == 0)
  {
    if (Port_OKALL_CT < 20) // �W��1000mS
      Port_OKALL_CT++;

    if (Port_OKALL_CT >= 10) // ��������500mS�⦳�İT��(OK)�AOK�̵u�u��200mS�B���(��700mS�G)
    {
      if (Each_OKALL_1T == 1)
      {
        Each_OKALL_1T = 0;
        Each_OKALL_CT++;
      }
    }
  }
  else if (Port_OKALL_CT >= 9) // OK�����G�A�B��~���C�s��OK�ɡAOK�̵u�u��200mS�B���(��700mS�G)�A��⦸100mS�B����N������ġC
    Port_OKALL_CT -= 9;
  else
  {
    Port_OKALL_CT = 0;
    Each_OKALL_1T = 1;
  }
  // �u---------------------------------------------OKALL�T������
  //  	if(SelBit0_eKEY == 0)
  //  	{
  //  		if(Port_OKALL_CT < 20)		//�W��1000mS
  //  			Port_OKALL_CT++;
  //
  //  		if(Port_OKALL_CT >= 16)		//��������800mS�⦳�İT��(AT�n�]�w1.0S)
  //  		{
  //  			if(Each_OKALL_1T == 1)
  //  			{
  //  				Each_OKALL_1T = 0;
  //  				Each_OKALL_CT++;
  //  			}
  //  		}
  //  	}
  //  	else if(Port_OKALL_CT >= 4) 	//OKALL�A-200mS��������250mS(5��)�⦳�ĩ�}(1������)
  //  		Port_OKALL_CT -= 4;
  //  	else
  //  	{
  //  		Port_OKALL_CT = 0;
  //  		Each_OKALL_1T = 1;
  //  	}
  // �|---------------------------------------------

#endif
#ifdef Timing_Debug_J                  // JohnsonTest
  Cnt16b_10mS++;                       // JohnsonTest ��4��BCD
  if ((Cnt16b_10mS & 0x000F) > 0x0009) // 0~9999
  {
    Cnt16b_10mS &= 0xFFF0;
    Cnt16b_10mS += 0x0010;
    if ((Cnt16b_10mS & 0x00F0) > 0x0090)
    {
      Cnt16b_10mS &= 0xFF0F;
      Cnt16b_10mS += 0x0100;
      if ((Cnt16b_10mS & 0x0F00) > 0x0900)
      {
        Cnt16b_10mS &= 0xF0FF;
        Cnt16b_10mS += 0x1000;
        if ((Cnt16b_10mS & 0xF000) > 0x9000)
        {
          Cnt16b_10mS &= 0x0FFF;
          Cnt16b_10mS += 0x1000;
          if ((Cnt16b_10mS & 0xF000) > 0x9000)
            Cnt16b_10mS = 0;
        }
      }
    }
  }
  // 	if(Cnt16b_10mS >= 0x3600)	//3600x16.7mS=60S
  if (Cnt16b_10mS == 0x0000) // 10000
  {
    Cnt16b_10mS = 0;
    Cnt8b_1Min++;
    if ((Cnt8b_1Min & 0x0F) > 0x09) // 0~59��
    {
      Cnt8b_1Min &= 0xF0;
      Cnt8b_1Min += 0x10;
      if ((Cnt8b_1Min & 0xF0) > 0x50)
      {
        Cnt8b_1Min = 0;
        Cnt8b_1Hour++;
        if ((Cnt8b_1Hour & 0x0F) > 0x09) // 0~99�p��
        {
          Cnt8b_1Hour &= 0xF0;
          Cnt8b_1Hour += 0x10;
          if ((Cnt8b_1Hour & 0xF0) > 0x90)
            Cnt8b_1Hour = 0;
        }
      }
    }
  }
#endif
}

void UART_ErrorHandler(UART_T *uart)
{
  uint32_t u32IntSts = uart->FIFOSTS;

  // ?????????(RX Overrun)
  if (u32IntSts & UART_FIFOSTS_RXOVIF_Msk)
  {
    uart->FIFOSTS = UART_FIFOSTS_RXOVIF_Msk; // ??
    printf("UART RX Overrun Error\n");
  }

  // ?????????(Framing Error)
  if (uart->FIFOSTS & UART_FIFOSTS_FEF_Msk)
  {
    uart->FIFOSTS = UART_FIFOSTS_FEF_Msk;
    printf("UART Framing Error\n");
  }

  // ?????????(Parity Error)
  if (uart->FIFOSTS & UART_FIFOSTS_PEF_Msk)
  {
    uart->FIFOSTS = UART_FIFOSTS_PEF_Msk;
    printf("UART Parity Error\n");
  }

  // ????? Break ??
  if (uart->FIFOSTS & UART_FIFOSTS_BIF_Msk)
  {
    uart->FIFOSTS = UART_FIFOSTS_BIF_Msk;
    printf("UART Break Detected\n");
  }

  // ?? RX FIFO
  uart->FIFO |= UART_FIFO_RXRST_Msk;
}