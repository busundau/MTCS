using SerialHex.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SerialHex
{
    public partial class Pg_Language : Form
    {
        public Pg_Language()
        {
            InitializeComponent();
        }
        byte[] Default_Item_P = new byte[2];
        byte[] Item_P = new byte[2];
        Byte aa, bb, cc;
        private void Pg_Language_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            radioButton17.Checked = true;
            radioButton3.Checked = true;
            radioButton7.Checked = true;
            radioButton11.Checked = true;
            radioButton14.Checked = true;
            radioButton22.Checked = true;
            radioButton15.Checked = true;
            radioButton8.Checked = true;

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
           /* Ti = "";
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
           
            //////////////////////////////////////////////////////////
          //  richTextBox1.Text += "ok_state=" + ok_state.ToString() + "\r\n";//ok_state
          //  richTextBox1.Text += "pagebutton_press=" + pagebutton_press.ToString() + "\r\n";//pagebutton Button
          //  richTextBox1.Text += "Barcode_press=" + Barcode_press.ToString() + "\r\n";//Barcode_press Button
         //   richTextBox1.Text += "Confirm_press=" + Confirm_press.ToString() + "\r\n";//Confirm_press Button

            ////////////////////////////////////////////////////////////
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 9;//資料數
            if(radioButton17.Checked)
            Form1.MainCommand[3] = 10;//頁數

            if (radioButton18.Checked)
                Form1.MainCommand[3] = 11;//頁數


                                          // Form1.MainCommand[4] = Title[0];//標頭檔名1
            if (radioButton1.Checked)
            {
                Form1.MainCommand[4] = 0;//無顯示
            }
            if (radioButton2.Checked)
            {
                Form1.MainCommand[4] = 1;//Language
            }

            Button1[0] = 1;//2;//page up
            Button2[0] = 8;//3;//page down
            Button3[0] = 7;//6;//enter


         




            Form1.MainCommand[5] = Button1[0];//page up
            Form1.MainCommand[6] = Button2[0];//page down
            Form1.MainCommand[7] = Button3[0];//enter

            if (radioButton4.Checked)
            {
               // Form1.MainCommand[8] = 0x00;
                aa = 0;
            }

            if (radioButton10.Checked) // blue Default Reset_item_P
            {
               // Form1.MainCommand[8] = 0x01;
                aa = 1;
            }

            if (radioButton5.Checked)//red Default Reset_item_P
            {
               // Form1.MainCommand[8] = 0x2;
                aa = 2;
            }

            if (radioButton3.Checked)// gray Default Reset_item_P
            {
              //  Form1.MainCommand[8] = 0x3;
                aa = 3;
            }
            if (radioButton6.Checked)//  Default Reset_item_P no font
            {
                bb = 9;
            }

            if (radioButton7.Checked)// Default Reset_item_P show font
            {
                bb = 0;
            }
            cc = (Byte)(aa + bb);
            Form1.MainCommand[8] = cc;
            ////////////////////////////////
            if (radioButton12.Checked)
            {
               // Form1.MainCommand[9] = 0x00;
                aa = 0;
            }

            if (radioButton14.Checked) // blue Default Reset_item_P
            {
               // Form1.MainCommand[9] = 0x01;
                aa = 1;
            }

            if (radioButton13.Checked)//red Default Reset_item_P
            {
               // Form1.MainCommand[9] = 0x2;
                aa = 2;
            }

            if (radioButton11.Checked)// gray Default Reset_item_P
            {
               // Form1.MainCommand[9] = 0x3;
                aa = 3;
            }
            if (radioButton9.Checked)//  Default Reset_item_P no font
            {
               // Form1.MainCommand[9] = 0x9;
                bb = 9;
            }

            if (radioButton8.Checked)// Default Reset_item_P show font
            {
               // Form1.MainCommand[9] = 0x0;
                bb = 0;
            }
            cc = (Byte)(aa + bb);
            Form1.MainCommand[9] = cc;

            ////////////////////////////////
            if (radioButton20.Checked)
            {
              //  Form1.MainCommand[10] = 0x00;
                aa = 0;
            }

            if (radioButton22.Checked) // blue Default Reset_item_P
            {
               // Form1.MainCommand[10] = 0x01;
                aa = 1;
            }

            if (radioButton21.Checked)//red Default Reset_item_P
            {
               // Form1.MainCommand[10] = 0x2;
                aa = 2;
            }

            if (radioButton19.Checked)// gray Default Reset_item_P
            {
               // Form1.MainCommand[10] = 0x3;
                aa = 3;
            }
            if (radioButton16.Checked)//  Default Reset_item_P no font
            {
              //  Form1.MainCommand[10] = 0x9;
                bb = 9;
            }

            if (radioButton15.Checked)// Default Reset_item_P show font
            {
                //Form1.MainCommand[10] = 0x0;
                bb = 0;
            }
            cc = (Byte)(aa + bb);
            Form1.MainCommand[10] = cc;


            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            for (i = 2; i <= 10;i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[11] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            for (i = 0; i <= 11; i++)
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
            textBox18.Text = "Language";
        }

        private void radioButton7_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                panel4.BackColor = Color.AliceBlue;

                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                Default_Item_P[0] = 0x01;
            }

            if (radioButton4.Checked)
            {
                panel1.BackColor = Color.AliceBlue;

             
                panel2.BackColor = Color.White;
                panel4.BackColor = Color.White;
                Default_Item_P[0] = 0x02;
            }

            if (radioButton5.Checked)
            {
                panel2.BackColor = Color.AliceBlue;

                panel1.BackColor = Color.White;
               
                panel4.BackColor = Color.White;
                Default_Item_P[0] = 0x03;
            }
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                panel4.BackColor = Color.IndianRed;

                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                Default_Item_P[0] = 0x11;

            }

            if (radioButton4.Checked)
            {
                panel1.BackColor = Color.IndianRed;
               
                panel2.BackColor = Color.White;
                panel4.BackColor = Color.White;
                Default_Item_P[0] = 0x12;
            }

            if (radioButton5.Checked)
            {
                panel2.BackColor = Color.IndianRed;
                panel1.BackColor = Color.White;
               
                panel4.BackColor = Color.White;
                Default_Item_P[0] = 0x13;
            }
        }

        private void radioButton9_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                panel4.BackColor = Color.DarkGray;
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                Default_Item_P[0] = 0x21;

            }

            if (radioButton4.Checked)
            {
                panel1.BackColor = Color.DarkGray;
               
                panel2.BackColor = Color.White;
                panel4.BackColor = Color.White;
                Default_Item_P[0] = 0x22;
            }

            if (radioButton5.Checked)
            {
                panel2.BackColor = Color.DarkGray;
                panel1.BackColor = Color.White;
               
                panel4.BackColor = Color.White;
                Default_Item_P[0] = 0x23;
            }
        }

        private void radioButton14_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                panel4.BackColor = Color.AliceBlue;

                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                Item_P[0] = 0x01;

            }

            if (radioButton11.Checked)
            {
                panel1.BackColor = Color.AliceBlue;


                panel2.BackColor = Color.White;
                panel4.BackColor = Color.White;
                Item_P[0] = 0x02;
            }

            if (radioButton12.Checked)
            {
                panel2.BackColor = Color.AliceBlue;

                panel1.BackColor = Color.White;

                panel4.BackColor = Color.White;

                Item_P[0] = 0x03;
            }
        }

        private void radioButton15_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                panel4.BackColor = Color.IndianRed;

                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;
                Item_P[0] = 0x11;

            }

            if (radioButton11.Checked)
            {
                panel1.BackColor = Color.IndianRed;

                panel2.BackColor = Color.White;
                panel4.BackColor = Color.White;
                Item_P[0] = 0x12;
            }

            if (radioButton12.Checked)
            {
                panel2.BackColor = Color.IndianRed;
                panel1.BackColor = Color.White;

                panel4.BackColor = Color.White;

                Item_P[0] = 0x13;
            }
        }

        private void radioButton16_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                panel4.BackColor = Color.DarkGray;
                panel1.BackColor = Color.White;
                panel2.BackColor = Color.White;

                Item_P[0] = 0x21;

            }

            if (radioButton11.Checked)
            {
                panel1.BackColor = Color.DarkGray;

                panel2.BackColor = Color.White;
                panel4.BackColor = Color.White;

                Item_P[0] = 0x22;
            }

            if (radioButton12.Checked)
            {
                panel2.BackColor = Color.DarkGray;
                panel1.BackColor = Color.White;

                panel4.BackColor = Color.White;

                Item_P[0] = 0x23;
            }
        }

        private void radioButton17_CheckedChanged_1(object sender, EventArgs e)
        {
            label5.Text = "Pg_Language_0";
        }

        private void radioButton18_CheckedChanged_1(object sender, EventArgs e)
        {
            label5.Text = "Pg_Language_1";
        }
    }
}
