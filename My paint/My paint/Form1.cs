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
using System.IO;

namespace My_paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Color c = Color.Red;
        Color c2 = Color.Black;

        DL asd = new DL();

        Bitmap bmp = new Bitmap(1000, 1000);

        bool move = false;
        bool stopasync = false;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            //await Task.Run(() => Draw(e));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }

            pictureBox1.Image = bmp;

            int rR = 0;
            int rG = 0;
            int rB = 0;

            for (int j = 0; j < 3; j++)
            {
                int r = 0;
                Stopwatch t = new Stopwatch();

                t.Start();
                for (int i = 1; t.ElapsedMilliseconds <= 1; i++)
                {
                    if (i < 256)
                    {
                        r = i;
                    }

                    else
                    {
                        r = i - i / 256 * 256;
                    }
                }
                t.Stop();
                t.Reset();

                if (j == 0)
                {
                    rR = r;
                }

                if (j == 1)
                {
                    rG = r;
                }

                if (j == 2)
                {
                    rB = r;
                }
            }

            c2 = Color.FromArgb(rR, rG, rB);
        }

        private void Form1_Load2(object sender, EventArgs e)
        {
            int rR = 0;
            int rG = 0;
            int rB = 0;

            for (int j = 0; j < 3; j++)
            {
                int r = 0;
                Stopwatch t = new Stopwatch();

                t.Start();
                for (int i = 1; t.ElapsedMilliseconds <= 1; i++)
                {
                    if (i < 256)
                    {
                        r = i;
                    }

                    else
                    {
                        r = i - i / 256 * 256;
                    }
                }
                t.Stop();
                t.Reset();

                if (j == 0)
                {
                    rR = r;
                }

                if (j == 1)
                {
                    rG = r;
                }

                if (j == 2)
                {
                    rB = r;
                }
            }

            c2 = Color.FromArgb(rR, rG, rB);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true && e.X > -1 && e.Y > -1 && e.X < 1001 && e.Y < 1001)
            {
                bmp.SetPixel(e.X, e.Y, c2);

                pictureBox1.Image = bmp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            c2 = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal[] p1 = new decimal[2];
            string[] te = textBox1.Text.Split();

            decimal[] p2 = new decimal[2];
            string[] te2 = textBox2.Text.Split();

            for (int i = 0; i < 2; i++)
            {
                p1[i] = Convert.ToDecimal(te[i]);
                p2[i] = Convert.ToDecimal(te2[i]);
            }

            bmp = DL.DrawLine(bmp, p1, p2, c2);

            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "BMP(*.BMP)|*.bmp";

            if (save.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] txt = textBox3.Text.Split();

            bmp = new Bitmap(Convert.ToInt32(txt[0]), Convert.ToInt32(txt[1]));

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    bmp.SetPixel(x, y, Color.Black);
                }
            }

            pictureBox1.Image = bmp;
        }

        bool stopasync2 = false;

        int min = 0;
        int max = 500;
        int r = 0;

        private async void button5_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < 100; k++)
            {
                Form1_Load2(sender, e);

                Random r = new System.Random();

                int l3 = r.Next(1, 10);

                for (int i = 0; i < Convert.ToInt32(l3 * 100000); i++)
                {
                    int l1 = r.Next(0, 1001);
                    int l2 = r.Next(0, 1001);

                    bmp.SetPixel(l1, l2, c2);

                    pictureBox1.Image = bmp;
                }
            }
        }

        public async Task Random()
        {
            r = 0;

            int[] numodec = new int[0];

            string min2t = min.ToString();
            string max2t = max.ToString();
            char[] mint = min2t.ToCharArray();
            char[] maxt = max2t.ToCharArray();

            numodec = new int[maxt.Length - mint.Length + 1];

            for (int i = 0; i < numodec.Length; i++)
            {
                if (i == 0)
                {
                    numodec[i] = mint.Length;
                }

                else
                {
                    numodec[i] = mint.Length + i;
                }
            }

            int l = 1;

            Stopwatch ne = new Stopwatch();
            int lk;
            ne.Start();
            for (lk = 1; ne.ElapsedTicks <= 500; lk++)
            {
                if (lk < numodec.Length)
                {
                    l = lk;
                }

                else
                {
                    l = lk - lk / numodec.Length * numodec.Length;
                }
            }
            ne.Stop();
            ne.Reset();

            string[] nums = new string[l];

            string numaxt = max.ToString();
            string numint = min.ToString();

            char[] numax = numaxt.ToCharArray();
            char[] numin = numint.ToCharArray();//num min

            if (l != numin.Length)
            {

            }

            else
            {

            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (numin.Length - i > 0)
                    {
                        if (j >= numin[numin.Length - i] && j <= numax[numax.Length - i])
                        {
                            if (nums[nums.Length - i] != null)
                            {
                                if (i != nums.Length)
                                {
                                    nums[nums.Length - i] = nums[nums.Length - i] + " " + j.ToString() + " ";

                                }

                                else
                                {
                                    nums[nums.Length - i] = nums[nums.Length - i] + " " + j.ToString();
                                }
                            }

                            else
                            {
                                if (i != nums.Length)
                                {
                                    nums[nums.Length - i] = j.ToString() + " ";
                                }

                                else
                                {
                                    nums[nums.Length - i] = j.ToString();
                                }
                            }
                        }
                    }

                    if (numin.Length - i == 0)
                    {
                        if (j <= numax[numax.Length - i])
                        {
                            if (nums[nums.Length - i] != null)
                            {
                                if (i != nums.Length)
                                {
                                    nums[nums.Length - i] = nums[nums.Length - i] + " " + j.ToString() + " ";

                                }

                                else
                                {
                                    nums[nums.Length - i] = nums[nums.Length - i] + " " + j.ToString();
                                }
                            }

                            else
                            {
                                if (i != nums.Length)
                                {
                                    nums[nums.Length - i] = j.ToString() + " ";
                                }

                                else
                                {
                                    nums[nums.Length - i] = j.ToString();
                                }
                            }
                        }
                    }
                }
            } // the variable numbers for each number

            int rt = -0;
            stopasync2 = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //decimal rad = Convert.ToDecimal(Convert.ToInt32(textBox5.Text));

            //string[] a = textBox4.Text.Split();

            //decimal[] center = new decimal[2] { Convert.ToDecimal(Convert.ToInt32(a[0])), Convert.ToDecimal(Convert.ToInt32(a[1])) };

            //for (decimal x = center[0] - rad + 1; x < center[0] + rad + 1; x = x + Convert.ToDecimal(1))
            //{
            //    decimal[] p1 = new decimal[2];
            //    string[] te = textBox1.Text.Split();

            //    decimal[] p2 = new decimal[2];
            //    string[] te2 = textBox2.Text.Split();

            //    decimal[] p3 = new decimal[2];
            //    decimal[] p4 = new decimal[2];

            //    p1[0] = x - 1;
            //    p2[0] = x;

            //    string b = Math.Sqrt(Convert.ToDouble(InfiNum.Abs((Math.Floor(((x - 1 - center[0]) * (x - 1 - center[0]) - rad * rad))).ToString()))).ToString();
            //    string c = Math.Sqrt(Convert.ToDouble(InfiNum.Abs((Math.Floor(((x - center[0]) * (x - center[0]) - rad * rad))).ToString()))).ToString();

            //    p1[1] = Convert.ToDecimal(b) + center[1];
            //    p2[1] = Convert.ToDecimal(c) + center[1];

            //    p3[0] = p1[0];
            //    p4[0] = p2[0];

            //    p3[1] = center[1] - (p1[1] - center[1]);
            //    p4[1] = center[1] - (p2[1] - center[1]);

            //    bmp = asd.DrawLine(bmp, p1, p2, c2, Convert.ToInt32(x));
            //    bmp = asd.DrawLine(bmp, p3, p4, c2, Convert.ToInt32(x));

            //    if (x == center[0] + rad)
            //    {
            //        bmp = asd.DrawLine(bmp, p2, p4, c2, Convert.ToInt32(x));
            //    }

            //    if (x == center[0] - rad + 1)
            //    {
            //        bmp = asd.DrawLine(bmp, p1, p3, c2, Convert.ToInt32(x));
            //    }
            //}

            //pictureBox1.Image = bmp;

            decimal rad = Convert.ToDecimal(Convert.ToInt32(textBox5.Text));

            string[] a = textBox4.Text.Split();

            decimal[] center = new decimal[2] { Convert.ToDecimal(Convert.ToInt32(a[0])), Convert.ToDecimal(Convert.ToInt32(a[1])) };

            for (decimal x = center[0] - rad + Convert.ToInt32(1); x < center[0] + rad + Convert.ToInt32(1); x = x + Convert.ToDecimal(1))
            {
                decimal[] p1 = new decimal[2];
                string[] te = textBox1.Text.Split();

                decimal[] p2 = new decimal[2];
                string[] te2 = textBox2.Text.Split();

                decimal[] p3 = new decimal[2];
                decimal[] p4 = new decimal[2];

                p1[0] = x - 1;
                p2[0] = x;

                string b = InfiNum.Root(InfiNum.Abs(/*InfiNum.Floor*/(((x - Convert.ToDecimal(1) - center[0]) * (x - Convert.ToDecimal(1) - center[0]) - rad * rad).ToString())), "2");
                string c = InfiNum.Root(InfiNum.Abs(/*InfiNum.Floor*/(((x - center[0]) * (x - center[0]) - rad * rad).ToString())), "2");

                p1[1] = Convert.ToDecimal(b) + center[1];
                p2[1] = Convert.ToDecimal(c) + center[1];

                p3[0] = p1[0];
                p4[0] = p2[0];

                p3[1] = center[1] - (p1[1] - center[1]);
                p4[1] = center[1] - (p2[1] - center[1]);

                bmp = asd.DrawCircleLine(bmp, p1, p2, c2, center, rad);

                if (x == 503)
                {
                    int jfgsf = 0;
                }

                bmp = asd.DrawCircleLine(bmp, p3, p4, c2, center, rad);

                if (x == center[0] + rad)
                {
                    bmp = asd.DrawCircleLine(bmp, p2, p4, c2, center, rad);
                }

                if (x == center[0] - rad + Convert.ToDecimal(1))
                {
                    bmp = asd.DrawCircleLine(bmp, p1, p3, c2, center, rad);
                }

                //bmp.SetPixel(Convert.ToInt32(p1[0]), Convert.ToInt32(p1[1]), c2);
                //bmp.SetPixel(Convert.ToInt32(p2[0]), Convert.ToInt32(p2[1]), c2);
                //bmp.SetPixel(Convert.ToInt32(p3[0]), Convert.ToInt32(p3[1]), c2);
                //bmp.SetPixel(Convert.ToInt32(p4[0]), Convert.ToInt32(p4[1]), c2);
            }

            pictureBox1.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DL dl = new DL();

            InfiNum x1 = new InfiNum("999");
            InfiNum y1 = new InfiNum("0");

            InfiNum x2 = new InfiNum("0");
            InfiNum y2 = new InfiNum("999");

            decimal r = 255;
            decimal g = 255;
            decimal b = 255;

            for (int i = 0; i < 50000; i++)
            {
                //dl.DrawLine(bmp, new decimal[] { (1000 + (Convert.ToInt32(x1) - (Convert.ToInt32(x1) / 1000 * 1000))) - (1000 + (Convert.ToInt32(x1) - (Convert.ToInt32(x1) / 1000 * 1000))) / 1000 * 1000, (1000 + (Convert.ToInt32(y1) - (Convert.ToInt32(y1) / 1000 * 1000))) - (1000 + (Convert.ToInt32(y1) - (Convert.ToInt32(y1) / 1000 * 1000))) / 1000 * 1000 }, new decimal[] { (1000 + (Convert.ToInt32(x2) - (Convert.ToInt32(x2) / 1000 * 1000))) - (1000 + (Convert.ToInt32(x2) - (Convert.ToInt32(x2) / 1000 * 1000))) / 1000 * 1000, (1000 + (Convert.ToInt32(y2) - (Convert.ToInt32(y2) / 1000 * 1000))) - (1000 + (Convert.ToInt32(y2) - (Convert.ToInt32(y2) / 1000 * 1000))) / 1000 * 1000 }, Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b)));

                InfiNum k = new InfiNum("1000");

                InfiNum a = (new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor(((x1 / new InfiNum("1000"))).Value)) * new InfiNum("1000"))));
                InfiNum b2 = new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000");

                decimal[] d1 = new decimal[2] { Convert.ToDecimal((((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum((new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")) )) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value))).Value),

                    Convert.ToDecimal(((new InfiNum("1000") + (y1 - (new InfiNum(InfiNum.Floor((y1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - (new InfiNum("1000") + (y1 - (new InfiNum(InfiNum.Floor((y1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000") * new InfiNum("1000")).Value) };

                //r = r + (decimal)0.01;
                //g = g + (decimal)0.01;
                //b = b + (decimal)0.01;

                x1.Value = x1.Add("1");
                y1.Value = x1.Subtract(x1.Pow("2"));

                x2.Value = x2.Add("1");
                y2.Value = x2.Subtract(x2.Root("2"));

                if (b > 5)
                {
                    b = b - 5;
                }

                else
                {
                    if (g > 5)
                    {
                        g = g - 5;
                        b = 255;
                    }

                    else
                    {
                        r = r - 5;
                        g = 255;
                        b = 255;
                    }
                }

                d1 = new decimal[2] { Convert.ToDecimal(((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value), Convert.ToDecimal(((new InfiNum("1000") + (y1 - (new InfiNum(InfiNum.Floor((y1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (y1 - (new InfiNum(InfiNum.Floor((y1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value) };// (1000 + (x1 - (floor(x1 / 1000) * 1000))) |||||||||-||||||||||| floor((1000 + (x1 - (floor(x1 / 1000) * 1000))) / 1000) * 1000

                decimal[] d2 = new decimal[2] { Convert.ToDecimal(((new InfiNum("1000") + (x2 - (new InfiNum(InfiNum.Floor((x2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (x2 - (new InfiNum(InfiNum.Floor((x2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value), Convert.ToDecimal(((new InfiNum("1000") + (y2 - (new InfiNum(InfiNum.Floor((y2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (y2 - (new InfiNum(InfiNum.Floor((y2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value) };

                if (d2[1] >= 1000 || d2[1] < 0)
                {
                    int teg = 0;
                }

                DL.DrawLine(bmp, new decimal[] { Convert.ToDecimal(InfiNum.Floor(((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum((((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value)), Convert.ToDecimal(InfiNum.Floor(((new InfiNum("1000") + (y1 - (new InfiNum(InfiNum.Floor((y1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (y1 - (new InfiNum(InfiNum.Floor((y1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value)) }, new decimal[] { Convert.ToDecimal(InfiNum.Floor(((new InfiNum("1000") + (x2 - (new InfiNum(InfiNum.Floor((x2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (x2 - (new InfiNum(InfiNum.Floor((x2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value)), Convert.ToDecimal(InfiNum.Floor(((new InfiNum("1000") + (y2 - (new InfiNum(InfiNum.Floor((y2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (y2 - (new InfiNum(InfiNum.Floor((y2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value)) }, Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b)));
            }

            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    for (int k = 0; k < 255; k++)
                    {

                    }
                }
            }

            pictureBox1.Image = bmp;
        }

        public void drawLines(InfiNum num_of_lines, InfiNum x1, InfiNum y1, InfiNum x2, InfiNum y2, InfiNum r, InfiNum g, InfiNum b, InfiNum r_change, InfiNum g_change, InfiNum b_change)
        {
            for (InfiNum i = new InfiNum("0"); i < num_of_lines; i = i + new InfiNum("1"))
            {
                decimal[] p1 = new decimal[2] { Convert.ToDecimal(((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (x1 - (new InfiNum(InfiNum.Floor((x1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value), Convert.ToDecimal(((new InfiNum("1000") + (y1 - (new InfiNum(InfiNum.Floor((y1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (y1 - (new InfiNum(InfiNum.Floor((y1 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value) };// (1000 + (x1 - (floor(x1 / 1000) * 1000))) |||||||||-||||||||||| floor((1000 + (x1 - (floor(x1 / 1000) * 1000))) / 1000) * 1000
                decimal[] p2 = new decimal[2] { Convert.ToDecimal(((new InfiNum("1000") + (x2 - (new InfiNum(InfiNum.Floor((x2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (x2 - (new InfiNum(InfiNum.Floor((x2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value), Convert.ToDecimal(((new InfiNum("1000") + (y2 - (new InfiNum(InfiNum.Floor((y2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) - new InfiNum(InfiNum.Floor(((new InfiNum("1000") + (y2 - (new InfiNum(InfiNum.Floor((y2 / new InfiNum("1000")).Value)) * new InfiNum("1000")))) / new InfiNum("1000")).Value)) * new InfiNum("1000")).Value) };

                //decimal rt = Convert.ToDecimal(((new InfiNum("255") + (r - (new InfiNum(InfiNum.Floor((r / new InfiNum("255")).Value)) * new InfiNum("255")))) - new InfiNum(InfiNum.Floor(((new InfiNum("255") + (r - (new InfiNum(InfiNum.Floor((r / new InfiNum("255")).Value)) * new InfiNum("255")))) / new InfiNum("255")).Value)) * new InfiNum("255")).Value);
                //decimal gt = Convert.ToDecimal(((new InfiNum("255") + (g - (new InfiNum(InfiNum.Floor((g / new InfiNum("255")).Value)) * new InfiNum("255")))) - new InfiNum(InfiNum.Floor(((new InfiNum("255") + (g - (new InfiNum(InfiNum.Floor((g / new InfiNum("255")).Value)) * new InfiNum("255")))) / new InfiNum("255")).Value)) * new InfiNum("255")).Value);
                //decimal bt = Convert.ToDecimal(((new InfiNum("255") + (b - (new InfiNum(InfiNum.Floor((b / new InfiNum("255")).Value)) * new InfiNum("255")))) - new InfiNum(InfiNum.Floor(((new InfiNum("255") + (b - (new InfiNum(InfiNum.Floor((b / new InfiNum("255")).Value)) * new InfiNum("255")))) / new InfiNum("255")).Value)) * new InfiNum("255")).Value);

                DL.DrawLine(bmp, new decimal[2] { Math.Floor(p1[0]), Math.Floor(p1[1])}, new decimal[2] { Math.Floor(p2[0]), Math.Floor(p2[1])}, Color.FromArgb(Convert.ToInt32(Math.Round(Convert.ToDecimal(r.Value))), Convert.ToInt32(Math.Round(Convert.ToDecimal(g.Value))), Convert.ToInt32(Math.Round(Convert.ToDecimal(b.Value)))));

                x1 = (x1 + y2) / new InfiNum("2");

                y1 = ((y1 * x2) & new InfiNum("2"));

                x2 = (new InfiNum("2") * (x2 * y1)) / (x2 + y1);

                y2 = (((y2 ^ new InfiNum("2")) + (x1 ^ new InfiNum("2")) / new InfiNum("2")) & new InfiNum("2"));

                if (r - r_change > new InfiNum("0"))
                {
                    r = r - r_change;
                }

                else
                {
                    r = new InfiNum("255") - InfiNum.Abs(r - r_change);

                    if (g - g_change > new InfiNum("0"))
                    {
                        g = g - g_change;
                    }

                    else
                    {
                        g = new InfiNum("255") - InfiNum.Abs(g - g_change);

                        if (b - b_change > new InfiNum("0"))
                        {
                            b = b - b_change;
                        }

                        else
                        {
                            b = new InfiNum("255") - InfiNum.Abs(b - b_change);
                        }
                    }
                }
            }

            pictureBox1.Image = bmp;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            InfiNum num = new InfiNum(r.Next(0, 1000).ToString());

            InfiNum x1 = new InfiNum(r.Next(0, 999).ToString());
            InfiNum x2 = new InfiNum(r.Next(0, 999).ToString());
            InfiNum y1 = new InfiNum(r.Next(0, 999).ToString());
            InfiNum y2 = new InfiNum(r.Next(0, 999).ToString());

            string[] func1 = new string[3] { r.Next(0, 5).ToString(), r.Next(1, 9).ToString(), r.Next(1, 9).ToString() };
            string[] func2 = new string[3] { r.Next(0, 5).ToString(), r.Next(1, 9).ToString(), r.Next(1, 9).ToString() };
            string[] func3 = new string[3] { r.Next(0, 5).ToString(), r.Next(1, 9).ToString(), r.Next(1, 9).ToString() };
            string[] func4 = new string[3] { r.Next(0, 5).ToString(), r.Next(1, 9).ToString(), r.Next(1, 9).ToString() };

            if (func1[1] == "6")
            {
                func1[1] = "x1";
            }

            if (func1[1] == "7")
            {
                func1[1] = "y1";
            }

            if (func1[1] == "8")
            {
                func1[1] = "x2";
            }

            if (func1[1] == "9")
            {
                func1[1] = "y2";
            }
            //
            if (func1[2] == "6")
            {
                func1[2] = "x1";
            }

            if (func1[2] == "7")
            {
                func1[2] = "y1";
            }

            if (func1[2] == "8")
            {
                func1[2] = "x2";
            }

            if (func1[2] == "9")
            {
                func1[2] = "y2";
            }
            //
            //

            if (func2[1] == "6")
            {
                func2[1] = "x1";
            }

            if (func2[1] == "7")
            {
                func2[1] = "y1";
            }

            if (func2[1] == "8")
            {
                func2[1] = "x2";
            }

            if (func2[1] == "9")
            {
                func2[1] = "y2";
            }
            //
            if (func2[2] == "6")
            {
                func2[2] = "x1";
            }

            if (func2[2] == "7")
            {
                func2[2] = "y1";
            }

            if (func2[2] == "8")
            {
                func2[2] = "x2";
            }

            if (func2[2] == "9")
            {
                func2[2] = "y2";
            }
            //
            //

            if (func3[1] == "6")
            {
                func3[1] = "x1";
            }

            if (func3[1] == "7")
            {
                func3[1] = "y1";
            }

            if (func3[1] == "8")
            {
                func3[1] = "x2";
            }

            if (func3[1] == "9")
            {
                func3[1] = "y2";
            }
            //
            if (func3[2] == "6")
            {
                func3[2] = "x1";
            }

            if (func3[2] == "7")
            {
                func3[2] = "y1";
            }

            if (func3[2] == "8")
            {
                func3[2] = "x2";
            }

            if (func3[2] == "9")
            {
                func3[2] = "y2";
            }
            //
            //

            if (func4[1] == "6")
            {
                func4[1] = "x1";
            }

            if (func4[1] == "7")
            {
                func4[1] = "y1";
            }

            if (func4[1] == "8")
            {
                func4[1] = "x2";
            }

            if (func4[1] == "9")
            {
                func4[1] = "y2";
            }
            //
            if (func4[2] == "6")
            {
                func4[2] = "x1";
            }

            if (func4[2] == "7")
            {
                func4[2] = "y1";
            }

            if (func4[2] == "8")
            {
                func4[2] = "x2";
            }

            if (func4[2] == "9")
            {
                func4[2] = "y2";
            }

            string[] func1_t = new string[3] { func1[0], func1[1], func1[2] };
            string[] func2_t = new string[3] { func2[0], func2[1], func2[2] };
            string[] func3_t = new string[3] { func3[0], func3[1], func3[2] };
            string[] func4_t = new string[3] { func4[0], func4[1], func4[2] };

            if (func1_t[0] == "0")
            {
                func1_t[0] = "add";
            }

            if (func1_t[0] == "1")
            {
                func1_t[0] = "subtract";
            }

            if (func1_t[0] == "2")
            {
                func1_t[0] = "multiply";
            }

            if (func1_t[0] == "3")
            {
                func1_t[0] = "divide";
            }

            if (func1_t[0] == "4")
            {
                func1_t[0] = "power";
            }

            if (func1_t[0] == "5")
            {
                func1_t[0] = "root";
            }
            //

            if (func2_t[0] == "0")
            {
                func2_t[0] = "add";
            }

            if (func2_t[0] == "1")
            {
                func2_t[0] = "subtract";
            }

            if (func2_t[0] == "2")
            {
                func2_t[0] = "multiply";
            }

            if (func2_t[0] == "3")
            {
                func2_t[0] = "divide";
            }

            if (func2_t[0] == "4")
            {
                func2_t[0] = "power";
            }

            if (func2_t[0] == "5")
            {
                func2_t[0] = "root";
            }
            //

            if (func3_t[0] == "0")
            {
                func3_t[0] = "add";
            }

            if (func3_t[0] == "1")
            {
                func3_t[0] = "subtract";
            }

            if (func3_t[0] == "2")
            {
                func3_t[0] = "multiply";
            }

            if (func3_t[0] == "3")
            {
                func3_t[0] = "divide";
            }

            if (func3_t[0] == "4")
            {
                func3_t[0] = "power";
            }

            if (func3_t[0] == "5")
            {
                func3_t[0] = "root";
            }
            //

            if (func4_t[0] == "0")
            {
                func4_t[0] = "add";
            }

            if (func4_t[0] == "1")
            {
                func4_t[0] = "subtract";
            }

            if (func4_t[0] == "2")
            {
                func4_t[0] = "multiply";
            }

            if (func4_t[0] == "3")
            {
                func4_t[0] = "divide";
            }

            if (func4_t[0] == "4")
            {
                func4_t[0] = "power";
            }

            if (func4_t[0] == "5")
            {
                func4_t[0] = "root";
            }

            //File.WriteAllText("C:\\Users\\james\\Documents\\remof.txt", File.ReadAllText("C:\\Users\\james\\Documents\\remof.txt") + "\r\n\r\nLines: " + num.Value + "\r\nx1: " + x1.Value + "\r\ny1: " + y1.Value + "\r\nx2: " + x2.Value + "\r\ny2: " + y2.Value + "\r\nfunc x1: " + func1_t[0] + "(" + func1_t[1] + ", " + func1_t[2] + ")\r\nfunc y1: " + func2_t[0] + "(" + func2_t[1] + ", " + func2_t[2] + ")\r\nfunc x2: " + func3_t[0] + "(" + func3_t[1] + ", " + func3_t[2] + ")\r\nfunc y2: " + func4_t[0] + "(" + func4_t[1] + ", " + func4_t[2] + ")");

            x1 = new InfiNum("2");
            y1 = new InfiNum("2");

            x2 = new InfiNum("999");
            y2 = new InfiNum("999");

            num = new InfiNum("1000");

            //draw255Lines(399, 0, 399, 399, 399, 'add(x1, 1)', 'multiply(y1, 3)', 'multiply(x2, 3)', 'subtract(y2, 1)', 100, 100, 100)

            drawLines(num, x1, y1, x2, y2, new InfiNum("255"), new InfiNum("255"), new InfiNum("255"), new InfiNum("20"), new InfiNum("20"), new InfiNum("20"));
        }

        //for (decimal y = center[1] - rad + 2; y < center[1] + rad; y = y + Convert.ToDecimal(1))
        //{
        //    decimal[] p1 = new decimal[2];
        //    string[] te = textBox1.Text.Split();

        //    decimal[] p2 = new decimal[2];
        //    string[] te2 = textBox2.Text.Split();

        //    decimal[] p3 = new decimal[2];
        //    decimal[] p4 = new decimal[2];

        //    p1[1] = y - 1;
        //    p2[1] = y;

        //    string b = InfiNum.Root(InfiNum.Abs(InfiNum.Floor(((y - 1 - center[1]) * (y - 1 - center[1]) - rad * rad).ToString())), "2");
        //    string c = InfiNum.Root(InfiNum.Abs(InfiNum.Floor(((y - center[1]) * (y - center[1]) - rad * rad).ToString())), "2");

        //    p1[0] = Convert.ToDecimal(b) + center[0];
        //    p2[0] = Convert.ToDecimal(c) + center[0];

        //    p3[1] = p1[1];
        //    p4[1] = p2[1];

        //    p3[0] = center[0] - (p1[0] - center[0]);
        //    p4[0] = center[0] - (p2[0] - center[0]);

        //    bmp = asd.DrawLine(bmp, p1, p2, c2, Convert.ToInt32(y));
        //    bmp = asd.DrawLine(bmp, p3, p4, c2, Convert.ToInt32(y));
        //}
    }
}
