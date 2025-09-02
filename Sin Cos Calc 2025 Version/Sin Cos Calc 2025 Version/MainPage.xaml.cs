using Sin_Cos_Calc_2025_Version.Sin_Cos_Calculator;

namespace Sin_Cos_Calc_2025_Version
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            if (Cos.IsChecked)
            {
                string zero1 = "";
                string zero2 = "";
                string zero3 = "";

                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    zero1 = zero1 + "0";

                    if (i < Convert.ToInt32(textBox1.Text) - 2)
                    {
                        zero2 = zero2 + "0";
                    }

                    if (i < Convert.ToInt32(textBox1.Text) - 1)
                    {
                        zero3 = zero3 + "0";
                    }
                }

                InfiNum.zeroAFTp = zero1;
                Angle.zeroAFTp = zero2;
                Angle.zeroAFTp2 = zero3;

                Angle.GetCosSin(new InfiNum(textBox6.Text), new InfiNum[2] { new InfiNum(textBox2.Text), new InfiNum(textBox3.Text) }, new InfiNum[2] { new InfiNum(textBox4.Text), new InfiNum(textBox5.Text) }, out InfiNum[] newpos);

                textBox7.Text = newpos[0].Value;
                textBox8.Text = newpos[1].Value;
            }

            else
            {
                string zero1 = "";
                string zero2 = "";
                string zero3 = "";

                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    zero1 = zero1 + "0";

                    if (i < Convert.ToInt32(textBox1.Text) - 2)
                    {
                        zero2 = zero2 + "0";
                    }

                    if (i < Convert.ToInt32(textBox1.Text) - 1)
                    {
                        zero3 = zero3 + "0";
                    }
                }

                InfiNum.zeroAFTp = zero1;
                Angle.zeroAFTp = zero2;
                Angle.zeroAFTp2 = zero3;

                Angle.GetDegreeAngle(new InfiNum[2] { new InfiNum(textBox4.Text), new InfiNum(textBox5.Text) }, new InfiNum[2] { new InfiNum(textBox2.Text), new InfiNum(textBox3.Text) }, new InfiNum[2] { new InfiNum(textBox7.Text), new InfiNum(textBox8.Text) }, out InfiNum angle);

                textBox6.Text = angle.Value;
            }
        }

        bool stop = false;

        private void Cos_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (stop == false)
            {
                stop = true;

                if (Cosneg1.IsChecked == false)
                {
                    Cos.IsChecked = true;
                }

                else
                {
                    Cosneg1.IsChecked = false;
                }

                stop = false;
            }
        }

        private void Cosneg1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (stop == false)
            {
                stop = true;

                if (Cos.IsChecked == false)
                {
                    Cosneg1.IsChecked = true;
                }

                else
                {
                    Cos.IsChecked = false;
                }

                stop = false;
            }
        }
    }

}
