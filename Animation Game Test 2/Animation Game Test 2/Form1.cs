using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Animation_Game_Test_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap picture = new Bitmap(200, 200);
        Stopwatch t = new Stopwatch();

        bool normal = true;

        string memx = "200";
        string memy = "200";

        int x = 200;
        int y = 200;

        int k = 0;

        int x2 = 0;
        int y2 = 0;

        int xh = 0;
        int yh = 0;

        Color[] c = new Color[30];

        bool stopasync = false;

        bool stop = false;

        private async void button1_Click(object sender, EventArgs e)
        {
            if (c[0] == Color.Empty)
            {
                MessageBox.Show("Not valid number of colors. Please select at least 1 color.");
            }

            else
            {
                done = false;

                mag = 0;

                textBox1.Text = memx;
                textBox2.Text = memy;

                stop = false;

                pictureBox1.BackColor = Color.Black;

                textBox1.Enabled = false;
                textBox2.Enabled = false;

                button3.Enabled = false;
                button2.Enabled = false;
                button1.Enabled = false;
                trackBar1.Enabled = false;

                int timee = x * y / 1000;

                button1.Text = "Wait for " + timee.ToString() + " seconds please";

                for (x2 = 0; x2 < x; x2++)
                {
                    for (y2 = 0; y2 < y; y2++)
                    {
                        picture.SetPixel(x2, y2, Color.Black);
                    }
                }

                if (stop == false)
                {
                    if (stopasync == false)
                    {
                        for (x2 = 0; x2 < x; x2++)
                        {
                            if (stop == false)
                            {
                                if (stopasync == false)
                                {
                                    for (y2 = 0; y2 < y; y2++)
                                    {
                                        if (stop == false)
                                        {
                                            if (stopasync == false)
                                            {
                                                stopasync = true;
                                                await Task.Run(() => GetPixel());

                                                if (stopasync == false)
                                                {
                                                    if (normal == true)
                                                    {
                                                        picture.SetPixel(x2, y2, c[k]);
                                                    }

                                                    else
                                                    {
                                                        picture.SetPixel(y2, x2, c[k]);
                                                    }

                                                    pictureBox1.Image = picture;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = true;
            button1.Enabled = true;
            trackBar1.Enabled = true;
            button1.Text = "Generate random picture!";
        }

        int fk = 0;

        private async Task GetPixel()
        {
            if (stop == false)
            {
                if (radioButton1.Checked == true)
                {
                    if (color == 1)
                    {
                        k = 0;
                    }

                    else
                    {
                        t.Start();

                        for (int l = 1; t.ElapsedMilliseconds < 10; l++)
                        {
                            if (l < color)
                            {
                                k = l;
                            }

                            else
                            {
                                k = l - l / color * color;
                            }
                        }

                        t.Stop();
                        t.Reset();
                    }
                }

                else
                {
                    t.Start();

                    for (int l = 1; t.ElapsedTicks <= 60; l++)
                    {
                        if (l < color)
                        {
                            k = l;
                        }

                        else
                        {
                            k = l - l / color * color;
                        }
                    }

                    t.Stop();
                    t.Reset();
                }
            }

            stopasync = false;
        }

        int color = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;

            button5.Visible = false;

            for (x2 = 0; x2 < x; x2++)
            {
                for (y2 = 0; y2 < y; y2++)
                {
                    picture.SetPixel(x2, y2, Color.Black);
                }
            }

            trackBar1.Minimum = 1;
            trackBar1.Maximum = 2;

            xh = Convert.ToInt32(textBox1.Text);
            yh = Convert.ToInt32(textBox2.Text);

            Black.Checked = true;
            White.Checked = true;

            normal = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "BMP(*.BMP)|*.bmp";

            if (save.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string a = textBox1.Text;

            char[] ca = a.ToCharArray();

            if (ca.Length > 0)
            {
                if (ca.Length > 5)
                {
                    MessageBox.Show("Not valid number. Please enter a number there from 1 to 65535");
                    textBox1.Text = memx.ToString();
                }

                else
                {
                    int lf = 0;
                    for (int i = 0; i < ca.Length; i++)
                    {
                        if (ca[i] == '0')
                        {
                            lf++;
                        }

                        if (ca[i] == '1')
                        {
                            lf++;
                        }

                        if (ca[i] == '2')
                        {
                            lf++;
                        }

                        if (ca[i] == '3')
                        {
                            lf++;
                        }

                        if (ca[i] == '4')
                        {
                            lf++;
                        }

                        if (ca[i] == '5')
                        {
                            lf++;
                        }

                        if (ca[i] == '6')
                        {
                            lf++;
                        }

                        if (ca[i] == '7')
                        {
                            lf++;
                        }

                        if (ca[i] == '8')
                        {
                            lf++;
                        }

                        if (ca[i] == '9')
                        {
                            lf++;
                        }
                    }

                    if (ca.Length == lf)
                    {
                        xh = 0;
                        xh = Convert.ToInt32(a);
                    }

                    else
                    {
                        MessageBox.Show("Not valid number. Please enter a number there from 1 to 65535");
                        textBox1.Text = memx.ToString();
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string a = textBox2.Text;

            char[] ca = a.ToCharArray();

            if (ca.Length > 0)
            {
                if (ca.Length > 5)
                {
                    MessageBox.Show("Not valid number. Please enter a number there from 1 to 65535");
                    textBox2.Text = memy.ToString();
                }

                else
                {
                    int lf = 0;
                    for (int i = 0; i < ca.Length; i++)
                    {
                        if (ca[i] == '0')
                        {
                            lf++;
                        }

                        if (ca[i] == '1')
                        {
                            lf++;
                        }

                        if (ca[i] == '2')
                        {
                            lf++;
                        }

                        if (ca[i] == '3')
                        {
                            lf++;
                        }

                        if (ca[i] == '4')
                        {
                            lf++;
                        }

                        if (ca[i] == '5')
                        {
                            lf++;
                        }

                        if (ca[i] == '6')
                        {
                            lf++;
                        }

                        if (ca[i] == '7')
                        {
                            lf++;
                        }

                        if (ca[i] == '8')
                        {
                            lf++;
                        }

                        if (ca[i] == '9')
                        {
                            lf++;
                        }
                    }

                    if (ca.Length == lf)
                    {
                        yh = 0;
                        yh = Convert.ToInt32(a);
                    }

                    else
                    {
                        MessageBox.Show("Not valid number. Please enter a number there from 1 to 65535");
                        textBox2.Text = memy.ToString();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a2 = textBox1.Text;

            char[] c2 = a2.ToCharArray();

            if (c2.Length == 0)
            {
                MessageBox.Show("Not valid number. Please enter a number there from 1 to 65535");
                textBox1.Text = memx.ToString();
            }

            else
            {
                if (xh > 0 && xh < 65536)
                {
                    x = xh;
                    mag = 0;
                    picture = new Bitmap(x, y);
                    pictureBox1.Size = new Size(x, y);
                    memx = a2;

                    for (x2 = 0; x2 < x; x2++)
                    {
                        for (y2 = 0; y2 < y; y2++)
                        {
                            picture.SetPixel(x2, y2, Color.Black);
                        }
                    }

                    pictureBox1.Image = picture;
                }

                else
                {
                    MessageBox.Show("Not valid number. Please enter a number there from 1 to 65535");
                    textBox1.Text = memx.ToString();
                }
            }

            string a = textBox2.Text;

            char[] ca = a.ToCharArray();

            if (ca.Length == 0)
            {
                MessageBox.Show("Not valid number. Please enter a number there from 1 to 65535");
                textBox2.Text = memy.ToString();
            }

            else
            {
                if (yh > 0 && yh < 65536)
                {
                    y = yh;
                    mag = 0;
                    picture = new Bitmap(x, y);
                    pictureBox1.Size = new Size(x, y);
                    memy = a;

                    for (x2 = 0; x2 < x; x2++)
                    {
                        for (y2 = 0; y2 < y; y2++)
                        {
                            picture.SetPixel(x2, y2, Color.Black);
                        }
                    }

                    pictureBox1.Image = picture;
                }

                else
                {
                    MessageBox.Show("Not valid number. Please enter a number there from 1 to 65535");
                    textBox2.Text = memy.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        bool done2 = false;

        private void Black_CheckedChanged(object sender, EventArgs e)
        {
            if (Black.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Black;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Black)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Black.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void White_CheckedChanged(object sender, EventArgs e)
        {
            if (White.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.White;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.White)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    White.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Gray_CheckedChanged(object sender, EventArgs e)
        {
            if (Gray.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Gray;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Gray)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Gray.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Red_CheckedChanged(object sender, EventArgs e)
        {
            if (Red.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Red;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Red)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done = true;
                    Red.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Orange_CheckedChanged(object sender, EventArgs e)
        {
            if (Orange.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Orange;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Orange)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Orange.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Yellow_CheckedChanged(object sender, EventArgs e)
        {
            if (Yellow.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Yellow;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Yellow)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Yellow.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Green_CheckedChanged(object sender, EventArgs e)
        {
            if (Green.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Green;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Green)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Green.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Blue_CheckedChanged(object sender, EventArgs e)
        {
            if (Blue.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Blue;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Blue)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Blue.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Purple_CheckedChanged(object sender, EventArgs e)
        {
            if (Purple.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Purple;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Purple)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Purple.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Pink_CheckedChanged(object sender, EventArgs e)
        {
            if (Pink.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Pink;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Pink)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Pink.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Brown_CheckedChanged(object sender, EventArgs e)
        {
            if (Brown.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Brown;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Brown)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Brown.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Tomato_CheckedChanged(object sender, EventArgs e)
        {
            if (Tomato.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Tomato;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Tomato)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Tomato.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Wheat_CheckedChanged(object sender, EventArgs e)
        {
            if (Wheat.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Wheat;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Wheat)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Wheat.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void LemonChiffon_CheckedChanged(object sender, EventArgs e)
        {
            if (LemonChiffon.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.LemonChiffon;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.LemonChiffon)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    LemonChiffon.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Gold_CheckedChanged(object sender, EventArgs e)
        {
            if (Gold.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Gold;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Gold)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Gold.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void ForestGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (ForestGreen.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.ForestGreen;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.ForestGreen)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    ForestGreen.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void LawnGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (LawnGreen.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.LawnGreen;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.LawnGreen)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    LawnGreen.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Turquoise_CheckedChanged(object sender, EventArgs e)
        {
            if (Turquoise.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Turquoise;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Turquoise)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Turquoise.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Aqua_CheckedChanged(object sender, EventArgs e)
        {
            if (Aqua.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Aqua;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Aqua)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Aqua.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Navy_CheckedChanged(object sender, EventArgs e)
        {
            if (Navy.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Navy;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Navy)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Navy.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Magenta_CheckedChanged(object sender, EventArgs e)
        {
            if (Magenta.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Magenta;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Magenta)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Magenta.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void DarkViolet_CheckedChanged(object sender, EventArgs e)
        {
            if (DarkViolet.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.DarkViolet;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.DarkViolet)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    DarkViolet.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void LightCoral_CheckedChanged(object sender, EventArgs e)
        {
            if (LightCoral.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.LightCoral;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.LightCoral)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    LightCoral.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void DeepPink_CheckedChanged(object sender, EventArgs e)
        {
            if (DeepPink.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.DeepPink;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.DeepPink)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    DeepPink.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void RoyalBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (RoyalBlue.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.RoyalBlue;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.RoyalBlue)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    RoyalBlue.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Aquamarine_CheckedChanged(object sender, EventArgs e)
        {
            if (Aquamarine.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Aquamarine;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Aquamarine)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Aquamarine.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void PowderBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (PowderBlue.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.PowderBlue;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && Khaki.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.PowderBlue)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    PowderBlue.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        private void Khaki_CheckedChanged(object sender, EventArgs e)
        {
            if (Khaki.Checked == true)
            {
                if (done2 == false)
                {
                    c[color] = Color.Khaki;
                    color++;
                }

                else
                {
                    done2 = false;
                }
            }

            else
            {
                if ((Black.Checked == false && White.Checked == false && Gray.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && VarientColor1.Checked == false && VarientColor2.Checked == false) == false)
                {
                    int kj = 0;

                    Color[] color2 = new Color[c.Length - 1];

                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] != Color.Khaki)
                        {
                            color2[kj] = c[i];
                            kj++;
                        }
                    }

                    c = color2;
                    Array.Resize(ref c, c.Length + (30 - c.Length));
                    color--;
                }

                else
                {
                    done2 = true;
                    Khaki.Checked = true;
                    button5.Visible = true;
                    label4.Text = "Not valid number of colors. Please select at least 1 color.";
                }
            }
        }

        bool stop2 = false;
        bool stopasync2 = false;

        int mag = 0;

        private async void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                stop2 = false;
                trackBar1.Enabled = false;

                if (trackBar1.Value == 1)
                {
                    stop2 = true;
                    mag = 0;

                    pictureBox1.Image = picture;
                }

                if (stop2 == false)
                {
                    if (trackBar1.Value == 2)
                    {
                        stop2 = true;
                        mag = 1;

                        stopasync2 = true;
                        await Task.Run(() => GetMag());

                        if (stopasync2 == false)
                        {
                            pictureBox1.Image = pic1;
                        }
                    }
                }

                trackBar1.Enabled = true;
            }

            else
            {
                MessageBox.Show("Type in this textbox a number from 1 to 100");
                textBox3.Text = (magsize - 1).ToString();
            }
        }

        Bitmap pic1 = new Bitmap(1, 1);
        Bitmap pic1h = new Bitmap(1, 1);

        int x3 = 0;
        int y3 = 0;

        bool done = false;

        int magsize = 11;

        private async Task GetMag()
        {
            x3 = 0;
            y3 = 0;

            if (mag == 1)
            {
                if (done == false)
                {
                    pic1 = new Bitmap(x * magsize, y * magsize);

                    for (int i = 0; i < x * magsize; i++)
                    {
                        for (int j = 0; j < y * magsize; j++)
                        {
                            pic1.SetPixel(i, j, Color.Black);
                        }
                    }

                    for (int k = 0; k < x; k++)
                    {
                        y3 = 0;

                        for (int k2 = 0; k2 < y; k2++)
                        {
                            Color c2 = picture.GetPixel(k, k2);

                            pic1.SetPixel(x3, y3, c2);

                            for (int i = 0; i < magsize; i++)
                            {
                                for (int j = 0; j < magsize; j++)
                                {
                                    pic1.SetPixel(x3 + i, y3 + j, c2);
                                }
                            }

                            y3 = y3 + magsize - 1;
                        }

                        x3 = x3 + magsize - 1;
                    }

                    Color regfuk = new Color();

                    pic1h = new Bitmap(x * magsize - x, y * magsize - y);

                    for (int i = 0; i < x * magsize - x; i++)
                    {
                        for (int j = 0; j < y * magsize - y; j++)
                        {
                            regfuk = pic1.GetPixel(i, j);
                            pic1h.SetPixel(i, j, regfuk);
                        }
                    }

                    pic1 = pic1h;

                    done = true;
                }
            }

            stopasync2 = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            button5.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            char[] c = textBox3.Text.ToCharArray();

            if (c.Length != 0)
            {
                if (c.Length > 4)
                {
                    MessageBox.Show("Type in this textbox a number from 1 to 100");
                    textBox3.Text = (magsize - 1).ToString();
                }

                else
                {
                    int k = 0;

                    if (c[0] == '+' | false | (c[0] == '0' | false | (c[0] == '1' | false | (c[0] == '2' | false | (c[0] == '3' | false | (c[0] == '4' | false | (c[0] == '5' | false | (c[0] == '6' | false | (c[0] == '7' | false | (c[0] == '8' | false | c[0] == '9'))))))))))
                    {
                        k++;
                    }

                    for (int i = 1; i < c.Length; i++)
                    {
                        if (c[i] == '0')
                        {
                            k++;
                        }

                        if (c[i] == '1')
                        {
                            k++;
                        }

                        if (c[i] == '2')
                        {
                            k++;
                        }

                        if (c[i] == '3')
                        {
                            k++;
                        }

                        if (c[i] == '4')
                        {
                            k++;
                        }

                        if (c[i] == '5')
                        {
                            k++;
                        }

                        if (c[i] == '6')
                        {
                            k++;
                        }

                        if (c[i] == '7')
                        {
                            k++;
                        }

                        if (c[i] == '8')
                        {
                            k++;
                        }

                        if (c[i] == '9')
                        {
                            k++;
                        }
                    }

                    if (k == c.Length)
                    {
                        int h = Convert.ToInt32(textBox3.Text);

                        if (h == 0 | false | h > 100)
                        {
                            MessageBox.Show("Type in this textbox a number from 1 to 100");
                            textBox3.Text = (magsize - 1).ToString();
                        }

                        else
                        {
                            magsize = h + 1;
                            done = false;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Type in this textbox a number from 1 to 100");
                        textBox3.Text = (magsize - 1).ToString();
                    }
                }
            }
        }

        string[] perc = new string[0];
        int[] r = new int[0];

        public int l;

        int num = 0;

        bool stopasync3 = false;

        private async void button6_Click(object sender, EventArgs e)
        {
            Animation_Game_Test_3 c = new Animation_Game_Test_3();

            if (stopasync3 == false)
            {
                for (int x2 = 0; x2 < x; x2++)
                {
                    if (stopasync3 == false)
                    {
                        for (int y2 = 0; y2 < y; y2++)
                        {
                            if (stopasync3 == false)
                            {
                                string[] ht = textBox4.Text.Split('*');

                                string[] spl = ht[0].Split('|');

                                string[] colors = spl[0].Split('/');
                                perc = spl[1].Split();

                                r = new int[100];

                                int hr = 0;
                                int fhr = 0;

                                for (int i = 0; i < perc.Length; i++)
                                {
                                    hr = fhr;
                                    for (int j = hr; j < Convert.ToInt32(perc[i]) + hr; j++)
                                    {
                                        r[j] = i;
                                        fhr = j;
                                    }
                                }

                                stopasync3 = true;
                                c.NewGenPic(picture, normal, x2, y2, colors, ht, perc, r);
                                
                                if (c.asyncstop == false)
                                {
                                    stopasync3 = false;
                                    pictureBox1.Image = c.game2;
                                    picture = c.game2;
                                    done = false;
                                }
                            }
                        }
                    }
                }
            }

            if (stopasync3 == false)
            {
                textBox5.Text = textBox5.Text + " " + c.l.ToString();
            }
        }

        bool stopsico = false;

        private void Normal_CheckedChanged(object sender, EventArgs e)
        {
            if (stopsico == false)
            {
                if (Normal.Checked == true)
                {
                    normal = true;
                    stopsico = true;
                    Horizontal.Checked = false;
                    stopsico = false;
                }

                else
                {
                    normal = false;
                    stopsico = true;
                    Horizontal.Checked = true;
                    stopsico = false;
                }
            }
        }

        private void Horizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (stopsico == false)
            {
                if (Horizontal.Checked == true)
                {
                    normal = false;
                    stopsico = true;
                    Normal.Checked = false;
                    stopsico = false;
                }

                else
                {
                    normal = true;
                    stopsico = true;
                    Normal.Checked = true;
                    stopsico = false;
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (VarientColor1.Checked == false)
            {
                char[] h = textBox6.Text.ToCharArray();

                for (int i = 0; i < h.Length; i++)
                {
                    if (h[i] != '0' && h[i] != '1' && h[i] != '2' && h[i] != '3' && h[i] != '4' && h[i] != '5' && h[i] != '6' && h[i] != '7' && h[i] != '8' && h[i] != '9' && h[i] != ' ')
                    {
                        MessageBox.Show("Put the RGB of a color in this textbox");

                        textBox6.Text = mem6;
                    }

                    else
                    {
                        mem6 = textBox6.Text;
                    }
                }
            }

            else
            {
                textBox6.Text = mem6;
            }
        }

        string mem6 = "";
        string mem7 = "";

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (VarientColor1.Checked == false)
            {
                char[] h = textBox7.Text.ToCharArray();

                for (int i = 0; i < h.Length; i++)
                {
                    if (h[i] != '0' && h[i] != '1' && h[i] != '2' && h[i] != '3' && h[i] != '4' && h[i] != '5' && h[i] != '6' && h[i] != '7' && h[i] != '8' && h[i] != '9' && h[i] != ' ')
                    {
                        MessageBox.Show("Put the RGB of a color in this textbox");

                        textBox7.Text = mem7;
                    }

                    else
                    {
                        mem7 = textBox7.Text;
                    }
                }
            }

            else
            {
                textBox7.Text = mem7;
            }
        }

        bool trueckeck1 = true;
        bool stopid = false;

        private void VarientColor1_CheckedChanged(object sender, EventArgs e)
        {
            if (stopid == false)
            {
                string[] test = textBox6.Text.Split();

                if (test.Length != 3)
                {
                    MessageBox.Show("Put the RGB of a color in this textbox");
                    trueckeck1 = false;
                    stopid = true;
                    VarientColor1.Checked = false;
                    stopid = false;
                }

                else
                {
                    if (test[0] == " " && test[1] == " " && test[2] == " ")
                    {
                        MessageBox.Show("Put the RGB of a color in this textbox");
                        trueckeck1 = false;
                        stopid = true;
                        VarientColor1.Checked = false;
                        stopid = false;
                    }

                    else
                    {
                        int h = 0;

                        for (int i = 0; i < test.Length; i++)
                        {
                            h = Convert.ToInt32(test[i]);

                            if (h > 255)
                            {
                                MessageBox.Show("Put the RGB of a color in this textbox");
                                trueckeck1 = false;
                                stopid = true;
                                VarientColor1.Checked = false;
                                stopid = false;
                            }
                        }
                    }
                }

                if (trueckeck1 == true)
                {
                    if (VarientColor1.Checked == true)
                    {
                        if (done2 == false)
                        {
                            c[color] = Color.FromArgb(Convert.ToInt32(test[0]), Convert.ToInt32(test[1]), Convert.ToInt32(test[2]));
                            color++;
                        }

                        else
                        {
                            done2 = false;
                        }
                    }

                    else
                    {
                        if ((Black.Checked == false && White.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor2.Checked == false) == false)
                        {
                            int kj = 0;

                            Color[] color2 = new Color[c.Length - 1];

                            for (int i = 0; i < c.Length; i++)
                            {
                                if (c[i] != Color.FromArgb(Convert.ToInt32(test[0]), Convert.ToInt32(test[1]), Convert.ToInt32(test[2])))
                                {
                                    color2[kj] = c[i];
                                    kj++;
                                }
                            }

                            c = color2;
                            Array.Resize(ref c, c.Length + (30 - c.Length));
                            color--;
                        }

                        else
                        {
                            done2 = true;
                            VarientColor1.Checked = true;
                            button5.Visible = true;
                            label4.Text = "Not valid number of colors. Please select at least 1 color.";
                        }
                    }
                }
            }
        }

        private void VarientColor2_CheckedChanged(object sender, EventArgs e)
        {
            if (stopid == false)
            {
                string[] test = textBox7.Text.Split();

                if (test.Length != 3)
                {
                    MessageBox.Show("Put the RGB of a color in this textbox");
                    trueckeck1 = false;
                    stopid = true;
                    VarientColor2.Checked = false;
                    stopid = false;
                }

                else
                {
                    if (test[0] == " " && test[1] == " " && test[2] == " ")
                    {
                        MessageBox.Show("Put the RGB of a color in this textbox");
                        trueckeck1 = false;
                        stopid = true;
                        VarientColor2.Checked = false;
                        stopid = false;
                    }

                    else
                    {
                        int h = 0;

                        for (int i = 0; i < test.Length; i++)
                        {
                            h = Convert.ToInt32(test[i]);

                            if (h > 255)
                            {
                                MessageBox.Show("Put the RGB of a color in this textbox");
                                trueckeck1 = false;
                                stopid = true;
                                VarientColor2.Checked = false;
                                stopid = false;
                            }
                        }
                    }
                }

                if (trueckeck1 == true)
                {
                    if (VarientColor2.Checked == true)
                    {
                        if (done2 == false)
                        {
                            c[color] = Color.FromArgb(Convert.ToInt32(test[0]), Convert.ToInt32(test[1]), Convert.ToInt32(test[2]));
                            color++;
                        }

                        else
                        {
                            done2 = false;
                        }
                    }

                    else
                    {
                        if ((Black.Checked == false && White.Checked == false && Red.Checked == false && Orange.Checked == false && Yellow.Checked == false && Green.Checked == false && Blue.Checked == false && Purple.Checked == false && Pink.Checked == false && Brown.Checked == false && Tomato.Checked == false && Wheat.Checked == false && LemonChiffon.Checked == false && Gold.Checked == false && ForestGreen.Checked == false && LawnGreen.Checked == false && Turquoise.Checked == false && Aqua.Checked == false && Navy.Checked == false && Magenta.Checked == false && DarkViolet.Checked == false && LightCoral.Checked == false && DeepPink.Checked == false && RoyalBlue.Checked == false && Aquamarine.Checked == false && PowderBlue.Checked == false && Khaki.Checked == false && VarientColor2.Checked == false) == false)
                        {
                            int kj = 0;

                            Color[] color2 = new Color[c.Length - 1];

                            for (int i = 0; i < c.Length; i++)
                            {
                                if (c[i] != Color.FromArgb(Convert.ToInt32(test[0]), Convert.ToInt32(test[1]), Convert.ToInt32(test[2])))
                                {
                                    color2[kj] = c[i];
                                    kj++;
                                }
                            }

                            c = color2;
                            Array.Resize(ref c, c.Length + (30 - c.Length));
                            color--;
                        }

                        else
                        {
                            done2 = true;
                            VarientColor2.Checked = true;
                            button5.Visible = true;
                            label4.Text = "Not valid number of colors. Please select at least 1 color.";
                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap pix16 = new Bitmap(4080, 4080);

            int B = 0;
            int G = 0;
            int R = 0;

            //for (int b1_16 = 0; b1_16 < 16; b1_16++) // 1
            //{
            //    for (int b2_16 = 0; b2_16 < 16; b2_16++)
            //    {
            //        for (int g256 = 0; g256 < 256; g256++)
            //        {
            //            for (int r256 = 0; r256 < 256; r256++)
            //            {
            //                pix16.SetPixel(b2_16 * 256 + g256, b1_16 * 256 + r256, Color.FromArgb(R, G, B));

            //                R++;
            //            }

            //            R = 0;
            //            G++;
            //        }

            //        G = 0;
            //        B++;
            //    }
            //}

            //for (int b1 = 0; b1 < 16; b1++)  // 2
            //{
            //    for (int b2 = 0; b2 < 256; b2++)
            //    {
            //        for (int g = 0; g < 16; g++)
            //        {
            //            for (int r = 0; r < 256; r++)
            //            {
            //                pix16.SetPixel(b2 * 16 + g, b1 * 256 + r, Color.FromArgb(r, g * 16, b2));
            //            }
            //        }
            //    }
            //}

            for (int b1 = 0; b1 < 16; b1++)  // 3
            {
                for (int b2 = 0; b2 < 255; b2++)
                {
                    int fdfdh = 0;
                    if (b2 == 16)
                    {
                        int ew = 0;
                    }

                    for (int r = 0; r < 16; r++)
                    {
                        if (r == 15)
                        {
                            int ew = 0;
                        }

                        for (int g = 0; g < 256; g++)
                        {
                            if (g == 255)
                            {
                                int ewrrt = 0;
                                break;
                            }

                            if (b1 * 255 + b2 * 16 + g + r > 4079)
                            {
                                pix16.SetPixel(b2 * 16 + r, Math.Abs((b1 * 255 + b2 * 16 + g + r) - 4080 * ((b1 * 255 + b2 * 16 + g + r) / 4080)), Color.FromArgb(r * 16, g, b2));
                            }

                            else
                            {
                                pix16.SetPixel(b2 * 16 + r, (b1 * 255 + b2 * 16 + g + r), Color.FromArgb(r * 16, g, b2));
                            }
                        }
                    }
                }
            }

            picture = null;
            picture = pix16;
            pictureBox1.Image = pix16;
        }
    }
}
