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
    public partial class Pg_JS_2_Step2_1 : Form
    {
        public Pg_JS_2_Step2_1()
        {
            InitializeComponent();
        }

        private void Pg_JS_2_Step2_1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            radioButton4.Checked = true;
            radioButton10.Checked = true;
            radioButton12.Checked = true;
            radioButton18.Checked = true;
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
           /*
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
               
           //   richTextBox1.Text += Applinkarray[i]+" ";
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
                  //  richTextBox1.Text += str222.ToString()[i];
                    datauploand[i] = Convert.ToByte(str222[i]);  //want++
                }

                else
                {
                  //  richTextBox1.Text += '0';
                    datauploand[i] = Convert.ToByte('0'); //want++
                }
               
               

            }
          //  richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {

            //    richTextBox1.Text += datauploand[i] + " ";
            }
        //    richTextBox1.Text += "\r\n";
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
           
           ////////////////////////////////////////////////////////Job
            string Step_Id = "";
            byte[] Step_Idarray = new byte[2];
            Step_Id = "";
            Step_Id = textBox4.Text.ToString();
         //   richTextBox1.Text += "Step_Id=" + Step_Id.ToString() + "\r\n";
            Step_Idarray[0] = Convert.ToByte(Step_Id); ;//want++
            //////////////////////////////////////////////////////////
           
           
          
         
           
          
            ///////////////////////////////////////////////////////////////////////TourqeNow_int
            string TourqeNow_int = "";
            UInt16[] TourqeNow_intarray = new UInt16[2];
            byte[] TourqeNow_intarray_Byte = new byte[2];
            TourqeNow_int = "";
            TourqeNow_int = textBox11.Text.ToString();
        //    richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";
           
          

            //////////////////////////////////////////////////////////TourqeNow_float
            string TourqeNow_float = "";
            UInt16[] TourqeNow_floatarray = new UInt16[2];
            byte[] TourqeNow_floatarray_Byte = new byte[2];
            TourqeNow_float = "";
          //  TourqeNow_float = textBox12.Text.ToString();
         //   richTextBox1.Text += "TourqeNow_float=" + TourqeNow_float.ToString() + "\r\n";
           
          
          //  richTextBox1.Text += "TourqeNow_float Hbyte=" + TourqeNow_floatarray[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////angle
           
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////speed

            string speed = "";
            UInt16[] speed_array = new UInt16[2];
            byte[] speed_array_Byte = new byte[2];
            speed = "";
            speed = textBox14.Text.ToString(); ;
        //    richTextBox1.Text += "speed_array=" + speed.ToString() + "\r\n";
         
            speed_array[0] = (UInt16)((Convert.ToUInt16(speed)) & 0xff);
            speed_array_Byte[0] = (Byte)((Convert.ToByte(speed_array[0])));//want++
          //  richTextBox1.Text += "speed_array Lbyte=" + speed_array_Byte[0].ToString() + "\r\n";


            speed_array[1] = (UInt16)((Convert.ToUInt16(speed) >> 8) & 0xff);
            speed_array_Byte[1] = (Byte)((Convert.ToByte(speed_array[1]) & 0xff));//want++
          //  richTextBox1.Text += "speed_array Hbyte=" + speed_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///
            ///   //////////////////////////////////////////////////////////speed

            string Joint_Offest = "";
            UInt16[] Joint_Offest_array = new UInt16[2];
            byte[] Joint_Offest_array_Byte = new byte[2];
            Joint_Offest = "";
            Joint_Offest = textBox6.Text.ToString(); ;
          //  richTextBox1.Text += "Joint_Offest_array=" + Joint_Offest.ToString() + "\r\n";

          //  Joint_Offest_array[0] = (UInt16)((Convert.ToUInt16(Joint_Offest)) & 0xff);
         //   Joint_Offest_array_Byte[0] = (Byte)((Convert.ToByte(Joint_Offest_array[0])));//want++
           // richTextBox1.Text += "Joint_Offest_array Lbyte=" + Joint_Offest_array_Byte[0].ToString() + "\r\n";


          //  Joint_Offest_array[1] = (UInt16)((Convert.ToUInt16(Joint_Offest) >> 8) & 0xff);
         //   Joint_Offest_array_Byte[1] = (Byte)((Convert.ToByte(Joint_Offest_array[1]) & 0xff));//want++
           // richTextBox1.Text += "Joint_Offest_array Hbyte=" + Joint_Offest_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////speed

           
            //////////////////////////////////////////////////////////





            ///////////////////////////////////////////////////////////////////////////////
         //   richTextBox1.Text += "ok_state=" + ok_state.ToString() + "\r\n";//ok_state
         //   richTextBox1.Text += "pagebutton_press=" + pagebutton_press.ToString() + "\r\n";//pagebutton Button
         //   richTextBox1.Text += "Barcode_press=" + Barcode_press.ToString() + "\r\n";//Barcode_press Button
        //    richTextBox1.Text += "Confirm_press=" + Confirm_press.ToString() + "\r\n";//Confirm_press Button

            ////////////////////////////////////////////////////////////
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
            Form1.MainCommand[2] = 25;//資料數
            Form1.MainCommand[3] = 42;//頁數
           // Form1.MainCommand[4] = Title[0];//標頭檔名1
           
            Form1.MainCommand[4] = Convert.ToByte(textBox3.Text.ToString());//jobid
            Form1.MainCommand[5] = Convert.ToByte(textBox5.Text.ToString()); ;//seqid
            Form1.MainCommand[6] = Convert.ToByte(textBox7.Text.ToString());//stepid

            Button1[0] = 8;//back
            Button2[0] = 9;//next
            Button3[0] = 10;//step
            Form1.MainCommand[7] = Button1[0];//back
            Form1.MainCommand[8] = Button2[0];//next
            Form1.MainCommand[9] = Button3[0];//step
          

            if (radioButton4.Checked)
            {
                Form1.MainCommand[10] = 1;//0:Target Ang.
            }
            if (radioButton9.Checked)
            {
                Form1.MainCommand[10] = 2;//1:Target Tor.
            }

           

            if (radioButton10.Checked)
            {
                Form1.MainCommand[11] = 0;//Kgf.m
            }

            if (radioButton11.Checked)
            {
                Form1.MainCommand[11] = 1; //1.N.m
            }

            if (radioButton3.Checked)
            {
                Form1.MainCommand[11] = 2; //2.Kgf.cm
            }

            if (radioButton5.Checked)
            {
                Form1.MainCommand[11] = 3; //3.In.lbs
            }

            if (radioButton6.Checked)
            {
                Form1.MainCommand[11] = 4; //4.cN.m
            }

            if (radioButton7.Checked)
            {
                Form1.MainCommand[11] = 9; //9Degree
            }



            if (radioButton18.Checked)
            {
                Form1.MainCommand[12] = 0;//Kgf.m
            }

            if (radioButton17.Checked)
            {
                Form1.MainCommand[12] = 1; //1.N.m
            }

            if (radioButton16.Checked)
            {
                Form1.MainCommand[12] = 2; //2.Kgf.cm
            }

            if (radioButton15.Checked)
            {
                Form1.MainCommand[12] = 3; //3.In.lbs
            }

            if (radioButton14.Checked)
            {
                Form1.MainCommand[12] = 4; //4.cN.m
            }
            Form1.MainCommand[13] = Step_Idarray[0];//step id

            if (radioButton4.Checked)
            {
                string angle = "";
                UInt16[] angle_array = new UInt16[2];
                byte[] angle_array_Byte = new byte[2];
                angle = "";
                angle = textBox8.Text.ToString(); ;
             //   richTextBox1.Text += "angle_array=" + angle.ToString() + "\r\n";

                angle_array[0] = (UInt16)((Convert.ToUInt16(angle)) & 0xff);
                angle_array_Byte[0] = (Byte)((Convert.ToByte(angle_array[0])));//want++
            //    richTextBox1.Text += "angle_array Lbyte=" + angle_array_Byte[0].ToString() + "\r\n";

                angle_array[1] = (UInt16)((Convert.ToUInt16(angle) >> 8) & 0xff);
                angle_array_Byte[1] = (Byte)((Convert.ToByte(angle_array[1]) & 0xff));//want++
             //   richTextBox1.Text += "angle_array Hbyte=" + angle_array_Byte[1].ToString() + "\r\n";

                Form1.MainCommand[14] = angle_array_Byte[0];//Torang_LSB

                Form1.MainCommand[15] = angle_array_Byte[1];//Torang_H1
                Form1.MainCommand[16] = 0;//Torang_H2
                Form1.MainCommand[17] = 0;//Torang_MSB

            }
            if (radioButton9.Checked)
            {

                string TourqeNow_int2221 = "";
                UInt64[] TourqeNow_intarray641 = new UInt64[4];
                UInt32[] TourqeNow_intarray_321 = new UInt32[4];
                UInt16[] TourqeNow_intarray_161 = new UInt16[4];
                Byte[] TourqeNow_intarray_Byte2221 = new Byte[4];
                TourqeNow_int2221 = "";
                TourqeNow_int2221 = textBox11.Text.ToString();



                //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

                TourqeNow_intarray_161[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221)) & 0xffff);
                TourqeNow_intarray_Byte2221[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0] >> 8)) & 0xff);//want++
                TourqeNow_intarray_161[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221) >> 16) & 0xffff);
                TourqeNow_intarray_Byte2221[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1] >> 8)) & 0xff);//want++
                                                                                                              //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";

                //  richTextBox1.Text += "TourqeNow_int Hbyte=" + TourqeNow_intarray_Byte[1].ToString() + "\r\n";

                /////////////////////////////////////////



                Form1.MainCommand[14] = TourqeNow_intarray_Byte2221[0];
                Form1.MainCommand[15] = TourqeNow_intarray_Byte2221[1];
                Form1.MainCommand[16] = TourqeNow_intarray_Byte2221[2];
                Form1.MainCommand[17] = TourqeNow_intarray_Byte2221[3];
            }

            if (radioButton12.Checked)
                Form1.MainCommand[18] = 0;//CW
            if (radioButton13.Checked)
                Form1.MainCommand[18] = 1;//CCW






            Form1.MainCommand[19] = speed_array_Byte[0];
            Form1.MainCommand[20] = speed_array_Byte[1];
            string TourqeNow_int222 = "";
            UInt64[] TourqeNow_intarray64 = new UInt64[4];
            UInt32[] TourqeNow_intarray_32 = new UInt32[4];
            UInt16[] TourqeNow_intarray_16 = new UInt16[4];
            Byte[] TourqeNow_intarray_Byte222 = new Byte[4];
            TourqeNow_int222 = "";
            TourqeNow_int222 = textBox6.Text.ToString();


            long number = long.Parse(textBox6.Text.ToString());
            byte[] data = BitConverter.GetBytes(number);
            //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

          /*  TourqeNow_intarray_16[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int222)) & 0xffff);
            TourqeNow_intarray_Byte222[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[0])) & 0xff);//want++
            TourqeNow_intarray_Byte222[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[0] >> 8)) & 0xff);//want++
            TourqeNow_intarray_16[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int222) >> 16) & 0xffff);
            TourqeNow_intarray_Byte222[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[1])) & 0xff);//want++
            TourqeNow_intarray_Byte222[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_16[1] >> 8)) & 0xff);//want++
                                                                                                             //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";
          */
            Form1.MainCommand[21] = data[0];//TourqeNow_intarray_Byte222[0];
            Form1.MainCommand[22] = data[1];// TourqeNow_intarray_Byte222[1];
            Form1.MainCommand[23] = data[2];// TourqeNow_intarray_Byte222[2];
            Form1.MainCommand[24] = data[3];// TourqeNow_intarray_Byte222[3];

            string DelayTime = "";
            UInt16[] DelayTime_array = new UInt16[2];
            byte[] DelayTime_array_Byte = new byte[2];
            DelayTime = "";
            DelayTime = textBox2.Text.ToString(); ;
            //   richTextBox1.Text += "DelayTime_array=" + DelayTime.ToString() + "\r\n";

            DelayTime_array[0] = (UInt16)((Convert.ToUInt16(DelayTime)) & 0xff);
            DelayTime_array_Byte[0] = (Byte)((Convert.ToByte(DelayTime_array[0])));//want++
            richTextBox1.Text += "DelayTime_array Lbyte=" + DelayTime_array_Byte[0].ToString() + "\r\n";


            DelayTime_array[1] = (UInt16)((Convert.ToUInt16(DelayTime) >> 8) & 0xff);
            DelayTime_array_Byte[1] = (Byte)((Convert.ToByte(DelayTime_array[1]) & 0xff));//want++
            richTextBox1.Text += "DelayTime_array Hbyte=" + DelayTime_array_Byte[1].ToString() + "\r\n";
            Form1.MainCommand[25] = DelayTime_array_Byte[0];
            Form1.MainCommand[26] = DelayTime_array_Byte[1];





            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            for (i = 2; i <= 26;i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[27] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            for (i = 0; i <= 27; i++)
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
            radioButton2.Text = "Job-"+textBox3.Text.ToString()+" Seq-"+textBox5.Text.ToString() + " Step1-" + textBox7.Text.ToString();
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            label2.Text = "Target Ang.";
        }

        private void radioButton9_CheckedChanged_1(object sender, EventArgs e)
        {
            label2.Text = "Target Tor.";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {
            label13.Text = "Kgf.m";
        }

        private void radioButton11_CheckedChanged_1(object sender, EventArgs e)
        {
            
            label13.Text = "N.m";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = "CW";
        }

        private void radioButton13_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = "CCW";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0)
                label5.Text = (Convert.ToDouble(textBox6.Text.ToString()) / 10).ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
                label10.Text = (Convert.ToDouble(textBox2.Text.ToString()) / 100).ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            radioButton2.Text = "Job-" + textBox3.Text.ToString() + "Seq-" + textBox5.Text.ToString() + "Step1-" + textBox7.Text.ToString();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            label13.Text = "Kgf.cm";

        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            label13.Text = "In.lbs";
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            label13.Text = "cN.m";
        }

        private void radioButton7_CheckedChanged_1(object sender, EventArgs e)
        {
            label13.Text = "Degree";
        }

        private void radioButton18_CheckedChanged_1(object sender, EventArgs e)
        {
            label7.Text = "Kgf.m";
        }

        private void label7_Click(object sender, EventArgs e)
        {
          
        }

        private void radioButton17_CheckedChanged_1(object sender, EventArgs e)
        {
            label7.Text = "N.m";
        }

        private void radioButton16_CheckedChanged_1(object sender, EventArgs e)
        {
            label7.Text = "Kgf.cm";
           
        }

        private void radioButton15_CheckedChanged_1(object sender, EventArgs e)
        {
            label7.Text = "In.lbs";
        }

        private void radioButton14_CheckedChanged_1(object sender, EventArgs e)
        {
            label7.Text = "cN.m";
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
            label23.Text = "Pg_JS_2_Step2_1";
        }

        private void radioButton19_CheckedChanged_1(object sender, EventArgs e)
        {
            label23.Text = "Page34";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            radioButton2.Text = "Job-" + textBox3.Text.ToString() + "Seq-" + textBox5.Text.ToString() + "Step1-" + textBox7.Text.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            radioButton2.Text = "Job-" + textBox3.Text.ToString() + "Seq-" + textBox5.Text.ToString() + "Step1-" + textBox7.Text.ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
