using SerialHex.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SerialHex
{
    public partial class Pg_Home : Form
    {
        public Pg_Home()
        {
            InitializeComponent();
        }

        private void Pg_Home_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton29.Checked = true;
            radioButton3.Checked = true;
            radioButton5.Checked = true;
            radioButton30.Checked = true;
                  radioButton15.Checked = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////標題檔16碼
            string Ti = "";
            int i, count;
            string str111 = "";
            byte[] Title = new byte[50];
            byte[] Button1 = new byte[2];
            byte[] Button2 = new byte[2];
            byte[] Button3 = new byte[2];
            Ti = "";
            Ti = textBox18.Text.ToString();
            for (i = 0; i < 1; i++)
            {
                if (i < textBox18.TextLength)
                {
                    Title[i] = Convert.ToByte(Ti[i]); //want++
                  //  richTextBox1.Text += Ti.ToString()[i];
                }

                else
                {
                    Title[i] = Convert.ToByte('0'); //want++
                 //   richTextBox1.Text += Ti.ToString()[i];
                }

            }
          //  richTextBox1.Text += "\r\n";
            for (i = 0; i < 1; i++)
            {

              //  richTextBox1.Text += Title[i] + " ";
            }
       //     richTextBox1.Text += "\r\n";
            ////////////////////////////////////////////////////////////////APPLINK


            byte[] Applinkarray = new byte[100];
          
            str111 = "";
            str111 = textBox1.Text.ToString();
            for (i = 0; i < 16; i++)
            {
                if (i < textBox1.TextLength)
                {
                 //   richTextBox1.Text += str111.ToString()[i];
                    Applinkarray[i] = Convert.ToByte(str111[i]);  //want++
                }

                else
                {
                //    richTextBox1.Text += '0';
                    Applinkarray[i] = Convert.ToByte('0'); //want++
                }
                
               

            }
          //  richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {
               
             // richTextBox1.Text += Applinkarray[i]+" ";
             }
          //  richTextBox1.Text += "\r\n";
            ////////////////////////////////////////////////////////////////datauploand
            string str222 = "";
            str222 = textBox2.Text.ToString();
            byte[] datauploand = new byte[100];
            str222 = "";
            str222 = textBox2.Text.ToString();
            for (i = 0; i < 16; i++)
            {
                if (i < textBox2.TextLength)
                {
                 //   richTextBox1.Text += str222.ToString()[i];
                    datauploand[i] = Convert.ToByte(str222[i]);  //want++
                }

                else
                {
                   // richTextBox1.Text += '0';
                    datauploand[i] = Convert.ToByte('0'); //want++
                }
               
               

            }
          //  richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {

               // richTextBox1.Text += datauploand[i] + " ";
            }
          //  richTextBox1.Text += "\r\n";
            //////////////////////////////////////////////////////s1-s3
            /*string s1 = "", s2 = "", s3 = "";
            byte[] ss = new byte[10];
            s1 = "";
            s1 = textBox15.Text.ToString();
          
            richTextBox1.Text += "s1"+s1.ToString()+ "\r\n";
            ss[0] = Convert.ToByte(s1); //want++
            richTextBox1.Text += "ss[0]" + ss[0].ToString() + "\r\n";
            s2 = "";
            s2 = textBox16.Text.ToString();
            richTextBox1.Text += "s2="+s2.ToString() + "\r\n";
            ss[1] = Convert.ToByte(s2); //want++ //want++
            s3 = "";
            s3 = textBox17.Text.ToString();
            richTextBox1.Text += "s3="+s3.ToString() + "\r\n";
            ss[2] = Convert.ToByte(s3); //want++; //want++
            */
            ////////////////////////////////////////////////////////batt.
            string batt = "";
            byte[] bata = new byte[2];
            batt = "";
            batt= textBox3.Text.ToString();
          //  richTextBox1.Text += "batt=" + batt.ToString() + "\r\n";
            bata[0]= Convert.ToByte(batt);//want++
                                        //////////////////////////////////////////////////////////
                                        ////////////////////////////////////////////////////////Job
            string Job = "";
            byte[] Jobarray = new byte[2];
            Job = "";
            Job = textBox4.Text.ToString();
         //   richTextBox1.Text += "Job=" + Job.ToString() + "\r\n";
            Jobarray[0] = Convert.ToByte(Job); ;//want++
            //////////////////////////////////////////////////////////
            /// ////////////////////////////////////////////////////////seq now
            string SeqNow = "";
            byte[] SeqNowarray = new byte[2];
            SeqNow = "";
            SeqNow = textBox5.Text.ToString();
          //  richTextBox1.Text += "SeqNow=" + SeqNow.ToString() + "\r\n";
            SeqNowarray[0] = Convert.ToByte(SeqNow);//want++
            //////////////////////////////////////////////////////////
            ////// ////////////////////////////////////////////////////////seq total
            string SeqTotal = "";
            byte[] SeqTotalarray = new byte[2];
            SeqTotal = "";
            SeqTotal = textBox6.Text.ToString();
         //   richTextBox1.Text += "SeqTotal=" + SeqTotal.ToString() + "\r\n";
            SeqTotalarray[0] = Convert.ToByte(SeqTotal);//want++
            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////StepNow
            string StepNow = "";
            byte[] StepNowarray = new byte[2];
            StepNow = "";
            StepNow = textBox7.Text.ToString();
         //   richTextBox1.Text += "StepNow=" + StepNow.ToString() + "\r\n";
            StepNowarray[0] = Convert.ToByte(StepNow); ;//want++
           //////////////////////////////////////////////////////////
          //////////////////////////////////////////////////////////////StepNow
            string StepTotal = "";
            byte[] StepTotalarray = new byte[2];
            StepTotal = "";
            StepTotal = textBox8.Text.ToString();
         //   richTextBox1.Text += "StepTotal=" + StepTotal.ToString() + "\r\n";
            StepTotalarray[0] = Convert.ToByte(StepTotal); ;//want++
            //////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////CounterNow
            string CounterNow = "";
            byte[] CounterNowarray = new byte[2];
            CounterNow = "";
            CounterNow = textBox9.Text.ToString();
         //   richTextBox1.Text += "CounterNow=" + CounterNow.ToString() + "\r\n";
            CounterNowarray[0] = Convert.ToByte(CounterNow);//want++
            //////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////CounterTotal
            string CounterTotal = "";
            byte[] CounterTotalarray = new byte[2];
            CounterTotal = "";
            CounterTotal = textBox10.Text.ToString();
         //   richTextBox1.Text += "CounterTotalarray=" + CounterTotal.ToString() + "\r\n";
            CounterTotalarray[0] = Convert.ToByte(CounterTotal); ;//want++
            //////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////TourqeNow_int
            string TourqeNow_int = "";
            UInt64[] TourqeNow_intarray64 = new UInt64[4];
            UInt32[] TourqeNow_intarray_32 = new UInt32[4];
            UInt16[] TourqeNow_intarray_16 = new UInt16[4];
            Byte[] TourqeNow_intarray_Byte = new Byte[4];
            TourqeNow_int = "";
            TourqeNow_int = textBox11.Text.ToString(); 

                      

            //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

            TourqeNow_intarray_16[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int) ) & 0xffff);
            TourqeNow_intarray_Byte[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[0]) ) & 0xff);//want++
            TourqeNow_intarray_Byte[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[0]>>8)) & 0xff);//want++
            TourqeNow_intarray_16[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int)>>16) & 0xffff);
            TourqeNow_intarray_Byte[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[1])) & 0xff);//want++
            TourqeNow_intarray_Byte[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[1] >> 8)) & 0xff);//want++
                                                                                                          //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";

            //  richTextBox1.Text += "TourqeNow_int Hbyte=" + TourqeNow_intarray_Byte[1].ToString() + "\r\n";

            //////////////////////////////////////////////////////////TourqeNow_float
            string TourqeNow_int2 = "";
            UInt64[] TourqeNow_intarray642 = new UInt64[4];
            UInt32[] TourqeNow_intarray_322 = new UInt32[4];
            UInt16[] TourqeNow_intarray_162 = new UInt16[4];
            Byte[] TourqeNow_intarray_Byte2 = new Byte[4];
            TourqeNow_int2 = "";
            TourqeNow_int2 = textBox12.Text.ToString();



            //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

            TourqeNow_intarray_162[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int2)) & 0xffff);
            TourqeNow_intarray_Byte2[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_162[0])) & 0xff);//want++
            TourqeNow_intarray_Byte2[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_162[0] >> 8)) & 0xff);//want++
            TourqeNow_intarray_162[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int2) >> 16) & 0xffff);
            TourqeNow_intarray_Byte2[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_162[1])) & 0xff);//want++
            TourqeNow_intarray_Byte2[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_162[1] >> 8)) & 0xff);//want++
                                                                                                          //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";

            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////angle
            string angle = "";
            UInt16[] angle_array = new UInt16[2];
            byte[] angle_array_Byte = new byte[2];
            angle = "";
            //angle = textBox13.Text.ToString(); ;
            byte[] dataaaa = BitConverter.GetBytes(int.Parse(textBox13.Text.ToString()));  // 預設是 Little-Endian
                                                         //   richTextBox1.Text += "angle_array=" + angle.ToString() + "\r\n";

            //angle_array[0] = (UInt16)((Convert.ToUInt16(angle)) & 0xff);
            //angle_array_Byte[0] = (Byte)((Convert.ToByte(angle_array[0])));//want++
        //    richTextBox1.Text += "angle_array Lbyte=" + angle_array_Byte[0].ToString() + "\r\n";

            //angle_array[1] = (UInt16)((Convert.ToUInt16(angle) >> 8) & 0xff);
            //angle_array_Byte[1] = (Byte)((Convert.ToByte(angle_array[1]) & 0xff));//want++
        //    richTextBox1.Text += "angle_array Hbyte=" + angle_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////speed

            string speed = "";
            UInt16[] speed_array = new UInt16[2];
            byte[] speed_array_Byte = new byte[2];
            speed = "";
            speed = textBox14.Text.ToString(); ;
       //     richTextBox1.Text += "speed_array=" + speed.ToString() + "\r\n";
         
            speed_array[0] = (UInt16)((Convert.ToUInt16(speed)) & 0xff);
            speed_array_Byte[0] = (Byte)((Convert.ToByte(speed_array[0])));//want++
       //     richTextBox1.Text += "speed_array Lbyte=" + speed_array_Byte[0].ToString() + "\r\n";


            speed_array[1] = (UInt16)((Convert.ToUInt16(speed) >> 8) & 0xff);
            speed_array_Byte[1] = (Byte)((Convert.ToByte(speed_array[1]) & 0xff));//want++
        //    richTextBox1.Text += "speed_array Hbyte=" + speed_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
        //    richTextBox1.Text += "ok_state=" + ok_state.ToString() + "\r\n";//ok_state
        //    richTextBox1.Text += "pagebutton_press=" + pagebutton_press.ToString() + "\r\n";//pagebutton Button
        //    richTextBox1.Text += "Barcode_press=" + Barcode_press.ToString() + "\r\n";//Barcode_press Button
        //    richTextBox1.Text += "Confirm_press=" + Confirm_press.ToString() + "\r\n";//Confirm_press Button

            ////////////////////////////////////////////////////////////
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 73;//資料數
            Form1.MainCommand[3] = 0;//頁數
           // Form1.MainCommand[4] = Title[0];//標頭檔名1
            if (radioButton29.Checked)
            {
                Form1.MainCommand[4] = 0;//無顯示
            }
            if (radioButton30.Checked)
            {
                Form1.MainCommand[4] = 1;//Data Full
            }
            if (radioButton31.Checked)
            {
                Form1.MainCommand[4] = 2;//Setting...
            }
            if (radioButton9.Checked)
            {
                Form1.MainCommand[4] = 3;//Data upload
            }
            Button1[0] = 2;//page
            Button2[0] = 10;//barcode
            Button3[0] = 5;//confirm
            Form1.MainCommand[5] = Button1[0];//page
            Form1.MainCommand[6] = Button2[0];//barcode
            Form1.MainCommand[7] = Button3[0];//confirm
     
            if (radioButton1.Checked)
            {
                Form1.MainCommand[8] = 0x00;//
            }
            if (radioButton2.Checked)
            {
                Form1.MainCommand[8] = 0x01;
            }
            if (radioButton10.Checked)
            {
                Form1.MainCommand[8] = 0x02;
            }
            if (radioButton11.Checked)
            {
                Form1.MainCommand[8] = 0x10;
            }
            if (radioButton12.Checked)
            {
                Form1.MainCommand[8] = 0x20;
            }
            if (radioButton13.Checked)
            {
                Form1.MainCommand[8] = 0x40;
            }
            if (radioButton14.Checked)
            {
                Form1.MainCommand[8] = 0x80;
            }

            if (radioButton3.Checked)
            {
                Form1.MainCommand[9] = 7;//1;//顯示蜂鳴器開
            }
            else
            {
                Form1.MainCommand[9] = 0;//不顯示蜂鳴器
            }
            Form1.MainCommand[10] = bata[0];//電量
            Form1.MainCommand[11] = Jobarray[0];//Job_ID
            Form1.MainCommand[12] = SeqNowarray[0];//Seq_Current
            Form1.MainCommand[13] = SeqTotalarray[0];//Seq_Sum
            Form1.MainCommand[14] = StepNowarray[0];//Step_Current
            Form1.MainCommand[15] = StepTotalarray[0];//Step_Sum
            Form1.MainCommand[16] = CounterNowarray[0];//Counter_Current
            Form1.MainCommand[17] = CounterTotalarray[0];//Counter_Sum
            if (radioButton5.Checked)
            {
                Form1.MainCommand[18] = 0; //Kgf.m
            }
            if (radioButton6.Checked)
            {
                Form1.MainCommand[18] = 1;//N.m
            }
            if (radioButton7.Checked)
            {
                Form1.MainCommand[18] = 2;//Kgf.cm
            }
            if (radioButton8.Checked)
            {
                Form1.MainCommand[18] = 3;//In.lbs
                                          /////////////////////////////////////////


            }
            if (radioButton32.Checked)
            {
                Form1.MainCommand[18] = 4;//cN.m
                                          /////////////////////////////////////////


            }
            ///
            UInt32[] TourqeNow_intarray32 = new UInt32[2];
            TourqeNow_int = "";
            TourqeNow_int = textBox11.Text.ToString();


            TourqeNow_intarray32[0] = (UInt32)((Convert.ToUInt32(TourqeNow_int)));

          //  richTextBox1.Text += "TourqeNow_intarray32=" + TourqeNow_intarray32[0].ToString() + "\r\n";//Confirm_press Button


            UInt32[] TourqeNow_floatarray32 = new UInt32[2];

            TourqeNow_int = "";
           


         //   TourqeNow_floatarray32[0] = (UInt32)((Convert.ToUInt32(TourqeNow_int)));

        //    richTextBox1.Text += "TourqeNow_floatarray32=" + TourqeNow_floatarray32[0].ToString() + "\r\n";//Confirm_press Button
            UInt64[] TourqeNow_array64 = new UInt64[2];

        //    TourqeNow_array64[0] = (UInt64)(TourqeNow_intarray32[0] * 10000) + (UInt64)TourqeNow_floatarray32[0];
      //      richTextBox1.Text += "TourqeNow_array64=" + TourqeNow_array64[0].ToString() + "\r\n";//Confirm_press Button
            /////////////////////////////////////////



            Form1.MainCommand[19] = TourqeNow_intarray_Byte[0];//Tourqe_LSB
            Form1.MainCommand[20] = TourqeNow_intarray_Byte[1];//Tourqe_H1
            Form1.MainCommand[21] = TourqeNow_intarray_Byte[2];//;//Tourqe_H2
            Form1.MainCommand[22] = TourqeNow_intarray_Byte[3];//Tourqe_MSB

            ////////////////////////////////////////////////////////////////////
            /// UInt32[] TourqeNow_intarray32 = new UInt32[2];
            TourqeNow_int = "";
            TourqeNow_int = textBox12.Text.ToString();


            TourqeNow_intarray32[0] = (UInt32)((Convert.ToUInt32(TourqeNow_int)));

            //  richTextBox1.Text += "TourqeNow_intarray32=" + TourqeNow_intarray32[0].ToString() + "\r\n";//Confirm_press Button


            UInt32[] TourqeNow_floatarray32222 = new UInt32[2];

            TourqeNow_int = "";



            //   TourqeNow_floatarray32[0] = (UInt32)((Convert.ToUInt32(TourqeNow_int)));

            //    richTextBox1.Text += "TourqeNow_floatarray32=" + TourqeNow_floatarray32[0].ToString() + "\r\n";//Confirm_press Button
            UInt64[] TourqeNow_array64222 = new UInt64[2];

            //    TourqeNow_array64[0] = (UInt64)(TourqeNow_intarray32[0] * 10000) + (UInt64)TourqeNow_floatarray32[0];
            //      richTextBox1.Text += "TourqeNow_array64=" + TourqeNow_array64[0].ToString() + "\r\n";//Confirm_press Button
            /////////////////////////////////////////



            Form1.MainCommand[23] = TourqeNow_intarray_Byte2[0];//Tourqe_LSB
            Form1.MainCommand[24] = TourqeNow_intarray_Byte2[1];//Tourqe_H1
            Form1.MainCommand[25] = TourqeNow_intarray_Byte2[2];//;//Tourqe_H2
            Form1.MainCommand[26] = TourqeNow_intarray_Byte2[3];//Tourqe_MSB
            ////////////////////////////////////////////////////////////////////
            Form1.MainCommand[27] = dataaaa[0];//Angle_L
            Form1.MainCommand[28] = dataaaa[1];//Angle_H
            Form1.MainCommand[29] = dataaaa[2];//Angle_H
            Form1.MainCommand[30] = dataaaa[3];//Angle_H
            Form1.MainCommand[31] = speed_array_Byte[0];//Speed_L
            Form1.MainCommand[32] = speed_array_Byte[1];//Speed_H
            if (radioButton15.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 2;
            }
            if (radioButton16.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 3;
            }
            if (radioButton17.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 4;
            }
            if (radioButton18.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 5;
            }
            if (radioButton19.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 6;
            }
            if (radioButton20.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 8;
            }
            if (radioButton21.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 9;
            }
            if (radioButton22.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 10;
            }
            if (radioButton23.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 11;
            }
            if (radioButton24.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 12;
            }
            if (radioButton25.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 14;
            }
            if (radioButton27.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 16;
            }
            if (radioButton28.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 18;
            }
            if (radioButton33.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 23;
            }
            if (radioButton34.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 24;
            }
            if (radioButton35.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 25;
            }
            if (radioButton36.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 26;
            }
            if (radioButton37.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 27;
            }
            if (radioButton38.Checked)
            {
                Form1.MainCommand[33] = (Byte)'C';
                Form1.MainCommand[34] = 32;
            }
            if (radioButton39.Checked)
            {
                Form1.MainCommand[33] = (Byte)'C';
                Form1.MainCommand[34] = 33;
            }
            if (radioButton40.Checked)
            {
                Form1.MainCommand[33] = (Byte)'C';
                Form1.MainCommand[34] = 35;
            }
            if (radioButton41.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 36;
            }
            if (radioButton42.Checked)
            {
                Form1.MainCommand[33] = (Byte)'E';
                Form1.MainCommand[34] = 37;
            }
            if (radioButton26.Checked)
            {
                Form1.MainCommand[33] = 0;
                Form1.MainCommand[34] = 0;
            }
            
            byte[] decBytes;
            decBytes = System.Text.Encoding.UTF8.GetBytes(textBox15.Text.ToString());
            
            Form1.MainCommand[35] = decBytes[0];
            if (textBox15.Text.ToString().Length<2)
            {
                Form1.MainCommand[36] = 0x20;
            }
            else
            {
                Form1.MainCommand[36] = decBytes[1];
            }
            if (textBox15.Text.ToString().Length <3)
            {
                Form1.MainCommand[37] = 0x20;
            }
            else
            {
                Form1.MainCommand[37] = decBytes[2];
            }
            if (textBox15.Text.ToString().Length < 4)
            {
                Form1.MainCommand[38] = 0x20;
            }
            else
            {
                Form1.MainCommand[38] = decBytes[3];
            }
            if (textBox15.Text.ToString().Length < 5)
            {
                Form1.MainCommand[39] = 0x20;
            }
            else
            {
                Form1.MainCommand[39] = decBytes[3];
            }

            if (textBox15.Text.ToString().Length < 6)
            {
                Form1.MainCommand[40] = 0x20;
            }
            else
            {
                Form1.MainCommand[40] = decBytes[4];
            }
            if (textBox15.Text.ToString().Length <7)
            {
                Form1.MainCommand[41] = 0x20;
            }
            else
            {
                Form1.MainCommand[41] = decBytes[5];
            }
            if (textBox15.Text.ToString().Length <8)
            {
                Form1.MainCommand[42] = 0x20;
            }
            else
            {
                Form1.MainCommand[42] = decBytes[7];
            }

            if (textBox15.Text.ToString().Length <9)
            {
                Form1.MainCommand[43] = 0x20;
            }
            else
            {
                Form1.MainCommand[43] = decBytes[8];
            }
            if (textBox15.Text.ToString().Length <10)
            {
                Form1.MainCommand[44] = 0x20;
            }
            else
            {
                Form1.MainCommand[44] = decBytes[9];
            }
            if (textBox15.Text.ToString().Length <11)
            {
                Form1.MainCommand[45] = 0x20;
            }
            else
            {
                Form1.MainCommand[45] = decBytes[10];
            }
            if (textBox15.Text.ToString().Length <12)
            {
                Form1.MainCommand[46] = 0x20;
            }
            else
            {
                Form1.MainCommand[46] = decBytes[11];
            }
            if (textBox15.Text.ToString().Length <13)
            {
                Form1.MainCommand[47] = 0x20;
            }
            else
            {
                Form1.MainCommand[47] = decBytes[12];
            }
            if (textBox15.Text.ToString().Length <14)
            {
                Form1.MainCommand[48] = 0x20;
            }
            else
            {
                Form1.MainCommand[48] = decBytes[13];
            }
            if (textBox15.Text.ToString().Length <15)
            {
                Form1.MainCommand[49] = 0x20;
            }
            else
            {
                Form1.MainCommand[49] = decBytes[14];
            }
            if (textBox15.Text.ToString().Length <16)
            {
                Form1.MainCommand[50] = 0x20;
            }
            else
            {
                Form1.MainCommand[50] = decBytes[15];
            }
            if (textBox15.Text.ToString().Length <17)
            {
                Form1.MainCommand[51] = 0x20;
            }
            else
            {
                Form1.MainCommand[51] = decBytes[16];
            }
            if (textBox15.Text.ToString().Length <18)
            {
                Form1.MainCommand[52] = 0x20;
            }
            else
            {
                Form1.MainCommand[52] = decBytes[17];
            }

            if (textBox15.Text.ToString().Length <19)
            {
                Form1.MainCommand[53] = 0x20;
            }
            else
            {
                Form1.MainCommand[53] = decBytes[18];
            }
            if (textBox15.Text.ToString().Length <20)
            {
                Form1.MainCommand[54] = 0x20;
            }
            else
            {
                Form1.MainCommand[54] = decBytes[19];
            }
            for ( i = 0; i < 20; i++)
            {
                Form1.MainCommand[i+55] = (byte)textBox16.Text[i]; // 或用 Encoding if needed
            }

            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            for (i = 2; i <= 74;i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[75] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            Form1.SendCommand = "";
            for (i = 0; i <= 75; i++)
            {
                richTextBox1.Text +=  Form1.MainCommand[i].ToString("X2") + " ";
          //      Form1.SendCommand += Form1.MainCommand[i].ToString("X2") + " ";
                // richTextBox1.Text += i+" "+Form1.MainCommand[i].ToString("X")+"\r\n";
                // richTextBox1.Text += i+" "+Form1.MainCommand[i].ToString("X")+" ";
                //  richTextBox1.Text += i + " " + Form1.MainCommand[i].ToString("X") + " ";
            }
           richTextBox1.Text += "\r\n#########################################################\r\n";
           ///////////////////////////////////////////////////////////////////////////////////////////////
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }
        public byte pagebutton_press=0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (pagebutton_press == 1)
                pagebutton_press = 0;
            else 
                pagebutton_press = 1;
        }
        public byte Barcode_press = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Barcode_press == 1)
                Barcode_press = 0;
            else
                Barcode_press = 1;
        }
        public byte Confirm_press = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (Confirm_press == 1)
                Confirm_press = 0;
            else
                Confirm_press = 1;
        }
        byte ok_state = 0;
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox15.ForeColor = Color.Black;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Red;
        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Data Full";
        }

        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Setting,,,";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label21.Text = "DT";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label21.Text = "";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
           
         
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "kgf.m";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "N.m";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "Kgf.cm";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "in-lbs";
        }
        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "cN.m";
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Text = "Date Upload";
        }

        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Green;
        }

        private void radioButton11_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox15.ForeColor = Color.Red;
        }

        private void radioButton12_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox15.ForeColor = Color.Green;
        }

        private void radioButton13_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox15.ForeColor = Color.Blue;
        }

        private void radioButton14_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox15.ForeColor = Color.Yellow;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton40_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton41_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton42_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton26_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
