using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Animation_Game_Test_6
{
    class Angle // in degrees
    {
        public static string zeroAFTp = "00000000"; //8 when limit is 10
        public static string zeroAFTp2 = "0000000"; //7 when limit is 10

        public static void GetCosSin(InfiNum angle, InfiNum[] center, InfiNum[] currentposition, out InfiNum[] newposition) // a.k.a get coords for any angle on the unit circle(not 100% percise though)
        {
            newposition = new InfiNum[2];
            bool d90 = true;

            if (angle == new InfiNum("0"))
            {
                newposition = new InfiNum[2] { currentposition[0], currentposition[1] };
                d90 = false;
            }

            if (angle == new InfiNum("90"))
            {
                newposition = new InfiNum[2] { center[0] + (center[1] - currentposition[1]), center[1] - (center[0] - currentposition[0]) };
                d90 = false;
            }

            if (angle == new InfiNum("-90"))
            {
                newposition = new InfiNum[2] { center[0] - (center[1] - currentposition[1]), center[1] + (center[0] - currentposition[0]) };
                d90 = false;
            }

            if (d90)
            {
                //saving data for circles other than the unit circle
                InfiNum rad = new InfiNum(((((center[0] - currentposition[0]) ^ new InfiNum("2")) + ((center[1] - currentposition[1]) ^ new InfiNum("2"))) & new InfiNum("2")).Value);

                InfiNum[] temp_center = new InfiNum[2] { center[0].InfiNum_Value, center[1].InfiNum_Value };

                InfiNum[] temp_currentposition = new InfiNum[2] { currentposition[0].InfiNum_Value, currentposition[1].InfiNum_Value };

                center = new InfiNum[2] { new InfiNum("0"), new InfiNum("0") };
                currentposition = new InfiNum[2] { currentposition[0] / rad - temp_center[0], currentposition[1] / rad - temp_center[1] };

                if (angle == InfiNum.num(0))
                {
                    newposition[0] = currentposition[0].InfiNum_Value;
                    newposition[1] = currentposition[1].InfiNum_Value;
                }

                if (angle < new InfiNum("-360") || angle > new InfiNum("360"))
                {
                    angle = angle - InfiNum.Floor(angle / new InfiNum("360")) * new InfiNum("360");
                }

                if (angle > new InfiNum("0"))
                {
                    angle = (new InfiNum("-360") + angle);
                }

                // Unit circle only
                if (angle <= new InfiNum("0"))
                {
                    InfiNum temp = angle / new InfiNum("-60");

                    InfiNum[] A = new InfiNum[2] { currentposition[0].InfiNum_Value, currentposition[1].InfiNum_Value }; // being passed by REFERENCE otherwise!!!!
                    InfiNum[] S = new InfiNum[2]; // useless

                    InfiNum[] ans = new InfiNum[2] { currentposition[0].InfiNum_Value, currentposition[1].InfiNum_Value };

                    for (InfiNum i = new InfiNum("0"); i < InfiNum.Floor(temp); i += new InfiNum("1")) // 60 deg
                    {
                        if (InfiNum.Abs(A[0]) <= new InfiNum("0." + zeroAFTp + "10") || InfiNum.Abs(A[1]) <= new InfiNum("0." + zeroAFTp + "10"))
                        {
                            if (InfiNum.Abs(A[0]) <= new InfiNum("0." + zeroAFTp + "10"))
                            {
                                if (A[1] > center[1])
                                {
                                    A[0] = (new InfiNum("3") & new InfiNum("2")) / new InfiNum("2");
                                    A[1] = new InfiNum("0.5");
                                }

                                else
                                {
                                    A[0] = -(new InfiNum("3") & new InfiNum("2")) / new InfiNum("2");
                                    A[1] = -new InfiNum("0.5");
                                }
                            }

                            else
                            {
                                if (A[0] > center[0])
                                {
                                    A[0] = new InfiNum("0.5");
                                    A[1] = -(new InfiNum("3") & new InfiNum("2")) / new InfiNum("2");
                                }

                                else
                                {
                                    A[0] = -new InfiNum("0.5");
                                    A[1] = (new InfiNum("3") & new InfiNum("2")) / new InfiNum("2");
                                }
                            }
                        }

                        else
                        {
                            InfiNum[] deg90 = new InfiNum[2] { center[0] - (center[1] - A[1]), center[1] + (center[0] - A[0]) }; // -90 degrees

                            /*OS1*/
                            InfiNum[] F1ofX = new InfiNum[2] /* slope, y - slope*x */ { (A[1] - center[1]) / (A[0] - center[0]), A[1] - (A[1] - center[1]) / (A[0] - center[0]) * A[0] }; //a[0]x + b[1] -- f(x) = OS1 (center-A)
                            /*OS2*/

                            InfiNum[] G1ofX = new InfiNum[2] { (deg90[1] - center[1]) / (deg90[0] - center[0]), deg90[1] - (deg90[1] - center[1]) / (deg90[0] - center[0]) * deg90[0] }; //a[0]x + b[1] -- y on OS2 (center-deg90)

                            /*OG1 = 0.5*/
                            InfiNum[] pointG1 = new InfiNum[2] { (A[0] + center[0]) / new InfiNum("2"), (A[1] + center[1]) / new InfiNum("2") }; //point G1 is on F1ofX and G2ofX

                            InfiNum[] pointG2 = new InfiNum[2]; //point G2 is on G1ofX and on F2ofX

                            //-----------------finding x of G2-------------------

                            //OG2 = sqr(3)/2;
                            // OG2^2 = (XofG2 - XofCenter)^2 + (YofG2 - YofCenter)^2,  //// NO INTERVAALSASASLALSALSLASLALSLASLALSALSALSLALSALSLALSAL
                            // (XofG2 - XofCenter)^2 + (YofG2 - YofCenter)^2 = 3/4, -- let XofG2 be x, XofCenter be c, YofCenter be d, YofG2 is g(XofG2)
                            // (x - c)^2 + (G2ofX - d)^2 = 3/4, let G2ofX be ax + b
                            // x^2 - 2xc + c^2 + (ax + b)^2 + 2(ax + b)d + d^2 = 3/4,
                            // x^2 - 2xc + a^2*x^2 + 2abx + b^2 + c^2 + d^2 = 3/4,
                            // (a^2 + 1)x^2 + (2ab)x + (b^2 + c^2 + d^2 - 3/4) = 0,
                            //
                            // x = -2ab ± √(4*a^2*b^2 - 4(a^2 + 1)(b^2 + c^2 + d^2 - 3/4))
                            //  —————————————————————————————————————————————————————————— ,
                            //                           2(a^2 + 1)
                            //
                            // x = (-2ab ± √(4*a^2*b^2 - (4a^2 + 4)(b^2 + c^2 + d^2 - 3/4))) / (2a^2 + 2),
                            // x = (-2ab ± √(4*a^2*b^2 - (4a^2*b^2 + 2a^2*c^2 + 4a^2*d^2 - 4a^2*0.75 + 4b^2 + 4c^2 + 4d^2 - 3)) / (2a^2 + 2),
                            // x = (-2ab ± √(4a²b² - (4a²b² + 2a²c² +4a²d² - 3a² + 4b² + 4c² + 4d² - 3)) / (2a² + 2),
                            //
                            // x = (-2ab ± √(-2a²c² - 4a²d² + 3a² - 4b² - 4c² - 4d² + 3)) / (2a² + 2).
                            //
                            // a = G1ofX[0]
                            // b = G1ofX[1]
                            // c = center[0]
                            // d = center[1]
                            //
                            //                 InfiNum ^ 2 + 1 is not the same as (InfiNum ^ 2) + 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                            InfiNum plus = (new InfiNum("-2") * G1ofX[0] * G1ofX[1] + ((new InfiNum("-2") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) + new InfiNum("3") * (G1ofX[0] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (center[0] ^ new InfiNum("2")) - new InfiNum("4") * (center[1] ^ new InfiNum("2")) + new InfiNum("3")) & new InfiNum("2"))) / (new InfiNum("2") * ((G1ofX[0] ^ new InfiNum("2")) + new InfiNum("1")));

                            InfiNum minus = (new InfiNum("-2") * G1ofX[0] * G1ofX[1] - ((new InfiNum("-2") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) + new InfiNum("3") * (G1ofX[0] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (center[0] ^ new InfiNum("2")) - new InfiNum("4") * (center[1] ^ new InfiNum("2")) + new InfiNum("3")) & new InfiNum("2"))) / (new InfiNum("2") * ((G1ofX[0] ^ new InfiNum("2")) + new InfiNum("1")));

                            InfiNum[] diff = new InfiNum[2] { new InfiNum(), new InfiNum() };

                            if (deg90[0] < center[0])
                            {
                                pointG2[0] = minus;
                            }

                            else
                            {
                                pointG2[0] = plus;
                            }

                            pointG2[1] = G1ofX[0] * pointG2[0] + G1ofX[1]; //doesnt work because somehow formula doesn't work for 240 degrees

                            InfiNum[] G2ofX = new InfiNum[2]; // AofG1[0]*x + ?b[1] -- find b
                            InfiNum[] F2ofX = new InfiNum[2]; // AofG1[0]*x + ?b[1] -- find b

                            G2ofX[0] = G1ofX[0].InfiNum_Value;
                            G2ofX[1] = pointG1[1] - (G1ofX[0] * pointG1[0] + G1ofX[1]); // YofG1 - g1(XofG1)

                            F2ofX[0] = F1ofX[0].InfiNum_Value;
                            F2ofX[1] = pointG2[1] - (F1ofX[0] * pointG2[0] + F1ofX[1]);// YofG2 - f1(XofG2)

                            //  intersection of G2ofX and F2ofX is S3(S)
                            //  so we slove {y = G2ofX,
                            //              {y = F2ofX;
                            //
                            //              {y = ax + b,
                            //              {y = cx + d;
                            //
                            //              {y = ax + b,
                            //              {ax + b = cx + d;
                            //
                            //              {y = ax + b,
                            //              {(a - c)x = d - b;
                            //
                            //              {y = ax + b,
                            //              {x = (d - b) / (a - c);
                            //
                            //              {x = (d - b) / (a - c),
                            //              {y = a((d - b) / (a - c)) + b.

                            S[0] = (F2ofX[1] - G2ofX[1]) / (G2ofX[0] - F2ofX[0]); /////////////// WOOOOOOOOOOOOOOOOOOOOOOOOORRRKIIIIIIIIIINGGG
                            S[1] = G2ofX[0] * S[0] + G2ofX[1];

                            A[0] = S[0].InfiNum_Value;
                            A[1] = S[1].InfiNum_Value;
                        }

                        ans = A;
                    }

                    if (InfiNum.Floor(temp) * new InfiNum("-60") != angle) // half angles -- complete
                    {
                        InfiNum currentangle = InfiNum.Floor(temp) * new InfiNum("-60");
                        InfiNum angle_change = new InfiNum("-90");

                        // Iterating by finding half angles

                        // x of C(n) = (R * OT(n)) / OE(n)); y of C(n) = (x of C(n) * y of E(n)) / x of E(n).

                        InfiNum[] temp_A = new InfiNum[2] { A[0].InfiNum_Value, A[1].InfiNum_Value };
                        InfiNum[] C = new InfiNum[2] { center[0] - (center[1] - temp_A[1]), center[1] + (center[0] - temp_A[0]) }; // -90 degrees

                        for (int i = 0; InfiNum.Abs(angle - currentangle) > new InfiNum("0." + zeroAFTp + "1"); i++)
                        {
                            // Finding half angle

                            InfiNum[] temp_C = new InfiNum[2];

                            InfiNum[] E_n = new InfiNum[2] { (temp_A[0] + C[0]) / new InfiNum("2"), (temp_A[1] + C[1]) / new InfiNum("2") };
                            InfiNum[] T_n = new InfiNum[2] { E_n[0], new InfiNum("0") };

                            InfiNum OE_n = (((center[0] - E_n[0]) ^ new InfiNum("2")) + ((center[1] - E_n[1]) ^ new InfiNum("2"))) & new InfiNum("2");
                            InfiNum OT_n = T_n[0];// must be x of pointE, therefore distance formula doesn't work

                            temp_C[0] = (new InfiNum("1")/*radius*/ * OT_n) / OE_n;
                            temp_C[1] = (temp_C[0] * E_n[1]) / E_n[0];
                            if (InfiNum.Abs(currentangle) > InfiNum.Abs(angle))
                            {
                                angle_change = angle_change / new InfiNum("2");
                                currentangle = currentangle - angle_change;

                                if (InfiNum.Abs(currentangle) >= InfiNum.Abs(angle))
                                {
                                    C = new InfiNum[2] { temp_C[0].InfiNum_Value, temp_C[1].InfiNum_Value };
                                }

                                else
                                {
                                    temp_A = new InfiNum[2] { temp_C[0].InfiNum_Value, temp_C[1].InfiNum_Value };
                                }
                            }

                            else if (InfiNum.Abs(currentangle) < InfiNum.Abs(angle))
                            {
                                angle_change = angle_change / new InfiNum("2");
                                currentangle = currentangle + angle_change;

                                if (InfiNum.Abs(currentangle) >= InfiNum.Abs(angle))
                                {
                                    C = new InfiNum[2] { temp_C[0].InfiNum_Value, temp_C[1].InfiNum_Value };
                                }

                                else
                                {
                                    temp_A = new InfiNum[2] { temp_C[0].InfiNum_Value, temp_C[1].InfiNum_Value };
                                }
                            }

                            if (InfiNum.Abs(C[0] - temp_A[0]) < new InfiNum("0." + zeroAFTp + "2") || InfiNum.Abs(C[1] - temp_A[1]) < new InfiNum("0." + zeroAFTp + "2"))
                            {
                                break;
                            }
                        }

                        string t = "";
                        string t2 = "";

                        for (int i = 0; i < InfiNum.zeroAFTp.Length; i++)
                        {
                            t += "9";

                            if (i < zeroAFTp.Length)
                            {
                                t2 += "9";
                            }
                        }

                        if (InfiNum.Abs(C[0]) > new InfiNum("0." + t2))
                        {

                            if (C[0].Value.ToCharArray()[0] == '-')
                            {
                                C[0].Value = "-1";
                                C[1].Value = "0";
                            }

                            else
                            {
                                C[0].Value = "1";
                                C[1].Value = "0";
                            }
                        }

                        if (InfiNum.Abs(C[1]) > new InfiNum("0." + t2))
                        {
                            if (C[1].Value.ToCharArray()[0] == '-')
                            {
                                C[0].Value = "0";
                                C[1].Value = "-1";
                            }

                            else
                            {
                                C[0].Value = "0";
                                C[1].Value = "1";
                            }
                        }

                        ans = C;
                    }

                    ans[0] = ans[0] * rad + temp_center[0];
                    ans[1] = ans[1] * rad + temp_center[1];

                    newposition = ans;
                }
            }

        }

        //doesn't work
        public static void GetCosSin2(InfiNum angle, InfiNum[] center, InfiNum[] currentposition, out InfiNum[] newposition) // a.k.a get coords for any angle on the unit circle(not 100% percise though)
        {
            newposition = new InfiNum[2];
            if (currentposition[0] != center[0] || currentposition[1] != center[1])
            {
                if (angle > new InfiNum("0"))
                {
                    angle = -(new InfiNum("360") - angle);
                }

                if (angle < new InfiNum("0"))
                {
                    bool bad = true;

                    if (angle.Value == "-30")
                    {
                        bad = false;
                    }

                    if (angle.Value == "-60")
                    {
                        bad = false;
                    }

                    if (angle.Value == "-45")
                    {
                        bad = false;
                    }

                    InfiNum temp = angle / new InfiNum("-60");

                    InfiNum[] A = new InfiNum[2] { currentposition[0].InfiNum_Value, currentposition[1].InfiNum_Value }; // being passed by REFERENCE!!!!
                    InfiNum[] S = new InfiNum[2]; // useless

                    for (InfiNum i = new InfiNum("0"); i < InfiNum.Floor(temp); i += new InfiNum("1"))
                    {
                        if (A[0] == new InfiNum("0") || A[0] == new InfiNum("1"))
                        {

                        }

                        else
                        {
                            InfiNum[] deg90 = new InfiNum[2] { center[0] - (center[1] - A[1]), center[1] + (center[0] - A[0]) }; // -90 degrees

                            /*OS1*/
                            InfiNum[] F1ofX = new InfiNum[2] /* slope, y - slope*x */ { (A[1] - center[1]) / (A[0] - center[0]), A[1] - (A[1] - center[1]) / (A[0] - center[0]) * A[0] }; //a[0]x + b[1] -- f(x) = OS1 (center-A)
                            /*OS2*/

                            InfiNum[] G1ofX = new InfiNum[2] { (deg90[1] - center[1]) / (deg90[0] - center[0]), deg90[1] - (deg90[1] - center[1]) / (deg90[0] - center[0]) * deg90[0] }; //a[0]x + b[1] -- y on OS2 (center-deg90)

                            /*OG1 = 0.5*/
                            InfiNum[] pointG1 = new InfiNum[2] { (A[0] + center[0]) / new InfiNum("2"), (A[1] + center[1]) / new InfiNum("2") }; //point G1 is on F1ofX and G2ofX

                            InfiNum[] pointG2 = new InfiNum[2]; //point G2 is on G1ofX and on F2ofX

                            //-----------------finding x of G2-------------------

                            //OG2 = sqr(3)/2;
                            // OG2^2 = (XofG2 - XofCenter)^2 + (YofG2 - YofCenter)^2,  //// NO INTERVAALSASASLALSALSLASLALSLASLALSALSALSLALSALSLALSAL
                            // (XofG2 - XofCenter)^2 + (YofG2 - YofCenter)^2 = 3/4, -- let XofG2 be x, XofCenter be c, YofCenter be d, YofG2 is g(XofG2)
                            // (x - c)^2 + (G2ofX - d)^2 = 3/4, let G2ofX be ax + b
                            // x^2 - 2xc + c^2 + (ax + b)^2  2(ax + b)d + d^2 = 3/4,
                            // x^2 - 2xc + a^2*x^2 + 2abx + b^2 + c^2 + d^2 = 3/4,
                            // (a^2 + 1)x^2 + (2ab)x + (b^2 + c^2 + d^2 - 3/4) = 0,
                            //
                            // x = -2ab ± √(4*a^2*b^2 - 4(a^2 + 1)(b^2 + c^2 + d^2 - 3/4))
                            //  —————————————————————————————————————————————————————————— ,
                            //                           2(a^2 + 1)
                            //
                            // x = (-2ab ± √(4*a^2*b^2 - (4a^2 + 4)(b^2 + c^2 + d^2 - 3/4))) / (2a^2 + 2),
                            // x = (-2ab ± √(4*a^2*b^2 - (4a^2*b^2 + 2a^2*c^2 + 4a^2*d^2 - 4a^2*0.75 + 4b^2 + 4c^2 + 4d^2 - 3)) / (2a^2 + 2),
                            // x = (-2ab ± √(4a²b² - (4a²b² + 2a²c² +4a²d² - 3a² + 4b² + 4c² + 4d² - 3)) / (2a² + 2),
                            // x = (-2ab ± √(-2a²c² - 4a²d² + 3a² - 4b² - 4c² - 4d² + 3)) / (2a² + 2).
                            //
                            // a = G1ofX[0]
                            // b = G1ofX[1]
                            // c = center[0]
                            // d = center[1]
                            //
                            //                 InfiNum ^ 2 + 1 is not the same as (InfiNum ^ 2) + 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                            InfiNum plus = (new InfiNum("-2") * G1ofX[0] * G1ofX[1] + (new InfiNum("-2") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) + new InfiNum("3") * (G1ofX[0] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (center[0] ^ new InfiNum("2")) - new InfiNum("4") * (center[1] ^ new InfiNum("2")) + new InfiNum("3")) & new InfiNum("2")) / (new InfiNum("2") * ((G1ofX[0] ^ new InfiNum("2")) + new InfiNum("1")));
                            InfiNum minus = (new InfiNum("-2") * G1ofX[0] * G1ofX[1] - (new InfiNum("-2") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) + new InfiNum("3") * (G1ofX[0] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (center[0] ^ new InfiNum("2")) - new InfiNum("4") * (center[1] ^ new InfiNum("2")) + new InfiNum("3")) & new InfiNum("2")) / (new InfiNum("2") * ((G1ofX[0] ^ new InfiNum("2")) + new InfiNum("1")));

                            InfiNum[] diff = new InfiNum[2] { new InfiNum(), new InfiNum() };

                            diff[0] = InfiNum.Abs(((new InfiNum("3") & new InfiNum("2")) / new InfiNum("2")) - ((((plus ^ new InfiNum("2")) - new InfiNum("0")) + (((G1ofX[0] * plus + G1ofX[1]) ^ new InfiNum("2")) - new InfiNum("0"))) & new InfiNum("2")));

                            diff[1] = InfiNum.Abs(((new InfiNum("3") & new InfiNum("2")) / new InfiNum("2")) - ((((minus ^ new InfiNum("2")) - new InfiNum("0")) + (((G1ofX[0] * minus + G1ofX[1]) ^ new InfiNum("2")) - new InfiNum("0"))) & new InfiNum("2")));

                            if (diff[0] > diff[1])
                            {
                                pointG1[0] = minus;
                            }

                            else
                            {
                                pointG2[0] = plus;
                            }

                            pointG2[1] = G1ofX[0] * pointG2[0] + G1ofX[1]; //doesnt work because somehow formula doesn't work for 240 degrees

                            // (y of G2 = g1(x of G2)) => y of G2 = G1ofX[0] * x + G1ofX[1]


                            InfiNum[] G2ofX = new InfiNum[2]; // AofG1[0]*x + ?b[1] -- find b
                            InfiNum[] F2ofX = new InfiNum[2]; // AofG1[0]*x + ?b[1] -- find b

                            G2ofX[0] = G1ofX[0].InfiNum_Value;
                            G2ofX[1] = pointG1[1] - (G1ofX[0] * pointG1[0] + G1ofX[1]); // YofG1 - g1(XofG1)

                            F2ofX[0] = F1ofX[0].InfiNum_Value;
                            F2ofX[1] = pointG2[1] - (F1ofX[0] * pointG2[0] + F1ofX[1]);// YofG2 - f1(XofG2)

                            //  intersection of G2ofX and F2ofX is S3(S)
                            //  so we slove {y = G2ofX,
                            //              {y = F2ofX;
                            //
                            //              {y = ax + b,
                            //              {y = cx + d;
                            //
                            //              {y = ax + b,
                            //              {ax + b = cx + d;
                            //
                            //              {y = ax + b,
                            //              {(a - c)x = d - b;
                            //
                            //              {y = ax + b,
                            //              {x = (d - b) / (a - c);
                            //
                            //              {x = (d - b) / (a - c),
                            //              {y = a((d - b) / (a - c)) + b.

                            S[0] = (F2ofX[1] - G2ofX[1]) / (G2ofX[0] - F2ofX[0]);
                            S[1] = G2ofX[0] * S[0] + G2ofX[1];

                            A[0] = S[0].InfiNum_Value;
                            A[1] = S[1].InfiNum_Value;
                        }
                    }

                    if (angle - InfiNum.Floor(temp) * new InfiNum("-60") != angle)
                    {
                        InfiNum currentangle = InfiNum.Floor(temp) * new InfiNum("-60");
                        InfiNum angle_change = new InfiNum("-45");

                        // Iterating by finding half angles

                        // x of C(n) = (R * OT(n)) / OE(n)); y of C(n) = (x of C(n) * y of E(n)) / x of E(n).

                        InfiNum[] temp_A = new InfiNum[2] { A[0].InfiNum_Value, A[1].InfiNum_Value };
                        InfiNum[] C = new InfiNum[2] { center[0] - (center[1] - temp_A[1]), center[1] + (center[0] - temp_A[0]) }; // -90 degrees

                        for (int i = 0; InfiNum.Abs(angle - currentangle) > new InfiNum("0.0000000001"); i++)
                        {
                            //Console.WriteLine(currentangle.Value);
                            // Finding half angle

                            InfiNum[] temp_C = new InfiNum[2];

                            InfiNum[] E_n = new InfiNum[2] { (temp_A[0] + C[0]) / new InfiNum("2"), (temp_A[1] + C[1]) / new InfiNum("2") };
                            InfiNum[] T_n = new InfiNum[2] { E_n[0], new InfiNum("0") };

                            InfiNum OE_n = (((center[0] - E_n[0]) ^ new InfiNum("2")) + ((center[1] - E_n[1]) ^ new InfiNum("2"))) & new InfiNum("2");
                            InfiNum OT_n = (((center[0] - T_n[0]) ^ new InfiNum("2")) + ((center[1] - T_n[1]) ^ new InfiNum("2"))) & new InfiNum("2");

                            temp_C[0] = (new InfiNum("1")/*radius*/ * OT_n) / OE_n;
                            temp_C[1] = (temp_C[0] * E_n[1]) / E_n[0];

                            currentangle = currentangle + angle_change;
                            angle_change = InfiNum.Abs(angle_change) / new InfiNum("2");

                            if (currentangle < angle)
                            {
                                C = new InfiNum[2] { temp_C[0].InfiNum_Value, temp_C[1].InfiNum_Value };
                            }

                            if (currentangle > angle)
                            {
                                A = new InfiNum[2] { C[0].InfiNum_Value, C[1].InfiNum_Value };
                                C = new InfiNum[2] { temp_C[0].InfiNum_Value, temp_C[1].InfiNum_Value };
                                angle_change = -angle_change;
                            }
                        }

                        int gjfg = 0;
                    }

                    newposition[0] = A[0];
                    newposition[1] = A[1];
                }

                if (angle.Value == "-60") // complete
                {
                    // -90 degrees is center[0] - (center[1] - currentposition[1]), center[1] + (center[0] - currentposition[0])
                    // 90 degrees is center[0] + (center[1] - currentposition[1]), center[1] - (center[0] - currentposition[0])

                    InfiNum[] deg90 = new InfiNum[2] { center[0] - (center[1] - currentposition[1]), center[1] + (center[0] - currentposition[0]) }; // -90 degrees

                    /*OS1*/
                    InfiNum[] F1ofX = new InfiNum[2] /* slope, y - slope*x */ { (currentposition[1] - center[1]) / (currentposition[0] - center[0]), currentposition[1] - (currentposition[1] - center[1]) / (currentposition[0] - center[0]) * currentposition[0] }; //a[0]x + b[1] -- f(x) = OS1 (center-currentposition)
                    /*OS2*/
                    InfiNum[] G1ofX = new InfiNum[2] { (deg90[1] - center[1]) / (deg90[0] - center[0]), deg90[1] - (deg90[1] - center[1]) / (deg90[0] - center[0]) * deg90[0] }; //a[0]x + b[1] -- y on OS2 (center-deg90)

                    /*OG1 = 0.5*/
                    InfiNum[] pointG1 = new InfiNum[2] { (currentposition[0] + center[0]) / new InfiNum("2"), (currentposition[1] + center[1]) / new InfiNum("2") }; //point G1 is on F1ofX and G2ofX

                    InfiNum[] pointG2 = new InfiNum[2]; //point G2 is on G1ofX and on F2ofX

                    //-----------------finding x of G2-------------------

                    //OG2 = sqr(3)/2;
                    // OG2^2 = (XofG2 - XofCenter)^2 + (YofG2 - YofCenter)^2,  //// NO INTERVAALSASASLALSALSLASLALSLASLALSALSALSLALSALSLALSAL
                    // (XofG2 - XofCenter)^2 + (YofG2 - YofCenter)^2 = 3/4, -- let XofG2 be x, XofCenter be c, YofCenter be d, YofG2 is g(XofG2)
                    // (x - c)^2 + (G2ofX - d)^2 = 3/4, let G2ofX be ax + b
                    // x^2 - 2xc + c^2 + (ax + b)^2  2(ax + b)d + d^2 = 3/4,
                    // x^2 - 2xc + a^2*x^2 + 2abx + b^2 + c^2 + d^2 = 3/4,
                    // (a^2 + 1)x^2 + (2ab)x + (b^2 + c^2 + d^2 - 3/4) = 0,
                    //
                    // x = -2ab ± √(4*a^2*b^2 - 4(a^2 + 1)(b^2 + c^2 + d^2 - 3/4))
                    //  —————————————————————————————————————————————————————————— ,
                    //                           2(a^2 + 1)
                    //
                    // x = (-2ab ± √(4*a^2*b^2 - (4a^2 + 4)(b^2 + c^2 + d^2 - 3/4))) / (2a^2 + 2),
                    // x = (-2ab ± √(4*a^2*b^2 - (4a^2*b^2 + 2a^2*c^2 + 4a^2*d^2 - 4a^2*0.75 + 4b^2 + 4c^2 + 4d^2 - 3)) / (2a^2 + 2),
                    // x = (-2ab ± √(4a²b² - (4a²b² + 2a²c² +4a²d² - 3a² + 4b² + 4c² + 4d² - 3)) / (2a² + 2),
                    // x = (-2ab ± √(-2a²c² - 4a²d² + 3a² - 4b² - 4c² - 4d² + 3)) / (2a² + 2).

                    //  or, if you're dumb, with intervals:


                    // ALL WRONG:


                    // (|x| - |c|)^2 + (|ax + b| - |d|)^2 = 3/4, -- solve for x

                    // Let the madness begin.

                    // x^2 - 2*|x|*|c| + c^2 + (ax + b)^2 - 2*|ax + b|*d + d^2 = 3/4,
                    // x^2 - 2*|x|*|c| + c^2 + a^2*x^2 + 2abx + b^2 - 2*|ax + b|*d + d^2 = 3/4,
                    // (a^2 + 1)x^2 - 2|x||c| - 2|ax+b||d| + 2abx + b^2 + c^2 + d^2 = 3/4,
                    // (a^2 + 1)x^2 - 2|c||x| - 2|d||ax+b| + 2abx + b^2 + c^2 + d^2 = 3/4,

                    // Now we distribute the modulus.

                    // x = 0
                    // ax + b = 0, x = -b/a
                    // 
                    // 2 sets of solutions:
                    // if -b/a < 0
                    // or if -b/a > 0
                    //
                    //
                    // 1st set:
                    //
                    //
                    // ------|----|+++++++++
                    // ──────|────0────────>   x = 0
                    // ------|++++|+++++++++
                    // ────-b/a───|────────>   x = -b/a
                    //       |    |
                    //
                    //
                    // 2nd set:
                    //
                    // ------|+++++++|+++++++
                    // ──────0──────────────>   x = 0
                    // ------|-------|+++++++
                    // ──────|─────-b/a─────>   x = -b/a
                    //       |       |
                    // 
                    // 
                    // 4 possible intervals: 
                    //
                    //          (-, -);               (-, +);           (+, -);              (+, +);
                    //       in both cases         when -b/a < 0    when -b/a  > 0        in both cases
                    //   (-∞; 0) or (-∞; -b/a)       (-b/a; 0)         (0; -b/a)      (0; +∞) or (-b/a; +∞)
                    // 
                    // ══════
                    // ║  
                    // ║  x = (a^2 + 1)x^2 - 2|c|(-(x)) - 2|d|(-(ax+b)) + 2abx + b^2 + c^2 + d^2 = 3/4, (-, -)
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 - 2|c|(-(x)) - 2|d|(+(ax+b)) + 2abx + b^2 + c^2 + d^2 = 3/4, (-, +)
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 - 2|c|(+(x)) - 2|d|(-(ax+b)) + 2abx + b^2 + c^2 + d^2 = 3/4, (+, -)
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 - 2|c|(+(x)) - 2|d|(+(ax+b)) + 2abx + b^2 + c^2 + d^2 = 3/4; (+, +)
                    // ║  
                    // ══════
                    //
                    //
                    // ══════
                    // ║  
                    // ║  x = (a^2 + 1)x^2 + 2|c|*x - 2|d|(-ax-b) + 2abx + b^2 + c^2 + d^2 = 3/4,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 + 2|c|*x - 2|d|(ax+b) + 2abx + b^2 + c^2 + d^2 = 3/4,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 - 2|c|*x - 2|d|(-ax-b) + 2abx + b^2 + c^2 + d^2 = 3/4,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 - 2|c|*x - 2|d|(ax+b) + 2abx + b^2 + c^2 + d^2 = 3/4;
                    // ║  
                    // ══════
                    //
                    //
                    // ══════
                    // ║  
                    // ║  x = (a^2 + 1)x^2 + 2|c|x + 2a|d|x + 2b|d| + 2abx + b^2 + c^2 + d^2 = 3/4,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 + 2|c|x - 2a|d|x - 2b|d| + 2abx + b^2 + c^2 + d^2 = 3/4,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 - 2|c|x + 2a|d|x + 2b|d| + 2abx + b^2 + c^2 + d^2 = 3/4,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 - 2|c|x - 2a|d|x - 2b|d| + 2abx + b^2 + c^2 + d^2 = 3/4;
                    // ║  
                    // ══════
                    // 
                    // 
                    // ══════
                    // ║  
                    // ║  x = (a^2 + 1)x^2 + (2|c| + 2a|d| + 2ab)x + (2b|d| + b^2 + c^2 + d^2 - 3/4) = 0,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 + (2|c| - 2a|d| + 2ab)x + (-2b|d| + b^2 + c^2 + d^2 - 3/4) = 0,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 + (-2|c| + 2a|d| + 2ab)x + (2b|d| + b^2 + c^2 + d^2 - 3/4) = 0,
                    // ║  
                    // ║  
                    // ║  x = (a^2 + 1)x^2 + (-2|c| - 2a|d| + 2ab)x + (-2b|d| + b^2 + c^2 + d^2 - 3/4) = 0;
                    // ║  
                    // ══════
                    //
                    // Apply quadratic formula
                    //
                    // ══════
                    // ║  
                    // ║  x = -(2|c| + 2a|d| + 2ab) ± √((2|c| + 2a|d| + 2ab)^2 - 4*(a^2 + 1)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ———————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2(a^2 + 1)
                    // ║  
                    // ║  
                    // ║  x = -(2|c| - 2a|d| + 2ab) ± √((2|c| - 2a|d| + 2ab)^2 - 4*(a^2 + 1)*(-2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2(a^2 + 1)
                    // ║  
                    // ║  
                    // ║  x = -(-2|c| + 2a|d| + 2ab) ± √((-2|c| + 2a|d| + 2ab)^2 - 4*(a^2 + 1)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      —————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2(a^2 + 1)
                    // ║  
                    // ║  
                    // ║  x = -(-2|c| - 2a|d| + 2ab) ± √((-2|c| - 2a|d| + 2ab)^2 - 4*(a^2 + 1)*(-2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————— ;
                    // ║                                                 2(a^2 + 1)
                    // ║  
                    // ══════
                    //
                    //
                    // ══════
                    // ║  
                    // ║  x = -2|c| - 2a|d| - 2ab ± √(4*c^2 + 4a|c||d| + 4ab|c| + 4a|c||d| + 4*a^2*d^2 + 4*a^2*b|d| + 4ab|c| + 4*a^2*|d| + 4*a^2*b^2 - (4*a^2 + 4)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = -2|c| + 2a|d| - 2ab ± √(4*c^2 - 4a|c||d| + 4ab|c| - 4a|c||d| + 4*a^2*d^2 - 4*a^2*b|d| + 4ab|c| - 4*a^2*|d| + 4*a^2*b^2 - (4*a^2 + 4)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = 2|c| - 2a|d| - 2ab ± √(4*c^2 - 4a|c||d| - 4ab|c| - 4a|c||d| + 4*a^2*d^2 + 4*a^2*b|d| - 4ab|c| + 4*a^2*|d| + 4*a^2*b^2 - (4*a^2 + 4)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = 2|c| + 2a|d| - 2ab ± √(4*c^2 + 4a|c||d| - 4ab|c| + 4a|c||d| + 4*a^2*d^2 - 4*a^2*b|d| - 4ab|c| - 4*a^2*|d| + 4*a^2*b^2 - (4*a^2 + 4)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ;
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ══════
                    //
                    //
                    // ══════
                    // ║  
                    // ║  x = -2|c| - 2a|d| - 2ab ± √(4c^2 + 8 a|c||d| + 8ab|c| + 4a^2*d^2 + 8a^2*b|d| + 4a^2*b^2 - (4*a^2 + 4)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = -2|c| + 2a|d| - 2ab ± √(4c^2 - 8 a|c||d| + 8ab|c| + 4a^2*d^2 - 8a^2*b|d| + 4a^2*b^2 - (4*a^2 + 4)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = 2|c| - 2a|d| - 2ab ± √(4c^2 - 8 a|c||d| - 8ab|c| + 4a^2*d^2 + 8a^2*b|d| + 4a^2*b^2 - (4*a^2 + 4)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = 2|c| + 2a|d| - 2ab ± √(4c^2 + 8 a|c||d| - 8ab|c| + 4a^2*d^2 - 8a^2*b|d| + 4a^2*b^2 - (4*a^2 + 4)*(2b|d| + b^2 + c^2 + d^2 - 3/4))
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ;
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ══════
                    //
                    //
                    // ══════
                    // ║  
                    // ║  x = -2|c| - 2a|d| - 2ab ± √(4c^2 + 8 a|c||d| + 8ab|c| + 4a^2*d^2 + 8a^2*b|d| + 4a^2*b^2 - 4a^2*c^2 - 4*a^2*d^2 + 3a^2 - 8b|d| - 4b^2 - 4c^2 - 4d^2 + 3)
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = -2|c| + 2a|d| - 2ab ± √(4c^2 - 8 a|c||d| + 8ab|c| + 4a^2*d^2 - 8a^2*b|d| + 4a^2*b^2 - 4a^2*c^2 - 4*a^2*d^2 + 3a^2 + 8b|d| - 4b^2 - 4c^2 - 4d^2 + 3)
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = 2|c| - 2a|d| - 2ab ± √(4c^2 - 8 a|c||d| - 8ab|c| + 4a^2*d^2 + 8a^2*b|d| + 4a^2*b^2 - 4a^2*c^2 - 4*a^2*d^2 + 3a^2 - 8b|d| - 4b^2 - 4c^2 - 4d^2 + 3)
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = 2|c| + 2a|d| - 2ab ± √(4c^2 + 8 a|c||d| - 8ab|c| + 4a^2*d^2 - 8a^2*b|d| + 4a^2*b^2 - 4a^2*c^2 - 4*a^2*d^2 + 3a^2 + 8b|d| - 4b^2 - 4c^2 - 4d^2 + 3)
                    // ║      ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— ;
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ══════
                    //
                    //
                    // ══════
                    // ║  
                    // ║  x = -2|c| - 2a|d| - 2ab ± √(8a|c||d| + 8ab|c| - 4a^2*c^2 + 3a^2 - 8b|d| - 4b^2 - 4d^2 + 3)
                    // ║      —————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = -2|c| + 2a|d| - 2ab ± √(-8a|c||d| - 8ab|c| - 4a^2*c^2 + 3a^2 + 8b|d| - 4b^2 - 4d^2 + 3)
                    // ║      —————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = 2|c| - 2a|d| - 2ab ± √(-8a|c||d| - 8ab|c| - 4a^2*c^2 + 3a^2 - 8b|d| - 4b^2 - 4d^2 + 3)
                    // ║      —————————————————————————————————————————————————————————————————————————————————————— ,
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ║  
                    // ║  x = 2|c| + 2a|d| - 2ab ± √(8a|c||d| - 8ab|c| - 4a^2*c^2 + 3a^2 + 8b|d| - 4b^2 - 4d^2 + 3)
                    // ║      ————————————————————————————————————————————————————————————————————————————————————— ;
                    // ║                                                 2a^2 + 2
                    // ║  
                    // ══════
                    //
                    // Rewrite
                    //
                    // ══════
                    // ║  
                    // ║  x = (-2|c| - 2a|d| - 2ab ± √(-4a²c² + 8a|c||d| + 8ab|c| - 8b|d| + 3a² - 4b² - 4d² + 3)) / (a² + 1),   (-, -)
                    // ║  
                    // ║  
                    // ║  x = (-2|c| + 2a|d| - 2ab ± √(-4a²c² - 8a|c||d| - 8ab|c| + 8b|d| + 3a² - 4b² - 4d² + 3)) / (a² + 1),   (-, +)
                    // ║  
                    // ║  
                    // ║  x = (2|c| - 2a|d| - 2ab ± √(-4a²c² - 8a|c||d| + 8ab|c| - 8b|d| + 3a² - 4b² - 4d² + 3)) / (a² + 1),    (+, -)
                    // ║  
                    // ║  
                    // ║  x = (2|c| + 2a|d| - 2ab ± √(-4a²c² + 8a|c||d| - 8ab|c| + 8b|d| + 3a² - 4b² - 4d² + 3)) / (a² + 1).    (-, -)
                    // ║  
                    // ══════ (all wrong)
                    //
                    // x = (-2ab ± √(-2a²c² - 4a²d² + 3a² - 4b² - 4c² - 4d² + 3)) / (2a² + 2).
                    //
                    // a = G1ofX[0]
                    // b = G1ofX[1]
                    // c = center[0]
                    // d = center[1]
                    //
                    //                 InfiNum ^ 2 + 1 is not the same as (InfiNum ^ 2) + 1 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                    if (deg90[0] > center[0]) // finding the interval G2 is located on
                    {
                        // separating ±

                        InfiNum plus = (new InfiNum("-2") * G1ofX[0] * G1ofX[1] + (new InfiNum("-2") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) + new InfiNum("3") * (G1ofX[0] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (center[0] ^ new InfiNum("2")) - new InfiNum("4") * (center[1] ^ new InfiNum("2")) + new InfiNum("3")) & new InfiNum("2")) / (new InfiNum("2") * ((G1ofX[0] ^ new InfiNum("2")) + new InfiNum("1")));
                        InfiNum minus = (new InfiNum("-2") * G1ofX[0] * G1ofX[1] - (new InfiNum("-2") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) + new InfiNum("3") * (G1ofX[0] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (center[0] ^ new InfiNum("2")) - new InfiNum("4") * (center[1] ^ new InfiNum("2")) + new InfiNum("3")) & new InfiNum("2")) / (new InfiNum("2") * ((G1ofX[0] ^ new InfiNum("2")) + new InfiNum("1")));

                        if (plus < deg90[0] && plus > center[0])
                        {
                            pointG2[0] = plus;
                        }

                        if (minus < deg90[0] && minus > center[0])
                        {
                            pointG2[0] = minus;
                        }
                    }

                    else
                    {
                        // separating ±
                        InfiNum plus = (new InfiNum("-2") * G1ofX[0] * G1ofX[1] + (new InfiNum("-2") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) + new InfiNum("3") * (G1ofX[0] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (center[0] ^ new InfiNum("2")) - new InfiNum("4") * (center[1] ^ new InfiNum("2")) + new InfiNum("3")) & new InfiNum("2")) / (new InfiNum("2") * ((G1ofX[0] ^ new InfiNum("2")) + new InfiNum("1")));
                        InfiNum minus = (new InfiNum("-2") * G1ofX[0] * G1ofX[1] - (new InfiNum("-2") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[0] ^ new InfiNum("2")) * (G1ofX[1] ^ new InfiNum("2")) + new InfiNum("3") * (G1ofX[0] ^ new InfiNum("2")) - new InfiNum("4") * (G1ofX[1] ^ new InfiNum("2")) - new InfiNum("4") * (center[0] ^ new InfiNum("2")) - new InfiNum("4") * (center[1] ^ new InfiNum("2")) + new InfiNum("3")) & new InfiNum("2")) / (new InfiNum("2") * ((G1ofX[0] ^ new InfiNum("2")) + new InfiNum("1")));

                        if (plus > deg90[0] && plus < center[0])
                        {
                            pointG2[0] = plus;
                        }

                        if (minus > deg90[0] && minus < center[0])
                        {
                            pointG2[0] = minus;
                        }
                    }

                    // (y of G2 = g1(x of G2)) => y of G2 = G1ofX[0] * x + G1ofX[1]
                    pointG2[1] = G1ofX[0] * pointG2[0] + G1ofX[1]; //doesnt work because somehow formula doesn't work for 240 degrees

                    InfiNum[] G2ofX = new InfiNum[2]; // AofG1[0]*x + ?b[1] -- find b
                    InfiNum[] F2ofX = new InfiNum[2]; // AofG1[0]*x + ?b[1] -- find b

                    G2ofX[0] = G1ofX[0];
                    G2ofX[1] = pointG1[1] - (G1ofX[0] * pointG1[0] + G1ofX[1]); // YofG1 - g1(XofG1)

                    F2ofX[0] = F1ofX[0];
                    F2ofX[1] = pointG2[1] - (F1ofX[0] * pointG2[0] + F1ofX[1]);// YofG2 - f1(XofG2)

                    //  intersection of G2ofX and F2ofX is S3(newposition)
                    //  so we slove {y = G2ofX,
                    //              {y = F2ofX;
                    //
                    //              {y = ax + b,
                    //              {y = cx + d;
                    //
                    //              {y = ax + b,
                    //              {ax + b = cx + d;
                    //
                    //              {y = ax + b,
                    //              {(a - c)x = d - b;
                    //
                    //              {y = ax + b,
                    //              {x = (d - b) / (a - c);
                    //
                    //              {x = (d - b) / (a - c),
                    //              {y = a((d - b) / (a - c)) + b.

                    newposition[0] = (F2ofX[1] - G2ofX[1]) / (G2ofX[0] - F2ofX[0]);
                    newposition[1] = G2ofX[0] * newposition[0] + G2ofX[1];

                    int ghrhg = 0;
                }
            }

            else
            {
                if (angle.Value == "-60")
                {
                    if (center[0] == currentposition[0])
                    {
                        //OT = x(S)
                        //TS = y(S)

                        //(OS = 1) => (TS = 0.5) =>
                        //(OS^2 = OT^2 + TS^2) => (OT^2 = 1 - 1/4) => (OT = √(3)/2)

                        if (currentposition[1] > center[1])
                        {
                            newposition[0] = center[0] + (new InfiNum("3") & new InfiNum("2")) / new InfiNum("2");
                            newposition[1] = center[1] + new InfiNum("0.5");
                        }

                        if (currentposition[1] < center[1])
                        {
                            newposition[0] = center[0] - (new InfiNum("3") & new InfiNum("2")) / new InfiNum("2");
                            newposition[1] = center[1] - new InfiNum("0.5");
                        }
                    }

                    if (center[1] == currentposition[1])
                    {
                        //OT = x(S)
                        //TS = y(S)

                        //(OS = 1) => (OT = 0.5) =>
                        //(OS^2 = OT^2 + TS^2) => (TS^2 = 1 - 1/4) => (TS = √(3)/2)

                        if (currentposition[0] > center[0])
                        {
                            newposition[0] = center[0] + new InfiNum("0.5");
                            newposition[1] = center[1] - (new InfiNum("3") & new InfiNum("2")) / new InfiNum("2");
                        }

                        if (currentposition[0] < center[0])
                        {
                            newposition[0] = center[0] - new InfiNum("0.5");
                            newposition[1] = center[1] + (new InfiNum("3") & new InfiNum("2")) / new InfiNum("2");
                        }
                    }
                }
            }
        }

        public static void GetDegreeAngle(InfiNum[] p1, InfiNum[] center, InfiNum[] p2, out InfiNum angle) // uses iteration of previous method
        {
            angle = new InfiNum();

            p1[0] = p1[0] - center[0];
            p1[1] = p1[1] - center[1];

            p2[0] = p2[0] - center[0];
            p2[1] = p2[1] - center[1];

            center[0] = center[0] - center[0];
            center[1] = center[1] - center[1];

            InfiNum radius = ((((p1[0] - center[0]) ^ InfiNum.num(2)) + ((p1[1] - center[1]) ^ InfiNum.num(2))) & InfiNum.num(2));

            if (radius > InfiNum.num(1))
            {
                p1[0] = p1[0] / radius;
                p1[1] = p1[1] / radius;

                p2[0] = p2[0] / radius;
                p2[1] = p2[1] / radius;
            }

            // we now know the cosine and sine of each of the two angles of which our angle consists of, so now we find it

            InfiNum angle1 = new InfiNum();
            InfiNum angle2 = new InfiNum();

            InfiNum angle1_min = new InfiNum("180");
            InfiNum angle1_max = new InfiNum("-180");

            InfiNum v1 = new InfiNum("0"); // first approximation

            InfiNum angle2_min = new InfiNum("180");
            InfiNum angle2_max = new InfiNum("-180");

            InfiNum v2 = new InfiNum("0"); // first approximation

            GetCosSin(v1, new InfiNum[2] { new InfiNum(), new InfiNum() }, new InfiNum[2] { new InfiNum("1"), new InfiNum("0") }, out InfiNum[] t1);
            GetCosSin(v2, new InfiNum[2] { new InfiNum(), new InfiNum() }, new InfiNum[2] { new InfiNum("1"), new InfiNum("0") }, out InfiNum[] t2);

            if (p1[0] == InfiNum.num(0) && p1[1] == InfiNum.num(1))
            {
                angle1.Value = "90";
            }

            else if (p1[0] == InfiNum.num(0) && p1[1] == InfiNum.num(-1))
            {
                angle1.Value = "-90";
            }

            else if (p1[0] == InfiNum.num(1) && p1[1] == InfiNum.num(0))
            {
                angle1.Value = "0";
            }

            else if (p1[0] == InfiNum.num(-1) && p1[1] == InfiNum.num(0))
            {
                angle1.Value = "180";
            }

            else
            {

                for (; ; ) // angle1
                {
                    GetCosSin((angle1_min + angle1_max) / InfiNum.num(2), new InfiNum[2] { new InfiNum(), new InfiNum() }, new InfiNum[2] { new InfiNum("1"), new InfiNum("0") }, out InfiNum[] h1);

                    t1 = h1;

                    if ((InfiNum.Abs(t1[0] - p1[0]) <= new InfiNum("0." + zeroAFTp2 + "1") || InfiNum.Abs(t1[1] - p1[1]) <= new InfiNum("0." + zeroAFTp2 + "1")) || InfiNum.Abs(angle1_max - angle1_min) <= new InfiNum("0." + zeroAFTp2 + "1"))
                    {
                        break;
                    }

                    if (t1[0] < p1[0] && t1[1] > p1[1])
                    {
                        angle1_min = (angle1_min + angle1_max) / InfiNum.num(2);
                    }

                    if (t1[0] < p1[0] && t1[1] < p1[1])
                    {
                        angle1_max = (angle1_min + angle1_max) / InfiNum.num(2);
                    }

                    if (t1[0] > p1[0] && t1[1] > p1[1])
                    {
                        angle1_min = (angle1_min + angle1_max) / InfiNum.num(2); // wrong logic
                    }

                    if (t1[0] > p1[0] && t1[1] < p1[1])
                    {
                        angle1_max = (angle1_min + angle1_max) / InfiNum.num(2); // wrong logic
                    }
                }

                angle1 = (angle1_min + angle1_max) / InfiNum.num(2);
            }

            // angle2

            if (p2[0] == InfiNum.num(0) && p2[1] == InfiNum.num(1))
            {
                angle2.Value = "90";
            }

            else if (p2[0] == InfiNum.num(0) && p2[1] == InfiNum.num(-1))
            {
                angle2.Value = "-90";
            }

            else if (p2[0] == InfiNum.num(1) && p2[1] == InfiNum.num(0))
            {
                angle2.Value = "0";
            }

            else if (p2[0] == InfiNum.num(-1) && p2[1] == InfiNum.num(0))
            {
                angle2.Value = "180";
            }

            else
            {

                for (; ; ) // angle2
                {
                    GetCosSin((angle2_min + angle2_max) / InfiNum.num(2), new InfiNum[2] { new InfiNum(), new InfiNum() }, new InfiNum[2] { new InfiNum("1"), new InfiNum("0") }, out InfiNum[] h2);

                    t2 = h2;

                    if ((InfiNum.Abs(t2[0] - p2[0]) <= new InfiNum("0." + zeroAFTp2 + "1") || InfiNum.Abs(t2[1] - p2[1]) <= new InfiNum("0." + zeroAFTp2 + "1")) || InfiNum.Abs(angle2_max - angle2_min) <= new InfiNum("0." + zeroAFTp2 + "1"))
                    {
                        break;
                    }

                    if (t2[0] < p2[0] && t2[1] > p2[1])
                    {
                        angle2_min = (angle2_min + angle2_max) / InfiNum.num(2);
                    }

                    if (t2[0] < p2[0] && t2[1] < p2[1])
                    {
                        angle2_max = (angle2_min + angle2_max) / InfiNum.num(2);
                    }

                    if (t2[0] > p2[0] && t2[1] > p2[1])
                    {
                        angle2_min = (angle2_min + angle2_max) / InfiNum.num(2); // wrong logic
                    }

                    if (t2[0] > p2[0] && t2[1] < p2[1])
                    {
                        angle2_max = (angle2_min + angle2_max) / InfiNum.num(2); // wrong logic
                    }
                }

                angle2 = (angle2_min + angle2_max) / InfiNum.num(2);
            }

            angle = InfiNum.Abs(angle1 - angle2); // WOOOOOOOOOOOOOOOORKING
        }
    }
}
