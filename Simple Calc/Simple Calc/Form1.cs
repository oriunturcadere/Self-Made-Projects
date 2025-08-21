using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Simple_Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal x = 0;
        decimal y = 0;

        BigInteger x2 = 0;
        BigInteger y2 = 0;

        InfiNum x3 = new InfiNum();
        InfiNum y3 = new InfiNum();

        string[] xs = new string[0];
        string[] ys = new string[0];
        string[] ans = new string[0];

        int place = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            decimal rad = 6371230;
            decimal avg = Convert.ToDecimal(9.80665);

            decimal dis = Convert.ToDecimal(textBox1.Text);

            decimal step1 = rad / (rad + dis * 1000);

            decimal step2 = step1 * step1;

            decimal step3 = step2 * avg;

            textBox2.Text = step3.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(textBox3.Text, textBox3.Font);

            if (size.Width != 0 && size.Width < 1852)
            {
                textBox3.Width = size.Width;
            }

            if (size.Width > 1852)
            {
                textBox3.Width = 1852;
                textBox3.ScrollBars = ScrollBars.Vertical;
            }

            else
            {
                textBox3.ScrollBars = ScrollBars.None;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1) && decimal.TryParse(textBox2.Text, out decimal t2))
                {
                    x = t1;
                    y = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();
                        ans[ans.Length - 1] = (x + y).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();
                        anst[place] = (x + y).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();
                        ans[ans.Length - 1] = (x2 + y2).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();
                        anst[place] = (x2 + y2).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();
                InfiNum t2 = new InfiNum();

                t1.Value = textBox1.Text;
                t2.Value = textBox2.Text;

                if (t1._0 == false && t2._0 == false)
                {
                    x3.Value = t1.Value;
                    y3.Value = t2.Value;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;
                        ans[ans.Length - 1] = x3.Add(y3.Value);
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x3.Value;
                        yt[place] = y3.Value;
                        anst[place] = x3.Add(y3.Value);

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (place != 0)
            {
                place--;
                textBox1.Text = xs[place].ToString();

                if (ys[place] == null)
                {
                    textBox2.Text = "";
                }

                else
                {
                    textBox2.Text = ys[place].ToString();
                }

                textBox3.Text = ans[place].ToString();
            }
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            if (place != ans.Length - 1 && ans.Length != 0)
            {
                place++;
                textBox1.Text = xs[place].ToString();

                if (ys[place] == null)
                {
                    textBox2.Text = "";
                }

                else
                {
                    textBox2.Text = ys[place].ToString();
                }

                textBox3.Text = ans[place].ToString();
            }
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1) && decimal.TryParse(textBox2.Text, out decimal t2))
                {
                    x = t1;
                    y = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();
                        ans[ans.Length - 1] = (x * y).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();
                        anst[place] = (x * y).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();
                        ans[ans.Length - 1] = (x2 * y2).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();
                        anst[place] = (x2 * y2).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();
                InfiNum t2 = new InfiNum();

                t1.Value = textBox1.Text;
                t2.Value = textBox2.Text;

                if (t1._0 == false && t2._0 == false)
                {
                    x3.Value = t1.Value;
                    y3.Value = t2.Value;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;
                        ans[ans.Length - 1] = x3.Multiply(y3.Value);
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x3.Value;
                        yt[place] = y3.Value;
                        anst[place] = x3.Multiply(y3.Value);

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Subtract_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1) && decimal.TryParse(textBox2.Text, out decimal t2))
                {
                    x = t1;
                    y = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();
                        ans[ans.Length - 1] = (x - y).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();
                        anst[place] = (x - y).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();
                        ans[ans.Length - 1] = (x2 - y2).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();
                        anst[place] = (x2 - y2).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();
                InfiNum t2 = new InfiNum();

                t1.Value = textBox1.Text;
                t2.Value = textBox2.Text;

                if (t1._0 == false && t2._0 == false)
                {
                    x3.Value = t1.Value;
                    y3.Value = t2.Value;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;
                        ans[ans.Length - 1] = x3.Subtract(y3.Value);
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x3.Value;
                        yt[place] = y3.Value;
                        anst[place] = x3.Subtract(y3.Value);

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1) && decimal.TryParse(textBox2.Text, out decimal t2))
                {
                    x = t1;
                    y = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();
                        ans[ans.Length - 1] = (x / y).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();
                        anst[place] = (x / y).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();
                        ans[ans.Length - 1] = (x2 / y2).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();
                        anst[place] = (x2 / y2).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();
                InfiNum t2 = new InfiNum();

                t1.Value = textBox1.Text;
                t2.Value = textBox2.Text;

                if (t1._0 == false && t2._0 == false)
                {
                    x3.Value = t1.Value;
                    y3.Value = t2.Value;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;
                        ans[ans.Length - 1] = x3.Divide(y3.Value);
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x3.Value;
                        yt[place] = y3.Value;
                        anst[place] = x3.Divide(y3.Value);

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Square_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1))
                {
                    x = t1;
                    y = 0;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();
                        ans[ans.Length - 1] = (x * x).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();
                        anst[place] = (x * x).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1))
                {
                    x2 = t1;
                    y2 = 0;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();
                        ans[ans.Length - 1] = (x2 * x2).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();
                        anst[place] = (x2 * x2).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();

                t1.Value = textBox1.Text;

                if (t1._0 == false)
                {
                    x3.Value = t1.Value;
                    y3.Value = "0";

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;
                        ans[ans.Length - 1] = x3.Multiply(x3.Value);
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x3.Value;
                        yt[place] = y3.Value;
                        anst[place] = x3.Multiply(x3.Value);

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Cube_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1))
                {
                    x = t1;
                    y = 0;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();
                        ans[ans.Length - 1] = (x * x * x).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();
                        anst[place] = (x * x * x).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1))
                {
                    x2 = t1;
                    y2 = 0;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();
                        ans[ans.Length - 1] = (x2 * x2 * x2).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();
                        anst[place] = (x2 * x2 * x2).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();

                t1.Value = textBox1.Text;

                if (t1._0 == false)
                {
                    x3.Value = t1.Value;
                    y3.Value = "0";

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;
                        ans[ans.Length - 1] = x3.Multiply(x3.Multiply(x3.Value));
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x3.Value;
                        yt[place] = y3.Value;
                        anst[place] = x3.Multiply(x3.Multiply(x3.Value));

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Power_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1) && decimal.TryParse(textBox2.Text, out decimal t2) && BigInteger.TryParse(textBox2.Text, out BigInteger t3))
                {
                    x = t1;
                    y = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();

                        if (y < 1)
                        {
                            if (y == 0)
                            {
                                ans[ans.Length - 1] = "1";
                            }

                            else
                            {
                                ans[ans.Length - 1] = x.ToString();

                                decimal t = Math.Abs(x);

                                for (int i = 1; i < Math.Abs(y); i++)
                                {
                                    t = t * x;
                                }

                                ans[ans.Length - 1] = (x / t).ToString();
                            }
                        }

                        else
                        {
                            ans[ans.Length - 1] = x.ToString();

                            for (int i = 1; i < y; i++)
                            {
                                ans[ans.Length - 1] = (Convert.ToDecimal(ans[ans.Length - 1]) * x).ToString();
                            }
                        }
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[xt.Length - 1] = x.ToString();
                        yt[yt.Length - 1] = y.ToString();

                        if (y < 1)
                        {
                            if (y == 0)
                            {
                                anst[anst.Length - 1] = "1";
                            }

                            else
                            {
                                anst[anst.Length - 1] = x.ToString();

                                decimal t = x;

                                for (int i = 1; i < Math.Abs(y); i++)
                                {
                                    t = t * x;
                                }

                                anst[anst.Length - 1] = (x / t).ToString();
                            }
                        }

                        else
                        {
                            anst[anst.Length - 1] = x.ToString();

                            for (int i = 1; i < y; i++)
                            {
                                anst[anst.Length - 1] = (Convert.ToDecimal(anst[anst.Length - 1]) * x).ToString();
                            }
                        }

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        if (y2 < 1)
                        {
                            if (y2 == 0)
                            {
                                ans[ans.Length - 1] = "1";
                            }

                            else
                            {
                                ans[ans.Length - 1] = x2.ToString();

                                BigInteger t = x2;

                                for (int i = 1; i < BigInteger.Abs(y2); i++)
                                {
                                    t = t * x2;
                                }

                                ans[ans.Length - 1] = (x2 / t).ToString();
                            }
                        }

                        else
                        {
                            ans[ans.Length - 1] = x2.ToString();

                            for (int i = 1; i < y2; i++)
                            {
                                ans[ans.Length - 1] = (BigInteger.Parse(ans[ans.Length - 1]) * x2).ToString();
                            }
                        }
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[xt.Length - 1] = x2.ToString();
                        yt[yt.Length - 1] = y2.ToString();

                        if (y2 < 1)
                        {
                            if (y2 == 0)
                            {
                                anst[anst.Length - 1] = "1";
                            }

                            else
                            {
                                anst[anst.Length - 1] = x2.ToString();

                                BigInteger t = x2;

                                for (int i = 1; i < BigInteger.Abs(y2); i++)
                                {
                                    t = t * x2;
                                }

                                anst[anst.Length - 1] = (x2 / t).ToString();
                            }
                        }

                        else
                        {
                            anst[anst.Length - 1] = x2.ToString();

                            for (int i = 1; i < y2; i++)
                            {
                                anst[anst.Length - 1] = (BigInteger.Parse(anst[anst.Length - 1]) * x2).ToString();
                            }
                        }

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();
                InfiNum t2 = new InfiNum();

                t1.Value = textBox1.Text;
                t2.Value = textBox2.Text;

                if (t1._0 == false && t2._0 == false && BigInteger.TryParse(textBox2.Text, out BigInteger t3))
                {
                    x3.Value = t1.Value;
                    y3.Value = t2.Value;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;

                        if (y3.Smaller("1"))
                        {
                            if (y3.Value == "0.000000000000000000000000000000")
                            {
                                ans[ans.Length - 1] = "1.000000000000000000000000000000";
                            }

                            else
                            {
                                ans[ans.Length - 1] = x3.Value;

                                InfiNum t = new InfiNum();
                                t.Value = x3.Value;

                                InfiNum i1 = new InfiNum();

                                InfiNum absh1 = new InfiNum();
                                absh1.Value = i1.Subtract(y3.Value);

                                for (i1.Value = "1"; i1.Smaller(absh1.Value); i1.Value = i1.Add("1"))
                                {
                                    t.Value = t.Multiply(x3.Value);
                                }

                                ans[ans.Length - 1] = x3.Divide(t.Value);
                            }
                        }

                        else
                        {
                            ans[ans.Length - 1] = x3.Value;

                            InfiNum i1 = new InfiNum();

                            for (i1.Value = "1"; i1.Smaller(y3.Value); i1.Value = i1.Add("1"))
                            {
                                InfiNum a = new InfiNum();
                                a.Value = ans[ans.Length - 1];
                                ans[ans.Length - 1] = a.Multiply(x3.Value);
                            }
                        }
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[xt.Length - 1] = x3.Value;
                        yt[yt.Length - 1] = y3.Value;

                        if (y3.Smaller("1"))
                        {
                            if (y3.Value == "0.000000000000000000000000000000")
                            {
                                anst[anst.Length - 1] = "1.000000000000000000000000000000";
                            }

                            else
                            {
                                anst[anst.Length - 1] = x3.Value;

                                InfiNum t = new InfiNum();
                                t.Value = x3.Value;

                                InfiNum i1 = new InfiNum();

                                InfiNum absh1 = new InfiNum();
                                absh1.Value = i1.Subtract(y3.Value);

                                for (i1.Value = "1"; i1.Smaller(absh1.Value); i1.Value = i1.Add("1"))
                                {
                                    t.Value = t.Multiply(x3.Value);
                                }

                                anst[anst.Length - 1] = x3.Divide(t.Value);
                            }
                        }

                        else
                        {
                            anst[anst.Length - 1] = x3.Value;
                                
                            InfiNum a = new InfiNum();
                            for (InfiNum i = new InfiNum("1"); i.Smaller(y3.Value); i.Value = i.Add("1"))
                            {
                                a.Value = anst[anst.Length - 1];

                                anst[anst.Length - 1] = a.Multiply(x3.Value);
                            }
                        }

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        bool stop = false;

        private void Decimal_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Decimal.Checked == true)
                {
                    stop = true;

                    BigInt.Checked = false;
                    Infn.Checked = false;
                    Sqr.Enabled = true;
                    Rooting.Enabled = true;

                    stop = false;
                }

                else
                {
                    Decimal.Checked = true;
                }
            }
        }

        private void BigInt_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (BigInt.Checked == true)
                {
                    stop = true;

                    Decimal.Checked = false;
                    Infn.Checked = false;
                    Sqr.Enabled = false;
                    Rooting.Enabled = false;

                    stop = false;
                }

                else
                {
                    BigInt.Checked = true;
                }
            }
        }

        private void Sqr_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1))
                {
                    x = t1;
                    y = 0;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();

                        Root t = new Root();
                        t.Rt(x, 2, out decimal sqr);

                        ans[ans.Length - 1] = (sqr).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();

                        Root t = new Root();
                        t.Rt(x, 2, out decimal r);

                        anst[anst.Length - 1] = (r).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();
                InfiNum t2 = new InfiNum();

                t1.Value = textBox1.Text;
                t2.Value = textBox2.Text;

                if (t1._0 == false && t2._0 == false)
                {
                    x3.Value = t1.Value;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;

                        ans[ans.Length - 1] = (x3.Root("2")).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        ys[ys.Length - 1] = y3.Value;

                        anst[anst.Length - 1] = (x3.Root("2")).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Rooting_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1) && decimal.TryParse(textBox2.Text, out decimal t2) && BigInteger.TryParse(textBox2.Text, out BigInteger t3))
                {
                    x = t1;
                    y = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();

                        Root t = new Root();
                        t.Rt(x, y, out decimal sqr);

                        ans[ans.Length - 1] = (sqr).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();

                        Root t = new Root();
                        t.Rt(x, y, out decimal sqr);

                        ans[ans.Length - 1] = (sqr).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (Infn.Checked)
            {
                InfiNum t1 = new InfiNum();
                InfiNum t2 = new InfiNum();

                t1.Value = textBox1.Text;
                t2.Value = textBox2.Text;

                if (t1._0 == false && t2._0 == false && BigInteger.TryParse(textBox2.Text, out BigInteger t3))
                {
                    x3.Value = t1.Value;
                    y3.Value = t2.Value;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;

                        ans[ans.Length - 1] = (x3.Root(y3.Value));
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x3.Value;
                        yt[place] = y3.Value;

                        ans[ans.Length - 1] = (x3.Root(y3.Value)).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GCD_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if ((decimal.TryParse(textBox1.Text, out decimal t1) && decimal.TryParse(textBox2.Text, out decimal t2)) && (BigInteger.TryParse(textBox1.Text, out BigInteger t3) && BigInteger.TryParse(textBox2.Text, out BigInteger t4)))
                {
                    x2 = t3;
                    y2 = t4;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        GCDiv t = new GCDiv();
                        t.GreatestCD(x2, y2, out BigInteger res);

                        ans[ans.Length - 1] = (res).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();

                        GCDiv t = new GCDiv();
                        t.GreatestCD(x2, y2, out BigInteger res);

                        anst[anst.Length - 1] = (res).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        GCDiv t = new GCDiv();
                        t.GreatestCD(x2, y2, out BigInteger res);

                        ans[ans.Length - 1] = (res).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();

                        GCDiv t = new GCDiv();
                        t.GreatestCD(x2, y2, out BigInteger res);

                        anst[anst.Length - 1] = (res).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t3 = new InfiNum();
                InfiNum t4 = new InfiNum();

                t3.Value = textBox1.Text;
                t4.Value = textBox2.Text;

                if (t3._0 == false && t4._0 == false && BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        GCDiv t = new GCDiv();
                        t.GreatestCD(x2, y2, out BigInteger res);

                        ans[ans.Length - 1] = (res).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();

                        GCDiv t = new GCDiv();
                        t.GreatestCD(x2, y2, out BigInteger res);

                        anst[anst.Length - 1] = (res).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LCM_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if ((decimal.TryParse(textBox1.Text, out decimal t1) && decimal.TryParse(textBox2.Text, out decimal t2)) && (BigInteger.TryParse(textBox1.Text, out BigInteger t3) && BigInteger.TryParse(textBox2.Text, out BigInteger t4)))
                {
                    x2 = t3;
                    y2 = t4;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        LCMultiple t = new LCMultiple();
                        t.LeastCM(x2, y2, out BigInteger res);

                        ans[ans.Length - 1] = (res).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();

                        LCMultiple t = new LCMultiple();
                        t.LeastCM(x2, y2, out BigInteger res);

                        anst[anst.Length - 1] = (res).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        LCMultiple t = new LCMultiple();
                        t.LeastCM(x2, y2, out BigInteger res);

                        ans[ans.Length - 1] = (res).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();

                        LCMultiple t = new LCMultiple();
                        t.LeastCM(x2, y2, out BigInteger res);

                        anst[anst.Length - 1] = (res).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t3 = new InfiNum();
                InfiNum t4 = new InfiNum();

                t3.Value = textBox1.Text;
                t4.Value = textBox2.Text;

                if (t3._0 == false && t4._0 == false && BigInteger.TryParse(textBox1.Text, out BigInteger t1) && BigInteger.TryParse(textBox2.Text, out BigInteger t2))
                {
                    x2 = t1;
                    y2 = t2;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        LCMultiple t = new LCMultiple();
                        t.LeastCM(x2, y2, out BigInteger res);

                        ans[ans.Length - 1] = (res).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();

                        LCMultiple t = new LCMultiple();
                        t.LeastCM(x2, y2, out BigInteger res);

                        anst[anst.Length - 1] = (res).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Factorial_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1))
                {
                    x = t1;
                    y = 0;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();

                        ans[place] = (x).ToString();

                        for (int i = 2; i < x; i++)
                        {
                            ans[place] = (Convert.ToDecimal(ans[place]) * i).ToString();
                        }
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();

                        anst[place] = (x).ToString();

                        for (int i = 2; i < x; i++)
                        {
                            anst[place] = (Convert.ToDecimal(anst[place]) * i).ToString();
                        }

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1))
                {
                    x2 = t1;
                    y2 = 0;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        ans[place] = (x2).ToString();

                        for (int i = 2; i < x2; i++)
                        {
                            ans[place] = (BigInteger.Parse(ans[place]) * i).ToString();
                        }
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();

                        anst[place] = (x2).ToString();

                        for (int i = 2; i < x2; i++)
                        {
                            anst[place] = (BigInteger.Parse(anst[place]) * i).ToString();
                        }

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t3 = new InfiNum();

                t3.Value = textBox1.Text;

                if (t3._0 == false && BigInteger.TryParse(textBox1.Text, out BigInteger t1))
                {
                    x3.Value = t3.Value;
                    y3.Value = "0";

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x3.Value;
                        ys[ys.Length - 1] = y3.Value;

                        ans[place] = x3.Value;

                        InfiNum i1 = new InfiNum();

                        for (i1.Value = "2"; i1.Smaller(x3.Value); i1.Value = i1.Add("1"))
                        {
                            ans[place] = i1.Multiply(ans[place]);
                        }
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x3.Value;
                        yt[place] = y3.Value;

                        anst[place] = x3.Value;

                        InfiNum i1 = new InfiNum();

                        for (i1.Value = "2"; i1.Smaller(x3.Value); i1.Value = i1.Add("1"))
                        {
                            anst[place] = i1.Multiply(anst[place]);
                        }

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Prime_Click(object sender, EventArgs e)
        {
            if (Decimal.Checked)
            {
                if (decimal.TryParse(textBox1.Text, out decimal t1) && BigInteger.TryParse(textBox1.Text, out BigInteger t3))
                {
                    x2 = t3;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x.ToString();
                        ys[ys.Length - 1] = y.ToString();

                        PrimeNumbers lt = new PrimeNumbers();
                        lt.Prime_13_(x2, out string primej, out int res);

                        ans[ans.Length - 1] = (primej).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x.ToString();
                        yt[place] = y.ToString();

                        PrimeNumbers lt = new PrimeNumbers();
                        lt.Prime_13_(x2, out string primej, out int res);

                        anst[anst.Length - 1] = (primej).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (BigInt.Checked)
            {
                if (BigInteger.TryParse(textBox1.Text, out BigInteger t1))
                {
                    x2 = t1;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        PrimeNumbers lt = new PrimeNumbers();
                        lt.Prime_13_(x2, out string primej, out int res);

                        ans[ans.Length - 1] = (primej).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();

                        PrimeNumbers lt = new PrimeNumbers();
                        lt.Prime_13_(x2, out string primej, out int res);

                        anst[anst.Length - 1] = (primej).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Infn.Checked)
            {
                InfiNum t3 = new InfiNum();

                t3.Value = textBox1.Text;

                if (t3._0 == false && BigInteger.TryParse(textBox1.Text, out BigInteger t1))
                {
                    x2 = t1;

                    if (ans.Length - 1 == place)
                    {
                        Array.Resize(ref xs, xs.Length + 1);
                        Array.Resize(ref ys, ys.Length + 1);
                        Array.Resize(ref ans, ans.Length + 1);

                        place++;

                        xs[xs.Length - 1] = x2.ToString();
                        ys[ys.Length - 1] = y2.ToString();

                        PrimeNumbers lt = new PrimeNumbers();
                        lt.Prime_13_(x2, out string primej, out int res);

                        ans[ans.Length - 1] = (primej).ToString();
                    }

                    else
                    {
                        string[] xt = new string[place + 1];
                        string[] yt = new string[place + 1];
                        string[] anst = new string[place + 1];

                        for (int i = 0; i < place; i++)
                        {
                            xt[i] = xs[i];
                            yt[i] = ys[i];
                            anst[i] = ans[i];
                        }

                        xt[place] = x2.ToString();
                        yt[place] = y2.ToString();

                        PrimeNumbers lt = new PrimeNumbers();
                        lt.Prime_13_(x2, out string primej, out int res);

                        anst[anst.Length - 1] = (primej).ToString();

                        xs = xt;
                        ys = yt;
                        ans = anst;
                    }

                    textBox3.Text = ans[ans.Length - 1].ToString();
                }

                else
                {
                    MessageBox.Show("Invalid Input", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            Form1 d = new Form1();
            d.Show();
        }

        private void Thread1()
        {
            Form1 d = new Form1();
            d.Show();
        }

        private void Inf_Click(object sender, EventArgs e)
        {
            Info d = new Info();
            d.Show();
        }

        private void Infn_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Infn.Checked == true)
                {
                    stop = true;

                    Decimal.Checked = false;
                    BigInt.Checked = false;
                    Sqr.Enabled = true;
                    Rooting.Enabled = true;

                    stop = false;
                }

                else
                {
                    Infn.Checked = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InfiNum MÆ = new InfiNum("99.999999999999"); //alt+0198 alt+185 alt+204 ╠MÆ╣

            InfiNum pow100 = new InfiNum(MÆ.Pow("10000"));

            InfiNum res = new InfiNum(pow100.Value);

            for (int i = 0; i < 9; i++)
            {
                int j = 243;
                j = j * 44;

                res.Value = res.Multiply(pow100.Value);
            }

            res.Value = res.Divide(MÆ.Value);

            textBox1.Text = res.Value;
        }
    }
}

//999999999000010000499984999933343323090763510237388014956825322876773729474978225833597898991683004884030983451699401028127784606787938228972681178274012498581993441157432058855124096322138748604504146822406318380624094289380739863002587561183004481305537746227393742884984643772443352504897469174271026084916461458481402482243428109744270893154534949757004061947343116497897976523615150003985998501788921621643425580324331473981943673956333742236886835156525227232758305754452307520325104501680882887037112671250180216063218821622025352024202032580977104055566934375875039163270186170315716846537307322478829024311069887028748354818616280918741093341904695047747764202212770841023638328965191511422040582045419266260438790228996005113906546817588813195704242316069715629691040385335806883327180509875987806186037387200236501536226710087074680524264866794539990441044717230961270773325390953478742002334831611056724802557137477404790064245316825909849568140412898674907298820984524346408075536447631663219386589434840294485272444580321207710437748805446318777614970591319814312595235357643140462468743176682774163222667341329143554741907946111434428590897018209683927570611924366254252970252861559059620086830743549084513073227739288708581018549256118900482094144667630955752343971399649371414380316221222655112633967387166540824821266874215581827948376911997748277713843284035543251223138440933199789479411541728447021243123994857779213917519343872704391939106559563350894320477443398285431125253795985982227565528839122622816555033993847850954835084957588312079097378195928832668791874181072426310334027501107291615652890553624157938407257469758673966585999846201785642483687888804747575207627067343032469854344372681271088254948029543393681414513367044592355702486684345069846309649067453809390435559703140437711373726601123968989072828942331389642112112681478032810151841286601875779014370124231104247411095254948086610479188758577871407471919706692298564699760410586919243226205364852691285293674385216173729061182166592051090279607273275168711919147362764461359708563525465858939502037815665139392498272192179375996385706561881056573811286102991843736777693440157815664589010239311036418188048699786457837538646582044930805579065856024422328240924970909305554701714732286001350291417387537877593597798997338703397358543989592198646695528863069317106243356070057785769938252755323808693857043440923925387966722698762102679138919902814425199035736254626073315122882465228216846719207780409488726449099250301337152481468139508571236612509902003257138800219971023844167729907345535674898177138875468901421410944784267812291665003406364726336978331704417500612705988591252489450782617755835131825560604793138395142749824591320966960681554535568832036516391554809387332448717192640505688106947997311514714110319573508229128027803401345243993556243521618510853864931352325108866780858263752492885104504927038853236636303936232804824888593888010522906954701758087723617231320220719314243515309406274108942783803153684286941410735218513238707708498406522093530182423035655940802196475345863192911366620646552520916454079057096487755052868966898443135446350530007227533759943752037598139516378226839229582074593662684337845029008629385817328452296646607695847285192126736740952945150646621031956735323476659559334111861355566391386952158760464410261802771230338484548085513299614724883615285836641086737059300677742934641274885936470299243376749075621617250842749821585450756175160635431617094105725256521989133227325980167085404412588748767644549610955247998873592500650380556073768379751886003389221105550563959082340652874275921905885251627908728427742312739524307584234617165464019874314147103283042124689154287894968157082599354900831461076229244093058061043690208113183838975099884538219365217784913647198148212144347655002159972886838685929290774408139055062859824554285881735652933300300343835985105965189024813339589617467790235256588120173920878808199471379585705639064047158094400889097366780321505025990591428355676059431300598213695091538144863560968933243921042747464291753709601271334428476425923307000887051995524793189548303468217981607479844753635685790303781606925668986507325850790643686186319696784862420579568705493558258455830112633460115309511181956266031167896299148217631439048178873560807920750735066358873127695405644504901941816158135789782408927325533907769916504540464115278245360307974929586262280533060820713041309147834344385743008657273682332024122990285500860427451126550656185433982129617805623984917474463442842325728198988802494177213071200650317145581825498708795275089499234462285271173277771829212981659294493735973056101611060300446067829058623382804696665331029667617367812741799599015597916449619935769789135077839750386790742760401113109430193694371277535696633947154168888403116492492607625217472965288036062388400815048589536758700116200136994961399221399398444334902892461987851895772280994545233814317940439655430242876577666925638459022921565211292620443697734157473552573434783008446695979820678760221554569709209118183759330659884566974188506667612496141527334611657824313459395076776029661631820740401181391893093862865969069801487185063504021999811832395814068169706603485958499514884332200815438647181531746694311141427807799325873853564667522780835634212678344595357094077179927315663688153749153603947045055748628709434732651392988338699111257329954947997333498922079447244434085744034496218460942046270026335271003357705909615267119930303739900147468862027237503761461442006743667793534536595591387330396515019573736564003549858078037769695149978630335774340041174278264687667060104255280752662068765275409256131975759909297832817549994821521245889443821713516380906852664601755095006557626472519282698206251743243463033766896757376429623452876999746222639893436497168801216977752428465380088731041513699242837459786425384985222563319761149500981852284515966496880653382559862906597322153662748554493043992658359345261465507092899261769886533972484039604880774907852304561862011920676729792154189798956060637031054217401578753544007951933503692088130138379596415307898864369874354710413766837150617815703655056010599529097874756892279641374989982494795239725999230451602711348426848093521126133998360060281223144497769151182565972855506533311974128076428646546001089227282089472108464262851995203307383194957987487463235817177560882901736365296458084075245558524023334415869953436897468497275155229222416264785575381005022969382826348109668662423929599712345529551271624575751695510420634294775456638614035579991014440914236614520646475259728505194738507415194853177862296320857176121406688834324021770398835959618499635992317398565869774935580883043645536022112193722838521631709695377727781765436786362389208035263281064205337865868194454337792386683527245122854185381943268614001662387032903838788405930838180115248005775283756204913973644945489198561261071075904172806796192014700176874234402653960626098423475968249063423718369505900466505000870173297654680513664199680214384369074552640769820804112239613277464062410567553070956344974787931459861655701015321875083419548645304118880404190150881654997304644774778889370490372283479943004240452836461171707494742291026871492958343612111232939900525082711153600929353880394048883174402031400256524251636678371760799038905997443457974013994634099976113656923883343392721894176656694332010900292592437108633129359982252379282088154666088100295879425808912558598559020353956079290244192193209712692183705600708747998328370577576595909944770504163965840895117383964272165010650254941445384773547282135469926829547199830698456252665739645928151876669909320495558918140135531241129840239321678972914162669256840481931565952220103074067252047812322988360610035933691440306225022475897938435791535892565375150122626559140928506699288036049854146032595524739975803523841948100785364621588936539776024430477452842803043393553616225945651646294416620569143331322484426458158561489469178198931284624888478799857022960431500933788006255391212579692248072393912957079312718664660639661145999143293057164448729313719452528289466388736238070061236073686974720827079033021123562616561576535917734782188416453615577322659963219581569594582697869249160078672573789489507094231047115168648942172205825134414199782972742722526020401688075501848510652813575844065152000191498622923086944402770302054157914008149588010573014139887574155336248806769087474529152216529917523886072243190146697479048941053990814563196895819083867597110059306186619619103875747486123284296120263337497481748385072656248045579805969830411630814890017539728492543611427259862317281755851144092272479698761512000848447599125668974915594044420057809818412070459980253026964357306506763443597927472644135543894401553082745441538000593694604536988796017411795435166901819586035272129833636236161822326887779778674321740710732993274650024668001253140340944868671190754008032863758398351317728844191877930237091051015810511859245832166199580111454542370322818278361313751752659999902424545613176433863821847347801644211262767977385873888895764099253397492045365438897855252867008973206784614860584602986946182968863278089443002180831651686816768201210356361562549234703755239215262633442459920984121680324956722855881440491058091125914010932325362165742462434463059452255115353112034429834676453314794952123723379529599997648223684986431932224842333515404190050591196298300821175802021919360168672476033189195599729978957355551379637586742315257739430056201901735948553574170133589698515756093964546520538881379166866230237075521171108716789418647294505737763352619609316201273331698040796465032873018097751762917786820687363805473345487684011986695989129884640837967770174852169387028773870637323685896435784250893517432677255515701100054338592336836964995268490762082954339004970109847283809801251414207698935005324052606155864628040022780787806970096220947389908717514571710343711791520166537957225455403631573808868613620113843585969969559670741285468964577491704178365205770905584447078082618210307585269224986773563095622186312471888543377532060639355581749414269860573181033411664167121073924948080643254753898708790433900259301120494933081080554737476520441221544566553615878894782317622014339715612107877950148693649357743218288103612059033138993039631779992613105489002303063935053969481545174081476634920273732223454884013823608776399650631843237387268011831199389205651356869728310873235247555747195161051359047055056225456947418217446973083761501928785710129757817373740957365875031002711043626650296761816419299049910948924539912301402415002526636957650692464966879728347651289513201954755419823664938047444771421002924511520380710509177424656238030761857276349021575191423137862455588143733906829318666095148201855311666433549550339755189941170569830333915931389679454149410595244993147715867229507082301396843300757916675990350567993410447449046376157797341356239475137774746629716084166364305196869480948897415027938924978262315576203826735586201311656471342844928664546617150868990769535875267579634350018684377701905789900335740897812714415920396783530413243829042086108124492328063976294660890638712031089408837942737621580407602834594438140364086955852309499231824851527540118227702310188393684974603798351373205068460698732918157719541065087250737104948394009410208779607527064123365130180092266254404241133520163857188458787199108210204054247182536114715195797333696775333775813546225101077440361244020981784299362826852916626575103133143340021797945158303630123919876630456027258707074162290648952081299047085362392692929726423003623082168560440890557975525633013954151872977011848100211377686866417104575585264559135341929263938509907644536648572097623875813642874236866401270202634785932030707508793914093512023468207327225370249602338236480826286846681229258107686584546840380307410911508512519930852585368809773714558706518297805832249323727163905897270740039229444563959511132643640276194373942362471360030334961825123349103621337843642985699135376193535895511560851348880105576249902786177824805435921667657199063407904142997834552564155103696901843319177925967168943721563868766210408944644770782421167803847907230523861847137185391270144416042838242521479077388910250300114870344333565073142582272789177315121845941032616646656252453888905437802646627999570280176950369586344508139212651023130273342547546422515900173125854793958258441312170272435150387957839507585066982722166181441417666867154252840189773667063087928859060363462677933346821835852730044331440185942811936078631481037539093720865013685995853794035307141825680539743454616001844590803350270174619863730646971175738827879996185218611059581674670565266399777331296955218717582885485712825534203763629889662554646365999695216009623113380687466042947942588601740239875498030850509351622056975254001055308227071379049042256540926481771056591727521831045583196544432892386238557952279117027881046872723920059116905961602337217028820509943705803179187828982089058186685001954091187713613043168927873676602256013652632615876855002892938899301828626325455917424070777352158799803857296654629052674814927593535262723632684539227370564681826267054646705147335504230046974296124135083933858061318503975351042154394990968028790414587481158053040180065590942466783570128018064447263204710751186350144233672423173392046552017185529288568342760730135882397286687151740106424307076671099390551156937170651766029989826127321209875033101361305089282136138441733545478458075743258092272151481989238224714330411772973980699825219697200518008587511906220831555341769021085481171254130509188293738861819244741345288928725482594498514306900394955355711002156152408057044138234609304495809049210180325646345208449347590202628502243074117510856075881552012104561427480993204056274439413701769578638097505849890920142759054810454513898332311248509075654477507122326618174574798104631072892887523838322123158753960066137907158694169249795408770443119724399569150781464623283959001530454071512025137795709863556351968931662420047232058736195072571353909791544700993783432653010656013303915594423346018478156188928830666867082910787421755213661127297260958510376179191840860111841239794936202082948883984292098969805080328759317186736893451313458151113451828367583224756596630391276264774754431447304227610900655749284453142318364575276645518533196277460438717713060038843635377562235911610195484709589335610509035807645121215836777720942402569957437736174973234335328360570026965254502451571271734763408390565680064006018609325302636128762589648827493316692287566146701104327439715139728645613301363847959267073616041868145313754268534743134181777580754564477118913172912503200869347158380120247261500882022042714138203900137333544078220607210465363189214610859333088392665163465447077991306252407049171573307290758436207325125063406070922665034986064524423787599364775949392987376359269704782188842709465172985867152207895487782749335936719076536589887398091377096785543065845040723485597129455870985575687687118884257078131649979564310306492765972301184084227419614930910078202638619397465207042279628359606688761304296387597447354071522253168426636110524733637199829253677762759435884413435892367080264607673170060972389536831945216193580221190813039958699422807688335806404154043136153223658579745915697207680368886428771388885259321713187775156283264438805025205025366660271546000716693778638533520784314262943332833804998517365878343186514169559219481010631239497215454653271209239639723968845053857408429071799437686816538894236346628365704324293494532713949417036465933000815455980706082322991048767693824694952621663852904871866615419280332608073756943317114295637212992978861233356461849500296386154735360739090109570655108170254130352031062509185476497287591172529381333153478791493691649002339389490529983885435490141606448564018906310049528563559883524799558887626428948966699287124161504851389163792061843359697709985328868329251485115770612797574088006946779640026035631466068958460276625174871240444662830581167303030938822875008449579259872086952600900389480494282726741196498394935083220142252408652037510851863511424605908533362376924220325393116396607540052121665894599243033044966104664229104109036369354149236229235434059944012830376082356850111163259996175737617669755307471022072618106787346736484283123386852736551349060368393484679392830880030722865028342037839154136455966388496441166845241922944207448172806364291453633571930902346017834088853463302253741603210442207303731639463214995715693931512526010204627152885303860166848368828813819334687170201313772391278295315042271527719955622688218239412394934209033418656849525430673346590189186973599485635248615519812907647984287886646619238865973015698060946490122443287581308273048077132415760521024564126389614468828666671406051243047411234156132508288747170574786150233124542919537275335266814566461898068886706041877519656004091566849575705333907192565203534254738509135316159851377376088292355332051056670970940511075287447135891356194932878080332015809948171965745777013138240870632259574052836670121584013936193278136160971677072774392699511643036936890705061368371260343292179813882862332566011904446414807424616052926787769202025039034451975561144815344288762313473825324779863524823762283248394267803518876191425439363602577338783657784879573193590663415717753058161878618572598114166443350636000515880535927741169872833985215063008426712925907361344649645624870436524399995887803020233457431465399842352371853684050082779991702774247740418073101304077573162252138074818461594482452583295369591906853399373034769565773889901975252120162081297348216000994275774288982750980942751654112441855963749644423473963774858034647555032708047743324292951428783688890629598473076310465293359548394698031590622930869855063938424291103686808085497035988461370695146708013191304635423929254614519061492636037198418057650569604503073369043814699950626242143384363820211246995337439746232841261113566392271980786257255247235609289480377769088920542642397055544831566287950112543512581351544663442794285384639854219098161026955030606246231551106283978153756751803348393206080251049409695680676267880456837719164773644778236524103219495425572904951397278075690840676160419591354985675342238824130806677247954317838747330787291277272721847851687579520860773576133026260930383385849444853941601422222752084299457910772515725532801893270813294364451746020154774975239599803286437389497282000317873878378276598876998884837975423533869331921780041144639236107750626693218189725233007154407763013162313765582728339642135638604959932381722716052568577529766113456929225433358240367677189284456412327938036011267388752412497348433662469077097281503345670659424132952223353829343122895428922564428597053347066535898872838094490907002575781962951047747800490094253903814526888500604816360561766788201753958149777835963029903499368952093325574043317117535523489904735594552241522984736992460409165672103486935683204216937314476819637118348244472654166608966516345182316514744818501807714443044439722681638647663791531374509418453780787268496136531674575031368340131247228215018497692400567570536191110135746637521857706183459984505116300281036707853770224960905122547257154128241739692776796098998659276779826565643969693666352762410577331340303621060805894628618084051398717576705714973439943048137567440841874968532380694734289836462803555576360929428442352753078888940251991154740770262923698933020812676733033063966336167758870650313823997469020571359260402189600088089307458114911147080305130573629499846880864139126156470364484035715223331064007786787609857131862537876776797344398015552898530792776818896963858972737620638526027978173776602350077827062415602361868504141831483360961427946584151022582233374824546943021535982499334071888099109751620455589659265883971730072082570507178710333876016237291585070000992723054814811797917964988477619124453334237203790307991049025548589570210730090139541160855049584325326282078898693726728697079740130644894574685587997399211698596137533401209579311793416900931310847487744161424200602122988277869030272594062855865083535343007340943133264645913894512704189305862921540400520577123195556040887947016768626727645573037469584735388059596369667730242649837681507103617273223897395638450352711746185246707098590541044910891812942682012701443552141103341416722820818268806104568115207409755041844593574826084574638875970844968252223430095966267503696580134931344834475739504471560206408300300591160091515194571097895276071647679984985331155265672420895332313707653245315625279538941048856394160180389463045388058407204992205859185432684741134684305273563672516154306057439548001908169922617067757080647653846171119958637130185632269460082889399887383364244653138786909258050773472451446735015294233580913245364112000705073648616333998767930549878584451835435847293647454280690636018821912142077650889773413975163651156750449579930391063119873536083416606087846235813353207913554814150097180130207937918170803408300365935259840070052550391728235541196559734701679934863738373197277556411865919866905158276676228998477992035409530824267744739816848214247553111872205788591697927858314481704710936960413261642124295419516587786669504796736558815016164089003598598506008061905355219731587742920295581790533936454368799583369147529860837633092027768689581893317235056517588084732970070681309457755606100804501939256638970508871605875821140709629383553326135290531309922782191436792967234401263894632030975840359544848430192226007106116923860682889762513049632047274096766139240223941967870771054179545010792011545414982483926301540212024755689196401154341418276088302663074998040975951874335324732618719948582008723102661692867202140588216065527939993168705499879336691264951256755307364921878130286310502911015571894411319694238487444515283518446734858469379576682051149678047969957018550969490711291498739259664482190266113832005757724745764303067257687096533524457950082003150653818587461459269375190825318662504611929898584065312638070645677453739785493386700802324569845669403985636565434438794397318719477129411613857364920195890090021859590117322490885909680843146872679803838532119243486138562985920520190805799280266249240226733381010932681846058761143286485807060064080033351067588758520462521034148361787805204505833690722730123763760024711426616549592126876674540926373695336220604954975159165546445621272760322212977511804609812113959181986509750958696434963455739002547799425648885037838412077664388464117032789711846573650124223756214839917388254434302943458594528469649259880021932279564458496655450841024739453474376243606901998845634381421055434862464113754978846041795477712838317715460236915820977082010651622275457760909087945903231665233788996662543250393684764972235776572382258428675864478774959686157006338706224725498039802396097656338390186734910349602638314542774631816595348762500879020746168126101958484918503860554458433536516215734815499156189512067666638638152703788518279376608644828911958165412554103889940969943207051648398296666989862305234546936222721884740767903051826943268423624849902797639002408275686119401755701006664910051550101994133168951886285542255434099523556200609310539549639030577714868800097357599306821233818070843229356910543009847720845645927899224943313153202642192571564781054945865820756622044514004752836214319874868925856735802375568840394829643986019381857601866543829813902884406778855115206257542046106213635966508938815215793054940666633871779983089466832596090755511758452582206275600595956768448410544186228379534274341410700806986324036797217002162811698978478850194343228693187766719415896348967486269356650947041162600716753857623953705610704674007688998108594667813290692299361659355873185656301306832810875660234690471850646993580997780124099586317166521246811986830143768693600225091957134584165893219666944782637141263748804896023696111859225046369455453267602405849281281756020487120317753763849545513090920571336737994725982085691968274909234177055761086252628625027100108961574357260572059285670918136539666283822703063886434956620637611168871114912171892423023204015678877757290207618005409650105982023822535139285323051955423957630052218112454423047592494694751372181066173330432765338681368711826346424161322060377664571259108201954709275387585485005947888024715492720156065611645185013815739371932614671195934806157221496443220390438830162414828049343861619259702955072564993917398535248190466915966612408064773784101041815787597955987625579079771579174209615644785979205515804218796841280029041956943563050189611046758342237697049345854130505827624914164297915232152723681077237646321368068647761170470559023392910042662729060575374901498777049517257073375188841866989680644738141430639875872605359812067804552495596118565379630347890867470698676277085025772472913238603058835124414662536195597923355494792996842791305202258340278763998378370147537536042975680652347711363798761327799809072978980312798709187612217984115557666487166412291059580729262845771544680301185303777328950589006955384074713486567073358159341519948798742655589253898445141469895372804146361124411896402356953932941766709280093537944722993224643126771892469783562304584244980668771823643342556068246908148529766963819614206666746880389849451485753571886548570675863341462977157594473631632267597648329664249713199547467072304859827666911489026777564449060685391889606494033768913472314204509019973228100101685409824986848867980539714083049493663959909055260616273897988967654213308958776392373537549645309200763960631867117782446451435754461202596882003794294932120576798954892476550870133083811938379144082032497644032081809578886901963885033608269353954094152976064668942095120804255019845397535260562143861027666184291548517800730011681927571114260592391720828196898769905820820481602633648235049204344013881843632622270056702857061971942547063892841668367273881778360425108958335303784119754209904766937336607194007716905620893487747322178092964471045655052210494172449276743440381817708261865477557875273800255261773206597078848764306241044744766217072666552728603912066975722200919087391174747915285646571400064236079475295093075599821041179705182234018900400723500096538968625499790226345328534122391481745714572820471666385442842429933745272278174841132306281988012170206971939537455417005130551881075672504994863220236937337784791134421261517497582504808502218243418910801434254122906199365704905412713068964360355656072734150639542908774881219544132052515823522426702143664237544338137597568734991387486508245502234006125100217026711926992749603473834347396243391404957497299445648404916921630425782768604210893879444468471236120266353993787251559360687949938207936811984302915378316718844978275890239122153960279002370612021856054288542660922563741735122464671103094938663812335784065378567652328684013390853936251668685242227630866758536437684813235053746798558300689548470077970542929213912955522760677861236857037653208589419952150726153795842616884835848035522502805523344198656204309421614561782799790549666049206212937680477845485351840954039631941304956321199401985597548797171913790373816130146292344991382270183330841276314469278708653174959791278419225012122190689544755078676493696636874495068284085188441450913829594212561220417815349271850135794598497160638118066044282635941127449493244610122653709075950093085916278550825968899250387815947613919627277306817498962464957661493312578876468066244334251647511975237923263389566505325752420919882431314602831935958435183813471488364235319453178095112117369409229689947486682396530140959252187746657623328312204110172855968243372517791769939593308547708418574289043440642494560461070974894736873528362931964381505296493119452534710573817744349063913024228633154746201832316836021488513378558908514637264507952983650371166855197269974158440076344893098901783536629486645584314413774877192007997234111092334072118886583759366487833436537643633502129532101545692998843075294747779387343773514021131325748926879648595944959595417050391041998571543742154357559603153445762021016183869209753895836861957092135361406178920899219363386957496516251748005072964993159636499586786822784104033139065278284659457960952934718219361299336754548810221350915066658489916027730080377567191359778217182719481734672646145925895879236321443695986780158470542571755264166622970335888582673377905971954838789274532256446219246372375450440916246535580019643914761112073753332598238901655110526903395846776614116127359265734183589938102510021338989894461212093023390351015913611043683378133309755706217329439143955788554835091157767958183836520430270920428084572815329971448325350845745207895582671690350229850616158073510231577167492388812068793190951405250593620812691674111144634801869251896991274882075444263373753820024476972737704065818093843497613469571328182549474583116983293789155088335324574195362387065649342453936914810900079352076370556161307701491171987370937934243534730493605615880977910945523368441917596340367551081939362398054602351658536574665291117369761065014940761093399525837936927570938671624267316292271177128329246883551837295979368615801448726423822838912501404117535517811885879975408535660781102716930942677200276066656760883282218303468577336565549752854784866986185152901818302260565204780822199687597396536677884429563035346159640675268278828733389279728709286103418606410919548705028388840867810143325452958148921740768817084114359158854099553228830670411616887311524487621729467439892475726802809593300486638953549201305409103730056854232935803300564713153057408658530991665011925412227705123211892439624655389441982683286950164283590236971798399218058679350867651734351302800895712941774141451612626138040504137799805876684049313157448477589473776955442609143119290494118985235072878875388953775441472773227812927423294797602677905951544386147917540156356206270791834738468572287418013445998759345118926504871443437062889824148772473918431765095591188415761907002521033289707301556710896341012054396163648548842717590772344891910303068612476252898332750636145536408957483247199410620620340831241715570513404424800202717821732861700130801011654798354478005131215939828487435283766221212296954127988659840041716718671034744167890445571505591188185671616454937757627582486780331742996509112657187907114929219068526196527155549044441460558730269636519773464571236157984094529959657834556125347991946226066886040702652019070680130930173247455050542135029136901280505740035583260378320429901514829698715906128214487094558230901048367844417262890309681392560505739256871595469669270261092178925986178184339146983705982616411428060777415139017395799840083478195184955462403419510279708076110215800960961711737617639408475109305165465212699761801449798810840328953967391198524126529454429346850603193139427807821455561376674446445834709005170739650026306062013902956542085720191372429578751759904662640189912316509091837372786428215418330260080998460662439204548523181942120491625452570455673418649190137515549087230767595340251100883959263948322880804149269803319534357006833334609055793972126082450849192924799401544347469474723498938434382640533024913764699828949559388484516618490507828903657784907398604802215406373973937749910653134496391672056035543590931752859012489461851887689573653353563618818644622289813608299119482907011825693223636484405108278490853832784176902511608712377243608103676182369192501763385505038004157796730617108682086252397404825155960464916946468247794266281068225633955433935539075020755261181832680241257838225671562181932083722912481356059010782109884769877023191402658505140095598711483676845423240127515625394087290589168723632513350495311828466535832755514287521324800773483149389581749701302973124894998647348303127269956746035830956084086229789053681605976901851356203862873416024928411135748154971211310547236251641773021101934247639848210211686311330841158585750348915320107875040144942611214501545910859333969170167686741095857393016291360750939366278608072244480700765689201483359374923324427278125304912381181318993291567188391001890924305669990021110837564985399009604300983145613596531425555649123946186753304864011060644961936703118021304269232259933901790165438472492448475512157491191418135986474851386166613145649656578109208826850049465212170688406895304433807681346287155591262287021603118977695282909472273478181696512961231207919445856607803029813935699045865346737619739410730095159852313144899035675928301159042707482842900409310434947528897311200866881403806233500392922613056454910760693438644591851167896833404958976452063445686049315296425091485227544221500790631631058846789158956355348100356360965843966017746751421081631802845383639400275488695720931004479130118614429364256465398849744855964833251030511626609849467586013217312565083739867143578757000548393899136271568327696818951326767924507534431463912315848833131925765010217587634361431310717897637203452930854929984728460457024520780056079618132450069298714304000794870278865793934591372006712992394590883517123343741611925905021482315826416590734765480157774223776293969819310635061213654999267912004868839661046327074991174128134890596899222962438653705537812019789774827216506144589833011034164384453952422193515738651276193640436753893112610072830415658407451311253041729974053338135211009225307666339061154133612138041205527508981834247182727582702641966539966379762776387910587852849027781837883426089226856833647766259994128593017081735732569881059829516042658892191256190305746618014437085233817967955695289745908656275200467959088493549659293722575658125078927552346806964278179903494816713977581292686537531044269040769497554990342636574569582267172720260254153367889738886873288071477658962920216266229691407949813446955855103385307095101744370095040320106007009389383861356287924284117121915300011344993353359211889313860306392615106051319214836625302390192597147176064730712790006585379345189390802862142558750756498341389018750336355357671456728127759744291820263799470561714487174837554667828512033321627417090900937439871054905623643629989083341214494782241216139109145405927906696372299366686912519384716957275229733824943735464101990065384254709407237835870017190951459561607552468991536709382494376018771366049193365192314817558357642415426706096379222190115293725851375845120043605878344998092699247523275486157873566647171273544598707924704451440138481205943882039363795343451135211857962832689366598673169943104130632298895726314697320343552833825152972857765317268602396098511702296091140864286249594595143334963474836465680471416699494563500953899703306069785722502854510304290809934856178158245047875093142360673873011592655568218092675445981445504761996768983960593731727710471599918552930081016188609610610382026941125985742160391754034486257574759393608167360830017412331841774409409714340401920886376414496997302885350700830386423441721707515860457649464334173200221139396714804153360361050249547342910361454394563385873033619795563044848539544723006376878569773777730723589395946458407864663370100692832428069169677981968658608974729065440284850285085399718198102476576286985983305882053673878146443721299499402694187626443235199854939428274908825992247093575895696285890252043120106070071529653015754412097447502128572942195022811687711539218946833633147660703716368733579457757525971062424003716625956845268981248160954197239963527362377915918783131556030824377837883693969535777581123358062954568299351167459640330753768029535024274540759128737730588849336945982722560201525244796654261476476301140860421392991724392244491181754268237347958105104712566833931233225352851334098230127284913017943845539269358687932405063924718338605120196159926637301733469673511854400788998086596056605034963234885550460864557258531773497073575640904244437762310749001402085994008531764731889540737335031212305866492500118084038515222313941874346963263849946366061141969555079749752106928390395535992853234124916506176674175828492777770965261556733539791506989611117118617894982439599613410853730173762606900405084313763188113650958621713191492504553356590646436106110947103294923026879359321917886106388210945877383871880523434650025699213987075142529231776443367718226483230845740762342827341586199441375288357486238897290573732880684337783060687561925212800679884979664121568606357963893846176422655927955737248685617749029590894741338778040430158311405391473217709172279292595682172252687406626623915611751738570408442234523355168892824763995362131239716945482744886287253603480469931892914084750433935329709928557546712442191755938464064035562742881705680465282834277491010967169462136104413748312389397613719131859861868030102827836781952556555615230078258729330905844013523010164908132285596340774632653451974918109148396808343873370208165664136456718325067615831677688322022930029277247589604464272331071473230697038554838379144323492157712255350737295878886839094160193513993503012897066106528776637990605462681337521117038942725210910647233583061695418465078573506365839215330664358328424654648421419875611274741986660712950271548578614458233633630868989560013050568267770378507886907836701163819005136736236463680758043373501904226613042623782868333741509859737251777759611414477474677819999415473283997721023397673645135878795301548481081917507875307524033515673556569338250714496422383952901294847852951779524582842334489851007442805259726683376538982424403947279481137607614096564227919332302851143838290524134118505686281053993239507212477974014400526609814545950158124771301253346488187731746340963062216424630963105609680659993056316035407226352602669300796169947032782008534098230795310469928537336685317536806449491609470075810131881020043476401175459226757333302856703683072881669538897981378398588109835463438946773139712984874371150744606611702833605317020746248009802967085753121080003580550603707181331330790427799927891375953544064870933318921821566819186799925246463260087690364874583040053477318671940330645583125989877752243711113236471815333857834841192951725764222862706445204680204875200870095557272620808906136948090990589870478144472129584443221168275075849019263304657027176989624615803896011666743990455731477433371018733673476270581702016099155526813144556211222299051271919821088972064071264472763841007432881857535432615187602594488632885077845483785195572255656642035665440317815326156497915955620697887386321929225387255018244159346842129245456496576542854691327664096950948694115719822401421085620520050135890201729086025064771302851208819581703635701093898489784922459825630824297247938063337016788300637709359544117427960526361459034020589535243478549298444107286001409827836407555573454343743291074522617607148980424494910285141793641149454928814699122671339698341674839476739525424207517488894486960014333646537559103465246411577449054316445122955768510557587971708777593125731885892473194346370202187626537354357280603450338550924242303460344350022579269395256800767690665962824933388427791860532610333491906827651770578701866083838672737339256483765556360676668868792310427432512114522092631737498671275392165829362597611145052911795840898537618056756059166601463540104368100575973430110206799127810315630681582677754066218089959891187410723717331989721263362746254983384230698988214019093432530575976209351528016898645217867691470366253554970058303155901227655433157850342432965058493407075782181830014035314243710381185492880511537490026680949930363397396080287093315995965051135364363387382003635398556327240652723744715444066080300377696073843306031566881290319708276225891702801170963665662602131342832756546791970972162926357351022858694640693086705979989748902111612019147950606069275358444792595737206381978776347463391067431319177226452665680624560877622156107579599861463419996099446135586700095478009607156898249304744149096978730318746764161545431116432225139802457301807755456119641706061160315596222385501510705465408015744098106557297704331905076662352257719115323962435705986937783088471437639646501629986191660177776432575150507253120153450039643239866478667927426775601721933826576178544809196410522286466987720857957249305251543201102929082935029840048021582993728705235902044986036127704821545003304251892308326778618918842745270258977301407278229409603790049403510437663795987102619650784690668369381544713233002092730365842468166035921191334696857111505264629028992830780547979644328664587767598261711051785990052841911863229310390461782877366662037157649343951592410939384197480758745529301628194152808627671549676596150146967690560676235318866590594629967496047735126369790819219481468525014874887548828139268897527946173212909742412820491780975973355516762477269839579112959223119802889588147419709921051109871123411036312026225973844849384943619816488365029041368378328832717281188821688767861030911274392705739330509606098269715119091720113960520524753732442495408114424887441590252235683394682905414327218601059203290506009299154579155069948060167892097565121663129730384733711346351834764528943993534673592496005557259442720584140416057354166066484682300694447949575340939483850321117140213706155297012975017832019790883154563341686558861860414066761078158204292405633493155774240823131675260561580856326164717025429619935039814703713722718723270735867745631089555877014781704703920530147073102898309951295631828610260621411047320082369131582232630317393852288999007689090834365834458468006447524291981283811474000834332734543455005019344535427854074109691700646803080401033828995127474248563734827094753104946618712084840633631753634147425159622215557093789908339367162345911193351920521454746644057259763249743521723036692318788934920879037143353913601813776833908978216124589026182868658309622246007579929734614818563362523528717265461844096338814492558556171948910690985655730229570008380263196868721374921600041814759145372419443852099085426627303547462218548543484778406631612023886870630478116915489970929892351886283582771886725365948392683028836197039982203391959797796937129708613288995300403777630137203107354987399226814571511547376144100938873962853013369841961715162135947143899870235766658740114041083073021844251593539801311196479950341116224806325231352621444356030776462243365912480445984312114625757399807114641158863711010584547746730372727184854291780651347188486662559138861307970553560548109421362948562818374052739182806846694279760488722308913960512256387941340025370523919739445757260038916722409056992799548950485668044323035595141773176347616036256497629686781378949053677952428530437353318180042276747914385631816203664763705618714903328189665090128131794428211383684760576124549556153841643055982519552990071855885258933991596242525567825034881566341795127377697871282378023071937374138620470735490132899903918381053270605079721174450866373272154218993764187850363267202404760274761035143292775913561347822928931014449212758505443831329934430316937829962496867620145486862767442532038192586992407280157189582199065228041368231027021374780550792483784100989724217026460126188703531159432562233144921175196687671031413996191239722836504629541976495472551282329652056442205197133128720585133392416483468236076723571953125678145258785149143808884761529555002651361525282620446319195098928702249111272933450716133476899210323266075322867350781710341360739579074901901164110083237980700091513894916026258149974557488148316627024443826158111191188058267363000383001009819046245009999270007696129995165708926420878828841240320998291264790357512352447461429110339549700435034023300438384661522003817202113827610832801005772742225366018788782673422752548829028970484470350172196609580145493414783646002506346607875125366326385483849236694594154359978281484012769580046483431118164415983111811877995203800441186061029554311848745541935526231119409135598037677257553267638010385195513677540732324534653760222023198091350993893054603230921454938899295295463776717084035178273092966011133557517178192856890452116707009826812326853272880669656632970769303044726470990390571723710923570022310191714904674549691743716546174894424654385484705397591131490148448800625073460468004386919044364060122351902504682462889021787628944915610777434477454322400054036145918279627964313199746178108498744373819004622128364937034397680244192678228171411668820516418820866421893728552036540327312496961672630109886995402556443693550032840846736142203618643339955268270671964619411622167677003967049670490963486598920736671266094445916054627386274790579466256840594761891592076921368771686800498076765519007342172026249129859979862668512587606653251966926301795480034007150058092761793082482887462430280261772414787440756777531050018507080600182182035326633472234417812846292936467504248202362557540801901742033561329980904859059543601788454541243175745572399609099020249159288928585075048400185261824444173958078828117628114804451828613073765885718901691434225095012556304689197745070132274478674592375346556960160820775699165250910052525250420863846466007570601841715775134643586804373091349745782579425234951325263437751252103961379522569208516435647580169944491388430870905951017458748685802570753829041730474552950640201083754042740255328525455311715146123998049126251712366800038354607482877163872453413820584668804625840865522613706383380513053026425394001140770507985309282393073119163093673391146944702297710297494089983093619024873841569265219251765932756351542520999414622702597325018753036991590125481435044625623123564395205434732688047397713956103605751130552512140735390015243513838250538291679522855486717852222215719854110317003770532183353106209169901019783317110944398042773509499724866409894795531229506998222563776395233099312888427294996017433489149853050280498762523497801492446164114137332540082352909509476057905688322519903386716305823467417626098038950694238063301698803575104042218449643920748061859983090649824557311665891055027809545008975984092584948800506833823298431106467484234742929774993101116356463952063137756187545395871375551612160411260649513442969922470285160046115524471379547112534122532260721870404388479424733188096645993892406947781950396004991927822611116784138923988467678908345106031342474072489223447827459829766207963198183552888252220466314757594787052540716184694740262458480525935155686069179552210892007160816040058699720004604639841912947968405608799634408594949178935708172275046963388501237197272334825763404636106868348570443221856579907864711063546027366006072595253659379943497887392652344412114585893382849814117297556519229614335299834086296175915810502754320584110109375717104208131180151516208016109163016348102306473475942260275050810377140882216440634750648806061313506875018570078435241548240066453846425530263424683598428734760288391076741208953290391705291426172164881246392921126416904514570606448810399946957087940848207741162090678883249318367777682293679506489369653057877116225183155032322691602807456125542056369662883172665849905569221625622178657094760556071530736039103626156750237697200322084590322053902267559955319882872560719957247335992580388422283296273410453196086091823503678863424346115591139028051321276230739417613122837775923069808413831077628443923326739271853288215675107627085419362214369294034288479418833216961965317150418911854114363541449692766626197868741518851717093000028676809680977130382175719163232958723889676367887288576119479229717898248568810470525642351829717628283122088621562309397278952410397646224321146203024966230203663173945630997966625128958754170916996714209579244483190291425987144564870089937173800625690188291303811727477405369887851044633875902208425415885603259700178175813816448526589940214217674817092936755572450298202779148612950119848121302853624300882055025679006781018646842719126946501364932667332204795114483800307185993723242840458216189837644660688360874175084558684357625293981705498345517921481742007876219513947024805600200260699185836919735255214344745582500468076662502262036537037407310930373657927985707614065330397086341168243641562705042871941016985249322780977570618756518183659883390214727090748763472363052164138698558887559326423938088252499710439658267577918966730919496201784661235221140677162234279675762724912258785536010464996239919142015598291705696795756276506208236089186002497221739745483209892391308179154129809739104877606771974119589310297034077346109540792120739422446822994243018354831016764629549647050079238077571517085475793455943389828926744823376819984654095453778894912642446916822733274652627628924719938341361110055799976337228201735118718413426064004471980741901620113004194104600025641817466776112613422914409477494531719682660811685707766528682826769136085508547183291452141927257593654972394118530562362859808623434943516150421807705891653803864938654941326019180667404606749457330825775457533275431414404287685109795415359607829839309923243912514667264103699438328347054841392270375884657421984524690919634100897177012263561667665082511329970990188506650143351971661081450690656842791999828974984434746583331161383144592338633910543376684237530003794606512945809345470183388807460115500020568451758982038708130956784781516325473746534531587909608693792335099750729862854581512495572481776836609634706133785892202244881040635963227796090558786699424460822633491168029228779835403588624015871764853349708960433998447200555852292952943475220303886178617793395523921745734088074854648259273721408892725581909288109337939061596302692328910301967350150290239333033699630573145651862263619781066009838577308628299801381159227891224444503193326617458244795506342526835940065168189977671858295238055831574613298875694194298894329495551704628305487312693608099522374211186865384856360635513497654113653283603608159751647130418084434552725382882554258919703171527209015857701657881666911583062024810975244226730980172906124672108299583159716799660230749954047488102515777591069066063606663935556187252078644859890990326777887433690442534084359630292415472084224483783910877587974213832893813663615978760350879698475308582352656843283686033987439617517156842510029314770930088229432388676059930214596131426231057956412062633307215516048009832820691300974638578419698771689323296774276963913140839315890345922124888614141729320952150458754443664635744538698747186228820897709368387303263108599295347879081416396830497888606318656706199286605913401847577965700057892308396056453775292402884710571681627765772798026441313714845822735082737774800132051502158658109895473299666054906063467008178006372940594955255564796507281795131398726900240673330918058214691486685562848621109649329181271708930361477939359809107450025619440110200196100910080859518652615479998717407224652242497370327287157492229891967650450754429135605027654897624872644483261208305633811657745191310590708988396529909353420494048150224421001654602426988390187587647472719313042016143069135426921481326036700076405864783738640332190885914792847794072244117383864750725554538466223842451497979088903757067291968869177256305474287375803711393383131761649439803941186079465930950115673394686969453626064551991576834880717134407454273894174875138384171215970335516605631956237631665099949439266163310070278861201298524024438604245964455150381119290998973521619059826294162945985142022687285542368149538173391726394502748979893232155277006725314363459236610630083570656675935660255405038833853533156029780614386600565609040332863388632564396224363890865552165303482502594434962067046102940457812948814069132550682857145013651521480784111945041274765726262633485964776351811033983524352357313007437262620542663960115781037248636137461015562978642567228497276390261758522491775244975699744579232224186603329279388724089595189576529355957002033391757252927155011825829364756173863261101130054325029830030148127148307143719077559008420048359323664421378556009925986549510372215909390134760366597290302113683355492269023526560130143656582171722954612903107293352082076480098105974219106102527554574126777526149488533534191842131222411276247477150220904559778838670603007065446402911861407523695182981992385997960029827030941213212806966375642156302903968376607148635540930460128799744973393486886921625270717213448380045561916654261262831745412168389018775813162470471508607172189164414886297536690554292489843531605893230363826665977199444006599745330310430618129574132000316730510184650985113587567589536993038477928537168361754398668282742992263924845547026192173405253943145415919796185961937418842995876135891114322330152270490406578605187356767182859758296245944579192546709723449260633313190628306032389153923452509794136510326672623605724596066189303683670217331325254816218407636542179759591552719513715736579821631365127355341707766090066298265057291666067415451862497169638214377571988171031540026384345597881498838129400656626256817064878097469990622560084547413074282928453770008540428975940132491457438719183154424896959007463048377039909630427559917575638235232483789385964902748627926596262745815421844369088579938784114537702074788952785755490794105845525156322410249522211756588699059691307673412303173097958945421417307873821570933467901774797195424165442005204612391067992340386543109327482008427806002449482624409994648857265344468257739890711123631223539372074185378935036192560697616649715595892745251169780286998179157796534171481304729864744584758685404490862225897876429066309448006831663627693153069544155933818477114231032358662305552177873082302253508536923814163161284994942814542668200989129695215545047077790511610855783144787621045916087259375507918476359163166398212363320487589235284584861292248930614903599685172233707784645145133311132628209435375166734236927861019924830021951102411761156499071856158241446284724496613237231415073728524291085667836992113945360888733380860769937710439718849783548287562161009800355050943931299335850655236196495086219019906387169724916438012001426580697573983964671520975294476871061754490615656431351895818443184759148398335832201790900033671730040525119782139223303534067446884957582026271832521085279170285358577765516934724453290252026326392172497742512934043712685606572750697921315638598278103544158934175591726175981506832279946355415058458796813480859492953373197462952804703130434903119774567962720156971709585765557755876091836678139728846861439078284815311235710654225866684917394192208241193801189469361501234998257581004969471854205225332740532272365240156590792877174389738983253976675466824093449087513339523356748946390750569130447987847485367795847430045567519928040799380933006414153284338952128290058008613737080920528804724909421270139090525059110921968343603806789082536927831089895727819339886050206475511599768398866049428109162584813355703252038258767350205062110419856708256855698081266237821169053938868505413248235479253725637430672090202447452967710499271244293239964581342341492818598795095793742856861751147325368775083225414800141952716652881144070210092648352934835409036155591706314029104993381639824667089832632371352009828426564451198757917167170523335683102181554651843015254518833416123161253538068202039873606225791584812158051802426478478288598818248347739029435920018614524355736327123853679316760550024933845425881167439648610696148059298037554748807397783335753628957063544129539717612128325627974935920768473558426418566616674760365043212840008117156813561761287303435560524148244081081156856527927463890310775577142276067254959501170850353562609364532829532487561551238323359630381918637843040996768262766734826082409887834388469035793987714366897942229684546374526332727450103385261009123221900208579934976720974893298253134289052761918310150407169057540386742612532689750274744544471913970515075676348399347406325981318252934052956100379921655639358071221796518428111841825301729508849953731492323252217268185471736433815136200421376874720173850525316782497064793564259714269169426987347159775900541513057011186111892188605760702338070969847487745515595311999007381535885357537481413269871541264318156532762790062754660731699392579965036935608449371867974924467884788285724944584628012302561281642090182301613455157610418763591612776584028851831146919349129409506117956319635158063839044892667165321645257376843102748486911130150679553821292127848745920732058464312459768754566914767717992872229938537065202286122288291158759982049819114766466996279675953315113170834954458410522845901904366807970535044537247129523022289209259659221835539333392519919450632717442776746357305725191314351704484340792356846127451913089719278091712367066942827827871038001067677182236182264692186900525497582239464516176375699270459520729555210994977814287631793943532404223494461488931015595325826402079076896138330236693976143926108823105097004583767608986959337990183149860908992699114662240294088994270426548579730509728708923796277045264379205287772491480988247511020149012792285624456264795105302870187934635117011758553275918203236787379027657984881872223979600006846856726191849778848738895539803777338969188737238479317866286706705052033977264997552947332756153009999981411559818204873121359184096314877657668304641265436683920110532010967556963956929845950039026199915885854291281030830397899146124397529836330623076200102677748612944699332158782353103763545709191344593336960531377907202061720954856092826727486615542788701274542673814760038497670747629342584253626194144609438284304599885513427552701614094492778556658540520117089990007112472513274617363958635879998273298262612335230056642190412886537668784491251343565716157497911055859367498370822272741111696386470314800118689801162507931415492681836857664730476559602793793024665936196388934691237576887072439789515684087127761258665543746354838111298258898435735708392210144097724111981021220949089853415345331870751032415445261874186991317512737951870663293458951800706336370988837938915176161513585835963753746659287577383903201562098523745683582114845110293167854420403334707594131847139442901088047378590072627532767850183174727551697137339215291236260009548369917789768117012939421940640151713143418675578313322192225781288253761996410971354264044097291497580438386905977418913355811933725503896757408985771765335270481467407418465279120126026548151287375817896553056604939404104916122889314224210457292309282255907538198791931984793065262016675859329190389044494922638640930285815065007498272633670828945586462132051320607193948607509977041873046488167231799831126772391660550310574934155813083231962213527199346222954134410490626645165138891941749742094493081118739391500461678871792814281133650288893037983932362437185153188411335292784508804706533371829315232746416601666321274222709516573974333774790692531260550698348894454496451812662113124382066901765183634387920252758388316437613309457224692341825196396828424122718083236794157960572952851714785734007477985733562388993011973761393232365348150863367295445715331940695175859167787076327015014500163646331343725895070226582912980751840802125432983382546738563027129638960332087696984077768579958068813946835264480898081777171262893519335643811266056475577938999679231811205817955277291207176686287985930586820442958721873122170734516545609243591299713496239073013380833022068835946762871204324129353746618585331872335897588212063425972033682678771508877473966728050179903166472859496216375722968335947989521346395998571866588721336427427398496991072084380900086557041321799143165544059070959633838257240627320479296346755374758990305143021305336225720131935969249773826476729886551175297019085868182722166085301003402913067417917495481113193085370499097685393951074782168743357785297896225840873012769609698670746731104964641865115688920348069658969842955908462374306873973572221140470667634314837670232506068570979768707916225954498770343052717957735482632423456057061973885515545639935610544843274400349784598452550141014381356412693975011790080075969969992710237270068849199457542088232610697412505644476590894398349608695066997088317880408171277057988125567737461319846467779040820551070658854959557378385439421473474703289073601372467962849578318615505857437873394482948210453068869591898768754590528868491412101699962108414483556477982566897704085529900597757547083829123462379127674617531471184666555976642339489346485823336372447717806852186116768241257335266064255241586074438910972425478517599114645117146696740045062527476802056116185044198660077835340951564000513977435774665750049686482294920603152127179620877796707046981017546669777025854785521000613554637501744064649399911105910139571940364712308167038616702342547006977154002137089938228749151148410787419579777004625131661179939142625923839151703844977872318322568608960869487736251197215297318197596781903728453140191009665848167914911374105112953758978697309992156300876646089394643334941121583708915676950321239803017332955471180422626670212423499235343086666731013684886508488094828179162187076998471131143751441758917825822190376565555774992680977363800538123952485461723525868875706031433944244679348944761636483461670637848218973421626504345344081064507948323134847273795800161734380098849993614504325768834990308231165619356797334525550166449897301626416169614758241086193421696922965987569199564913257078706422577347613299389827237095213285615854024312868143257584043213737719181045959029090825220317162742622195731797114092076956295072690030461685327526914175088350191814581397585409184352367115755904810515066336755026940109662374241020401562546036158837504850803034675178873759283500349691836638792997001448990640532148496563199374561708321003338830037357713963189722610607679553294322656275560139622846978525915646953382003639884908878487222261129568491521919424555545365739992623576360460215867484484169512063026506502121001747202126650429529949218557471864374958526155584640698310784008701910159715389354707323030825045370051778292172936729913058182856453095933504958799576141180693907556241476269777855773450970306944920854947038093533408176273557927009425641851185900834521959977906733369020370135497407697908662036484659251161155915145602990956277487374521624806203277776287551813376991152816611848670550739175594394488944108761638603040330065419521425778895368651688101507899241507508763785706008687474168654805839285182679739872910578966446913884753219244751543695895352481869346288786993470601438054935376514243083646879000078140662475494040654836693804436027668802345384128846561608464072636476575050126182111064484448206946144810633272939715333828414164342596533933451155173800172968475509496010222848999474900118081162168132236278767518209762559583782899770359214869008798649014665820210466570292301275162365948300069435029740078294953344748298636056753520747557927340602237795852603341816520520079322169673976866154765201006577475437080825642430376217970905557169938242306817461745130471094834956038017633830151188569235223916407765866743047649591800588732750330507679528345325247745024284833765702518865371800488712337934952355494750825644855543454253707314127288644817462913198410987106437498333276307289621142526200003971081092331078666443822756421197468692533591579776755658772501168239960847885530154498963770172582021628937793590496023645339042831098221675965438380881391866667510159808366565866092791731198682291624706252332515894688706814158117205267414856235601335391296648757427303287581609651642726936368562433774125405457606003813407442451624631704905736525590364432693957392833719475643484614691451494100713274382714294540912375682049773267726143528941528685917899992068918774138966993651003209524991382587794894749630953171230237384583319451772580787157551622851118833199222872320971909399025089866029318973795308840770983041447184891302022518998264195398379667619224365168441156823948380915256927598958664729454468201678228828809354465000924652428832660342842502918782561221494468350990938587506355885709565088062256272929735775352488656989434022191673971312526866579080054447322870812347229260580086914935822033050809659065793763736720993146978020774281761331531274214914521564449128128207261862913603430737257998642634304842426779953693959797870983574108148265129083309903979647712499232456918033527266301301463726933967496823751341311864745285001686968953682936711730499295748694679731085719017884697175730062704428909736159983871925794652568601956445325543101432887720386942141467402183897498715267190276281588086774227417099603627634311300740498093286557445804604859239534816068225710973461767070139384011213166551653932035170385087248069726857924614018070274539363925326007439993827060506365667531953276275492012796439903206280785828000506332827722240060499418711794788089420449489557129141008029349354508027357189923836256106331845059585871077922825867294647050353313024412949681947948301080573456591361554576790587670492459497197861220913699510949240256001486760577538610367123398421566795675539684134156194063105736561742632475876148208888140357694342495968999171246940200192144851451132591662504940378581662598233239008341677097425968939492861874285171758758425382750894835827325850884958991363703870359082964937901590420308525132195237427197725195403808152108075611090822856759096738348719222618649423291989654281716868417915255673775006247540397257194748707173405931582600147444124491128483895362215279501687015255180250369435993502480821019708645887232851858603147572416913924761782279592546286599671043137809650289500924652215033951986217862774021627200148011268920281586846449274649488444051042390716273723570811533778415933786907302163958691201339983830845693957013981497990932767804346156982962343204417898757532125329297301479280626780714210590689253413606826262513405454056062129880069344744140285149474441177265742960120747925644865537133170904517896528169032769183589104841901880759385747913115527741135660802978419985897207793219353516212426101907006238530963358982287061650141487045080721551613338078740615366921994206149694843000372155197786475883695612008106319911236841805284627170898339236317403225444750325847976673025648412343596402271237257631428341586541919200187553989514419569989418594009964239572188048903788216977725272532452692298586913223151724774745102674596697108209137810949459871573439966932141262752912609540042999896191931647272688930588984719680308082968013339728846725839949162691499313603767133556409869683103238177125412816494180260275696513663733173067966038851700025624455568240606040496219911750097833044443781527883946130962985928901828835362630665262905480440488905384878416460437329883924156187637475194903492927508087304108434149786785535165747457847068432146336084376774773875511097316487193248983747396234637840828201485159441550660244669650477347616984199413878179848742226517679750480378211513880045139090818543042788826896709786812861948963761099794570700778990666413686822005689111822673687973338102219970373180292896694542628671538023477045453524266767535206772053332247087740661911655345732635828864541602281937910116448986078797192489454709706551750794462283313213363889938315532555391405064141413017583854943109879277833952942663247390986004765182405368379252866924446407065021200368013363711561809694223048352645199653703354279747348360740913658885588145413902209623359766956764827349163746676196290232079517753124481441210814673756894488189555285490846421597394780976937025419019702845511408288993891716958681161611635051565374978155950480227301203352962068970241301476073084781588212867330575415660470912539473677927123513475552184869313716488572199790241996654983993259226195403728886214989423855450057433086150249239271257662861986010983382901468461483283150914835243335395542169395610557192102791565613976365275413368673084137445428871908287014768451519545555686432254499134467132408596696924249110439239957376220205115643269080700004503271164332241354462245192376695404806017200475478908158944935542583711482265092304479291162291578659833707562243902806853413313840341633998745107771985815675545067209283544635364755045701242946920504269753063098307036060998177505006719317293219232107318335979235337867965945982227585699417913946096504383961760032117059363006901208084673130015612152613497329583546376148602020178478501261839128445666922636350253296490116417711011864790750640399299638981526332365018504906955338222831639376055605737790718534179922590826498571314391093977470691477696504699804745388867974180872680994365462017122218707653992878404859295788282018679996820498372790369533732004283197668426883104765014799753316527037392289465558055614840296383483899653837140458029076681532218363512922233044603711446161855310446163661033970181689436517327740317015025264604227540580845344113916842271827522930880161519543119018860234504497673160789872950271656294621608004438253010352586835942724189042508721218624968299219348298906547401248701402905699166294041481527067931705918876011254424326919146423306151915255221528736570372455840678567413108770049820313891844838450015626013327291079247185920728831616207811867354191347949815180990290195037129919474468591380150854244931416275416207800207287484897984204787965091886178760937312584004482583013243776983287584537223502474967699266832574121678197150504964862431698562836088590129547331544917269549926883880763993679331891831961287796852023510831043766991045952120435704176296373184302196510928992736301336619767352267624296884140244122367081156644375455135184462346315596890394123665797919212686492478783149257475130538784331955187125946824118499635432241088319513679519632028543216380114834436438452635595724133710304137846838105656130569134742042192590872048238790531179685974313400825859878182826686939907005204579872918868068714421733935716263808549280706781408433059457627094023898918241688786054632660223701126345083790372339721785516366820760196847576663495677345397316905295814905200816931627012731392854992962004983328700863249806802612641619707642934738486351775031361542200178039269067210813249897571504270648163606249338918760243706592546598184671122207127722895349884133672920496197424868047805437515335290118021041081902040625704763306049505391230546357811783453238715522135883042467524618057730540732369605520652772471047504856647697518270704960965460540584142770857459415018893183603913406752418896865176703983776708058158583977083649499289918598592086824537475163707448261295503820272782928154497175952245354240794728404494291982348987625998089973578513953903968496432263250182151770395658059881237835227502094108724215664286233004323440429442701943021123750528363796960737247325033131213850147922879692419845797180031821050233401385322527060951689191879207061362764798643053931083585032558275142150205068879553912544212055732941867317041065878045184176295731305067224507520101568225698290680185876442316045860896878561650959337412686551819768702521040735071313801976326044175141254191255597161034995663098688716847756048493781527376521910912641235399645205529065530412045275887465406778454008627119987392908411179087970324050654526969630350485252200552960355115040463964401501940029846923582409607460835022395214506277546288926527983181015198723423867941757389526952129229557697333494888224050552165883268939076584018736294356887826550725016688162531869238270591500308306730438284916086956138588226050703833100774813829750590162305440569732427364669845777069715206552044858851506526646174622305470218727661858929776786706051565893144396150063218624782889466278964185046519026763723121595145517787247572499764642318862767074736269229349179606526086385341682561299290329905960268764321927598356088941280329200692151324978915217151678002415074845308235759744428636306124149789652921904707506868521480512342176521198170606760825235951228127272642976369681591853888353504960682309783664934353137815333397482075218280512333514593823687185551848594206496578542381469745406435655939132546126414153629539026901165349078776011141648490918489123288851264906734100985397259342954593816921604487512068943613085644392960081073611929867322924782696100992412858586416110797637540254097829711817011160410549111898988237721324296365964382943911470135959488282583473461915789128786438740565353900292453409882647244659592145051417531683432143485770976955479187628196769169128781887700759116534621153036047111399199528692172883113337192572852487596097672898593259150679843647281330264799592297048352537964898320908050869982249815449102819553384253779027156386701926689851377918995747377590472385166782203969686999788651280738445105471167158099562705872439309364872669712393780901714903505269634044085964279745764406625135088579711610480824668333244465285298258034385303676407063669407666213247922039178632806805260399137713157686532945733965238459851782521971666296056998802896278584381715802522964364311792947138737193846657236319743540412940176404436305098881757600546110077770491537976107854870622392430233654792891631814624309075277063278173815747350663380789464753014768593954563393203414692942775534741260978888039826974931391006220804126057123797412410858746680857234089546775979013560671444638327950136058660971220477460643675464148503237327215937888232070799860136490341055612245391586849888067997608916826100914997820041875313401683654886071949757685012125665973887033285109355036863542534664258608795737159991395714237159802614215004551626879374913162376025899471395382288637925150880373419468162092398346775418418160255641540157623709258388343738218913815553804721119782880888120520698007571719136934219888748675641613823098291874259315935031093958965971313069781725011225237677166917809310189888535266051273447468604057560385970607972687681700177816454447443857729788962959252564525722195425724950996940582075149793962753171917634391346108321940756240646756057727121859813613137725503545972166034849631390347847874169986165257543466153538560925710389493258209641141902367122325846928254908054446605994657209062133894203450626246172267317505357409523816804951998434688159946313821832784926969590916641647984910098173965899710541457530869497892739805389652405914361816495209905793348252839561729974450076889848293680296902718246745197511547327287386879941354844422290250427996019014757305073435218547643435681809720728604754002919730737685534871358675662223407338088149024020237226651586495084761156270843655106643596266182841173538343997639696048846603368938691195119076082435412386336430469963923044711203294670941682040387855719505316473750206447969375245833321721879396406138020926520072649139924660756584250783232784993253762067336776832759967808657632912463564986894084316495224965901802928666983867647900616972613596277043544318648228673109811588954080740690764718705829450211246625927055568419544953767270103081628387791014338769229086190934836726284127324033984237229353334065388800281005009142132381662035175814559461021393099315459133040222510452904323184834595256717119096652213601520851597778313944952361212227783103988974938691045445816829324198124731971260062598013729196551185318859689083030521372261628295856362784775329558537396434318128270837964996450786678274865927593884343733343763280535676694559257881118232069845907668985915300503225416365266500232386716465761501441226128967495273319952033679268878485392503335813596371631691779651964629632689972606392549824490485507773570429309150471203426562111130561980046230677719598764532433525888328345460455178756596146215407982237388450601855592022484242468039267428987551049348784072466745259312634342717129269816063883101796076081694928828053739769095842716516143004105258712770185369551363232000237850315355661744068130317978543057827204581707609858701967595080355126612120475619484617109100530603248806791315164608585799729652880174363163465901954167728718971695537108729846096564510008323434776095427621463862661620145285366146912817202750774469571191570306533551856258326858707442375350055579761894450014632696113516223851093934776822261728018583994651219585296508593948138144826780377217574486280050565424206779285869892964352587988509871989587481528834457904780508547975600703308592999153775618409140872209544235227379593351802552668979972288350839008297968943299081708751763489130084726436529016573493511041961341193722662241492558075686982343908675019966229273730869942064154725939630383351220582599698843316204428782639314990075398339810830493440022591368423592177135309049696497123994718125305739618252729878718875326761852479668104954487173969237184114675761575810193465090608434314959080979460440629218648362378294339921842395959366243934876185662215086744914268389546690462045472160724411336483935439271058250831995917654971823052270421214768745194289483622641103285017639439385938751276168620616932701315237087021162824315094698813344925764968232778591531247533009649467312621464080072865120776633030085910286463939652422551058505381013465315857417486818641554637293331768884441762851825586804281548540212030496296684991978003526667804967276818744395100754561271743261222259868063225684212369484211214906584368208418564742876201928448719367140993520645090812398274415441014766035192441830738659409567936689012270945188205402601588705183039167424897211535323858523629196418615553174529048522586318103492094862635233849037092976408841555741263748348772793498386109201859756566078724846993219706456827418637734496197437756874774019848801357713621888701552856723268213305658407643361913743998013909225530173550007921629749827572277412388797736795846659063830303610599270564583005442651354382238666696189116483850364114012770925240538183238818217369751238577004305308679869194640589921661968525085619021214035665234015764264496798482763326950323092914536055095127827041570236550757779327556759487764394218090124495885810053762565433831437203844424465972156770325920518973299985978875563394988876582452193506302125696123122403839342740662614454898084497142410895549124345362413631709591139273667226170382786200129857997544292831336818354766873055387408949877080765120265999770932141628047916099332087236031522156170034551048101067081054150359391425821312379297691074717054643068133312375659135688538333470974872524563361473134782446069172341278680687763261847789505535795235944160546354875524310365079576427827019326396448486232274472083338850727390958726051323041710240159885332579085173309482364355435357259109177319704412134039112465208685781832500621988683245614343888762266455068630052897375326292316630541174072338126418830905179173705256132934873462280713588159571306527878849505047113220273689178543469245452002045956180523958154983615501867003899242442886750874812363164966151336316972192658042081288177087621615214085708930162622847796697162748977085392436929398864493625032469386448455342641780139677843571851964326671201301547703656547548266208467699377255092697212182337830285283066644787183907477982780817011366200234063804304316402507324899890091392042957908711743274594030797716533107858126468614085717911018991301772898348238033736905106561737562661269122313120009407986302515479752615627776357305987151839434217313843393794339053269596255021330024897758669836561385029966309337964746969054183376205892453205952139163332643654118440868211978493643138226520630672827568966053162721888136513715203462193395463635728275911155176377420930456808528922764424712742557047021715219970500850622047994014628688237076676764389903191155735789882974171249174826116124882396849705711921648268682187067028084535388993682080275102082336303290491086503057253103588926242081002576511225564362664161868283269043205339187794084392812850407416197666780475563483311877034323832902081674318748472618170560592902596272465287064082017500174948570422336797901627106836714047976651232604137575437060853740935325682946898019675604323175154216554371000454247958472105455267666629903303448473918713181663993832285585733600830801541132225028679817016652074342249685809651663093592387801319521025560983545395670069138844477575680346744124715679589444139975251567371013212911719547660067034987369528691664221296504673140796126221794427961032435810570046920423625355244472868209966915478079951942110986610138462420200455003087754817354007160707672104196786721508457892632494385150247715941554113558040024003346939583219980757276327057633730262103618073187231388795373869415333931344975252186058410850264491587058462664087043768371348083168131801792224839208029497336775236617042557327064804538814870489730858608802500568908345009435353088907030161760632073613361808004952897973318338751366827029660194128620221352266119550620092558970183470316029957195829957400778992544515881860272880966793643735768407368939857437579401452358626725876230014263625688210111873448127914138634887315621446817496541418889312537757159792596010464365806398272973888247842548141637082523130974498396082528587368953089186538214266415209999538190543954708673358910577495262382856007651745332266414208243301836304713581564033898321132956480880174807249664199849981320417793361546558893042797599537920416943234211270499548718439041842844589283192243806575806840092337720723670707434794535022903210971518470540987483149779719193659592361979346092171085066984308438142107483669138273513130018884323992154829425846790593515110426869521488110869686172591861376752344956985708305304096976491354850768418126516523392502630345245697048699740192135016334082344231587210049094100356677793083761032373558068646641847932031172318124405413905156299652297332642064751774552289749268454419189034661217212441523985419666469892139813877685443525568283488832036818141945067597876942962506129113125667380701045532915439661870308574691001623680906904591520356890403604285811566187988645344088645762824101317212997150328251365465332641225042190900354566753858905228155295025077586310194023186561930262936802296907433926553472654658213345608104307509739884828382168988543321745015400504092592587252279063458343266209305044852726462540613033442756306087813343435569366808644161265464903763486107603831842183649899211041088643890999263986149173567476967941847773177474421040906863808398455392785614438705473080699107345821706049525264810187361894468227701930390231809936429646796222932261799345656957127495470132268566485030694456193270789063074097388043097997813605138574552912431302629534808453856005063111667813627047019092173833399162007854863377476421187659512379492288027581997231990000357742668812062033539077516220393055319367866361932983305979092330704216136838255720754883746658579543430662798928668038488785183590197087041185233978137019659481779852400645016395912898559682167577817149471771301008208883468596005900916122821012015329691503806544434354142290674358664909259353323403025707029369157594044109816176151327765905154383908894407375947267327919371749832618839055622787280801155432311054688874442681052713597940236522640697168815013799303942587701154085740023730360358297815393023150673880292901404127908599634464769144121759421204626557349121761776221838258368192072705988895813367272843043867278341221065258527994471333329162187524428973711757842160732418342257419301216392264290690980967764875755016163779943034831740129983303282366469536984353021052680197338454365292245323583425549425872741818460787298782192593597227736035517978443395145939523596819438054688659967833148769610245762528971539792387737103260394972997554592074487645618174928459696104001538148669947980918599549657335168590596574878177710215682131644448060564629615627866493640651937167552842970158397837776673923295601067557868028460738913147710830549936334603967503442393938652289362065049853980222200813174904554997495305792741170056848858625735338653367144932933878655623569493200543716201065745383095880990120153539244255103928276591921147874007239716296583856244327977003733797565822981541714035437394242938803448672982177793821488816776604802348791334794866101745578553569215744139170973688321595823116736655488224893249886276073450508106509382586933072976997815822224873759784523338058954786628395361150055801445714230691599948888401547353496155315329160679349955806834960861498022753580729508841358808978032272091571555874853842674960470056392069403497271357210715734237200771962551038404947870890686417358681572756373324303494544346439190698764977503537236263951244714251986015989696948485956328502351170623975621245846825394143438010838325497258775339531801202388876294392966089907448222042972387991850227063506890433103453955985275239775158692912931051786165098292012383995184434948255797687213118390445425553025525188925067212185284876297139837722812381456261233432719114103807350849152921798674855032228403163082285923305746051804535750638709986641780867293848488931294790985516837136664342712831810431939485670033028103750947894035864116697473111815469271190307342066808587629587007574493562012795789404627457392271271862077255964913491539926475655155909161033107288855273511486390072432782794668808422112041610215744182324822626116263973789552931470067194402241197883851891685910084287907708479198549723088568189394810207565689525367956900387824902792276066450930215516717547125252363617800259234092599686055637994465415367094874293744051692626874293330802052869164431705834886786138408236398897604360809140387109823419632993250304504850854549150443971966106446821833166564878827929067545123880442700641494223581359047683680278504433720845409894445392702582755082010664359297413968159705815958224539869787948216978484653157395028849890499691263411490997009951790387932441115162938629892461539407502234040343376709857374553501230186628878771180170666300972897342141615903265456169899249722340432563515767042258241471602607085038176035021891053364379992553382219867500396050008112271810559062120296121416570885638519471138656211419162506428093048943542600535805135416500895099636056473599580265239850452939923586894690732314987165140470503909001526324134677468546279429581428414535514281049429438236907414031683764916873805210251134228664350596015790404684105430434259242605915640450156352791636083494241581150133483382202538733145426596688143513709704235801494700290933986952536043112948453490249441053391528913248212732822116391170008320844480971678030531112194650718522950126479476513161420473725089202971462581995869978813106073604538509838569159542136061680440330272365370831958990061056492103145097561853067688358454280737503437150268764026773366612218483931321459616237777551968267997183264178826497850393928690944649057510210560411736500300889450744263565484691037830644922208293161710571381623672486201506732704342554051111119570291003146494438715834520642151553902951619822890917821048108559944192482300628429182175399107822922766386874240875339578657925041969318542323711326624904051502768062343231523617530641296651427064104840583235515271612536260742108959491212566011387144374452434781280628651652836291344835576267629391526651285835367137575295188730727565176991349064297987156028293365559951252218946293966785546305299801986408664259631260639371868057643407396999486984761143003379014474745913606538170078180975866268531873054365339431346744140313468520044350147937299209395654651676828567006352799646975919518888764700125535339369544059338164683136256102638513859476158767427866687299081661832676518767574504215964923501034563567932412840722979466095259391079334417804743438545331844693247901635541062029490119247826515767478967952358016620239733130676154618729118236104463369856961604731759096005038074800868339017195010864565617528901213846829045701981218848719330878062512017030379280333521413985366931994804282886649485133063669492028101817414555820593914820954223313747608611802818076710415056238300792117862640357142128873867068805339568614594139033836598647657853888530169784803447499331510555094293290460123471304716466776780585245047321235965705369788065448301173328840858088890006423518051062678018446911134415093091264629482263200229533204218759539854473690589929633410423761913426663742362180581683401446329161493178502181061185066749363114922469121848048722239616689691744527788533978345604805777729701406922383129838936311523869513000765482539850636501397101901200457703521052264117755987598616242206561405272365563489928979137970382836689721009356989031465888036361538079868298596997946822064382580223807136771762959049160378393535018092492469625884178084376598319459518732418147430877092856689873924909027728852019033292134889416263775862980542041335334801049249444858071696267189161439985699631483330129072172695421735167163644076816180648391835712826833863992695225087000575641191310593421195671840356717136531226653901077101841675158907926053076618355830366606952233373852383104732062720718833445811983826890147898003424268434104251066236565381038618972293537189463219203819448710879193394284556414748197569393864476350441954697325623275109344166569809836661095570820765329683853422397365812374656652402673125195898460873333747678265924579912608291411505807589291378838429909273221318230327425080998829381635359081519420657216596452264250876804555393413963489801216678314406854283503484444446380757486170886086546540543977186405742445138674349965373972187787186534427795471763216551031886313476792732427012387659003988496216760814252714342683668832039760664124459878523067432908546736266286259887961353872015198696545838048238706875899309584893733389163663529356333971469514253871100883434364321016652431139177173645521054439650623188284757521248052523046689046609553963941112403732501913120425705272858272342502362791050304481602429361040893439799612871454657621676770713146289535024382481759247154412509149259161040674905463094910229629726845201634103375651374578284829533411330831347405665840779255200305938852024462875766244810039842468879833808335334476762594333769553731521728737062109076322305555322165574224506426549200340493143331295445400529971523344745658268302904245142806667344444058880563158844329876335847882933172625754180063454703438458117985200758023813267622134035406757014373075801937155612672208237535687767425308494760579888509638054020038169071456679525929936423118694632599221924046717684773507007931501684043462818770679960892903044069708100586732843128422120852506763443027468276064077087507722857792544233166128784032615103873012257330411806488983354513663531868534488585306639344206645918917956072664491394443234356888487896357389137168581641166267440632363439581741463077164228869620219908043499853183362304540150914082344656757879471115581730688300002359699246494446387250287354220636602476701781446541261814855403233699941291746906851772767458498385813706809588353326442880451456928251102762399991782167175078839425922972426670297306484363712788599064658052033894250139810103208516162247371881503323904112322414334029230751860773267455144120813199838608236041430456375363393872523753620754706326083849782875886370805262566044711478497279002890472493209178255258477012166578701334990668684126736691939405824131668083314386098822245341873647439722475408222822396189601988716227419844844976828999453383650354679383523606245407350780343251960413754757341093336611285903222775196842106111597276314629921856888031250777704434905417755457221198022872667512804026641319668418829874159666094565519520000010874481311885183694213307523785580551317486350631401546514133264888712006599580605958979094889121005482618757824786862677646846033663313274459995402197597943389271568847199641154080619361306308605338335776901742907126604318722632920467520339869399688336358834851176121540739780195360961516127255076440462731376326265149832242217877020296858879362627404482863183907309468971623557497515056331369671016160731803478377964006097650357702968604879869174824466893598244061588273650584044765952583675348078025772430674180007006673382578741846535471014688208881778393022450703221438271139714461424772118735702335352940447756022468060908869213785410946091358834109740452651573856445664509688746828163983088681036237663661202404478442640626874478371218113373056921930408787301982581607015755281557185541092586419824957424393555359132652048308479558496068470926313857673790280769260144209088844922964043642325158801672406816475190897233811514677230915294674267289936630156927418760631519568916327518195007845805702125044307820469995690953996853453336076368024845614427947307807325302295603596146416567710313284537080685141052972705858683464993468932287306393450234530044026140047478871444386379079529061280159863155186479695931554282972461000774860306259696600640377908619035145507993712074424902904619827526188130375314474225644444911477230496753302090131021778407370637409831231425397249471353962778395493932923161387143192254466727055207215778112623745177825506564583837738703630037653808875252329654380478553544825187280231656445758879766405617120401003887210523952626772390893117070512885836831883858847311121097793417173334581880597947650656421655537427667974805484516524341364746614611491237519577986437406230791856455752634449004714343093228716063065774199000144196823510045908015070902915827005407455465955732192391415211812909625364525581976918080578864049832428736032398067007586174075463414974282827574451521329289405270730154956071515795443927450643654202981698305313355536204997537478294155018343780287037641610506063614922200307715342689166472384203775189457559276758958341976113219962926350358968366149419741482836976458277435222730514292134409040995368976146636587497118962686255444988844589645763544507007635905702273793337948500099674972358755739468830908650184139977759141002318354082820872470779391437365213985326463725979395869080578005056450194024216521861624755852609751429991191591812942276372988674797026174064735897058396883678283618125343653906926942862282330477474931987217702572193808584828016668778717489978480261967556827665565079706718968062431877053405895955359664082332008960183387103378591173997915581606538464808966773790466196737504707950346639230248080381720183592653173840051425635962926926569083829390527365792704478129858305714616792229124421668421301391912940505431436453952654449108804337136935765088155346674157951589894185719344655133743670027091894289918710179862722646227507040910878686164607808212783546554304109025531802085081421093271596075539042830451958905320826903191925375072938937861427559440145639552971256268590234181853804659542793320180012209900029864488312489747342089988557620406533977716373215802854273857627694622941972400735101047746877069560343141719252501147894235398493961419126154635986526505885639972091780529285470013255261385107327348654757936436435842784446207178438924915413143733478898395393663405542022401136727696613247306537699216039181085221429658578047686559031155065933193015654237437034501138673166732823590720346280550778724931125345370253710467015249528054524117513675274977838697738644795650472682298774218996895789433760304683750689287580652047560969905589330888741859435060945057849781054682736290789992327646051007222527423885475038959575096290069133425018592114334687785389111240877685962126310414781449664825331862680068809434106126855673764583748577516801240546898887556540919523332853515159529014464255531215122847586823921165297042967379807787512895450155098911839604926770133690453493388439156167907829291058535897283771546661669917047785009104058597879347839692203493864468032746959434344568357549920799546045893214439808465348387153464653572617265085582207930966469552860608745636561389498786542543029601571847323731534733902693429624587866298759638501750650141014694101694609254465832139489810211772117838771260807727513891146326289134363601953125101767764004891691056717541485599709700886358353767793569981440696260900370562445384561954868999544070630434680460830519690179042618122707975190319111761003082783562311723408869519221841160911227933078207320766316209971406678814891884670946841247687239160683282184201081356753909882564968734089783809743610964517186465781646514069669943764023897526288364000912303558343306880058971899773734580157554403991316344030951547067284682030914976112586923763547321027742838239106594321545290982436169833529707125711381676301745703185480013008472628681909643479493191628044042329485720440605324192769194126677256785374450522720710905090042800463883869202253709879289696941414257015281332251668166854431189819475561600194456818855133363114640960100379889447862076179419451434533065867040921975268867382896537407696260133957209072584209041273594757743876500748734736234522949789151176632095460685105043861905520989229286787799835465511023207845326447153969221254317226105057529102088111756396284727439501800529837260174716427510632627952499596169309184474311421127251655432226007988276672797627283346252114264589538044189117996086935053279742573704934350498449767208693288580974768420055780246924269871030576755960473413132971389275421892093701245837578420589889068365674818034953236131219826409801714783074115135039629919826771200208688765006058439618887034966911839161388511854187655863668000518878545521771862599431389222764906149614201664448334010530978034881576003687052644777201058392513965828707041536758703788988215979128341943227235311373168266812669201068228049581941572189838432984209349242544359927567168087783274295793541267976562481902781750938311041373798854553475336869444707639583201122893697690990708758684480485095144867278553257931287086465009387754939725379511897125866368947804656402706763038606583518312743231729261134981135896033266360702552533706434559984700563697384435647291785484458296640574169435741455766231841238440072317247788718408219098225503782927601794432351138587853630051321775887573398856779269455810631291209005427388850943012295950835224047656563328791575473845796937542467066623474904482214696178678661549122386390733388100381983826904573504303863164649377424181823364337684741791728607310983928853513746487445542870448337989117943188129204021898629251111914526162835625117363738173632254636894686004094435556363892719536785506225202711477747888124801345753463698421874139651322668869596586691442370196293953639223474227451428231848225211990356399728385705338803542130658008522404365392616547899350916381395123136491249792473813470048926621715212415510113454821037469238242688833168822207123037497880322008296084607759884801996275070586583163221654144514222032319120408375797746021627667656115098319713333256509502857283860574134368422143344421623009687975553250238981978000298453403932228600324664316430426478105339382395307039600632468481966429541342051103995960719484168345476363319036663757426845991111013412405033450073219220137390770308173902042628977842932788591788622353701065169119726527641551012816454653956286517310270408396919752986378876086664326959452115652681164867495718175532632123866048550310527278430426593832698635698862588945487287524423479403883953814502666611340114699645376576249566904781163371240247916433157273067058187418367249213975068778064575363774979983510819970038872035113193481820189932058433225508826273233333524075699494617762949595442241733327239273741068943863468726337335379141735678222219024252830616726082809939931797348850599848618575649371853158683802985602425476945736614413960249244612450465152331301588134651200360476263667667554843700145015372717523585331149506861534023852039034272499755864535923069581702985281022354205061938339258461893481564799016794163792945252669878598450084802417949526233405589315651711806424752811528871568725758959820733048010908895212588293784961904590024759060614805588575224179377784956329037338984102373408154694342804031523005209285773092445367159772063454618249880986908465244741555804380803842199996691414150041717244736016092685581601464797707000501791594273453867307626432320145891924887727958318505354809952431749143216257600153021760484481725044736571264439695923076083632904356883201878670895223792863830050925850819915700106141881559706070298861758973083340069981736435433596679740910062573392142310533648608826315807376059140831211945383520403098585052467871531116115553743245624585757387507988451256440763020520445290693590933810228096674309389174321448560234642867534103823484953273840345113793304619614582629849844030982138090394107167382672606903847019880315869832530318090884590305517256527420508403692009297372342429922644904302428283599139796486309523653710982085725956602436743771394349606131015513917055137383832578063379054193958866821429098943820183416682295720885669805423817123767427275204411275931661193501996781818187451786225205787150039346350794517191184825398533295984897519699933924386052402260853101975135746359101996047193201129451188710193308375951620418118330434453985913793132030206768443760456757826096601192810746381394009129004766575118871151912495880319007438548424787607543069631699871949421317071359975555010103697086932206331771602787916097245200566075205325941274712167114386285876774746248481269999663079440051661694308596444557193244360447074878057382804904406180081941315334596218833904760770393546133712543392773921612831896294268065063464628882935214937948427264390769953354669603312459136023586891660815342953948117431237600102255373779238298064766430129999298294231630052235093762810518078278870359090850918733742502880894346136700397919953083445220916678337451598794575818930113997270049012948587107502494389866155560202228749866340432621362687461409051123753067390438597323398976751413677381159819918072609462177478478464752932622133132095171537832111311003164061622834300792885546958454246167473644560397091459790605712548126031294738063279578601167664764042138298837818259503542461194515864428126661988795725161932718587506793795319072904707599649818518553228653234980224940884312593398125810850141974594820727359832779609831763063812693365729117776320884465982702403215808405613767202185937028865031341191993310001601267586374307527218453390633564211110177028141157417029861684786363807295611810217671240999575594295656952225786659986807081745762766248582659616681586845884261315038315753623192298841530575878924699267911260936718910471313218156635525315414394313525745583147059648572942718255188679772294981563893488680682184273171298280159954671447021537805203557645336873363455054467796124150561703915635379796552644418617214463689449924635427690337167553672388871217200917771831217633630674022123416860151465043877447534609219960556828740362616683554592120610392009648697180766145837020596579542197927960518400879908832435567739252575121007704787816907700482645380807265206963170363782210221296368314977192167391812129227763863608673245928187469226552075983042826238093573029565788791527166446383265877186954148823496793045704148557465227849349029748940965027529011495949595225991890298707135196213629438888650422412672720304847245249556703022409300157213722894981936611888894038527357276348195546034897931415580580523538997078374168237682440220415258032860287012505847197708205875882449354619658212501549587071323840038950546828881473861044309400065498432264545123477323411829756249923363601752695511390230408584258695753278941650277193601864672738594363268790190948075458839541048902954870080954332572695624511915722225084236287668103570227832648254921628588674739588680151457766046729105858878328469439274047610503391061322820843731979601062422403536947947106141067842783029896356669033240303094351576386545652229375108916065649482073683974561588835764237971630247562980295392007489168103809760560762563778753192502063487156655277722703840157594684343958585656350192293915676951017107618824043007257989002275265797001503123948910415772167879164204278092843810831323904373034428768369936051938802798582721890594413591838221242344033004849693563482921283282623700642942857608334044125740502172950567324705009666245887220354174866687173047156570687420609112662585071955908386551109747145252296256457654606944154417913433075502999940313408438822562977177969690824828063973686851563234300486370456892490095066519915906486063158261011875317457100883812491808632253448851724261388772801406065528522050903097584520078068454657489443572078534240818373140838066350970287991012482129577178049629403884999548883663967275287517966815979623431863873903135741746820164833049218947371461175990929940476639391163623560061590444542935507566788971578369768231177011048513306975295508778993971671896321932046913825821663337546134406608875220298003481598317892587432985043846171612741284613559278717209895042394604378468245051412555710090029260323096678617067017294791572330970508329750080519993627174743592878559179690428948033197689419215849276866139472852765996073136224756151691101043922564743815678433643200981740992072510609532483478846161843936102541723077099552857031834305452640826413695810646386454313012104783675695449569781926403405091287520878176646615736315216024589100269502391481109892228453230181461336444952732564251075932596359539864266161190472781142272529530181240422834529648730983132894467134077801462921515891176343475291223424811009179791995212639343969248089755083446679582677665115618942567540311516694106231788776357272627303012953865305856780677414720847553592460460722742989314138480895701100174585735360136209963245359171898891356622594420446650741710472144280356563664918505337420895149997775660504366040105047247504738683421450152123664378392617290254364516651350350379529552948414547833463173443200068911828738271943587741216112674166189081650838606774900506313550738215312084939537093355482020532849562392290053053328146648577017675236873729901661822799127729412769554242170671884496683544966758379425954479142752118692837440341739546705206951257260408604132472800705370972011386170150229520421356094400418326813026674697773350130505748396225881320074860840469157107121901679767383669611867995838073511386313862655214456739516698832797507800249215064706227223201975417218719766129453132646267121509373754383439639552521803645860398595101943460590125751667204477972926196561253773233824961792165252690441697555466099262246591137109105358378610728348052660469267340501631302004047304802404677493541527204138992584408296892516311457064422064163238519637024133405369540547872230468394893988027768935058704295251526977264457202848980599680177318519554397753575833265916188229319018706645102646533799028766571669316215394369175604898091713311678775221384027511608873262549202644637601560331540005585465353434736679550809000067872547795237212273324712888166927107830153320661902166843905806244637711699913818289637676428733148986854545568858228582198347694008256070028705676162649038046290553517342987690844453514135482708994929827106087221366332183679605323966687626321539327791410589855849177674407626981773852963373499570236682984507041891508407579404507784104817254537841772185848000030616843277204818355979980860937818155693797776226172192555118697213934250228811865352618501467953239063936602197793207522971632707756634320600506586403148569496967913635514110543403655741360663918702631580116861923304366983146627229834703273901662864656396248918916656744001613595372791331301171166141150195287374298477632457677988373287068462761339239521582353950103153970272080032129008920356450865475739972580252994431876060129153632444251473303401456212393675514847347062284530955895323958236432507182882132417418626599577669073435480738808808394083493864583800449739770309158742773633446970843195449438797039278650065132172558089887175016889249611843805080396525545232018045005678227028625884007052383200204181553942676645878448292049047855269470396809880852004090740374890531567813464117981561741029161115627534903506892246570539521401639587365382014888534515273114546798599897286808851807082276554241675759503947992448367937316072888682924645189600144909224785014478391615738691788039870718338807662104279560535684755153512916683458569451024902793272755321160554930353513097880702430943345831298774165723297887219203738139920114223530130221602456681562991541701563231040807195251275959585034186030655639352927253657633284307774697283864735165826951246465746683179455661137981711122546691596929336281633764471896875910977764755437093869911549004364824212200647209445234152146129080700750761657930312968812984036138042780820034291240589939884231990574102863295457399065019907609325948535234751309132199305651271108739841913479565985621192679440641046324952458705226262273635135127153030155245574796216795922159994868529369653671631641664678239588340155876992598764020992158010445706520526624828090472327566379911096984690309932884279316404786741328784616348799284283144424035082212706889994453935985404090492340734876818394843049658791261677765519438003239694117590102578822277880792691600666829553495409990124412557677972950292267084586127476956875812698106806290620228973218263846177350889233598421133145508284199731378091151284776583079343190494403567690826012895823882790323000538405318786991737131023050761898332891618565902771181698660257272930456362036445881199801790677216356891644337178823571285309118133236905808830656209799644668109978754052049104384732952788861028598976910267471006352953936235489168711886847770624673754240346286078622037462438434616297599522937436890167612407842584141420483903720150781807833271533330387085577665557087488009429972841355326606844629582126167134602271227984599223680275474493763830692089641077945558927691504296407485759577299369623249401223913515157079214882689286259299155248342197785079380259439366917142536857880783127502761601576248624691936466210124501938007290927339210238989801128040661451386899541067775151555766307543311774872684665215572074180830390485931289236602591417887878971995135867810567796197845539306683803569748566183459643964030518042959750393020989812655694785727553081785786959937759177043607175946089670549526944468627089088078715921656937497786295482946593978844241901327889213092065695159819138859633961013519923614612007597726047428589206893332938590258859127503240176450920230383014399762307603374799912703998587220232439116439034714944828416815905480931462984768624027470197672032117441552700792858342467098009485851834138797482380348729265979506212502247267104857700205289488862132589888887131640338934240151463383249466235145041462592057165781521299101320525861773878372749478143939335542629667928332201163383300803530678388438059164166992294614639922577751443353389188733322958676178451027436055751997990319445009129495658322885991190708910632926539245761305974774047610040928980221821853784852896862829747705939239903881838338178103616668156045159125624515326619979408278535992193933937338984753384445547541401019109018579476755588756665441430798663614137180913774723529173541516396694005935823108342616958441756419775595672796017623662265696390546063710166630152365040422071781967148547652879508600731698274481803037675737716244244915866793817657981826403255263103116365207247322837433598386058328544886591391249691912355958499097193592548653038689461456249540170998070902699761714176664371073733388851120160329271150442543146377744267406337485950382698619568209872843193458392692468602128314125998189128645909447974145194609603985698629680672023638888756852235828717984565650757514983829516305013862729569207765647258610246992484127908705342479253664398428932137364497517315556158758157683556057432902640977322081883352813579610072670567162937771500312776425880914520567370397726757303800527182123224764010465826069067539660868378291525977949044006509303498172255117075780353043460663908845668778755834969048461383081483568571021749846169768627485825966699009043377078562399438064101765014402633174491541984859470091709609726555011526145583360018155700254764128316107428186704609760402831161932385662386351817795923556689161349419717942551127215800571455072615821247875765082554530535535786897111154201536540981800781741397304944969065549540491202670556355534894289856580434158280577022325819038408236450208285411856314041132511757610716757050289110270711729021256449831476013616214391003496441079883232526760522339956817094447764005758375064066299752619671888861830482835370678796824462614877236364677145150788286063542078717462646024401376531870440353830702676564817995479417301341170109660537030918459797828100297919268911009109894954561430233795628095514113849862516872631843801211268566833312940354383510736325565442989273226208028652540083404802492696437321350507878869099121236191622901011114915434408843078763549157610428721323734007327598418790297956582169186923791138857744034521846281470787016246202339618618036375152622995177670057374536274912911719388315532925149092173998109831258793865906530356871173115371145716341492739066897509351719693530005169664273103052966533809757956159409706873265691594152227770270885848843671360072211891066217947927783606608373875539771210373317803710100752898475630324945457167433615222529406947063200783170097104599485914443393529256986881825615698821773320179847648985155963695912747437371988709211531415683467500977194841156419439416815230236899050875964245396273478887923025916785832154638694843933553312229433022523841952107780983866586788743624954887833149731876329355767779888877859723652780868484408418025984924558441212260982054868773949138059122365743074770183516327605008399873489000870092831968613899706022194151268900394844614672462782797296746684751498586737185973685207597737175989609265028537663536836244929738947251631618047748423384115215485829656565346118826789374728945083822055017766566136605586831343793496894103079677688835280138836068903360118247884707186472421855013787886894677256910652053119779077501074777222412463462416206070869609615305003324681363588041060930871012498635264592872536140888869902869562975981962837627444783888812729074293824167700507188558649781111049966170785710962329856712801320774073276374727800278744960780538797608242245499206433557743154673263769173310636524540697977097060439242852493807790038440275480606137888345717428781209555017305789238046541915635718503480463710824113737330396250004738374055584347376703442450589084626201629899405578919709606374502383102795950365383299383552726571994335304959536394810790641174432813955870208378608149569974504886170695590830920967636680959969158582949898615478206629318366780350006035732293270243681873318859476629773878720139989882762431796479355686402907246612652070891635531721705695369665778121732425216242701520235636375979873799732991414066727309726464995779154105844273020145164818960386163367128576040249911280113055998339036619504265660926995625191095905307816608547910456999750489629360513208381796655495804473184822810314334430432661899816765107488560476637142676498207765297056682048532696448471488173054366823568087435111170765225575516829706489362475165346324501517548825693510007089474873502066902266416059973928472001452865638761637679494260686417304504773377008839908355542330698774490377502777044497757038312191295327150086758479091931713017358242440852557265224739126662690266146599449990650654050969768952422643668964616209533798526891399117586934931549863508760592543562283015268734070379749102196555838716507163510839632878886269822758945201209590882516388803226936932414574848681918265650865555961964031509762530970033662135908442377585479480922146082927671026585440941014349012751713886091294286849272553534254851154263014620572226885023273993302429364334951167802726212313259517175303808948631863196078790840740915536879265704438914995951806891204688947310971738499998566539937554187123368440629254088680618854719941961553659359866352938877063502389828951340667909232680356841596114118387663323847494669826992731589746726999487494134219366973446357278099260466438910890960755464287233620015158845689619842078330705504269610372762180495677050205117038823798754334405639747753688591983033248139604028053522249073291461199378225349985566248554152689753289856725647258567174256722944875834807077320302981074921021163796707633245770994699586226696044138805258690466901103562885218585546088651609058795752348525199846729038218641814994027643683265546567524219291392008882357778816630165635888556095570178020685019811352009162878838404076749355903295022481188049468423509535114615067008858900708250653721343643630287441239811297248112029705602595328259459819779604178246805618154979714236730208749713516854538313783617898819994483696448348861410425134752442515153189479655927768023273542087656200194092703127928074029931915424437397588447657679579423502833395675192688607618202508694392296737355174317921164811521910944112330717105950050916683611141046853812674522058341728199217639810018807693352862505278062012936417391911288600020185867478937808843274355489140443821310005696374632697375139915835620878116514281915828014734274432198524507985616747924209432538941535980314903638480818426674927643746727612301644176575847030302049524797080624738230543312326884711826731669913110853146741179110393246135885269965768416665677629695104713820990382176935621999272381622299500980716462843103662682543332016107037641074775630028432131212271138018929831340608145260208677807671096515868148067241406775770046065038409851619841458676790366931395612861757722528620779707837379340523375407003738084824909281716700934552592761522590355136101587451353102857823086934129535270995479849463066179880000331593278475169886429534660954393431937208369431919825115879570157642257929948036510539591452929105384556855295229782147658200277007224237952763723637691172262311357350174755934585319198115401695245710586984872479650414104841306319282995591859387893560051823220795355045747641981937779090079412573655908669298258603138029073227021366928138601145971844714190964429976190733218288607302125300751044921920225541098869295266921279137178383018340254210788482973305000067712654725503256375855724110995118027413530505036353949303029320818644600239189941794907447358333783819652874681470080259805428145277541124039027911052281568244258948227632064680056945101196767335806966345791854385683667121477365687788618919349912239566477139338906434910509994640682499105402911491025725529657451309020616424486837440201390179544150668691164640312539086154115005485888561203818510801075977863431063269212200134339775985971646115961496904316462835380032972291333163943999309489778901558597189548809107053027880901477673816778565709178909260573413869941958182096234133578866247296714064283182187211304239024931531977960044693919834315585566544279270668254416957248260034228237096924446180943562498356381247017971271533227405255585435381845859024348910313588385452890208504344172724179110948146210698098894757226188602392284867229714511266953744698626557868134468818616747494972910105791683351800895685869278685553450633910694800860368741803657081785843639217834347253741890950333044836527545539733992802144335860852741003368253380987806155452925368599511849896728752311748902087735264424068521840494869717413905598822359771030389027751257549441884991924105695195460368101704493576579317219507492305284760667479965738153098928387952987690044143407004713431389372597487898365860013811785394244009869149201750846082555527459067329848533561419707473491589361649347364004174761734660843413961322442412287166034471331405843774963568488262479161708319475335004777704268576923425580697721409903916613016696734848063916357028992065463725609075143391961282160520749016055833006104942765813494093225328891707594734145619661984382542642865657014647981643008344704570245516473564914950492312466887144993454351199481168177855183537756465949436693985361933642973423497696465242183808866333033355428414327947212962479202342057514428185354288900289330288517429826691392699830923229001245811437179596608636189077029377436001195594794102977574459724274953611740489082004020641887029696167460011413526012412547690394435200083545791092064637132659343611704970653427823897243319522598454485215594288540213750193714937526811082035602526300394726734914014745994131496196039594307508001333873041626915943405169172587603533218314361141376429200454699204007306594164715870728881357376853126470837042753440063782020695215519427805653720003426615102952461356417377754510925488109871385199821811798801040187663012014752204520541354828956343550760374537576969550719307190455094973297431079853072678503608276605587617485893470689731350543902482300195998479178338842254693029513613884651482785289576551711385656565423029323633502877752002737176230060839286945236222826585774351918778869266351603293754011373195641615960905740653253046260257097449736494287737883359659822973551900674041247148910367256369152060209569300860928115678556163063551361162629318868278897376242857854718755438072176782344412576605351459352142277859614457147410417965933111675599885790448652856428276925885692312797905662851085171451207285355913144493537960007875360018912799316892998474782302831225139826966585752357935402702774424391515936819683198765840912725908224126038330916235458499025318031394814378459565186575284994484224712220586611708567094671276062396577174448873149958729321105484917951008415564517193809904232571929594414851451126816867590011825662592255366544795197798087652713384680537972394456156563322053649063995094409451819766476859301767842167894207965183192694577344944458795154322353452727034220871540608525455973879707803640592141726962179236052440789485169357429602158481442828878666160470991497319180797385682853552193432257001917090222125829943871856049461662875214144635544049407251582899805218058641882128242035333460184755937603321105127484567305737320087486355768686271703846465274467978511356062522796447171427919569922884222161439227888037001259940718148602232540387147974924971772741622188485200205292679529912037644103273898169313135962805976227693238668255125304331315325499311562222946116865538656074921730953337314208545016560894838540369559650112963172121862322450324453126407024462208612905098960407916331993164443036288058516164970064590370290223138419159175580282282228409419867512088328166992472684056464228475795661502082602155378678740304586024188282456801630247460708201887811885001671409361907189094457742150516372127745054314168999723749961010004121954463968862586443700153600622247741433367897169857976741446147058006304236356842001049093332425921048081240215599091889781019576592163138911277755939377059123261187935404635297217900811716212188781172932215323903870922231631840060513597871384487282126952524416935723909281096363123185195084980899697990968017156539038269376261550633749908808262005383269061166415086888448713490667226765055264717904379902614852513149199114118985904854049095993502464326407310177525831654486791088950454142382899043082748618077962516212176828398536681025618973802244330385581182773857761853048979951097360547068638295824279523074543941519712634055374891371935871455126923401938071105496747091424024807361540020003288248176188751042351748675441133739876599110143248425347499260450974831163539439086325154107355794337467302542736100238601037013867535524620830659111002063293092150856160022270353829131127016848692923535163306626608326476603461480582653412221511358713122623406727138616024871712149425398039503310041858150081845348743373121789004416440649207532624496871376419292141167630335708498806679590914859698639904665985413261542976937602500486179873193644928537608476910886803183501535593673238661536361391112927501906226064464281213528781336479912128653106957641293440364586768001118337652816402671786194129494945392214324738467493704568764440922634726095828271974929561855632273779988838617280934186613918794390690067317008077037861820471717711454149866082394094478746640548906332710220994389885412534242532373132657437752180977505470249589062923177125543555372476465021943319605644457380761454300678279101507947762650070185546136785205984355552269262082415254045580174425149914403110496914785378161903248166100063059859802540433062486956505551564992487216051148699392765733272732694175799760555919908933403169683444117826981558157489467435254023996992330571106869985113276882781737714729228062761235092165663523182793903997907060248764309730117328804323922176874208419107234292285676043480193536872734139542894657053891974512957412704027745497235510332736385524555920503927268888280389195960431961836107167991477776659174529278035265187723565013550884974002041441374524827104035691765833330376559618084613838566522446833534214769129914456859759929890214714795924826034636125717774965344221152343752147283713770223307314029433880216571160067681588451458989327792180110461574567826829397865008074512734172796909652536744376610344312512997588575571404572813893113958290277322352757506039070043184590003124890285013435744132146779944288572354906459028704088072045635076658660766050830564453251823215880965715072334946161284951104148202845915793100371827252711188990009073532144074345987587244568770305573088839883665669691349127567604476357856712933833939885687662381594509683842050257841657926813280684600789549420131732368674996638239078544791041939735579629655319630654181970058715715054888861458471224762393048465646473797355289478482513162952221200383420554511429284669681929176488627463847661373761495657889989391633303366828707075643435495656605084414605707705100565189442415852847327537800246651232221184648599922261672434286869470664873852861798276534431162915165541018639937118146656119668324109047294596029557448035971983380546357005272206601687340449372032739492361314018495442590033478978671830462188065178879993723840434599295656148011460104736413651433617491917213682244718139681692122205629714230489463405168169879138132714259618107293406932574437321498933727731299588597315828187398608899785155647040314164022275468896490233185584073705972993209794341644401383807572519972768299761784224346245422937745631860250273454074887871645473991883420455599073744711339583492003432219600214228296609919703698385202270159167288664463094213357374763785696911711645898971164553659623254513512323803280584882020111115298943799829383048694650322599774295229049775440873664563847577924567031057367973629966285126224282874480708900817016921742171190193940268970291930572034673671882690060269256106975013638089954933782189953605410481288198815186568184864373515407140295034430288950614377674949479464514528387248110390787856639758335168902380758931928535480231886206337257455338340677700981942361182030762678030777379531715544254947823894305384737717248982004017811902461654461671220381008351452391634786316570458074988114042489251173284487238668951428130503046762201057410506670812601428055584717430419447215512577529529016013538972939734949671147704030752901227226286506887527104316804744260887941876942191021885256531051053932610793379076476139188427157238975217253773399045826108753351806240497608137052909351776152073910623308348561648187745838850301612802974666726087274685795004974359057660325921335488251085657653161595858765823438083470597189037391715889483562041895243459452191846139155683041450024697265478307645733225606929690981278814508393298336327737160256377870909217530295340553637941168060445814445434473427340628567183994932749297261732663175101484514531954672385026633741329382329024335431929251819460916989887644189843551107064029574266143747543315126134350346456200663822030389205763116047417210247577986381594638768109838907563131265407213357246856943485434509522366407845686499674730914651167955166915582512366312834932657741205032250859361412284633877911199740813387487038235611797826028319669627229207830557577119477207196496735441328921765194396236566166109113503694032188180798401147840845309560002669570271712427314708263863539299417050576237481259172735946465292410752482746091369673261731221638191931890672749129174867083467356708145333735442646691983446466251772992793312297753977983522364272114950510749743964789893377061923197381072002904618519700458017342967578250620314744748877082296167249583378313829659960454023968306314842269922494363551235698523597788438243601582472614802936763162176843991311739521994416139147859289679144940781501153998318566733930848019484445612290408206373851917837720423482403134852257454005383504117439825554508520963206193070275733365149944973871938731760086317512674719749847679242852031764722679955559867631455858989717539901636354895347706299088217991332550288160000340128792006986380207937134270019292434443167071630853908384093999777381698937016056174015125184354633935966960634978592396983439755932615876635294138129000908441714729868452668244047006273025738397595976888389183415330715903315986759633702153283969720683604350352123468292264821048760209142531771721184116079978537926757182880019414324403585015233380434162862083228203362265740938070370378727684752566654276293894557449380318251111493229359028483753605924366266899616742600361983505236826428141955612371052319462276864524283576495681385167780431645064156036352618665342351730722061650942018747415998444870238523623899099365045845681165350572474345701894694977377940770952122909888939159954637135183194535102479706274287694862319502189807147470332585078870953956214645803737123893131747819178088983405552233197499581191602823891844340159635125437892551966792540295940761998237256901740801386314185277954699176586457479511557547620971550685963396828136479625775956039506259237361329517670533209853527683636350696682668663292688511949888294322244435692535811866945406132932206001097269925231755913697462558636991782026521652794429604480224759868022354413541044441768242032779271325748702223558675347505002650313984659352285881195327103159048324886703799289220591630337950433879310066917215494396399844147285663447072713631662687147886165654949667508297002452337098803755909737818164173612614975130815661972398203048547207176531660021838776426688856189423395780411307957876095425708814222954632727388196595802977323902358854767819462276065704926635806539593169524433420583470563597702732300465799754004928102590406607309676651125198803841780309610431113024029210126315619629163039760473098968635324473202172332330357659279506282940184144603086512316730122338564318784000747904120565643384058275801493600679427196709032765286513212536657516254959695553071852052752983392418201771606692588021102179350823836779966458449749753045834771562900101633432432546473177253258821243678146799783185340695980776075496905921734336391431248010755120707205781395580370221086304782648935578166757877030640947865082257621842004254978304114564159990044945943504810341200529950367305549154704221148521542238180298566932185789851928547472505397992416471522394673076335286884494752697669853066048919581725276621857983051587697719120571040604149689606120189052631584372035107736286657534445176690636535174871736408450912922033620401824634692054147153664682250382352955675180867238303391085080954187609891807430467698014123581402935975327161811490482701074157361303449739819912278879092128988923416240643978783164485722105021067750115904458652393269483239672843456436870819243152266515393208440340585290871526560374869038346242698485747197238752044728738297681802633449947485664656439033862389013001448869279312761475701875903599639011455975216331941922047399551338681647514747533636658438286687006438823311539052880855621423699700829879553470404651507523700193950655220906978971646120576865009039099275331774208350467876679440674035540959566532760367775985375544558891201895609894683590064822475852082503328343277341416350387305259130563756946450203002244515916252433382572229164031801399610937809362871959146582958821282873089014684164727269584024746311841517022063989052429798657732430971322836676588987104604535477650923434042900034420155515827925470305423329046276463115049614799031792736010356989245996090340275856011919937042225180419805291986045529544723045972964160534471688122539269805211979701809859129549812129402081087029395568333835210867278117484746564395112595612436691722626332363628526464985059330591777749971554100875980393101661881100281385721662216424920614062372998952650189894029666590361270239745666495521748474855176660368512057746644792598150713536840559219826247602182654164889737995981667968046449057538032440074829346816894375312764277369145761289578628460552678410853137850457859713034594969831896542395652836651321301607863487892661889063043786172629318403585606771945528312297265987859592484694122162107106834070851372152559424461027661001691230097834511204495782292751187775082785986482588476312804169314519895105575776199784202714739228124712583854273512394341578784810296459466693438200657289703100615014256075911546394385481019058894433960544451025195346695835349896329733685783612637076504949204790553090819153998925336175928625804167419945582352404827130632877144756323280307366761772631795271749843888407353650213668451323478308355171742390816428546906747348569762542570115213378550159812714692646814170696435841338509440581233392605345196962753739023433753939536212616032837126931094200087381850212231953607943107790204358786224714158519510745153832705606196004475432329837418696436603047569235256301579295791103500449941709040772198812902094625033540358743636559123394628537468751256472269949074623821978921596461712936138963040624145633758489906285920336320127040019664175058036492219663865966282266198915025713253255530003722191928719633436857437176012576139723372004296471574302209100944353045567126448072839684960150017306225062370577797780574223528904223818534909290743089862147586726013152697269608361139833344078632570167940160270059368166009054848229906297000456242305657031709107052236375055999589190292607129504373202257735337284351475252608197902751020272333085621135548867558832598838630023217003474645890316391809475128256258158212500911247599127413931514487495065490435488423095800285153101768518532974827747741483737307912343403923211577245226697782308341330499783860290283360576017647484784028289163973224882476477275852426582488567630469762804511581834604087449743324457680108467176303635564881681696760364563050717976585441780715095971457035928080826471267902910172919752045978769504619352992018525564207948396325004066302731325253626312311081552097562605562324638894558691175512155300960372128095992217742851726339617765024461255739032833361814805990750506104834772366524675206665541507896194373939795901303371624675807733141746487792276514967238032951727992992392959620301345371047220189120345789850121136290276707523067666002249009301749838017871738274997330283708603949345526400333972910268013081515778611271427562917350652714084812953385184535808683571228555533542747102045297037680775740250116709191993694726601833680203208874247872934910954688466125817178622908042992614039597738274623525127616650921167436752518138186698548588618466621864480852078450710211748595677938400810531532123604304790896267102375301829359946731007905267072472238446727012388295684192068094491915793516553156251094366346159208651320146003884434961524953723826059400417197084025651683755780864468573433460119862374068284611792806575815452930587719567572479139525247797667322289705882494132962269558511859165858129196512567766899898602338782942441554593765915093119842178612099080400735641441834895378797740620538280363260206251998522060062007291898176368500790809374851860946916097483680725155121640955495973359628646836496574935543881206774498734442670251410259464847109562884796878624534681399322934590754300033479850717077499485297221959694001474597413004808993402769448576825311284704414079264190752205718780619406846963275893809909498846608445148818703375122161415042479037553863144304615360750813026404190102067050417543682216193998297845025539209642923179172207369685334860883758502064926990498722798799583682851254953214190720732629238162601328456884543856160322802985957046550438174994368729832088238105494449403863625748028477459611704385668455048337887170872425694306843358640728005444186721211262235032575107962814017430534416583757915531743824839685975857627497988950489347894775740299044989656775317312791565237991866359895792956282854580822422308973976606535726968514564381392260540548580577142024192522012123215887009674183427263156472024157180693704522425242909877529046130813409458036104434469288245652882177881627858926527482712844297341038668829194739797261340606425550055320340822132343929117473110582569414125055432879999369409599563207941079705335416634637974571495011672959708714754216975964708618262453300231958563618481423641529070638980265280009081615311097079655251795543092346660491394725357606314085338660599825494197594103356953041082645862082844231477192332374167868489663748005641519188523105849656933744430902013508269766353492751706617958453286652018081697535203911472191547720999355732008570328336642807185692371324312322395110021679962060535442187024207502191773547929719655955982272663200877664745701513265696872362949745570980052628707746453138103846698774140724810725908613988706685969818301340795656046330711505925732594468271437813374415619942354648962103095968432193903261068588872623439236794976209995008533082477095411199089313402464143214316463383604835106870882385078650102162290384600082129609157837648090398759078600466778965407955075995053279135795250860876783717355802906289242904067835810306500228901943077211654841705830732254503806574644143251782153407030494700811364613095512263511903943110880844465065537702494715855780832139220368569441876473921680358083564870985179740333040153550994882118106560272714422679300859158245096855706864236181274318565715656753401322959672229447711692317757284995048991360707704550497451848415145941483099177063805535571724969532746478366966568138655980426673083229260149525663577910593114478426773452162911238529124677719389156846808581352723226132403500171679691829362903793329619448626895617435898685415632071179080510959148487576912854605612954783208930828398953356706495859733954990869514754819916107362661688561010974914791692283700998553861986926969082244580762849418981431812634037220548326058040622304253398395392406929894901380381912248989758021337891355603951165192115959176935221313461721550179693795777672607172982385520680257110435652477299119267285690713219278151694810077974399421179093998280698958089356453317560877171780837542489460405644071316922163151501497294206260403027888102135293590241698754183101082861822244728809737816467361577414767745096066775383784280078770338875233605244358742467555589022267626039274045564311878788030442236885181513773901297155257411526632778521620471274366390041348333420687139183653141268137291113863699078657454335896389904314806480035976641918012395912490927180319331984718128695642971176445002091340526537209577684297468259263033440809020369268912820935684598882861813015169355396964206050741436443879838496906871500074040782058534102273804768279567331263095474154006932461927278173507530597567228637666710862101683001435819600503650685147511210433081812273182916985824152655785102717055351146930815208100401972765099231005022270565092932590124351279453932281828889052462983940142265321796333169712162098503058693351818636303033841677357966684298518095948681687030204744565559502582911196263181085450732517584773410169402160988368362347195881469786089341306097682719974244955242496166810027357315344867499336795506035309253097997871488205199354327490335675255456187680159655471941190829070657063802772970467297640600127692691399334879492183339591487921896957769872585649567688715464427963877114861173692846796456177620685739929323414861113567626046907151377603514084221287183193530951699588320303445970797505206143437025892246687222730094475265989339785735587550690393703770411160689209093545551340785715226867771343485750583452566529350797152517128717250483164887828941155728431174414711033611319316414393001738448031983058822714306685414258872423374584441108677083051650772844131618207343517031825206263985797596274311675933653744190402431059335144616226468337583246986141999088433654860328718869820400025200668411850377310524485623391312399782340776281297559840484923314057687981331757086683176904796306545836934268837819274689069091366853636304263102367415830657314627510317150338910977946251191717998563301606613933025383543428277256993282313478715384056111355848806733633572847854683324640602842626940946236955370139237177193490890839544554409620958471077426068691087881744171261621686983820971535185556160505548486277281763034238148980838574695408941911723502839915305561798582822818212839241692449171746223632017744780040024780236957025023127095322644459315784616325432737025345322406420815459863747422456562975194875928788968664686631719637081713370359967280616768630748075260668330658082150717703710532688469085209123825945483068381237767004379522911772842196962336305935948783033983706804503946941461825604124827453309984592196146260284756849121043952005070868091342557443073774744319806811205591310435633253288391170442498145898254282442834931796488620792872801125211281721852512488468487917592498431904691279991854692425064739915634693865339312727954722383208603212529685817054230568558111213298610752620626798577135522780750820903834683022917721729995589428769533161575653741924292082299283004395381662458444872338119682702270994918443856075055087435082741179444450969987935479549453051791066309076753141192171043698383746005362290479435690108606242013015059764886874989522584697767266895779247511972062156189672052210992060850926520138339954656709992188373095001004644059765470157930062521771149356650490317153332999277816785204935217965533436023116211753872148903246571642115561860850794908801866901890496086136560126107298024774034505841618317906508351447569692419255897880914520346681778750536882413673549471122841275203097466762527665176982255033053140080465039983686565680579988171935207946386089232204406010138928615844703261794175817951514892372910744580291060227360806138998509389825193195094064553678901025098450218918587743297078198426634994970684350945836680114023159035318869982318695882880418968944297818567809779371156143950040688357931832042954188883964649001085683922552864413172171627415250861664588046072792806202406732375333057098534525730666691944755615814623816287826896570229264831226076239946434037605224084456129666171851583542583635373762209032743659651224752172086973974386766296818372238221837000507729221175424248828492361037430561484143521461259332603879752081051275363525746157342022898007559404593811863718373773588532179159985506903607935524088125801836617972203901446419021677818982620895094263182936500417337223240663544962149164145696321458084448403375757312926974313206449769356243246792669077819724769495543818381468792194589297919507464901719149512760904875830078678551747021481732284512181593577645550664702038102839204179262541977921460287683546797838569884764071709293874241229556559575182580676035582563133083117938187331997641364047752938100681325795190503975413977526085695072056027653367760696994341931114215291790141617225441351067805183806910577951992267889545985986884997510606666267175344752240581154280618565051038288023778621853486979291573285136436847806225962296008204140524871590649499242467266892738772609938855050163176218678307547680630383970404782235970361416491793407512342872050675248117503326986324939611644670515992741617775917825011053126316714970422467189952314409641723861189885038258890969441719556541688614460267910474711124114755738466407841596739803039001688637410105750400702755469343315507033807300115713910204183985072040383787529966181181909211879741448547594514167533776666728807609063036435209168787253646032666411436716782182889509169249597047822102005601184882249571094879146491486069838308287335279738717762634430024059849987532567241036617303214631146025602939762808524389376738521564634661250272137195597226894290113090301578433978326129845128267531470674246661541705722707961320208291717292565861792531630110375280739228680822550021978448819538936564917413094726746274508967921689046262949984873382954104247412840502748170390272727594012749388197314289253791029666413406824282577202766672513266112701570856544028223521856420372477278108025484278275229486194427282343986193240436929941322383746775462752344730314167197846769884299125197800083896505139302486009717059510653517810103358449575623051279437714655090428590115564620851176104716074169458074330665494985647281328944615433726078012103735364425476804944932286827386146617232196693719310524340429537981557843446723670705193931091582617195627903704851569178330409141946989450137619361319084910469317223517141745703266426623573653554785888775292167613356076022664667754667006762044658464708786083330122555570338522839201577320266195137350342822710926483271878584143638333155088878671170135005190873905765867549930669335349567731712011974213526353200535464635826329342038930512986433287885174620805948105589839355657438051953686563357424513429374467533070541447707798725837719729460345074742093738608731812830502665671940293911747142719734898367853471661202378543624091467684089622555167545541598117301015465652165764681839661502587792449447308758586355920683409368456765879375274662266852979551198047405133100054413460860334897493736108651545919045807326828548729200827920884018296137121542876833909261148204060848109925584836758710170950091687670914708871881991647484192661998166640018152490238093072381808483422527289009968739135388105888016328198863743014295960993940930803086344734381675450805640874410568253292845198442972684600778419965342476567975805551276337730184198828452700606106402100444139258487871531437006657176360418344913469402406858819059886352114520682631343414503222770455885174043736946076329747007014639548924947093381437914394068522572226889034874325030305931192550158065743865708864208994380217305730697443045144297862339304907011829695074164516608258283349914846984147640366154948439925160111428362659228188338600536590312750608590805053889679284051917419601612900365317028529779912183805038050405856769969584608427929733688646599756147039950386281055697595397710591686748788299021923272679944205275503669720671014078583445350358736840121653785761909997585394896344001691246680217958261162708052145233585049004116428399094405171868996800420118107894549220369881338103156772850508453822573163107705649644552609420268307702943738348513852115138936206736561736679149051054346860615804213215156479811547095693384250720193037923580944910375909987706010180853769916492615909530930004855945193006661635789910542775600304749667304066263934657651612643825433229132778560505631665922657057083459463151414408187610049288921801225567972565564723197930486897689014958656508667318651412665381963701557736428136456488657120988063755901869604800293106306622418279391718447467017352782329343718975451431817221453965212482491101306389063702000625154289022576385994407760056409258666339306038313176100614636798123454278751744037269618012815502143763348193755537411359037975293443919714959834919281337993058416951452055858431089593622385660164468951833290630224596616452546544385915284467833361845449647555002315476674429700275121022879018115256942608381324403193759392517819898377653167036411966943527239757403038560151156757092167123944090896378343433817695934312033897425509507164769909744724697133471072213885695250409381038516214625331399295986714855758140385810847201120583972462993858266020989319810348128108816398502199659805505494829424639865119972252896221638564880289913799501753639765870965292061616366395662961719060350563474921595224092744914741835698596731741156269815024604430682658180185018229611748009714341034524469190241943921477590412529976476958661336929144698948219198298554108441561005707134176562864670421236499944945201131738265151188637986334695018060697580983080253690324529658924776950575725668896189766171300296412902643856925998628017223590324697676711034787224978669150993880164125034434208855734611524117358180793390200730610542946383725794982528047771882013589734021795349698401271225417260594050065535873547176244822768244596593992224810415836796397851305219250222328904825375651003258354199017960556936790135677605911015864750932528764946863957818691049203546878201171835770787695280889595596232417050025017399743563922245486154217127976620014354634091163609013295929403593565341134770666052731498887055766305681359909145585136850892078818882984956967474891495788789726241886104042229381929791869344130059779695990020410016244033574729432200785586275343906662165159828981221925616592049086296052063042706556041207536957370572718200831778468554438087645377312902535236322946789421528314500274731671624702732355404826103278059596971769467090752882768826178237118508041730537796475941333069126744901225732010957881946783506524328812875149953733313193647442247823453955065185107719041274867898309730378843876859953444399125342250893162027476171573878566561104066417358339082436679945121266470980597799577601161506843113586556904212817861400497111828473765848105629102807097599264212137398736971109991440668350334751459119050131803608979373164224725525290808326363314649451413338304364971877538213729884671769673326614339083573238170338387904661338025497678504043392234270979088720662037326166790562337323825651509162981952790533642687256947285633979791023077800868994822845550922889041271752371299771028350580886770639588226079650939609784275602323411603663351943139104806851971887247390182565256849198973371109138638881170605542413260638579037382345995632524530347984541341779454664944418617383256481032707636456244803743208729202463393031939296450199219672271295022455977474423143407823487292295192445836232592518394815105982640674462704675536330039985841001837892475857312051234732492701083047086530432853807679284712412482057060973493353653235310609920153815281814771625407305461366662746026548552096867173329086689016933194609347610366663395584216360251740660130812733879749203672225256431711799407524938744817454547705610010218233738299915296011346573771005698727991443033338798537432861503643509097998742822509263290822077525737229032628891560208536146991778050639028058032498953790406132416833504276858494680776744178564267974226696645177498396039668655457683376944158642285525657372737233382217531728915580976635809626473327872180672133321813551143464978111534727798575175802070978388449852417824470404062298585266323058782793132325055143469543582826999677746716147939650952681864474722743657145794828590916595835053979492423816814964419582489517321699533776337593148982033575920445722690592372032761796143118319586335330310181609131125277382209234581934019041885843643097464727160852116247240551667009991657180629398904018944892066376377360752107975642206208869975854206698934943108260406973620231666523245726269776281276190794683930274660390654169389653612073348482005847330397841036343498821768149424845071765543605450420940141660982409946682274086489140100778685260013636232592557496559960868699553052593247356995912597257322964481673702013012986131057426142915865515507037460059165004177005643716127608821100615942263372812916716292799480283677205717497746988642405273781641623274552707712437929423736010053343556734059318994810878425403882909181876542565113639781834952449695040348703122765904849279549075517860094165588706369412480728939122876117560555967543730251755017871240340757817945160394402924689821848359556189306456932691795849182047524285884270391026932061910391848787505755155753867830731006986880051862022438999673040942429176819164490328604619323400098159634828440921149971969039614093394364208153407120251937530007855236131124521443457722508881462555782845120725754225136864301294851681540552016849528446108305417691211887560729436592991202590834586464242432134655721731852466619971128224330810126183212505940420683171524845780464790664570449346311933925352172012348159746882007829537636921949275978301513744177750824172696671994685909290140681681216741787034562835500731326166136822046672346703077400553372926895806564524851217107968341354548463355490005151923371120990974568494297703762029051743163413026068392572561919287733429457223859820288379913574521746931842679500783800225280916103635127857497981314205562326804581428301241772484346250447002315973614774018052312774802287507421541302525440857908696526701396603900635313482053748528827791770354996197719759164326746834527833165140733047692277331756905332829683656330938553097832897858970455802528632479692546590405542250605905202406726081583206180309842520557299568566720829426017895095938514801214766249122952117928468430592857317745930775345601234520413460505704869635070195433748421917400207685402577087540737199391825470527727793729210816415808274458484628273180951112545970198070449421373857602481599972413849643647475022409546746538026655786179508036449079661987834717846578538531558429341423943269933984410490450682118888113709548191764790177824274951891737435011417123393625700993273707708717840990770428085514430184133377864324000087759037124651016768416418628980841231198659433495528385609329943114526364919428376984840004208138027698065554913877620368425366389733762242361911381180096447745809249544612273938475973022321339807175922336011832186205803312876447897385574269047059869205921492516673496828081223605171556296865868317352590827701275195005140701297930373504081740248702965317608279717327663905650749263603477515506045503260761888063055853964816902922851804568780913623923484290673039528394994665109792773940705630881886253596940883412752716285670770253303396222266669222551687476796092325919932642090586932621184720717761728506009848817619250713065672076633227485154613378308048485448243380345872412102516286697919224794267056002534360200079103283206869950589257797018167394604873106692300727040201705903982139614793180365102478528730081239203293771693278669309887189716673532119050243744458477190603915613206970874396407819347443306183165812664264359079903801538677456037465737278486825702145073114650616428687150018951374769817275641967019432368504221964452664724411966795096010362468531262836376922768666476007515899819758451669555437269324958465038810965748882658465727866686618551180821412827629677218884569897184406066418259954276979911789438187271388777661335354350789822216127213058349714865188284262464214183265982317267523755472047856656049339512691129255131044705731976435219436080353149149034719554883906322177788219221340028911949373091437579403682465499382581336463142951440298927266402610023818580168306211852949045978493242784181873904435540709507913360957925970031238214018513097112524104128562199326308891026260239920617538905322443363775391679080608116735244500091733815571327301072126774839173092650707943553688958507099149990662970657291744699187851695963491320500234138521703643085025113589805010382994217253990798051697238463643619733190154037653967533143210635881665959587463428791390541639231606362202804473737836081222913673791506723692622730865470170952668248862222807747503693762837527473931558057799143528595914638935263300623250651954404031353433845991468590908324742551120386883491657461910307389647318816960957156672294777887586498053516510394214251244603650410822155550264514749024244716704902152454354772637779944293365797375726064955782105372903663090805422712638801040244646808404065236167546167304914696403090855873117937259356224948793031718026218847488424633410772591712267843141926794368076575376069606238664732718274714788779537531832516865103691010213670438001162344407805317601787826250775474597470533672319300820840301175177100097431774100514624436612963177733751997400671764942769263818092276867861677758972470996393231887738461569717424355564285423510798261761432601971339913031072734429594088879997354382381883260261434542864168378288296990891906348699010933962132021064117642214102489460008726299839146478106932096996494693042835602138182157993549047436505257401678907504069492926203331983709885208197797954860815894489561663123544737150964549799762107948638815461845151605684303419656547981982238172534588293304551860278044566620827964672340252596535504074394207794446426329470580483345987575730392652503242796404645149394801590862410293795790881406005283907632859566392022489450282450328002912249455738139958194937449077249426116989933168996389523402572803305323436970066372923735047044164212347776139612692075491783182330188188227214852407015198821667336150088927316535368232518692660271908357446425290642798653452167545727584058749420472215694381869528871769023986276991741505775414073737954215860138990852082177092647390005999365256334093040089442860323427260167717997566483928921012717444506582561993812182882499542514806574404060151026083220579442107497182980918932500219712808132785197731094453118166574766453250251352691651192123776157243888115795427466996062729255256030853290981709357968448353459435892158712128510588040458942174527165681227325404020113021931382317492691683394820751845930470438223253428209142472438213669377057386636937710224581514924679733241157723340418564264158691469148571356489853101658208520448755280242847304433509529096865615967244307781168142585712531932822765304590580877308072797250343232144348576106688135840678342811608122893417428538670187896139962908674664026530891719893240505886024068722190721500592769441251798480546502309043155449628028556368189234740753028886518336147358595726111413820795169397420071127433690119395216963617297554110952777080784692635550804690861026642234488460265084344593729351866851795797407547154898480683497072718380927492015794443680399023832042998988923463458856343644266962834545775197985286385787350307846742048564415357569104581014083521878150649984749652638336983101570813007006372476988783052841016914026144793828515333952115986246704396695370266580464862323152293293640872992827554129651574572273869243948845118304757370416403871601544261487318881932970929382132332656690172365123263878798706792536266667455022320505599478308748655264381197037037211075845083822090481391959157300356925149593925851734596358141186034889474349970494977698441249083877025522367694554151661854811924464293415819458050193567233948649442110833716146368159798899047611356755205419516254862125211932022911838079709307297340043827377844234599882814081073107090781030043428613462834603397053562293891777469665099422539178943072829332340483163804506228713820596139523815738684707533074636017300197218814573141674700170485472398893521711505343359839751241006831725138756601939634477502792875678290365042789894242072190510218197588443257943511029938635566134884546823066492227518869882790319470104466055344476397210314808284017698361753326616103973592562083963036088296414143036366017548079795185072130995062297383643285292176783221506002453118464535505986033410522717069083258074852416222055678349894167969488703810644183281535374756194998180656873356024600064190868575992105347345520909264818985758688041258717365451817048938841127244112031052243651061489720191067989843103007877531514068609593314915824589511716786122334373127279326475068543928962241840170475403036426183184065468039811658558208710099472270335836785251347714899537987152980663622446704699137488415556230589096300551071225908227424525450268252555765938701559799908092480464655622109922704283279285350541458204588008934402193239101284051259054763756806668874308863662041824942643550825974670762447148462053292526294428304375760903979131009647474990546730100022288720462811398488290070004182577933065964663271516001688395010960712047014180510186032970783993133522313000099010094500648740961026236080980336938242582327604612708709419928284343120537417737404663901145032797971049047629057683929272560714114462624289828090003667484678494780384814112107399613285839822200235273256307213345729071842670051492961489090221144968757000966392796924594928051883141398357465704973671517157704307484665831100984282989223759797069687187457085314841203447267372596812092322994155492743759161386780887386455163934434689565211860628863617753982554982656757229205242861856727119683110479192974628050241436691062704499597502549550496248075129493816738818637371147598247389738729973892357919007439623989273886370647840808428833653217078790675020506744760603393435392341329782101522724825879408868314595895336286185724867948028604011109017695006453866135495466576691275609415973949904319919545167142071424114572633434767249417472327834001798490910871671890488401424910525482883142162989982200501563950075448217309240232586298746267538577952957453221796432836179033689080890827417462659878883802510804483874887887863339029120654971998409442236731756933416073032130282797073374992253790002359690988894194496462717834129248882335742573470521120133681276755164442117819178365536156099399017136139296999198327684971245913320386043626203755868977318576642911222663268416744971922190064460632909653997984503066469221834697931947851987721429507193431645642730651816296213097121022022631720168849691931600947174043747974145256365906288552302725842436128146953280015089897504929093795742838779902125622983806105090885637828685126739072319375820905860377359990963696729182802477439464544997507979127790859252590201931341167653214525533126186065855729594259805519058980459498761913808212780820077931825736089045315238995637371147563748252640820449594045253081845581679162924307711644907305550350658257057844935068120113687241410272526539235669922938637007445306312605280807879645477725858328237829473993491609213787894831995794162692545350711166842173330470343516819695956523804491702772005372976047090493800295689697648518149408926542859332102972423941488924377933548312930155351444721252398566594557677286902514355304750260425964257706463838697517665914930948511980616287050535580023130411872596996053737918737940572300214428387049689414480955391817239809389158233730613063149060365956461923941770352912758755415346225981308572920455867127764044643299341656240740842574336280325135924053428586487310561310209699955341451684908866278556526561876145863457174362429301586335072627313793765620991040546952157353750799397996619506417398906942894159044614483850655361968042419055313562294117815668097492188965329502477973892063229600467199788380567770647453060699789715748664989256267550472255501362942707363702145446047564675416710808791028625400682160565406317293333004717667409635367203826549155075608821236599830410587202570283967152486479645979455676043773671456633141974881832519307511235189616682551024675733495875657775333703650734223246839789766003111492991764646183471514303042630046488784083670683599912015734309802244774466866269628268212808954404002435575734812908775365739528816232928900952523567683275977379882730323876759321697176844385373282735242076572828295080877528881411263224886774751669967656016241493169596599051128685359981780275507842862108803594491789375099586079948360863990938551203895222035510482005579863604164193849770831532610011724659660427032985985246520379864791163217705423665815883718171107976951316745066389123024409674630917896208414134045788659290301554452408526426395035361829210335965403728102318041937538083893887089624827179537226562221522024209263689611391781458875474441743869546899282296671229549555735866174551159083279604107580679803757792639730821743143784564166021967047665311707033602977422340622134947734969424628166501560404821824536203249209615647924905059646894000278348256927519558241355272839130514459714051968822147299547392157080518393310521657574845647099428017195906592326114676684846435546662413237186968779492737555026749905834946682264306049736718551610445501416343467172352075130746812997222406699269324146896823331840871280872999529884187829881996025969249790115564144327252856356928095794556834485844014735849666972180454558071928463465153642054951609825666718430568428854313757174876770680399699954634121151905351451804390866788234201380827190848267074944350073565367807568110513979408121243836455083125069250264704928705204411464091686992284715240682702928796393712959295139313942895381832563571824644852113887816281509542868377229579226783548197852732606074521938086233467949426114335715131572736103361576939541834972902213673727884036171792428735962269513915936168563415931576732426577916715782274508927092633645252042923002879565397969271833879168819541641322085628137708980255176331681287687877785156648541339630178671111414557335622724924061381166189357489206886618548159294883929885345873900419489783683378430486265170621311474382583135036828476134919890291546992609029270030173929663684790916622009349928510643596386876775746315551175240799532964370604454350269482455915384703837688330250948696735871437874193232565782193405996829489818242412917399132453700792445352097662791728388078718963394905870796528091412019726098481404664377772384869083017975329296704971181826026447944053931090259802023193066517742258287906847678545138841033169522329854705321678481316761791126571524367392959465561085933768965965240877120170640189675058349146352601522534310330338286586687820074715245757804177562927692008663484130520399466413620310313557261814710325352097238269022890871979676054175131228176635198415562197611193678792638087766757339427873786330515002256686993396753975203269921719416218171278292568140435454939324064743772655934840856858041681450327448923970803583873687526510543430013131294687338199667692196120794691289114387791674907949030965617609353463560079255111107386877173851063883803268248737281929259980768648621418315462125646939798015181840338585170727614475483042676234769108034939711929492513304245556013827406503886457784887858500367285093659978428632853396160383891729840081623258828132892002205521589213687024632823168982947897363489921540043022572270966185077376301252283938856453389306234551157258085641614176134030387352385132228964235113020786440335021530263471888983311573894412326050261320569236225638521831440566286754829743617301948181613079347355746852514755367707231614060039111670385734228570547840830358640684734654868532911836653319210687651340860558278268557288599374341917771692692333625069021412892267200765957207442431444219237814636024313104761179733297750266632866418194029831209073400303408585212377769588097561123084486268123904306578308870003265268912603013484952032388617502757150745162617439255784604213018026178432524024810327383724606010331286321861048371151859484153213560986950237246840447306479057038170926166489298528641726511578861466108428366604162162655342995276142174084786542405105928115991104663550002650328909101993659614983141481417673102578171881329910874647867288042548313270001950601420379179465934460117474698135174189487056678908516728627365745132011835517970132217416856869840498851316123600986124973356435663298267320507227641410552976538841058650648116270662008603751517605813247280902971070232760118730803959699335380714305731524750105539695917831371955397211682171263924576381237698228510113590316903887164247886097944456330416169181677795452499603026886664351129231297803274691490129561053945877992865216222576248642143934099511225738448595817176794876895011284878043384784137823608556759353184810455846750003896104733785164007644929956968041337402029209063694571611012545600145068470688327789081907391677824585455659475589440154906418617698447089601868421493561491401290794640413630193675286119648522285781381156071514519401972714229323443344876076282018667625237714750678445612041557388750139619009568213286796106191654978114099053958519287359739804112359587187178720713718902218033976889773197630516313214466799357939112127763043225452525607948898923916591839583499783443962457074719724118390280471434735290739105190780708720429356799272268805742811769148510985148336268990546962187550818782042180740608072535845770573694997640985050136409977936456855017359673126206052527848420498895239235868410571196620602622189275727079764557703998131513854589967697230603314845597792968210184787806306518083598866826120080987712929789855378469646454844710120274538153372038469952890948597022867505866565388199414220496301807339228559844727757653582547705255490648386685338324862047500211173365606509873714909650491516918787330431238274799706539156120960822361451779940476164140364788072925988149325885320001823181546477947468281842217733639717494484899204332386028886790792721010724256254548015146797407270530706479775466383278288023827846265448111077852663969295951833732066510135920172077902503626277158530549028479173066311833138614614022258319403324505125378806229986107403700889533894298020993729336153068246521914480519992869940123381622605710706774081423896596395676675907829994077278445953658425657708926639140608749701860085091556558035255342092319886660540410399521760841465403382509941550989465646910004308110315544285153125641497195490910143575885009568708304942623252917177990387092721820869619538466899943750658259790887968508256361668424820377452673623197909511104335960088045052151440393182663601964334454566352889678049667234616779602326604463531008123258370752098910778174815556828306593395871938662523998996727380995317213260908599144389502315935075691610196701625144394769170223042344081217820063771213707350508043290728723908944086325960367414459270963912286206981816161970201233714071992382828973350091464389534164263235649645628393520314286520906632013396448062782515256480400113367178808529717095997832284698807394041601480786640249309567210111946328060993159528239051779323833388280076463099476739408714590244753204249748137002265912999151461409256163678617377046978259874328401316764935909193933018220062413569161739173917947953086623165966451720396964897282264569845442917323999478684519120512213497562091464005073509226348136700441363387807245125130249499577685138285900795445205748251695592287497154090548569632456917755369008262286307185746581438952606148397111179215964336159855989375086691993492497392330686562557193602725070120187945840627503128534890808248564956795172178078257341432535405409049242386207788607735457102375700557602587222237381293211469343827525641525772618950075858814799848815932000438779438008645621254982583713501261968730347990054854324805195255700713136105397331455688580877529574023515246788098211531554350574506814944161643486697914337285504754009680674748776135363791745730493620855063256098281461838413814457927773499709314867148320830081669069511995991437607372641637986610448935589952240503821580382317762654966259420858579432791207498580424058483121104635439357398540800711186953091241045723913557461778803587461921745495599878486009241467775406888235249025568072958427347414119960335792579400510849930933255841809231576418174134221818801397562064370666406810355719232035593288012677257917755323369750501155266482686508388196714415558866834199613643349833298942744993443385922599706544796894609136005982679795896181345961750665203137656933174743887216304712981032718609834367633146269933534385220023663352784638731920180759285506722229838477336008290438184641736569597491234724657400739479958811501861228320810514245354941994410852877616926322581009533064232915677943130573207625318325065722253492144812215706021501718745289636408592493819337097252183128884816459878607331257801340016862481512427969670212755519138685638851468339762935632122812834296639478840967326682713862558164546771702956374494076603640480999715510568111615260008901285206956633926829390539512537469024635339423363938747069206824098818227329704852892588992510085116709603837980046105302596961462027025835724722649343399716543377774566111247562605228326029979695981706233714263526117791637795978745391196210676215644542019027735978929416788838842877828680118799343564288504430316278523695499718062035100099967428799630521811638984848992947912205540608414317005970739499036257670758138746148483139278976667177347526325474812732032734901765157602502067059726771603484580112119757219829689350303596674038964551560807081915618479239800289807458568247706240942668315181396167673750958763992819212970848702579617257129546814131158630912156686892661524198604644287470207161277378789513303659429920194002702738536450245140552188761807024837757907177726502659588745002943604996846344429112064778344267305155666151437353473988082533871427107637890267183766641925557290679660725183609940479667669031269935799293395908394593332764961850472633808344564108601249898376399174306251627881378637932355004353460907031507972364741933002174459406865529233588839393164425701526317372431560828725766440219669069776215400287289362799093641499456963477025122456166354780890037836828400109489399497113844760322782701613295743884451027022042643664382762646278628086219403683882396093044647439143558018180125083223871437587191302070165077900120275052703351751402994511446061716568520848387063612017334416855262045103118115880365016375467984633493309407110718499795515717625963655482555217978154383756906709019241341655800435617504162587636666056391741600750264473803680676559942873774153980592136014679646474718006336388351649579452097847860844218232388715033547556235984920010137175220045079609166106006924706972851154620160021989768715285522715333433118570628526429394939439321400371835178708271568554552476745495162952761038291664296675703902061906423442519495459923893443659919322643585298875733077759849416124560275981433353120156369588088699009594590937388774101778644832171031846882007156296050524557642584257784787987800379760778933784912594712460925015477473716186406808154748665776261893616740927930230588262709842515998414945068406868184155096946511786869150201299836435634858284593877894152106490562231371692976917402853179971893464178474476745489637440573605207290635099195736363239370751169383233839614819540959871447503706699818577018879416655196009822938718072458551123446193412755137469436651088781431111689098513009201207027953739637433825854092073189671280886699713454269476032496392392924023463024879051340699269875496247319100566472954352183917023050060340195176222298169716563826941970473556271294289753676190356697053713515057077885445595640022259989318614350753633452763476852398503474694044066361052604147756460941387122901612904807703011051941826732959801280349830272733132492917563164539570741458346988886057953304103367839712137663915609348571370653996660892070545803930340991977760774829134986712611216832379811218697555447736997626113197734928390489155199498925511389394948925592805463582953396029588543773425505612578856508296385613892234667538502920836678381604967057955546476475748759976976673565641673946604063465856496713926029235092676807322552690278698232660935792630520601628686064356650747968519123545726464453804860764676233829679328638212032120133339653424355980595415940583153544586741896402745099035015235106894253113789133731206618168215006034461534852545219208520734634262835039738019160332003289291520931210159485748538965384076552082758797945733728632376719293109375546360801034166584042400432529777904655137718279557007537057895896498159547275171572483901896619821232060618189389703744899360102221305932163115486907852770263481958113368996938721552347835314066707360360448674140115287608870036233600101352188468480098004819544780930257084792187079453058257940154439274910888920549343341338743006092971849907428889201887499914883315007436867622953365313027030336683329219211057340449681770316701981659007573479636458590400124928076402263415750240427394573498615503307447512602756411613624151658485005746291043758931969622165119251142423357348937361164597878542789881157193933052604124464314658442848759505258129939866288594488284935986728869708505523740443992250196586652407815322312843817392480884902526157002359691275275919567519287701828851021160008317341664454806643161157079870965726816625158412648417369310168212439586258624045272276431969329005557429342938433646747373767690239882384555347268491511853578223093859185997175537067110310225106451567025173686276719332166742957867492956319562908246044932650859332257528503370901367437135908535971682484267604188669238249410923859498091100218541334323897632120421108597579272482686488844671217444528429580548437769030880516370438649306601859017742698259292774501294772574168848309678486196543847359198658727800963524079418503069276315159338170660803097495826073642594018608301992801245204572701277851535214075009222311681930596720610576681752600133766470627260519903641399549754297613736096751719407281344960554615104877253669734194858029855838234135895808209796611834220875857379779569883508680191414241981772855239739401691678696068501930933908476061407218264171036436811324534881328178229536645161522324774644490092762849694114759730157789420655478580584203722894783903109350302210596213157305462158464179360041287134872077321553280316432306583952259753875647839369284268639844721043803444611954032230966381791585672001144300816449527752179669458352491612220588795456822857083393712842510737050361437853795665102462191752405800775265120392079337618038322586626333746079120778940877343520623398738435419526956156889565785355806791412436571162270566342827741808660858807994827998975196433273111613216186118436954517822507239698870536627337398222782439126436581364605882167841622569267375115304114311817874745581872537143205989334442074662647058039617053075388656776335929406020273254884390229991807664848040490296601021546757457588253628115854503344946016775904353566850707569086703882209916753310807781939552315813754842350318283209832900367563576436099713469139961573758034495607825014276243578676238668131944119708834768342411829764095930797718614603667528468070110026702721628094281934790252018842125824486501690695977824161368254300926559795268918970325466626495786307105714926145725869659594293960168425563903589908966638243563003078956164069628818053525624789945588571368049009094484088581993543235170815543968389901620667645252482574193475172042188829659403293045850638091453157970474133876717219268650973646853356076270992837328902269756200317862734808900069302626754939844325195748738965072787627637070102258283305217651952306673575511801945770038677741464845720471366090215688535771401442991680566593855979975192907217602740223601358563267512488548990471733695991717645302800576469110573670751547194044005808400771044658541891562101674074702599760608327808781546956989807747815773545052704653228651875268784855394233461503316949581529683213064187102110456675845931340928315945699639811535790265698509886490383882065012370587914820455350511303119690514115291827231260001747071548698778430740848930357199575209433850612876185399205382467810355480455912555631275830196395110012548343888743776255063708607054805447203445109617395689564060082933560498366003483507314768945963228188619143229187962892621531887338974475314068000671183695251457266109074107147627321092120724584895981032759008146716045899795251041951272057202625621775540325100024248036786272154987500517647179355117363497756417018749319758172048203097737736731850055401196624076796157109390527991139353230590862647291477160895644791289192372725482449388783776645197379433120196816242550582980738105381745788212062817110854479344341977985643044008329747831925311162942086196637155978580129847642871825370868830681705940512773365542839840017644808818476805179020499263847897064740469178786912762498612500574093501121662910182654709827010220483238714726728707174011603009518976021000757623716311645942528760622303636057632054494256081807020087041819994166988440550921657021440633791472337566465990681903351138028956889947018243420595380718777051709820167172455643199750171677414709493041694010587660467725382838759874557464682559817224947144425455187510473763289436977046129859948171616510342217044667268110605398057789275589727940730534103645676284621678153883122866052365573267287215240979492589168256071052329412005017288084447335662293521107485900437096557325435462296018345534833620988600714891233982840186847277964550591682383501595798958225981644351765692622251874545615760849723276592661234725269260525692981950387934426173976077900536597372427452471428650229267482309857898042451783581003829581409054812007856615885311885897748717653593464271559897726197697954870717957786373122562588532979566668985069360020252935984836131805046664547866564242025575088327533089800345640472175403141507486183479113539265617402602041843608203330035508083350456966536293366917601015253847680285498934255355116753986995515933652733376533037753146606561979781164353976255157632436214772291203123044956028273943277510259338126981035574675260294470717516070551131536812263071927587340037961643651777979492113952182937271930097217531041707877345833461860653537048573704931067102614034736050927425829256916357732214599107146461325404781994921793161982247678616456066400480662790604572360604004653371221877487641627653579428090461791158306201419248272391497276694580791666604894063635677528570234016080667072735543314713792772871694859734878955529593176910880682237591862611940609539004400853639648059729271835737249720665011516558803762651665050922985710153246812131652490932557129847144509899705433958744728325349551129431112922060847924108592156317428486764302888990781363117198729281400189694777645522220338916104339065625914842374664347838212134034935944604205392295628919319656199509353282224841026751881118735999917628241416171236870191342218901374596708875440968066777118559069244326632852604049313979709815956496432007770728791189495241798363108199662583589612779666387037760028918376812258015074844192742989366207265702352968364995198532894821757239506314682191750507123248330037591854951978215826888210497471086235691452018705900672461787333370098637123546218545945113329103753446096280578988045136048179020190600469248753273036857287988710310901495789528851286875220380911640565319820159498155710804931148934174865717009435725438862421088253345532423547854216804045827219946107494222667405539133622123542965485956481127295184659135003401481831552382860136597424177864285282481130964126273437207629997156007057475175247159803822490313375903461925506567779519713928758099724394405689792446084506775917666813553291159882877052727004270721871680573390363783853293879625308488452467242701878273620262431853787961631300537178525155946183422963150129116951267291325577307090484347440183767241291246387854636289366192977178101091964362967918599653809087723281183681673543061919028743529015638451266904943969645174257981569940864642641965250217018629611080827131514568260602038010464184281153766268286035183151398964190218468145531966972128651190982507079275391220878220671360188082399568617904296117337255428659772119726869398630259282637618199782525599397874965246210229977385917250758324616523065541602934094011322874865540812048570525598261080783908097878904927217989973447356914309599104253106130024776225121976680412693643955530573117314128701545604522143095962833260366692762536887867786897452945804028303461548196133835284481010668702577799622100262483200041794054970751365288832233153005685364806957539061878525058324128463353736579211519832229797003519663068507034460915476025177476050580697937364238113544209621590427260458524888118737266921962455564423535636869472910082561699493476164659607945042517717545775472097080780858856352162909844220241918222304277680138043785234278539674210558369055481183740219387941619052590639031951298552325982475501362507876839961003799173323349009640215653341980467707423125884295892013536719653187565147658820940603935094898118827468916295244114135077418870121534395151633366616641976539785011604414966882532247902752417475818197202405475270982970320494864132210387702684929787377795098260653710337296952088629288925679176967219030505511233030493318397825027590959177261663526909616415325581120503203466582155406070089703514660391049927435537376410314051970379479770418536498697619825811670052446329053185439326940485914820020629407791060156356087110491460557809346191747892177395106942347376052824009081787825346083315926146178637586121890185902286936436310851201552523629716062803354233616653247744039149393197353776917045739736168894571918845654858272751557610934267994818082705819535709323042737232692641638754527331425862768634777311586094661580778553926261378654628911955551868151665320026362102156522833821918757656009772238541636577396487103960450842839303116842413145237638458201757308615093499258718805525650945386118109481128213090336616009257968974798661369826597389514834175887913481878889386444925641278979600531059598299384392201511039309499483456296727770903105403980043303851903139546448445290473446261427588086167728511448788520421291587328966518574710955846092118490642233602178680437263416620687746419095682239438848978110489123255794804147698327018622711659082360591125739331629587469739479599061882263798648135480071384039169182370078601214029491056374285852337397611633147380490963416393502118212143361019324710537869611913988180600838836236122244514658347134845667079599886689745958134803534306045727168619730789538558341345541451641773884363958878253508187443531394533312437513596520684310735349360698341516921121797922068692432410084271009510325705924245649736783438673223297411117949660408192816047120916301705630777836220553864564560537061683519614668857101902645393876739787494747952434769897209764545636327095392580557964830420761873869137326083807008716599658793450546282168777930422077648906179215424022018902073147323504828635433418931766676148846216278275032672978530365097399931283607913306731939142891974341047323982436721611200433631693961323622606764778987219243179469964606854542919653236942364649250141248448857691248300922339124587509136801653972659152987300026520644244671143452097753265002235627688471448702321563917930143395468452923691868532891318585919502353229910811049928254282766753028073195074699605619414650322843437930486775783352762233309311714942510770492097724593132782222581524651588735753988161029464335207288784457264398928316785745530100814713505015236373633401996885714003690773736435074144664741264194100054524758594260350053381875613262838809239726277363295145623879659340186165663846872291626894527085323906035464102557283744889630749341379423160633476889332589521250339013595582576312126796690638226222330679328340893798909944911242821439074033531654128080797457546705613601595710937867118381622721001841243174245730364702518607602321341525177080924990367346233187283854033768956528242948242129027735528781365622572680642845098090594653254107350379580963619170251841526100342671396821747152017526840608725055828162910885649295099786771399485688890075835515410628717283747467706811182980785574166959604114215148812835502424050727339409943385368416170429940183178895813535459961384752270024308673143585223533581469662531358404633118074066881852148472435698097880911248788626273739689120450256933103646697766948078416626193780925175714925525149014861663238954540309965720877386658088661308302183061439321842086709858527013447206387974905774549406907825839951491929338352372587897548281143617163734370187425693046303933824320803027489397393587798918038849081965246605247741735218000695720698647051349909518078073355856192569049452168996980068121408271287615997078542633443888176552070679000504490317624847398280336032811182196017832029523606718287650162350777007097867774526830291794616416729289773874209344453770621581955164919412900625209068859322502015278982659949718718414377772217796889564715821645197472440036340510156083353809493657714116861242405738073636170474387571276140029531608745484019390309719245892265067239004370165818017513324099769888958793462394482213205311980245210509157164613913992096309056152808642406484604739464906197184192985622504910413031715180818511891219712540174911412859186833315367267498108589340459069474566193245828565251378338529470455671619194236886851240917337278494912941355431164438192594808339241948243344886030541219372485583831967642501453554878879539721249252556348744947812272383423176580166005493548446045513097733090737100404003911511639355724030892573660305910614020641786497726003488916704084784543938579470565153680042250052220757602822993968635782538291446002310723737809642822376228239139104134317725273861707253646228564544356905395658089154516377995779654047621650430021210458167605700825545436546739509152375121551794789910796027693387314098477404490441179787054406109200790728232946544303576307355312643169748276293292908625844323891218026218579439724723455650164174522059626283143420047518253493074373145927588519698071903330635228369869345214489434649663591775294760313154952361989429356979973336867550642054319883023503419812661027485217870133412022131599512076886666532439409550301336868337834642192978887348460326679174083445920621863528171319728194005221143441471658844011617716594474896115211375867832679076319507928045249899931750546352793724345432075680989456682242193008504979757367773716144057322012275828761855966505208349294131822554338173605623903407111730459343934923741098009217456194670565158754696616496474878683873652928607709404050849938900868342275155561853473350220118286445529952770395222802743832142216493283925583404319531848333151976921844955707527136168215057361924297509499026894456313312865973226130953595300338288069241926769692231123727302650612397855193845405763373494531719694030619139144541589345415535661856809044965238139113281806273736587258130646923344454784248224803987778499667236072315734125969208147628497534760318488431871210615458774136662815551408359764113722783787194735669418611515719170767674797985204768483507848566258642861893503304571634056585564276401599378095513716679041699090776437543405322068170689801358832365593776615834017556098246602123692880888682300441765347976164234252788051833269981016229717850098419530890522927690161927180850214862830845272155399561996029626036917617383864766759731998607079115278466316857217900899708746451892278162569768969272207163544709210547762525461232870685042169350710392853058346180722629894199720647052930273189891706570645925610806155362077937171586251261377820442983718064336618287486581542777982252924421768949061243661671630432459140683194799027188241214331252259123606559661295289171879899648250910119494370166436716830097503484232699991517902483900577114577225582374657719105814753543738256643278400424283327704764418276712941890001580752359028318495343404155133775476697618036288643835863437542133154505595585027074211320038519713111039582427072331924672057109309113675026882651736411507928212086549409945277842335823816748086220614835941715968536298200025454293728726110688054453363042250551700834834759350180405948950883094280377428806499500863093177247234229240196143470427228407615986399678778721525673554178664247852495770880695778736931719901350429305778259050833900161604500691440471460541002084842591374721758693229256836007776934371594309678345715335989873970247024903352115845408592112724069159663189251873582037389649591413554385523127162460648773732745181064888037102775453081592514196024192955443117079072656770913141094795906826662705761432484153370771809953356618191145452861596421569666455035734456145207086670004261081516157042402178027168162356971383975186025576685243061148959477515914822249689175828622018197226713509564157142696105186347615676794729912887897400847716541555513675051566112649270865418740372966438003423910123605239019837327599935497835964029031022635576290235882163573049422627265050090615633655041182715197808685946554951921610478825531694925309601556390011791022228195009302134253808012060629388781017863573148873033768816214382494692991532039777585691130069111206509726146274491098285333128018214826541404556995271990185058633978665254542527118269126392953004097851414752759465964102239730732549717625235290259634612115000797892792394953396901848221531594712428311782329603259156787084652441008641554233139897642617551941152067284293547739536289693310197363616126417890710853093904077021995074595523211466528280507881016373408725594011393603481604571522897982897330507961226534066311237434611627515854847252320862428153279492804450476217822932251062909095446391380383988787216823356188511942385899356095664506275026145525867962507161438451450906706764633180754763785662103742773085561211985224667640747085275576225753049667540720264367736099086897788033905665730897690096542916499271784065843322548010474707697224121290841190731348359854570130324334610833827001923428940084908423463923437897132906009358565834104922689729724302849627497438948380779326856480514794460604870056561992386545960175349584719215891194849448620687285432031405106741417861536690787345434003073064303395309593369555337402922350612314356009875764005286199743607506050892074526157915765788274423754933753136967415158663252522298742632445198968548560487159676677735465808224429575878626849311452977835324208623873151775809868819380490618940988278068415077518957757667839143087359139940032906052143440624051886884839282508642946429850123104615154667652105050870342056817107976218090713599149853325833107552503012387092433290486001760513299255596153548494235289172636792756087469503328423213739546482624412922779640792705778624322150136632519870456092006795310109670455517071778990781906118590992209700087520919502188251210164542274599007942355540502213518157465077042705984055782046850981848310664235677344135136825238154321410146992527007856143303090999956398891747425576128996242017522378856183762911265506631657980294026460359769707812718675088285364003950711063224542384176005440424165452069259597606984736485789922398446277079109437309139915848820921376817959907458626673391049151492870998785312096022914814526919803949106857333941085713178067673484162278576268864267523008645557298317109688537269811044825073149158315167702201692668869778022528677691289700552768128357439661508033059865921085340983041730074531962191561205283932504305516081671237087458290684497429581428026302234247611905028201945403218779125796488457172724444953946465469402488454554512507004674442823628664348088124059983419143344096998975617701673941229302105461658496588022624732735339488806078256438185706516055443279125037730755273294190663770368164493844121797553088626283352506821571866781692415044470174832864498262705506736284998247381815037696452321012948262852182994891591603124858624916380956638072383961498987941942141358507862501246441142644139165527240927941086575066710639314832471650490380404283375843731289227617186938488035251449805485977813568091178265539389348380289518836463265170539720061469429669517992691582095491912382838532812215983486788157764454387669471657411170970940535676953135071717188918313800214074886645475754935910218337076573806393654665042695393914037984558577227473474624207727653866237998328562280893234678437758606201731882542184168092525378631886614132376653460387326113843272450083023181651021137966484684923895722120770738240758460874804513677909116119621909775059698905783962342108137850975653685132855887503574860668055663678257844300090900643529287887782719505438225734000855992975215792720114159578295517443307239924544612313546685012385457182499382538484020337125472325392233374285641326013018969767045462023028549482962117812884281333385295697323657705664544105896933062770259056388839580108776754739312076339366726968435920249154903454247115823908541962306394815154649063452734302126469645239330321803966584506431587037795435705368475301188837849527424008187849181057247673908547509222522778195911861977972410994954968367950106773275026177419685680851888809856893758815278321254295191859922010586960685289023776833505906912063035599349383159309350740173106973051486527559082062278527858595247453586890637296271911860259165310364549970175417874639512662389259886832595181499832839120840299733244907910140971639340524341120395918755409226456355521561252091734306381236220898426438070019013817938388101728693281548535301039909542135839092413180590147909865784816191784839605651890645917851376115435504872562123440031427957240356380104814599323465944772199668010715982568792503761427477037677594766988718183322364727147622792077153485181375633581121772213021981361211207723470448648051776547732682635160561496823657341724357984207255546051445090969697205858791044389106071339568841953675037670460184180761085337454824870835178918243982897757607216425554032894089088496302407734236776722432349735721146083788236466177599800236004832035583197828636648599258564912218358073442151346174875854616848657147649988243962213503103640816275916551342201347165640867659909062444653466946908440036545968678983097663370238934517283969770441256863783868613379003497953957702731117531515350824625413097631182681200982512872707770899307190269048133451898201971680986521382018431270160621636745667338326178544383427850291360121961259402767631211234340957162762446929997432185909057051682992462438285533856070791224431711152391054294069343257718013104484046026480351306398358942769743588584928654313382112463078737208668915450564235595792854926085079669862524284544366781283126566562475086685475812826720736413434960603541362315888249761510955266061748869524634603138352481184374445749973551375963289047985545464116993421477782211358697596813764955019530683438169366505838959904262788977050338481955885058194238887510155883302392956956247554332129180114880261312052056450159506876801876123758726997985319037643115889716703878164173225099718011240912703008575458547032393999773762429738088223806887801385120706937235500544959435141731473103365199261918450677272194353971394960183318919569917781690394642091894568467974495367489245240111602695599920173103300781949846111590635261930387091018485319466957091838769465625952043184290003889229730577156653186403809298519333803133189821330529560609596312921302086947994850191233160106203757518028889701330905145642966977409588351005098340912279936003110575716699218082929411024640245998986877658972437343282811479682240873714066784301961867479921893821269341383352907686404066284980379810244437024174730434237250818818218466467627132110308057208264839672881582930191429585721737749256634162979606852979742757092297300816838511579651784214062799937579161478479724886640670987658108514684129292574929989797931813219657855265997946424310476881701146948368835443363337795227493729621585535080300064731552437681293371847319967691549661041101666524815422892160758308792435353496241821045506969075406696986342115294845668947007391800936652444235325757187187403393362155043516509225903469215623515031432145316277822579164858931200427291408251503298257318300538904884349308683266709908213489008440448854788855181003010801711797476812156232944978584169048601439668611712162536642676942460532192071909852124135632689900246001132711659613732743252084950686674166174061203968220157026776591337375464891397011144333574409371415740322795161465113378351204044964348192999234902434947511277590388426970905345202301754890115007059394997837478914615217055229465091671053266292869121516958936040524509273745513418393706979293691699379583376250591913414751724239879835935495318060445434077306291594881380694249497784448709710926245676532461550021652012701666354333777274885947462090867728505368444784731098182002221307412858631522627498267469998865031274272203900994160820095383503873108998442795109440751513300842963053869032960624659619061893622500300656643808953047636142376292425903356403570696046256073196287038375358947102581877747985746540626954367642532039370571015745376083209010551631810218645961741707638219443258047759838595677971444878160642853169606960325779990990416952568991001489687901291682029074738481758738214887573407962431510084663336698752303655819223967536479239542301395099036880581970509912859058164881561424854637634966644249279892746527633093581620683255786366761970966582660378559343484074699215190464213810022548436123291228601305491642516701824852691635443189996508353574275437728007998389817359549957558931868304362375013603798564394535976191654267970432465159770946038699346830489129420490882175644246420721333680906526202265478926894587843398773320433472366741123968516579511982497213218440167169803760809798932183135134538326438691152729628252677302258072573210773384329820777076003770457620355772291667316994941327770220765260956234209197038941348976053552364705412623260908631794433933336570640112499150975176577917544433547277292971607855741329335631533305802141738335983779034882852112390758964786728042948600314215587999321647030466089890166810023489916893849951054474451134267822848187279554556951206753893885300046497005234912323476546687232360801076166686768562495314751402851227880549768792210390490752307097833220467401814147652853777690920367092531511483446823649889597209758978341098458955176866455422351940901347354597774174880872669427323969028818917739051930194972825922665934177398739722481919524668416418716798687251981076079444558725217053838680578322075465989173782595020594234432392937555448392501187763490012088982390519630072018640054978802018780090371327125352510607063370546878255024249748995684854463901977229312021379492458391872745590189813547493468830634118526.470586802067390430203453634153
