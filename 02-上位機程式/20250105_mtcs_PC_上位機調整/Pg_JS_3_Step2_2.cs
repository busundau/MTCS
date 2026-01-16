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
    public partial class Pg_JS_3_Step2_2 : Form
    {
        public Pg_JS_3_Step2_2()
        {
            InitializeComponent();
        }

        private void Pg_JS_3_Step2_2__Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                radioButton3.Checked = true;
                radioButton4.Checked = true;
                radioButton2.Checked = true;
                radioButton18.Checked = true;
            });
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
                  //  richTextBox1.Text += '0';
                    Applinkarray[i] = Convert.ToByte('0'); //want++
                }
                
               

            }
          //  richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {
               
           //   richTextBox1.Text += Applinkarray[i]+" ";
             }
           // richTextBox1.Text += "\r\n";
            ////////////////////////////////////////////////////////////////datauploand
            string str222 = "";
          //  str222 = textBox2.Text.ToString();
            byte[] datauploand = new byte[100];
            str222 = "";
          //  str222 = textBox2.Text.ToString();
           //
         //   richTextBox1.Text += "\r\n";
            for (i = 0; i < 16; i++)
            {

              //  richTextBox1.Text += datauploand[i] + " ";
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
           
           ////////////////////////////////////////////////////////Job
            string Step_Id = "";
            byte[] Step_Idarray = new byte[2];
            Step_Id = "";
         //   Step_Id = textBox4.Text.ToString();
          //  richTextBox1.Text += "Step_Id=" + Step_Id.ToString() + "\r\n";
            //Step_Idarray[0] = Convert.ToByte(Step_Id); ;//want++
            ///////////////////////////////////////////////////////////////////////Hi_Tourqe_int
            string Hi_Tourqe_int = "";
            UInt16[] Hi_Tourqe_intarray = new UInt16[2];
            byte[] Hi_Tourqe_intarray_Byte = new byte[2];
            Hi_Tourqe_int = "";
            Hi_Tourqe_int = textBox3.Text.ToString();
          //  richTextBox1.Text += "Hi_Tourqe_int=" + Hi_Tourqe_int.ToString() + "\r\n";
           
            //Hi_Tourqe_intarray[0] = (UInt16)((Convert.ToUInt16(Hi_Tourqe_int) ) & 0xff);
          //  Hi_Tourqe_intarray_Byte[0] = (Byte)((Convert.ToByte(Hi_Tourqe_intarray[0]) ));//want++
         //   richTextBox1.Text += "Hi_Tourqe_int Lbyte=" + Hi_Tourqe_intarray_Byte[0].ToString() + "\r\n";


          //  Hi_Tourqe_intarray[1] = (UInt16)((Convert.ToUInt16(Hi_Tourqe_int) >> 8) & 0xff);
         //   Hi_Tourqe_intarray_Byte[1] = (Byte)((Convert.ToByte(Hi_Tourqe_intarray[1]) & 0xff));//want++
           // richTextBox1.Text += "Hi_Tourqe_int Hbyte=" + Hi_Tourqe_intarray_Byte[1].ToString() + "\r\n";

            //////////////////////////////////////////////////////////Hi_Tourqe_float
            string Hi_Tourqe_float = "";
            UInt16[] Hi_Tourqe_floatarray = new UInt16[2];
            byte[] Hi_Tourqe_floatarray_Byte = new byte[2];
            Hi_Tourqe_float = "";
        //    Hi_Tourqe_float = textBox4.Text.ToString();
          //  richTextBox1.Text += "Hi_Tourqe_float=" + Hi_Tourqe_float.ToString() + "\r\n";
           
           // Hi_Tourqe_floatarray[0] = (UInt16)((Convert.ToUInt16(Hi_Tourqe_float)) & 0xff);
          //  Hi_Tourqe_floatarray_Byte[0] = (Byte)((Convert.ToByte(Hi_Tourqe_floatarray[0])));//want++
          //  richTextBox1.Text += "Hi_Tourqe_float Lbyte=" + Hi_Tourqe_floatarray_Byte[0].ToString() + "\r\n";

           // Hi_Tourqe_floatarray[1] = (UInt16)((Convert.ToUInt16(Hi_Tourqe_float) >> 8) & 0xff);
          //  Hi_Tourqe_floatarray_Byte[1] = (Byte)((Convert.ToByte(Hi_Tourqe_floatarray[1]) & 0xff));//want++
          //  richTextBox1.Text += "Hi_Tourqe_float Hbyte=" + Hi_Tourqe_floatarray[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////Lo_Tourqe_int
            string Lo_Tourqe_int = "";
            UInt16[] Lo_Tourqe_intarray = new UInt16[2];
            byte[] Lo_Tourqe_intarray_Byte = new byte[2];
            Lo_Tourqe_int = "";
            Lo_Tourqe_int = textBox11.Text.ToString();
          //  richTextBox1.Text += "Lo_Tourqe_int=" + Lo_Tourqe_int.ToString() + "\r\n";

           // Lo_Tourqe_intarray[0] = (UInt16)((Convert.ToUInt16(Lo_Tourqe_int)) & 0xff);
          //  Lo_Tourqe_intarray_Byte[0] = (Byte)((Convert.ToByte(Lo_Tourqe_intarray[0])));//want++
          //  richTextBox1.Text += "Lo_Tourqe_int Lbyte=" + Lo_Tourqe_intarray_Byte[0].ToString() + "\r\n";


          //  Lo_Tourqe_intarray[1] = (UInt16)((Convert.ToUInt16(Lo_Tourqe_int) >> 8) & 0xff);
          //  Lo_Tourqe_intarray_Byte[1] = (Byte)((Convert.ToByte(Lo_Tourqe_intarray[1]) & 0xff));//want++
         //   richTextBox1.Text += "Lo_Tourqe_int Hbyte=" + Lo_Tourqe_intarray_Byte[1].ToString() + "\r\n";

            //////////////////////////////////////////////////////////Lo_Tourqe_float
            string Lo_Tourqe_float = "";
            UInt16[] Lo_Tourqe_floatarray = new UInt16[2];
            byte[] Lo_Tourqe_floatarray_Byte = new byte[2];
            Lo_Tourqe_float = "";
          //  Lo_Tourqe_float = textBox12.Text.ToString();
           // richTextBox1.Text += "Lo_Tourqe_float=" + Lo_Tourqe_float.ToString() + "\r\n";

          //  Lo_Tourqe_floatarray[0] = (UInt16)((Convert.ToUInt16(Lo_Tourqe_float)) & 0xff);
          //  Lo_Tourqe_floatarray_Byte[0] = (Byte)((Convert.ToByte(Lo_Tourqe_floatarray[0])));//want++
          //  richTextBox1.Text += "Lo_Tourqe_float Lbyte=" + Lo_Tourqe_floatarray_Byte[0].ToString() + "\r\n";

          //  Lo_Tourqe_floatarray[1] = (UInt16)((Convert.ToUInt16(Lo_Tourqe_float) >> 8) & 0xff);
          //  Lo_Tourqe_floatarray_Byte[1] = (Byte)((Convert.ToByte(Lo_Tourqe_floatarray[1]) & 0xff));//want++
         //   richTextBox1.Text += "Lo_Tourqe_float Hbyte=" + Lo_Tourqe_floatarray[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///
            ///  ///////////////////////////////////////////////////////////////////////Threshold_Tor_int
            string Threshold_Tor_int = "";
            UInt16[] Threshold_Tor_intarray = new UInt16[2];
            byte[] Threshold_Tor_intarray_Byte = new byte[2];
            Threshold_Tor_int = "";
            Threshold_Tor_int = textBox7.Text.ToString();
          //  richTextBox1.Text += "Threshold_Tor_int=" + Threshold_Tor_int.ToString() + "\r\n";

         //   Threshold_Tor_intarray[0] = (UInt16)((Convert.ToUInt16(Threshold_Tor_int)) & 0xff);
       //     Threshold_Tor_intarray_Byte[0] = (Byte)((Convert.ToByte(Threshold_Tor_intarray[0])));//want++
         //   richTextBox1.Text += "Threshold_Tor_int Lbyte=" + Threshold_Tor_intarray_Byte[0].ToString() + "\r\n";


         //   Threshold_Tor_intarray[1] = (UInt16)((Convert.ToUInt16(Threshold_Tor_int) >> 8) & 0xff);
        //    Threshold_Tor_intarray_Byte[1] = (Byte)((Convert.ToByte(Threshold_Tor_intarray[1]) & 0xff));//want++
          //  richTextBox1.Text += "Threshold_Tor_int Hbyte=" + Threshold_Tor_intarray_Byte[1].ToString() + "\r\n";

            //////////////////////////////////////////////////////////Threshold_Tor_float
            string Threshold_Tor_float = "";
            UInt16[] Threshold_Tor_floatarray = new UInt16[2];
            byte[] Threshold_Tor_floatarray_Byte = new byte[2];
            Threshold_Tor_float = "";
           // Threshold_Tor_float = textBox5.Text.ToString();
          //  richTextBox1.Text += "Threshold_Tor_float=" + Threshold_Tor_float.ToString() + "\r\n";

         //   Threshold_Tor_floatarray[0] = (UInt16)((Convert.ToUInt16(Threshold_Tor_float)) & 0xff);
        //    Threshold_Tor_floatarray_Byte[0] = (Byte)((Convert.ToByte(Threshold_Tor_floatarray[0])));//want++
          //  richTextBox1.Text += "Threshold_Tor_float Lbyte=" + Threshold_Tor_floatarray_Byte[0].ToString() + "\r\n";

        //    Threshold_Tor_floatarray[1] = (UInt16)((Convert.ToUInt16(Threshold_Tor_float) >> 8) & 0xff);
       //     Threshold_Tor_floatarray_Byte[1] = (Byte)((Convert.ToByte(Threshold_Tor_floatarray[1]) & 0xff));//want++
         //   richTextBox1.Text += "Threshold_Tor_float Hbyte=" + Threshold_Tor_floatarray[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///  ///////////////////////////////////////////////////////////////////////Downshift_Tor_int
            string Downshift_Tor_int = "";
            UInt16[] Downshift_Tor_intarray = new UInt16[2];
            byte[] Downshift_Tor_intarray_Byte = new byte[2];
            Downshift_Tor_int = "";
            Downshift_Tor_int = textBox8.Text.ToString();
         //   richTextBox1.Text += "Downshift_Tor_int=" + Downshift_Tor_int.ToString() + "\r\n";

     //       Downshift_Tor_intarray[0] = (UInt16)((Convert.ToUInt16(Downshift_Tor_int)) & 0xff);
      //      Downshift_Tor_intarray_Byte[0] = (Byte)((Convert.ToByte(Downshift_Tor_intarray[0])));//want++
         //   richTextBox1.Text += "Downshift_Tor_int Lbyte=" + Downshift_Tor_intarray_Byte[0].ToString() + "\r\n";


      //      Downshift_Tor_intarray[1] = (UInt16)((Convert.ToUInt16(Downshift_Tor_int) >> 8) & 0xff);
      //      Downshift_Tor_intarray_Byte[1] = (Byte)((Convert.ToByte(Downshift_Tor_intarray[1]) & 0xff));//want++
          //  richTextBox1.Text += "Downshift_Tor_int Hbyte=" + Downshift_Tor_intarray_Byte[1].ToString() + "\r\n";

            //////////////////////////////////////////////////////////Downshift_Tor_float
            string Downshift_Tor_float = "";
            UInt16[] Downshift_Tor_floatarray = new UInt16[2];
            byte[] Downshift_Tor_floatarray_Byte = new byte[2];
            Downshift_Tor_float = "";
          //  Downshift_Tor_float = textBox2.Text.ToString();
         //   richTextBox1.Text += "Downshift_Tor_float=" + Downshift_Tor_float.ToString() + "\r\n";

       //     Downshift_Tor_floatarray[0] = (UInt16)((Convert.ToUInt16(Downshift_Tor_float)) & 0xff);
       //     Downshift_Tor_floatarray_Byte[0] = (Byte)((Convert.ToByte(Downshift_Tor_floatarray[0])));//want++
          //  richTextBox1.Text += "Downshift_Tor_float Lbyte=" + Downshift_Tor_floatarray_Byte[0].ToString() + "\r\n";

        //    Downshift_Tor_floatarray[1] = (UInt16)((Convert.ToUInt16(Downshift_Tor_float) >> 8) & 0xff);
         //   Downshift_Tor_floatarray_Byte[1] = (Byte)((Convert.ToByte(Downshift_Tor_floatarray[1]) & 0xff));//want++
         //   richTextBox1.Text += "Downshift_Tor_float Hbyte=" + Downshift_Tor_floatarray[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            /// 
            ///   //////////////////////////////////////////////////////////HighAngle

            string HighAngle = "";
            UInt16[] HighAngle_array = new UInt16[2];
            byte[] HighAngle_array_Byte = new byte[2];
          
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////LowAngle

            string LowAngle = "";
            UInt16[] LowAngle_array = new UInt16[2];
            byte[] LowAngle_array_Byte = new byte[2];
           
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////speed

            string Joint_Offest = "";
            UInt16[] Joint_Offest_array = new UInt16[2];
            byte[] Joint_Offest_array_Byte = new byte[2];
            Joint_Offest = "";
            Joint_Offest = textBox6.Text.ToString(); ;
        //    richTextBox1.Text += "Joint_Offest_array=" + Joint_Offest.ToString() + "\r\n";

            Joint_Offest_array[0] = (UInt16)((Convert.ToUInt16(Joint_Offest)) & 0xff);
            Joint_Offest_array_Byte[0] = (Byte)((Convert.ToByte(Joint_Offest_array[0])));//want++
        //    richTextBox1.Text += "Joint_Offest_array Lbyte=" + Joint_Offest_array_Byte[0].ToString() + "\r\n";


            Joint_Offest_array[1] = (UInt16)((Convert.ToUInt16(Joint_Offest) >> 8) & 0xff);
            Joint_Offest_array_Byte[1] = (Byte)((Convert.ToByte(Joint_Offest_array[1]) & 0xff));//want++
        //    richTextBox1.Text += "Joint_Offest_array Hbyte=" + Joint_Offest_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////speed

            string DelayTime = "";
            UInt16[] DelayTime_array = new UInt16[2];
            byte[] DelayTime_array_Byte = new byte[2];
            DelayTime = "";
           // DelayTime = textBox2.Text.ToString(); ;
         //   richTextBox1.Text += "DelayTime_array=" + DelayTime.ToString() + "\r\n";

          //  DelayTime_array[0] = (UInt16)((Convert.ToUInt16(DelayTime)) & 0xff);
          //  DelayTime_array_Byte[0] = (Byte)((Convert.ToByte(DelayTime_array[0])));//want++
         //   richTextBox1.Text += "DelayTime_array Lbyte=" + DelayTime_array_Byte[0].ToString() + "\r\n";

//
        //    DelayTime_array[1] = (UInt16)((Convert.ToUInt16(DelayTime) >> 8) & 0xff);
        //    DelayTime_array_Byte[1] = (Byte)((Convert.ToByte(DelayTime_array[1]) & 0xff));//want++
       //     richTextBox1.Text += "DelayTime_array Hbyte=" + DelayTime_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////Threshold_Angle

            string Threshold_Angle = "";
            UInt16[] Threshold_Angle_array = new UInt16[2];
            byte[] Threshold_Angle_array_Byte = new byte[2];
            Threshold_Angle = "";
            Threshold_Angle = textBox9.Text.ToString(); ;
        //    richTextBox1.Text += "Threshold_Angle_array=" + Threshold_Angle.ToString() + "\r\n";

          //  Threshold_Angle_array[0] = (UInt16)((Convert.ToUInt16(Threshold_Angle)) & 0xff);
        //    Threshold_Angle_array_Byte[0] = (Byte)((Convert.ToByte(Threshold_Angle_array[0])));//want++
        //    richTextBox1.Text += "Threshold_Angle_array Lbyte=" + Threshold_Angle_array_Byte[0].ToString() + "\r\n";


          //  Threshold_Angle_array[1] = (UInt16)((Convert.ToUInt16(Threshold_Angle) >> 8) & 0xff);
        //    Threshold_Angle_array_Byte[1] = (Byte)((Convert.ToByte(Threshold_Angle_array[1]) & 0xff));//want++
         //   richTextBox1.Text += "Threshold_Angle_array Hbyte=" + Threshold_Angle_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            ///   //////////////////////////////////////////////////////////Downshift_Angle

            string Downshift_Angle = "";
            UInt16[] Downshift_Angle_array = new UInt16[2];
            byte[] Downshift_Angle_array_Byte = new byte[2];
            Downshift_Angle = "";
            Downshift_Angle = textBox10.Text.ToString(); ;
         //   richTextBox1.Text += "Downshift_Angle_array=" + Downshift_Angle.ToString() + "\r\n";

         //   Downshift_Angle_array[0] = (UInt16)((Convert.ToUInt16(Downshift_Angle)) & 0xff);
        //    Downshift_Angle_array_Byte[0] = (Byte)((Convert.ToByte(Downshift_Angle_array[0])));//want++
         //   richTextBox1.Text += "Downshift_Angle_array Lbyte=" + Downshift_Angle_array_Byte[0].ToString() + "\r\n";


        //    Downshift_Angle_array[1] = (UInt16)((Convert.ToUInt16(Downshift_Angle) >> 8) & 0xff);
        //    Downshift_Angle_array_Byte[1] = (Byte)((Convert.ToByte(Downshift_Angle_array[1]) & 0xff));//want++
         //   richTextBox1.Text += "Downshift_Angle_array Hbyte=" + Downshift_Angle_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
         
            ///   //////////////////////////////////////////////////////////Downshift_Spd

            string Downshift_Spd = "";
            UInt16[] Downshift_Spd_array = new UInt16[2];
            byte[] Downshift_Spd_array_Byte = new byte[2];
            Downshift_Spd = "";
            Downshift_Spd = textBox6.Text.ToString(); ;
        //    richTextBox1.Text += "Downshift_Spd_array=" + Downshift_Spd.ToString() + "\r\n";

          //  Downshift_Spd_array[0] = (UInt16)((Convert.ToUInt16(Downshift_Spd)) & 0xff);
         //   Downshift_Spd_array_Byte[0] = (Byte)((Convert.ToByte(Downshift_Spd_array[0])));//want++
      //      richTextBox1.Text += "Downshift_Spd_array Lbyte=" + Downshift_Spd_array_Byte[0].ToString() + "\r\n";


         //   Downshift_Spd_array[1] = (UInt16)((Convert.ToUInt16(Downshift_Spd) >> 8) & 0xff);
         //   Downshift_Spd_array_Byte[1] = (Byte)((Convert.ToByte(Downshift_Spd_array[1]) & 0xff));//want++
        //    richTextBox1.Text += "Downshift_Spd_array Hbyte=" + Downshift_Spd_array_Byte[1].ToString() + "\r\n";
            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////



            ///////////////////////////////////////////////////////////////////////////////
        //    richTextBox1.Text += "ok_state=" + ok_state.ToString() + "\r\n";//ok_state
         //   richTextBox1.Text += "pagebutton_press=" + pagebutton_press.ToString() + "\r\n";//pagebutton Button
        //    richTextBox1.Text += "Barcode_press=" + Barcode_press.ToString() + "\r\n";//Barcode_press Button
         //   richTextBox1.Text += "Confirm_press=" + Confirm_press.ToString() + "\r\n";//Confirm_press Button

            ////////////////////////////////////////////////////////////
            Form1.MainCommand[0] = 0x3b;
            Form1.MainCommand[1] = 0x2c;
        
                Form1.MainCommand[2] = 33;//資料數
           
                Form1.MainCommand[3] = 43;//頁數
          
                                          // Form1.MainCommand[4] = Title[0];//標頭檔名1
          
                Form1.MainCommand[4] = Convert.ToByte(textBox16.Text.ToString());//jobid
            Form1.MainCommand[5] = Convert.ToByte(textBox15.Text.ToString());//seqid
            Form1.MainCommand[6] = Convert.ToByte(textBox13.Text.ToString());//stepid


            Button1[0] = 8;//back
            Button2[0] = 9;//next
            Button3[0] = 10;//step
            Form1.MainCommand[7] = Button1[0];//back
            Form1.MainCommand[8] = Button2[0];//next
            Form1.MainCommand[9] = Button3[0];//step
            if (radioButton18.Checked==true)
            {
                Form1.MainCommand[10] = 0;
            }
            if (radioButton17.Checked == true)
            {
                Form1.MainCommand[10] = 1;
            }
            if (radioButton16.Checked == true)
            {
                Form1.MainCommand[10] = 2;
            }
            if (radioButton15.Checked == true)
            {
                Form1.MainCommand[10] = 3;
            }
            if (radioButton14.Checked == true)
            {
                Form1.MainCommand[10] = 4;
            }
            ////////////////////////////////////////////////////////
            ///
            string TourqeNow_int2221 = "";
            UInt64[] TourqeNow_intarray641 = new UInt64[4];
            UInt32[] TourqeNow_intarray_321 = new UInt32[4];
            UInt16[] TourqeNow_intarray_161 = new UInt16[4];
            Byte[] TourqeNow_intarray_Byte2221 = new Byte[4];
            TourqeNow_int2221 = "";
            TourqeNow_int2221 = textBox3.Text.ToString();



            //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

            TourqeNow_intarray_161[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221)) & 0xffff);
            TourqeNow_intarray_Byte2221[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0])) & 0xff);//want++
            TourqeNow_intarray_Byte2221[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0] >> 8)) & 0xff);//want++
            TourqeNow_intarray_161[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221) >> 16) & 0xffff);
            TourqeNow_intarray_Byte2221[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1])) & 0xff);//want++
            TourqeNow_intarray_Byte2221[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1] >> 8)) & 0xff);//want++
                                                                                                               //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";




            Form1.MainCommand[11] = TourqeNow_intarray_Byte2221[0];
            Form1.MainCommand[12] = TourqeNow_intarray_Byte2221[1];
            Form1.MainCommand[13] = TourqeNow_intarray_Byte2221[2];
            Form1.MainCommand[14] = TourqeNow_intarray_Byte2221[3];


            ///////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            ///
          //  string TourqeNow_int2221 = "";
          //  UInt64[] TourqeNow_intarray641 = new UInt64[4];
         //   UInt32[] TourqeNow_intarray_321 = new UInt32[4];
         //   UInt16[] TourqeNow_intarray_161 = new UInt16[4];
         //   Byte[] TourqeNow_intarray_Byte2221 = new Byte[4];
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




            Form1.MainCommand[15] = TourqeNow_intarray_Byte2221[0];
            Form1.MainCommand[16] = TourqeNow_intarray_Byte2221[1];
            Form1.MainCommand[17] = TourqeNow_intarray_Byte2221[2];
            Form1.MainCommand[18] = TourqeNow_intarray_Byte2221[3];


            ///////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////
            ///
            HighAngle = "";
            HighAngle = textBox14.Text.ToString(); ;
            //     richTextBox1.Text += "HighAngle_array=" + HighAngle.ToString() + "\r\n";

            HighAngle_array[0] = (UInt16)((Convert.ToUInt16(HighAngle)) & 0xff);
            HighAngle_array_Byte[0] = (Byte)((Convert.ToByte(HighAngle_array[0])));//want++
                                                                                   //      richTextBox1.Text += "HighAngle_array Lbyte=" + HighAngle_array_Byte[0].ToString() + "\r\n";


            HighAngle_array[1] = (UInt16)((Convert.ToUInt16(HighAngle) >> 8) & 0xff);
            HighAngle_array_Byte[1] = (Byte)((Convert.ToByte(HighAngle_array[1]) & 0xff));//want++
                                                                                          //     richTextBox1.Text += "HighAngle_array Hbyte=" + HighAngle_array_Byte[1].ToString() + "\r\n";

            LowAngle = "";
            LowAngle = textBox1.Text.ToString(); ;
            //      richTextBox1.Text += "LowAngle_array=" + LowAngle.ToString() + "\r\n";

            LowAngle_array[0] = (UInt16)((Convert.ToUInt16(LowAngle)) & 0xff);
            LowAngle_array_Byte[0] = (Byte)((Convert.ToByte(LowAngle_array[0])));//want++
                                                                                 //    richTextBox1.Text += "LowAngle_array Lbyte=" + LowAngle_array_Byte[0].ToString() + "\r\n";


            LowAngle_array[1] = (UInt16)((Convert.ToUInt16(LowAngle) >> 8) & 0xff);
            LowAngle_array_Byte[1] = (Byte)((Convert.ToByte(LowAngle_array[1]) & 0xff));//want++
                                                                                        //    richTextBox1.Text += "LowAngle_array Hbyte=" + LowAngle_array_Byte[1].ToString() + "\r\n";


            Form1.MainCommand[19] = HighAngle_array_Byte[0];
            Form1.MainCommand[20] = HighAngle_array_Byte[1];
            Form1.MainCommand[21] = LowAngle_array_Byte[0];
            Form1.MainCommand[22] = LowAngle_array_Byte[1];

            ///////////////////////////////////////////////////////////////////
            /// 
            if (radioButton6.Checked)
            {
                Form1.MainCommand[23] = 0; //0:Threshold off
                Form1.MainCommand[24] = 0;
                Form1.MainCommand[25] = 0;
                Form1.MainCommand[26] = 0;
                Form1.MainCommand[27] = 0;
            }
                if (radioButton4.Checked)
            {
                Form1.MainCommand[23] = 1; //0:Threshold Ang.

                TourqeNow_int2221 = "";
                TourqeNow_int2221 = textBox9.Text.ToString();



                //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

                TourqeNow_intarray_161[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221)) & 0xffff);
                TourqeNow_intarray_Byte2221[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0] >> 8)) & 0xff);//want++
                TourqeNow_intarray_161[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221) >> 16) & 0xffff);
                TourqeNow_intarray_Byte2221[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1] >> 8)) & 0xff);//want++
                                                                                                                   //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";




                Form1.MainCommand[24] = TourqeNow_intarray_Byte2221[0];
                Form1.MainCommand[25] = TourqeNow_intarray_Byte2221[1];
                Form1.MainCommand[26] = TourqeNow_intarray_Byte2221[2];
                Form1.MainCommand[27] = TourqeNow_intarray_Byte2221[3];
            }
          
            if (radioButton5.Checked) {

                Form1.MainCommand[23] = 2;


               // string TourqeNow_int2221 = "";
               // UInt64[] TourqeNow_intarray641 = new UInt64[4];
              //  UInt32[] TourqeNow_intarray_321 = new UInt32[4];
              //  UInt16[] TourqeNow_intarray_161 = new UInt16[4];
             //   Byte[] TourqeNow_intarray_Byte2221 = new Byte[4];
                TourqeNow_int2221 = "";
                TourqeNow_int2221 = textBox7.Text.ToString();



                //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

                TourqeNow_intarray_161[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221)) & 0xffff);
                TourqeNow_intarray_Byte2221[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0] >> 8)) & 0xff);//want++
                TourqeNow_intarray_161[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221) >> 16) & 0xffff);
                TourqeNow_intarray_Byte2221[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1] >> 8)) & 0xff);//want++
                                                                                                                   //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";




                Form1.MainCommand[24] = TourqeNow_intarray_Byte2221[0];
                Form1.MainCommand[25] = TourqeNow_intarray_Byte2221[1];
                Form1.MainCommand[26] = TourqeNow_intarray_Byte2221[2];
                Form1.MainCommand[27] = TourqeNow_intarray_Byte2221[3];

            }

            if (radioButton7.Checked)
            {
                Form1.MainCommand[28] = 0; //0:Threshold off
                Form1.MainCommand[29] = 0;
                Form1.MainCommand[30] = 0;
                Form1.MainCommand[31] = 0;
                Form1.MainCommand[32] = 0;
            }
            if (radioButton2.Checked)
            {
                Form1.MainCommand[28] = 1; 

                TourqeNow_int2221 = "";
                TourqeNow_int2221 = textBox10.Text.ToString();//downshift angle.



                //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

                TourqeNow_intarray_161[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221)) & 0xffff);
                TourqeNow_intarray_Byte2221[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0] >> 8)) & 0xff);//want++
                TourqeNow_intarray_161[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221) >> 16) & 0xffff);
                TourqeNow_intarray_Byte2221[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1] >> 8)) & 0xff);//want++
                                                                                                                   //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";




                Form1.MainCommand[29] = TourqeNow_intarray_Byte2221[0];
                Form1.MainCommand[30] = TourqeNow_intarray_Byte2221[1];
                Form1.MainCommand[31] = TourqeNow_intarray_Byte2221[2];
                Form1.MainCommand[32] = TourqeNow_intarray_Byte2221[3];


            }

            if (radioButton1.Checked)
            {
                Form1.MainCommand[28] = 2; //downshift tor.

                TourqeNow_int2221 = "";
                TourqeNow_int2221 = textBox8.Text.ToString();



                //  richTextBox1.Text += "TourqeNow_int=" + TourqeNow_int.ToString() + "\r\n";

                TourqeNow_intarray_161[0] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221)) & 0xffff);
                TourqeNow_intarray_Byte2221[0] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[1] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[0] >> 8)) & 0xff);//want++
                TourqeNow_intarray_161[1] = (UInt16)((Convert.ToUInt32(TourqeNow_int2221) >> 16) & 0xffff);
                TourqeNow_intarray_Byte2221[2] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1])) & 0xff);//want++
                TourqeNow_intarray_Byte2221[3] = (Byte)((Convert.ToUInt16(TourqeNow_intarray_161[1] >> 8)) & 0xff);//want++
                                                                                                                   //   richTextBox1.Text += "TourqeNow_int Lbyte=" + TourqeNow_intarray_Byte[0].ToString() + "\r\n";




                Form1.MainCommand[29] = TourqeNow_intarray_Byte2221[0];
                Form1.MainCommand[30] = TourqeNow_intarray_Byte2221[1];
                Form1.MainCommand[31] = TourqeNow_intarray_Byte2221[2];
                Form1.MainCommand[32] = TourqeNow_intarray_Byte2221[3];
            }



            TourqeNow_int2221 = "";
            TourqeNow_int2221 = textBox11.Text.ToString();




            ///
            HighAngle = "";
            HighAngle = textBox6.Text.ToString(); ;
            //     richTextBox1.Text += "HighAngle_array=" + HighAngle.ToString() + "\r\n";

            HighAngle_array[0] = (UInt16)((Convert.ToUInt16(HighAngle)) & 0xff);
            HighAngle_array_Byte[0] = (Byte)((Convert.ToByte(HighAngle_array[0])));//want++
                                                                                   //      richTextBox1.Text += "HighAngle_array Lbyte=" + HighAngle_array_Byte[0].ToString() + "\r\n";


            HighAngle_array[1] = (UInt16)((Convert.ToUInt16(HighAngle) >> 8) & 0xff);
            HighAngle_array_Byte[1] = (Byte)((Convert.ToByte(HighAngle_array[1]) & 0xff));//want++
                                                                                          //     richTextBox1.Text += "HighAngle_array Hbyte=" + HighAngle_array_Byte[1].ToString() + "\r\n";

                                                                                      //    richTextBox1.Text += "LowAngle_array Hbyte=" + LowAngle_array_Byte[1].ToString() + "\r\n";


            Form1.MainCommand[33] = HighAngle_array_Byte[0];
            Form1.MainCommand[34] = HighAngle_array_Byte[1];

            byte Protocol_CheckSum;
            Protocol_CheckSum = 0;
            for (i = 2; i <= 34;i++)
            {
                Protocol_CheckSum += Form1.MainCommand[i];
            }
            Form1.MainCommand[35] = Protocol_CheckSum;//check sum
            richTextBox1.Text += "#########################################################\r\n";
            for (i = 0; i <= 35; i++)
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
          //  textBox2.Text = "";
        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {
           // textBox2.Text = "Data Full";
        }

        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {
           // textBox2.Text = "Setting,,,";
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
            textBox18.Text = "Job-1 Seq-1 Step1-2";
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
            
        }

        private void radioButton11_CheckedChanged_1(object sender, EventArgs e)
        {
           
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

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged_2(object sender, EventArgs e)
        {
          
           
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
           
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            
            textBox18.Text = "Job-" + textBox16.Text.ToString() + "Seq-" + textBox15.Text.ToString() + "Step1-" + textBox13.Text.ToString();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            radioButton3.Text = "Job-" + textBox16.Text.ToString() + "Seq-" + textBox15.Text.ToString() + "Step1-" + textBox13.Text.ToString();
            textBox18.Text = "Job-" + textBox16.Text.ToString() + "Seq-" + textBox15.Text.ToString() + "Step1-" + textBox13.Text.ToString();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            radioButton3.Text = "Job-" + textBox16.Text.ToString() + "Seq-" + textBox15.Text.ToString() + "Step1-" + textBox13.Text.ToString();
            textBox18.Text = "Job-" + textBox16.Text.ToString() + "Seq-" + textBox15.Text.ToString() + "Step1-" + textBox13.Text.ToString();
        }

        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {
            radioButton3.Text = "Job-" + textBox16.Text.ToString() + "Seq-" + textBox15.Text.ToString() + "Step1-" + textBox13.Text.ToString();
            textBox18.Text = "Job-" + textBox16.Text.ToString() + "Seq-" + textBox15.Text.ToString() + "Step1-" + textBox13.Text.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pg_JS_3_Step2_2_Load(object sender, EventArgs e)
        {

        }
    }
}
