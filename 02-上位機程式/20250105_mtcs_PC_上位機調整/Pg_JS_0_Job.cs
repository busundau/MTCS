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
    public partial class Pg_JS_0_Job : Form
    {
        public Pg_JS_0_Job()
        {
            InitializeComponent();
        }

        private void Pg_JS_0_Job_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            radioButton3.Checked = true;
            radioButton5.Checked = true;
            radioButton7.Checked = true;
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

            /// ////////////////////////////////////////////////////////seq now
            string Seq_ID = "";
            byte[] Seq_IDarray = new byte[2];
                                             //////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////StepNow
            string StepNow = "";
            byte[] StepNowarray = new byte[2];
           
                                                        //////////////////////////////////////////////////////////






           // richTextBox1.Text += "ok_state=" + ok_state.ToString() + "\r\n";//ok_state
           // richTextBox1.Text += "pagebutton_press=" + pagebutton_press.ToString() + "\r\n";//pagebutton Button
          //  richTextBox1.Text += "Barcode_press=" + Barcode_press.ToString() + "\r\n";//Barcode_press Button
          //  richTextBox1.Text += "Confirm_press=" + Confirm_press.ToString() + "\r\n";//Confirm_press Button

            ////////////////////////////////////////////////////////////
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 20;//資料數
            if(radioButton3.Checked)
            Form1.MainCommand[3] = 40;//頁數
            
            if (radioButton1.Checked)
            {
                Form1.MainCommand[4] = 0;//title no display
            }
            if (radioButton2.Checked)
            {
                Form1.MainCommand[4] = 1;//title show Job
            }

            Button1[0] = 2;//page up
            Button2[0] = 3;//page down
            Button3[0] = 6;//enter
            Form1.MainCommand[5] = Button1[0];//page
            Form1.MainCommand[6] = Button2[0];//page down
            Form1.MainCommand[7] = Button3[0];//enter

            Form1.MainCommand[8] = System.Text.Encoding.ASCII.GetBytes(textBox1.Text.ToString())[0];//job name1
            Form1.MainCommand[9] = System.Text.Encoding.ASCII.GetBytes(textBox2.Text.ToString())[0];//job name2
            Form1.MainCommand[10] = System.Text.Encoding.ASCII.GetBytes(textBox3.Text.ToString())[0];//job name3
            Form1.MainCommand[11] = System.Text.Encoding.ASCII.GetBytes(textBox4.Text.ToString())[0];//job name4
            Form1.MainCommand[12] = System.Text.Encoding.ASCII.GetBytes(textBox6.Text.ToString())[0];//job name5
            Form1.MainCommand[13] = System.Text.Encoding.ASCII.GetBytes(textBox8.Text.ToString())[0];//job name6
            Form1.MainCommand[14] = System.Text.Encoding.ASCII.GetBytes(textBox9.Text.ToString())[0];//job name7
            Form1.MainCommand[15] = System.Text.Encoding.ASCII.GetBytes(textBox10.Text.ToString())[0];//job name8
            Form1.MainCommand[16] = System.Text.Encoding.ASCII.GetBytes(textBox11.Text.ToString())[0];//job name9
            Form1.MainCommand[17] = System.Text.Encoding.ASCII.GetBytes(textBox12.Text.ToString())[0];//job name10
            Form1.MainCommand[18] = System.Text.Encoding.ASCII.GetBytes(textBox13.Text.ToString())[0];//job name11
            Form1.MainCommand[19] = System.Text.Encoding.ASCII.GetBytes(textBox14.Text.ToString())[0];//job name12
            if (radioButton5.Checked)
            {
                Form1.MainCommand[20] = 1;
            }

            if (radioButton6.Checked)
            {
                Form1.MainCommand[20] = 0;
            }
            if (radioButton7.Checked)
            {
                Form1.MainCommand[21] = 1;
            }

            if (radioButton8.Checked)
            {
                Form1.MainCommand[21] = 0;
            }














            byte Protocol_CheckSum;
                Protocol_CheckSum = 0;
                for (i = 2; i <= 21; i++)
                {
                    Protocol_CheckSum += Form1.MainCommand[i];
                }
                Form1.MainCommand[22] = Protocol_CheckSum;//check sum
                richTextBox1.Text += "#########################################################\r\n";
                for (i = 0; i <= 22; i++)
                {
                    richTextBox1.Text += Form1.MainCommand[i].ToString("X2") + " ";
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

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox18.Text = "";

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox18.Text = "Job";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-1";
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-2";
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-3";
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-4";
        }

        private void radioButton7_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-5";
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-6";
        }

        private void radioButton9_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-7";
        }

        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-8";
        }

        private void radioButton11_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-9";
        }

        private void radioButton12_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox4.Text = "JOB-10";
        }

        private void radioButton13_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void radioButton14_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_2(object sender, EventArgs e)
        {
            label4.Text = "Pg_JS_0_Job";
            button2.Text = "Page Down";
        }

        private void radioButton4_CheckedChanged_2(object sender, EventArgs e)
        {
            label4.Text = "Page31";
            button2.Text = "Seq";
        }
    }
}
