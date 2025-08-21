using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circumference
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            InfiNum.zeroAFTp = "";
            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
            {
                InfiNum.zeroAFTp = InfiNum.zeroAFTp + "0";
            }

            InfiNum rad = new InfiNum(textBox1.Text);

            int sides = Convert.ToInt32(textBox3.Text);

            bool goon = true;

            if (rad.SmallerEquals("0"))
            {
                goon = false;
                if (radioButton2.Checked)
                {
                    MessageBox.Show("Радиус меньше либо равен нуля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MessageBox.Show("The radius is either less or equal to zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (sides < 2)
            {
                goon = false;
                if (radioButton2.Checked)
                {
                    MessageBox.Show("Кол-во рёбер меньше чем 4", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MessageBox.Show("Number of sides is less than 4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (goon)
            {
                PI t = new PI();
                t.DrawCircle(rad, sides, out string[] points, out InfiNum ONEsegment, out InfiNum circumference, out InfiNum PI);

                textBox4.Text = circumference.Value;
                textBox5.Text = PI.Value;
                textBox6.Text = ONEsegment.Value;

                int numOFpi = 0;
                char[] pI = "3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679821480865132823066470938446095505822317253594081284811174502841027019385211055596446229489549303819644288109756659334461284756482337867831652712019091456485669234603486104543266482133936072602491412737245870066063155881748815209209628292540917153643678925903600113305305488204665213841469519415116094330572703657595919530921861173819326117931051185480744623799627495673518857527248912279381830119491298336733624406566430860213949463952247371907021798609437027705392171762931767523846748184676694051320005681271452635608277857713427577896091736371787214684409012249534301465495853710507922796892589235420199561121290219608640344181598136".ToCharArray();

                char[] ourpI = PI.Value.ToCharArray();

                for (int i = 2; i < PI.Value.Length; i++)
                {
                    if (ourpI[i] == pI[i])
                    {
                        numOFpi++;
                    }

                    else
                    {
                        break;
                    }
                }

                textBox7.Text = numOFpi.ToString();

                InfiNum pI2 = new InfiNum("3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679821480865132823066470938446095505822317253594081284811174502841027019385211055596446229489549303819644288109756659334461284756482337867831652712019091456485669234603486104543266482133936072602491412737245870066063155881748815209209628292540917153643678925903600113305305488204665213841469519415116094330572703657595919530921861173819326117931051185480744623799627495673518857527248912279381830119491298336733624406566430860213949463952247371907021798609437027705392171762931767523846748184676694051320005681271452635608277857713427577896091736371787214684409012249534301465495853710507922796892589235420199561121290219608640344181598136");

                InfiNum C = new InfiNum(pI2.Multiply(InfiNum.Multiply(rad.Value, "2")));

                textBox8.Text = C.Value;

                if (PI.Smaller("2") || PI.Greater("4"))
                {
                    if (radioButton2.Checked)
                    {
                        MessageBox.Show("Программе было дано недостаточно точности чтобы правильно измерить длину одного ребра, следовательно она допустила ошибку при вычислении длины окружности", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        MessageBox.Show("The program didn't have enough precision to calcualte one side of the polygon. Therefore it made an error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                toolTip1.Show("кол-во знаков после точки рекомендуемо должно быть\r\nбольше чем степени кол - ва рёбер т.к.\r\nчем больше рёбер, тем они соответственно меньше\r\nи менее точность не достаточна для измерении\r\nдлины ребра(иногда, не следуя этой рекомендации,\r\nпрограмма выдаёт очень неточные результаты)", label9, 3_600_000);
            }

            else
            {
                toolTip1.Show("the recomended number of digits after the point\r\nmust be greater than the power of sides of the polygon, because\r\nthe more sides there are, the smaller they are\r\nand less percision is not enough for calculating\r\nthe length of a side(sometimes, not following this recomendation,\r\nthe program gives out extremely inprecise results)", label9, 3_600_000);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Center point: point O(0,0)";
            label2.Text = "Radius: ";
            label6.Text = "Number of sides(power of 2): ";
            label9.Text = "Precision(number of digits after the point): ";
            button1.Text = "Calculate";
            label5.Text = "Results:";
            label4.Text = "Circumference length: ";
            label3.Text = "Number Pi: ";
            label10.Text = "Length of side:";
            label13.Text = "Circumference length, calculated\r\nwith Pi off the internet:";
            label12.Text = "Number of correct digits\r\nafter the point:";
            label8.Text = "The more sides the polygon has, the longer\r\nthe program shall work(for instance it took it 1 hour to calculate\r\na polygon with 2^200 sides with 500 digits after the point)!";
            this.Text = "Calculating the length of the circumference";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Центр окружности: т.O(0,0)";
            label2.Text = "Радиус:";
            label6.Text = "Кол-во рёбер(степень числа 2):";
            label9.Text = "Точность(кол-во знаков после точки): ";
            button1.Text = "Вычислить!";
            label5.Text = "Результаты:";
            label4.Text = "Длина окружности: ";
            label3.Text = "Число Пи: ";
            label10.Text = "Длина ребра: ";
            label13.Text = "Длина окружности, вычисленная\r\nс помощью Пи из справочника: ";
            label12.Text = "Кол-во правильно-вычисленных\r\nзнаков после точки: ";
            label8.Text = "Чем больше рёбер, тем дольше программа будет работать\r\n(например время вычисления 2 ^ 200 рёбер со 500 знаками\r\nпосле точки составляет 1 час)!";
            this.Text = "Вычисление длины окружности";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
    }
}
