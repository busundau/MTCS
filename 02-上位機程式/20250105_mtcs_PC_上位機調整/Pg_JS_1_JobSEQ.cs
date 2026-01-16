using SerialHex.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SerialHex
{
    public partial class Pg_JS_1_JobSEQ : Form
    {
        public Pg_JS_1_JobSEQ()
        {
            InitializeComponent();
        }

        private void Pg_JS_1_JobSEQ_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            radioButton1.Checked = true;
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
            Seq_ID = "";
            Seq_ID = textBox5.Text.ToString();
            //richTextBox1.Text += "Seq_ID=" + Seq_ID.ToString() + "\r\n";
           // Seq_IDarray[0] = Convert.ToByte(Seq_ID);//want++
                                                    //////////////////////////////////////////////////////////

            //////////////////////////////////////////////////////////////StepNow
            string StepNow = "";
            byte[] StepNowarray = new byte[2];
            StepNow = "";
            StepNow = textBox7.Text.ToString();
          //  richTextBox1.Text += "StepNow=" + StepNow.ToString() + "\r\n";
           // StepNowarray[0] = Convert.ToByte(StepNow); ;//want++
            
                                                        //////////////////////////////////////////////////////////






          //  richTextBox1.Text += "ok_state=" + ok_state.ToString() + "\r\n";//ok_state
            //richTextBox1.Text += "pagebutton_press=" + pagebutton_press.ToString() + "\r\n";//pagebutton Button
           // richTextBox1.Text += "Barcode_press=" + Barcode_press.ToString() + "\r\n";//Barcode_press Button
           // richTextBox1.Text += "Confirm_press=" + Confirm_press.ToString() + "\r\n";//Confirm_press Button

            ////////////////////////////////////////////////////////////
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 43;//資料數
          
            Form1.MainCommand[3] = 41;//頁數
          
            Form1.MainCommand[4] = Convert.ToByte(textBox35.Text.ToString());//title show Job
            Form1.MainCommand[5] = Convert.ToByte(textBox36.Text.ToString());//title show Job

            Button1[0] = 2;//page up
            Button2[0] = 11;//sequence
            Button3[0] = 6;//enter
            Form1.MainCommand[6] = Button1[0];//page
            Form1.MainCommand[7] = Button2[0];//page down
            Form1.MainCommand[8] = Button3[0];//enter
            Form1.MainCommand[9] = Convert.ToByte(textBox5.Text.ToString()[0]);
            Form1.MainCommand[10] = Convert.ToByte(textBox5.Text.ToString()[1]);
            Form1.MainCommand[11] = Convert.ToByte(textBox5.Text.ToString()[2]);
            Form1.MainCommand[12] = Convert.ToByte(textBox5.Text.ToString()[3]);
            Form1.MainCommand[13] = Convert.ToByte(textBox5.Text.ToString()[4]);
            Form1.MainCommand[14] = Convert.ToByte(textBox5.Text.ToString()[5]);
            Form1.MainCommand[15] = Convert.ToByte(textBox5.Text.ToString()[6]);
            Form1.MainCommand[16] = Convert.ToByte(textBox5.Text.ToString()[7]);
            Form1.MainCommand[17] = Convert.ToByte(textBox5.Text.ToString()[8]);
            Form1.MainCommand[18] = Convert.ToByte(textBox5.Text.ToString()[9]);
            Form1.MainCommand[19] = Convert.ToByte(textBox5.Text.ToString()[10]);
            Form1.MainCommand[20] = Convert.ToByte(textBox5.Text.ToString()[11]);

            Form1.MainCommand[21] = System.Text.Encoding.ASCII.GetBytes(textBox7.Text.ToString())[0];
            Form1.MainCommand[22] = System.Text.Encoding.ASCII.GetBytes(textBox15.Text.ToString())[0];
            Form1.MainCommand[23] = System.Text.Encoding.ASCII.GetBytes(textBox16.Text.ToString())[0];
            Form1.MainCommand[24] = System.Text.Encoding.ASCII.GetBytes(textBox17.Text.ToString())[0];
            Form1.MainCommand[25] = System.Text.Encoding.ASCII.GetBytes(textBox19.Text.ToString())[0];
            Form1.MainCommand[26] = System.Text.Encoding.ASCII.GetBytes(textBox20.Text.ToString())[0];
            Form1.MainCommand[27] = System.Text.Encoding.ASCII.GetBytes(textBox21.Text.ToString())[0];
            Form1.MainCommand[28] = System.Text.Encoding.ASCII.GetBytes(textBox22.Text.ToString())[0];
            Form1.MainCommand[29] = System.Text.Encoding.ASCII.GetBytes(textBox23.Text.ToString())[0];
            Form1.MainCommand[30] = System.Text.Encoding.ASCII.GetBytes(textBox24.Text.ToString())[0];
            Form1.MainCommand[31] = System.Text.Encoding.ASCII.GetBytes(textBox25.Text.ToString())[0];
            Form1.MainCommand[32] = System.Text.Encoding.ASCII.GetBytes(textBox26.Text.ToString())[0];
            Form1.MainCommand[33] = System.Text.Encoding.ASCII.GetBytes(textBox27.Text.ToString())[0];
            Form1.MainCommand[34] = System.Text.Encoding.ASCII.GetBytes(textBox28.Text.ToString())[0];
            Form1.MainCommand[35] = System.Text.Encoding.ASCII.GetBytes(textBox29.Text.ToString())[0];
            Form1.MainCommand[36] = System.Text.Encoding.ASCII.GetBytes(textBox30.Text.ToString())[0];
            Form1.MainCommand[37] = System.Text.Encoding.ASCII.GetBytes(textBox31.Text.ToString())[0];
            Form1.MainCommand[38] = System.Text.Encoding.ASCII.GetBytes(textBox32.Text.ToString())[0];
            Form1.MainCommand[39] = System.Text.Encoding.ASCII.GetBytes(textBox33.Text.ToString())[0];
            Form1.MainCommand[40] = System.Text.Encoding.ASCII.GetBytes(textBox34.Text.ToString())[0];
            Form1.MainCommand[41] = Convert.ToByte(textBox1.Text.ToString());

            if (radioButton1.Checked)//stop ng
            {
                Form1.MainCommand[42] =1;
            }

            if (radioButton3.Checked)//stop ng
            {
                Form1.MainCommand[42] = 0;
            }

            if (radioButton5.Checked)//SEQ_OK
            {
                Form1.MainCommand[43] = 1;
            }

            if (radioButton4.Checked)//SEQ_OK
            {
                Form1.MainCommand[43] = 0;
            }

            if (radioButton7.Checked)//STOP_SEQ_OK
            {
                Form1.MainCommand[44] = 1;
            }

            if (radioButton6.Checked)//STOP_SEQ_OK
            {
                Form1.MainCommand[44] = 0;
            }

            byte Protocol_CheckSum;
                Protocol_CheckSum = 0;
                for (i = 2; i <= 44; i++)
                {
                    Protocol_CheckSum += Form1.MainCommand[i];
                }
                Form1.MainCommand[45] = Protocol_CheckSum;//check sum
                richTextBox1.Text += "#########################################################\r\n";
                for (i = 0; i <= 45; i++)
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
            textBox18.Text = "Pg_JS_1_JobSEQ";
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
           
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
           
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
            
        }

        private void radioButton13_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void radioButton14_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox7.Text = "MTCSC39E-000001\r\nMore...";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_2(object sender, EventArgs e)
        {
            label4.Text = "Pg_JS_1_JobSEQ";
            button2.Text = "Page Down";
        }

        private void radioButton4_CheckedChanged_2(object sender, EventArgs e)
        {
            label4.Text = "Pg_JS_1_JobSEQ";
            button2.Text = "Seq";
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            radioButton2.Text = "Job-" + textBox35.Text.ToString() + " Seq-" + textBox36.Text.ToString();
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            radioButton2.Text = "Job-" + textBox35.Text.ToString() + " Seq-" + textBox36.Text.ToString();
        }
    }
}
