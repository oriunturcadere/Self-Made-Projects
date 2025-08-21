//this is gonna be fun
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Animation_Game_Test_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;

            form2.Text = "View";
            form2.Width = 424;
            form2.Height = 464;
            form2.AutoScroll = true;

            form2.Controls.Add(pictureBox1);
            form2.Controls.Add(pictureBox2);

            form2.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            form2.Controls[0].Top = 0;
            form2.Controls[0].Left = 0;
            form2.FormClosing += Form2_FormClosing;
            form2.Icon = this.Icon;

            form2.Show();
        }

        private void Form2_FormClosing(object? sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        Bitmap bmp = new Bitmap(400, 400);
        static string[,] bitmap_layers = new string[400, 400]; // points are being set on top of one another on the bitmap, so we save id's here
        Bitmap graph = new Bitmap(400, 400);

        bool stopasync = false;

        static decimal current_time = 0; // main velocity counter (R.I.P. sped: ~01.06.2022 -- 23.01.2023)

        bool firstime = true;

        static string[] positions = new string[0]; // now in decimal form as well
        static string[] velocity = new string[0]; // 1st, 2nd and 3rd dimension speeds

        static int[] atomic_number = new int[0];
        static int[] electron_number = new int[0];
        static int[] neutron_number = new int[0];

        static int[] valence_electrons = new int[0];

        static string[] covalent_bonds = new string[0]; // covalent(electron sharing) bonds     // contains id's of points that one object is connected to covalently
        static string[] covalent_bond_strength = new string[0];
        static string[] ionic_bonds = new string[0]; // strong elctromagnetic bonds(no electrons shared)     // contains id's of points that one object is connected to ionically

        // no hydrogen_bonds as they can be easily simulated without need to store any info about them

        static decimal[] startime = new decimal[0]; // time when last position was set

        static string[] colors = new string[0];

        static string[,,] space3D = new string[200, 200, 200]; // formerly bitmap_layers    // contains id's of points
        static int[] size = new int[3] { 200, 200, 200 };

        bool stopasync2 = false;

        public static int GetValenceElectrons(int protons)
        {
            int temp_protons = protons;

            int[] orbits = new int[1];

            if (protons <= 2)
            {
                orbits[0] = protons;
                temp_protons = temp_protons - 2;
            }

            else
            {
                orbits[0] = 2;
                temp_protons = temp_protons - 2;

                int[] subshells = new int[1] { 2 };
                Array.Resize(ref orbits, orbits.Length + 1);

                int count2 = 1; // for repeating subtractions of energy levels (such as 3s 2p and 4s 3p which are technically equal)   // here 1s has already been filled

                for (int i = 0; temp_protons > 0; i++)
                {
                    for (int j = subshells.Length - 1; j > -1; j--)
                    {
                        if (temp_protons - subshells[j] > 0)
                        {
                            orbits[orbits.Length - 1 - j] += subshells[j];
                            temp_protons = temp_protons - subshells[j];
                        }

                        else
                        {
                            orbits[orbits.Length - 1 - j] += temp_protons;
                            temp_protons = 0;
                            break;
                        }
                    }

                    if (true && orbits[orbits.Length - 1] != 0)
                    {
                        Array.Resize(ref orbits, orbits.Length + 1);
                    }

                    count2++;

                    if (count2 == 2)
                    {
                        count2 = 0;

                        if (true)
                        {
                            Array.Resize(ref subshells, subshells.Length + 1);
                            subshells[subshells.Length - 1] = subshells[subshells.Length - 2] + 4;
                        }

                        else
                        {
                            int[] te = new int[subshells.Length - 1];

                            for (int k = 1; k < subshells.Length; k++)
                            {
                                te[k - 1] = subshells[k];
                            }

                            subshells = te;
                        }
                    }
                }
            }

            if (orbits[orbits.Length - 1] == 0)
            {
                return orbits[orbits.Length - 2];
            }

            else
            {
                return orbits[orbits.Length - 1];
            }
        }

        public static string[] Calculate_Structure(int index_of_centeral_atom)
        {
            string[] directions = covalent_bonds[index_of_centeral_atom].Split();

            if (GetValenceElectrons(atomic_number[index_of_centeral_atom]) == 1)
            {
                decimal distance = Convert.ToDecimal(positions[Convert.ToInt32(directions[0])].Split()[0]);

                //if (directions[0])
                //{

                //}
            }

            if (GetValenceElectrons(atomic_number[index_of_centeral_atom]) == 2)
            {

            }

            if (GetValenceElectrons(atomic_number[index_of_centeral_atom]) == 3)
            {

            }

            if (GetValenceElectrons(atomic_number[index_of_centeral_atom]) == 4)
            {

            }

            if (GetValenceElectrons(atomic_number[index_of_centeral_atom]) == 5)
            {

            }

            if (GetValenceElectrons(atomic_number[index_of_centeral_atom]) == 6)
            {

            }

            if (GetValenceElectrons(atomic_number[index_of_centeral_atom]) == 7)
            {

            }

            if (GetValenceElectrons(atomic_number[index_of_centeral_atom]) == 8)
            {

            }

            return new string[0];
        }

        private async Task GetTime()
        {
            Stopwatch t = new Stopwatch();

            //t.Start();
            //for (int i = 0; t.ElapsedTicks < 1; i++)
            //{

            //}
            //t.Stop();
            //t.Reset();

            current_time = current_time + (decimal)1;//1 nanosecond; 100 nanoseconds = 1 tick; 10000 ticks = 1 millisecond; 1000 milliseconds = 1 second
            stopasync2 = false;
        }

        bool firstime_for_reality_travel = true;

        public void reality_one_point_travel_Click(object sender, EventArgs e)
        {
            Angle.GetCosSin(InfiNum.num(150), new InfiNum[2] { InfiNum.num(0), InfiNum.num(0) }, new InfiNum[2] { (InfiNum.num(3)&InfiNum.num(2))/InfiNum.num(2), InfiNum.num(Convert.ToDecimal(0.5)) }, out InfiNum[] newpos);
            Angle.GetDegreeAngle(new InfiNum[2] { (InfiNum.num(3) & InfiNum.num(2)) / InfiNum.num(2), (InfiNum.num(1) & InfiNum.num(2)) / InfiNum.num(2) }, new InfiNum[2] { InfiNum.num(0), InfiNum.num(0) }, new InfiNum[2] { (InfiNum.num(3) & InfiNum.num(2)) / InfiNum.num(2), -(InfiNum.num(Convert.ToDecimal(0.5))) }, out InfiNum angle);

            int grj = GetValenceElectrons(53);

            InfiNum ig = new InfiNum("0.0011").Round(2);

            string[] a = textBox1.Text.Split();

            if ((space3D[Convert.ToInt32(Math.Round(Convert.ToDecimal(a[0]))), Convert.ToInt32(Math.Round(Convert.ToDecimal(a[1]))), Convert.ToInt32(Math.Round(Convert.ToDecimal(a[2])))] == "" || space3D[Convert.ToInt32(Math.Round(Convert.ToDecimal(a[0]))), Convert.ToInt32(Math.Round(Convert.ToDecimal(a[1]))), Convert.ToInt32(Math.Round(Convert.ToDecimal(a[2])))] == null) && shi == false)
            {
                Array.Resize(ref positions, positions.Length + 1);
                Array.Resize(ref velocity, velocity.Length + 1);
                Array.Resize(ref startime, startime.Length + 1);
                Array.Resize(ref colors, colors.Length + 1);

                Array.Resize(ref atomic_number, atomic_number.Length + 1);
                Array.Resize(ref neutron_number, neutron_number.Length + 1);
                Array.Resize(ref electron_number, electron_number.Length + 1);

                string[] e1 = textBox15.Text.Split(" ");

                atomic_number[atomic_number.Length - 1] = Convert.ToInt32(e1[0]);
                neutron_number[neutron_number.Length - 1] = Convert.ToInt32(e1[1]);
                electron_number[electron_number.Length - 1] = Convert.ToInt32(e1[2]);

                string[] speed = textBox3.Text.Split();

                positions[positions.Length - 1] = a[0] + " " + a[1] + " " + a[2];

                velocity[velocity.Length - 1] = speed[0] + " " + speed[1] + " " + speed[2];//velocity = "1d speed" + "2d speed" + "3d speed"

                startime[startime.Length - 1] = current_time;

                string[] h1 = positions[positions.Length - 1].Split();

                string[] color = textBox2.Text.Split();

                int xpoint2d = 0;
                int ypoint2d = 0;

                xpoint2d = (size[0] - Convert.ToInt32(a[2])) + Convert.ToInt32(a[0]);
                ypoint2d = Convert.ToInt32(((size[0] - Convert.ToInt32(a[1])) + Convert.ToInt32(a[2]) + Convert.ToInt32(a[0])) / 1.5);

                string[] ids = new string[0];
                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                {
                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                }

                bool tempset = false;

                for (int jj = 0; jj < ids.Length; jj++)
                {
                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(a[1]))
                    {
                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                        if (jj == 0)
                        {
                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                        }

                        int temp = 1;

                        for (int k = 1; k < ids.Length; k++)
                        {
                            if (k != jj)
                            {
                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp];
                                temp++;
                            }

                            else
                            {
                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + (positions.Length - 1).ToString();
                            }
                        }

                        tempset = true;
                        break;
                    }

                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(a[1]))
                    {
                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(a[0]))
                        {
                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                            if (jj == 0)
                            {
                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                            }

                            int temp_ = 1;

                            for (int k = 1; k < ids.Length; k++)
                            {
                                if (k != jj)
                                {
                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                    temp_++;
                                }

                                else
                                {
                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + (positions.Length - 1).ToString();
                                }
                            }

                            tempset = true;
                            break;
                        }
                    }
                }

                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                {
                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + (positions.Length - 1).ToString();
                }

                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                {
                    bitmap_layers[xpoint2d, ypoint2d] = (positions.Length - 1).ToString();
                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                }

                space3D[Convert.ToInt32(Math.Round(Convert.ToDecimal(h1[0]))), Convert.ToInt32(Math.Round(Convert.ToDecimal(h1[1]))), Convert.ToInt32(Math.Round(Convert.ToDecimal(h1[2])))] = (positions.Length - 1).ToString();

                colors[colors.Length - 1] = color[0] + " " + color[1] + " " + color[2];

                if (firstime_for_reality_travel)
                {
                    firstime_for_reality_travel = false;
                    reality_travel();
                }
            }

            else
            {
                if (firstime_for_reality_travel && shi)
                {
                    firstime_for_reality_travel = false;
                    reality_travel();
                }
            }
        }

        private async void reality_travel()
        {
            if (firstime == !true)
            {
            }

            else
            {
                if (stopasync == false)
                {
                    if (stopasync2 == false)
                    {
                        for (int jhj = 0; positions.Length > 0; jhj++)
                        {
                            //bool[] moved = new bool[velocity.Length]; // idk what for

                            //for (int i = 0; i < moved.Length; i++)
                            //{
                            //    moved[i] = false;
                            //}

                            if (stopasync == false)
                            {
                                if (stopasync2 == false)
                                {
                                    Stopwatch howmuchtime = new Stopwatch();

                                    howmuchtime.Start();
                                    stopasync2 = true;

                                    Stopwatch tt = new Stopwatch();
                                    tt.Start();
                                    await Task.Run(() => GetTime());
                                    tt.Stop();

                                    if (stopasync == false)
                                    {
                                        if (stopasync2 == false)
                                        {
                                            for (int i = 0; i < velocity.Length; i++)
                                            {
                                                //so first thing's first: no more absolute coordinates(or speeds?), only when displaying to bitmap

                                                string[] speeds = velocity[i].Split();
                                                decimal firstdimensionspeed = Convert.ToDecimal(speeds[0]);
                                                decimal seconddimensionspeed = Convert.ToDecimal(speeds[1]);
                                                decimal thirddimensionspeed = Convert.ToDecimal(speeds[2]);

                                                if (firstdimensionspeed != 0 && seconddimensionspeed != 0 && thirddimensionspeed != 0)
                                                {
                                                    if (firstdimensionspeed > 1000000000 || seconddimensionspeed > 1000000000 || thirddimensionspeed > 1000000000)
                                                    {
                                                        int guh = 0;

                                                    }

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0  || (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0  || (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0 )
                                                    {
                                                        //main travel code

                                                        //right(x) only

                                                        if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)))
                                                        {
                                                            string[] h_coords = positions[i].Split();

                                                            decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                            //if hit border
                                                            if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                            {
                                                                velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //if hit object
                                                                if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] != "")
                                                                {
                                                                    string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])].Split();
                                                                    int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                    string[] h_speed2 = velocity[i2].Split();

                                                                    decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                    decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                    decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                    decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                    decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                    decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                    decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                    //first dimension energy transfer
                                                                    firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //second dimension energy transfer
                                                                    seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //third dimension energy transfer
                                                                    thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    if (firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    //rewrite

                                                                    //original point
                                                                    velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;

                                                                    //point that it hit
                                                                    velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                else
                                                                {
                                                                    //moved[i] = true;
                                                                    //new position
                                                                    positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + coords[1].ToString() + " " + coords[2].ToString();

                                                                    //save previous point info
                                                                    string[] color = colors[i].Split();

                                                                    //erase previous point
                                                                    int xpoint2dt = 0;
                                                                    int ypoint2dt = 0;

                                                                    decimal xt = coords[0];
                                                                    decimal yt = coords[1];
                                                                    decimal zt = coords[2];

                                                                    xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                    ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                    // Erasing or replacing point

                                                                    int[] bit_lay = new int[0];
                                                                    string[] h_bit = new string[0];

                                                                    if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                    {
                                                                        bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                        h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                    }

                                                                    for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                    {
                                                                        bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                    }

                                                                    if (bit_lay.Length > 1)
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                        for (int jj = 0; jj < h_bit.Length; jj++)
                                                                        {
                                                                            
                                                                            if (bit_lay[jj] != i)
                                                                            {
                                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                                }
                                                                            }
                                                                        }

                                                                        string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                        string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                        string[] c = colors[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                    }

                                                                    else
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    }

                                                                    //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                    //set new point
                                                                    int xpoint2d = 0;
                                                                    int ypoint2d = 0;

                                                                    decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                    decimal y = coords[1];
                                                                    decimal z = coords[2];

                                                                    xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                    ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                    // Adding and maybe setting new point
                                                                    string[] ids = new string[0];

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                    {
                                                                        ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                    }

                                                                    bool tempset = false;

                                                                    for (int jj = 0; jj < ids.Length; jj++)
                                                                    {
                                                                        string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                        if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }

                                                                        if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                        {
                                                                            if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                                if (jj == 0)
                                                                                {
                                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                                }

                                                                                int temp_ = 1;

                                                                                for (int k = 1; k < ids.Length; k++)
                                                                                {
                                                                                    if (k != jj)
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                        temp_++;
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                    }
                                                                                }

                                                                                tempset = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                        bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                    }

                                                                    //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                    space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = i.ToString();
                                                                }
                                                            }
                                                        }

                                                        //up(y) only

                                                        if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)))
                                                        {
                                                            string[] h_coords = positions[i].Split();

                                                            decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                            //if hit border (fixed)
                                                            if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // y + 1(or -1)
                                                            {
                                                                velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //if hit object
                                                                if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != "")
                                                                {
                                                                    string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])].Split();
                                                                    int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                    string[] h_speed2 = velocity[i2].Split();

                                                                    decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                    decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                    decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                    decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                    decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                    decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                    decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                    //first dimension energy transfer
                                                                    firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //second dimension energy transfer
                                                                    seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //third dimension energy transfer
                                                                    thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //rewrite

                                                                    if (firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    //original point
                                                                    velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;

                                                                    //point that it hit
                                                                    velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                else
                                                                {
                                                                    //moved[i] = true;
                                                                    //new position
                                                                    positions[i] = coords[0].ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + coords[2].ToString();

                                                                    //save previous point info
                                                                    string[] color = colors[i].Split();

                                                                    //erase previous point
                                                                    int xpoint2dt = 0;
                                                                    int ypoint2dt = 0;

                                                                    decimal xt = coords[0];
                                                                    decimal yt = coords[1];
                                                                    decimal zt = coords[2];

                                                                    xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                    ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                    // Erasing or replacing point

                                                                    int[] bit_lay = new int[0];
                                                                    string[] h_bit = new string[0];

                                                                    if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                    {
                                                                        bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                        h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                    }

                                                                    for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                    {
                                                                        bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                    }

                                                                    if (bit_lay.Length > 1)
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                        for (int jj = 0; jj < h_bit.Length; jj++)
                                                                        {
                                                                            
                                                                            if (bit_lay[jj] != i)
                                                                            {
                                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                                }
                                                                            }
                                                                        }

                                                                        string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                        string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                        string[] c = colors[i].Split(" ");

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                    }

                                                                    else
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    }

                                                                    //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                    //set new point
                                                                    int xpoint2d = 0;
                                                                    int ypoint2d = 0;

                                                                    decimal x = coords[0];
                                                                    decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                    decimal z = coords[2];

                                                                    xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                    ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                    // Adding and maybe setting new point
                                                                    string[] ids = new string[0];

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                    {
                                                                        ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                    }

                                                                    bool tempset = false;

                                                                    for (int jj = 0; jj < ids.Length; jj++)
                                                                    {
                                                                        string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                        if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }

                                                                        if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                        {
                                                                            if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                                if (jj == 0)
                                                                                {
                                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                                }

                                                                                int temp_ = 1;

                                                                                for (int k = 1; k < ids.Length; k++)
                                                                                {
                                                                                    if (k != jj)
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                        temp_++;
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                    }
                                                                                }

                                                                                tempset = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                        bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                    }

                                                                    //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] = i.ToString();
                                                                }
                                                            }
                                                        }

                                                        //forward(z) only

                                                        if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)))
                                                        {
                                                            //main travel code

                                                            string[] h_coords = positions[i].Split();

                                                            decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                            //if hit border
                                                            if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                            {
                                                                velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //if hit object
                                                                if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                                {
                                                                    string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                    int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                    string[] h_speed2 = velocity[i2].Split();

                                                                    decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                    decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                    decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                    decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                    decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                    decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                    decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                    //first dimension energy transfer
                                                                    firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //second dimension energy transfer
                                                                    seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //third dimension energy transfer
                                                                    thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    if (firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    //rewrite
                                                                    velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;

                                                                    velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                else
                                                                {
                                                                    //moved[i] = true;
                                                                    //new position
                                                                    positions[i] = coords[0].ToString() + " " + coords[1].ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                    //save previous point info
                                                                    string[] color = colors[i].Split(" ");

                                                                    //erase previous point
                                                                    int xpoint2dt = 0;
                                                                    int ypoint2dt = 0;

                                                                    decimal xt = coords[0];
                                                                    decimal yt = coords[1];
                                                                    decimal zt = coords[2];

                                                                    xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                    ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                    // Erasing or replacing point

                                                                    int[] bit_lay = new int[0];
                                                                    string[] h_bit = new string[0];

                                                                    if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                    {
                                                                        bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                        h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                    }

                                                                    for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                    {
                                                                        bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                    }

                                                                    if (bit_lay.Length > 1)
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                        for (int jj = 0; jj < h_bit.Length; jj++)
                                                                        {
                                                                            
                                                                            if (bit_lay[jj] != i)
                                                                            {
                                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                                }
                                                                            }
                                                                        }

                                                                        string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                        string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                        string[] c = colors[i].Split(" ");

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                    }

                                                                    else
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    }

                                                                    //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                    //set new point
                                                                    int xpoint2d = 0;
                                                                    int ypoint2d = 0;

                                                                    decimal x = coords[0];
                                                                    decimal y = coords[1];
                                                                    decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                    xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                    ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                    // Adding and maybe setting new point
                                                                    string[] ids = new string[0];

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                    {
                                                                        ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                    }

                                                                    bool tempset = false;

                                                                    for (int jj = 0; jj < ids.Length; jj++)
                                                                    {
                                                                        string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                        if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }

                                                                        if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                        {
                                                                            if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                                if (jj == 0)
                                                                                {
                                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                                }

                                                                                int temp_ = 1;

                                                                                for (int k = 1; k < ids.Length; k++)
                                                                                {
                                                                                    if (k != jj)
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                        temp_++;
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                    }
                                                                                }

                                                                                tempset = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                        bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                    }

                                                                    //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                                }
                                                            }
                                                        }

                                                        //up and right

                                                        if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)))
                                                        {
                                                            string[] h_coords = positions[i].Split();

                                                            decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                            //if hit border
                                                            if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0) || coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // x + 1(or -1) || y + 1(or -1)
                                                            {
                                                                if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                                {
                                                                    velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // y + 1(or -1)
                                                                {
                                                                    velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }
                                                            }

                                                            else
                                                            {
                                                                //if hit object
                                                                if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != "")
                                                                {
                                                                    string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])].Split();
                                                                    int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                    string[] h_speed2 = velocity[i2].Split();

                                                                    decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                    decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                    decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                    decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                    decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                    decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                    decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                    //first dimension energy transfer
                                                                    firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //second dimension energy transfer
                                                                    seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //third dimension energy transfer
                                                                    thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    if (firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    //rewrite
                                                                    velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;

                                                                    velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                else
                                                                {
                                                                    //moved[i] = true;
                                                                    //new position
                                                                    positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + coords[2].ToString();

                                                                    //save previous point info
                                                                    string[] color = colors[i].Split();

                                                                    //erase previous point
                                                                    int xpoint2dt = 0;
                                                                    int ypoint2dt = 0;

                                                                    decimal xt = coords[0];
                                                                    decimal yt = coords[1];
                                                                    decimal zt = coords[2];

                                                                    xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                    ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                    // Erasing or replacing point

                                                                    int[] bit_lay = new int[0];
                                                                    string[] h_bit = new string[0];

                                                                    if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                    {
                                                                        bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                        h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                    }

                                                                    for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                    {
                                                                        bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                    }

                                                                    if (bit_lay.Length > 1)
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                        for (int jj = 0; jj < h_bit.Length; jj++)
                                                                        {
                                                                            
                                                                            if (bit_lay[jj] != i)
                                                                            {
                                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                                }
                                                                            }
                                                                        }

                                                                        string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                        string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                        string[] c = colors[i].Split(" ");

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                    }

                                                                    else
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    }

                                                                    //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                    //set new point
                                                                    int xpoint2d = 0;
                                                                    int ypoint2d = 0;

                                                                    decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                    decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                    decimal z = coords[2];

                                                                    xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                    ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                    // Adding and maybe setting new point
                                                                    string[] ids = new string[0];

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                    {
                                                                        ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                    }

                                                                    bool tempset = false;

                                                                    for (int jj = 0; jj < ids.Length; jj++)
                                                                    {
                                                                        string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                        if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }

                                                                        if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                        {
                                                                            if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                                if (jj == 0)
                                                                                {
                                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                                }

                                                                                int temp_ = 1;

                                                                                for (int k = 1; k < ids.Length; k++)
                                                                                {
                                                                                    if (k != jj)
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                        temp_++;
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                    }
                                                                                }

                                                                                tempset = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                        bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                    }

                                                                    //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                    space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] = i.ToString();
                                                                }
                                                            }
                                                        }

                                                        //forward and right

                                                        if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)))
                                                        {
                                                            string[] h_coords = positions[i].Split();

                                                            decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                            //if hit border
                                                            if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0) || coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // x + 1(or -1) || y + 1(or -1)
                                                            {
                                                                if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                                {
                                                                    velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                                {
                                                                    velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }
                                                            }

                                                            else
                                                            {
                                                                //if hit object
                                                                if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                                {
                                                                    string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                    int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                    string[] h_speed2 = velocity[i2].Split();

                                                                    decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                    decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                    decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                    decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                    decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                    decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                    decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                    //first dimension energy transfer
                                                                    firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //second dimension energy transfer
                                                                    seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //third dimension energy transfer
                                                                    thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    if (firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    //rewrite
                                                                    velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;

                                                                    velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                else
                                                                {
                                                                    //moved[i] = true;
                                                                    //new position
                                                                    positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + coords[1].ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                    //save previous point info
                                                                    
                                                                    string[] color = colors[i].Split(" ");

                                                                    //erase previous point
                                                                    int xpoint2dt = 0;
                                                                    int ypoint2dt = 0;

                                                                    decimal xt = coords[0];
                                                                    decimal yt = coords[1];
                                                                    decimal zt = coords[2];

                                                                    xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                    ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                    // Erasing or replacing point

                                                                    int[] bit_lay = new int[0];
                                                                    string[] h_bit = new string[0];

                                                                    if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                    {
                                                                        bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                        h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                    }

                                                                    for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                    {
                                                                        bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                    }

                                                                    if (bit_lay.Length > 1)
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                        for (int jj = 0; jj < h_bit.Length; jj++)
                                                                        {
                                                                            
                                                                            if (bit_lay[jj] != i)
                                                                            {
                                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                                }
                                                                            }
                                                                        }

                                                                        string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                        string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                        string[] c = colors[i].Split(" ");

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                    }

                                                                    else
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    }

                                                                    //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                    //set new point
                                                                    int xpoint2d = 0;
                                                                    int ypoint2d = 0;

                                                                    decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                    decimal y = coords[1];
                                                                    decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                    xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                    ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                    // Adding and maybe setting new point
                                                                    string[] ids = new string[0];

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                    {
                                                                        ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                    }

                                                                    bool tempset = false;

                                                                    for (int jj = 0; jj < ids.Length; jj++)
                                                                    {
                                                                        string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                        if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }

                                                                        if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                        {
                                                                            if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                                if (jj == 0)
                                                                                {
                                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                                }

                                                                                int temp_ = 1;

                                                                                for (int k = 1; k < ids.Length; k++)
                                                                                {
                                                                                    if (k != jj)
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                        temp_++;
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                    }
                                                                                }

                                                                                tempset = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                        bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                    }

                                                                    //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                    space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                                }
                                                            }
                                                        }

                                                        //forward and up

                                                        if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0 )
                                                        {
                                                            string[] h_coords = positions[i].Split();

                                                            decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                            //if hit border
                                                            if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[0] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0) || coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // x + 1(or -1) || y + 1(or -1)
                                                            {
                                                                if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[0] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // x + 1(or -1)
                                                                {
                                                                    velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                                {
                                                                    velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }
                                                            }

                                                            else
                                                            {
                                                                //if hit object
                                                                if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                                {
                                                                    string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                    int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                    string[] h_speed2 = velocity[i2].Split();

                                                                    decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                    decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                    decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                    decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                    decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                    decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                    decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                    //first dimension energy transfer
                                                                    firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //second dimension energy transfer
                                                                    seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //third dimension energy transfer
                                                                    thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    if (firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    //rewrite
                                                                    velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;

                                                                    velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                else
                                                                {
                                                                    //moved[i] = true;
                                                                    //new position
                                                                    positions[i] = coords[0].ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                    //save previous point info
                                                                    
                                                                    string[] color = colors[i].Split(" ");

                                                                    //erase previous point
                                                                    int xpoint2dt = 0;
                                                                    int ypoint2dt = 0;

                                                                    decimal xt = coords[0];
                                                                    decimal yt = coords[1];
                                                                    decimal zt = coords[2];

                                                                    xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                    ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                    // Erasing or replacing point

                                                                    int[] bit_lay = new int[0];
                                                                    string[] h_bit = new string[0];

                                                                    if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                    {
                                                                        bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                        h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                    }

                                                                    for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                    {
                                                                        bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                    }

                                                                    if (bit_lay.Length > 1)
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                        for (int jj = 0; jj < h_bit.Length; jj++)
                                                                        {

                                                                            if (bit_lay[jj] != i)
                                                                            {
                                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                                {

                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                                }
                                                                            }
                                                                        }

                                                                        string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                        string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                        string[] c = colors[i].Split(" ");

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                    }

                                                                    else
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    }

                                                                    //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                    //set new point
                                                                    int xpoint2d = 0;
                                                                    int ypoint2d = 0;

                                                                    decimal x = coords[0];
                                                                    decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                    decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                    xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                    ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                    // Adding and maybe setting new point
                                                                    string[] ids = new string[0];

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                    {
                                                                        ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                    }

                                                                    bool tempset = false;

                                                                    for (int jj = 0; jj < ids.Length; jj++)
                                                                    {
                                                                        string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                        if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }

                                                                        if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                        {
                                                                            if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                                if (jj == 0)
                                                                                {
                                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                                }

                                                                                int temp_ = 1;

                                                                                for (int k = 1; k < ids.Length; k++)
                                                                                {
                                                                                    if (k != jj)
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                        temp_++;
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                    }
                                                                                }

                                                                                tempset = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                        bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                    }

                                                                    //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                                }
                                                            }
                                                        }

                                                        //right, up and forward

                                                        if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0 )
                                                        {
                                                            string[] h_coords = positions[i].Split();

                                                            decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                            //if hit border
                                                            if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0) || coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0) || coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // x + 1(or -1) || y + 1(or -1) || z + 1(or -1)
                                                            {
                                                                if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                                {
                                                                    velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // y + 1(or -1)
                                                                {
                                                                    velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                                {
                                                                    velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                                    startime[i] = current_time;
                                                                }
                                                            }

                                                            else
                                                            {
                                                                //if hit object
                                                                if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                                {
                                                                    string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                    int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                    string[] h_speed2 = velocity[i2].Split();

                                                                    decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                    decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                    decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                    decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                    decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                    decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                    decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                    //first dimension energy transfer
                                                                    firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //second dimension energy transfer
                                                                    seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    //third dimension energy transfer
                                                                    thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                    speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                    if (firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                    }

                                                                    if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                    {
                                                                        speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                    }

                                                                    //rewrite
                                                                    velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;

                                                                    velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                    startime[i] = current_time;
                                                                }

                                                                else
                                                                {
                                                                    //moved[i] = true;
                                                                    //new position
                                                                    positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                    //save previous point info
                                                                    
                                                                    string[] color = colors[i].Split(" ");

                                                                    //erase previous point
                                                                    int xpoint2dt = 0;
                                                                    int ypoint2dt = 0;

                                                                    decimal xt = coords[0];
                                                                    decimal yt = coords[1];
                                                                    decimal zt = coords[2];

                                                                    xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                    ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                    // Erasing or replacing point

                                                                    int[] bit_lay = new int[0];
                                                                    string[] h_bit = new string[0];

                                                                    if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                    {
                                                                        bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                        h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                    }

                                                                    for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                    {
                                                                        bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                    }

                                                                    if (bit_lay.Length > 1)
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                        for (int jj = 0; jj < h_bit.Length; jj++)
                                                                        {
                                                                            
                                                                            if (bit_lay[jj] != i)
                                                                            {
                                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                                {
                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                                }

                                                                                else
                                                                                {

                                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                                }
                                                                            }
                                                                        }

                                                                        string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                        string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                        string[] c = colors[i].Split(" ");

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                    }

                                                                    else
                                                                    {
                                                                        bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                        bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    }

                                                                    //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                    space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                    //set new point
                                                                    int xpoint2d = 0;
                                                                    int ypoint2d = 0;

                                                                    decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                    decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                    decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                    xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                    ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                    // Adding and maybe setting new point
                                                                    string[] ids = new string[0];

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                    {
                                                                        ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                    }

                                                                    bool tempset = false;

                                                                    for (int jj = 0; jj < ids.Length; jj++)
                                                                    {
                                                                        string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                        if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }

                                                                        if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                        {
                                                                            if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                                if (jj == 0)
                                                                                {
                                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                                }

                                                                                int temp_ = 1;

                                                                                for (int k = 1; k < ids.Length; k++)
                                                                                {
                                                                                    if (k != jj)
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                        temp_++;
                                                                                    }

                                                                                    else
                                                                                    {
                                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                    }
                                                                                }

                                                                                tempset = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                    }

                                                                    if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                        bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                    }

                                                                    //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                    space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }










                                                if (firstdimensionspeed != 0 && seconddimensionspeed == 0 && thirddimensionspeed == 0)
                                                {
                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0 )
                                                    {
                                                        //main travel code

                                                        //right(x) only

                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border (fixed)
                                                        if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                        {
                                                            velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + coords[1].ToString() + " " + coords[2].ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");
                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                decimal y = coords[1];
                                                                decimal z = coords[2];

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = i.ToString();
                                                            }


                                                        }
                                                    }
                                                }










                                                if (firstdimensionspeed == 0 && seconddimensionspeed != 0 && thirddimensionspeed == 0)
                                                {
                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0 )
                                                    {
                                                        //main travel code

                                                        //up(y) only

                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // y + 1(or -1)
                                                        {
                                                            velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = coords[0].ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + coords[2].ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0];
                                                                decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                decimal z = coords[2];

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] = i.ToString();
                                                            }
                                                        }
                                                    }
                                                }








                                                if (firstdimensionspeed == 0 && seconddimensionspeed == 0 && thirddimensionspeed != 0)
                                                {
                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0 )
                                                    {
                                                        //main travel code

                                                        //forward(z) only

                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                        {
                                                            velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = coords[0].ToString() + " " + coords[1].ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                int[] xs = new int[bit_lay.Length];
                                                                int[] ys = new int[bit_lay.Length];
                                                                int[] zs = new int[bit_lay.Length];

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);

                                                                    string[] help = positions[bit_lay[jj]].Split(" ");

                                                                    xs[jj] = Convert.ToInt32(help[0]);
                                                                    ys[jj] = Convert.ToInt32(help[1]);
                                                                    zs[jj] = Convert.ToInt32(help[2]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        

                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {

                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0];
                                                                decimal y = coords[1];
                                                                decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                            }
                                                        }
                                                    }
                                                }






                                                if (firstdimensionspeed != 0 && seconddimensionspeed != 0 && thirddimensionspeed == 0)
                                                {
                                                    //main travel code

                                                    //right(x) only

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) != Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)))
                                                    {
                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                        {
                                                            velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite

                                                                //original point
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                //point that it hit
                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + coords[1].ToString() + " " + coords[2].ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                decimal y = coords[1];
                                                                decimal z = coords[2];

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = i.ToString();
                                                            }
                                                        }
                                                    }

                                                    //up(y) only

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0 )
                                                    {
                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border (fixed)
                                                        if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // y + 1(or -1)
                                                        {
                                                            velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite

                                                                //original point
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                //point that it hit
                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = coords[0].ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + coords[2].ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0];
                                                                decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                decimal z = coords[2];

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] = i.ToString();
                                                            }
                                                        }
                                                    }

                                                    //up and right

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0 )
                                                    {
                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0) || coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // x + 1(or -1) || y + 1(or -1)
                                                        {
                                                            if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                            {
                                                                velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // y + 1(or -1)
                                                            {
                                                                velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + coords[2].ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                decimal z = coords[2];

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] = i.ToString();
                                                            }
                                                        }
                                                    }
                                                }












                                                if (firstdimensionspeed != 0 && seconddimensionspeed == 0 && thirddimensionspeed != 0)
                                                {
                                                    //main travel code

                                                    //right(x) only

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0 )
                                                    {
                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                        {
                                                            velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite

                                                                //original point
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                //point that it hit
                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + coords[1].ToString() + " " + coords[2].ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                decimal y = coords[1];
                                                                decimal z = coords[2];

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = i.ToString();
                                                            }
                                                        }
                                                    }

                                                    //forward(z) only

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0 )
                                                    {
                                                        //main travel code

                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                        {
                                                            velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = coords[0].ToString() + " " + coords[1].ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0];
                                                                decimal y = coords[1];
                                                                decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                            }
                                                        }
                                                    }

                                                    //forward and right

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / firstdimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0 )
                                                    {
                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0) || coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // x + 1(or -1) || y + 1(or -1)
                                                        {
                                                            if (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) > size[0] - 1 || (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed) < 0)) // x + 1(or -1)
                                                            {
                                                                velocity[i] = (-firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                            {
                                                                velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = (coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)).ToString() + " " + coords[1].ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed);
                                                                decimal y = coords[1];
                                                                decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0] + firstdimensionspeed / Math.Abs(firstdimensionspeed)), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                            }
                                                        }
                                                    }
                                                }












                                                if (firstdimensionspeed == 0 && seconddimensionspeed != 0 && thirddimensionspeed != 0)
                                                {
                                                    //main travel code

                                                    //forward(z) only

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0 )
                                                    {
                                                        //main travel code

                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                        {
                                                            velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite

                                                                // orignial point
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                //point that it hit
                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = coords[0].ToString() + " " + coords[1].ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0];
                                                                decimal y = coords[1];
                                                                decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                            }
                                                        }
                                                    }

                                                    //up(y) only

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0 )
                                                    {
                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border (fixed)
                                                        if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[1] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // y + 1(or -1)
                                                        {
                                                            velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                            startime[i] = current_time;
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite

                                                                //original point
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                //point that it hit
                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = coords[0].ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + coords[2].ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0];
                                                                decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                decimal z = coords[2];

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2])] = i.ToString();
                                                            }
                                                        }
                                                    }

                                                    //forward and up

                                                    if ((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / thirddimensionspeed)) != 0  && (current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed) == Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) && Math.Round((current_time - startime[i]) / Math.Round(1_000_000_000/*nanoseconds*/ / seconddimensionspeed)) != 0 )
                                                    {
                                                        string[] h_coords = positions[i].Split();

                                                        decimal[] coords = new decimal[3] { Convert.ToDecimal(h_coords[0]), Convert.ToDecimal(h_coords[1]), Convert.ToDecimal(h_coords[2]) };

                                                        //if hit border
                                                        if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[0] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0) || coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // x + 1(or -1) || y + 1(or -1)
                                                        {
                                                            if (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) > size[0] - 1 || (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed) < 0)) // x + 1(or -1)
                                                            {
                                                                velocity[i] = (firstdimensionspeed).ToString() + " " + (-seconddimensionspeed).ToString() + " " + (thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            if (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) > size[2] - 1 || (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed) < 0)) // y + 1(or -1)
                                                            {
                                                                velocity[i] = (firstdimensionspeed).ToString() + " " + (seconddimensionspeed).ToString() + " " + (-thirddimensionspeed).ToString();
                                                                startime[i] = current_time;
                                                            }
                                                        }

                                                        else
                                                        {
                                                            //if hit object
                                                            if (space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != null && space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] != "")
                                                            {
                                                                string[] h_secondspeed = space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))].Split();
                                                                int i2 = Convert.ToInt32(h_secondspeed[0]);

                                                                string[] h_speed2 = velocity[i2].Split();

                                                                decimal[] speed2 = new decimal[3] { Convert.ToDecimal(h_speed2[0]), Convert.ToDecimal(h_speed2[1]), Convert.ToDecimal(h_speed2[2]) };

                                                                decimal firstdimensionspeedtemp = firstdimensionspeed;
                                                                decimal seconddimensionspeedtemp = seconddimensionspeed;
                                                                decimal thirddimensionspeedtemp = thirddimensionspeed;

                                                                decimal speed2_firstdimensionspeedtemp = speed2[0];
                                                                decimal speed2_seconddimensionspeedtemp = speed2[1];
                                                                decimal speed2_thirddimensionspeedtemp = speed2[2];

                                                                //first dimension energy transfer
                                                                firstdimensionspeedtemp = (speed2_firstdimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_firstdimensionspeedtemp = (firstdimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //second dimension energy transfer
                                                                seconddimensionspeedtemp = (speed2_seconddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_seconddimensionspeedtemp = (seconddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                //third dimension energy transfer
                                                                thirddimensionspeedtemp = (speed2_thirddimensionspeedtemp * (atomic_number[i2] + neutron_number[i2])) / (atomic_number[i] + neutron_number[i]);
                                                                speed2_thirddimensionspeedtemp = (thirddimensionspeed * (atomic_number[i] + neutron_number[i])) / (atomic_number[i2] + neutron_number[i2]);

                                                                if (firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_firstdimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_firstdimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_seconddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_seconddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp > 1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = 1_000_000_000;
                                                                }

                                                                if (speed2_thirddimensionspeedtemp < -1_000_000_000)
                                                                {
                                                                    speed2_thirddimensionspeedtemp = -1_000_000_000;
                                                                }

                                                                //rewrite
                                                                velocity[i] = firstdimensionspeedtemp.ToString() + " " + seconddimensionspeedtemp.ToString() + " " + thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;

                                                                velocity[i2] = speed2_firstdimensionspeedtemp.ToString() + " " + speed2_seconddimensionspeedtemp.ToString() + " " + speed2_thirddimensionspeedtemp.ToString();
                                                                startime[i] = current_time;
                                                            }

                                                            else
                                                            {
                                                                //moved[i] = true;
                                                                //new position
                                                                positions[i] = coords[0].ToString() + " " + (coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)).ToString() + " " + (coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed)).ToString();

                                                                //save previous point info
                                                                
                                                                string[] color = colors[i].Split(" ");

                                                                //erase previous point
                                                                int xpoint2dt = 0;
                                                                int ypoint2dt = 0;

                                                                decimal xt = coords[0];
                                                                decimal yt = coords[1];
                                                                decimal zt = coords[2];

                                                                xpoint2dt = Convert.ToInt32((size[0] - zt) + xt);
                                                                ypoint2dt = Convert.ToInt32(((size[0] - yt) + zt + xt) / (decimal)1.5);

                                                                // Erasing or replacing point

                                                                int[] bit_lay = new int[0];
                                                                string[] h_bit = new string[0];

                                                                if (bitmap_layers[xpoint2dt, ypoint2dt] != null)
                                                                {
                                                                    bit_lay = new int[bitmap_layers[xpoint2dt, ypoint2dt].Split(" ").Length];
                                                                    h_bit = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");
                                                                }

                                                                for (int jj = 0; jj < bit_lay.Length; jj++)
                                                                {
                                                                    bit_lay[jj] = Convert.ToInt32(h_bit[jj]);
                                                                }

                                                                if (bit_lay.Length > 1)
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = "";

                                                                    for (int jj = 0; jj < h_bit.Length; jj++)
                                                                    {
                                                                        
                                                                        if (bit_lay[jj] != i)
                                                                        {
                                                                            if (bitmap_layers[xpoint2dt, ypoint2dt] != "")
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = bitmap_layers[xpoint2dt, ypoint2dt] + " " + h_bit[jj];
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2dt, ypoint2dt] = h_bit[jj];
                                                                            }
                                                                        }
                                                                    }

                                                                    string[] new_color_on_point = bitmap_layers[xpoint2dt, ypoint2dt].Split(" ");

                                                                    string[] n_coords = positions[Convert.ToInt32(new_color_on_point[0])].Split(" ");

                                                                    string[] c = colors[i].Split(" ");

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.FromArgb(Convert.ToInt32(c[0]), Convert.ToInt32(c[1]), Convert.ToInt32(c[2])));
                                                                }

                                                                else
                                                                {
                                                                    bitmap_layers[xpoint2dt, ypoint2dt] = null;

                                                                    bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                }

                                                                //bmp.SetPixel(xpoint2dt, ypoint2dt, Color.Transparent);
                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), Convert.ToInt32(coords[2])] = "";

                                                                //set new point
                                                                int xpoint2d = 0;
                                                                int ypoint2d = 0;

                                                                decimal x = coords[0];
                                                                decimal y = coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed);
                                                                decimal z = coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed);

                                                                xpoint2d = Convert.ToInt32((size[0] - z) + x);
                                                                ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

                                                                // Adding and maybe setting new point
                                                                string[] ids = new string[0];

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null)
                                                                {
                                                                    ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                                                                }

                                                                bool tempset = false;

                                                                for (int jj = 0; jj < ids.Length; jj++)
                                                                {
                                                                    string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                                                                    if (Convert.ToInt32(p[1]) < Convert.ToInt32(coords[1]))
                                                                    {
                                                                        bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                        if (jj == 0)
                                                                        {
                                                                            bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                        }

                                                                        int temp_ = 1;

                                                                        for (int k = 1; k < ids.Length; k++)
                                                                        {
                                                                            if (k != jj)
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                temp_++;
                                                                            }

                                                                            else
                                                                            {
                                                                                bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                            }
                                                                        }

                                                                        tempset = true;
                                                                        break;
                                                                    }

                                                                    if (Convert.ToInt32(p[1]) == Convert.ToInt32(coords[1]))
                                                                    {
                                                                        if (Convert.ToInt32(p[0]) < Convert.ToInt32(coords[0]))
                                                                        {
                                                                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                                                            if (jj == 0)
                                                                            {
                                                                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                            }

                                                                            int temp_ = 1;

                                                                            for (int k = 1; k < ids.Length; k++)
                                                                            {
                                                                                if (k != jj)
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                                                                    temp_++;
                                                                                }

                                                                                else
                                                                                {
                                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                                }
                                                                            }

                                                                            tempset = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + i.ToString();
                                                                }

                                                                if (bitmap_layers[xpoint2d, ypoint2d] == null)
                                                                {
                                                                    bitmap_layers[xpoint2d, ypoint2d] = i.ToString();
                                                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                                                }

                                                                //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                                                                space3D[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1] + seconddimensionspeed / Math.Abs(seconddimensionspeed)), Convert.ToInt32(coords[2] + thirddimensionspeed / Math.Abs(thirddimensionspeed))] = i.ToString();
                                                            }
                                                        }
                                                    }


                                                }




                                            }
                                        }
                                    }

                                    howmuchtime.Stop();
                                    howmuchtime.Reset();

                                    pictureBox1.Image = bmp;
                                }
                            }
                        }
                    }
                }
            }

            int qdy = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textBox8.Text); i++)
            {
                Random r1 = new Random();
                Random r2 = new Random();
                Random ran3 = new Random();
                Random ran4 = new Random();
                Random ran6 = new Random();
                Random r5 = new Random();

                //int r3 = ran3.Next(0, size[0]);
                //int r4 = ran4.Next(0, size[1]);

                string a = textBox10.Text;

                string[] tb10 = textBox10.Text.Split();
                string[] tb11 = textBox11.Text.Split();
                string[] tb4 = textBox4.Text.Split();

                int r3 = ran3.Next(Convert.ToInt32(tb10[0]), Convert.ToInt32(tb10[1]) + 1); // x
                int r4 = ran4.Next(Convert.ToInt32(tb11[0]), Convert.ToInt32(tb11[1]) + 1); // y
                int r6 = ran6.Next(Convert.ToInt32(tb4[0]), Convert.ToInt32(tb4[1]) + 1); // z

                if (space3D[Convert.ToInt32(Math.Round(Convert.ToDecimal(r3))), Convert.ToInt32(Math.Round(Convert.ToDecimal(r4))), Convert.ToInt32(Math.Round(Convert.ToDecimal(r6)))] == "" || space3D[Convert.ToInt32(Math.Round(Convert.ToDecimal(r3))), Convert.ToInt32(Math.Round(Convert.ToDecimal(r4))), Convert.ToInt32(Math.Round(Convert.ToDecimal(r6)))] == null)
                {
                    Array.Resize(ref positions, positions.Length + 1);
                    Array.Resize(ref velocity, velocity.Length + 1);
                    Array.Resize(ref startime, startime.Length + 1);
                    Array.Resize(ref colors, colors.Length + 1);

                    Array.Resize(ref atomic_number, atomic_number.Length + 1);
                    Array.Resize(ref neutron_number, neutron_number.Length + 1);
                    Array.Resize(ref electron_number, electron_number.Length + 1);

                    string[] t1 = textBox7.Text.Split(" ");
                    int a1 = r1.Next(Convert.ToInt32(t1[0]), Convert.ToInt32(t1[1]));

                    string[] t2 = textBox14.Text.Split(" ");
                    int n1 = r1.Next(Convert.ToInt32(t2[0]), Convert.ToInt32(t2[1]));

                    string[] t3 = textBox6.Text.Split(" ");
                    int e1 = r1.Next(Convert.ToInt32(t3[0]), Convert.ToInt32(t3[1]));

                    if (n1 == -1)
                    {
                        n1 = a1;
                    }

                    if (e1 == -1)
                    {
                        n1 = a1;
                    }

                    atomic_number[atomic_number.Length - 1] = a1;
                    neutron_number[neutron_number.Length - 1] = n1;
                    electron_number[electron_number.Length - 1] = e1;

                    positions[positions.Length - 1] = r3.ToString() + " " + r4.ToString() + " " + r6.ToString();

                    string[] tb12 = textBox12.Text.Split();
                    string[] tb13 = textBox13.Text.Split();
                    string[] tb5 = textBox5.Text.Split();

                    velocity[positions.Length - 1] = r1.Next(Convert.ToInt32(tb12[0]), Convert.ToInt32(tb12[1]) + 1).ToString() + " " + r2.Next(Convert.ToInt32(tb13[0]), Convert.ToInt32(tb13[1]) + 1).ToString() + " " + r2.Next(Convert.ToInt32(tb5[0]), Convert.ToInt32(tb5[1]) + 1).ToString();

                    startime[positions.Length - 1] = Convert.ToDecimal(r5.Next(0, 999)) * 10000;

                    string[] color = textBox2.Text.Split();

                    int xpoint2d = 0;
                    int ypoint2d = 0;

                    xpoint2d = (size[0] - r6) + r3;
                    ypoint2d = Convert.ToInt32(((size[0] - r4) + r6 + r3) / 1.5);

                    string[] ids = new string[0];
                    if (bitmap_layers[xpoint2d, ypoint2d] != null)
                    {
                        ids = bitmap_layers[xpoint2d, ypoint2d].Split(" ");
                    }

                    bool tempset = false;

                    for (int jj = 0; jj < ids.Length; jj++)
                    {
                        string[] p = positions[Convert.ToInt32(ids[jj])].Split(" ");

                        if (Convert.ToInt32(p[1]) < Convert.ToInt32(tb10[1]))
                        {
                            bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                            if (jj == 0)
                            {
                                bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                            }

                            int temp = 1;

                            for (int k = 1; k < ids.Length; k++)
                            {
                                if (k != jj)
                                {
                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp];
                                    temp++;
                                }

                                else
                                {
                                    bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + (positions.Length - 1).ToString();
                                }
                            }

                            tempset = true;
                            break;
                        }

                        if (Convert.ToInt32(p[1]) == Convert.ToInt32(tb10[1]))
                        {
                            if (Convert.ToInt32(p[0]) < Convert.ToInt32(tb10[0]))
                            {
                                bitmap_layers[xpoint2d, ypoint2d] = ids[0];

                                if (jj == 0)
                                {
                                    bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                                }

                                int temp_ = 1;

                                for (int k = 1; k < ids.Length; k++)
                                {
                                    if (k != jj)
                                    {
                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + ids[temp_];
                                        temp_++;
                                    }

                                    else
                                    {
                                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + (positions.Length - 1).ToString();
                                    }
                                }

                                tempset = true;
                                break;
                            }
                        }
                    }

                    if (bitmap_layers[xpoint2d, ypoint2d] != null && tempset == false)
                    {
                        bitmap_layers[xpoint2d, ypoint2d] = bitmap_layers[xpoint2d, ypoint2d] + " " + (positions.Length - 1).ToString();
                    }

                    if (bitmap_layers[xpoint2d, ypoint2d] == null)
                    {
                        bitmap_layers[xpoint2d, ypoint2d] = (positions.Length - 1).ToString();
                        bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));
                    }

                    //bmp.SetPixel(xpoint2d, ypoint2d, Color.FromArgb(Convert.ToInt32(color[0]), Convert.ToInt32(color[1]), Convert.ToInt32(color[2])));

                    space3D[Convert.ToInt32(Math.Round(Convert.ToDecimal(r3))), Convert.ToInt32(Math.Round(Convert.ToDecimal(r4))), Convert.ToInt32(Math.Round(Convert.ToDecimal(r6)))] = (positions.Length - 1).ToString();

                    colors[colors.Length - 1] = color[0] + " " + color[1] + " " + color[2];
                }

                else
                {
                    i--;
                }
            }

            shi = true;

            reality_one_point_travel_Click(sender, e);

            shi = false;
        }

        bool shi = false;

        private void set_size_Click(object sender, EventArgs e)
        {
            string[] b = textBox9.Text.Split();

            size = new int[3] { Convert.ToInt32(b[0]), Convert.ToInt32(b[1]), Convert.ToInt32(b[2]) };
            space3D = new string[Convert.ToInt32(b[0]), Convert.ToInt32(b[1]), Convert.ToInt32(b[2])];

            int xpoint = Convert.ToInt32((size[0] - 0) + size[0]);
            int ypoint = Convert.ToInt32(((size[0] - 0) + size[2] + size[0]) / (decimal)1.5);

            bmp = new Bitmap(xpoint, ypoint);
            bitmap_layers = new string[xpoint, ypoint];
            graph = new Bitmap(xpoint, ypoint);

            form2.Width = xpoint;
            form2.Height = ypoint;

            positions = new string[0];
            velocity = new string[0];
            startime = new decimal[0];

            atomic_number = new int[0];
            neutron_number = new int[0];
            electron_number = new int[0];

            colors = new string[0];
            firstime_for_reality_travel = true;

            DL dL = new DL();

            decimal[] d1 = new decimal[2] { xpoint / 2 - 1, ypoint / 2 / (decimal)1.5 }; // center
            decimal[] d2 = new decimal[2] { xpoint / 2 - 1, 0 };

            dL.DrawLine(graph, d1, d2, Color.LimeGreen);

            d1 = new decimal[2] { xpoint - 1, ypoint / (decimal)1.5 };
            d2 = new decimal[2] { xpoint / 2 - 1, ypoint / 2 / (decimal)1.5 }; // center

            dL.DrawLine(graph, d1, d2, Color.Yellow);

            d1 = new decimal[2] { xpoint / 2 - 1, ypoint / 2 / (decimal)1.5 }; // center
            d2 = new decimal[2] { 0, ypoint / (decimal)1.5 };

            //xpoint2d = Convert.ToInt32((size[0] - z) + x);
            //ypoint2d = Convert.ToInt32(Math.Round(((size[0] - y) + z + x) / (decimal)1.5));

            dL.DrawLine(graph, d1, d2, Color.Red);

            pictureBox2.Image = graph;
            pictureBox1.BackgroundImage = pictureBox2.Image;
            pictureBox1.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    for (int j = 0; j < 100; j++)
            //    {
            //        bmp.SetPixel(i, j, Color.LimeGreen);
            //    }
            //}

            ////bmp = (Bitmap)Image.FromFile(@"C:\Users\james\OneDrive\Desktop\Pictures\all 16.7 million pixels.bmp");

            //newbmp45degree = new Bitmap(bmp.Width * 2 - 1, bmp.Height * 2 - 1);

            //pictureBox1.Image = bmp;

            int xpoint = Convert.ToInt32((size[0] - 0) + size[0]);
            int ypoint = Convert.ToInt32(((size[0] - 0) + size[2] + size[0]) / (decimal)1.5);

            DL dL = new DL();

            decimal[] d1 = new decimal[2] { xpoint / 2 - 1, ypoint / 2 / (decimal)1.5 }; // center
            decimal[] d2 = new decimal[2] { xpoint / 2 - 1, 0 };

            dL.DrawLine(graph, d1, d2, Color.LimeGreen);

            d1 = new decimal[2] { xpoint - 1, ypoint / (decimal)1.5 };
            d2 = new decimal[2] { xpoint / 2 - 1, ypoint / 2 / (decimal)1.5 }; // center

            dL.DrawLine(graph, d1, d2, Color.Yellow);

            d1 = new decimal[2] { xpoint / 2 - 1, ypoint / 2 / (decimal)1.5 }; // center
            d2 = new decimal[2] { 0, ypoint / (decimal)1.5 };

            dL.DrawLine(graph, d1, d2, Color.Red);

            pictureBox2.Image = graph;
            pictureBox1.BackgroundImage = pictureBox2.Image;
        }

        static Form form2 = new Form();
    }
}