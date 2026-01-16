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
    public partial class Page50 : Form
    {
        public Page50()
        {
            InitializeComponent();
        }

        private void Page50_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
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
           
            //////////////////////////////////////////////////////////
         
           
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 38;//資料數
            Form1.MainCommand[3] = 70;//頁數
           // Form1.MainCommand[4] = Title[0];//標頭檔名1
            if (radioButton1.Checked)
            {
                Form1.MainCommand[4] = 0;//無顯示
            }
            if (radioButton2.Checked)
            {
                Form1.MainCommand[4] = 1;//NetWork AP Information
            }
           
            Button1[0] = 2;//page up
            Button2[0] = 3;//page down
            Button3[0] = 6;//enter
            Form1.MainCommand[5] = Button1[0];//page up
            Form1.MainCommand[6] = Button2[0];//page down
            Form1.MainCommand[7] = Button3[0];//enter
         


            byte[] array = System.Text.Encoding.ASCII.GetBytes(textBox1.Text.ToString());
            int asciicode = (int)(array[0]);
            Form1.MainCommand[8] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox2.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[9] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox3.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[10] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox4.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[11] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox5.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[12] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox6.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[13] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox7.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[14] = (Byte)asciicode;//ssid1


            array = System.Text.Encoding.ASCII.GetBytes(textBox8.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[15] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox9.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[16] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox10.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[17] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox11.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[18] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox12.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[19] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox13.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[20] = (Byte)asciicode;//ssid1


            array = System.Text.Encoding.ASCII.GetBytes(textBox14.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[21] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox15.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[22] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox16.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[23] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox17.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[24] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox19.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[25] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox20.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[26] = (Byte)asciicode;//ssid1


            array = System.Text.Encoding.ASCII.GetBytes(textBox21.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[27] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox22.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[28] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox23.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[29] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox24.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[30] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox25.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[31] = (Byte)asciicode;//ssid1


            array = System.Text.Encoding.ASCII.GetBytes(textBox26.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[32] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox27.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[33] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox28.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[34] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox29.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[35] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox30.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[36] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox31.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[37] = (Byte)asciicode;//ssid1


            array = System.Text.Encoding.ASCII.GetBytes(textBox32.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[38] = (Byte)asciicode;//ssid1

            array = System.Text.Encoding.ASCII.GetBytes(textBox33.Text.ToString());
            asciicode = (int)(array[0]);
            Form1.MainCommand[39] = (Byte)asciicode;//ssid1

            /* Form1.MainCommand[10]= Convert.ToByte(textBox2.Text.ToString());//ssid2
             Form1.MainCommand[11]= Convert.ToByte(textBox3.Text.ToString());//ssid3
             Form1.MainCommand[12]= Convert.ToByte(textBox4.Text.ToString());//ssid4
             Form1.MainCommand[13]= Convert.ToByte(textBox5.Text.ToString());//ssid5
             Form1.MainCommand[14]= Convert.ToByte(textBox6.Text.ToString());//ssid6
             Form1.MainCommand[15]= Convert.ToByte(textBox7.Text.ToString());//ssid7
             Form1.MainCommand[16]= Convert.ToByte(textBox8.Text.ToString());//ssid8
             Form1.MainCommand[17]= Convert.ToByte(textBox9.Text.ToString());//ssid9
             Form1.MainCommand[18]= Convert.ToByte(textBox10.Text.ToString());//ssid10
             Form1.MainCommand[19]= Convert.ToByte(textBox11.Text.ToString());//ssid11
             Form1.MainCommand[20]= Convert.ToByte(textBox12.Text.ToString());//ssid12
             Form1.MainCommand[21]= Convert.ToByte(textBox13.Text.ToString());//ssid13
             Form1.MainCommand[22]= Convert.ToByte(textBox14.Text.ToString());//ssid14
             Form1.MainCommand[23]= Convert.ToByte(textBox15.Text.ToString());//ssid15
             Form1.MainCommand[24]= Convert.ToByte(textBox16.Text.ToString());//ssid16
             Form1.MainCommand[25]= Convert.ToByte(textBox17.Text.ToString());//ssid17
             Form1.MainCommand[26]= Convert.ToByte(textBox18.Text.ToString());//ssid18
             Form1.MainCommand[27]= Convert.ToByte(textBox19.Text.ToString());//ssid19
             Form1.MainCommand[28]= Convert.ToByte(textBox20.Text.ToString());//ssid20
             Form1.MainCommand[29]= Convert.ToByte(textBox21.Text.ToString());//ssid21
             Form1.MainCommand[30]= Convert.ToByte(textBox22.Text.ToString());//ssid22
             Form1.MainCommand[31]= Convert.ToByte(textBox23.Text.ToString());//ssid23
             Form1.MainCommand[32]= Convert.ToByte(textBox24.Text.ToString());//ssid24
             Form1.MainCommand[33]= Convert.ToByte(textBox25.Text.ToString());//ssid25
             Form1.MainCommand[34]= Convert.ToByte(textBox26.Text.ToString());//ssid26
             Form1.MainCommand[35]= Convert.ToByte(textBox27.Text.ToString());//ssid27
             Form1.MainCommand[36]= Convert.ToByte(textBox28.Text.ToString());//ssid28
             Form1.MainCommand[37]= Convert.ToByte(textBox29.Text.ToString());//ssid29
             Form1.MainCommand[38]= Convert.ToByte(textBox30.Text.ToString());//ssid30
             Form1.MainCommand[39]= Convert.ToByte(textBox31.Text.ToString());//ssid31
             Form1.MainCommand[40]= Convert.ToByte(textBox32.Text.ToString());//ssid32
             */
            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            for (i = 2; i <= 39;i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[40] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            for (i = 0; i <= 40; i++)
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
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox34.Text = "";

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox34.Text = "Pg_Net_AP_Info_0";
        }
    }
}
