using SerialHex.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SerialHex
{
    public partial class Pg_Tool_Info : Form
    {
        public Pg_Tool_Info()
        {
            InitializeComponent();
        }

        private void Pg_Tool_Info_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            radioButton7.Checked = true;
            radioButton3.Checked = true;
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
            /*Ti = "";
            Ti = textBox18.Text.ToString();
            for (i = 0; i < 1; i++)
            {
                if (i < textBox18.TextLength)
                {
                    Title[i] = Convert.ToByte(Ti[i]); //want++
                    richTextBox1.Text += Ti.ToString()[i];
                }

                else
                {
                    Title[i] = Convert.ToByte('0'); //want++
                    richTextBox1.Text += Ti.ToString()[i];
                }

            }
            richTextBox1.Text += "\r\n";
            for (i = 0; i < 1; i++)
            {

                richTextBox1.Text += Title[i] + " ";
            }
            richTextBox1.Text += "\r\n";
            */
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
         //   richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {
               
          //    richTextBox1.Text += Applinkarray[i]+" ";
             }
         //   richTextBox1.Text += "\r\n";
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
             //       richTextBox1.Text += str222.ToString()[i];
                    datauploand[i] = Convert.ToByte(str222[i]);  //want++
                }

                else
                {
             //       richTextBox1.Text += '0';
                    datauploand[i] = Convert.ToByte('0'); //want++
                }
               
               

            }
        //    richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {

         //       richTextBox1.Text += datauploand[i] + " ";
            }
       //     richTextBox1.Text += "\r\n";
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
                                  //////////////////////////////////////////////////////////
                                        ////////////////////////////////////////////////////////Job
            string Job = "";
            byte[] Jobarray = new byte[2];
            Job = "";
            Job = textBox4.Text.ToString();
      //      richTextBox1.Text += "Job=" + Job.ToString() + "\r\n";
            Jobarray[0] = Convert.ToByte(Job); ;//want++
            //////////////////////////////////////////////////////////
            /// ////////////////////////////////////////////////////////seq now
            string SeqNow = "";
            byte[] SeqNowarray = new byte[2];
            SeqNow = "";
           // SeqNow = textBox5.Text.ToString();
     //       richTextBox1.Text += "SeqNow=" + SeqNow.ToString() + "\r\n";
           // SeqNowarray[0] = Convert.ToByte(SeqNow);//want++
            //////////////////////////////////////////////////////////
            ////// ////////////////////////////////////////////////////////seq total
            string SeqTotal = "";
            byte[] SeqTotalarray = new byte[2];
            SeqTotal = "";
            SeqTotal = textBox6.Text.ToString();
       //     richTextBox1.Text += "SeqTotal=" + SeqTotal.ToString() + "\r\n";
            SeqTotalarray[0] = Convert.ToByte(SeqTotal);//want++
            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////
       //     richTextBox1.Text += "ok_state=" + ok_state.ToString() + "\r\n";//ok_state
      //      richTextBox1.Text += "pagebutton_press=" + pagebutton_press.ToString() + "\r\n";//pagebutton Button
      //      richTextBox1.Text += "Barcode_press=" + Barcode_press.ToString() + "\r\n";//Barcode_press Button
      //      richTextBox1.Text += "Confirm_press=" + Confirm_press.ToString() + "\r\n";//Confirm_press Button

            ////////////////////////////////////////////////////////////
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 54;//資料數
            Form1.MainCommand[3] = 50;//頁數
           // Form1.MainCommand[4] = Title[0];//標頭檔名1
            if (radioButton1.Checked)
            {
                Form1.MainCommand[4] = 0;//無顯示
            }
            if (radioButton2.Checked)
            {
                Form1.MainCommand[4] = 1;//Tool information
            }
            
            Button1[0] = 2;//page up
            Button2[0] = 3;//page down
            Button3[0] = 6;//enter
            Form1.MainCommand[5] = Button1[0];//page up
            Form1.MainCommand[6] = Button2[0];//page down
            Form1.MainCommand[7] = Button3[0];//enter
        

            Form1.MainCommand[8]=Convert.ToByte(textBox1.Text.ToString());//fw1
            Form1.MainCommand[9] = Convert.ToByte(textBox2.Text.ToString());//fw2

            byte[] array = System.Text.Encoding.ASCII.GetBytes(textBox1.Text.ToString());
            int asciicode = (int)(array[0]);



            array = System.Text.Encoding.ASCII.GetBytes(textBox3.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[10] = (Byte)asciicode;//SN1

            array = System.Text.Encoding.ASCII.GetBytes(textBox7.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[11] = (Byte)asciicode;//SN2

            array = System.Text.Encoding.ASCII.GetBytes(textBox8.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[12] = (Byte)asciicode;//SN3

            array = System.Text.Encoding.ASCII.GetBytes(textBox9.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[13] = (Byte)asciicode;//SN4

            array = System.Text.Encoding.ASCII.GetBytes(textBox10.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[14] = (Byte)asciicode;//SN5


            array = System.Text.Encoding.ASCII.GetBytes(textBox11.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[15] = (Byte)asciicode;//SN6

            array = System.Text.Encoding.ASCII.GetBytes(textBox12.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[16] = (Byte)asciicode;//SN7

            array = System.Text.Encoding.ASCII.GetBytes(textBox13.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[17] = (Byte)asciicode;//SN8

            array = System.Text.Encoding.ASCII.GetBytes(textBox14.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[18] = (Byte)asciicode;//SN9

            array = System.Text.Encoding.ASCII.GetBytes(textBox15.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[19] = (Byte)asciicode;//SN10

            array = System.Text.Encoding.ASCII.GetBytes(textBox16.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[20] = (Byte)asciicode;//SN11

            array = System.Text.Encoding.ASCII.GetBytes(textBox17.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[21] = (Byte)asciicode;//SN12

            array = System.Text.Encoding.ASCII.GetBytes(textBox19.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[22] = (Byte)asciicode;//SN13

            array = System.Text.Encoding.ASCII.GetBytes(textBox20.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[23] = (Byte)asciicode;//SN14

            array = System.Text.Encoding.ASCII.GetBytes(textBox21.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[24] = (Byte)asciicode;//SN15

            array = System.Text.Encoding.ASCII.GetBytes(textBox22.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[25] = (Byte)asciicode;//SN16

            array = System.Text.Encoding.ASCII.GetBytes(textBox23.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[26] = (Byte)asciicode;//SN17

            array = System.Text.Encoding.ASCII.GetBytes(textBox24.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[27] = (Byte)asciicode;//SN18

            array = System.Text.Encoding.ASCII.GetBytes(textBox25.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[28] = (Byte)asciicode;//SN19


            array = System.Text.Encoding.ASCII.GetBytes(textBox26.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[29] = (Byte)asciicode;//SN20

            array = System.Text.Encoding.ASCII.GetBytes(textBox46.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[30] = (Byte)asciicode;//1

            array = System.Text.Encoding.ASCII.GetBytes(textBox45.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[31] = (Byte)asciicode;//2

            array = System.Text.Encoding.ASCII.GetBytes(textBox44.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[32] = (Byte)asciicode;//3

            array = System.Text.Encoding.ASCII.GetBytes(textBox43.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[33] = (Byte)asciicode;//4

            array = System.Text.Encoding.ASCII.GetBytes(textBox42.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[34] = (Byte)asciicode;//5

            array = System.Text.Encoding.ASCII.GetBytes(textBox41.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[35] = (Byte)asciicode;//6

            array = System.Text.Encoding.ASCII.GetBytes(textBox40.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[36] = (Byte)asciicode;//7

            array = System.Text.Encoding.ASCII.GetBytes(textBox39.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[37] = (Byte)asciicode;//8

            array = System.Text.Encoding.ASCII.GetBytes(textBox38.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[38] = (Byte)asciicode;//9

            array = System.Text.Encoding.ASCII.GetBytes(textBox37.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[39] = (Byte)asciicode;//10

            array = System.Text.Encoding.ASCII.GetBytes(textBox36.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[40] = (Byte)asciicode;//11

            array = System.Text.Encoding.ASCII.GetBytes(textBox35.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[41] = (Byte)asciicode;//12

            array = System.Text.Encoding.ASCII.GetBytes(textBox34.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[42] = (Byte)asciicode;//13

            array = System.Text.Encoding.ASCII.GetBytes(textBox33.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[43] = (Byte)asciicode;//14

            array = System.Text.Encoding.ASCII.GetBytes(textBox32.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[44] = (Byte)asciicode;//15

            array = System.Text.Encoding.ASCII.GetBytes(textBox31.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[45] = (Byte)asciicode;//16

            array = System.Text.Encoding.ASCII.GetBytes(textBox30.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[46] = (Byte)asciicode;//17

            array = System.Text.Encoding.ASCII.GetBytes(textBox29.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[47] = (Byte)asciicode;//18

            array = System.Text.Encoding.ASCII.GetBytes(textBox28.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[48] = (Byte)asciicode;//19

            array = System.Text.Encoding.ASCII.GetBytes(textBox27.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[49] = (Byte)asciicode;//20


            if (radioButton7.Checked)
            {
                Form1.MainCommand[50] = Convert.ToByte(textBox4.Text.ToString()); //PCB
            }
            string aan = "128";
            if (radioButton8.Checked)
            {
                Form1.MainCommand[50] = unchecked((byte)-int.Parse((textBox4.Text.ToString())));
               
            }

            if (radioButton3.Checked)
            {
                Form1.MainCommand[51] = Convert.ToByte(textBox6.Text.ToString());
            }

            if (radioButton12.Checked)
            {
               
                Form1.MainCommand[51] = unchecked((byte)-int.Parse((textBox6.Text.ToString())));
            }

            UInt32[] TourqeNow_intarray32 = new UInt32[2];
            string TourqeNow_int = "";
            UInt16[] TourqeNow_intarray = new UInt16[2];
            byte[] TourqeNow_intarray_Byte = new byte[2];
            TourqeNow_int = "";
            TourqeNow_int = textBox5.Text.ToString();


            TourqeNow_intarray32[0] = (UInt32)((Convert.ToUInt32(TourqeNow_int)));

            //   richTextBox1.Text += "TourqeNow_intarray32=" + TourqeNow_intarray32[0].ToString() + "\r\n";//Confirm_press Button



          //  string TourqeNow_int = "";
            UInt64[] TourqeNow_intarray64 = new UInt64[4];
            UInt32[] TourqeNow_intarray_32 = new UInt32[4];
            UInt16[] TourqeNow_intarray_16 = new UInt16[4];
            Byte[] TourqeNow_intarray_Byte222 = new Byte[4];
            TourqeNow_int = "";
            TourqeNow_int = textBox5.Text.ToString();



            //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

            TourqeNow_intarray_16[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int)) & 0xffff);
            TourqeNow_intarray_Byte222[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[0])) & 0xff);//want++
            TourqeNow_intarray_Byte222[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[0] >> 8)) & 0xff);//want++
            TourqeNow_intarray_16[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int) >> 16) & 0xffff);
            TourqeNow_intarray_Byte222[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[1])) & 0xff);//want++
            TourqeNow_intarray_Byte222[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[1] >> 8)) & 0xff);//want++

            //  


            Form1.MainCommand[52] = TourqeNow_intarray_Byte222[0];
            Form1.MainCommand[53] = TourqeNow_intarray_Byte222[1];
            Form1.MainCommand[54] = TourqeNow_intarray_Byte222[2];
            Form1.MainCommand[55] = TourqeNow_intarray_Byte222[3];




            

          


            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            for (i = 2; i <= 55;i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[56] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            for (i = 0; i <= 56; i++)
            {
                richTextBox1.Text +=  Form1.MainCommand[i].ToString("X2") + " ";
                // richTextBox1.Text += i+" "+Form1.MainCommand[i].ToString("X")+"\r\n";
                // richTextBox1.Text += i+" "+Form1.MainCommand[i].ToString("X")+" ";
                //  richTextBox1.Text += i + " " + Form1.MainCommand[i].ToString("X") + " ";
            }
            richTextBox1.Text += "\r\n#########################################################\r\n";
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
            textBox1.ForeColor = Color.Green;
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
            label21.Text = "Buzzer On";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label21.Text = "Mute";
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
            ;
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
           
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox18.Text = "";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox18.Text = "Pg_Tool_Info_0";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
           
            
        }

        private void radioButton7_CheckedChanged_1(object sender, EventArgs e)
        {
            label13.Text = "";
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
            label13.Text = "-";
        }

        private void radioButton9_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {
          
        }

        private void radioButton11_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioButton12_CheckedChanged_1(object sender, EventArgs e)
        {
            label14.Text = "-";
        }

        private void radioButton3_CheckedChanged_2(object sender, EventArgs e)
        {
            label14.Text = "";
        }
    }
}
