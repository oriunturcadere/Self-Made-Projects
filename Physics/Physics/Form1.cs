using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Physics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BigD[] fallprop = new BigD[4];//an array of the fall properties
        BigD titir = new BigD();

        BigD g = new BigD();
        BigD rad = new BigD();
        BigD m = new BigD();
        BigD escv = new BigD();
        BigD density = new BigD();

        private void button1_Click(object sender, EventArgs e)
        {
            fallprop[0] = new BigD(); // the starting distance
            fallprop[1] = new BigD(); // time elapsed
            fallprop[2] = new BigD(); // average speed
            fallprop[3] = new BigD(); // final speed on the impact

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;

            if (textBox1.Text != "")
            {
                BigD d = new BigD();
                d.Value = BigD.ReverseN(textBox1.Text).Value;

                BigD d2 = new BigD();
                d2.Value = BigD.ReverseN(textBox6.Text).Value;

                BigD d3 = new BigD();
                d3.Value = BigD.ReverseN(textBox7.Text).Value;

                if (d._0 == false && d2._0 == false && d3._0 == false)// if it's a decimal
                {
                    fallprop[0].Value = d.Value;//the distance input
                    FromDistance t = new FromDistance(); // the utility class object

                    g.Value = d2.Value;
                    rad.Value = d3.Value;

                    t.Calc(fallprop, titir, g, rad, out BigD[] fallp2, out string ans); // the answer array

                    fallprop = fallp2;
                    BigD h = new BigD(fallprop[1].Value);

                    textBox2.Text = fallprop[1].FormatN();
                    textBox3.Text = fallprop[2].FormatN();
                    textBox4.Text = fallprop[3].FormatN();
                    textBox5.Text = "Typical fromula for free fall:\r\nd = ½gt², where d is distance, g is gravitational acceleration and t is time.\r\n\r\n    We do iteration since g is never constant - depending on the distance from the object, and we didn't find the formula for it. So the closest we could come to the correct answer was by iteration. We do iteration second by second(millisecond), calculating the g every time for the current elevation with the formula: (r / (r + d))² * g, where r is the radius of the object, d is the distance from the surface of the object and g is the average gravitational acceleration at the surface of the object, then we apply the g and t into this formula: ½gt²(t is 1 second(millisecond)); and then the last second, since it's practically never a full one we have to use a quadratic equation for it: " + "Formula for last iteration (millisec/sec(depending on what you chose)):\r\n\r\n" + ans + ".\r\n\r\n    Where d is distance, vₐ is average velocity, v₁ is starter velocity(the velocity gained before the final iteration), v₀ is final velocity, a₁ is current acceleration.\r\n\r\n   As for the calculation of the gravitational acceleration from the mass and radius of the object we used the simple formula g = GM/r², where g is gravitational acceleration(at the surface of the object), G is the universal gravitational constant, M is the mass of the object and r is the radius, which is derived from F = G * (m1 * m2 / r²), where F is force, G is the universal gravitational constant, m1 is the mass of the first object, m2 is the mass of the second object, r is the distance between the objects' centres.\r\n\r\n    And as for the escape velocity of the object it is calculated by the simple formula: vₑ = √(2GM/R), where vₑ is the escape velocity, G is the universal gravitational constant, M is the mass of the object and R is the radius of the object. And as for the density of the object - we calculate it by dividing the mass by the volume of the object(the volume is calculated by the formula V = (4/3) × π × r3, where V is the volume of the object, π is the value of π and r is the radius of the object(we only consider objects that are spheres)).\r\n\r\n    The object is a black hole only when it's escape velocity exceeds the speed of light.";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              //\₋_₋/
                }
            }

            if (textBox2.Text != "")
            {

            }

            if (textBox3.Text != "")
            {

            }

            if (textBox4.Text != "")
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text != "")
            //{
            //    textBox2.Text = "";
            //    textBox3.Text = "";
            //    textBox4.Text = "";

            //    textBox2.ReadOnly = true;
            //    textBox3.ReadOnly = true;
            //    textBox4.ReadOnly = true;
            //}

            //else
            //{
            //    textBox2.ReadOnly = false;
            //    textBox3.ReadOnly = false;
            //    textBox4.ReadOnly = false;
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (textBox2.Text != "")
            //{
            //    textBox1.Text = "";
            //    textBox3.Text = "";
            //    textBox4.Text = "";

            //    textBox1.ReadOnly = true;
            //    textBox3.ReadOnly = true;
            //    textBox4.ReadOnly = true;
            //}

            //else
            //{
            //    textBox1.ReadOnly = false;
            //    textBox3.ReadOnly = false;
            //    textBox4.ReadOnly = false;
            //}
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //if (textBox3.Text != "")
            //{
            //    textBox1.Text = "";
            //    textBox2.Text = "";
            //    textBox4.Text = "";

            //    textBox1.ReadOnly = true;
            //    textBox2.ReadOnly = true;
            //    textBox4.ReadOnly = true;
            //}

            //else
            //{
            //    textBox1.ReadOnly = false;
            //    textBox2.ReadOnly = false;
            //    textBox4.ReadOnly = false;
            //}
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //if (textBox4.Text != "")
            //{
            //    textBox1.Text = "";
            //    textBox2.Text = "";
            //    textBox3.Text = "";

            //    textBox1.ReadOnly = true;
            //    textBox2.ReadOnly = true;
            //    textBox3.ReadOnly = true;
            //}

            //else
            //{
            //    textBox1.ReadOnly = false;
            //    textBox2.ReadOnly = false;
            //    textBox3.ReadOnly = false;
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fallprop = new BigD[4];

            Seconds.Checked = true;
            Earth.Checked = true;

            label10.Visible = false;
        }

        private void Seconds_CheckedChanged(object sender, EventArgs e)
        {
            if (Seconds.Checked)
            {
                Millisecond.Checked = false;
                titir.Value = "1";
            }

            else
            {
                Millisecond.Checked = true;
            }
        }

        private void Millisecond_CheckedChanged(object sender, EventArgs e)
        {
            if (Millisecond.Checked)
            {
                Seconds.Checked = false;
                titir.Value = "0.001";
            }

            else
            {
                Seconds.Checked = true;
            }
        }

        bool stop = false;

        private void St()
        {
            stop = true;

            Earth.Checked = false;
            Moon.Checked = false;
            Sun.Checked = false;
            Mercury.Checked = false;
            Venus.Checked = false;
            Mars.Checked = false;
            Jupiter.Checked = false;
            Saturn.Checked = false;
            Uranus.Checked = false;
            Neptune.Checked = false;
            Pluto.Checked = false;
        }

        private void Earth_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Earth.Checked)
                {
                    St();

                    Earth.Checked = true;

                    g.Value = "9.80665";
                    rad.Value = "6371230";
                    m.Value = "5964524599470051078201040.4430273535828159087095150193";

                    stop = true;
                    textBox6.Text = g.Value;
                    stop = true;
                    textBox7.Text = rad.Value;
                    stop = true;
                    textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Earth.Checked = true;
                    g.Value = "9.80665";
                    rad.Value = "6371230";
                    m.Value = "5964524599470051078201040.4430273535828159087095150193";

                    stop = true;
                    textBox6.Text = g.Value;
                    stop = true;
                    textBox7.Text = rad.Value;
                    stop = true;
                    textBox8.Text = m.Value;

                    stop = false;
                }

                else
                {
                    if (Moon.Checked == false && Sun.Checked == false && Mercury.Checked == false && Venus.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Earth.Checked = true;

                        stop = false;
                    }
                }   
            }
        }

        private void Moon_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Moon.Checked)
                {
                    St();

                    Moon.Checked = true;

                    g.Value = "1.625";
                    rad.Value = "1737400";
                    m.Value = "73495642620406108407450.914582983722101023661688202718";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Moon.Checked = true;
                    g.Value = "1.625";
                    rad.Value = "1737400";
                    m.Value = "73495642620406108407450.914582983722101023661688202718";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Moon.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Sun.Checked == false && Mercury.Checked == false && Venus.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Moon.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Sun_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Sun.Checked)
                {
                    St();

                    Sun.Checked = true;

                    g.Value = "274.1";
                    rad.Value = "696340000";
                    m.Value = "1991408303975379378131517752259.487449955649317958430225589144";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Sun.Checked = true; g.Value = "274.1";
                    rad.Value = "696340000";
                    m.Value = "1991408303975379378131517752259.487449955649317958430225589144";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Sun.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Mercury.Checked == false && Venus.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Sun.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Mercury_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Mercury.Checked)
                {
                    St();

                    Mercury.Checked = true;

                    g.Value = "3.703";
                    rad.Value = "2439700";
                    m.Value = "330244167604673602953515.690552106058063433461990266823";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Mercury.Checked = true;
                    g.Value = "3.703";
                    rad.Value = "2439700";
                    m.Value = "330244167604673602953515.690552106058063433461990266823";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Mercury.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Sun.Checked == false && Venus.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Mercury.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Venus_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Venus.Checked)
                {
                    St();

                    Venus.Checked = true;

                    g.Value = "8.872";
                    rad.Value = "6051800";
                    m.Value = "4868545790659986095461846.426773427948121688682185409824";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Venus.Checked = true;
                    g.Value = "8.872";
                    rad.Value = "6051800";
                    m.Value = "4868545790659986095461846.426773427948121688682185409824";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Venus.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Sun.Checked == false && Mercury.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Venus.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Mars_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Mars.Checked)
                {
                    St();

                    Mars.Checked = true;

                    g.Value = "3.728";
                    rad.Value = "3389500";
                    m.Value = "641735067784623498669479.538752906767674346127106657396";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Mars.Checked = true;
                    g.Value = "3.728";
                    rad.Value = "3389500";
                    m.Value = "641735067784623498669479.538752906767674346127106657396";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;


                    stop = false;

                    stop = true;

                    Mars.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Sun.Checked == false && Mercury.Checked == false && Venus.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Mars.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Jupiter_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Jupiter.Checked)
                {
                    St();

                    Jupiter.Checked = true;

                    g.Value = "25.93";
                    rad.Value = "69911000";
                    m.Value = "1898900186865155946587394816.963536547359336417903291539807";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Jupiter.Checked = true;
                    g.Value = "25.93";
                    rad.Value = "69911000";
                    m.Value = "1898900186865155946587394816.963536547359336417903291539807";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Jupiter.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Sun.Checked == false && Mercury.Checked == false && Venus.Checked == false && Mars.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Jupiter.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Saturn_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Saturn.Checked)
                {
                    St();

                    Saturn.Checked = true;

                    g.Value = "11.19";
                    rad.Value = "58232000";
                    m.Value = "568541395526574449212475726.991585357082923788746913432263";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Saturn.Checked = true;
                    g.Value = "11.19";
                    rad.Value = "58232000";
                    m.Value = "568541395526574449212475726.991585357082923788746913432263";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Saturn.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Sun.Checked == false && Mercury.Checked == false && Venus.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Uranus.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Saturn.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Uranus_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Uranus.Checked)
                {
                    St();

                    Uranus.Checked = true;

                    g.Value = "9.01";
                    rad.Value = "25362000";
                    m.Value = "86836113838012130510871910.435595617673147460024452808476";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj); stop = false; textBox8.Text = m.Value;

                    stop = true;

                    Uranus.Checked = true;
                    g.Value = "9.01";
                    rad.Value = "25362000";
                    m.Value = "86836113838012130510871910.435595617673147460024452808476";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Uranus.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Sun.Checked == false && Mercury.Checked == false && Venus.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Neptune.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Uranus.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Neptune_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Neptune.Checked)
                {
                    St();

                    Neptune.Checked = true;

                    g.Value = "11.28";
                    rad.Value = "24622000";
                    m.Value = "102462357830892048042576654.759906983434420923932586963296";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Neptune.Checked = true;
                    g.Value = "11.28";
                    rad.Value = "24622000";
                    m.Value = "102462357830892048042576654.759906983434420923932586963296";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Neptune.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Sun.Checked == false && Mercury.Checked == false && Venus.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Pluto.Checked == false)
                    {
                        stop = true;

                        Neptune.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void Pluto_CheckedChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                if (Pluto.Checked)
                {
                    St();

                    Pluto.Checked = true;

                    g.Value = "0.610";
                    rad.Value = "1188300";
                    m.Value = "12905969105854290029487.210222232877040730707453311917";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    object send = 0;
                    EventArgs hj = new EventArgs();

                    textBox8_TextChanged(send, hj);

                    stop = true;

                    Pluto.Checked = true;
                    g.Value = "0.610";
                    rad.Value = "1188300";
                    m.Value = "12905969105854290029487.210222232877040730707453311917";

                    stop = false; textBox6.Text = g.Value;
                    textBox7.Text = rad.Value;
                    stop = false; textBox8.Text = m.Value;

                    stop = false;

                    stop = true;

                    Pluto.Checked = true;

                    stop = false;
                }

                else
                {
                    if (Earth.Checked == false && Moon.Checked == false && Sun.Checked == false && Mercury.Checked == false && Venus.Checked == false && Mars.Checked == false && Jupiter.Checked == false && Saturn.Checked == false && Uranus.Checked == false && Neptune.Checked == false)
                    {
                        stop = true;

                        Pluto.Checked = true;

                        stop = false;
                    }
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                St();

                if (textBox6.Text != "")
                {
                    BigD big = new BigD();
                    big.Value = BigD.ReverseN(textBox6.Text).Value;

                    if (big._0 == false && big.Equals("0.000000000000000000000000000000") == false)
                    {
                        g.Value = big.Value;

                        BigD d1 = new BigD();
                        BigD d2 = new BigD();
                        BigD d3 = new BigD();
                        BigD h1 = new BigD();

                        d1.Value = g.Value;
                        d2.Value = rad.Value;
                        d3.Value = "0.0000000000667408";

                        h1.Value = d1.Multiply(d2.Multiply(d2.Value));
                        h1.Value = h1.Divide(d3.Value);

                        m.Value = h1.Value;
                        stop = true;
                        textBox8.Text = m.FormatN();

                        BigD h2 = new BigD();
                        h2.Value = h1.Multiply(d3.Value);
                        h2.Value = h2.Multiply("2.000000000000000000000000000000");
                        h2.Value = h2.Divide(d2.Value);

                        h2.Value = h2.Root("2");

                        escv.Value = h2.Value;

                        textBox9.Text = escv.FormatN();

                        BigD h3 = new BigD();
                        BigD pi = new BigD();

                        h3.Value = "4";
                        h3.Value = h3.Divide("3");

                        pi.Value = "3.141592653589793238462643383279";

                        h3.Value = h3.Multiply(pi.Multiply(d2.Multiply(d2.Multiply(d2.Value))));
                        h3.Value = h1.Divide(h3.Value);

                        density.Value = h3.Value;

                        textBox10.Text = density.FormatN();

                        if (escv.Greater("299792458"))
                        {
                            label10.Visible = true;
                            //MessageBox.Show("This is a black hole", "Black Hole", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            label10.Visible = false;
                        }
                    }

                    else
                    {
                        textBox6.Text = g.FormatN();
                    }
                }

                stop = false;
            }

            stop = true;
            textBox6.Text = g.FormatN();
            textBox7.Text = rad.FormatN();
            textBox8.Text = m.FormatN();
            stop = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                St();

                if (textBox7.Text != "")
                {
                    BigD big = new BigD();
                    big.Value = BigD.ReverseN(textBox7.Text).Value;

                    if (big._0 == false && big.Equals("0.000000000000000000000000000000") == false)
                    {
                        rad.Value = big.Value;

                        BigD d1 = new BigD();
                        BigD d2 = new BigD();
                        BigD d3 = new BigD();
                        BigD h1 = new BigD();

                        d1.Value = m.Value;
                        d2.Value = rad.Value;
                        d3.Value = "0.0000000000667408";

                        h1.Value = d3.Multiply(d1.Value);
                        h1.Value = h1.Divide(d2.Multiply(d2.Value));

                        g.Value = h1.Value;
                        stop = true;
                        textBox6.Text = g.FormatN();

                        BigD h2 = new BigD();
                        h2.Value = d1.Multiply(d3.Value);
                        h2.Value = h2.Multiply("2.000000000000000000000000000000");
                        h2.Value = h2.Divide(d2.Value);

                        h2.Value = h2.Root("2");

                        escv.Value = h2.Value;

                        textBox9.Text = escv.FormatN();

                        BigD h3 = new BigD();
                        BigD pi = new BigD();

                        h3.Value = "4";
                        h3.Value = h3.Divide("3");

                        pi.Value = "3.141592653589793238462643383279";

                        h3.Value = h3.Multiply(pi.Multiply(d2.Multiply(d2.Multiply(d2.Value))));
                        h3.Value = d1.Divide(h3.Value);

                        density.Value = h3.Value;

                        textBox10.Text = density.FormatN();

                        if (escv.Greater("299792458"))// (escv.Greater("299792458:))
                        {
                            label10.Visible = true;
                            //MessageBox.Show("This is a black hole", "Black Hole", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            label10.Visible = false;
                        }
                    }

                    else
                    {
                        textBox7.Text = rad.FormatN();
                    }
                }

                stop = false;
            }

            stop = true;
            textBox6.Text = g.FormatN();
            textBox7.Text = rad.FormatN();
            textBox8.Text = m.FormatN();
            stop = false;
        }
        
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (stop == false)
            {
                St();

                if (textBox8.Text != "")
                {
                    BigD big = new BigD();
                    big.Value = BigD.ReverseN(textBox8.Text).Value;

                    if (big._0 == false && big.Equals("0.000000000000000000000000000000") == false)
                    {
                        m.Value = big.Value;

                        BigD d1 = new BigD();
                        BigD d2 = new BigD();
                        BigD d3 = new BigD();
                        BigD h1 = new BigD();

                        d1.Value = m.Value;
                        d2.Value = rad.Value;
                        d3.Value = "0.0000000000667408";

                        h1.Value = d3.Multiply(d1.Value);
                        h1.Value = h1.Divide(d2.Multiply(d2.Value));

                        g.Value = h1.Value;
                        stop = true;
                        textBox6.Text = g.FormatN();

                        BigD h2 = new BigD();
                        h2.Value = d1.Multiply(d3.Value);
                        h2.Value = h2.Multiply("2.000000000000000000000000000000");
                        h2.Value = h2.Divide(d2.Value);

                        h2.Value = h2.Root("2");

                        escv.Value = h2.Value;

                        textBox9.Text = escv.FormatN();

                        BigD h3 = new BigD();
                        BigD pi = new BigD();

                        h3.Value = "4";
                        h3.Value = h3.Divide("3");

                        pi.Value = "3.141592653589793238462643383279";

                        h3.Value = h3.Multiply(pi.Multiply(d2.Multiply(d2.Multiply(d2.Value))));
                        h3.Value = d1.Divide(h3.Value);

                        density.Value = h3.Value;

                        textBox10.Text = density.FormatN();

                        if (escv.Greater("299792458"))
                        {
                            label10.Visible = true;
                            //MessageBox.Show("This is a black hole", "Black Hole", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            label10.Visible = false;
                        }
                    }

                    else
                    {
                        textBox8.Text = m.FormatN();
                    }
                }

                stop = false;
            }

            stop = true;

            textBox6.Text = g.FormatN();
            textBox7.Text = rad.FormatN();
            textBox8.Text = m.FormatN();

            stop = false;
        }
    }
}
