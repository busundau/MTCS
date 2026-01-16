using SerialHex.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SerialHex
{
    public partial class Pg_Call_Job : Form
    {
        byte[] Choice_Job_ID_P = new byte[2];
        byte[] Item_Job_ID_P = new byte[2];
        Byte aa, bb, cc;
        public Pg_Call_Job()
        {
            InitializeComponent();
        }

        private void Pg_Call_Job_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            radioButton31.Checked = true;
            radioButton19.Checked = true;
            radioButton29.Checked = true;
            radioButton5.Checked = true;
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
            ////////////////////////////////////////////////////////////////APPLINK


            byte[] Applinkarray = new byte[100];
          
            str111 = "";
            str111 = textBox1.Text.ToString();
            for (i = 0; i < 16; i++)
            {
                if (i < textBox1.TextLength)
                {
                    richTextBox1.Text += str111.ToString()[i];
                    Applinkarray[i] = Convert.ToByte(str111[i]);  //want++
                }

                else
                {
                    richTextBox1.Text += '0';
                    Applinkarray[i] = Convert.ToByte('0'); //want++
                }
                
               

            }
            richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {
               
              richTextBox1.Text += Applinkarray[i]+" ";
             }
            richTextBox1.Text += "\r\n";
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
                    richTextBox1.Text += str222.ToString()[i];
                    datauploand[i] = Convert.ToByte(str222[i]);  //want++
                }

                else
                {
                    richTextBox1.Text += '0';
                    datauploand[i] = Convert.ToByte('0'); //want++
                }
               
               

            }
            richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {

                richTextBox1.Text += datauploand[i] + " ";
            }
            richTextBox1.Text += "\r\n";
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
            richTextBox1.Text += "batt=" + batt.ToString() + "\r\n";
            bata[0]= Convert.ToByte(batt);//want++
                                        //////////////////////////////////////////////////////////
                                        ////////////////////////////////////////////////////////Job
            string Job = "";
            byte[] Jobarray = new byte[2];
            Job = "";
            Job = textBox4.Text.ToString();
            richTextBox1.Text += "Job=" + Job.ToString() + "\r\n";
            Jobarray[0] = Convert.ToByte(Job); ;//want++
            //////////////////////////////////////////////////////////
            /// ////////////////////////////////////////////////////////seq now
            string SeqNow = "";
            byte[] SeqNowarray = new byte[2];
            SeqNow = "";
            SeqNow = textBox5.Text.ToString();
            richTextBox1.Text += "SeqNow=" + SeqNow.ToString() + "\r\n";
            SeqNowarray[0] = Convert.ToByte(SeqNow);//want++
            //////////////////////////////////////////////////////////
            ////// ////////////////////////////////////////////////////////seq total
            string SeqTotal = "";
            byte[] SeqTotalarray = new byte[2];
            SeqTotal = "";
            SeqTotal = textBox6.Text.ToString();
            richTextBox1.Text += "SeqTotal=" + SeqTotal.ToString() + "\r\n";
            SeqTotalarray[0] = Convert.ToByte(SeqTotal);//want++
            //////////////////////////////////////////////////////////
          
          
          
           
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 27;//資料數
            Form1.MainCommand[3] = 0;//頁數
           // Form1.MainCommand[4] = Title[0];//標頭檔名1
           
            Button1[0] = 1;//page
            Button2[0] = 4;//barcode
            Button3[0] = 5;//confirm
            Form1.MainCommand[5] = Button1[0];//page
            Form1.MainCommand[6] = Button2[0];//barcode
            Form1.MainCommand[7] = Button3[0];//confirm
            Form1.MainCommand[8] = 0;//item_P保留
           
            Form1.MainCommand[11] = bata[0];//電量
            Form1.MainCommand[12] = Jobarray[0];//Job_ID
            Form1.MainCommand[13] = SeqNowarray[0];//Seq_Current
            Form1.MainCommand[14] = SeqTotalarray[0];//Seq_Sum
          
           
          

            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            for (i = 2; i <= 28;i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[29] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            for (i = 0; i <= 29; i++)
            {
                richTextBox1.Text +=  Form1.MainCommand[i].ToString("X") + " ";
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            byte[] Title = new byte[50];
            byte[] Button1 = new byte[2];
            byte[] Button2 = new byte[2];
            byte[] Button3 = new byte[2];

            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 8;//資料數
            if(radioButton31.Checked)
            Form1.MainCommand[3] = 30;//頁數
            if (radioButton32.Checked)
                Form1.MainCommand[3] = 31;//頁數

            if (radioButton1.Checked) //nodisplay
            {
                Form1.MainCommand[4] = 0;//title
            }
            if (radioButton2.Checked) //Switch Job
            {
                Form1.MainCommand[4] = 1;//title
            }
            Button1[0] = 2;//page up
            Button2[0] = 3;//page down
            Button3[0] = 6;//enter
            Form1.MainCommand[5] = Button1[0];//page up
            Form1.MainCommand[6] = Button2[0];//page down
            Form1.MainCommand[7] = Button3[0];//enter
           
            // Form1.MainCommand[8] = Item_Job_ID_P[0];//Item_Job_ID_P
            if (radioButton3.Checked)
               aa = 0x1<<2;
            if (radioButton4.Checked)
                aa = 0x2<<2;
            if (radioButton5.Checked)
                aa = 0x3<<2;
            if (radioButton6.Checked)
                aa = 0x4<<2;
            if (radioButton7.Checked)
                aa = 0x5<<2;
            if (radioButton8.Checked)
                aa = 0x6<<2;
            if (radioButton11.Checked)
            {



                aa = (7 << 2);
            }
            if (radioButton12.Checked)
            {



                aa = (8 << 2);
            }

            if (radioButton23.Checked)
            {



                aa = (9 << 2);
            }

            if (radioButton24.Checked)
            {



                aa = (10 << 2);
            }

            if (radioButton25.Checked)
            {



                aa = (11 << 2);
            }

            if (radioButton26.Checked)
            {



                aa = (12 << 2);
            }

            if (radioButton33.Checked)
            {



                aa = (13 << 2);
            }

            if (radioButton34.Checked)
            {



                aa = (14 << 2);
            }

            if (radioButton35.Checked)
            {



                aa = (15 << 2);
            }

            if (radioButton36.Checked)
            {



                aa = (16 << 2);
            }

            if (radioButton37.Checked)
            {



                aa = (17 << 2);
            }

            if (radioButton38.Checked)
            {



                aa= (18 << 2);
            }


            if (radioButton39.Checked)
            {



                aa = (19 << 2);
            }

            if (radioButton40.Checked)
            {



                aa = (20 << 2);
            }

            if (radioButton41.Checked)
            {


                aa = (21 << 2);
            }

            if (radioButton42.Checked)
            {



                aa = (22 << 2);
            }

            if (radioButton43.Checked)
            {



                aa = (23 << 2);
            }

            if (radioButton44.Checked)
            {



                aa = (24 << 2);
            }

            if (radioButton45.Checked)
            {



                aa = (25 << 2);
            }


            if (radioButton46.Checked)
            {



                aa = (26 << 2);
            }

            if (radioButton47.Checked)
            {



                aa = (27 << 2);
            }

            if (radioButton48.Checked)
            {



                aa = (28 << 2);
            }

            if (radioButton13.Checked)
                bb = 0x0 ;
            if (radioButton14.Checked)
                bb = 0x1;
            if (radioButton15.Checked)
                bb = 0x2;
            if (radioButton16.Checked)
                bb =0x3 ;
            cc = (Byte)(aa + bb);
            Form1.MainCommand[8] = cc;


            if (radioButton17.Checked)
                aa = 0x1<<2;
            if (radioButton18.Checked)
                aa = 0x2<<2;
            if (radioButton19.Checked)
                aa = 0x3<<2;
            if (radioButton20.Checked)
                aa = 0x4<<2;
            if (radioButton21.Checked)
                aa = 0x5<<2;
            if (radioButton22.Checked)
                aa = 0x6<<2;
            if (radioButton9.Checked)
            {
                


                aa = (7 << 2);
            }

            if (radioButton10.Checked)
            {
               

                aa= (8 << 2) ;
            }


            if (radioButton49.Checked)
            {
                


                aa= (9 << 2) ;
            }

            if (radioButton50.Checked)
            {
              


               aa = (10 << 2) ;
            }

            if (radioButton51.Checked)
            {
              


                aa= (11 << 2) ;
            }

            if (radioButton52.Checked)
            {
                


                aa = (12 << 2) ;
            }

            if (radioButton53.Checked)
            {
               


                aa= (13 << 2);
            }

            if (radioButton54.Checked)
            {
               


                aa = (14 << 2) ;
            }

            if (radioButton55.Checked)
            {
               


                aa= (15 << 2);
            }

            if (radioButton56.Checked)
            {
               


                aa = (16 << 2);
            }

            if (radioButton57.Checked)
            {
               


                aa= (17 << 2);
            }

            if (radioButton58.Checked)
            {
                

                aa = (18 << 2);
            }

            if (radioButton59.Checked)
            {
              


               aa= (19 << 2);
            }

            if (radioButton60.Checked)
            {
                


               aa = (20 << 2) ;
            }

            if (radioButton61.Checked)
            {
               


                aa = (21 << 2);
            }

            if (radioButton62.Checked)
            {
               


                aa= (22 << 2);
            }

            if (radioButton63.Checked)
            {
               


                aa= (23 << 2) ;
            }
            if (radioButton64.Checked)
            {
                


                aa= (24 << 2) ;
            }

            if (radioButton65.Checked)
            {
                


                aa = (25 << 2) ;
            }

            if (radioButton66.Checked)
            {
               


                aa= (26 << 2);
            }

            if (radioButton67.Checked)
            {
               


                aa = (27 << 2) ;
            }

            if (radioButton68.Checked)
            {
               


                aa = (28 << 2) ;
            }

            if (radioButton27.Checked)
                bb = 0x0;
            if (radioButton28.Checked)
                bb = 0x1;
            if (radioButton29.Checked)
                bb = 0x2;
            if (radioButton30.Checked)
                bb = 0x3;

            cc = (Byte)(aa + bb);
            Form1.MainCommand[9] = cc;//Choice_Job_ID_P
           
            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            int i;
            for (i = 2; i <= 9; i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[10] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            for (i = 0; i <= 10; i++)
            {
                richTextBox1.Text += Form1.MainCommand[i].ToString("X2") + " ";
                // richTextBox1.Text += i+" "+Form1.MainCommand[i].ToString("X")+"\r\n";
                // richTextBox1.Text += i+" "+Form1.MainCommand[i].ToString("X")+" ";
                //  richTextBox1.Text += i + " " + Form1.MainCommand[i].ToString("X") + " ";
            }
            richTextBox1.Text += "\r\n#########################################################\r\n";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox18.Text = "";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox18.Text = "Switch Job";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void radioButton14_CheckedChanged_1(object sender, EventArgs e)
        {
            

                if (radioButton3.Checked)
                {

                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox1.BackColor = Color.AliceBlue;

               

                Item_Job_ID_P[0] = (0x01<<2+0x1);
            }

                if (radioButton4.Checked)
                {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox2.BackColor = Color.AliceBlue;

               
              
                Item_Job_ID_P[0] = (0x02 << 2 + 0x1);
            }

                if (radioButton5.Checked)
                {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox3.BackColor = Color.AliceBlue;

               
               
                Item_Job_ID_P[0] = (0x03 << 2 + 0x1);
            }

                if (radioButton6.Checked)
                {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox4.BackColor = Color.AliceBlue;

               
               
                Item_Job_ID_P[0] = (0x04 << 2 + 0x1);
            }

                if (radioButton7.Checked)
                {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox5.BackColor = Color.AliceBlue;

               
                
                Item_Job_ID_P[0] = (0x05 << 2 + 0x1);
            }

                if (radioButton8.Checked)
                {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox6.BackColor = Color.AliceBlue;

               
                
               
                Item_Job_ID_P[0] = (0x06 << 2 + 0x1);
            }

            if (radioButton11.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox7.BackColor = Color.AliceBlue;

               

                Item_Job_ID_P[0] = (7 << 2 + 0x1);
            }
            if (radioButton12.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox8.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (8 << 2 + 0x1);
            }

            if (radioButton23.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox9.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (9 << 2 + 0x1);
            }

            if (radioButton24.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox10.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (10 << 2 + 0x1);
            }

            if (radioButton25.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox11.BackColor = Color.AliceBlue;

               

                Item_Job_ID_P[0] = (11 << 2 + 0x1);
            }

            if (radioButton26.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox12.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (12 << 2 + 0x1);
            }

            if (radioButton33.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox13.BackColor = Color.AliceBlue;

               

                Item_Job_ID_P[0] = (13 << 2 + 0x1);
            }

            if (radioButton34.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox14.BackColor = Color.AliceBlue;

                


                Item_Job_ID_P[0] = (14 << 2 + 0x1);
            }

            if (radioButton35.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox15.BackColor = Color.AliceBlue;

                

                Item_Job_ID_P[0] = (15 << 2 + 0x1);
            }

            if (radioButton36.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox16.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (16 << 2 + 0x1);
            }

            if (radioButton37.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox17.BackColor = Color.AliceBlue;

              


                Item_Job_ID_P[0] = (17 << 2 + 0x1);
            }

            if (radioButton38.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox19.BackColor = Color.AliceBlue;

               

                Item_Job_ID_P[0] = (18 << 2 + 0x1);
            }


            if (radioButton39.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox20.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (19 << 2 + 0x1);
            }

            if (radioButton40.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox21.BackColor = Color.AliceBlue;



                Item_Job_ID_P[0] = (20 << 2 + 0x1);
            }

            if (radioButton41.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox22.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (21 << 2 + 0x1);
            }

            if (radioButton42.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox23.BackColor = Color.AliceBlue;

                


                Item_Job_ID_P[0] = (22 << 2 + 0x1);
            }

            if (radioButton43.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox24.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (23 << 2 + 0x1);
            }

            if (radioButton44.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;

                textBox25.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (24 << 2 + 0x1);
            }

            if (radioButton45.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox26.BackColor = Color.AliceBlue;

                


                Item_Job_ID_P[0] = (25 << 2 + 0x1);
            }


            if (radioButton46.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox27.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (26 << 2 + 0x1);
            }

            if (radioButton47.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox28.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (27 << 2 + 0x1);
            }

            if (radioButton48.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox29.BackColor = Color.AliceBlue;

               


                Item_Job_ID_P[0] = (28 << 2 + 0x1);
            }










        }

        private void radioButton15_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox1.BackColor = Color.IndianRed;


                
               
               
                Item_Job_ID_P[0] = (1<<2)+0x2;
            }

            if (radioButton4.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox2.BackColor = Color.IndianRed;

               

                Item_Job_ID_P[0] = (2 << 2) + 0x2;
            }

            if (radioButton5.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox3.BackColor = Color.IndianRed;

              

                Item_Job_ID_P[0] = (3 << 2) + 0x2;
            }

            if (radioButton6.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox4.BackColor = Color.IndianRed;

                

                Item_Job_ID_P[0] = (4 << 2) + 0x2;
            }

            if (radioButton7.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox5.BackColor = Color.IndianRed;

               

                Item_Job_ID_P[0] = (5 << 2) + 0x2;
            }

            if (radioButton8.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox6.BackColor = Color.IndianRed;

              


                Item_Job_ID_P[0] = (6 << 2) + 0x2;
            }


            if (radioButton11.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox7.BackColor = Color.IndianRed;

              


                Item_Job_ID_P[0] = (7 << 2 + 0x2);
            }
            if (radioButton12.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox8.BackColor = Color.IndianRed;

               

                Item_Job_ID_P[0] = (8 << 2 + 0x2);
            }

            if (radioButton23.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox9.BackColor = Color.IndianRed;

              


                Item_Job_ID_P[0] = (9 << 2 + 0x2);
            }

            if (radioButton24.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox10.BackColor = Color.IndianRed;

                


                Item_Job_ID_P[0] = (10 << 2 + 0x2);
            }

            if (radioButton25.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox11.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (11 << 2 + 0x2);
            }

            if (radioButton26.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox12.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (12 << 2 + 0x2);
            }

            if (radioButton33.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox13.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (13 << 2 + 0x2);
            }

            if (radioButton34.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox14.BackColor = Color.IndianRed;

              

                Item_Job_ID_P[0] = (14 << 2 + 0x2);
            }

            if (radioButton35.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox15.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (15 << 2 + 0x2);
            }

            if (radioButton36.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox16.BackColor = Color.IndianRed;

                


                Item_Job_ID_P[0] = (16 << 2) + 0x2;
            }

            if (radioButton37.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox17.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (17 << 2) + 0x2;
            }

            if (radioButton38.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox19.BackColor = Color.IndianRed;

              


                Item_Job_ID_P[0] = (18 << 2) + 0x2;
            }


            if (radioButton39.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox20.BackColor = Color.IndianRed;

               

                Item_Job_ID_P[0] = (19 << 2) + 0x2;
            }

            if (radioButton40.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox21.BackColor = Color.IndianRed;

                


                Item_Job_ID_P[0] = (20 << 2) + 0x2;
            }

            if (radioButton41.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox22.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (21 << 2) + 0x2;
            }

            if (radioButton42.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox23.BackColor = Color.IndianRed;

                


                Item_Job_ID_P[0] = (22 << 2 )+ 0x2;
            }

            if (radioButton43.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox24.BackColor = Color.IndianRed;

                


                Item_Job_ID_P[0] = (23 << 2) + 0x2;
            }

            if (radioButton44.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox25.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (24 << 2) + 0x2;
            }

            if (radioButton45.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox26.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (25 << 2 )+ 0x3;
            }


            if (radioButton46.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox27.BackColor = Color.IndianRed;

              

                Item_Job_ID_P[0] = (26 << 2 )+ 0x3;
            }

            if (radioButton47.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox28.BackColor = Color.IndianRed;

                

                Item_Job_ID_P[0] = (27 << 2 )+ 0x3;
            }

            if (radioButton48.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox29.BackColor = Color.IndianRed;

               


                Item_Job_ID_P[0] = (28 << 2 )+ 0x3;
            }


        }

        private void radioButton16_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox1.BackColor = Color.DarkGray;

              
               
                Item_Job_ID_P[0] = (1<<2)+0x3;
            }

            if (radioButton4.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox2.BackColor = Color.DarkGray;

               

                Item_Job_ID_P[0] = (2 << 2) + 0x3;
            }

            if (radioButton5.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox3.BackColor = Color.DarkGray;

                

                Item_Job_ID_P[0] = (3 << 2) + 0x3;
            }

            if (radioButton6.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox4.BackColor = Color.DarkGray;

              

                Item_Job_ID_P[0] = (4 << 2) + 0x3;
            }

            if (radioButton7.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox5.BackColor = Color.DarkGray;

               

                Item_Job_ID_P[0] = (5 << 2) + 0x3;
            }

            if (radioButton8.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox6.BackColor = Color.DarkGray;

               


                Item_Job_ID_P[0] = (6 << 2) + 0x3;
            }

       


            if (radioButton11.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox7.BackColor = Color.DarkGray;

                

                Item_Job_ID_P[0] = (7 << 2 )+ 0x3;
            }
            if (radioButton12.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox8.BackColor = Color.DarkGray;

                

                Item_Job_ID_P[0] = (8 << 2) + 0x3;
            }

            if (radioButton23.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox9.BackColor = Color.DarkGray;

               


                Item_Job_ID_P[0] = (9 << 2 )+ 0x3;
            }

            if (radioButton24.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox10.BackColor = Color.DarkGray;

              


                Item_Job_ID_P[0] = (10 << 2 )+ 0x3;
            }

            if (radioButton25.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox11.BackColor = Color.DarkGray;

               

                Item_Job_ID_P[0] = (11 << 2) + 0x3;
            }

            if (radioButton26.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox12.BackColor = Color.DarkGray;

               


                Item_Job_ID_P[0] = (12 << 2) + 0x3;
            }

            if (radioButton33.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox13.BackColor = Color.DarkGray;

               


                Item_Job_ID_P[0] = (13 << 2) + 0x3;
            }

            if (radioButton34.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox14.BackColor = Color.DarkGray;

               

                Item_Job_ID_P[0] = (14 << 2) + 0x3;
            }

            if (radioButton35.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox15.BackColor = Color.DarkGray;

                


                Item_Job_ID_P[0] = (15 << 2) + 0x3;
            }

            if (radioButton36.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox16.BackColor = Color.DarkGray;

               

                Item_Job_ID_P[0] = (16 << 2) + 0x3;
            }

            if (radioButton37.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox17.BackColor = Color.DarkGray;

               

                Item_Job_ID_P[0] = (17 << 2) + 0x3;
            }

            if (radioButton38.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox19.BackColor = Color.DarkGray;

                


                Item_Job_ID_P[0] = (18 << 2) + 0x3;
            }


            if (radioButton39.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox20.BackColor = Color.DarkGray;

                

                Item_Job_ID_P[0] = (19 << 2) + 0x3;
            }

            if (radioButton40.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox21.BackColor = Color.DarkGray;

              


                Item_Job_ID_P[0] = (20 << 2) + 0x3;
            }

            if (radioButton41.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox22.BackColor = Color.DarkGray;

               


                Item_Job_ID_P[0] = (21 << 2) + 0x3;
            }

            if (radioButton42.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox23.BackColor = Color.DarkGray;

                


                Item_Job_ID_P[0] = (22 << 2) + 0x3;
            }

            if (radioButton43.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox24.BackColor = Color.DarkGray;

               


                Item_Job_ID_P[0] = (23 << 2) + 0x3;
            }

            if (radioButton44.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox25.BackColor = Color.DarkGray;

               


                Item_Job_ID_P[0] = (24 << 2) + 0x3;
            }

            if (radioButton45.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox26.BackColor = Color.DarkGray;

               


                Item_Job_ID_P[0] = (25 << 2) + 0x3;
            }


            if (radioButton46.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox27.BackColor = Color.DarkGray;

                


                Item_Job_ID_P[0] = (26 << 2) + 0x3;
            }

            if (radioButton47.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox28.BackColor = Color.DarkGray;

                


                Item_Job_ID_P[0] = (27 << 2) + 0x3;
            }

            if (radioButton48.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox29.BackColor = Color.DarkGray;

                


                Item_Job_ID_P[0] = (28 << 2 )+ 0x3;
            }


        }

        private void radioButton13_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton28_CheckedChanged_1(object sender, EventArgs e)
        {

            if (radioButton17.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox1.BackColor = Color.AliceBlue;


               
                Choice_Job_ID_P[0]= (1<<2)+1;
            }

            if (radioButton18.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox2.BackColor = Color.AliceBlue;

               

                Choice_Job_ID_P[0] = (2 << 2) + 1;
            }

            if (radioButton19.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox3.BackColor = Color.AliceBlue;

               

                Choice_Job_ID_P[0] = (3 << 2) + 1;
            }

            if (radioButton20.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox4.BackColor = Color.AliceBlue;

               

                Choice_Job_ID_P[0] = (4 << 2) + 1;
            }

            if (radioButton21.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox5.BackColor = Color.AliceBlue;

              

                Choice_Job_ID_P[0] = (5 << 2) + 1;
            }

            if (radioButton22.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox6.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (6 << 2) + 1;
            }


            if (radioButton9.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox7.BackColor = Color.AliceBlue;

                

                Choice_Job_ID_P[0] = (7 << 2) + 1;
            }

            if (radioButton10.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox8.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (8 << 2) + 1;
            }


            if (radioButton49.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox9.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (9 << 2) + 1;
            }

            if (radioButton50.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox10.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (10 << 2) + 1;
            }

            if (radioButton51.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox11.BackColor = Color.AliceBlue;

                

                Choice_Job_ID_P[0] = (11 << 2) + 1;
            }

            if (radioButton52.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox12.BackColor = Color.AliceBlue;

              


                Choice_Job_ID_P[0] = (12 << 2) + 1;
            }

            if (radioButton53.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox13.BackColor = Color.AliceBlue;

              


                Choice_Job_ID_P[0] = (13 << 2) + 1;
            }

            if (radioButton54.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox14.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (14 << 2) + 1;
            }

            if (radioButton55.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox15.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (15 << 2) + 1;
            }

            if (radioButton56.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox16.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (16 << 2) + 1;
            }

            if (radioButton57.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox17.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (17 << 2) + 1;
            }

            if (radioButton58.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox19.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (18 << 2) + 1;
            }

            if (radioButton59.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox20.BackColor = Color.AliceBlue;

                

                Choice_Job_ID_P[0] = (19 << 2) + 1;
            }

            if (radioButton60.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox21.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (20 << 2) + 1;
            }

            if (radioButton61.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox22.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (21 << 2) + 1;
            }

            if (radioButton62.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox23.BackColor = Color.AliceBlue;

              


                Choice_Job_ID_P[0] = (22 << 2) + 1;
            }

            if (radioButton63.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox24.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (23 << 2) + 1;
            }
            if (radioButton64.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox25.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (24 << 2) + 1;
            }

            if (radioButton65.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox26.BackColor = Color.AliceBlue;

               

                Choice_Job_ID_P[0] = (25 << 2) + 1;
            }

            if (radioButton66.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox27.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (26 << 2) + 1;
            }

            if (radioButton67.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox28.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (27 << 2) + 1;
            }

            if (radioButton68.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox29.BackColor = Color.AliceBlue;

               


                Choice_Job_ID_P[0] = (28 << 2) + 1;
            }




        }

        private void radioButton29_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton17.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox1.BackColor = Color.IndianRed;



              
                
                Choice_Job_ID_P[0] = (1<<2)+2;
            }

            if (radioButton18.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox2.BackColor = Color.IndianRed;

               

                Choice_Job_ID_P[0] = (2 << 2) + 2;
            }

            if (radioButton19.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox3.BackColor = Color.IndianRed;

               
                Choice_Job_ID_P[0] = (3 << 2) + 2;
            }

            if (radioButton20.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox4.BackColor = Color.IndianRed;

               

                Choice_Job_ID_P[0] = (4 << 2) + 2;
            }

            if (radioButton21.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox5.BackColor = Color.IndianRed;

               

                Choice_Job_ID_P[0] = (5 << 2) + 2;
            }

            if (radioButton22.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox6.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (6 << 2) + 2;
            }

            if (radioButton9.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox7.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (7 << 2) + 2;
            }

            if (radioButton10.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox8.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (8 << 2) + 2;
            }


            if (radioButton49.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox9.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (9 << 2) + 2;
            }

            if (radioButton50.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox10.BackColor = Color.IndianRed;

                


                Choice_Job_ID_P[0] = (10 << 2) + 2;
            }

            if (radioButton51.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox11.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (11 << 2) + 2;
            }

            if (radioButton52.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox12.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (12 << 2) + 2;
            }

            if (radioButton53.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox13.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (13 << 2) + 2;
            }

            if (radioButton54.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox14.BackColor = Color.IndianRed;

                


                Choice_Job_ID_P[0] = (14 << 2) + 2;
            }

            if (radioButton55.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox15.BackColor = Color.IndianRed;

              


                Choice_Job_ID_P[0] = (15 << 2) + 2;
            }

            if (radioButton56.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox16.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (16 << 2) + 2;
            }

            if (radioButton57.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox17.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (17 << 2) + 2;
            }

            if (radioButton58.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox19.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (18 << 2) + 2;
            }

            if (radioButton59.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox20.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (19 << 2) + 2;
            }

            if (radioButton60.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox21.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (20 << 2) + 2;
            }

            if (radioButton61.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox22.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (21 << 2) + 2;
            }

            if (radioButton62.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox23.BackColor = Color.IndianRed;

                


                Choice_Job_ID_P[0] = (22 << 2) + 2;
            }

            if (radioButton63.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox24.BackColor = Color.IndianRed;

                


                Choice_Job_ID_P[0] = (23 << 2) + 2;
            }
            if (radioButton64.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox25.BackColor = Color.IndianRed;

                


                Choice_Job_ID_P[0] = (24 << 2) + 2;
            }

            if (radioButton65.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox26.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (25 << 2) + 2;
            }

            if (radioButton66.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox27.BackColor = Color.IndianRed;

                


                Choice_Job_ID_P[0] = (26 << 2) + 2;
            }

            if (radioButton67.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox28.BackColor = Color.IndianRed;

                


                Choice_Job_ID_P[0] = (27 << 2) + 2;
            }

            if (radioButton68.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox29.BackColor = Color.IndianRed;

               


                Choice_Job_ID_P[0] = (28 << 2) + 2;
            }


        }

        private void radioButton30_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton17.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox1.BackColor = Color.DarkGray;

               
                
                Choice_Job_ID_P[0] = (1<<2)+3;
            }

            if (radioButton18.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox2.BackColor = Color.DarkGray;

               
                Choice_Job_ID_P[0] = (2 << 2) + 3;
            }

            if (radioButton19.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox3.BackColor = Color.DarkGray;

              

                Choice_Job_ID_P[0] = (3 << 2) + 3;
            }

            if (radioButton20.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox4.BackColor = Color.DarkGray;

               

                Choice_Job_ID_P[0] = (4 << 2) + 3;
            }

            if (radioButton21.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox5.BackColor = Color.DarkGray;

               

                Choice_Job_ID_P[0] = (5 << 2) + 3;
            }

            if (radioButton22.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox6.BackColor = Color.DarkGray;

              

                Choice_Job_ID_P[0] = (6 << 2) + 3;
            }

            if (radioButton9.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox7.BackColor = Color.DarkGray;

               

                Choice_Job_ID_P[0] = (7 << 2) + 3;
            }

            if (radioButton10.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox8.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (8 << 2) + 3;
            }


            if (radioButton49.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox9.BackColor = Color.DarkGray;

                


                Choice_Job_ID_P[0] = (9 << 2) + 3;
            }

            if (radioButton50.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox10.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (10 << 2) + 3;
            }

            if (radioButton51.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox11.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (11 << 2) + 3;
            }

            if (radioButton52.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox12.BackColor = Color.DarkGray;

                


                Choice_Job_ID_P[0] = (12 << 2) + 3;
            }

            if (radioButton53.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox13.BackColor = Color.DarkGray;

                


                Choice_Job_ID_P[0] = (13 << 2) + 3;
            }

            if (radioButton54.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox14.BackColor = Color.DarkGray;

              


                Choice_Job_ID_P[0] = (14 << 2) + 3;
            }

            if (radioButton55.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox15.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (15 << 2) + 3;
            }

            if (radioButton56.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox16.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (16 << 2) + 3;
            }

            if (radioButton57.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox17.BackColor = Color.DarkGray;

                


                Choice_Job_ID_P[0] = (17 << 2) + 3;
            }

            if (radioButton58.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox19.BackColor = Color.DarkGray;

              


                Choice_Job_ID_P[0] = (18 << 2) + 3;
            }

            if (radioButton59.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox20.BackColor = Color.DarkGray;

                


                Choice_Job_ID_P[0] = (19 << 2) + 3;
            }

            if (radioButton60.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox21.BackColor = Color.DarkGray;

               

                Choice_Job_ID_P[0] = (20 << 2) + 3;
            }

            if (radioButton61.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox22.BackColor = Color.DarkGray;

                


                Choice_Job_ID_P[0] = (21 << 2) + 3;
            }

            if (radioButton62.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox23.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (22 << 2) + 3;
            }

            if (radioButton63.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox24.BackColor = Color.DarkGray;

                


                Choice_Job_ID_P[0] = (23 << 2) + 3;
            }
            if (radioButton64.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox25.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (24 << 2) + 3;
            }

            if (radioButton65.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox26.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (25 << 2) + 3;
            }

            if (radioButton66.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox27.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (26 << 2) + 3;
            }

            if (radioButton67.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox28.BackColor = Color.DarkGray;

               


                Choice_Job_ID_P[0] = (27 << 2) + 3;
            }

            if (radioButton68.Checked)
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox29.BackColor = Color.DarkGray;

                


                Choice_Job_ID_P[0] = (28 << 2) + 3;
            }




        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton27_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton17_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton22_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton31_CheckedChanged_1(object sender, EventArgs e)
        {
            label13.Text = "Pg_Call_Job_0";
        }

        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {
            label13.Text = "Pg_Call_Job_1";
        }
    }
}
