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
    public partial class Pg_Net_Info : Form
    {
        public Pg_Net_Info()
        {
            InitializeComponent();
        }

        private void Pg_Net_Info_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            radioButton5.Checked = true;
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
                //    richTextBox1.Text += str111.ToString()[i];
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
               
         //     richTextBox1.Text += Applinkarray[i]+" ";
             }
        //    richTextBox1.Text += "\r\n";
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
              //      richTextBox1.Text += str222.ToString()[i];
                    datauploand[i] = Convert.ToByte(str222[i]);  //want++
                }

                else
                {
              //      richTextBox1.Text += '0';
                    datauploand[i] = Convert.ToByte('0'); //want++
                }
               
               

            }
         //   richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {

           //     richTextBox1.Text += datauploand[i] + " ";
            }
         //   richTextBox1.Text += "\r\n";
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
         //   richTextBox1.Text += "batt=" + batt.ToString() + "\r\n";
            bata[0]= Convert.ToByte(batt);//want++
                                        //////////////////////////////////////////////////////////
                                        ////////////////////////////////////////////////////////Job
            string Job = "";
            byte[] Jobarray = new byte[2];
            Job = "";
            Job = textBox4.Text.ToString();
       //     richTextBox1.Text += "Job=" + Job.ToString() + "\r\n";
            Jobarray[0] = Convert.ToByte(Job); ;//want++
            //////////////////////////////////////////////////////////
            /// ////////////////////////////////////////////////////////seq now
            string SeqNow = "";
            byte[] SeqNowarray = new byte[2];
            SeqNow = "";
            SeqNow = textBox5.Text.ToString();
       //     richTextBox1.Text += "SeqNow=" + SeqNow.ToString() + "\r\n";
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
       //     richTextBox1.Text += "StepNow=" + StepNow.ToString() + "\r\n";
            StepNowarray[0] = Convert.ToByte(StepNow); ;//want++
           //////////////////////////////////////////////////////////
          //////////////////////////////////////////////////////////////StepNow
            string StepTotal = "";
            byte[] StepTotalarray = new byte[2];
            StepTotal = "";
            StepTotal = textBox8.Text.ToString();
       //     richTextBox1.Text += "StepTotal=" + StepTotal.ToString() + "\r\n";
            StepTotalarray[0] = Convert.ToByte(StepTotal); ;//want++
            //////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////CounterNow
            string CounterNow = "";
            byte[] CounterNowarray = new byte[2];
            CounterNow = "";
            CounterNow = textBox9.Text.ToString();
       //     richTextBox1.Text += "CounterNow=" + CounterNow.ToString() + "\r\n";
            CounterNowarray[0] = Convert.ToByte(CounterNow);//want++
            //////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////CounterTotal
            string CounterTotal = "";
            byte[] CounterTotalarray = new byte[2];
            CounterTotal = "";
            CounterTotal = textBox10.Text.ToString();
       //     richTextBox1.Text += "CounterTotalarray=" + CounterTotal.ToString() + "\r\n";
            CounterTotalarray[0] = Convert.ToByte(CounterTotal); ;//want++
            //////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////TourqeNow_int
            string TourqeNow_int = "";
            UInt16[] TourqeNow_intarray = new UInt16[2];
            byte[] TourqeNow_intarray_Byte = new byte[2];
            TourqeNow_int = "";
            TourqeNow_int = textBox11.Text.ToString();
       //     richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";
           
            TourqeNow_intarray[0] = (UInt16)((Convert.ToUInt16(TourqeNow_int) ) & 0xff);
            TourqeNow_intarray_Byte[0] = (Byte)((Convert.ToByte(TourqeNow_intarray[0]) ));//want++
    //        richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";


            TourqeNow_intarray[1] = (UInt16)((Convert.ToUInt16(TourqeNow_int) >> 8) & 0xff);
            TourqeNow_intarray_Byte[1] = (Byte)((Convert.ToByte(TourqeNow_intarray[1]) & 0xff));//want++
      //      richTextBox1.Text += "TourqeNow_int Hbyte=" + TourqeNow_intarray_Byte[1].ToString() + "\r\n";

            //////////////////////////////////////////////////////////TourqeNow_float
            string TourqeNow_float = "";
            UInt16[] TourqeNow_floatarray = new UInt16[2];
            byte[] TourqeNow_floatarray_Byte = new byte[2];
            TourqeNow_float = "";
            TourqeNow_float = textBox12.Text.ToString();
     //       richTextBox1.Text += "TourqeNow_float=" + TourqeNow_float.ToString() + "\r\n";
           
            TourqeNow_floatarray[0] = (UInt16)((Convert.ToUInt16(TourqeNow_float)) & 0xff);
            TourqeNow_floatarray_Byte[0] = (Byte)((Convert.ToByte(TourqeNow_floatarray[0])));//want++
    //        richTextBox1.Text += "TourqeNow_float Lbyte=" + TourqeNow_floatarray_Byte[0].ToString() + "\r\n";

            TourqeNow_floatarray[1] = (UInt16)((Convert.ToUInt16(TourqeNow_float) >> 8) & 0xff);
            TourqeNow_floatarray_Byte[1] = (Byte)((Convert.ToByte(TourqeNow_floatarray[1]) & 0xff));//want++
      //      richTextBox1.Text += "TourqeNow_float Hbyte=" + TourqeNow_floatarray[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////angle
            string angle = "";
            UInt16[] angle_array = new UInt16[2];
            byte[] angle_array_Byte = new byte[2];
            angle = "";
            angle = textBox13.Text.ToString(); ;
      //      richTextBox1.Text += "angle_array=" + angle.ToString() + "\r\n";
            
            angle_array[0] = (UInt16)((Convert.ToUInt16(angle)) & 0xff);
            angle_array_Byte[0] = (Byte)((Convert.ToByte(angle_array[0])));//want++
     //       richTextBox1.Text += "angle_array Lbyte=" + angle_array_Byte[0].ToString() + "\r\n";

            angle_array[1] = (UInt16)((Convert.ToUInt16(angle) >> 8) & 0xff);
            angle_array_Byte[1] = (Byte)((Convert.ToByte(angle_array[1]) & 0xff));//want++
      //      richTextBox1.Text += "angle_array Hbyte=" + angle_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////speed

            string speed = "";
            UInt16[] speed_array = new UInt16[2];
            byte[] speed_array_Byte = new byte[2];
            speed = "";
            speed = textBox14.Text.ToString(); ;
     //       richTextBox1.Text += "speed_array=" + speed.ToString() + "\r\n";
         
            speed_array[0] = (UInt16)((Convert.ToUInt16(speed)) & 0xff);
            speed_array_Byte[0] = (Byte)((Convert.ToByte(speed_array[0])));//want++
      //      richTextBox1.Text += "speed_array Lbyte=" + speed_array_Byte[0].ToString() + "\r\n";


            speed_array[1] = (UInt16)((Convert.ToUInt16(speed) >> 8) & 0xff);
            speed_array_Byte[1] = (Byte)((Convert.ToByte(speed_array[1]) & 0xff));//want++
       //     richTextBox1.Text += "speed_array Hbyte=" + speed_array_Byte[1].ToString() + "\r\n";

            ////////////////////////////////////////////////////////////
            string Port111 = "";
            UInt16[] Port111array = new UInt16[2];
            byte[] Port111array_Byte = new byte[2];
            Port111 = "";
            Port111 = textBox25.Text.ToString();
    //        richTextBox1.Text += "Port111=" + Port111.ToString() + "\r\n";

            Port111array[0] = (UInt16)((Convert.ToUInt16(Port111)) & 0xff);
            Port111array_Byte[0] = (Byte)((Convert.ToByte(Port111array[0])));//want++
   //         richTextBox1.Text += "Port111 Lbyte=" + Port111array_Byte[0].ToString() + "\r\n";


            Port111array[1] = (UInt16)((Convert.ToUInt16(Port111) >> 8) & 0xff);
            Port111array_Byte[1] = (Byte)((Convert.ToByte(Port111array[1]) & 0xff));//want++
     //       richTextBox1.Text += "Port111 Hbyte=" + Port111array_Byte[1].ToString() + "\r\n";

            //////////////////////////////////////////////////////////
     //       richTextBox1.Text += "ok_state=" + ok_state.ToString() + "\r\n";//ok_state
     //       richTextBox1.Text += "pagebutton_press=" + pagebutton_press.ToString() + "\r\n";//pagebutton Button
     //       richTextBox1.Text += "Barcode_press=" + Barcode_press.ToString() + "\r\n";//Barcode_press Button
    //        richTextBox1.Text += "Confirm_press=" + Confirm_press.ToString() + "\r\n";//Confirm_press Button

            ////////////////////////////////////////////////////////////
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 31;//資料數
            Form1.MainCommand[3] = 60;//頁數
           // Form1.MainCommand[4] = Title[0];//標頭檔名1
            if (radioButton1.Checked)
            {
                Form1.MainCommand[4] = 0;//無顯示
            }
            if (radioButton2.Checked)
            {
                Form1.MainCommand[4] = 1;//Network Information
            }
           
            Button1[0] = 2;//page up
            Button2[0] = 3;//page down
            Button3[0] = 6;//enter
            Form1.MainCommand[5] = Button1[0];//page up
            Form1.MainCommand[6] = Button2[0];//page down
            Form1.MainCommand[7] = Button3[0];//enter
         
            if (radioButton3.Checked)
            {
                Form1.MainCommand[8] = 1;//1:Static (AP)
            }

            if (radioButton4.Checked)
            {
                Form1.MainCommand[8] = 2;//2:DHCP (AP)
            }

            if (radioButton5.Checked)
            {
                Form1.MainCommand[8] = 3;//3:Static (STA)
            }

            if (radioButton6.Checked)
            {
                Form1.MainCommand[8] = 4;//4:DHCP  (STA)
            }
            Form1.MainCommand[9]=Convert.ToByte(textBox2.Text.ToString());//tool ip1
            Form1.MainCommand[10] = Convert.ToByte(textBox3.Text.ToString());//tool ip2
            Form1.MainCommand[11] = Convert.ToByte(textBox4.Text.ToString());//tool ip3
            Form1.MainCommand[12] = Convert.ToByte(textBox5.Text.ToString());//tool ip4

            Form1.MainCommand[13] = Convert.ToByte(textBox6.Text.ToString());//GW1
            Form1.MainCommand[14] = Convert.ToByte(textBox7.Text.ToString());//GW2
            Form1.MainCommand[15] = Convert.ToByte(textBox8.Text.ToString());//GW3
            Form1.MainCommand[16] = Convert.ToByte(textBox9.Text.ToString());//GW4
            Form1.MainCommand[17] = Convert.ToByte(textBox10.Text.ToString());//NM1
            Form1.MainCommand[18] = Convert.ToByte(textBox11.Text.ToString());//NM2
            Form1.MainCommand[19] = Convert.ToByte(textBox12.Text.ToString());//NM3
            Form1.MainCommand[20] = Convert.ToByte(textBox13.Text.ToString());//NM4
            string delimiter = " "; //default is space, can be changed by user
                                            // strip the input of all delimiter characters and the optional 0x prefix
        string data = textBox14.Text.Replace("0x", "").Replace(@"\n", "0A").Replace(@"\r", "0D").Replace(delimiter, "").Replace(",", "").Replace(" ", "").ToUpper();

            // check for invalid characters
            string invalidChars = "";
            for (i = 0; i < 2; i++)
            {
                if (!Char.IsDigit(data[i]) && !(data[i] >= 'A' && data[i] <= 'F'))
                {
                    if (invalidChars.IndexOf(data[i]) == -1)
                    {
                        invalidChars += data[i];
                    }
                }
            }


            // convert the hex characters to a byte array
            byte[] buffer = new byte[data.Length / 2 + 1];
            for (i = 0; i < data.Length; i += 2)
            {
                buffer[i / 2] = byte.Parse(data.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            Form1.MainCommand[21] = buffer[0];//mac1
            /////////////////////////////////////////////////////
            // strip the input of all delimiter characters and the optional 0x prefix
            data = textBox15.Text.Replace("0x", "").Replace(@"\n", "0A").Replace(@"\r", "0D").Replace(delimiter, "").Replace(",", "").Replace(" ", "").ToUpper();

            // check for invalid characters
            invalidChars = "";
            for (i = 0; i < 2; i++)
            {
                if (!Char.IsDigit(data[i]) && !(data[i] >= 'A' && data[i] <= 'F'))
                {
                    if (invalidChars.IndexOf(data[i]) == -1)
                    {
                        invalidChars += data[i];
                    }
                }
            }


            // convert the hex characters to a byte array
             buffer = new byte[data.Length / 2 + 1];
            for (i = 0; i < data.Length; i += 2)
            {
                buffer[i / 2] = byte.Parse(data.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            Form1.MainCommand[22] = buffer[0];//mac2
            /////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            // strip the input of all delimiter characters and the optional 0x prefix
            data = textBox16.Text.Replace("0x", "").Replace(@"\n", "0A").Replace(@"\r", "0D").Replace(delimiter, "").Replace(",", "").Replace(" ", "").ToUpper();

            // check for invalid characters
            invalidChars = "";
            for (i = 0; i < 2; i++)
            {
                if (!Char.IsDigit(data[i]) && !(data[i] >= 'A' && data[i] <= 'F'))
                {
                    if (invalidChars.IndexOf(data[i]) == -1)
                    {
                        invalidChars += data[i];
                    }
                }
            }


            // convert the hex characters to a byte array
            buffer = new byte[data.Length / 2 + 1];
            for (i = 0; i < data.Length; i += 2)
            {
                buffer[i / 2] = byte.Parse(data.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            Form1.MainCommand[23] = buffer[0];//mac3
            /////////////////////////////////////////////////////
            ///  /////////////////////////////////////////////////////
            // strip the input of all delimiter characters and the optional 0x prefix
            data = textBox17.Text.Replace("0x", "").Replace(@"\n", "0A").Replace(@"\r", "0D").Replace(delimiter, "").Replace(",", "").Replace(" ", "").ToUpper();

            // check for invalid characters
           invalidChars = "";
            for (i = 0; i < 2; i++)
            {
                if (!Char.IsDigit(data[i]) && !(data[i] >= 'A' && data[i] <= 'F'))
                {
                    if (invalidChars.IndexOf(data[i]) == -1)
                    {
                        invalidChars += data[i];
                    }
                }
            }


            // convert the hex characters to a byte array
            buffer = new byte[data.Length / 2 + 1];
            for (i = 0; i < data.Length; i += 2)
            {
                buffer[i / 2] = byte.Parse(data.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            Form1.MainCommand[24] = buffer[0];//mac4
            /////////////////////////////////////////////////////
            // strip the input of all delimiter characters and the optional 0x prefix
           data = textBox19.Text.Replace("0x", "").Replace(@"\n", "0A").Replace(@"\r", "0D").Replace(delimiter, "").Replace(",", "").Replace(" ", "").ToUpper();

            // check for invalid characters
            invalidChars = "";
            for (i = 0; i < 2; i++)
            {
                if (!Char.IsDigit(data[i]) && !(data[i] >= 'A' && data[i] <= 'F'))
                {
                    if (invalidChars.IndexOf(data[i]) == -1)
                    {
                        invalidChars += data[i];
                    }
                }
            }


            // convert the hex characters to a byte array
             buffer = new byte[data.Length / 2 + 1];
            for (i = 0; i < data.Length; i += 2)
            {
                buffer[i / 2] = byte.Parse(data.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            Form1.MainCommand[25] = buffer[0];//mac5
            ////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////
            // strip the input of all delimiter characters and the optional 0x prefix
            data = textBox20.Text.Replace("0x", "").Replace(@"\n", "0A").Replace(@"\r", "0D").Replace(delimiter, "").Replace(",", "").Replace(" ", "").ToUpper();

            // check for invalid characters
            invalidChars = "";
            for ( i = 0; i < 2; i++)
            {
                if (!Char.IsDigit(data[i]) && !(data[i] >= 'A' && data[i] <= 'F'))
                {
                    if (invalidChars.IndexOf(data[i]) == -1)
                    {
                        invalidChars += data[i];
                    }
                }
            }
          

            // convert the hex characters to a byte array
            buffer = new byte[data.Length / 2 + 1];
            for ( i = 0; i < data.Length; i += 2)
            {
                buffer[i / 2] = byte.Parse(data.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            ////////////////////////////////////////////////////////
 
           
            
            Form1.MainCommand[26] = buffer[0];//mac6

            Form1.MainCommand[27] = Convert.ToByte(textBox21.Text.ToString());//sip1
            Form1.MainCommand[28] = Convert.ToByte(textBox22.Text.ToString());//sip2
            Form1.MainCommand[29] = Convert.ToByte(textBox23.Text.ToString());//sip3
            Form1.MainCommand[30] = Convert.ToByte(textBox24.Text.ToString());//sip4
           
            Form1.MainCommand[31] = Port111array_Byte[0];
            Form1.MainCommand[32] = Port111array_Byte[1];
           
            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            for (i = 2; i <= 32;i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[33] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            for (i = 0; i <= 33; i++)
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
            label15.Text = "C1";
            label15.ForeColor = Color.Red;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "C2";
            label15.ForeColor = Color.Red;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "C3";
            label15.ForeColor = Color.Red;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "C4";
            label15.ForeColor = Color.Red;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "C5";
            label15.ForeColor = Color.Red;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "NSLA";
            label15.ForeColor = Color.Red;
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "NSHA";
            label15.ForeColor = Color.Red;
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "BS";
            label15.ForeColor = Color.Red;
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "OK";
            label15.ForeColor = Color.Green;
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "OKALL";
            label15.ForeColor = Color.Green;
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "NG-F";
            label15.ForeColor = Color.Red;
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "NG-Q";
            label15.ForeColor = Color.Red;
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "NG-C";
            label15.ForeColor = Color.Red;
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "E3";
            label15.ForeColor = Color.Red;
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "E4";
            label15.ForeColor = Color.Red;
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "E5";
            label15.ForeColor = Color.Red;
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "E7";
            label15.ForeColor = Color.Red;
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "E8";
            label15.ForeColor = Color.Red;
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "E9";
            label15.ForeColor = Color.Red;
        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {
            label15.Text = "Er";
            label15.ForeColor = Color.Red;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "N.m";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "Kgf.cm";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "Kgf.m";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "lbf.in";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox18.Text = "";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox18.Text = "Pg_Net_Info_0";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = "Static (AP)";
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = "DHCP (AP)";
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = "Static (STA)";
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = "DHCP(STA)";
            
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
