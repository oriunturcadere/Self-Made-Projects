using System;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Windows.Forms;

namespace mendalian_genetics_simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            textBox3.Visible = false;
            label120.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            checkBox29.Checked = true;

            checkBox29.Text = "English";
            checkBox30.Text = "Русский";

            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label21.Text = "";
            label22.Text = "";
            label23.Text = "";
            label24.Text = "";
            label25.Text = "";
            label26.Text = "";
            label27.Text = "";

            pictureBox111.Visible = false;
            pictureBox112.Visible = false;
            pictureBox121.Visible = false;
            pictureBox122.Visible = false;
            pictureBox131.Visible = false;
            pictureBox132.Visible = false;
            pictureBox141.Visible = false;
            pictureBox142.Visible = false;
            pictureBox151.Visible = false;
            pictureBox152.Visible = false;
            pictureBox161.Visible = false;
            pictureBox162.Visible = false;
            pictureBox171.Visible = false;
            pictureBox172.Visible = false;
            pictureBox211.Visible = false;
            pictureBox212.Visible = false;
            pictureBox221.Visible = false;
            pictureBox222.Visible = false;
            pictureBox231.Visible = false;
            pictureBox232.Visible = false;
            pictureBox241.Visible = false;
            pictureBox242.Visible = false;
            pictureBox251.Visible = false;
            pictureBox252.Visible = false;
            pictureBox261.Visible = false;
            pictureBox262.Visible = false;
            pictureBox271.Visible = false;
            pictureBox272.Visible = false;
        }

        static int[] mem11 = new int[4];
        static int[] mem12 = new int[4];
        static int[] mem13 = new int[4];
        static int[] mem14 = new int[4];
        static int[] mem15 = new int[4];
        static int[] mem16 = new int[4];
        static int[] mem17 = new int[4];
        static int[] mem21 = new int[4];
        static int[] mem22 = new int[4];
        static int[] mem23 = new int[4];
        static int[] mem24 = new int[4];
        static int[] mem25 = new int[4];
        static int[] mem26 = new int[4];
        static int[] mem27 = new int[4];

        static string[] g11 = new string[2];
        static string[] g12 = new string[2];
        static string[] g13 = new string[2];
        static string[] g14 = new string[2];
        static string[] g15 = new string[2];
        static string[] g16 = new string[2];
        static string[] g17 = new string[2];
        static string[] g21 = new string[2];
        static string[] g22 = new string[2];
        static string[] g23 = new string[2];
        static string[] g24 = new string[2];
        static string[] g25 = new string[2];
        static string[] g26 = new string[2];
        static string[] g27 = new string[2];

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox111.Checked == true && checkBox112.Checked == false && checkBox113.Checked == false && checkBox114.Checked == false)
            {
                mem11[0] = 1;
            }

            if (checkBox111.Checked == false && checkBox112.Checked == false && checkBox113.Checked == false && checkBox114.Checked == false)
            {
                mem11[0] = 0;
            }

            int o = 0;  // the number of cells that do not equall to 0

            int p = 0;  // the number of the cell that is not 0 in an array 

            for (int i = 0; i < mem11.Length; i++) // the loop for finding the number of cells not 0
            {
                if (mem11[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox111.Checked == true)
            {
                if (o == 1) // means that checkbox111 is the only one checked by the user
                {
                    if (p != 0)
                    {
                        mem11[0] = 2; // this is the second checked checkbox
                    }

                    else
                    {
                        mem11[0] = 1; // this is the first checked checkbox
                    }
                }

                if (o == 2) // there are 2 checked
                {
                    for (int i = 1; i < mem11.Length; i++) // the loop for finding the second checkbox and unchecking it
                    {
                        if (mem11[i] == 2)
                        {
                            mem11[i] = 0;

                            if (i == 1)
                            {
                                checkBox112.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox113.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox114.Checked = false;
                                break;
                            }
                        }
                    }

                    mem11[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem11[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem11.Length; i++)
                    {
                        if (mem11[i] == 1)
                        {
                            mem11[i] = 1;
                            break;
                        }
                    }

                    mem11[0] = 0;
                }
            }

            g11[0] = "";
            g11[1] = "";

            if (checkBox111.Checked == true)
            {
                g11[0] = checkBox111.Text;
            }

            if (checkBox112.Checked == true)
            {
                g11[1] = checkBox112.Text;
            }

            if (checkBox113.Checked == true)
            {
                if ((g11[0] == "" && g11[1] == "") == false)
                {
                    if (g11[0] == "")
                    {
                        g11[0] = checkBox113.Text;
                    }

                    if (g11[1] == "")
                    {
                        g11[1] = checkBox113.Text;
                    }
                }

                else
                {
                    g11[0] = checkBox113.Text;
                }
            }

            if (checkBox114.Checked == true)
            {
                if ((g11[0] == "" && g11[1] == "") == false)
                {
                    if (g11[0] == "")
                    {
                        g11[0] = checkBox114.Text;
                    }

                    if (g11[1] == "")
                    {
                        g11[1] = checkBox114.Text;
                    }
                }

                else
                {
                    g11[1] = checkBox114.Text;
                }
            }

            label11.Text = String.Join("", g11);

            pictureBox111.Visible = false;
            pictureBox112.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g11[i] == "" | false | g11[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
                pictureBox111.Visible = false;
            }

            else
            {
                if (g11[0] == g11[1])
                {
                    if (g11[0] == "R")
                    {
                        pictureBox111.Visible = true;
                    }

                    else
                    {
                        pictureBox112.Visible = true;
                    }
                }

                else
                {
                    pictureBox111.Visible = true;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox111.Checked == false && checkBox112.Checked == true && checkBox113.Checked == false && checkBox114.Checked == false)
            {
                mem11[1] = 1;
            }

            if (checkBox111.Checked == false && checkBox112.Checked == false && checkBox113.Checked == false && checkBox114.Checked == false)
            {
                mem11[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem11.Length; i++)
            {
                if (mem11[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox112.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem11[1] = 2;
                    }

                    else
                    {
                        mem11[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem11.Length; i++)
                    {
                        if (mem11[i] == 2)
                        {
                            mem11[i] = 0;

                            if (i == 0)
                            {
                                checkBox111.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox113.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox114.Checked = false;
                                break;
                            }
                        }
                    }

                    mem11[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem11[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem11.Length; i++)
                    {
                        if (mem11[i] == 1)
                        {
                            mem11[i] = 1;
                            break;
                        }
                    }

                    mem11[1] = 0;
                }
            }

            g11[0] = "";
            g11[1] = "";

            if (checkBox111.Checked == true)
            {
                g11[0] = checkBox111.Text;
            }

            if (checkBox112.Checked == true)
            {
                g11[1] = checkBox112.Text;
            }

            if (checkBox113.Checked == true)
            {
                if ((g11[0] == "" && g11[1] == "") == false)
                {
                    if (g11[0] == "")
                    {
                        g11[0] = checkBox113.Text;
                    }

                    if (g11[1] == "")
                    {
                        g11[1] = checkBox113.Text;
                    }
                }

                else
                {
                    g11[0] = checkBox113.Text;
                }
            }

            if (checkBox114.Checked == true)
            {
                if ((g11[0] == "" && g11[1] == "") == false)
                {
                    if (g11[0] == "")
                    {
                        g11[0] = checkBox114.Text;
                    }

                    if (g11[1] == "")
                    {
                        g11[1] = checkBox114.Text;
                    }
                }

                else
                {
                    g11[1] = checkBox114.Text;
                }
            }

            label11.Text = String.Join("", g11);

            pictureBox111.Visible = false;
            pictureBox112.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g11[i] == "" | false | g11[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
                pictureBox111.Visible = false;
            }

            else
            {
                if (g11[0] == g11[1])
                {
                    if (g11[0] == "R")
                    {
                        pictureBox111.Visible = true;
                    }

                    else
                    {
                        pictureBox112.Visible = true;
                    }
                }

                else
                {
                    pictureBox111.Visible = true;
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox121.Checked == true && checkBox122.Checked == false && checkBox123.Checked == false && checkBox124.Checked == false)
            {
                mem12[0] = 1;
            }

            if (checkBox121.Checked == false && checkBox122.Checked == false && checkBox123.Checked == false && checkBox124.Checked == false)
            {
                mem12[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem12.Length; i++)
            {
                if (mem12[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox121.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem12[0] = 2;
                    }

                    else
                    {
                        mem12[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem12.Length; i++)
                    {
                        if (mem12[i] == 2)
                        {
                            mem12[i] = 0;

                            if (i == 1)
                            {
                                checkBox122.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox123.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox124.Checked = false;
                                break;
                            }
                        }
                    }

                    mem12[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem12[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem12.Length; i++)
                    {
                        if (mem12[i] == 1)
                        {
                            mem12[i] = 1;
                            break;
                        }
                    }

                    mem12[0] = 0;
                }
            }

            g12[0] = "";
            g12[1] = "";

            if (checkBox121.Checked == true)
            {
                g12[0] = checkBox121.Text;
            }

            if (checkBox122.Checked == true)
            {
                g12[1] = checkBox122.Text;
            }

            if (checkBox123.Checked == true)
            {
                if ((g12[0] == "" && g12[1] == "") == false)
                {
                    if (g12[0] == "")
                    {
                        g12[0] = checkBox123.Text;
                    }

                    if (g12[1] == "")
                    {
                        g12[1] = checkBox123.Text;
                    }
                }

                else
                {
                    g12[0] = checkBox123.Text;
                }
            }

            if (checkBox124.Checked == true)
            {
                if ((g12[0] == "" && g12[1] == "") == false)
                {
                    if (g12[0] == "")
                    {
                        g12[0] = checkBox124.Text;
                    }

                    if (g12[1] == "")
                    {
                        g12[1] = checkBox124.Text;
                    }
                }

                else
                {
                    g12[1] = checkBox124.Text;
                }
            }

            label12.Text = String.Join("", g12);

            pictureBox121.Visible = false;
            pictureBox122.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g12[i] == "" | false | g12[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g12[0] == g12[1])
                {
                    if (g12[0] == "Y")
                    {
                        pictureBox121.Visible = true;
                    }

                    else
                    {
                        pictureBox122.Visible = true;
                    }
                }

                else
                {
                    pictureBox121.Visible = true;
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox121.Checked == false && checkBox122.Checked == true && checkBox123.Checked == false && checkBox124.Checked == false)
            {
                mem12[1] = 1;
            }

            if (checkBox121.Checked == false && checkBox122.Checked == false && checkBox123.Checked == false && checkBox124.Checked == false)
            {
                mem12[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem12.Length; i++)
            {
                if (mem12[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox122.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem12[1] = 2;
                    }

                    else
                    {
                        mem12[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem12.Length; i++)
                    {
                        if (mem12[i] == 2)
                        {
                            mem12[i] = 0;

                            if (i == 0)
                            {
                                checkBox121.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox123.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox124.Checked = false;
                                break;
                            }
                        }
                    }

                    mem12[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem12[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem12.Length; i++)
                    {
                        if (mem12[i] == 1)
                        {
                            mem12[i] = 1;
                            break;
                        }
                    }

                    mem12[1] = 0;
                }
            }

            g12[0] = "";
            g12[1] = "";

            if (checkBox121.Checked == true)
            {
                g12[0] = checkBox121.Text;
            }

            if (checkBox122.Checked == true)
            {
                g12[1] = checkBox122.Text;
            }

            if (checkBox123.Checked == true)
            {
                if ((g12[0] == "" && g12[1] == "") == false)
                {
                    if (g12[0] == "")
                    {
                        g12[0] = checkBox123.Text;
                    }

                    if (g12[1] == "")
                    {
                        g12[1] = checkBox123.Text;
                    }
                }

                else
                {
                    g12[0] = checkBox123.Text;
                }
            }

            if (checkBox124.Checked == true)
            {
                if ((g12[0] == "" && g12[1] == "") == false)
                {
                    if (g12[0] == "")
                    {
                        g12[0] = checkBox124.Text;
                    }

                    if (g12[1] == "")
                    {
                        g12[1] = checkBox124.Text;
                    }
                }
            }

            label12.Text = String.Join("", g12);

            pictureBox121.Visible = false;
            pictureBox122.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g12[i] == "" | false | g12[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g12[0] == g12[1])
                {
                    if (g12[0] == "Y")
                    {
                        pictureBox121.Visible = true;
                    }

                    else
                    {
                        pictureBox122.Visible = true;
                    }
                }

                else
                {
                    pictureBox121.Visible = true;
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox131.Checked == true && checkBox132.Checked == false && checkBox133.Checked == false && checkBox134.Checked == false)
            {
                mem13[0] = 1;
            }

            if (checkBox131.Checked == false && checkBox132.Checked == false && checkBox133.Checked == false && checkBox134.Checked == false)
            {
                mem13[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem13.Length; i++)
            {
                if (mem13[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox131.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem13[0] = 2;
                    }

                    else
                    {
                        mem13[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem13.Length; i++)
                    {
                        if (mem13[i] == 2)
                        {
                            mem13[i] = 0;

                            if (i == 1)
                            {
                                checkBox132.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox133.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox134.Checked = false;
                                break;
                            }
                        }
                    }

                    mem13[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem13[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem13.Length; i++)
                    {
                        if (mem13[i] == 1)
                        {
                            mem13[i] = 1;
                            break;
                        }
                    }

                    mem13[0] = 0;
                }
            }

            g13[0] = "";
            g13[1] = "";

            if (checkBox131.Checked == true)
            {
                g13[0] = checkBox131.Text;
            }

            if (checkBox132.Checked == true)
            {
                g13[1] = checkBox132.Text;
            }

            if (checkBox133.Checked == true)
            {
                if ((g13[0] == "" && g13[1] == "") == false)
                {
                    if (g13[0] == "")
                    {
                        g13[0] = checkBox133.Text;
                    }

                    if (g13[1] == "")
                    {
                        g13[1] = checkBox133.Text;
                    }
                }

                else
                {
                    g13[0] = checkBox133.Text;
                }
            }

            if (checkBox134.Checked == true)
            {
                if ((g13[0] == "" && g13[1] == "") == false)
                {
                    if (g13[0] == "")
                    {
                        g13[0] = checkBox134.Text;
                    }

                    if (g13[1] == "")
                    {
                        g13[1] = checkBox134.Text;
                    }
                }

                else
                {
                    g13[1] = checkBox134.Text;
                }
            }

            label13.Text = String.Join("", g13);

            pictureBox131.Visible = false;
            pictureBox132.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g13[i] == "" | false | g13[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g13[0] == g13[1])
                {
                    if (g13[0] == "G")
                    {
                        pictureBox131.Visible = true;
                    }

                    else
                    {
                        pictureBox132.Visible = true;
                    }
                }

                else
                {
                    pictureBox131.Visible = true;
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox131.Checked == false && checkBox132.Checked == true && checkBox133.Checked == false && checkBox134.Checked == false)
            {
                mem13[1] = 1;
            }

            if (checkBox131.Checked == false && checkBox132.Checked == false && checkBox133.Checked == false && checkBox134.Checked == false)
            {
                mem13[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem13.Length; i++)
            {
                if (mem13[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox132.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem13[1] = 2;
                    }

                    else
                    {
                        mem13[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem13.Length; i++)
                    {
                        if (mem13[i] == 2)
                        {
                            mem13[i] = 0;

                            if (i == 0)
                            {
                                checkBox131.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox133.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox134.Checked = false;
                                break;
                            }
                        }
                    }

                    mem13[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem13[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem13.Length; i++)
                    {
                        if (mem13[i] == 1)
                        {
                            mem13[i] = 1;
                            break;
                        }
                    }

                    mem13[1] = 0;
                }
            }

            g13[0] = "";
            g13[1] = "";

            if (checkBox131.Checked == true)
            {
                g13[0] = checkBox131.Text;
            }

            if (checkBox132.Checked == true)
            {
                g13[1] = checkBox132.Text;
            }

            if (checkBox133.Checked == true)
            {
                if ((g13[0] == "" && g13[1] == "") == false)
                {
                    if (g13[0] == "")
                    {
                        g13[0] = checkBox133.Text;
                    }

                    if (g13[1] == "")
                    {
                        g13[1] = checkBox133.Text;
                    }
                }

                else
                {
                    g13[0] = checkBox133.Text;
                }
            }

            if (checkBox134.Checked == true)
            {
                if ((g13[0] == "" && g13[1] == "") == false)
                {
                    if (g13[0] == "")
                    {
                        g13[0] = checkBox134.Text;
                    }

                    if (g13[1] == "")
                    {
                        g13[1] = checkBox134.Text;
                    }
                }

                else
                {
                    g13[1] = checkBox134.Text;
                }
            }

            label13.Text = String.Join("", g13);

            pictureBox131.Visible = false;
            pictureBox132.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g13[i] == "" | false | g13[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g13[0] == g13[1])
                {
                    if (g13[0] == "G")
                    {
                        pictureBox131.Visible = true;
                    }

                    else
                    {
                        pictureBox132.Visible = true;
                    }
                }

                else
                {
                    pictureBox131.Visible = true;
                }
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox141.Checked == true && checkBox142.Checked == false && checkBox143.Checked == false && checkBox144.Checked == false)
            {
                mem14[0] = 1;
            }

            if (checkBox141.Checked == false && checkBox142.Checked == false && checkBox143.Checked == false && checkBox144.Checked == false)
            {
                mem14[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem14.Length; i++)
            {
                if (mem14[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox141.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem14[0] = 2;
                    }

                    else
                    {
                        mem14[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem14.Length; i++)
                    {
                        if (mem14[i] == 2)
                        {
                            mem14[i] = 0;

                            if (i == 1)
                            {
                                checkBox142.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox143.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox144.Checked = false;
                                break;
                            }
                        }
                    }

                    mem14[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem14[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem14.Length; i++)
                    {
                        if (mem14[i] == 1)
                        {
                            mem14[i] = 1;
                            break;
                        }
                    }

                    mem14[0] = 0;
                }
            }

            g14[0] = "";
            g14[1] = "";

            if (checkBox141.Checked == true)
            {
                g14[0] = checkBox141.Text;
            }

            if (checkBox142.Checked == true)
            {
                g14[1] = checkBox142.Text;
            }

            if (checkBox143.Checked == true)
            {
                if ((g14[0] == "" && g14[1] == "") == false)
                {
                    if (g14[0] == "")
                    {
                        g14[0] = checkBox143.Text;
                    }

                    if (g14[1] == "")
                    {
                        g14[1] = checkBox143.Text;
                    }
                }

                else
                {
                    g14[0] = checkBox143.Text;
                }
            }

            if (checkBox144.Checked == true)
            {
                if ((g14[0] == "" && g14[1] == "") == false)
                {
                    if (g14[0] == "")
                    {
                        g14[0] = checkBox144.Text;
                    }

                    if (g14[1] == "")
                    {
                        g14[1] = checkBox144.Text;
                    }
                }

                else
                {
                    g14[1] = checkBox144.Text;
                }
            }

            label14.Text = String.Join("", g14);

            pictureBox141.Visible = false;
            pictureBox142.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g14[i] == "" | false | g14[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g14[0] == g14[1])
                {
                    if (g14[0] == "C")
                    {
                        pictureBox141.Visible = true;
                    }

                    else
                    {
                        pictureBox142.Visible = true;
                    }
                }

                else
                {
                    pictureBox141.Visible = true;
                }
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox141.Checked == false && checkBox142.Checked == true && checkBox143.Checked == false && checkBox144.Checked == false)
            {
                mem14[1] = 1;
            }

            if (checkBox141.Checked == false && checkBox142.Checked == false && checkBox143.Checked == false && checkBox144.Checked == false)
            {
                mem14[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem14.Length; i++)
            {
                if (mem14[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox142.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem14[1] = 2;
                    }

                    else
                    {
                        mem14[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem14.Length; i++)
                    {
                        if (mem14[i] == 2)
                        {
                            mem14[i] = 0;

                            if (i == 0)
                            {
                                checkBox141.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox143.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox144.Checked = false;
                                break;
                            }
                        }
                    }

                    mem14[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem14[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem14.Length; i++)
                    {
                        if (mem14[i] == 1)
                        {
                            mem14[i] = 1;
                            break;
                        }
                    }

                    mem14[1] = 0;
                }
            }

            g14[0] = "";
            g14[1] = "";

            if (checkBox141.Checked == true)
            {
                g14[0] = checkBox141.Text;
            }

            if (checkBox142.Checked == true)
            {
                g14[1] = checkBox142.Text;
            }

            if (checkBox143.Checked == true)
            {
                if ((g14[0] == "" && g14[1] == "") == false)
                {
                    if (g14[0] == "")
                    {
                        g14[0] = checkBox143.Text;
                    }

                    if (g14[1] == "")
                    {
                        g14[1] = checkBox143.Text;
                    }
                }

                else
                {
                    g14[0] = checkBox143.Text;
                }
            }

            if (checkBox144.Checked == true)
            {
                if ((g14[0] == "" && g14[1] == "") == false)
                {
                    if (g14[0] == "")
                    {
                        g14[0] = checkBox144.Text;
                    }

                    if (g14[1] == "")
                    {
                        g14[1] = checkBox144.Text;
                    }
                }

                else
                {
                    g14[1] = checkBox144.Text;
                }
            }

            label14.Text = String.Join("", g14);

            pictureBox141.Visible = false;
            pictureBox142.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g14[i] == "" | false | g14[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g14[0] == g14[1])
                {
                    if (g14[0] == "C")
                    {
                        pictureBox141.Visible = true;
                    }

                    else
                    {
                        pictureBox142.Visible = true;
                    }
                }

                else
                {
                    pictureBox141.Visible = true;
                }
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox151.Checked == true && checkBox152.Checked == false && checkBox153.Checked == false && checkBox154.Checked == false)
            {
                mem15[0] = 1;
            }

            if (checkBox151.Checked == false && checkBox152.Checked == false && checkBox153.Checked == false && checkBox154.Checked == false)
            {
                mem15[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem15.Length; i++)
            {
                if (mem15[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox151.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem15[0] = 2;
                    }

                    else
                    {
                        mem15[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem15.Length; i++)
                    {
                        if (mem15[i] == 2)
                        {
                            mem15[i] = 0;

                            if (i == 1)
                            {
                                checkBox152.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox153.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox154.Checked = false;
                                break;
                            }
                        }
                    }

                    mem15[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem15[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem15.Length; i++)
                    {
                        if (mem15[i] == 1)
                        {
                            mem15[i] = 1;
                            break;
                        }
                    }

                    mem15[0] = 0;
                }
            }

            g15[0] = "";
            g15[1] = "";

            if (checkBox151.Checked == true)
            {
                g15[0] = checkBox151.Text;
            }

            if (checkBox152.Checked == true)
            {
                g15[1] = checkBox152.Text;
            }

            if (checkBox153.Checked == true)
            {
                if ((g15[0] == "" && g15[1] == "") == false)
                {
                    if (g15[0] == "")
                    {
                        g15[0] = checkBox153.Text;
                    }

                    if (g15[1] == "")
                    {
                        g15[1] = checkBox153.Text;
                    }
                }

                else
                {
                    g15[0] = checkBox153.Text;
                }
            }

            if (checkBox154.Checked == true)
            {
                if ((g15[0] == "" && g15[1] == "") == false)
                {
                    if (g15[0] == "")
                    {
                        g15[0] = checkBox154.Text;
                    }

                    if (g15[1] == "")
                    {
                        g15[1] = checkBox154.Text;
                    }
                }

                else
                {
                    g15[1] = checkBox154.Text;
                }
            }

            label15.Text = String.Join("", g15);

            pictureBox151.Visible = false;
            pictureBox152.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g15[i] == "" | false | g15[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g15[0] == g15[1])
                {
                    if (g15[0] == "P")
                    {
                        pictureBox151.Visible = true;
                    }

                    else
                    {
                        pictureBox152.Visible = true;
                    }
                }

                else
                {
                    pictureBox151.Visible = true;
                }
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox151.Checked == false && checkBox152.Checked == true && checkBox153.Checked == false && checkBox154.Checked == false)
            {
                mem15[1] = 1;
            }

            if (checkBox151.Checked == false && checkBox152.Checked == false && checkBox153.Checked == false && checkBox154.Checked == false)
            {
                mem15[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem15.Length; i++)
            {
                if (mem15[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox152.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem15[1] = 2;
                    }

                    else
                    {
                        mem15[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem15.Length; i++)
                    {
                        if (mem15[i] == 2)
                        {
                            mem15[i] = 0;

                            if (i == 0)
                            {
                                checkBox151.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox153.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox154.Checked = false;
                                break;
                            }
                        }
                    }

                    mem15[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem15[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem15.Length; i++)
                    {
                        if (mem15[i] == 1)
                        {
                            mem15[i] = 1;
                            break;
                        }
                    }

                    mem15[1] = 0;
                }
            }

            g15[0] = "";
            g15[1] = "";

            if (checkBox151.Checked == true)
            {
                g15[0] = checkBox151.Text;
            }

            if (checkBox152.Checked == true)
            {
                g15[1] = checkBox152.Text;
            }

            if (checkBox153.Checked == true)
            {
                if ((g15[0] == "" && g15[1] == "") == false)
                {
                    if (g15[0] == "")
                    {
                        g15[0] = checkBox153.Text;
                    }

                    if (g15[1] == "")
                    {
                        g15[1] = checkBox153.Text;
                    }
                }

                else
                {
                    g15[0] = checkBox153.Text;
                }
            }

            if (checkBox154.Checked == true)
            {
                if ((g15[0] == "" && g15[1] == "") == false)
                {
                    if (g15[0] == "")
                    {
                        g15[0] = checkBox154.Text;
                    }

                    if (g15[1] == "")
                    {
                        g15[1] = checkBox154.Text;
                    }
                }

                else
                {
                    g15[1] = checkBox154.Text;
                }
            }

            label15.Text = String.Join("", g15);

            pictureBox151.Visible = false;
            pictureBox152.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g15[i] == "" | false | g15[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g15[0] == g15[1])
                {
                    if (g15[0] == "P")
                    {
                        pictureBox151.Visible = true;
                    }

                    else
                    {
                        pictureBox152.Visible = true;
                    }
                }

                else
                {
                    pictureBox151.Visible = true;
                }
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox161.Checked == true && checkBox162.Checked == false && checkBox163.Checked == false && checkBox164.Checked == false)
            {
                mem16[0] = 1;
            }

            if (checkBox161.Checked == false && checkBox162.Checked == false && checkBox163.Checked == false && checkBox164.Checked == false)
            {
                mem16[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem16.Length; i++)
            {
                if (mem16[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox161.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem16[0] = 2;
                    }

                    else
                    {
                        mem16[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem16.Length; i++)
                    {
                        if (mem16[i] == 2)
                        {
                            mem16[i] = 0;

                            if (i == 1)
                            {
                                checkBox162.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox163.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox164.Checked = false;
                                break;
                            }
                        }
                    }

                    mem16[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem16[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem16.Length; i++)
                    {
                        if (mem16[i] == 1)
                        {
                            mem16[i] = 1;
                            break;
                        }
                    }

                    mem16[0] = 0;
                }
            }

            g16[0] = "";
            g16[1] = "";

            if (checkBox161.Checked == true)
            {
                g16[0] = checkBox161.Text;
            }

            if (checkBox162.Checked == true)
            {
                g16[1] = checkBox162.Text;
            }

            if (checkBox163.Checked == true)
            {
                if ((g16[0] == "" && g16[1] == "") == false)
                {
                    if (g16[0] == "")
                    {
                        g16[0] = checkBox163.Text;
                    }

                    if (g16[1] == "")
                    {
                        g16[1] = checkBox163.Text;
                    }
                }

                else
                {
                    g16[0] = checkBox163.Text;
                }
            }

            if (checkBox164.Checked == true)
            {
                if ((g16[0] == "" && g16[1] == "") == false)
                {
                    if (g16[0] == "")
                    {
                        g16[0] = checkBox164.Text;
                    }

                    if (g16[1] == "")
                    {
                        g16[1] = checkBox164.Text;
                    }
                }

                else
                {
                    g16[1] = checkBox164.Text;
                }
            }

            label16.Text = String.Join("", g16);

            pictureBox161.Visible = false;
            pictureBox162.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g16[i] == "" | false | g16[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g16[0] == g16[1])
                {
                    if (g16[0] == "A")
                    {
                        pictureBox161.Visible = true;
                    }

                    else
                    {
                        pictureBox162.Visible = true;
                    }
                }

                else
                {
                    pictureBox161.Visible = true;
                }
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox161.Checked == false && checkBox162.Checked == true && checkBox163.Checked == false && checkBox164.Checked == false)
            {
                mem16[1] = 1;
            }

            if (checkBox161.Checked == false && checkBox162.Checked == false && checkBox163.Checked == false && checkBox164.Checked == false)
            {
                mem16[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem16.Length; i++)
            {
                if (mem16[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox162.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem16[1] = 2;
                    }

                    else
                    {
                        mem16[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem16.Length; i++)
                    {
                        if (mem16[i] == 2)
                        {
                            mem16[i] = 0;

                            if (i == 0)
                            {
                                checkBox161.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox163.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox164.Checked = false;
                                break;
                            }
                        }
                    }

                    mem16[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem16[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem16.Length; i++)
                    {
                        if (mem16[i] == 1)
                        {
                            mem16[i] = 1;
                            break;
                        }
                    }

                    mem16[1] = 0;
                }
            }

            g16[0] = "";
            g16[1] = "";

            if (checkBox161.Checked == true)
            {
                g16[0] = checkBox161.Text;
            }

            if (checkBox162.Checked == true)
            {
                g16[1] = checkBox162.Text;
            }

            if (checkBox163.Checked == true)
            {
                if ((g16[0] == "" && g16[1] == "") == false)
                {
                    if (g16[0] == "")
                    {
                        g16[0] = checkBox163.Text;
                    }

                    if (g16[1] == "")
                    {
                        g16[1] = checkBox163.Text;
                    }
                }

                else
                {
                    g16[0] = checkBox163.Text;
                }
            }

            if (checkBox164.Checked == true)
            {
                if ((g16[0] == "" && g16[1] == "") == false)
                {
                    if (g16[0] == "")
                    {
                        g16[0] = checkBox164.Text;
                    }

                    if (g16[1] == "")
                    {
                        g16[1] = checkBox164.Text;
                    }
                }

                else
                {
                    g16[1] = checkBox164.Text;
                }
            }

            label16.Text = String.Join("", g16);

            pictureBox161.Visible = false;
            pictureBox162.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g16[i] == "" | false | g16[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g16[0] == g16[1])
                {
                    if (g16[0] == "A")
                    {
                        pictureBox161.Visible = true;
                    }

                    else
                    {
                        pictureBox162.Visible = true;
                    }
                }

                else
                {
                    pictureBox161.Visible = true;
                }
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox171.Checked == true && checkBox172.Checked == false && checkBox173.Checked == false && checkBox174.Checked == false)
            {
                mem17[0] = 1;
            }

            if (checkBox171.Checked == false && checkBox172.Checked == false && checkBox173.Checked == false && checkBox174.Checked == false)
            {
                mem17[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem17.Length; i++)
            {
                if (mem17[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox171.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem17[0] = 2;
                    }

                    else
                    {
                        mem17[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem17.Length; i++)
                    {
                        if (mem17[i] == 2)
                        {
                            mem17[i] = 0;

                            if (i == 1)
                            {
                                checkBox172.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox173.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox174.Checked = false;
                                break;
                            }
                        }
                    }

                    mem17[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem17[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem17.Length; i++)
                    {
                        if (mem17[i] == 1)
                        {
                            mem17[i] = 1;
                            break;
                        }
                    }

                    mem17[0] = 0;
                }
            }

            g17[0] = "";
            g17[1] = "";

            if (checkBox171.Checked == true)
            {
                g17[0] = checkBox171.Text;
            }

            if (checkBox172.Checked == true)
            {
                g17[1] = checkBox172.Text;
            }

            if (checkBox173.Checked == true)
            {
                if ((g17[0] == "" && g17[1] == "") == false)
                {
                    if (g17[0] == "")
                    {
                        g17[0] = checkBox173.Text;
                    }

                    if (g17[1] == "")
                    {
                        g17[1] = checkBox173.Text;
                    }
                }

                else
                {
                    g17[0] = checkBox173.Text;
                }
            }

            if (checkBox174.Checked == true)
            {
                if ((g17[0] == "" && g17[1] == "") == false)
                {
                    if (g17[0] == "")
                    {
                        g17[0] = checkBox174.Text;
                    }

                    if (g17[1] == "")
                    {
                        g17[1] = checkBox174.Text;
                    }
                }

                else
                {
                    g17[1] = checkBox174.Text;
                }
            }

            label17.Text = String.Join("", g17);

            pictureBox171.Visible = false;
            pictureBox172.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g17[i] == "" | false | g17[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g17[0] == g17[1])
                {
                    if (g17[0] == "T")
                    {
                        pictureBox171.Visible = true;
                    }

                    else
                    {
                        pictureBox172.Visible = true;
                    }
                }

                else
                {
                    pictureBox171.Visible = true;
                }
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox171.Checked == false && checkBox172.Checked == true && checkBox173.Checked == false && checkBox174.Checked == false)
            {
                mem17[1] = 1;
            }

            if (checkBox171.Checked == false && checkBox172.Checked == false && checkBox173.Checked == false && checkBox174.Checked == false)
            {
                mem17[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem17.Length; i++)
            {
                if (mem17[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox172.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem17[1] = 2;
                    }

                    else
                    {
                        mem17[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem17.Length; i++)
                    {
                        if (mem17[i] == 2)
                        {
                            mem17[i] = 0;

                            if (i == 0)
                            {
                                checkBox171.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox173.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox174.Checked = false;
                                break;
                            }
                        }
                    }

                    mem17[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem17[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem17.Length; i++)
                    {
                        if (mem17[i] == 1)
                        {
                            mem17[i] = 1;
                            break;
                        }
                    }

                    mem17[1] = 0;
                }
            }

            g17[0] = "";
            g17[1] = "";

            if (checkBox171.Checked == true)
            {
                g17[0] = checkBox171.Text;
            }

            if (checkBox172.Checked == true)
            {
                g17[1] = checkBox172.Text;
            }

            if (checkBox173.Checked == true)
            {
                if ((g17[0] == "" && g17[1] == "") == false)
                {
                    if (g17[0] == "")
                    {
                        g17[0] = checkBox173.Text;
                    }

                    if (g17[1] == "")
                    {
                        g17[1] = checkBox173.Text;
                    }
                }

                else
                {
                    g17[0] = checkBox173.Text;
                }
            }

            if (checkBox174.Checked == true)
            {
                if ((g17[0] == "" && g17[1] == "") == false)
                {
                    if (g17[0] == "")
                    {
                        g17[0] = checkBox174.Text;
                    }

                    if (g17[1] == "")
                    {
                        g17[1] = checkBox174.Text;
                    }
                }

                else
                {
                    g17[1] = checkBox174.Text;
                }
            }

            label17.Text = String.Join("", g17);

            pictureBox171.Visible = false;
            pictureBox172.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g17[i] == "" | false | g17[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g17[0] == g17[1])
                {
                    if (g17[0] == "T")
                    {
                        pictureBox171.Visible = true;
                    }

                    else
                    {
                        pictureBox172.Visible = true;
                    }
                }

                else
                {
                    pictureBox171.Visible = true;
                }
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox211.Checked == true && checkBox212.Checked == false && checkBox213.Checked == false && checkBox214.Checked == false)
            {
                mem21[0] = 1;
            }

            if (checkBox211.Checked == false && checkBox212.Checked == false && checkBox213.Checked == false && checkBox214.Checked == false)
            {
                mem21[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem21.Length; i++)
            {
                if (mem21[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox211.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem21[0] = 2;
                    }

                    else
                    {
                        mem21[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem21.Length; i++)
                    {
                        if (mem21[i] == 2)
                        {
                            mem21[i] = 0;

                            if (i == 1)
                            {
                                checkBox212.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox213.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox214.Checked = false;
                                break;
                            }
                        }
                    }

                    mem21[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem21[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem21.Length; i++)
                    {
                        if (mem21[i] == 1)
                        {
                            mem21[i] = 1;
                            break;
                        }
                    }

                    mem21[0] = 0;
                }
            }

            g21[0] = "";
            g21[1] = "";

            if (checkBox211.Checked == true)
            {
                g21[0] = checkBox211.Text;
            }

            if (checkBox212.Checked == true)
            {
                g21[1] = checkBox212.Text;
            }

            if (checkBox213.Checked == true)
            {
                if ((g21[0] == "" && g21[1] == "") == false)
                {
                    if (g21[0] == "")
                    {
                        g21[0] = checkBox213.Text;
                    }

                    if (g21[1] == "")
                    {
                        g21[1] = checkBox213.Text;
                    }
                }

                else
                {
                    g21[0] = checkBox213.Text;
                }
            }

            if (checkBox214.Checked == true)
            {
                if ((g21[0] == "" && g21[1] == "") == false)
                {
                    if (g21[0] == "")
                    {
                        g21[0] = checkBox214.Text;
                    }

                    if (g21[1] == "")
                    {
                        g21[1] = checkBox214.Text;
                    }
                }

                else
                {
                    g21[1] = checkBox214.Text;
                }
            }

            label21.Text = String.Join("", g21);

            pictureBox211.Visible = false;
            pictureBox212.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g21[i] == "" | false | g21[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g21[0] == g21[1])
                {
                    if (g21[0] == "R")
                    {
                        pictureBox211.Visible = true;
                    }

                    else
                    {
                        pictureBox212.Visible = true;
                    }
                }

                else
                {
                    pictureBox211.Visible = true;
                }
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox211.Checked == false && checkBox212.Checked == true && checkBox213.Checked == false && checkBox214.Checked == false)
            {
                mem21[1] = 1;
            }

            if (checkBox211.Checked == false && checkBox212.Checked == false && checkBox213.Checked == false && checkBox214.Checked == false)
            {
                mem21[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem21.Length; i++)
            {
                if (mem21[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox212.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem21[1] = 2;
                    }

                    else
                    {
                        mem21[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem21.Length; i++)
                    {
                        if (mem21[i] == 2)
                        {
                            mem21[i] = 0;

                            if (i == 0)
                            {
                                checkBox211.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox213.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox214.Checked = false;
                                break;
                            }
                        }
                    }

                    mem21[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem21[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem21.Length; i++)
                    {
                        if (mem21[i] == 1)
                        {
                            mem21[i] = 1;
                            break;
                        }
                    }

                    mem21[1] = 0;
                }
            }

            g21[0] = "";
            g21[1] = "";

            if (checkBox211.Checked == true)
            {
                g21[0] = checkBox211.Text;
            }

            if (checkBox212.Checked == true)
            {
                g21[1] = checkBox212.Text;
            }

            if (checkBox213.Checked == true)
            {
                if ((g21[0] == "" && g21[1] == "") == false)
                {
                    if (g21[0] == "")
                    {
                        g21[0] = checkBox213.Text;
                    }

                    if (g21[1] == "")
                    {
                        g21[1] = checkBox213.Text;
                    }
                }

                else
                {
                    g21[0] = checkBox213.Text;
                }
            }

            if (checkBox214.Checked == true)
            {
                if ((g21[0] == "" && g21[1] == "") == false)
                {
                    if (g21[0] == "")
                    {
                        g21[0] = checkBox214.Text;
                    }

                    if (g21[1] == "")
                    {
                        g21[1] = checkBox214.Text;
                    }
                }

                else
                {
                    g21[1] = checkBox214.Text;
                }
            }

            label21.Text = String.Join("", g21);

            pictureBox211.Visible = false;
            pictureBox212.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g21[i] == "" | false | g21[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g21[0] == g21[1])
                {
                    if (g21[0] == "R")
                    {
                        pictureBox211.Visible = true;
                    }

                    else
                    {
                        pictureBox212.Visible = true;
                    }
                }

                else
                {
                    pictureBox211.Visible = true;
                }
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox221.Checked == true && checkBox222.Checked == false && checkBox223.Checked == false && checkBox224.Checked == false)
            {
                mem22[0] = 1;
            }

            if (checkBox221.Checked == false && checkBox222.Checked == false && checkBox223.Checked == false && checkBox224.Checked == false)
            {
                mem22[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem22.Length; i++)
            {
                if (mem22[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox221.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem22[0] = 2;
                    }

                    else
                    {
                        mem22[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem22.Length; i++)
                    {
                        if (mem22[i] == 2)
                        {
                            mem22[i] = 0;

                            if (i == 1)
                            {
                                checkBox222.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox223.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox224.Checked = false;
                                break;
                            }
                        }
                    }

                    mem22[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem22[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem22.Length; i++)
                    {
                        if (mem22[i] == 1)
                        {
                            mem22[i] = 1;
                            break;
                        }
                    }

                    mem22[0] = 0;
                }
            }

            g22[0] = "";
            g22[1] = "";

            if (checkBox221.Checked == true)
            {
                g22[0] = checkBox221.Text;
            }

            if (checkBox222.Checked == true)
            {
                g22[1] = checkBox222.Text;
            }

            if (checkBox223.Checked == true)
            {
                if ((g22[0] == "" && g22[1] == "") == false)
                {
                    if (g22[0] == "")
                    {
                        g22[0] = checkBox223.Text;
                    }

                    if (g22[1] == "")
                    {
                        g22[1] = checkBox223.Text;
                    }
                }

                else
                {
                    g22[0] = checkBox223.Text;
                }
            }

            if (checkBox224.Checked == true)
            {
                if ((g22[0] == "" && g22[1] == "") == false)
                {
                    if (g22[0] == "")
                    {
                        g22[0] = checkBox224.Text;
                    }

                    if (g22[1] == "")
                    {
                        g22[1] = checkBox224.Text;
                    }
                }

                else
                {
                    g22[1] = checkBox224.Text;
                }
            }

            label22.Text = String.Join("", g22);

            pictureBox221.Visible = false;
            pictureBox222.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g22[i] == "" | false | g22[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g22[0] == g22[1])
                {
                    if (g22[0] == "Y")
                    {
                        pictureBox221.Visible = true;
                    }

                    else
                    {
                        pictureBox222.Visible = true;
                    }
                }

                else
                {
                    pictureBox221.Visible = true;
                }
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox221.Checked == false && checkBox222.Checked == true && checkBox223.Checked == false && checkBox224.Checked == false)
            {
                mem22[1] = 1;
            }

            if (checkBox221.Checked == false && checkBox222.Checked == false && checkBox223.Checked == false && checkBox224.Checked == false)
            {
                mem22[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem22.Length; i++)
            {
                if (mem22[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox222.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem22[1] = 2;
                    }

                    else
                    {
                        mem22[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem22.Length; i++)
                    {
                        if (mem22[i] == 2)
                        {
                            mem22[i] = 0;

                            if (i == 0)
                            {
                                checkBox221.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox223.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox224.Checked = false;
                                break;
                            }
                        }
                    }

                    mem22[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem22[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem22.Length; i++)
                    {
                        if (mem22[i] == 1)
                        {
                            mem22[i] = 1;
                            break;
                        }
                    }

                    mem22[1] = 0;
                }
            }

            g22[0] = "";
            g22[1] = "";

            if (checkBox221.Checked == true)
            {
                g22[0] = checkBox221.Text;
            }

            if (checkBox222.Checked == true)
            {
                g22[1] = checkBox222.Text;
            }

            if (checkBox223.Checked == true)
            {
                if ((g22[0] == "" && g22[1] == "") == false)
                {
                    if (g22[0] == "")
                    {
                        g22[0] = checkBox223.Text;
                    }

                    if (g22[1] == "")
                    {
                        g22[1] = checkBox223.Text;
                    }
                }

                else
                {
                    g22[0] = checkBox223.Text;
                }
            }

            if (checkBox224.Checked == true)
            {
                if ((g22[0] == "" && g22[1] == "") == false)
                {
                    if (g22[0] == "")
                    {
                        g22[0] = checkBox224.Text;
                    }

                    if (g22[1] == "")
                    {
                        g22[1] = checkBox224.Text;
                    }
                }

                else
                {
                    g22[1] = checkBox224.Text;
                }
            }

            label22.Text = String.Join("", g22);

            pictureBox221.Visible = false;
            pictureBox222.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g22[i] == "" | false | g22[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g22[0] == g22[1])
                {
                    if (g22[0] == "Y")
                    {
                        pictureBox221.Visible = true;
                    }

                    else
                    {
                        pictureBox222.Visible = true;
                    }
                }

                else
                {
                    pictureBox221.Visible = true;
                }
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox231.Checked == true && checkBox232.Checked == false && checkBox233.Checked == false && checkBox234.Checked == false)
            {
                mem23[0] = 1;
            }

            if (checkBox231.Checked == false && checkBox232.Checked == false && checkBox233.Checked == false && checkBox234.Checked == false)
            {
                mem23[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem23.Length; i++)
            {
                if (mem23[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox231.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem23[0] = 2;
                    }

                    else
                    {
                        mem23[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem23.Length; i++)
                    {
                        if (mem23[i] == 2)
                        {
                            mem23[i] = 0;

                            if (i == 1)
                            {
                                checkBox232.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox233.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox234.Checked = false;
                                break;
                            }
                        }
                    }

                    mem23[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem23[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem23.Length; i++)
                    {
                        if (mem23[i] == 1)
                        {
                            mem22[i] = 1;
                            break;
                        }
                    }

                    mem23[0] = 0;
                }
            }

            g23[0] = "";
            g23[1] = "";

            if (checkBox231.Checked == true)
            {
                g23[0] = checkBox231.Text;
            }

            if (checkBox232.Checked == true)
            {
                g23[1] = checkBox232.Text;
            }

            if (checkBox233.Checked == true)
            {
                if ((g23[0] == "" && g23[1] == "") == false)
                {
                    if (g23[0] == "")
                    {
                        g23[0] = checkBox233.Text;
                    }

                    if (g23[1] == "")
                    {
                        g23[1] = checkBox233.Text;
                    }
                }

                else
                {
                    g23[0] = checkBox233.Text;
                }
            }

            if (checkBox234.Checked == true)
            {
                if ((g23[0] == "" && g23[1] == "") == false)
                {
                    if (g23[0] == "")
                    {
                        g23[0] = checkBox234.Text;
                    }

                    if (g23[1] == "")
                    {
                        g23[1] = checkBox234.Text;
                    }
                }

                else
                {
                    g23[1] = checkBox234.Text;
                }
            }

            label23.Text = String.Join("", g23);

            pictureBox231.Visible = false;
            pictureBox232.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g23[i] == "" | false | g23[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g23[0] == g23[1])
                {
                    if (g23[0] == "G")
                    {
                        pictureBox231.Visible = true;
                    }

                    else
                    {
                        pictureBox232.Visible = true;
                    }
                }

                else
                {
                    pictureBox231.Visible = true;
                }
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox231.Checked == false && checkBox232.Checked == true && checkBox233.Checked == false && checkBox234.Checked == false)
            {
                mem23[1] = 1;
            }

            if (checkBox231.Checked == false && checkBox232.Checked == false && checkBox233.Checked == false && checkBox234.Checked == false)
            {
                mem23[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem23.Length; i++)
            {
                if (mem23[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox232.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem23[1] = 2;
                    }

                    else
                    {
                        mem23[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem23.Length; i++)
                    {
                        if (mem23[i] == 2)
                        {
                            mem23[i] = 0;

                            if (i == 0)
                            {
                                checkBox231.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox233.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox234.Checked = false;
                                break;
                            }
                        }
                    }

                    mem23[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem23[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem23.Length; i++)
                    {
                        if (mem23[i] == 1)
                        {
                            mem23[i] = 1;
                            break;
                        }
                    }

                    mem23[1] = 0;
                }
            }

            g23[0] = "";
            g23[1] = "";

            if (checkBox231.Checked == true)
            {
                g23[0] = checkBox231.Text;
            }

            if (checkBox232.Checked == true)
            {
                g23[1] = checkBox232.Text;
            }

            if (checkBox233.Checked == true)
            {
                if ((g23[0] == "" && g23[1] == "") == false)
                {
                    if (g23[0] == "")
                    {
                        g23[0] = checkBox233.Text;
                    }

                    if (g23[1] == "")
                    {
                        g23[1] = checkBox233.Text;
                    }
                }

                else
                {
                    g23[0] = checkBox233.Text;
                }
            }

            if (checkBox234.Checked == true)
            {
                if ((g23[0] == "" && g23[1] == "") == false)
                {
                    if (g23[0] == "")
                    {
                        g23[0] = checkBox234.Text;
                    }

                    if (g23[1] == "")
                    {
                        g23[1] = checkBox234.Text;
                    }
                }

                else
                {
                    g23[1] = checkBox234.Text;
                }
            }

            label23.Text = String.Join("", g23);

            pictureBox231.Visible = false;
            pictureBox232.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g23[i] == "" | false | g23[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g23[0] == g23[1])
                {
                    if (g23[0] == "G")
                    {
                        pictureBox231.Visible = true;
                    }

                    else
                    {
                        pictureBox232.Visible = true;
                    }
                }

                else
                {
                    pictureBox231.Visible = true;
                }
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox241.Checked == true && checkBox242.Checked == false && checkBox243.Checked == false && checkBox244.Checked == false)
            {
                mem24[0] = 1;
            }

            if (checkBox241.Checked == false && checkBox242.Checked == false && checkBox243.Checked == false && checkBox244.Checked == false)
            {
                mem24[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem24.Length; i++)
            {
                if (mem24[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox241.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem24[0] = 2;
                    }

                    else
                    {
                        mem24[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem24.Length; i++)
                    {
                        if (mem24[i] == 2)
                        {
                            mem24[i] = 0;

                            if (i == 1)
                            {
                                checkBox242.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox243.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox244.Checked = false;
                                break;
                            }
                        }
                    }

                    mem24[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem24[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem24.Length; i++)
                    {
                        if (mem24[i] == 1)
                        {
                            mem24[i] = 1;
                            break;
                        }
                    }

                    mem24[0] = 0;
                }
            }

            g24[0] = "";
            g24[1] = "";

            if (checkBox241.Checked == true)
            {
                g24[0] = checkBox241.Text;
            }

            if (checkBox242.Checked == true)
            {
                g24[1] = checkBox242.Text;
            }

            if (checkBox243.Checked == true)
            {
                if ((g24[0] == "" && g24[1] == "") == false)
                {
                    if (g24[0] == "")
                    {
                        g24[0] = checkBox243.Text;
                    }

                    if (g24[1] == "")
                    {
                        g24[1] = checkBox243.Text;
                    }
                }

                else
                {
                    g24[0] = checkBox243.Text;
                }
            }

            if (checkBox244.Checked == true)
            {
                if ((g24[0] == "" && g24[1] == "") == false)
                {
                    if (g24[0] == "")
                    {
                        g24[0] = checkBox244.Text;
                    }

                    if (g24[1] == "")
                    {
                        g24[1] = checkBox244.Text;
                    }
                }

                else
                {
                    g24[1] = checkBox244.Text;
                }
            }

            label24.Text = String.Join("", g24);

            pictureBox241.Visible = false;
            pictureBox242.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g24[i] == "" | false | g24[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g24[0] == g24[1])
                {
                    if (g24[0] == "C")
                    {
                        pictureBox241.Visible = true;
                    }

                    else
                    {
                        pictureBox242.Visible = true;
                    }
                }

                else
                {
                    pictureBox241.Visible = true;
                }
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox241.Checked == false && checkBox242.Checked == true && checkBox243.Checked == false && checkBox244.Checked == false)
            {
                mem24[1] = 1;
            }

            if (checkBox241.Checked == false && checkBox242.Checked == false && checkBox243.Checked == false && checkBox244.Checked == false)
            {
                mem24[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem24.Length; i++)
            {
                if (mem24[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox242.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem24[1] = 2;
                    }

                    else
                    {
                        mem24[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem24.Length; i++)
                    {
                        if (mem24[i] == 2)
                        {
                            mem24[i] = 0;

                            if (i == 0)
                            {
                                checkBox241.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox243.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox244.Checked = false;
                                break;
                            }
                        }
                    }

                    mem24[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem24[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem24.Length; i++)
                    {
                        if (mem24[i] == 1)
                        {
                            mem24[i] = 1;
                            break;
                        }
                    }

                    mem24[1] = 0;
                }
            }

            g24[0] = "";
            g24[1] = "";

            if (checkBox241.Checked == true)
            {
                g24[0] = checkBox241.Text;
            }

            if (checkBox242.Checked == true)
            {
                g24[1] = checkBox242.Text;
            }

            if (checkBox243.Checked == true)
            {
                if ((g24[0] == "" && g24[1] == "") == false)
                {
                    if (g24[0] == "")
                    {
                        g24[0] = checkBox243.Text;
                    }

                    if (g24[1] == "")
                    {
                        g24[1] = checkBox243.Text;
                    }
                }

                else
                {
                    g24[0] = checkBox243.Text;
                }
            }

            if (checkBox244.Checked == true)
            {
                if ((g24[0] == "" && g24[1] == "") == false)
                {
                    if (g24[0] == "")
                    {
                        g24[0] = checkBox244.Text;
                    }

                    if (g24[1] == "")
                    {
                        g24[1] = checkBox244.Text;
                    }
                }

                else
                {
                    g24[1] = checkBox244.Text;
                }
            }

            label24.Text = String.Join("", g24);

            pictureBox241.Visible = false;
            pictureBox242.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g24[i] == "" | false | g24[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g24[0] == g24[1])
                {
                    if (g24[0] == "C")
                    {
                        pictureBox241.Visible = true;
                    }

                    else
                    {
                        pictureBox242.Visible = true;
                    }
                }

                else
                {
                    pictureBox241.Visible = true;
                }
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox251.Checked == true && checkBox252.Checked == false && checkBox253.Checked == false && checkBox254.Checked == false)
            {
                mem25[0] = 1;
            }

            if (checkBox251.Checked == false && checkBox252.Checked == false && checkBox253.Checked == false && checkBox254.Checked == false)
            {
                mem25[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem25.Length; i++)
            {
                if (mem25[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox251.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem25[0] = 2;
                    }

                    else
                    {
                        mem25[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem25.Length; i++)
                    {
                        if (mem25[i] == 2)
                        {
                            mem25[i] = 0;

                            if (i == 1)
                            {
                                checkBox252.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox253.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox254.Checked = false;
                                break;
                            }
                        }
                    }

                    mem25[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem25[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem25.Length; i++)
                    {
                        if (mem25[i] == 1)
                        {
                            mem25[i] = 1;
                            break;
                        }
                    }

                    mem25[0] = 0;
                }
            }

            g25[0] = "";
            g25[1] = "";

            if (checkBox251.Checked == true)
            {
                g25[0] = checkBox251.Text;
            }

            if (checkBox252.Checked == true)
            {
                g25[1] = checkBox252.Text;
            }

            if (checkBox253.Checked == true)
            {
                if ((g25[0] == "" && g25[1] == "") == false)
                {
                    if (g25[0] == "")
                    {
                        g25[0] = checkBox253.Text;
                    }

                    if (g25[1] == "")
                    {
                        g25[1] = checkBox253.Text;
                    }
                }

                else
                {
                    g25[0] = checkBox253.Text;
                }
            }

            if (checkBox254.Checked == true)
            {
                if ((g25[0] == "" && g25[1] == "") == false)
                {
                    if (g25[0] == "")
                    {
                        g25[0] = checkBox254.Text;
                    }

                    if (g25[1] == "")
                    {
                        g25[1] = checkBox254.Text;
                    }
                }

                else
                {
                    g25[1] = checkBox254.Text;
                }
            }

            label25.Text = String.Join("", g25);

            pictureBox251.Visible = false;
            pictureBox252.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g25[i] == "" | false | g25[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g25[0] == g25[1])
                {
                    if (g25[0] == "P")
                    {
                        pictureBox251.Visible = true;
                    }

                    else
                    {
                        pictureBox252.Visible = true;
                    }
                }

                else
                {
                    pictureBox251.Visible = true;
                }
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox251.Checked == false && checkBox252.Checked == true && checkBox253.Checked == false && checkBox254.Checked == false)
            {
                mem25[1] = 1;
            }

            if (checkBox251.Checked == false && checkBox252.Checked == false && checkBox253.Checked == false && checkBox254.Checked == false)
            {
                mem25[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem25.Length; i++)
            {
                if (mem25[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox252.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem25[1] = 2;
                    }

                    else
                    {
                        mem25[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem25.Length; i++)
                    {
                        if (mem25[i] == 2)
                        {
                            mem25[i] = 0;

                            if (i == 0)
                            {
                                checkBox251.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox253.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox254.Checked = false;
                                break;
                            }
                        }
                    }

                    mem25[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem25[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem25.Length; i++)
                    {
                        if (mem25[i] == 1)
                        {
                            mem25[i] = 1;
                            break;
                        }
                    }

                    mem25[1] = 0;
                }
            }

            g25[0] = "";
            g25[1] = "";

            if (checkBox251.Checked == true)
            {
                g25[0] = checkBox251.Text;
            }

            if (checkBox252.Checked == true)
            {
                g25[1] = checkBox252.Text;
            }

            if (checkBox253.Checked == true)
            {
                if ((g25[0] == "" && g25[1] == "") == false)
                {
                    if (g25[0] == "")
                    {
                        g25[0] = checkBox253.Text;
                    }

                    if (g25[1] == "")
                    {
                        g25[1] = checkBox253.Text;
                    }
                }

                else
                {
                    g25[0] = checkBox253.Text;
                }
            }

            if (checkBox254.Checked == true)
            {
                if ((g25[0] == "" && g25[1] == "") == false)
                {
                    if (g25[0] == "")
                    {
                        g25[0] = checkBox254.Text;
                    }

                    if (g25[1] == "")
                    {
                        g25[1] = checkBox254.Text;
                    }
                }

                else
                {
                    g25[1] = checkBox254.Text;
                }
            }

            label25.Text = String.Join("", g25);

            pictureBox251.Visible = false;
            pictureBox252.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g25[i] == "" | false | g25[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g25[0] == g25[1])
                {
                    if (g25[0] == "P")
                    {
                        pictureBox251.Visible = true;
                    }

                    else
                    {
                        pictureBox252.Visible = true;
                    }
                }

                else
                {
                    pictureBox251.Visible = true;
                }
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox261.Checked == true && checkBox262.Checked == false && checkBox263.Checked == false && checkBox264.Checked == false)
            {
                mem26[0] = 1;
            }

            if (checkBox261.Checked == false && checkBox262.Checked == false && checkBox263.Checked == false && checkBox264.Checked == false)
            {
                mem26[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem26.Length; i++)
            {
                if (mem26[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox261.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem26[0] = 2;
                    }

                    else
                    {
                        mem26[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem26.Length; i++)
                    {
                        if (mem26[i] == 2)
                        {
                            mem26[i] = 0;

                            if (i == 1)
                            {
                                checkBox262.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox263.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox264.Checked = false;
                                break;
                            }
                        }
                    }

                    mem26[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem26[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem26.Length; i++)
                    {
                        if (mem26[i] == 1)
                        {
                            mem26[i] = 1;
                            break;
                        }
                    }

                    mem26[0] = 0;
                }
            }

            g26[0] = "";
            g26[1] = "";

            if (checkBox261.Checked == true)
            {
                g26[0] = checkBox261.Text;
            }

            if (checkBox262.Checked == true)
            {
                g26[1] = checkBox262.Text;
            }

            if (checkBox263.Checked == true)
            {
                if ((g26[0] == "" && g26[1] == "") == false)
                {
                    if (g26[0] == "")
                    {
                        g26[0] = checkBox263.Text;
                    }

                    if (g26[1] == "")
                    {
                        g26[1] = checkBox263.Text;
                    }
                }

                else
                {
                    g26[0] = checkBox263.Text;
                }
            }

            if (checkBox264.Checked == true)
            {
                if ((g26[0] == "" && g26[1] == "") == false)
                {
                    if (g26[0] == "")
                    {
                        g26[0] = checkBox264.Text;
                    }

                    if (g26[1] == "")
                    {
                        g26[1] = checkBox264.Text;
                    }
                }

                else
                {
                    g26[1] = checkBox264.Text;
                }
            }

            label26.Text = String.Join("", g26);

            pictureBox261.Visible = false;
            pictureBox262.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g26[i] == "" | false | g26[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g26[0] == g26[1])
                {
                    if (g26[0] == "A")
                    {
                        pictureBox261.Visible = true;
                    }

                    else
                    {
                        pictureBox262.Visible = true;
                    }
                }

                else
                {
                    pictureBox261.Visible = true;
                }
            }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox261.Checked == false && checkBox262.Checked == true && checkBox263.Checked == false && checkBox264.Checked == false)
            {
                mem26[1] = 1;
            }

            if (checkBox261.Checked == false && checkBox262.Checked == false && checkBox263.Checked == false && checkBox264.Checked == false)
            {
                mem26[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem26.Length; i++)
            {
                if (mem26[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox262.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem26[1] = 2;
                    }

                    else
                    {
                        mem26[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem26.Length; i++)
                    {
                        if (mem26[i] == 2)
                        {
                            mem26[i] = 0;

                            if (i == 0)
                            {
                                checkBox261.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox263.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox264.Checked = false;
                                break;
                            }
                        }
                    }

                    mem26[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem26[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem26.Length; i++)
                    {
                        if (mem26[i] == 1)
                        {
                            mem26[i] = 1;
                            break;
                        }
                    }

                    mem26[1] = 0;
                }
            }

            g26[0] = "";
            g26[1] = "";

            if (checkBox261.Checked == true)
            {
                g26[0] = checkBox261.Text;
            }

            if (checkBox262.Checked == true)
            {
                g26[1] = checkBox262.Text;
            }

            if (checkBox263.Checked == true)
            {
                if ((g26[0] == "" && g26[1] == "") == false)
                {
                    if (g26[0] == "")
                    {
                        g26[0] = checkBox263.Text;
                    }

                    if (g26[1] == "")
                    {
                        g26[1] = checkBox263.Text;
                    }
                }

                else
                {
                    g26[0] = checkBox263.Text;
                }
            }

            if (checkBox264.Checked == true)
            {
                if ((g26[0] == "" && g26[1] == "") == false)
                {
                    if (g26[0] == "")
                    {
                        g26[0] = checkBox264.Text;
                    }

                    if (g26[1] == "")
                    {
                        g26[1] = checkBox264.Text;
                    }
                }

                else
                {
                    g26[1] = checkBox264.Text;
                }
            }

            label26.Text = String.Join("", g26);

            pictureBox261.Visible = false;
            pictureBox262.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g26[i] == "" | false | g26[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g26[0] == g26[1])
                {
                    if (g26[0] == "A")
                    {
                        pictureBox261.Visible = true;
                    }

                    else
                    {
                        pictureBox262.Visible = true;
                    }
                }

                else
                {
                    pictureBox261.Visible = true;
                }
            }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox271.Checked == true && checkBox272.Checked == false && checkBox273.Checked == false && checkBox274.Checked == false)
            {
                mem27[0] = 1;
            }

            if (checkBox271.Checked == false && checkBox272.Checked == false && checkBox273.Checked == false && checkBox274.Checked == false)
            {
                mem27[0] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem27.Length; i++)
            {
                if (mem27[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox271.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 0)
                    {
                        mem27[0] = 2;
                    }

                    else
                    {
                        mem27[0] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 1; i < mem27.Length; i++)
                    {
                        if (mem27[i] == 2)
                        {
                            mem27[i] = 0;

                            if (i == 1)
                            {
                                checkBox272.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox273.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox274.Checked = false;
                                break;
                            }
                        }
                    }

                    mem27[0] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem27[0] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem27.Length; i++)
                    {
                        if (mem27[i] == 1)
                        {
                            mem27[i] = 1;
                            break;
                        }
                    }

                    mem27[0] = 0;
                }
            }

            g27[0] = "";
            g27[1] = "";

            if (checkBox271.Checked == true)
            {
                g27[0] = checkBox271.Text;
            }

            if (checkBox272.Checked == true)
            {
                g27[1] = checkBox272.Text;
            }

            if (checkBox273.Checked == true)
            {
                if ((g27[0] == "" && g27[1] == "") == false)
                {
                    if (g27[0] == "")
                    {
                        g27[0] = checkBox273.Text;
                    }

                    if (g27[1] == "")
                    {
                        g27[1] = checkBox273.Text;
                    }
                }

                else
                {
                    g27[0] = checkBox273.Text;
                }
            }

            if (checkBox274.Checked == true)
            {
                if ((g27[0] == "" && g27[1] == "") == false)
                {
                    if (g27[0] == "")
                    {
                        g27[0] = checkBox274.Text;
                    }

                    if (g27[1] == "")
                    {
                        g27[1] = checkBox274.Text;
                    }
                }

                else
                {
                    g27[1] = checkBox274.Text;
                }
            }

            label27.Text = String.Join("", g27);

            pictureBox271.Visible = false;
            pictureBox272.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g27[i] == "" | false | g27[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g27[0] == g27[1])
                {
                    if (g27[0] == "T")
                    {
                        pictureBox271.Visible = true;
                    }

                    else
                    {
                        pictureBox272.Visible = true;
                    }
                }

                else
                {
                    pictureBox271.Visible = true;
                }
            }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox271.Checked == false && checkBox272.Checked == true && checkBox273.Checked == false && checkBox274.Checked == false)
            {
                mem27[1] = 1;
            }

            if (checkBox271.Checked == false && checkBox272.Checked == false && checkBox273.Checked == false && checkBox274.Checked == false)
            {
                mem27[1] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem27.Length; i++)
            {
                if (mem27[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox272.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 1)
                    {
                        mem27[1] = 2;
                    }

                    else
                    {
                        mem27[1] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem27.Length; i++)
                    {
                        if (mem27[i] == 2)
                        {
                            mem27[i] = 0;

                            if (i == 0)
                            {
                                checkBox271.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox273.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox274.Checked = false;
                                break;
                            }
                        }
                    }

                    mem27[1] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem27[1] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem27.Length; i++)
                    {
                        if (mem27[i] == 1)
                        {
                            mem27[i] = 1;
                            break;
                        }
                    }

                    mem27[1] = 0;
                }
            }

            g27[0] = "";
            g27[1] = "";

            if (checkBox271.Checked == true)
            {
                g27[0] = checkBox271.Text;
            }

            if (checkBox272.Checked == true)
            {
                g27[1] = checkBox272.Text;
            }

            if (checkBox273.Checked == true)
            {
                if ((g27[0] == "" && g27[1] == "") == false)
                {
                    if (g27[0] == "")
                    {
                        g27[0] = checkBox273.Text;
                    }

                    if (g27[1] == "")
                    {
                        g27[1] = checkBox273.Text;
                    }
                }

                else
                {
                    g27[0] = checkBox273.Text;
                }
            }

            if (checkBox274.Checked == true)
            {
                if ((g27[0] == "" && g27[1] == "") == false)
                {
                    if (g27[0] == "")
                    {
                        g27[0] = checkBox274.Text;
                    }

                    if (g27[1] == "")
                    {
                        g27[1] = checkBox274.Text;
                    }
                }

                else
                {
                    g27[1] = checkBox274.Text;
                }
            }

            label27.Text = String.Join("", g27);

            pictureBox271.Visible = false;
            pictureBox272.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g27[i] == "" | false | g27[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g27[0] == g27[1])
                {
                    if (g27[0] == "T")
                    {
                        pictureBox271.Visible = true;
                    }

                    else
                    {
                        pictureBox272.Visible = true;
                    }
                }

                else
                {
                    pictureBox271.Visible = true;
                }
            }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox29.Checked == true)
            {
                checkBox30.Checked = false;

                label110.Text = "Parent 1 pea plant:";
                label210.Text = "Parent 2 pea plant:";
                label1.Text = "Seed shape: R(Round), r(Wrinkled):";
                label2.Text = "Seed color: Y(Yellow), y(Green):";
                label3.Text = "Seed coat color: G(Gray), g(White):";
                label4.Text = "Pod shape: C(Smooth), c(Constricted):";
                label5.Text = "Pod color: P(Green), p(Yellow):";
                label6.Text = "Flower position: A(Axial), a(Terminal):";
                label7.Text = "Plant height: T(Tall), t(short):";
                label10.Text = "How many seeds should the parents produce?";
                label120.Text = "Write the corresponding\r\n number to one of the plants,\r\n that will be the one to self-polinate";
                label8.Text = "Not enough data(not enough checkboxes are checked)";
                label9.Text = "Put the number of seeds that the plants\r\nwill produce in the textbox above";

                checkBox111.Text = "R";
                checkBox112.Text = "r";
                checkBox113.Text = "R";
                checkBox114.Text = "r";

                checkBox211.Text = "R";
                checkBox212.Text = "r";
                checkBox213.Text = "R";
                checkBox214.Text = "r";

                checkBox121.Text = "Y";
                checkBox122.Text = "y";
                checkBox123.Text = "Y";
                checkBox124.Text = "y";

                checkBox221.Text = "Y";
                checkBox222.Text = "y";
                checkBox223.Text = "Y";
                checkBox224.Text = "y";

                checkBox131.Text = "G";
                checkBox132.Text = "g";
                checkBox133.Text = "G";
                checkBox134.Text = "g";

                checkBox231.Text = "G";
                checkBox232.Text = "g";
                checkBox233.Text = "G";
                checkBox234.Text = "g";

                checkBox141.Text = "C";
                checkBox142.Text = "c";
                checkBox143.Text = "C";
                checkBox144.Text = "c";

                checkBox241.Text = "C";
                checkBox242.Text = "c";
                checkBox243.Text = "C";
                checkBox244.Text = "c";

                checkBox151.Text = "P";
                checkBox152.Text = "p";
                checkBox153.Text = "P";
                checkBox154.Text = "p";

                checkBox251.Text = "P";
                checkBox252.Text = "p";
                checkBox253.Text = "P";
                checkBox254.Text = "p";


                checkBox161.Text = "A";
                checkBox162.Text = "a";
                checkBox163.Text = "A";
                checkBox164.Text = "a";

                checkBox261.Text = "A";
                checkBox262.Text = "a";
                checkBox263.Text = "A";
                checkBox264.Text = "a";

                checkBox171.Text = "T";
                checkBox172.Text = "t";
                checkBox173.Text = "T";
                checkBox174.Text = "t";

                checkBox273.Text = "T";
                checkBox274.Text = "t";
                checkBox271.Text = "T";
                checkBox272.Text = "t";

                button1.Text = "Cross the plants!";
                button2.Text = "Self-polinate the offspring!";
            }

            if (checkBox29.Checked == false && checkBox30.Checked == false)
            {
                checkBox29.Checked = true;
            }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true)
            {
                checkBox29.Checked = false;

                label110.Text = "Первое гороховое растение:";
                label210.Text = "Второе гороховое растение:";
                label1.Text = "Форма семечки:";
                label2.Text = "Цвет семечки:";
                label3.Text = "Цвет покрытия\r\nсемечки:";
                label4.Text = "Форма стручка:";
                label5.Text = "Цвет стручка:";
                label6.Text = "Позиция цветка:";
                label7.Text = "Высота растения:";
                label10.Text = "Сколько семечек должно сделаться?";
                label120.Text = "Напишите в верхнее текстововое\r\nокно соответствующий номер\r\nодному из растений, которое\r\nбудет самоопылять себя";

                checkBox111.Text = "Круглое";
                checkBox112.Text = "Морщинистое";
                checkBox211.Text = "Круглое";
                checkBox212.Text = "Морщинистое";

                checkBox121.Text = "Жёлтое";
                checkBox122.Text = "Зелёное";
                checkBox221.Text = "Жёлтое";
                checkBox222.Text = "Зелёное";

                checkBox131.Text = "Серое";
                checkBox132.Text = "Белое";
                checkBox231.Text = "Серое";
                checkBox232.Text = "Белое";

                checkBox141.Text = "Гладкое";
                checkBox142.Text = "Суженное";
                checkBox241.Text = "Гладкое";
                checkBox242.Text = "Суженное";

                checkBox151.Text = "Зелёное";
                checkBox152.Text = "Жёлтое";
                checkBox251.Text = "Зелёное";
                checkBox252.Text = "Жёлтое";

                checkBox161.Text = "Осевое";
                checkBox162.Text = "Терминальное";
                checkBox261.Text = "Осевое";
                checkBox262.Text = "Терминальное";

                checkBox171.Text = "Высокое";
                checkBox172.Text = "Короткое";
                checkBox271.Text = "Высокое";
                checkBox272.Text = "Короткое";

                button1.Text = "Скрестите родителей!";
                button2.Text = "Самоопыление потомства!";
            }

            if (checkBox29.Checked == false && checkBox30.Checked == false)
            {
                checkBox30.Checked = true;
            }
        }

        static string[] data_genotype = new string[0];

        private void button1_Click(object sender, EventArgs e) // the button was clicked and the checking of the inputs begin
        {
            label8.Visible = false;
            label9.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g11[i] == "" | false | g11[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g12[i] == "" | false | g12[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g13[i] == "" | false | g13[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g14[i] == "" | false | g14[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g15[i] == "" | false | g15[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g16[i] == "" | false | g16[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g17[i] == "" | false | g17[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g21[i] == "" | false | g21[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g22[i] == "" | false | g12[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g23[i] == "" | false | g13[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g24[i] == "" | false | g14[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g25[i] == "" | false | g15[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g26[i] == "" | false | g16[i] == null)
                {
                    not_enough_data = true;
                    break;
                }

                if (g27[i] == "" | false | g17[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            string hc = textBox1.Text;
            char[] hc2 = hc.ToCharArray();

            int hc3 = 0;

            if (textBox1.Text == "")
            {
                label9.Visible = true;
                not_enough_data = true;
            }


            for (int i = 0; i < hc2.Length; i++)
            {
                if (hc2[i] == '0')
                {
                    hc3++;
                }

                if (hc2[i] == '1')
                {
                    hc3++;
                }

                if (hc2[i] == '2')
                {
                    hc3++;
                }

                if (hc2[i] == '3')
                {
                    hc3++;
                }

                if (hc2[i] == '4')
                {
                    hc3++;
                }

                if (hc2[i] == '5')
                {
                    hc3++;
                }

                if (hc2[i] == '6')
                {
                    hc3++;
                }

                if (hc2[i] == '7')
                {
                    hc3++;
                }

                if (hc2[i] == '8')
                {
                    hc3++;
                }

                if (hc2[i] == '9')
                {
                    hc3++;
                }
            }

            if (hc3 != hc2.Length)
            {
                label9.Visible = true;
                not_enough_data = true;
            }
            // the checking of the inputs is finished

            if (not_enough_data == false) // if all inputs were correctly inputted
            {
                string[] seeds = new string[Convert.ToUInt64(textBox1.Text)]; // the seeds

                Stopwatch d = new Stopwatch(); // the timer

                int p; // an organasation helper

                string[] raw_data = new string[Convert.ToUInt64(textBox1.Text)]; // the raw data

                string[] phenotypedatacollector1 = new string[Convert.ToUInt64(textBox1.Text)]; // the phenotypes of the seeds

                char[] h1 = new char[0]; // a helper of the phenotype getting prosses of the seeds

                string[] h2 = new string[13]; // a helper of the genotype getting prosses of the seeds

                string ans = "";

                for (int i = 0; i < seeds.Length; i++) // the loop for finding out the genotype of the parents and the phenotype
                {
                    // the genotype getting prosses
                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            ans = g11[1];
                        }

                        else
                        {
                            ans = g11[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = ans;

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[0] = g21[1];
                        }

                        else
                        {
                            h2[0] = g21[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[0];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[1] = g12[1];
                        }

                        else
                        {
                            h2[1] = g12[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[1];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[2] = g22[1];
                        }

                        else
                        {
                            h2[2] = g22[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[2];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[3] = g13[1];
                        }

                        else
                        {
                            h2[3] = g13[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[3];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[4] = g23[1];
                        }

                        else
                        {
                            h2[4] = g23[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[4];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[5] = g14[1];
                        }

                        else
                        {
                            h2[5] = g14[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[5];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[6] = g24[1];
                        }

                        else
                        {
                            h2[6] = g24[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[6];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[7] = g15[1];
                        }

                        else
                        {
                            h2[7] = g15[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[7];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[8] = g25[1];
                        }

                        else
                        {
                            h2[8] = g25[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[8];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[9] = g16[1];
                        }

                        else
                        {
                            h2[9] = g16[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[9];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[10] = g26[1];
                        }

                        else
                        {
                            h2[10] = g26[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[10];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[11] = g17[1];
                        }

                        else
                        {
                            h2[11] = g17[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[11];

                    d.Start();
                    for (int j = 0; d.ElapsedMilliseconds < 1; j++)
                    {
                        p = j / 2;

                        if (j == p * 2)
                        {
                            h2[12] = g27[1];
                        }

                        else
                        {
                            h2[12] = g27[0];
                        }
                    }
                    d.Stop();
                    d.Reset();
                    seeds[i] = seeds[i] + h2[12];

                    // the phenotype getting prosses

                    h1 = seeds[i].ToCharArray();

                    for (int j = 0; j < h1.Length; j = j + 2)
                    {
                        p = j / 2;

                        //if (j == 2 * p)
                        //{
                        if (h1[j] == h1[j + 1])
                        {
                            phenotypedatacollector1[i] = phenotypedatacollector1[i] + h1[j].ToString();
                        }

                        else
                        {
                            if (h1[j] == 'r' | false | h1[j] == 'y' | false | h1[j] == 'g' | false | h1[j] == 'c' | false | h1[j] == 'p' | false | h1[j] == 'a' | false | h1[j] == 't')
                            {
                                phenotypedatacollector1[i] = phenotypedatacollector1[i] + h1[j + 1].ToString();
                            }

                            else
                            {
                                phenotypedatacollector1[i] = phenotypedatacollector1[i] + h1[j].ToString();
                            }
                        }
                        //}

                        // the condition that ruines everything sometimes

                        //else
                        //{
                        //    if (h1[j] == h1[j - 1])
                        //    {
                        //        phenotypedatacollector1[i] = phenotypedatacollector1[i] + h1[j].ToString();
                        //    }

                        //    else
                        //    {
                        //        if (h1[j] == 'r' | false | h1[j] == 'y' | false | h1[j] == 'g' | false | h1[j] == 'c' | false | h1[j] == 'p' | false | h1[j] == 'a' | false | h1[j] == 't')
                        //        {
                        //            phenotypedatacollector1[i] = phenotypedatacollector1[i] + h1[j - 1].ToString();
                        //        }

                        //        else
                        //        {
                        //            phenotypedatacollector1[i] = phenotypedatacollector1[i] + h1[j].ToString();
                        //        }
                        //    }
                        //}
                    }

                    // the data printing
                    raw_data[i] = "\r\n " + (i + 1).ToString() + ".    Genotype: " + seeds[i] + ".  Phenotype: " + phenotypedatacollector1[i];
                }

                // the data printing
                string rawans = String.Join("\r\n", raw_data);

                string[] names = new string[1]; // the unique genotypes in the seeds array
                int[] times = new int[1]; // the numbers of times that each of the unique genotypes occured

                char[] names2h = new char[0]; // the first helper of finding new unique genotypes in the seeds array
                char[] names3h = new char[0]; // the second helper of finding new unique genotypes in the seeds array

                names[0] = seeds[0];
                times[0] = 1;

                int[] gene11 = new int[14]; // the counter of names2h(how many times has the char 'R' occured and so on)
                int[] gene12 = new int[14]; // the counter of names3h(how many times has the char 'R' occured and so on)

                for (int i = 1; i < seeds.Length; i++) // the loop for sorting the experimental probabylity begins
                {
                    for (int f = 0; f < 14; f++)
                    {
                        gene11[f] = 0;
                    }

                    names2h = seeds[i].ToCharArray();

                    for (int k = 0; k < 14; k++)
                    {
                        if (names2h[k] == 'R')
                        {
                            gene11[0]++;
                        }

                        if (names2h[k] == 'r')
                        {
                            gene11[1]++;
                        }

                        if (names2h[k] == 'Y')
                        {
                            gene11[2]++;
                        }

                        if (names2h[k] == 'y')
                        {
                            gene11[3]++;
                        }
                        if (names2h[k] == 'G')
                        {
                            gene11[4]++;
                        }

                        if (names2h[k] == 'g')
                        {
                            gene11[5]++;
                        }

                        if (names2h[k] == 'C')
                        {
                            gene11[6]++;
                        }

                        if (names2h[k] == 'c')
                        {
                            gene11[7]++;
                        }
                        if (names2h[k] == 'P')
                        {
                            gene11[8]++;
                        }

                        if (names2h[k] == 'p')
                        {
                            gene11[9]++;
                        }

                        if (names2h[k] == 'A')
                        {
                            gene11[10]++;
                        }

                        if (names2h[k] == 'a')
                        {
                            gene11[11]++;
                        }

                        if (names2h[k] == 'T')
                        {
                            gene11[12]++;
                        }

                        if (names2h[k] == 't')
                        {
                            gene11[13]++;
                        }
                    }

                    for (int j = 0; j < names.Length; j++)
                    {
                        names3h = names[j].ToCharArray();

                        for (int k = 0; k < 14; k++)
                        {
                            gene12[k] = 0;
                        }

                        for (int h = 0; h < 14; h++)
                        {
                            if (names3h[h] == 'R')
                            {
                                gene12[0]++;
                            }

                            if (names3h[h] == 'r')
                            {
                                gene12[1]++;
                            }

                            if (names3h[h] == 'Y')
                            {
                                gene12[2]++;
                            }

                            if (names3h[h] == 'y')
                            {
                                gene12[3]++;
                            }
                            if (names3h[h] == 'G')
                            {
                                gene12[4]++;
                            }

                            if (names3h[h] == 'g')
                            {
                                gene12[5]++;
                            }

                            if (names3h[h] == 'C')
                            {
                                gene12[6]++;
                            }

                            if (names3h[h] == 'c')
                            {
                                gene12[7]++;
                            }
                            if (names3h[h] == 'P')
                            {
                                gene12[8]++;
                            }

                            if (names3h[h] == 'p')
                            {
                                gene12[9]++;
                            }

                            if (names3h[h] == 'A')
                            {
                                gene12[10]++;
                            }

                            if (names3h[h] == 'a')
                            {
                                gene12[11]++;
                            }

                            if (names3h[h] == 'T')
                            {
                                gene12[12]++;
                            }

                            if (names3h[h] == 't')
                            {
                                gene12[13]++;
                            }
                        }

                        if (gene11[0] == gene12[0] && gene11[1] == gene12[1] && gene11[2] == gene12[2] && gene11[3] == gene12[3] && gene11[4] == gene12[4] && gene11[5] == gene12[5] && gene11[6] == gene12[6] && gene11[7] == gene12[7] && gene11[8] == gene12[8] && gene11[9] == gene12[9] && gene11[10] == gene12[10] && gene11[11] == gene12[11] && gene11[12] == gene12[12] && gene11[13] == gene12[13])
                        {
                            times[j]++;
                            break;
                        }

                        else
                        {
                            if (j == names.Length - 1)
                            {
                                Array.Resize(ref names, names.Length + 1);
                                Array.Resize(ref times, times.Length + 1);

                                names[names.Length - 1] = seeds[i];
                                times[times.Length - 1] = 1;
                                break;
                            }
                        }
                    }
                }

                // the code for the sorting of the phenotype

                string[] names3 = new string[1]; // the unique phenotypes in the seeds array
                int[] times3 = new int[1]; // the numbers of times that each of the unique phenotypes occured

                names3[0] = phenotypedatacollector1[0];
                times3[0] = 1;

                for (int i = 1; i < phenotypedatacollector1.Length; i++) // the loop for sorting the experimental probabylity begins
                {
                    for (int j = 0; j < names3.Length; j++)
                    {
                        if (phenotypedatacollector1[i] == names3[j])
                        {
                            times3[j]++;
                            break;
                        }

                        else
                        {
                            if (j == names3.Length - 1)
                            {
                                Array.Resize(ref names3, names3.Length + 1);
                                Array.Resize(ref times3, times3.Length + 1);

                                names3[names3.Length - 1] = phenotypedatacollector1[i];
                                times3[times3.Length - 1] = 1;
                                break;
                            }
                        }
                    }
                }

                // the code for finding out the percents

                decimal seedsc = Convert.ToDecimal(textBox1.Text);

                decimal onepercent = seedsc / 100;

                decimal[] percent = new decimal[names.Length];

                for (int i = 0; i < times.Length; i++)
                {
                    percent[i] = Convert.ToDecimal(times[i]) / onepercent;
                }

                decimal[] percent2 = new decimal[names3.Length];

                for (int i = 0; i < times3.Length; i++)
                {
                    percent2[i] = Convert.ToDecimal(times3[i]) / onepercent;
                }

                // the code for the finding out the all the possible genotypes for the seeds that we get after crossing these particular parents

                string[] apo = new string[0]; // (all possible occurences) all the possible genotypes for the seeds that we get after crossing these particular parents 

                string[] phenotypedatacollector2 = new string[0]; // the phenotypes for apo

                char[] h21 = new char[0]; // a helper of the phenotype getting prosses of the array apo

                char[] help1 = new char[0]; // a helper of the genotype getting prosses of the array apo

                for (int i = 0; i < 2; i++) // the loop for the finding out the all the possible genotypes and their phenotypes for the seeds that we get after crossing these particular parents
                {
                    Array.Resize(ref apo, apo.Length + 1);
                    Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                    if (i == 0)
                    {
                        apo[apo.Length - 1] = g11[0];
                    }

                    else
                    {
                        apo[apo.Length - 1] = g11[1];
                    }

                    for (int j = 0; j < 2; j++)
                    {
                        help1 = apo[apo.Length - 1].ToCharArray();

                        if (j == 1)
                        {
                            Array.Resize(ref apo, apo.Length + 1);
                            Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                            for (int h = 0; h < 1; h++)
                            {
                                apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                            }

                            apo[apo.Length - 1] = apo[apo.Length - 1] + g21[1];
                        }

                        else
                        {
                            apo[apo.Length - 1] = apo[apo.Length - 1] + g21[0];
                        }

                        for (int k = 0; k < 2; k++)
                        {
                            help1 = apo[apo.Length - 1].ToCharArray();

                            if (k == 1)
                            {
                                Array.Resize(ref apo, apo.Length + 1);
                                Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                for (int h = 0; h < 2; h++)
                                {
                                    apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                }

                                apo[apo.Length - 1] = apo[apo.Length - 1] + g12[1];
                            }

                            else
                            {
                                apo[apo.Length - 1] = apo[apo.Length - 1] + g12[0];
                            }

                            for (int l = 0; l < 2; l++)
                            {
                                help1 = apo[apo.Length - 1].ToCharArray();

                                if (l == 1)
                                {
                                    Array.Resize(ref apo, apo.Length + 1);
                                    Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                    for (int h = 0; h < 3; h++)
                                    {
                                        apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                    }

                                    apo[apo.Length - 1] = apo[apo.Length - 1] + g22[1];
                                }

                                else
                                {
                                    apo[apo.Length - 1] = apo[apo.Length - 1] + g22[0];
                                }

                                for (int m = 0; m < 2; m++)
                                {
                                    help1 = apo[apo.Length - 1].ToCharArray();

                                    if (m == 1)
                                    {
                                        Array.Resize(ref apo, apo.Length + 1);
                                        Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                        for (int h = 0; h < 4; h++)
                                        {
                                            apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                        }

                                        apo[apo.Length - 1] = apo[apo.Length - 1] + g13[1];
                                    }

                                    else
                                    {
                                        apo[apo.Length - 1] = apo[apo.Length - 1] + g13[0];
                                    }

                                    for (int n = 0; n < 2; n++)
                                    {
                                        help1 = apo[apo.Length - 1].ToCharArray();

                                        if (n == 1)
                                        {
                                            Array.Resize(ref apo, apo.Length + 1);
                                            Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                            for (int h = 0; h < 5; h++)
                                            {
                                                apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                            }

                                            apo[apo.Length - 1] = apo[apo.Length - 1] + g23[1];
                                        }

                                        else
                                        {
                                            apo[apo.Length - 1] = apo[apo.Length - 1] + g23[0];
                                        }

                                        for (int o = 0; o < 2; o++)
                                        {
                                            help1 = apo[apo.Length - 1].ToCharArray();

                                            if (o == 1)
                                            {
                                                Array.Resize(ref apo, apo.Length + 1);
                                                Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                                for (int h = 0; h < 6; h++)
                                                {
                                                    apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                                }

                                                apo[apo.Length - 1] = apo[apo.Length - 1] + g14[1];
                                            }

                                            else
                                            {
                                                apo[apo.Length - 1] = apo[apo.Length - 1] + g14[0];
                                            }

                                            for (int q = 0; q < 2; q++)
                                            {
                                                help1 = apo[apo.Length - 1].ToCharArray();

                                                if (q == 1)
                                                {
                                                    Array.Resize(ref apo, apo.Length + 1);
                                                    Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                                    for (int h = 0; h < 7; h++)
                                                    {
                                                        apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                                    }

                                                    apo[apo.Length - 1] = apo[apo.Length - 1] + g24[1];
                                                }

                                                else
                                                {
                                                    apo[apo.Length - 1] = apo[apo.Length - 1] + g24[0];
                                                }

                                                for (int r = 0; r < 2; r++)
                                                {
                                                    help1 = apo[apo.Length - 1].ToCharArray();

                                                    if (r == 1)
                                                    {
                                                        Array.Resize(ref apo, apo.Length + 1);
                                                        Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                                        for (int h = 0; h < 8; h++)
                                                        {
                                                            apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                                        }

                                                        apo[apo.Length - 1] = apo[apo.Length - 1] + g15[1];
                                                    }

                                                    else
                                                    {
                                                        apo[apo.Length - 1] = apo[apo.Length - 1] + g15[0];
                                                    }

                                                    for (int s = 0; s < 2; s++)
                                                    {
                                                        help1 = apo[apo.Length - 1].ToCharArray();

                                                        if (s == 1)
                                                        {
                                                            Array.Resize(ref apo, apo.Length + 1);
                                                            Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                                            for (int h = 0; h < 9; h++)
                                                            {
                                                                apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                                            }

                                                            apo[apo.Length - 1] = apo[apo.Length - 1] + g25[1];
                                                        }

                                                        else
                                                        {
                                                            apo[apo.Length - 1] = apo[apo.Length - 1] + g25[0];
                                                        }

                                                        for (int t = 0; t < 2; t++)
                                                        {
                                                            help1 = apo[apo.Length - 1].ToCharArray();

                                                            if (t == 1)
                                                            {
                                                                Array.Resize(ref apo, apo.Length + 1);
                                                                Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                                                for (int h = 0; h < 10; h++)
                                                                {
                                                                    apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                                                }

                                                                apo[apo.Length - 1] = apo[apo.Length - 1] + g16[1];
                                                            }

                                                            else
                                                            {
                                                                apo[apo.Length - 1] = apo[apo.Length - 1] + g16[0];
                                                            }

                                                            for (int u = 0; u < 2; u++)
                                                            {
                                                                help1 = apo[apo.Length - 1].ToCharArray();

                                                                if (u == 1)
                                                                {
                                                                    Array.Resize(ref apo, apo.Length + 1);
                                                                    Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                                                    for (int h = 0; h < 11; h++)
                                                                    {
                                                                        apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                                                    }

                                                                    apo[apo.Length - 1] = apo[apo.Length - 1] + g26[1];
                                                                }

                                                                else
                                                                {
                                                                    apo[apo.Length - 1] = apo[apo.Length - 1] + g26[0];
                                                                }

                                                                for (int v = 0; v < 2; v++)
                                                                {
                                                                    help1 = apo[apo.Length - 1].ToCharArray();

                                                                    if (v == 1)
                                                                    {
                                                                        Array.Resize(ref apo, apo.Length + 1);
                                                                        Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                                                        for (int h = 0; h < 12; h++)
                                                                        {
                                                                            apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                                                        }

                                                                        apo[apo.Length - 1] = apo[apo.Length - 1] + g17[1];
                                                                    }

                                                                    else
                                                                    {
                                                                        apo[apo.Length - 1] = apo[apo.Length - 1] + g17[0];
                                                                    }

                                                                    for (int w = 0; w < 2; w++)
                                                                    {
                                                                        help1 = apo[apo.Length - 1].ToCharArray();

                                                                        if (w == 1)
                                                                        {
                                                                            Array.Resize(ref apo, apo.Length + 1);
                                                                            Array.Resize(ref phenotypedatacollector2, phenotypedatacollector2.Length + 1);

                                                                            for (int h = 0; h < 13; h++)
                                                                            {
                                                                                apo[apo.Length - 1] = apo[apo.Length - 1] + help1[h].ToString();
                                                                            }

                                                                            apo[apo.Length - 1] = apo[apo.Length - 1] + g27[1];
                                                                        }

                                                                        else
                                                                        {
                                                                            apo[apo.Length - 1] = apo[apo.Length - 1] + g27[0];
                                                                        }

                                                                        h21 = apo[apo.Length - 1].ToCharArray();

                                                                        for (int a = 0; a < h21.Length; a = a + 2)
                                                                        {
                                                                            p = a / 2;

                                                                            if (h21[a] == h21[a + 1])
                                                                            {
                                                                                phenotypedatacollector2[apo.Length - 1] = phenotypedatacollector2[apo.Length - 1] + h21[a].ToString();
                                                                            }

                                                                            else
                                                                            {
                                                                                if (h21[a] == 'r' | false | h21[a] == 'y' | false | h21[a] == 'g' | false | h21[a] == 'c' | false | h21[a] == 'p' | false | h21[a] == 'a' | false | h21[a] == 't')
                                                                                {
                                                                                    phenotypedatacollector2[apo.Length - 1] = phenotypedatacollector2[apo.Length - 1] + h21[a + 1].ToString();
                                                                                }

                                                                                else
                                                                                {
                                                                                    phenotypedatacollector2[apo.Length - 1] = phenotypedatacollector2[apo.Length - 1] + h21[a].ToString();
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                string[] names4 = new string[1]; // the unique phenotypes in the phenotypedatacollector2 array
                int[] times4 = new int[1]; // the numbers of times that each of the unique phenotypes occured

                names4[0] = phenotypedatacollector2[0];
                times4[0] = 1;

                for (int i = 1; i < phenotypedatacollector2.Length; i++) // the loop for sorting the experimental probabylity begins
                {
                    for (int j = 0; j < names4.Length; j++)
                    {
                        if (phenotypedatacollector2[i] == names4[j])
                        {
                            times4[j]++;
                            break;
                        }

                        else
                        {
                            if (j == names4.Length - 1)
                            {
                                Array.Resize(ref names4, names4.Length + 1);
                                Array.Resize(ref times4, times4.Length + 1);

                                names4[names4.Length - 1] = phenotypedatacollector2[i];
                                times4[times4.Length - 1] = 1;
                                break;
                            }
                        }
                    }
                }

                // the code for finding out the theoretical probability

                string[] names2 = new string[1]; // the unique theoretical genotypes, e.g. Rr = rR
                int[] times2 = new int[1]; // the number of times the theoretical unique theoretical genotypes occured genotypes

                char[] names4h = new char[0]; // the 14 cell array of characters, each char is taken from each possible genotype in the APO array
                char[] names5h = new char[0]; // the 14 cell array of characters, each char is taken from each genotype in the names2 array

                names2[0] = apo[0];
                times2[0] = 1;

                int[] gene21 = new int[14]; // the counter for the names4h array (the number times a particular character (e.g.'R') occured in the genotype, names4h)
                int[] gene22 = new int[14]; // the counter for the names5h array (the number times a particular character (e.g.'R') occured in the genotype, names5h)

                for (int i = 1; i < apo.Length; i++) // the loop for finding out the unique theoretically probable genotypes of the seeds in the apo array
                {
                    for (int j = 0; j < 14; j++)
                    {
                        gene21[j] = 0;
                    }

                    names4h = apo[i].ToCharArray(); // split a string from apo array into characters

                    for (int k = 0; k < 14; k++) // the  
                    {
                        if (names4h[k] == 'R')
                        {
                            gene21[0]++;
                        }

                        if (names4h[k] == 'r')
                        {
                            gene21[1]++;
                        }

                        if (names4h[k] == 'Y')
                        {
                            gene21[2]++;
                        }

                        if (names4h[k] == 'y')
                        {
                            gene21[3]++;
                        }

                        if (names4h[k] == 'G')
                        {
                            gene21[4]++;
                        }

                        if (names4h[k] == 'g')
                        {
                            gene21[5]++;
                        }

                        if (names4h[k] == 'C')
                        {
                            gene21[6]++;
                        }

                        if (names4h[k] == 'c')
                        {
                            gene21[7]++;
                        }

                        if (names4h[k] == 'P')
                        {
                            gene21[8]++;
                        }

                        if (names4h[k] == 'p')
                        {
                            gene21[9]++;
                        }

                        if (names4h[k] == 'A')
                        {
                            gene21[10]++;
                        }

                        if (names4h[k] == 'a')
                        {
                            gene21[11]++;
                        }

                        if (names4h[k] == 'T')
                        {
                            gene21[12]++;
                        }

                        if (names4h[k] == 't')
                        {
                            gene21[13]++;
                        }
                    }

                    for (int j = 0; j < names2.Length; j++)
                    {
                        names5h = names2[j].ToCharArray();

                        for (int k = 0; k < 14; k++)
                        {
                            gene22[k] = 0;
                        }

                        for (int h = 0; h < 14; h++)
                        {
                            if (names5h[h] == 'R')
                            {
                                gene22[0]++;
                            }

                            if (names5h[h] == 'r')
                            {
                                gene22[1]++;
                            }

                            if (names5h[h] == 'Y')
                            {
                                gene22[2]++;
                            }

                            if (names5h[h] == 'y')
                            {
                                gene22[3]++;
                            }

                            if (names5h[h] == 'G')
                            {
                                gene22[4]++;
                            }

                            if (names5h[h] == 'g')
                            {
                                gene22[5]++;
                            }

                            if (names5h[h] == 'C')
                            {
                                gene22[6]++;
                            }

                            if (names5h[h] == 'c')
                            {
                                gene22[7]++;
                            }

                            if (names5h[h] == 'P')
                            {
                                gene22[8]++;
                            }

                            if (names5h[h] == 'p')
                            {
                                gene22[9]++;
                            }

                            if (names5h[h] == 'A')
                            {
                                gene22[10]++;
                            }

                            if (names5h[h] == 'a')
                            {
                                gene22[11]++;
                            }

                            if (names5h[h] == 'T')
                            {
                                gene22[12]++;
                            }

                            if (names5h[h] == 't')
                            {
                                gene22[13]++;
                            }
                        }

                        if (gene21[0] == gene22[0] && gene21[1] == gene22[1] && gene21[2] == gene22[2] && gene21[3] == gene22[3] && gene21[4] == gene22[4] && gene21[5] == gene22[5] && gene21[6] == gene22[6] && gene21[7] == gene22[7] && gene21[8] == gene22[8] && gene21[9] == gene22[9] && gene21[10] == gene22[10] && gene21[11] == gene22[11] && gene21[12] == gene22[12] && gene21[13] == gene22[13])
                        {
                            times2[j]++;
                            break;
                        }

                        else
                        {
                            if (j == names2.Length - 1)
                            {
                                Array.Resize(ref names2, names2.Length + 1);
                                Array.Resize(ref times2, times2.Length + 1);

                                names2[names2.Length - 1] = apo[i];
                                times2[times2.Length - 1] = 1;
                                break;
                            }
                        }
                    }
                }

                int help4 = 0; // the number that shows if the theoretical probability is correct

                for (int i = 0; i < times2.Length; i++)
                {
                    help4 = help4 + times2[i];
                }

                // the theoretical probability printing

                int g = 0; // the substitute of Array.Resize action

                string[] seeds2 = new string[names.Length]; // the names of the theoretical genotypes encountered in the experimantal array
                int[] timesseeds2 = new int[names.Length]; // the numbers of times unique theoretical genotypes occured in the experimental array

                char[] nvsah2 = new char[0]; // (names2 vs apo helper 2)the second helper of finding the unique genotypes in the names2 array, that equall to the experimentall uinque genotypes
                char[] nvsah1 = new char[0]; // (names2 vs apo helper 1)the first helper of finding the unique genotypes in the names2 array, that equall to the experimentall uinque genotypes

                int[] gene31 = new int[14]; // the counter of nvsah1(how many times has the char 'R' occured and so on)
                int[] gene32 = new int[14]; // the counter of nvsah2(how many times has the char 'R' occured and so on)

                for (int i = 0; i < names.Length; i++) // the loop for the theoretical probability printing begins
                {
                    for (int f = 0; f < 14; f++)
                    {
                        gene31[f] = 0;
                    }

                    nvsah2 = names[i].ToCharArray();

                    for (int k = 0; k < nvsah2.Length; k++)
                    {
                        if (nvsah2[k] == 'R')
                        {
                            gene31[0]++;
                        }

                        if (nvsah2[k] == 'r')
                        {
                            gene31[1]++;
                        }

                        if (nvsah2[k] == 'Y')
                        {
                            gene31[2]++;
                        }

                        if (nvsah2[k] == 'y')
                        {
                            gene31[3]++;
                        }

                        if (nvsah2[k] == 'G')
                        {
                            gene31[4]++;
                        }

                        if (nvsah2[k] == 'g')
                        {
                            gene31[5]++;
                        }

                        if (nvsah2[k] == 'C')
                        {
                            gene31[6]++;
                        }

                        if (nvsah2[k] == 'c')
                        {
                            gene31[7]++;
                        }

                        if (nvsah2[k] == 'P')
                        {
                            gene31[8]++;
                        }

                        if (nvsah2[k] == 'p')
                        {
                            gene31[9]++;
                        }

                        if (nvsah2[k] == 'A')
                        {
                            gene31[10]++;
                        }

                        if (nvsah2[k] == 'a')
                        {
                            gene31[11]++;
                        }

                        if (nvsah2[k] == 'T')
                        {
                            gene31[12]++;
                        }

                        if (nvsah2[k] == 't')
                        {
                            gene31[13]++;
                        }
                    }

                    for (int j = 0; j < names2.Length; j++)
                    {
                        nvsah1 = names2[j].ToCharArray();

                        for (int k = 0; k < 14; k++)
                        {
                            gene32[k] = 0;
                        }

                        for (int f = 0; f < nvsah1.Length; f++)
                        {
                            if (nvsah1[f] == 'R')
                            {
                                gene32[0]++;
                            }

                            if (nvsah1[f] == 'r')
                            {
                                gene32[1]++;
                            }

                            if (nvsah1[f] == 'Y')
                            {
                                gene32[2]++;
                            }

                            if (nvsah1[f] == 'y')
                            {
                                gene32[3]++;
                            }

                            if (nvsah1[f] == 'G')
                            {
                                gene32[4]++;
                            }

                            if (nvsah1[f] == 'g')
                            {
                                gene32[5]++;
                            }

                            if (nvsah1[f] == 'C')
                            {
                                gene32[6]++;
                            }

                            if (nvsah1[f] == 'c')
                            {
                                gene32[7]++;
                            }

                            if (nvsah1[f] == 'P')
                            {
                                gene32[8]++;
                            }

                            if (nvsah1[f] == 'p')
                            {
                                gene32[9]++;
                            }

                            if (nvsah1[f] == 'A')
                            {
                                gene32[10]++;
                            }

                            if (nvsah1[f] == 'a')
                            {
                                gene32[11]++;
                            }

                            if (nvsah1[f] == 'T')
                            {
                                gene32[12]++;
                            }

                            if (nvsah1[f] == 't')
                            {
                                gene32[13]++;
                            }
                        }

                        if (gene31[0] == gene32[0] && gene31[1] == gene32[1] && gene31[2] == gene32[2] && gene31[3] == gene32[3] && gene31[4] == gene32[4] && gene31[5] == gene32[5] && gene31[6] == gene32[6] && gene31[7] == gene32[7] && gene31[8] == gene32[8] && gene31[9] == gene32[9] && gene31[10] == gene32[10] && gene31[11] == gene32[11] && gene31[12] == gene32[12] && gene31[13] == gene32[13])
                        {
                            seeds2[g] = names2[j];
                            timesseeds2[g] = times2[j];
                            g++;
                            break;
                        }
                    }
                }

                int dh = 0;

                string[] phenotype2 = new string[names.Length]; // the names of the theoretical phenotypes encountered in the experimantal array
                int[] timesphenotype2 = new int[names.Length]; // the numbers of times unique theoretical phenotypes occured in the experimental array

                for (int i = 0; i < names3.Length; i++) // the loop for the theoretical probability printing begins
                {
                    for (int j = 0; j < names4.Length; j++)
                    {
                        if (names3[i] == names4[j])
                        {
                            phenotype2[dh] = names4[j];
                            timesphenotype2[dh] = times4[j];
                            dh++;
                            break;
                        }
                    }
                }

                string[] data2 = new string[times.Length]; // a data printer

                for (int i = 0; i < times.Length; i++)
                {
                    data2[i] = names[i] + " - " + times[i].ToString() + "/" + Convert.ToUInt64(textBox1.Text).ToString() + " - " + timesseeds2[i].ToString() + "/" + apo.Length.ToString() + " - " + percent[i] + "%";
                }

                string[] data3 = new string[times3.Length];

                for (int i = 0; i < times3.Length; i++)
                {
                    data3[i] = names3[i] + " - " + times3[i].ToString() + "/" + Convert.ToUInt64(textBox1.Text).ToString() + " - " + timesphenotype2[i].ToString() + "/" + phenotypedatacollector2.Length.ToString() + " - " + percent2[i] + "%";
                }

                string[] sorteddata2 = new string[data2.Length];

                int[] sortedtimes = new int[times.Length];

                int or = 0; // orientation in the sorteddata2 array and in the sortedtimes array
                int[] or2 = new int[0]; // orientation in the times array

                bool or2h = false;

                int maxnum = 0;

                int orh = 0;

                for (int j = 0; sorteddata2[sorteddata2.Length - 1] == null; j++)
                {
                    maxnum = 0;

                    for (int i = 0; i < times.Length; i++)
                    {
                        or2h = false;

                        for (int k = 0; k < or2.Length; k++)
                        {
                            if (or2[k] == i)
                            {
                                or2h = true;
                                break;
                            }
                        }

                        if (or2h == false && times[i] >= maxnum)
                        {
                            maxnum = times[i];
                            orh = i;
                        }

                        if (i == times.Length - 1)
                        {
                            sortedtimes[or] = times[orh];
                            sorteddata2[or] = data2[orh];

                            Array.Resize(ref or2, or2.Length + 1);
                            or2[or2.Length - 1] = orh;

                            or++;
                        }
                    }
                }

                string[] sorteddata3 = new string[data3.Length];

                int[] sortedtimes2 = new int[data3.Length];

                int or3 = 0; // orientation in the sorteddata2 array and in the sortedtimes array
                int[] or4 = new int[0]; // orientation in the times array

                bool or4h = false;

                int maxnum2 = 0;

                int orh2 = 0;

                for (int j = 0; sorteddata3[sorteddata3.Length - 1] == null; j++)
                {
                    maxnum2 = 0;

                    for (int i = 0; i < times3.Length; i++)
                    {
                        or4h = false;

                        for (int k = 0; k < or4.Length; k++)
                        {
                            if (or4[k] == i)
                            {
                                or4h = true;
                                break;
                            }
                        }

                        if (or4h == false && times3[i] >= maxnum2)
                        {
                            maxnum2 = times3[i];
                            orh2 = i;
                        }

                        if (i == times3.Length - 1)
                        {
                            sortedtimes2[or3] = times3[orh2];
                            sorteddata3[or3] = data3[orh2];

                            Array.Resize(ref or4, or4.Length + 1);
                            or4[or4.Length - 1] = orh2;

                            or3++;
                        }
                    }
                }

                // every data getting and analysing prosses has finished and the data printing begins

                string unsortedans = "All the data:\r\n\r\ngenotype - times - theoretical probability - 100%\r\n" + String.Join("\r\n", data2);
                string unsortedans2 = "phenotype - times - theoretical probability - 100 %\r\n" + String.Join("\r\n", data3);

                string sortedans = "All the data, sorted:\r\n\r\ngenotype - times - theoretical probability - 100%\r\n" + String.Join("\r\n", sorteddata2);
                string sortedans2 = "phenotype - times - theoretical probability - 100%\r\n" + String.Join("\r\n", sorteddata3);

                if (seeds.Length < 2)
                {
                    textBox2.Text = "Out of " + seeds.Length.ToString() + " seed there is " + data2.Length.ToString() + " unique genotype and " + data3.Length.ToString() + " unique phenotype.\r\n\r\n" + sortedans + "\r\n\r\n" + sortedans2 + "\r\n\r\n" + unsortedans + "\r\n\r\n" + unsortedans2 + "\r\nRaw data:\r\n\r\n" + rawans;
                }

                if (seeds.Length > 1 && data2.Length < 2 && data3.Length > 1)
                {
                    textBox2.Text = "Out of " + seeds.Length.ToString() + " seeds there is " + data2.Length.ToString() + " unique genotype and " + data3.Length.ToString() + " unique phenotypes.\r\n\r\n" + sortedans + "\r\n\r\n" + sortedans2 + "\r\n\r\n" + unsortedans + "\r\n\r\n" + unsortedans2 + "\r\nRaw data:\r\n\r\n" + rawans;
                }

                if (seeds.Length > 1 && data2.Length > 1 && data3.Length < 2)
                {
                    textBox2.Text = "Out of " + seeds.Length.ToString() + " seeds there are " + data2.Length.ToString() + " unique genotypes and " + data3.Length.ToString() + " unique phenotype.\r\n\r\n" + sortedans + "\r\n\r\n" + sortedans2 + "\r\n\r\n" + unsortedans + "\r\n\r\n" + unsortedans2 + "\r\nRaw data:\r\n\r\n" + rawans;
                }

                if (seeds.Length > 1 && data2.Length > 1 && data3.Length > 1)
                {
                    textBox2.Text = "Out of " + seeds.Length.ToString() + " seeds there are " + data2.Length.ToString() + " unique genotypes and " + data3.Length.ToString() + " unique phenotypes.\r\n\r\n" + sortedans + "\r\n\r\n" + sortedans2 + "\r\n\r\n" + unsortedans + "\r\n\r\n" + unsortedans2 + "\r\nRaw data:\r\n\r\n" + rawans;
                }
            }
        }

        private void checkBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox271.Checked == false && checkBox272.Checked == false && checkBox273.Checked == false && checkBox274.Checked == true)
            {
                mem27[3] = 1;
            }

            if (checkBox271.Checked == false && checkBox272.Checked == false && checkBox273.Checked == false && checkBox274.Checked == false)
            {
                mem27[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem27.Length; i++)
            {
                if (mem27[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox274.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem27[3] = 2;
                    }

                    else
                    {
                        mem27[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem27.Length - 1; i++)
                    {
                        if (mem27[i] == 2)
                        {
                            mem27[i] = 0;

                            if (i == 0)
                            {
                                checkBox271.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox272.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox273.Checked = false;
                                break;
                            }
                        }
                    }

                    mem27[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem27[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem27.Length; i++)
                    {
                        if (mem27[i] == 1)
                        {
                            mem27[i] = 1;
                            break;
                        }
                    }

                    mem27[3] = 0;
                }
            }

            g27[0] = "";
            g27[1] = "";

            if (checkBox271.Checked == true)
            {
                g27[0] = checkBox271.Text;
            }

            if (checkBox272.Checked == true)
            {
                g27[1] = checkBox272.Text;
            }

            if (checkBox273.Checked == true)
            {
                if ((g27[0] == "" && g27[1] == "") == false)
                {
                    if (g27[0] == "")
                    {
                        g27[0] = checkBox273.Text;
                    }

                    if (g27[1] == "")
                    {
                        g27[1] = checkBox273.Text;
                    }
                }

                else
                {
                    g27[0] = checkBox273.Text;
                }
            }

            if (checkBox274.Checked == true)
            {
                if ((g27[0] == "" && g27[1] == "") == false)
                {
                    if (g27[0] == "")
                    {
                        g27[0] = checkBox274.Text;
                    }

                    if (g27[1] == "")
                    {
                        g27[1] = checkBox274.Text;
                    }
                }

                else
                {
                    g27[1] = checkBox274.Text;
                }
            }

            label27.Text = String.Join("", g27);

            pictureBox271.Visible = false;
            pictureBox272.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g27[i] == "" | false | g27[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g27[0] == g27[1])
                {
                    if (g27[0] == "T")
                    {
                        pictureBox271.Visible = true;
                    }

                    else
                    {
                        pictureBox272.Visible = true;
                    }
                }

                else
                {
                    pictureBox271.Visible = true;
                }
            }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox111.Checked == false && checkBox112.Checked == false && checkBox113.Checked == true && checkBox114.Checked == false)
            {
                mem11[2] = 1;
            }

            if (checkBox111.Checked == false && checkBox112.Checked == false && checkBox113.Checked == false && checkBox114.Checked == false)
            {
                mem11[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem11.Length; i++)
            {
                if (mem11[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox113.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem11[2] = 2;
                    }

                    else
                    {
                        mem11[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem11.Length; i++)
                    {
                        if (mem11[i] == 2)
                        {
                            mem11[i] = 0;

                            if (i == 0)
                            {
                                checkBox111.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox112.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox114.Checked = false;
                                break;
                            }
                        }
                    }

                    mem11[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem11[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem11.Length; i++)
                    {
                        if (mem11[i] == 1)
                        {
                            mem11[i] = 1;
                            break;
                        }
                    }

                    mem11[2] = 0;
                }
            }

            g11[0] = "";
            g11[1] = "";

            if (checkBox111.Checked == true)
            {
                g11[0] = checkBox111.Text;
            }

            if (checkBox112.Checked == true)
            {
                g11[1] = checkBox112.Text;
            }

            if (checkBox113.Checked == true)
            {
                if ((g11[0] == "" && g11[1] == "") == false)
                {
                    if (g11[0] == "")
                    {
                        g11[0] = checkBox113.Text;
                    }

                    if (g11[1] == "")
                    {
                        g11[1] = checkBox113.Text;
                    }
                }

                else
                {
                    g11[0] = checkBox113.Text;
                }
            }

            if (checkBox114.Checked == true)
            {
                if ((g11[0] == "" && g11[1] == "") == false)
                {
                    if (g11[0] == "")
                    {
                        g11[0] = checkBox114.Text;
                    }

                    if (g11[1] == "")
                    {
                        g11[1] = checkBox114.Text;
                    }
                }

                else
                {
                    g11[1] = checkBox114.Text;
                }
            }

            label11.Text = String.Join("", g11);

            pictureBox111.Visible = false;
            pictureBox112.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g11[i] == "" | false | g11[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
                pictureBox111.Visible = false;
            }

            else
            {
                if (g11[0] == g11[1])
                {
                    if (g11[0] == "R")
                    {
                        pictureBox111.Visible = true;
                    }

                    else
                    {
                        pictureBox112.Visible = true;
                    }
                }

                else
                {
                    pictureBox111.Visible = true;
                }
            }
        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox111.Checked == false && checkBox112.Checked == false && checkBox113.Checked == false && checkBox114.Checked == true)
            {
                mem11[3] = 1;
            }

            if (checkBox111.Checked == false && checkBox112.Checked == false && checkBox113.Checked == false && checkBox114.Checked == false)
            {
                mem11[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem11.Length; i++)
            {
                if (mem11[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox114.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem11[3] = 2;
                    }

                    else
                    {
                        mem11[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem11.Length - 1; i++)
                    {
                        if (mem11[i] == 2)
                        {
                            mem11[i] = 0;

                            if (i == 0)
                            {
                                checkBox111.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox112.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox113.Checked = false;
                                break;
                            }
                        }
                    }

                    mem11[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem11[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem11.Length; i++)
                    {
                        if (mem11[i] == 1)
                        {
                            mem11[i] = 1;
                            break;
                        }
                    }

                    mem11[3] = 0;
                }
            }

            g11[0] = "";
            g11[1] = "";

            if (checkBox111.Checked == true)
            {
                g11[0] = checkBox111.Text;
            }

            if (checkBox112.Checked == true)
            {
                g11[1] = checkBox112.Text;
            }

            if (checkBox113.Checked == true)
            {
                if ((g11[0] == "" && g11[1] == "") == false)
                {
                    if (g11[0] == "")
                    {
                        g11[0] = checkBox113.Text;
                    }

                    if (g11[1] == "")
                    {
                        g11[1] = checkBox113.Text;
                    }
                }

                else
                {
                    g11[0] = checkBox113.Text;
                }
            }

            if (checkBox114.Checked == true)
            {
                if ((g11[0] == "" && g11[1] == "") == false)
                {
                    if (g11[0] == "")
                    {
                        g11[0] = checkBox114.Text;
                    }

                    if (g11[1] == "")
                    {
                        g11[1] = checkBox114.Text;
                    }
                }

                else
                {
                    g11[1] = checkBox114.Text;
                }
            }

            label11.Text = String.Join("", g11);

            pictureBox111.Visible = false;
            pictureBox112.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g11[i] == "" | false | g11[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
                pictureBox111.Visible = false;
            }

            else
            {
                if (g11[0] == g11[1])
                {
                    if (g11[0] == "R")
                    {
                        pictureBox111.Visible = true;
                    }

                    else
                    {
                        pictureBox112.Visible = true;
                    }
                }

                else
                {
                    pictureBox111.Visible = true;
                }
            }
        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox121.Checked == false && checkBox122.Checked == false && checkBox123.Checked == true && checkBox124.Checked == false)
            {
                mem12[2] = 1;
            }

            if (checkBox121.Checked == false && checkBox122.Checked == false && checkBox123.Checked == false && checkBox124.Checked == false)
            {
                mem12[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem12.Length; i++)
            {
                if (mem12[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox123.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem12[2] = 2;
                    }

                    else
                    {
                        mem12[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem12.Length; i++)
                    {
                        if (mem12[i] == 2)
                        {
                            mem12[i] = 0;

                            if (i == 0)
                            {
                                checkBox121.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox122.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox124.Checked = false;
                                break;
                            }
                        }
                    }

                    mem12[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem12[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem12.Length; i++)
                    {
                        if (mem12[i] == 1)
                        {
                            mem12[i] = 1;
                            break;
                        }
                    }

                    mem12[2] = 0;
                }
            }

            g12[0] = "";
            g12[1] = "";

            if (checkBox121.Checked == true)
            {
                g12[0] = checkBox121.Text;
            }

            if (checkBox122.Checked == true)
            {
                g12[1] = checkBox122.Text;
            }

            if (checkBox123.Checked == true)
            {
                if ((g12[0] == "" && g12[1] == "") == false)
                {
                    if (g12[0] == "")
                    {
                        g12[0] = checkBox123.Text;
                    }

                    if (g12[1] == "")
                    {
                        g12[1] = checkBox123.Text;
                    }
                }

                else
                {
                    g12[0] = checkBox123.Text;
                }
            }

            if (checkBox124.Checked == true)
            {
                if ((g12[0] == "" && g12[1] == "") == false)
                {
                    if (g12[0] == "")
                    {
                        g12[0] = checkBox124.Text;
                    }

                    if (g12[1] == "")
                    {
                        g12[1] = checkBox124.Text;
                    }
                }

                else
                {
                    g12[1] = checkBox124.Text;
                }
            }

            label12.Text = String.Join("", g12);

            pictureBox121.Visible = false;
            pictureBox122.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g12[i] == "" | false | g12[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g12[0] == g12[1])
                {
                    if (g12[0] == "Y")
                    {
                        pictureBox121.Visible = true;
                    }

                    else
                    {
                        pictureBox122.Visible = true;
                    }
                }

                else
                {
                    pictureBox121.Visible = true;
                }
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox121.Checked == false && checkBox122.Checked == false && checkBox123.Checked == false && checkBox124.Checked == true)
            {
                mem12[3] = 1;
            }

            if (checkBox121.Checked == false && checkBox122.Checked == false && checkBox123.Checked == false && checkBox124.Checked == false)
            {
                mem12[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem12.Length - 1; i++)
            {
                if (mem12[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox124.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem12[3] = 2;
                    }

                    else
                    {
                        mem12[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem12.Length; i++)
                    {
                        if (mem12[i] == 2)
                        {
                            mem12[i] = 0;

                            if (i == 0)
                            {
                                checkBox121.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox122.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox123.Checked = false;
                                break;
                            }
                        }
                    }

                    mem12[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem12[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem12.Length; i++)
                    {
                        if (mem12[i] == 1)
                        {
                            mem12[i] = 1;
                            break;
                        }
                    }

                    mem12[3] = 0;
                }
            }

            g12[0] = "";
            g12[1] = "";

            if (checkBox121.Checked == true)
            {
                g12[0] = checkBox121.Text;
            }

            if (checkBox122.Checked == true)
            {
                g12[1] = checkBox122.Text;
            }

            if (checkBox123.Checked == true)
            {
                if ((g12[0] == "" && g12[1] == "") == false)
                {
                    if (g12[0] == "")
                    {
                        g12[0] = checkBox123.Text;
                    }

                    if (g12[1] == "")
                    {
                        g12[1] = checkBox123.Text;
                    }
                }

                else
                {
                    g12[0] = checkBox123.Text;
                }
            }

            if (checkBox124.Checked == true)
            {
                if ((g12[0] == "" && g12[1] == "") == false)
                {
                    if (g12[0] == "")
                    {
                        g12[0] = checkBox124.Text;
                    }

                    if (g12[1] == "")
                    {
                        g12[1] = checkBox124.Text;
                    }
                }

                else
                {
                    g12[1] = checkBox124.Text;
                }
            }

            label12.Text = String.Join("", g12);

            pictureBox121.Visible = false;
            pictureBox122.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g12[i] == "" | false | g12[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g12[0] == g12[1])
                {
                    if (g12[0] == "Y")
                    {
                        pictureBox121.Visible = true;
                    }

                    else
                    {
                        pictureBox122.Visible = true;
                    }
                }

                else
                {
                    pictureBox121.Visible = true;
                }
            }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox131.Checked == false && checkBox132.Checked == false && checkBox133.Checked == true && checkBox134.Checked == false)
            {
                mem13[2] = 1;
            }

            if (checkBox131.Checked == false && checkBox132.Checked == false && checkBox133.Checked == false && checkBox134.Checked == false)
            {
                mem13[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem13.Length; i++)
            {
                if (mem13[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox133.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem13[2] = 2;
                    }

                    else
                    {
                        mem13[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem13.Length; i++)
                    {
                        if (mem13[i] == 2)
                        {
                            mem13[i] = 0;

                            if (i == 0)
                            {
                                checkBox131.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox132.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox134.Checked = false;
                                break;
                            }
                        }
                    }

                    mem13[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem13[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem13.Length; i++)
                    {
                        if (mem13[i] == 1)
                        {
                            mem13[i] = 1;
                            break;
                        }
                    }

                    mem13[2] = 0;
                }
            }

            g13[0] = "";
            g13[1] = "";

            if (checkBox131.Checked == true)
            {
                g13[0] = checkBox131.Text;
            }

            if (checkBox132.Checked == true)
            {
                g13[1] = checkBox132.Text;
            }

            if (checkBox133.Checked == true)
            {
                if ((g13[0] == "" && g13[1] == "") == false)
                {
                    if (g13[0] == "")
                    {
                        g13[0] = checkBox133.Text;
                    }

                    if (g13[1] == "")
                    {
                        g13[1] = checkBox133.Text;
                    }
                }

                else
                {
                    g13[0] = checkBox133.Text;
                }
            }

            if (checkBox134.Checked == true)
            {
                if ((g13[0] == "" && g13[1] == "") == false)
                {
                    if (g13[0] == "")
                    {
                        g13[0] = checkBox134.Text;
                    }

                    if (g13[1] == "")
                    {
                        g13[1] = checkBox134.Text;
                    }
                }

                else
                {
                    g13[1] = checkBox134.Text;
                }
            }

            label13.Text = String.Join("", g13);

            pictureBox131.Visible = false;
            pictureBox132.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g13[i] == "" | false | g13[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g13[0] == g13[1])
                {
                    if (g13[0] == "G")
                    {
                        pictureBox131.Visible = true;
                    }

                    else
                    {
                        pictureBox132.Visible = true;
                    }
                }

                else
                {
                    pictureBox131.Visible = true;
                }
            }
        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox131.Checked == false && checkBox132.Checked == false && checkBox133.Checked == false && checkBox134.Checked == true)
            {
                mem13[3] = 1;
            }

            if (checkBox131.Checked == false && checkBox132.Checked == false && checkBox133.Checked == false && checkBox134.Checked == false)
            {
                mem13[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem13.Length; i++)
            {
                if (mem13[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox134.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem13[3] = 2;
                    }

                    else
                    {
                        mem13[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem13.Length - 1; i++)
                    {
                        if (mem13[i] == 2)
                        {
                            mem13[i] = 0;

                            if (i == 0)
                            {
                                checkBox131.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox132.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox133.Checked = false;
                                break;
                            }
                        }
                    }

                    mem13[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem13[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem13.Length; i++)
                    {
                        if (mem13[i] == 1)
                        {
                            mem13[i] = 1;
                            break;
                        }
                    }

                    mem13[3] = 0;
                }
            }

            g13[0] = "";
            g13[1] = "";

            if (checkBox131.Checked == true)
            {
                g13[0] = checkBox131.Text;
            }

            if (checkBox132.Checked == true)
            {
                g13[1] = checkBox132.Text;
            }

            if (checkBox133.Checked == true)
            {
                if ((g13[0] == "" && g13[1] == "") == false)
                {
                    if (g13[0] == "")
                    {
                        g13[0] = checkBox133.Text;
                    }

                    if (g13[1] == "")
                    {
                        g13[1] = checkBox133.Text;
                    }
                }

                else
                {
                    g13[0] = checkBox133.Text;
                }
            }

            if (checkBox134.Checked == true)
            {
                if ((g13[0] == "" && g13[1] == "") == false)
                {
                    if (g13[0] == "")
                    {
                        g13[0] = checkBox134.Text;
                    }

                    if (g13[1] == "")
                    {
                        g13[1] = checkBox134.Text;
                    }
                }

                else
                {
                    g13[1] = checkBox134.Text;
                }
            }

            label13.Text = String.Join("", g13);

            pictureBox131.Visible = false;
            pictureBox132.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g13[i] == "" | false | g13[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g13[0] == g13[1])
                {
                    if (g13[0] == "G")
                    {
                        pictureBox131.Visible = true;
                    }

                    else
                    {
                        pictureBox132.Visible = true;
                    }
                }

                else
                {
                    pictureBox131.Visible = true;
                }
            }
        }

        private void checkBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox141.Checked == false && checkBox142.Checked == false && checkBox143.Checked == true && checkBox144.Checked == false)
            {
                mem14[2] = 1;
            }

            if (checkBox141.Checked == false && checkBox142.Checked == false && checkBox143.Checked == false && checkBox144.Checked == false)
            {
                mem14[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem14.Length; i++)
            {
                if (mem14[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox143.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem14[2] = 2;
                    }

                    else
                    {
                        mem14[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem14.Length; i++)
                    {
                        if (mem14[i] == 2)
                        {
                            mem14[i] = 0;

                            if (i == 0)
                            {
                                checkBox141.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox142.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox144.Checked = false;
                                break;
                            }
                        }
                    }

                    mem14[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem14[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem14.Length; i++)
                    {
                        if (mem14[i] == 1)
                        {
                            mem14[i] = 1;
                            break;
                        }
                    }

                    mem14[2] = 0;
                }
            }

            g14[0] = "";
            g14[1] = "";

            if (checkBox141.Checked == true)
            {
                g14[0] = checkBox141.Text;
            }

            if (checkBox142.Checked == true)
            {
                g14[1] = checkBox142.Text;
            }

            if (checkBox143.Checked == true)
            {
                if ((g14[0] == "" && g14[1] == "") == false)
                {
                    if (g14[0] == "")
                    {
                        g14[0] = checkBox143.Text;
                    }

                    if (g14[1] == "")
                    {
                        g14[1] = checkBox143.Text;
                    }
                }

                else
                {
                    g14[0] = checkBox143.Text;
                }
            }

            if (checkBox144.Checked == true)
            {
                if ((g14[0] == "" && g14[1] == "") == false)
                {
                    if (g14[0] == "")
                    {
                        g14[0] = checkBox144.Text;
                    }

                    if (g14[1] == "")
                    {
                        g14[1] = checkBox144.Text;
                    }
                }

                else
                {
                    g14[1] = checkBox144.Text;
                }
            }

            label14.Text = String.Join("", g14);

            pictureBox141.Visible = false;
            pictureBox142.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g14[i] == "" | false | g14[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g14[0] == g14[1])
                {
                    if (g14[0] == "C")
                    {
                        pictureBox141.Visible = true;
                    }

                    else
                    {
                        pictureBox142.Visible = true;
                    }
                }

                else
                {
                    pictureBox141.Visible = true;
                }
            }
        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox141.Checked == false && checkBox142.Checked == false && checkBox143.Checked == false && checkBox144.Checked == true)
            {
                mem14[3] = 1;
            }

            if (checkBox141.Checked == false && checkBox142.Checked == false && checkBox143.Checked == false && checkBox144.Checked == false)
            {
                mem14[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem14.Length; i++)
            {
                if (mem14[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox144.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem14[3] = 2;
                    }

                    else
                    {
                        mem14[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem14.Length - 1; i++)
                    {
                        if (mem14[i] == 2)
                        {
                            mem14[i] = 0;

                            if (i == 0)
                            {
                                checkBox141.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox142.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox143.Checked = false;
                                break;
                            }
                        }
                    }

                    mem14[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem14[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem14.Length; i++)
                    {
                        if (mem14[i] == 1)
                        {
                            mem14[i] = 1;
                            break;
                        }
                    }

                    mem14[3] = 0;
                }
            }

            g14[0] = "";
            g14[1] = "";

            if (checkBox141.Checked == true)
            {
                g14[0] = checkBox141.Text;
            }

            if (checkBox142.Checked == true)
            {
                g14[1] = checkBox142.Text;
            }

            if (checkBox143.Checked == true)
            {
                if ((g14[0] == "" && g14[1] == "") == false)
                {
                    if (g14[0] == "")
                    {
                        g14[0] = checkBox143.Text;
                    }

                    if (g14[1] == "")
                    {
                        g14[1] = checkBox143.Text;
                    }
                }

                else
                {
                    g14[0] = checkBox143.Text;
                }
            }

            if (checkBox144.Checked == true)
            {
                if ((g14[0] == "" && g14[1] == "") == false)
                {
                    if (g14[0] == "")
                    {
                        g14[0] = checkBox144.Text;
                    }

                    if (g14[1] == "")
                    {
                        g14[1] = checkBox144.Text;
                    }
                }

                else
                {
                    g14[1] = checkBox144.Text;
                }
            }

            label14.Text = String.Join("", g14);

            pictureBox141.Visible = false;
            pictureBox142.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g14[i] == "" | false | g14[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g14[0] == g14[1])
                {
                    if (g14[0] == "C")
                    {
                        pictureBox141.Visible = true;
                    }

                    else
                    {
                        pictureBox142.Visible = true;
                    }
                }

                else
                {
                    pictureBox141.Visible = true;
                }
            }
        }

        private void checkBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox151.Checked == false && checkBox152.Checked == false && checkBox153.Checked == true && checkBox154.Checked == false)
            {
                mem15[2] = 1;
            }

            if (checkBox151.Checked == false && checkBox152.Checked == false && checkBox153.Checked == false && checkBox154.Checked == false)
            {
                mem15[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem15.Length; i++)
            {
                if (mem15[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox153.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem15[2] = 2;
                    }

                    else
                    {
                        mem15[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem15.Length; i++)
                    {
                        if (mem15[i] == 2)
                        {
                            mem15[i] = 0;

                            if (i == 0)
                            {
                                checkBox151.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox152.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox154.Checked = false;
                                break;
                            }
                        }
                    }

                    mem15[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem15[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem15.Length; i++)
                    {
                        if (mem15[i] == 1)
                        {
                            mem15[i] = 1;
                            break;
                        }
                    }

                    mem15[2] = 0;
                }
            }

            g15[0] = "";
            g15[1] = "";

            if (checkBox151.Checked == true)
            {
                g15[0] = checkBox151.Text;
            }

            if (checkBox152.Checked == true)
            {
                g15[1] = checkBox152.Text;
            }

            if (checkBox153.Checked == true)
            {
                if ((g15[0] == "" && g15[1] == "") == false)
                {
                    if (g15[0] == "")
                    {
                        g15[0] = checkBox153.Text;
                    }

                    if (g15[1] == "")
                    {
                        g15[1] = checkBox153.Text;
                    }
                }

                else
                {
                    g15[0] = checkBox153.Text;
                }
            }

            if (checkBox154.Checked == true)
            {
                if ((g15[0] == "" && g15[1] == "") == false)
                {
                    if (g15[0] == "")
                    {
                        g15[0] = checkBox154.Text;
                    }

                    if (g15[1] == "")
                    {
                        g15[1] = checkBox154.Text;
                    }
                }

                else
                {
                    g15[1] = checkBox154.Text;
                }
            }

            label15.Text = String.Join("", g15);

            pictureBox151.Visible = false;
            pictureBox152.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g15[i] == "" | false | g15[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g15[0] == g15[1])
                {
                    if (g15[0] == "P")
                    {
                        pictureBox151.Visible = true;
                    }

                    else
                    {
                        pictureBox152.Visible = true;
                    }
                }

                else
                {
                    pictureBox151.Visible = true;
                }
            }
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox151.Checked == false && checkBox152.Checked == false && checkBox153.Checked == false && checkBox154.Checked == true)
            {
                mem15[3] = 1;
            }

            if (checkBox151.Checked == false && checkBox152.Checked == false && checkBox153.Checked == false && checkBox154.Checked == false)
            {
                mem15[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem15.Length; i++)
            {
                if (mem15[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox154.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem15[3] = 2;
                    }

                    else
                    {
                        mem15[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem15.Length - 1; i++)
                    {
                        if (mem15[i] == 2)
                        {
                            mem15[i] = 0;

                            if (i == 0)
                            {
                                checkBox151.Checked = false;

                                break;
                            }

                            if (i == 1)
                            {
                                checkBox152.Checked = false;

                                break;
                            }

                            if (i == 2)
                            {
                                checkBox153.Checked = false;

                                break;
                            }
                        }
                    }

                    mem15[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem15[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem15.Length; i++)
                    {
                        if (mem15[i] == 1)
                        {
                            mem15[i] = 1;
                            break;
                        }
                    }

                    mem15[3] = 0;
                }
            }

            g15[0] = "";
            g15[1] = "";

            if (checkBox151.Checked == true)
            {
                g15[0] = checkBox151.Text;
            }

            if (checkBox152.Checked == true)
            {
                g15[1] = checkBox152.Text;
            }

            if (checkBox153.Checked == true)
            {
                if ((g15[0] == "" && g15[1] == "") == false)
                {
                    if (g15[0] == "")
                    {
                        g15[0] = checkBox153.Text;
                    }

                    if (g15[1] == "")
                    {
                        g15[1] = checkBox153.Text;
                    }
                }

                else
                {
                    g15[0] = checkBox153.Text;
                }
            }

            if (checkBox154.Checked == true)
            {
                if ((g15[0] == "" && g15[1] == "") == false)
                {
                    if (g15[0] == "")
                    {
                        g15[0] = checkBox154.Text;
                    }

                    if (g15[1] == "")
                    {
                        g15[1] = checkBox154.Text;
                    }
                }

                else
                {
                    g15[1] = checkBox154.Text;
                }
            }

            label15.Text = String.Join("", g15);

            pictureBox151.Visible = false;
            pictureBox152.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g15[i] == "" | false | g15[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g15[0] == g15[1])
                {
                    if (g15[0] == "P")
                    {
                        pictureBox151.Visible = true;
                    }

                    else
                    {
                        pictureBox152.Visible = true;
                    }
                }

                else
                {
                    pictureBox151.Visible = true;
                }
            }
        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox161.Checked == false && checkBox162.Checked == false && checkBox163.Checked == true && checkBox164.Checked == false)
            {
                mem16[2] = 1;
            }

            if (checkBox161.Checked == false && checkBox162.Checked == false && checkBox163.Checked == false && checkBox164.Checked == false)
            {
                mem16[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem16.Length; i++)
            {
                if (mem16[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox163.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem16[2] = 2;
                    }

                    else
                    {
                        mem16[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem16.Length; i++)
                    {
                        if (mem16[i] == 2)
                        {
                            mem16[i] = 0;

                            if (i == 0)
                            {
                                checkBox161.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox162.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox164.Checked = false;
                                break;
                            }
                        }
                    }

                    mem16[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem16[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem16.Length; i++)
                    {
                        if (mem16[i] == 1)
                        {
                            mem16[i] = 1;
                            break;
                        }
                    }

                    mem16[2] = 0;
                }
            }

            g16[0] = "";
            g16[1] = "";

            if (checkBox161.Checked == true)
            {
                g16[0] = checkBox161.Text;
            }

            if (checkBox162.Checked == true)
            {
                g16[1] = checkBox162.Text;
            }

            if (checkBox163.Checked == true)
            {
                if ((g16[0] == "" && g16[1] == "") == false)
                {
                    if (g16[0] == "")
                    {
                        g16[0] = checkBox163.Text;
                    }

                    if (g16[1] == "")
                    {
                        g16[1] = checkBox163.Text;
                    }
                }

                else
                {
                    g16[0] = checkBox163.Text;
                }
            }

            if (checkBox164.Checked == true)
            {
                if ((g16[0] == "" && g16[1] == "") == false)
                {
                    if (g16[0] == "")
                    {
                        g16[0] = checkBox164.Text;
                    }

                    if (g16[1] == "")
                    {
                        g16[1] = checkBox164.Text;
                    }
                }

                else
                {
                    g16[1] = checkBox164.Text;
                }
            }

            label16.Text = String.Join("", g16);

            pictureBox161.Visible = false;
            pictureBox162.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g16[i] == "" | false | g16[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g16[0] == g16[1])
                {
                    if (g16[0] == "A")
                    {
                        pictureBox161.Visible = true;
                    }

                    else
                    {
                        pictureBox162.Visible = true;
                    }
                }

                else
                {
                    pictureBox161.Visible = true;
                }
            }
        }

        private void checkBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox161.Checked == false && checkBox162.Checked == false && checkBox163.Checked == false && checkBox164.Checked == true)
            {
                mem16[3] = 1;
            }

            if (checkBox161.Checked == false && checkBox162.Checked == false && checkBox163.Checked == false && checkBox164.Checked == false)
            {
                mem16[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem16.Length; i++)
            {
                if (mem16[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox164.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem16[3] = 2;
                    }

                    else
                    {
                        mem16[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem16.Length - 1; i++)
                    {
                        if (mem16[i] == 2)
                        {
                            mem16[i] = 0;

                            if (i == 0)
                            {
                                checkBox161.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox162.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox163.Checked = false;
                                break;
                            }
                        }
                    }

                    mem16[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem16[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem16.Length; i++)
                    {
                        if (mem16[i] == 1)
                        {
                            mem16[i] = 1;
                            break;
                        }
                    }

                    mem16[3] = 0;
                }
            }

            g16[0] = "";
            g16[1] = "";

            if (checkBox161.Checked == true)
            {
                g16[0] = checkBox161.Text;
            }

            if (checkBox162.Checked == true)
            {
                g16[1] = checkBox162.Text;
            }

            if (checkBox163.Checked == true)
            {
                if ((g16[0] == "" && g16[1] == "") == false)
                {
                    if (g16[0] == "")
                    {
                        g16[0] = checkBox163.Text;
                    }

                    if (g16[1] == "")
                    {
                        g16[1] = checkBox163.Text;
                    }
                }

                else
                {
                    g16[0] = checkBox163.Text;
                }
            }

            if (checkBox164.Checked == true)
            {
                if ((g16[0] == "" && g16[1] == "") == false)
                {
                    if (g16[0] == "")
                    {
                        g16[0] = checkBox164.Text;
                    }

                    if (g16[1] == "")
                    {
                        g16[1] = checkBox164.Text;
                    }
                }

                else
                {
                    g16[1] = checkBox164.Text;
                }
            }

            label16.Text = String.Join("", g16);

            pictureBox161.Visible = false;
            pictureBox162.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g16[i] == "" | false | g16[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g16[0] == g16[1])
                {
                    if (g16[0] == "A")
                    {
                        pictureBox161.Visible = true;
                    }

                    else
                    {
                        pictureBox162.Visible = true;
                    }
                }

                else
                {
                    pictureBox161.Visible = true;
                }
            }
        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox171.Checked == false && checkBox172.Checked == false && checkBox173.Checked == true && checkBox174.Checked == false)
            {
                mem17[2] = 1;
            }

            if (checkBox171.Checked == false && checkBox172.Checked == false && checkBox173.Checked == false && checkBox174.Checked == false)
            {
                mem17[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem17.Length; i++)
            {
                if (mem17[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox173.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem17[2] = 2;
                    }

                    else
                    {
                        mem17[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem17.Length; i++)
                    {
                        if (mem17[i] == 2)
                        {
                            mem17[i] = 0;

                            if (i == 0)
                            {
                                checkBox171.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox172.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox174.Checked = false;
                                break;
                            }
                        }
                    }

                    mem17[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem17[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem17.Length; i++)
                    {
                        if (mem17[i] == 1)
                        {
                            mem17[i] = 1;
                            break;
                        }
                    }

                    mem17[2] = 0;
                }
            }

            g17[0] = "";
            g17[1] = "";

            if (checkBox171.Checked == true)
            {
                g17[0] = checkBox171.Text;
            }

            if (checkBox172.Checked == true)
            {
                g17[1] = checkBox172.Text;
            }

            if (checkBox173.Checked == true)
            {
                if ((g17[0] == "" && g17[1] == "") == false)
                {
                    if (g17[0] == "")
                    {
                        g17[0] = checkBox173.Text;
                    }

                    if (g17[1] == "")
                    {
                        g17[1] = checkBox173.Text;
                    }
                }

                else
                {
                    g17[0] = checkBox173.Text;
                }
            }

            if (checkBox174.Checked == true)
            {
                if ((g17[0] == "" && g17[1] == "") == false)
                {
                    if (g17[0] == "")
                    {
                        g17[0] = checkBox174.Text;
                    }

                    if (g17[1] == "")
                    {
                        g17[1] = checkBox174.Text;
                    }
                }

                else
                {
                    g17[1] = checkBox174.Text;
                }
            }

            label17.Text = String.Join("", g17);

            pictureBox171.Visible = false;
            pictureBox172.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g17[i] == "" | false | g17[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g17[0] == g17[1])
                {
                    if (g17[0] == "T")
                    {
                        pictureBox171.Visible = true;
                    }

                    else
                    {
                        pictureBox172.Visible = true;
                    }
                }

                else
                {
                    pictureBox171.Visible = true;
                }
            }
        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox171.Checked == false && checkBox172.Checked == false && checkBox173.Checked == false && checkBox174.Checked == true)
            {
                mem17[3] = 1;
            }

            if (checkBox171.Checked == false && checkBox172.Checked == false && checkBox173.Checked == false && checkBox174.Checked == false)
            {
                mem17[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem17.Length; i++)
            {
                if (mem17[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox174.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem17[3] = 2;
                    }

                    else
                    {
                        mem17[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem17.Length - 1; i++)
                    {
                        if (mem17[i] == 2)
                        {
                            mem17[i] = 0;

                            if (i == 0)
                            {
                                checkBox171.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox172.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox173.Checked = false;
                                break;
                            }
                        }
                    }

                    mem17[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem17[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem17.Length; i++)
                    {
                        if (mem17[i] == 1)
                        {
                            mem17[i] = 1;
                            break;
                        }
                    }

                    mem17[3] = 0;
                }
            }

            g17[0] = "";
            g17[1] = "";

            if (checkBox171.Checked == true)
            {
                g17[0] = checkBox171.Text;
            }

            if (checkBox172.Checked == true)
            {
                g17[1] = checkBox172.Text;
            }

            if (checkBox173.Checked == true)
            {
                if ((g17[0] == "" && g17[1] == "") == false)
                {
                    if (g17[0] == "")
                    {
                        g17[0] = checkBox173.Text;
                    }

                    if (g17[1] == "")
                    {
                        g17[1] = checkBox173.Text;
                    }
                }

                else
                {
                    g17[0] = checkBox173.Text;
                }
            }

            if (checkBox174.Checked == true)
            {
                if ((g17[0] == "" && g17[1] == "") == false)
                {
                    if (g17[0] == "")
                    {
                        g17[0] = checkBox174.Text;
                    }

                    if (g17[1] == "")
                    {
                        g17[1] = checkBox174.Text;
                    }
                }

                else
                {
                    g17[1] = checkBox174.Text;
                }
            }

            label17.Text = String.Join("", g17);

            pictureBox171.Visible = false;
            pictureBox172.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g17[i] == "" | false | g17[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g17[0] == g17[1])
                {
                    if (g17[0] == "T")
                    {
                        pictureBox171.Visible = true;
                    }

                    else
                    {
                        pictureBox172.Visible = true;
                    }
                }

                else
                {
                    pictureBox171.Visible = true;
                }
            }
        }

        private void checkBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox211.Checked == false && checkBox212.Checked == false && checkBox213.Checked == true && checkBox214.Checked == false)
            {
                mem21[2] = 1;
            }

            if (checkBox211.Checked == false && checkBox212.Checked == false && checkBox213.Checked == false && checkBox214.Checked == false)
            {
                mem21[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem21.Length; i++)
            {
                if (mem21[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox213.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem21[2] = 2;
                    }

                    else
                    {
                        mem21[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem21.Length; i++)
                    {
                        if (mem21[i] == 2)
                        {
                            mem21[i] = 0;

                            if (i == 0)
                            {
                                checkBox211.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox212.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox214.Checked = false;
                                break;
                            }
                        }
                    }

                    mem21[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem21[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem21.Length; i++)
                    {
                        if (mem21[i] == 1)
                        {
                            mem21[i] = 1;
                            break;
                        }
                    }

                    mem21[2] = 0;
                }
            }

            g21[0] = "";
            g21[1] = "";

            if (checkBox211.Checked == true)
            {
                g21[0] = checkBox211.Text;
            }

            if (checkBox212.Checked == true)
            {
                g21[1] = checkBox212.Text;
            }

            if (checkBox213.Checked == true)
            {
                if ((g21[0] == "" && g21[1] == "") == false)
                {
                    if (g21[0] == "")
                    {
                        g21[0] = checkBox213.Text;
                    }

                    if (g21[1] == "")
                    {
                        g21[1] = checkBox213.Text;
                    }
                }

                else
                {
                    g21[0] = checkBox213.Text;
                }
            }

            if (checkBox214.Checked == true)
            {
                if ((g21[0] == "" && g21[1] == "") == false)
                {
                    if (g21[0] == "")
                    {
                        g21[0] = checkBox214.Text;
                    }

                    if (g21[1] == "")
                    {
                        g21[1] = checkBox214.Text;
                    }
                }

                else
                {
                    g21[1] = checkBox214.Text;
                }
            }

            label21.Text = String.Join("", g21);

            pictureBox211.Visible = false;
            pictureBox212.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g21[i] == "" | false | g21[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g21[0] == g21[1])
                {
                    if (g21[0] == "R")
                    {
                        pictureBox211.Visible = true;
                    }

                    else
                    {
                        pictureBox212.Visible = true;
                    }
                }

                else
                {
                    pictureBox211.Visible = true;
                }
            }
        }

        private void checkBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox211.Checked == false && checkBox212.Checked == false && checkBox213.Checked == false && checkBox214.Checked == true)
            {
                mem21[3] = 1;
            }

            if (checkBox211.Checked == false && checkBox212.Checked == false && checkBox213.Checked == false && checkBox214.Checked == false)
            {
                mem21[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem21.Length; i++)
            {
                if (mem21[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox214.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem21[3] = 2;
                    }

                    else
                    {
                        mem21[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem21.Length - 1; i++)
                    {
                        if (mem21[i] == 2)
                        {
                            mem21[i] = 0;

                            if (i == 0)
                            {
                                checkBox211.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox212.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox213.Checked = false;
                                break;
                            }
                        }
                    }

                    mem21[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem21[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem21.Length; i++)
                    {
                        if (mem21[i] == 1)
                        {
                            mem21[i] = 1;
                            break;
                        }
                    }

                    mem21[3] = 0;
                }
            }

            g21[0] = "";
            g21[1] = "";

            if (checkBox211.Checked == true)
            {
                g21[0] = checkBox211.Text;
            }

            if (checkBox212.Checked == true)
            {
                g21[1] = checkBox212.Text;
            }

            if (checkBox213.Checked == true)
            {
                if ((g21[0] == "" && g21[1] == "") == false)
                {
                    if (g21[0] == "")
                    {
                        g21[0] = checkBox213.Text;
                    }

                    if (g21[1] == "")
                    {
                        g21[1] = checkBox213.Text;
                    }
                }

                else
                {
                    g21[0] = checkBox213.Text;
                }
            }

            if (checkBox214.Checked == true)
            {
                if ((g21[0] == "" && g21[1] == "") == false)
                {
                    if (g21[0] == "")
                    {
                        g21[0] = checkBox214.Text;
                    }

                    if (g21[1] == "")
                    {
                        g21[1] = checkBox214.Text;
                    }
                }

                else
                {
                    g21[1] = checkBox214.Text;
                }
            }

            label21.Text = String.Join("", g21);

            pictureBox211.Visible = false;
            pictureBox212.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g21[i] == "" | false | g21[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g21[0] == g21[1])
                {
                    if (g21[0] == "R")
                    {
                        pictureBox211.Visible = true;
                    }

                    else
                    {
                        pictureBox212.Visible = true;
                    }
                }

                else
                {
                    pictureBox211.Visible = true;
                }
            }
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox221.Checked == false && checkBox222.Checked == false && checkBox223.Checked == true && checkBox224.Checked == false)
            {
                mem22[2] = 1;
            }

            if (checkBox221.Checked == false && checkBox222.Checked == false && checkBox223.Checked == false && checkBox224.Checked == false)
            {
                mem22[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem22.Length; i++)
            {
                if (mem22[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox223.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem22[2] = 2;
                    }

                    else
                    {
                        mem22[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem22.Length; i++)
                    {
                        if (mem22[i] == 2)
                        {
                            mem22[i] = 0;

                            if (i == 0)
                            {
                                checkBox221.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox222.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox224.Checked = false;
                                break;
                            }
                        }
                    }

                    mem22[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem22[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem22.Length; i++)
                    {
                        if (mem22[i] == 1)
                        {
                            mem22[i] = 1;
                            break;
                        }
                    }

                    mem22[2] = 0;
                }
            }

            g22[0] = "";
            g22[1] = "";

            if (checkBox221.Checked == true)
            {
                g22[0] = checkBox221.Text;
            }

            if (checkBox222.Checked == true)
            {
                g22[1] = checkBox222.Text;
            }

            if (checkBox223.Checked == true)
            {
                if ((g22[0] == "" && g22[1] == "") == false)
                {
                    if (g22[0] == "")
                    {
                        g22[0] = checkBox223.Text;
                    }

                    if (g22[1] == "")
                    {
                        g22[1] = checkBox223.Text;
                    }
                }

                else
                {
                    g22[0] = checkBox223.Text;
                }
            }

            if (checkBox224.Checked == true)
            {
                if ((g22[0] == "" && g22[1] == "") == false)
                {
                    if (g22[0] == "")
                    {
                        g22[0] = checkBox224.Text;
                    }

                    if (g22[1] == "")
                    {
                        g22[1] = checkBox224.Text;
                    }
                }

                else
                {
                    g22[1] = checkBox224.Text;
                }
            }

            label22.Text = String.Join("", g22);

            pictureBox221.Visible = false;
            pictureBox222.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g22[i] == "" | false | g22[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g22[0] == g22[1])
                {
                    if (g22[0] == "Y")
                    {
                        pictureBox221.Visible = true;
                    }

                    else
                    {
                        pictureBox222.Visible = true;
                    }
                }

                else
                {
                    pictureBox221.Visible = true;
                }
            }
        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox221.Checked == false && checkBox222.Checked == false && checkBox223.Checked == false && checkBox224.Checked == true)
            {
                mem22[3] = 1;
            }

            if (checkBox221.Checked == false && checkBox222.Checked == false && checkBox223.Checked == false && checkBox224.Checked == false)
            {
                mem22[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem22.Length; i++)
            {
                if (mem22[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox224.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem22[3] = 2;
                    }

                    else
                    {
                        mem22[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem22.Length - 1; i++)
                    {
                        if (mem22[i] == 2)
                        {
                            mem22[i] = 0;

                            if (i == 0)
                            {
                                checkBox221.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox222.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox223.Checked = false;
                                break;
                            }
                        }
                    }

                    mem22[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem22[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem22.Length; i++)
                    {
                        if (mem22[i] == 1)
                        {
                            mem22[i] = 1;
                            break;
                        }
                    }

                    mem22[3] = 0;
                }
            }

            g22[0] = "";
            g22[1] = "";

            if (checkBox221.Checked == true)
            {
                g22[0] = checkBox221.Text;
            }

            if (checkBox222.Checked == true)
            {
                g22[1] = checkBox222.Text;
            }

            if (checkBox223.Checked == true)
            {
                if ((g22[0] == "" && g22[1] == "") == false)
                {
                    if (g22[0] == "")
                    {
                        g22[0] = checkBox223.Text;
                    }

                    if (g22[1] == "")
                    {
                        g22[1] = checkBox223.Text;
                    }
                }

                else
                {
                    g22[0] = checkBox223.Text;
                }
            }

            if (checkBox224.Checked == true)
            {
                if ((g22[0] == "" && g22[1] == "") == false)
                {
                    if (g22[0] == "")
                    {
                        g22[0] = checkBox224.Text;
                    }

                    if (g22[1] == "")
                    {
                        g22[1] = checkBox224.Text;
                    }
                }

                else
                {
                    g22[1] = checkBox224.Text;
                }
            }

            label22.Text = String.Join("", g22);

            pictureBox221.Visible = false;
            pictureBox222.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g22[i] == "" | false | g22[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g22[0] == g22[1])
                {
                    if (g22[0] == "Y")
                    {
                        pictureBox221.Visible = true;
                    }

                    else
                    {
                        pictureBox222.Visible = true;
                    }
                }

                else
                {
                    pictureBox221.Visible = true;
                }
            }
        }

        private void checkBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox231.Checked == false && checkBox232.Checked == false && checkBox233.Checked == true && checkBox234.Checked == false)
            {
                mem23[2] = 1;
            }

            if (checkBox231.Checked == false && checkBox232.Checked == false && checkBox233.Checked == false && checkBox234.Checked == false)
            {
                mem23[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem23.Length; i++)
            {
                if (mem23[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox233.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem23[2] = 2;
                    }

                    else
                    {
                        mem23[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem23.Length; i++)
                    {
                        if (mem23[i] == 2)
                        {
                            mem23[i] = 0;

                            if (i == 0)
                            {
                                checkBox231.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox232.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox234.Checked = false;
                                break;
                            }
                        }
                    }

                    mem23[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem23[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem23.Length; i++)
                    {
                        if (mem23[i] == 1)
                        {
                            mem23[i] = 1;
                            break;
                        }
                    }

                    mem23[2] = 0;
                }
            }

            g23[0] = "";
            g23[1] = "";

            if (checkBox231.Checked == true)
            {
                g23[0] = checkBox231.Text;
            }

            if (checkBox232.Checked == true)
            {
                g23[1] = checkBox232.Text;
            }

            if (checkBox233.Checked == true)
            {
                if ((g23[0] == "" && g23[1] == "") == false)
                {
                    if (g23[0] == "")
                    {
                        g23[0] = checkBox233.Text;
                    }

                    if (g23[1] == "")
                    {
                        g23[1] = checkBox233.Text;
                    }
                }

                else
                {
                    g23[0] = checkBox233.Text;
                }
            }

            if (checkBox234.Checked == true)
            {
                if ((g23[0] == "" && g23[1] == "") == false)
                {
                    if (g23[0] == "")
                    {
                        g23[0] = checkBox234.Text;
                    }

                    if (g23[1] == "")
                    {
                        g23[1] = checkBox234.Text;
                    }
                }

                else
                {
                    g23[1] = checkBox234.Text;
                }
            }

            label23.Text = String.Join("", g23);

            pictureBox231.Visible = false;
            pictureBox232.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g23[i] == "" | false | g23[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g23[0] == g23[1])
                {
                    if (g23[0] == "G")
                    {
                        pictureBox231.Visible = true;
                    }

                    else
                    {
                        pictureBox232.Visible = true;
                    }
                }

                else
                {
                    pictureBox231.Visible = true;
                }
            }
        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox231.Checked == false && checkBox232.Checked == false && checkBox233.Checked == false && checkBox234.Checked == true)
            {
                mem23[3] = 1;
            }

            if (checkBox231.Checked == false && checkBox232.Checked == false && checkBox233.Checked == false && checkBox234.Checked == false)
            {
                mem23[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem23.Length; i++)
            {
                if (mem23[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox234.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem23[3] = 2;
                    }

                    else
                    {
                        mem23[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem23.Length - 1; i++)
                    {
                        if (mem23[i] == 2)
                        {
                            mem23[i] = 0;

                            if (i == 0)
                            {
                                checkBox231.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox232.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox233.Checked = false;
                                break;
                            }
                        }
                    }

                    mem23[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem23[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem23.Length; i++)
                    {
                        if (mem23[i] == 1)
                        {
                            mem23[i] = 1;
                            break;
                        }
                    }

                    mem23[3] = 0;
                }
            }

            g23[0] = "";
            g23[1] = "";

            if (checkBox231.Checked == true)
            {
                g23[0] = checkBox231.Text;
            }

            if (checkBox232.Checked == true)
            {
                g23[1] = checkBox232.Text;
            }

            if (checkBox233.Checked == true)
            {
                if ((g23[0] == "" && g23[1] == "") == false)
                {
                    if (g23[0] == "")
                    {
                        g23[0] = checkBox233.Text;
                    }

                    if (g23[1] == "")
                    {
                        g23[1] = checkBox233.Text;
                    }
                }

                else
                {
                    g23[0] = checkBox233.Text;
                }
            }

            if (checkBox234.Checked == true)
            {
                if ((g23[0] == "" && g23[1] == "") == false)
                {
                    if (g23[0] == "")
                    {
                        g23[0] = checkBox234.Text;
                    }

                    if (g23[1] == "")
                    {
                        g23[1] = checkBox234.Text;
                    }
                }

                else
                {
                    g23[1] = checkBox234.Text;
                }
            }

            label23.Text = String.Join("", g23);

            pictureBox231.Visible = false;
            pictureBox232.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g23[i] == "" | false | g23[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g23[0] == g23[1])
                {
                    if (g23[0] == "G")
                    {
                        pictureBox231.Visible = true;
                    }

                    else
                    {
                        pictureBox232.Visible = true;
                    }
                }

                else
                {
                    pictureBox231.Visible = true;
                }
            }
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox241.Checked == false && checkBox242.Checked == false && checkBox243.Checked == true && checkBox244.Checked == false)
            {
                mem24[2] = 1;
            }

            if (checkBox241.Checked == false && checkBox242.Checked == false && checkBox243.Checked == false && checkBox244.Checked == false)
            {
                mem24[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem24.Length; i++)
            {
                if (mem24[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox243.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem24[2] = 2;
                    }

                    else
                    {
                        mem24[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem24.Length; i++)
                    {
                        if (mem24[i] == 2)
                        {
                            mem24[i] = 0;

                            if (i == 0)
                            {
                                checkBox241.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox242.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox244.Checked = false;
                                break;
                            }
                        }
                    }

                    mem24[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem24[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem24.Length; i++)
                    {
                        if (mem24[i] == 1)
                        {
                            mem24[i] = 1;
                            break;
                        }
                    }

                    mem24[2] = 0;
                }
            }

            g24[0] = "";
            g24[1] = "";

            if (checkBox241.Checked == true)
            {
                g24[0] = checkBox241.Text;
            }

            if (checkBox242.Checked == true)
            {
                g24[1] = checkBox242.Text;
            }

            if (checkBox243.Checked == true)
            {
                if ((g24[0] == "" && g24[1] == "") == false)
                {
                    if (g24[0] == "")
                    {
                        g24[0] = checkBox243.Text;
                    }

                    if (g24[1] == "")
                    {
                        g24[1] = checkBox243.Text;
                    }
                }

                else
                {
                    g24[0] = checkBox243.Text;
                }
            }

            if (checkBox244.Checked == true)
            {
                if ((g24[0] == "" && g24[1] == "") == false)
                {
                    if (g24[0] == "")
                    {
                        g24[0] = checkBox244.Text;
                    }

                    if (g24[1] == "")
                    {
                        g24[1] = checkBox244.Text;
                    }
                }

                else
                {
                    g24[1] = checkBox244.Text;
                }
            }

            label24.Text = String.Join("", g24);

            pictureBox241.Visible = false;
            pictureBox242.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g24[i] == "" | false | g24[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g24[0] == g24[1])
                {
                    if (g24[0] == "C")
                    {
                        pictureBox241.Visible = true;
                    }

                    else
                    {
                        pictureBox242.Visible = true;
                    }
                }

                else
                {
                    pictureBox241.Visible = true;
                }
            }
        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox241.Checked == false && checkBox242.Checked == false && checkBox243.Checked == false && checkBox244.Checked == true)
            {
                mem24[3] = 1;
            }

            if (checkBox241.Checked == false && checkBox242.Checked == false && checkBox243.Checked == false && checkBox244.Checked == false)
            {
                mem24[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem24.Length; i++)
            {
                if (mem24[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox244.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem24[3] = 2;
                    }

                    else
                    {
                        mem24[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem24.Length - 1; i++)
                    {
                        if (mem24[i] == 2)
                        {
                            mem24[i] = 0;

                            if (i == 0)
                            {
                                checkBox241.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox242.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox243.Checked = false;
                                break;
                            }
                        }
                    }

                    mem24[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem24[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem24.Length; i++)
                    {
                        if (mem24[i] == 1)
                        {
                            mem24[i] = 1;
                            break;
                        }
                    }

                    mem24[3] = 0;
                }
            }

            g24[0] = "";
            g24[1] = "";

            if (checkBox241.Checked == true)
            {
                g24[0] = checkBox241.Text;
            }

            if (checkBox242.Checked == true)
            {
                g24[1] = checkBox242.Text;
            }

            if (checkBox243.Checked == true)
            {
                if ((g24[0] == "" && g24[1] == "") == false)
                {
                    if (g24[0] == "")
                    {
                        g24[0] = checkBox243.Text;
                    }

                    if (g24[1] == "")
                    {
                        g24[1] = checkBox243.Text;
                    }
                }

                else
                {
                    g24[0] = checkBox243.Text;
                }
            }

            if (checkBox244.Checked == true)
            {
                if ((g24[0] == "" && g24[1] == "") == false)
                {
                    if (g24[0] == "")
                    {
                        g24[0] = checkBox244.Text;
                    }

                    if (g24[1] == "")
                    {
                        g24[1] = checkBox244.Text;
                    }
                }

                else
                {
                    g24[1] = checkBox244.Text;
                }
            }

            label24.Text = String.Join("", g24);

            pictureBox241.Visible = false;
            pictureBox242.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g24[i] == "" | false | g24[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g24[0] == g24[1])
                {
                    if (g24[0] == "C")
                    {
                        pictureBox241.Visible = true;
                    }

                    else
                    {
                        pictureBox242.Visible = true;
                    }
                }

                else
                {
                    pictureBox241.Visible = true;
                }
            }
        }

        private void checkBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox251.Checked == false && checkBox252.Checked == false && checkBox253.Checked == true && checkBox254.Checked == false)
            {
                mem25[2] = 1;
            }

            if (checkBox251.Checked == false && checkBox252.Checked == false && checkBox253.Checked == false && checkBox254.Checked == false)
            {
                mem25[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem25.Length; i++)
            {
                if (mem25[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox253.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem25[2] = 2;
                    }

                    else
                    {
                        mem25[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem25.Length; i++)
                    {
                        if (mem25[i] == 2)
                        {
                            mem25[i] = 0;

                            if (i == 0)
                            {
                                checkBox251.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox252.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox254.Checked = false;
                                break;
                            }
                        }
                    }

                    mem25[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem25[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem25.Length; i++)
                    {
                        if (mem25[i] == 1)
                        {
                            mem25[i] = 1;
                            break;
                        }
                    }

                    mem25[2] = 0;
                }
            }

            g25[0] = "";
            g25[1] = "";

            if (checkBox251.Checked == true)
            {
                g25[0] = checkBox251.Text;
            }

            if (checkBox252.Checked == true)
            {
                g25[1] = checkBox252.Text;
            }

            if (checkBox253.Checked == true)
            {
                if ((g25[0] == "" && g25[1] == "") == false)
                {
                    if (g25[0] == "")
                    {
                        g25[0] = checkBox253.Text;
                    }

                    if (g25[1] == "")
                    {
                        g25[1] = checkBox253.Text;
                    }
                }

                else
                {
                    g25[0] = checkBox253.Text;
                }
            }

            if (checkBox254.Checked == true)
            {
                if ((g25[0] == "" && g25[1] == "") == false)
                {
                    if (g25[0] == "")
                    {
                        g25[0] = checkBox254.Text;
                    }

                    if (g25[1] == "")
                    {
                        g25[1] = checkBox254.Text;
                    }
                }

                else
                {
                    g25[1] = checkBox254.Text;
                }
            }

            label25.Text = String.Join("", g25);

            pictureBox251.Visible = false;
            pictureBox252.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g25[i] == "" | false | g25[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g25[0] == g25[1])
                {
                    if (g25[0] == "P")
                    {
                        pictureBox251.Visible = true;
                    }

                    else
                    {
                        pictureBox252.Visible = true;
                    }
                }

                else
                {
                    pictureBox251.Visible = true;
                }
            }
        }

        private void checkBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox251.Checked == false && checkBox252.Checked == false && checkBox253.Checked == false && checkBox254.Checked == true)
            {
                mem25[3] = 1;
            }

            if (checkBox251.Checked == false && checkBox252.Checked == false && checkBox253.Checked == false && checkBox254.Checked == false)
            {
                mem25[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem25.Length; i++)
            {
                if (mem25[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox254.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem25[3] = 2;
                    }

                    else
                    {
                        mem25[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem25.Length - 1; i++)
                    {
                        if (mem25[i] == 2)
                        {
                            mem25[i] = 0;

                            if (i == 0)
                            {
                                checkBox251.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox252.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox253.Checked = false;
                                break;
                            }
                        }
                    }

                    mem25[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem25[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem25.Length; i++)
                    {
                        if (mem25[i] == 1)
                        {
                            mem25[i] = 1;
                            break;
                        }
                    }

                    mem25[3] = 0;
                }
            }

            g25[0] = "";
            g25[1] = "";

            if (checkBox251.Checked == true)
            {
                g25[0] = checkBox251.Text;
            }

            if (checkBox252.Checked == true)
            {
                g25[1] = checkBox252.Text;
            }

            if (checkBox253.Checked == true)
            {
                if ((g25[0] == "" && g25[1] == "") == false)
                {
                    if (g25[0] == "")
                    {
                        g25[0] = checkBox253.Text;
                    }

                    if (g25[1] == "")
                    {
                        g25[1] = checkBox253.Text;
                    }
                }

                else
                {
                    g25[0] = checkBox253.Text;
                }
            }

            if (checkBox254.Checked == true)
            {
                if ((g25[0] == "" && g25[1] == "") == false)
                {
                    if (g25[0] == "")
                    {
                        g25[0] = checkBox254.Text;
                    }

                    if (g25[1] == "")
                    {
                        g25[1] = checkBox254.Text;
                    }
                }

                else
                {
                    g25[1] = checkBox254.Text;
                }
            }

            label25.Text = String.Join("", g25);

            pictureBox251.Visible = false;
            pictureBox252.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g25[i] == "" | false | g25[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g25[0] == g25[1])
                {
                    if (g25[0] == "P")
                    {
                        pictureBox251.Visible = true;
                    }

                    else
                    {
                        pictureBox252.Visible = true;
                    }
                }

                else
                {
                    pictureBox251.Visible = true;
                }
            }
        }

        private void checkBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox261.Checked == false && checkBox262.Checked == false && checkBox263.Checked == true && checkBox264.Checked == false)
            {
                mem26[2] = 1;
            }

            if (checkBox261.Checked == false && checkBox262.Checked == false && checkBox263.Checked == false && checkBox264.Checked == false)
            {
                mem26[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem26.Length; i++)
            {
                if (mem26[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox263.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem26[2] = 2;
                    }

                    else
                    {
                        mem26[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem26.Length; i++)
                    {
                        if (mem26[i] == 2)
                        {
                            mem26[i] = 0;

                            if (i == 0)
                            {
                                checkBox261.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox262.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox264.Checked = false;
                                break;
                            }
                        }
                    }

                    mem26[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem26[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem26.Length; i++)
                    {
                        if (mem26[i] == 1)
                        {
                            mem26[i] = 1;
                            break;
                        }
                    }

                    mem26[2] = 0;
                }
            }

            g26[0] = "";
            g26[1] = "";

            if (checkBox261.Checked == true)
            {
                g26[0] = checkBox261.Text;
            }

            if (checkBox262.Checked == true)
            {
                g26[1] = checkBox262.Text;
            }

            if (checkBox263.Checked == true)
            {
                if ((g26[0] == "" && g26[1] == "") == false)
                {
                    if (g26[0] == "")
                    {
                        g26[0] = checkBox263.Text;
                    }

                    if (g26[1] == "")
                    {
                        g26[1] = checkBox263.Text;
                    }
                }

                else
                {
                    g26[0] = checkBox263.Text;
                }
            }

            if (checkBox264.Checked == true)
            {
                if ((g26[0] == "" && g26[1] == "") == false)
                {
                    if (g26[0] == "")
                    {
                        g26[0] = checkBox264.Text;
                    }

                    if (g26[1] == "")
                    {
                        g26[1] = checkBox264.Text;
                    }
                }

                else
                {
                    g26[1] = checkBox264.Text;
                }
            }

            label26.Text = String.Join("", g26);

            pictureBox261.Visible = false;
            pictureBox262.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g26[i] == "" | false | g26[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g26[0] == g26[1])
                {
                    if (g26[0] == "A")
                    {
                        pictureBox261.Visible = true;
                    }

                    else
                    {
                        pictureBox262.Visible = true;
                    }
                }

                else
                {
                    pictureBox261.Visible = true;
                }
            }
        }

        private void checkBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox261.Checked == false && checkBox262.Checked == false && checkBox263.Checked == false && checkBox264.Checked == true)
            {
                mem26[3] = 1;
            }

            if (checkBox261.Checked == false && checkBox262.Checked == false && checkBox263.Checked == false && checkBox264.Checked == false)
            {
                mem26[3] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem26.Length; i++)
            {
                if (mem26[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox264.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 3)
                    {
                        mem26[3] = 2;
                    }

                    else
                    {
                        mem26[3] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem26.Length - 1; i++)
                    {
                        if (mem26[i] == 2)
                        {
                            mem26[i] = 0;

                            if (i == 0)
                            {
                                checkBox261.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox262.Checked = false;
                                break;
                            }

                            if (i == 2)
                            {
                                checkBox263.Checked = false;
                                break;
                            }
                        }
                    }

                    mem26[3] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem26[3] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem26.Length; i++)
                    {
                        if (mem26[i] == 1)
                        {
                            mem26[i] = 1;
                            break;
                        }
                    }

                    mem26[3] = 0;
                }
            }

            g26[0] = "";
            g26[1] = "";

            if (checkBox261.Checked == true)
            {
                g26[0] = checkBox261.Text;
            }

            if (checkBox262.Checked == true)
            {
                g26[1] = checkBox262.Text;
            }

            if (checkBox263.Checked == true)
            {
                if ((g26[0] == "" && g26[1] == "") == false)
                {
                    if (g26[0] == "")
                    {
                        g26[0] = checkBox263.Text;
                    }

                    if (g26[1] == "")
                    {
                        g26[1] = checkBox263.Text;
                    }
                }

                else
                {
                    g26[0] = checkBox263.Text;
                }
            }

            if (checkBox264.Checked == true)
            {
                if ((g26[0] == "" && g26[1] == "") == false)
                {
                    if (g26[0] == "")
                    {
                        g26[0] = checkBox264.Text;
                    }

                    if (g26[1] == "")
                    {
                        g26[1] = checkBox264.Text;
                    }
                }

                else
                {
                    g26[1] = checkBox264.Text;
                }
            }

            label26.Text = String.Join("", g26);

            pictureBox261.Visible = false;
            pictureBox262.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g26[i] == "" | false | g26[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g26[0] == g26[1])
                {
                    if (g26[0] == "A")
                    {
                        pictureBox261.Visible = true;
                    }

                    else
                    {
                        pictureBox262.Visible = true;
                    }
                }

                else
                {
                    pictureBox261.Visible = true;
                }
            }
        }

        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox271.Checked == false && checkBox272.Checked == false && checkBox273.Checked == true && checkBox274.Checked == false)
            {
                mem27[2] = 1;
            }

            if (checkBox271.Checked == false && checkBox272.Checked == false && checkBox273.Checked == false && checkBox274.Checked == false)
            {
                mem27[2] = 0;
            }

            int o = 0;

            int p = 0;

            for (int i = 0; i < mem27.Length; i++)
            {
                if (mem27[i] != 0)
                {
                    o++;
                    p = i;
                }
            }

            if (checkBox273.Checked == true)
            {
                if (o == 1)
                {
                    if (p != 2)
                    {
                        mem27[2] = 2;
                    }

                    else
                    {
                        mem27[2] = 1;
                    }
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem27.Length; i++)
                    {
                        if (mem27[i] == 2)
                        {
                            mem27[i] = 0;

                            if (i == 0)
                            {
                                checkBox271.Checked = false;
                                break;
                            }

                            if (i == 1)
                            {
                                checkBox272.Checked = false;
                                break;
                            }

                            if (i == 3)
                            {
                                checkBox274.Checked = false;
                                break;
                            }
                        }
                    }

                    mem27[2] = 2;
                }
            }

            else
            {
                if (o == 1)
                {
                    mem27[2] = 0;
                }

                if (o == 2)
                {
                    for (int i = 0; i < mem27.Length; i++)
                    {
                        if (mem27[i] == 1)
                        {
                            mem27[i] = 1;
                            break;
                        }
                    }

                    mem27[2] = 0;
                }
            }

            g27[0] = "";
            g27[1] = "";

            if (checkBox271.Checked == true)
            {
                g27[0] = checkBox271.Text;
            }

            if (checkBox272.Checked == true)
            {
                g27[1] = checkBox272.Text;
            }

            if (checkBox273.Checked == true)
            {
                if ((g27[0] == "" && g27[1] == "") == false)
                {
                    if (g27[0] == "")
                    {
                        g27[0] = checkBox273.Text;
                    }

                    if (g27[1] == "")
                    {
                        g27[1] = checkBox273.Text;
                    }
                }

                else
                {
                    g27[0] = checkBox273.Text;
                }
            }

            if (checkBox274.Checked == true)
            {
                if ((g27[0] == "" && g27[1] == "") == false)
                {
                    if (g27[0] == "")
                    {
                        g27[0] = checkBox274.Text;
                    }

                    if (g27[1] == "")
                    {
                        g27[1] = checkBox274.Text;
                    }
                }

                else
                {
                    g27[1] = checkBox274.Text;
                }
            }

            label27.Text = String.Join("", g27);

            pictureBox271.Visible = false;
            pictureBox272.Visible = false;

            label8.Visible = false;

            bool not_enough_data = false;

            for (int i = 0; i < 2; i++)
            {
                if (g27[i] == "" | false | g27[i] == null)
                {
                    not_enough_data = true;
                    break;
                }
            }

            if (not_enough_data == true)
            {
                label8.Visible = true;
            }

            else
            {
                if (g27[0] == g27[1])
                {
                    if (g27[0] == "T")
                    {
                        pictureBox271.Visible = true;
                    }

                    else
                    {
                        pictureBox272.Visible = true;
                    }
                }

                else
                {
                    pictureBox271.Visible = true;
                }
            }
        }
    }
}