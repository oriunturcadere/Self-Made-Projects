using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace My_paint
{
    interface Circle
    {
        //public static void DrawCircle(InfiNum[] O, InfiNum rad, Bitmap bmp, out Bitmap bmp2, out object[] points)
        //{
        //    bmp2 = bmp;

        //    InfiNum[] p1 = new InfiNum[2];
        //    InfiNum[] p1_1 = new InfiNum[2];

        //    InfiNum[] p2 = new InfiNum[2];

        //    InfiNum[] p3 = new InfiNum[2];
        //    InfiNum[] p3_1 = new InfiNum[2];

        //    InfiNum[] p4 = new InfiNum[2];

        //    InfiNum[] p5 = new InfiNum[2];
        //    InfiNum[] p5_1 = new InfiNum[2];

        //    InfiNum[] p6 = new InfiNum[2];

        //    InfiNum[] p7 = new InfiNum[2];
        //    InfiNum[] p7_1 = new InfiNum[2];

        //    InfiNum[] p8 = new InfiNum[2];

        //    p1[0] = new InfiNum(O[0].Value);
        //    p1[1] = new InfiNum(O[1].Subtract(rad.Value));

            
        //    p2[0] = new InfiNum(O[0].Add(rad.Value));
        //    p2[1] = new InfiNum(O[1].Subtract(rad.Value));

            
        //    p3[0] = new InfiNum(O[0].Add(rad.Value));
        //    p3[1] = new InfiNum(O[1].Value);

            
        //    p4[0] = new InfiNum(O[0].Add(rad.Value));
        //    p4[1] = new InfiNum(O[1].Add(rad.Value));

            
        //    p5[0] = new InfiNum(O[0].Value);
        //    p5[1] = new InfiNum(O[1].Add(rad.Value));

            
        //    p6[0] = new InfiNum(O[0].Subtract(rad.Value));
        //    p6[1] = new InfiNum(O[1].Add(rad.Value));

            
        //    p7[0] = new InfiNum(O[0].Subtract(rad.Value));
        //    p7[1] = new InfiNum(O[1].Value);

            
        //    p8[0] = new InfiNum(O[0].Subtract(rad.Value));
        //    p8[1] = new InfiNum(O[1].Subtract(rad.Value));

        //    points = new object[8];
        //    object[] cor = new object[8];
            
        //    cor[0] = new string[2] { p1[0].Value + " " + p1[1].Value, p2[0].Value + " " + p2[1].Value };    //  2.0
        //    cor[1] = new string[2] { p2[0].Value + " " + p2[1].Value, p3[0].Value + " " + p3[1].Value };
        //    cor[2] = new string[2] { p3[0].Value + " " + p3[1].Value, p4[0].Value + " " + p4[1].Value };
        //    cor[3] = new string[2] { p4[0].Value + " " + p4[1].Value, p5[0].Value + " " + p5[1].Value };
        //    cor[4] = new string[2] { p5[0].Value + " " + p5[1].Value, p6[0].Value + " " + p6[1].Value };
        //    cor[5] = new string[2] { p6[0].Value + " " + p6[1].Value, p7[0].Value + " " + p7[1].Value };
        //    cor[6] = new string[2] { p7[0].Value + " " + p7[1].Value, p8[0].Value + " " + p8[1].Value };
        //    cor[7] = new string[2] { p8[0].Value + " " + p8[1].Value, p1[0].Value + " " + p1[1].Value };

        //    for (int i = 0; i < 8; i = i + 2)
        //    {
        //        string[] tp = ((string[])(cor[i]))[1].Split();

        //        InfiNum left = new InfiNum(O[0].Value);
        //        InfiNum lefty = new InfiNum(O[1].Value);

        //        InfiNum right = new InfiNum(tp[0]);
        //        InfiNum righty = new InfiNum(tp[1]);

        //        InfiNum X = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));
        //        InfiNum prevX = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));//the variable that stores the previous value of the X

        //        InfiNum Y = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));
        //        InfiNum prevY = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));//the variable that stores the previous value of the Y

        //        InfiNum sqr = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(O[0].Value, X.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(O[1].Value, Y.Value)), "2")), "2"));
        //        InfiNum fsqr = new InfiNum(sqr.Value);

        //        InfiNum[] finalp = new InfiNum[2];  // the current shortest distance
        //        finalp[0] = new InfiNum(X.Value);
        //        finalp[1] = new InfiNum(Y.Value);

        //        //            ________________________---------------------___________________

        //        fsqr.Value = sqr.Value;
        //        X.Value = InfiNum.Subtract(X.Value, InfiNum.Divide(InfiNum.Subtract(X.Value, left.Value), "2"));  // the new point , move the x coordinate to the left

        //        Y.Value = InfiNum.Subtract(Y.Value, InfiNum.Divide(InfiNum.Subtract(Y.Value, lefty.Value), "2")); ; // the new point

        //        //
        //        //  3rd part
        //        //
        //        //

        //        //InfiNum old = 0;//the  distance to the previous point on the oposite line segment
        //        //InfiNum newpoint = 0;//to the new point after we have made a step

        //        do
        //        {
        //            sqr.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(O[0].Value, X.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(O[1].Value, Y.Value)), "2")), "2");

        //            if (sqr.Greater(rad.Value))
        //            {
        //                right.Value = X.Value;
        //                X.Value = InfiNum.Subtract(right.Value, InfiNum.Divide(InfiNum.Subtract(right.Value, left.Value), "2"));

        //                righty.Value = Y.Value;
        //                Y.Value = InfiNum.Subtract(righty.Value, InfiNum.Divide(InfiNum.Subtract(righty.Value, lefty.Value), "2"));

        //                finalp[0].Value = X.Value;
        //                finalp[1].Value = Y.Value;
        //            }

        //            if (sqr.Smaller(rad.Value))
        //            {
        //                left.Value = X.Value;  // set up the left border as the x coordinate of the current (new) point
        //                X.Value = InfiNum.Subtract(right.Value, InfiNum.Divide(InfiNum.Subtract(right.Value, left.Value), "2"));

        //                lefty.Value = Y.Value;
        //                Y.Value = InfiNum.Subtract(righty.Value, InfiNum.Divide(InfiNum.Subtract(righty.Value, lefty.Value), "2"));

        //                finalp[0].Value = X.Value;
        //                finalp[1].Value = Y.Value;
        //            }

        //            if (sqr.Equals(rad.Value))
        //            {
        //                break;
        //            }
        //        }/*the end of the loop*/
        //        while (InfiNum.Greater(right.Subtract(left.Value), "0.0000000000000000000000000000000000000000000000000000000000001"));

        //        int sh = 0;
        //    }

        //    points[0] = new string[2] { p1[0].Value + " " + p1[1].Value, InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[0].Add(p3[0].Value), "2"), p2[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[1].Add(p3[1].Value), "2"), p2[1].Value), "2") };
        //    points[1] = new string[2] { InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[0].Add(p3[0].Value), "2"), p2[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[1].Add(p3[1].Value), "2"), p2[1].Value), "2"), p3[0].Value + " " + p3[1].Value};
        //    points[2] = new string[2] { p3[0].Value + " " + p3[1].Value, InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p3[0].Add(p5[0].Value), "2"), p4[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p3[1].Add(p5[1].Value), "2"), p4[1].Value), "2") };
        //    points[3] = new string[2] { InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p3[0].Add(p5[0].Value), "2"), p4[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p3[1].Add(p5[1].Value), "2"), p4[1].Value), "2"), p5[0].Value + " " + p5[1].Value };
        //    points[4] = new string[2] { p5[0].Value + " " + p5[1].Value, InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p5[0].Add(p7[0].Value), "2"), p6[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p5[1].Add(p7[1].Value), "2"), p6[1].Value), "2") };
        //    points[5] = new string[2] { InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p5[0].Add(p7[0].Value), "2"), p6[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p5[1].Add(p7[1].Value), "2"), p6[1].Value), "2"), p7[0].Value + " " + p7[1].Value };
        //    points[6] = new string[2] { p7[0].Value + " " + p7[1].Value, InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p7[0].Add(p1[0].Value), "2"), p8[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p7[1].Add(p1[1].Value), "2"), p8[1].Value), "2") };
        //    points[7] = new string[2] { InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p7[0].Add(p1[0].Value), "2"), p8[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p7[1].Add(p1[1].Value), "2"), p8[1].Value), "2"), p1[0].Value + " " + p1[1].Value };

        //    string[] temp = new string[2];

        //    temp[0] = InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[0].Add(p3[0].Value), "2"), p2[0].Value), "2");
        //    temp[1] = InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[1].Add(p3[1].Value), "2"), p2[1].Value), "2");

        //    InfiNum check = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract("49", temp[0])), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract("49", temp[1])), "2")), "2"));

        //    //if (rad.Floor() == rad.Value) /////////////            --------------______________-------------
        //    //{
        //    //    p1_1[0] = new InfiNum(O[0].Value);
        //    //    p1_1[1] = new InfiNum(O[1].Subtract(InfiNum.Subtract(rad.Value, "1")));

        //    //    p1[0] = new InfiNum(InfiNum.Add(O[0].Value, "1"));
        //    //    p1[1] = new InfiNum(O[1].Subtract(InfiNum.Subtract(rad.Value, "1")));

        //    //    p2[0] = new InfiNum(O[0].Add(rad.Value));
        //    //    p2[1] = new InfiNum(O[1].Subtract(InfiNum.Subtract(rad.Value, "1")));

        //    //    p3_1[0] = new InfiNum(O[0].Add(rad.Value));
        //    //    p3_1[1] = new InfiNum(O[1].Value);

        //    //    p3[0] = new InfiNum(O[0].Add(rad.Value));
        //    //    p3[1] = new InfiNum(O[1].Add("1"));

        //    //    p4[0] = new InfiNum(O[0].Add(rad.Value));
        //    //    p4[1] = new InfiNum(O[1].Add(rad.Value));

        //    //    p5[0] = new InfiNum(O[0].Add("1"));
        //    //    p5[1] = new InfiNum(O[1].Add(rad.Value));

        //    //    p5_1[0] = new InfiNum(O[0].Value);
        //    //    p5_1[1] = new InfiNum(O[1].Add(rad.Value));

        //    //    p6[0] = new InfiNum(O[0].Subtract(InfiNum.Subtract(rad.Value, "1")));
        //    //    p6[1] = new InfiNum(O[1].Add(rad.Value));

        //    //    p7_1[0] = new InfiNum(O[0].Subtract(InfiNum.Subtract(rad.Value, "1")));
        //    //    p7_1[1] = new InfiNum(O[1].Value);

        //    //    p7[0] = new InfiNum(O[0].Subtract(InfiNum.Subtract(rad.Value, "1")));
        //    //    p7[1] = new InfiNum(O[1].Add("1"));

        //    //    p8[0] = new InfiNum(O[0].Subtract(InfiNum.Subtract(rad.Value, "1")));
        //    //    p8[1] = new InfiNum(O[1].Subtract(InfiNum.Subtract(rad.Value, "1")));

        //    //    cor[0] = new string[2] { p1[0].Value + " " + p1[1].Value, p2[0].Value + " " + p2[1].Value };
        //    //    cor[1] = new string[2] { p2[0].Value + " " + p2[1].Value, p3_1[0].Value + " " + p3_1[1].Value };
        //    //    cor[2] = new string[2] { p3[0].Value + " " + p3[1].Value, p4[0].Value + " " + p4[1].Value };
        //    //    cor[3] = new string[2] { p4[0].Value + " " + p4[1].Value, p5[0].Value + " " + p5[1].Value };
        //    //    cor[4] = new string[2] { p5_1[0].Value + " " + p5_1[1].Value, p6[0].Value + " " + p6[1].Value };
        //    //    cor[5] = new string[2] { p6[0].Value + " " + p6[1].Value, p7[0].Value + " " + p7[1].Value };
        //    //    cor[6] = new string[2] { p7_1[0].Value + " " + p7_1[1].Value, p8[0].Value + " " + p8[1].Value };
        //    //    cor[7] = new string[2] { p8[0].Value + " " + p8[1].Value, p1_1[0].Value + " " + p1_1[1].Value };

        //    //    points[0] = new string[2] { p1[0].Value + " " + p1[1].Value, InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[0].Add(p3_1[0].Value), "2"), p2[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[1].Add(p3_1[1].Value), "2"), p2[1].Value), "2") };
        //    //    points[1] = new string[2] { InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[0].Add(p3_1[0].Value), "2"), p2[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p1[1].Add(p3_1[1].Value), "2"), p2[1].Value), "2"), p3_1[0].Value + " " + p3_1[1].Value };
        //    //    points[2] = new string[2] { p3[0].Value + " " + p3[1].Value, InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p3[0].Add(p5[0].Value), "2"), p4[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p3[1].Add(p5[1].Value), "2"), p4[1].Value), "2") };
        //    //    points[3] = new string[2] { InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p3[0].Add(p5[0].Value), "2"), p4[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p3[1].Add(p5[1].Value), "2"), p4[1].Value), "2"), p5[0].Value + " " + p5[1].Value };
        //    //    points[4] = new string[2] { p5_1[0].Value + " " + p5_1[1].Value, InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p5_1[0].Add(p7[0].Value), "2"), p6[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p5[1].Add(p7_1[1].Value), "2"), p6[1].Value), "2") };
        //    //    points[5] = new string[2] { InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p5_1[0].Add(p7[0].Value), "2"), p6[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p5_1[1].Add(p7[1].Value), "2"), p6[1].Value), "2"), p7[0].Value + " " + p7[1].Value };
        //    //    points[6] = new string[2] { p7_1[0].Value + " " + p7_1[1].Value, InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p7_1[0].Add(p1_1[0].Value), "2"), p8[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p7_1[1].Add(p1_1[1].Value), "2"), p8[1].Value), "2") };
        //    //    points[7] = new string[2] { InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p7_1[0].Add(p1_1[0].Value), "2"), p8[0].Value), "2") + " " + InfiNum.Divide(InfiNum.Add(InfiNum.Divide(p7_1[1].Add(p1_1[1].Value), "2"), p8[1].Value), "2"), p1_1[0].Value + " " + p1_1[1].Value };
        //    //}

        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 10; j++) // variable
        //        {
        //            for (int k = 0; k < ((string[])points[i]).Length - 1; k++)
        //            {
        //                string[] pn1 = ((string[])cor[i])[0].Split();

        //                string[] pn2 = ((string[])cor[i])[1].Split();

        //                string[] mp = ((string[])points[i])[k].Split();
        //                string[] mp2 = ((string[])points[i])[k + 1].Split();

        //                InfiNum dif = new InfiNum();
        //                InfiNum ndif = new InfiNum();

        //                InfiNum min = new InfiNum("0");
        //                InfiNum max = new InfiNum("0");

        //                InfiNum p = new InfiNum(InfiNum.Divide(InfiNum.Add(mp[0], mp2[0]), "2"));

        //                if (pn1[1] == pn2[1])
        //                {
        //                    if (InfiNum.Smaller(pn1[0], pn2[0]))
        //                    {
        //                        min.Value = pn1[0];
        //                        max.Value = pn2[0];

        //                        //if (InfiNum.Smaller(InfiNum.Subtract(mp2[0], pn1[0]), InfiNum.Subtract(pn2[0], mp2[0])))
        //                        //{
        //                        //    max.Value = mp2[0];
        //                        //}

        //                        //else
        //                        //{
        //                        //    min.Value = mp[0];
        //                        //}
        //                    }

        //                    else
        //                    {
        //                        min.Value = pn2[0];
        //                        max.Value = pn1[0];

        //                        //if (InfiNum.Smaller(InfiNum.Subtract(mp2[0], pn2[0]), InfiNum.Subtract(pn1[0], mp2[0])))
        //                        //{
        //                        //    max.Value = mp2[0];
        //                        //}

        //                        //else
        //                        //{
        //                        //    min.Value = mp[0];
        //                        //}
        //                    }

        //                    min.Value = mp[0];

        //                    if (j == 3 && k == 8)
        //                    {
        //                        int bs = 0;
        //                    }

        //                    InfiNum itX = new InfiNum(InfiNum.Divide(InfiNum.Add(min.Value, max.Value), "2"));

                            
        //                    //InfiNum itX = new InfiNum(InfiNum.Divide(InfiNum.Add(min.Value, max.Value), "2"));
        //                    //InfiNum nitX = new InfiNum(InfiNum.Divide(InfiNum.Add(min.Value, itX.Value), "2"));

        //                    //InfiNum dis1 = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[0], itX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[1], pn1[1])), "2")), "2"));
        //                    //InfiNum dis2 = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[0], itX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[1], pn1[1])), "2")), "2"));

        //                    //dif = new InfiNum(InfiNum.Abs(InfiNum.Subtract(dis1.Value, dis2.Value)));

        //                    //dis1.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[1], pn1[1])), "2")), "2");
        //                    //dis2.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[1], pn1[1])), "2")), "2");

        //                    //ndif = new InfiNum(InfiNum.Abs(InfiNum.Subtract(dis1.Value, dis2.Value)));

        //                    if (2 == 2)
        //                    {
        //                        InfiNum[] finalp = new InfiNum[2];
        //                        do
        //                        {
        //                            //if (dif.Equals(ndif.Value) || dif.Equals("0"))
        //                            //{
        //                            //    break;
        //                            //}

        //                            //if (j == 5 && k == 0)
        //                            //{
        //                            //    int bs = 0;
        //                            //}

        //                            //if (dif.Smaller(ndif.Value))
        //                            //{
        //                            //    if (itX.Greater(nitX.Value))
        //                            //    {
        //                            //        min.Value = nitX.Value;
        //                            //    }

        //                            //    if (itX.Smaller(nitX.Value))
        //                            //    {
        //                            //        max.Value = nitX.Value;
        //                            //    }

        //                            //    nitX.Value = InfiNum.Divide(InfiNum.Add(min.Value, max.Value), "2");

        //                            //    if (nitX.Equals(itX.Value))
        //                            //    {
        //                            //        nitX.Value = InfiNum.Divide(InfiNum.Add(min.Value, itX.Value), "2");
        //                            //    }

        //                            //    dis1.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[1], pn1[1])), "2")), "2");
        //                            //    dis2.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[1], pn1[1])), "2")), "2");

        //                            //    ndif = new InfiNum(InfiNum.Abs(InfiNum.Subtract(dis1.Value, dis2.Value)));
        //                            //}

        //                            //if (dif.Greater(ndif.Value))
        //                            //{
        //                            //    if (itX.Greater(nitX.Value))
        //                            //    {
        //                            //        max.Value = itX.Value;
        //                            //    }

        //                            //    if (itX.Smaller(nitX.Value))
        //                            //    {
        //                            //        min.Value = itX.Value;
        //                            //    }

        //                            //    itX.Value = nitX.Value;
        //                            //    dif.Value = ndif.Value;

        //                            //    nitX.Value = InfiNum.Divide(InfiNum.Add(min.Value, max.Value), "2");

        //                            //    if(nitX.Equals(itX.Value))
        //                            //    {
        //                            //        nitX.Value = InfiNum.Divide(InfiNum.Add(min.Value, itX.Value), "2");
        //                            //    }

        //                            //    dis1.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[1], pn1[1])), "2")), "2");
        //                            //    dis2.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[1], pn1[1])), "2")), "2");

        //                            //    ndif = new InfiNum(InfiNum.Abs(InfiNum.Subtract(dis1.Value, dis2.Value)));
        //                            //}
        //                            InfiNum left = new InfiNum(mp[0]);
        //                            InfiNum lefty = new InfiNum(mp[1]);

        //                            InfiNum right = new InfiNum(mp2[0]);
        //                            InfiNum righty = new InfiNum(mp2[1]);

        //                            InfiNum X = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));
        //                            InfiNum prevX = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));//the variable that stores the previous value of the X

        //                            InfiNum Y = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));
        //                            InfiNum prevY = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));//the variable that stores the previous value of the Y

        //                            InfiNum sqr = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(itX.Value, X.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(pn1[1], Y.Value)), "2")), "2"));
        //                            InfiNum fsqr = new InfiNum(sqr.Value);

        //                            finalp = new InfiNum[2];  // the current shortest distance
        //                            finalp[0] = new InfiNum(X.Value);
        //                            finalp[1] = new InfiNum(Y.Value);

        //                            //            ________________________---------------------___________________

        //                            fsqr.Value = sqr.Value;
        //                            X.Value = InfiNum.Subtract(X.Value, InfiNum.Divide(InfiNum.Subtract(X.Value, left.Value), "2"));  // the new point , move the x coordinate to the left

        //                            Y.Value = InfiNum.Subtract(Y.Value, InfiNum.Divide(InfiNum.Subtract(Y.Value, lefty.Value), "2")); ; // the new point

        //                            //
        //                            //  3rd part
        //                            //
        //                            //

        //                            //InfiNum old = 0;//the  distance to the previous point on the oposite line segment
        //                            //InfiNum newpoint = 0;//to the new point after we have made a step

        //                            do
        //                            {
        //                                sqr.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(itX.Value, X.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(pn1[1], Y.Value)), "2")), "2");

        //                                if (sqr.Greater(fsqr.Value)) // if the distance to the current startx/starty point 
        //                                                             //is greater than to the previous, so going beyond this point is unnesessary
        //                                                             //so this is the limit point
        //                                                             //we moved too much or in the wrong direction
        //                                {
        //                                    if (X.Smaller(prevX.Value))//if the new point's x coordinate 
        //                                                               //is to the left of the previous one
        //                                                               //so we set up the new left border 
        //                                    {
        //                                        left.Value = X.Value;  // set up the left border as the x coordinate of the current (new) point
        //                                        prevX.Value = X.Value;//saving the prev left border
        //                                        X.Value = InfiNum.Subtract(right.Value, InfiNum.Divide(InfiNum.Subtract(right.Value, left.Value), "2"));//make a step to the right, since left is greater now

        //                                        lefty.Value = Y.Value;//
        //                                        prevY.Value = Y.Value;//
        //                                        Y.Value = InfiNum.Subtract(righty.Value, InfiNum.Divide(InfiNum.Subtract(righty.Value, lefty.Value), "2"));
        //                                    }

        //                                    else//if the new point's x coordinate 
        //                                        //is to the right of the previous one
        //                                        //so we set up the new right border
        //                                    {
        //                                        right.Value = X.Value;  // set the left border as the x coordinate of the current point
        //                                        prevX.Value = X.Value;
        //                                        X.Value = InfiNum.Subtract(right.Value, InfiNum.Divide(InfiNum.Subtract(right.Value, left.Value), "2"));

        //                                        righty.Value = Y.Value;
        //                                        prevY.Value = Y.Value;
        //                                        Y.Value = InfiNum.Subtract(righty.Value, InfiNum.Divide(InfiNum.Subtract(righty.Value, lefty.Value), "2"));
        //                                    }
        //                                }

        //                                else
        //                                {
        //                                    if (sqr.Smaller(fsqr.Value))
        //                                    {
        //                                        fsqr = sqr;
        //                                        finalp[0].Value = X.Value;
        //                                        finalp[1].Value = Y.Value;

        //                                        //right = prevx;
        //                                        prevX.Value = X.Value;
        //                                        X.Value = InfiNum.Subtract(prevX.Value, InfiNum.Divide(InfiNum.Subtract(prevX.Value, left.Value), "2"));

        //                                        prevY.Value = Y.Value;
        //                                        //righty = prevy;
        //                                        Y.Value = InfiNum.Subtract(prevY.Value, InfiNum.Divide(InfiNum.Subtract(prevY.Value, left.Value), "2"));
        //                                    }

        //                                    else
        //                                    {
        //                                        if (sqr == fsqr)
        //                                        {
        //                                            break;
        //                                        }
        //                                    }
        //                                }
        //                            }/*the end of the loop*/
        //                            while (InfiNum.Greater(right.Subtract(left.Value), "0.000000000000000000000000000000000000000000000000000000000001"));

        //                            if (finalp[0].Greater(p.Value))
        //                            {
        //                                max.Value = itX.Value;
        //                            }

        //                            if (finalp[0].Smaller(p.Value))
        //                            {
        //                                min.Value = itX.Value;
        //                            }

        //                            if (finalp[0].Equals(p.Value))
        //                            {
        //                                break;
        //                            }

        //                            if (InfiNum.Greater(InfiNum.Abs(InfiNum.Subtract(p.Value, finalp[0].Value)), "0.000000000000000000000000000001"))
        //                            {
        //                                break;
        //                            }
        //                        } while (InfiNum.Greater(InfiNum.Abs(InfiNum.Subtract(p.Value, finalp[0].Value)), "0.000000000000000000000000000001"));

        //                        string[] points2 = new string[((string[])points[i]).Length + 1];
        //                        int t2 = 0;

        //                        InfiNum[] fp = new InfiNum[2];
        //                        fp[0] = new InfiNum(InfiNum.Divide(InfiNum.Add(InfiNum.Divide(InfiNum.Add(mp[0], mp2[0]), "2"), itX.Value), "2"));
        //                        fp[1] = new InfiNum(InfiNum.Divide(InfiNum.Add(InfiNum.Divide(InfiNum.Add(mp[1], mp2[1]), "2"), pn1[1]), "2"));

        //                        for (int l = 0; l < ((string[])points[i]).Length + 1; l++)
        //                        {
        //                            if (l == k + 1)
        //                            {
        //                                if (j == 0)
        //                                {
        //                                    points2[l] = fp[0].Value + " " + fp[1].Value;
        //                                }

        //                                else
        //                                {
        //                                    for (int m = 0; m < j + 1; m++)
        //                                    {
        //                                        fp[0].Value = InfiNum.Divide(InfiNum.Add(InfiNum.Divide(InfiNum.Add(mp[0], mp2[0]), "2"), fp[0].Value), "2");
        //                                        fp[1].Value = InfiNum.Divide(InfiNum.Add(InfiNum.Divide(InfiNum.Add(mp[1], mp2[1]), "2"), fp[1].Value), "2");
        //                                    }

        //                                    points2[l] = fp[0].Value + " " + fp[1].Value;
        //                                }
        //                            }

        //                            else
        //                            {
        //                                points2[l] = ((string[])points[i])[t2];
        //                                t2++;
        //                            }
        //                        }

        //                        points[i] = points2;
        //                        k++;
        //                    }
        //                }

        //                string[] temp2 = new string[2];

        //                temp2 = ((string[])points[i])[k].Split();

        //                InfiNum check2 = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract("49", temp[0])), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract("49", temp[1])), "2")), "2"));
        //                int esrhtrrtyj = 0;

        //                if (pn1[0] == pn2[0])
        //                {
        //                    p = new InfiNum(InfiNum.Divide(InfiNum.Add(mp[1], mp2[1]), "2"));

        //                    if (InfiNum.Smaller(pn1[1], pn2[1]))
        //                    {
        //                        min.Value = pn1[1];
        //                        max.Value = pn2[1];

        //                        //if (InfiNum.Smaller(InfiNum.Subtract(mp2[0], pn1[0]), InfiNum.Subtract(pn2[0], mp2[0])))
        //                        //{
        //                        //    max.Value = mp2[0];
        //                        //}

        //                        //else
        //                        //{
        //                        //    min.Value = mp[0];
        //                        //}
        //                    }

        //                    else
        //                    {
        //                        min.Value = pn2[1];
        //                        max.Value = pn1[1];

        //                        //if (InfiNum.Smaller(InfiNum.Subtract(mp2[0], pn2[0]), InfiNum.Subtract(pn1[0], mp2[0])))
        //                        //{
        //                        //    max.Value = mp2[0];
        //                        //}

        //                        //else
        //                        //{
        //                        //    min.Value = mp[0];
        //                        //}
        //                    }

        //                    min.Value = mp[1];

        //                    if (j == 3 && k == 8)
        //                    {
        //                        int bs = 0;
        //                    }

        //                    InfiNum itY = new InfiNum(InfiNum.Divide(InfiNum.Add(min.Value, max.Value), "2"));


        //                    //InfiNum itX = new InfiNum(InfiNum.Divide(InfiNum.Add(min.Value, max.Value), "2"));
        //                    //InfiNum nitX = new InfiNum(InfiNum.Divide(InfiNum.Add(min.Value, itX.Value), "2"));

        //                    //InfiNum dis1 = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[0], itX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[1], pn1[1])), "2")), "2"));
        //                    //InfiNum dis2 = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[0], itX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[1], pn1[1])), "2")), "2"));

        //                    //dif = new InfiNum(InfiNum.Abs(InfiNum.Subtract(dis1.Value, dis2.Value)));

        //                    //dis1.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[1], pn1[1])), "2")), "2");
        //                    //dis2.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[1], pn1[1])), "2")), "2");

        //                    //ndif = new InfiNum(InfiNum.Abs(InfiNum.Subtract(dis1.Value, dis2.Value)));

        //                    if (2 == 2)
        //                    {
        //                        InfiNum[] finalp = new InfiNum[2];
        //                        do
        //                        {
        //                            //if (dif.Equals(ndif.Value) || dif.Equals("0"))
        //                            //{
        //                            //    break;
        //                            //}

        //                            //if (j == 5 && k == 0)
        //                            //{
        //                            //    int bs = 0;
        //                            //}

        //                            //if (dif.Smaller(ndif.Value))
        //                            //{
        //                            //    if (itX.Greater(nitX.Value))
        //                            //    {
        //                            //        min.Value = nitX.Value;
        //                            //    }

        //                            //    if (itX.Smaller(nitX.Value))
        //                            //    {
        //                            //        max.Value = nitX.Value;
        //                            //    }

        //                            //    nitX.Value = InfiNum.Divide(InfiNum.Add(min.Value, max.Value), "2");

        //                            //    if (nitX.Equals(itX.Value))
        //                            //    {
        //                            //        nitX.Value = InfiNum.Divide(InfiNum.Add(min.Value, itX.Value), "2");
        //                            //    }

        //                            //    dis1.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[1], pn1[1])), "2")), "2");
        //                            //    dis2.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[1], pn1[1])), "2")), "2");

        //                            //    ndif = new InfiNum(InfiNum.Abs(InfiNum.Subtract(dis1.Value, dis2.Value)));
        //                            //}

        //                            //if (dif.Greater(ndif.Value))
        //                            //{
        //                            //    if (itX.Greater(nitX.Value))
        //                            //    {
        //                            //        max.Value = itX.Value;
        //                            //    }

        //                            //    if (itX.Smaller(nitX.Value))
        //                            //    {
        //                            //        min.Value = itX.Value;
        //                            //    }

        //                            //    itX.Value = nitX.Value;
        //                            //    dif.Value = ndif.Value;

        //                            //    nitX.Value = InfiNum.Divide(InfiNum.Add(min.Value, max.Value), "2");

        //                            //    if(nitX.Equals(itX.Value))
        //                            //    {
        //                            //        nitX.Value = InfiNum.Divide(InfiNum.Add(min.Value, itX.Value), "2");
        //                            //    }

        //                            //    dis1.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp[1], pn1[1])), "2")), "2");
        //                            //    dis2.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[0], nitX.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(mp2[1], pn1[1])), "2")), "2");

        //                            //    ndif = new InfiNum(InfiNum.Abs(InfiNum.Subtract(dis1.Value, dis2.Value)));
        //                            //}
        //                            InfiNum left = new InfiNum(mp[0]);
        //                            InfiNum lefty = new InfiNum(mp[1]);

        //                            InfiNum right = new InfiNum(mp2[0]);
        //                            InfiNum righty = new InfiNum(mp2[1]);

        //                            InfiNum X = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));
        //                            InfiNum prevX = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));//the variable that stores the previous value of the X

        //                            InfiNum Y = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));
        //                            InfiNum prevY = new InfiNum(InfiNum.Divide(InfiNum.Add(left.Value, right.Value), "2"));//the variable that stores the previous value of the Y

        //                            InfiNum sqr = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(pn1[0], X.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(itY.Value, Y.Value)), "2")), "2"));
        //                            InfiNum fsqr = new InfiNum(sqr.Value);

        //                            finalp = new InfiNum[2];  // the current shortest distance
        //                            finalp[0] = new InfiNum(X.Value);
        //                            finalp[1] = new InfiNum(Y.Value);

        //                            //            ________________________---------------------___________________

        //                            fsqr.Value = sqr.Value;
        //                            X.Value = InfiNum.Subtract(X.Value, InfiNum.Divide(InfiNum.Subtract(X.Value, left.Value), "2"));  // the new point , move the x coordinate to the left

        //                            Y.Value = InfiNum.Subtract(Y.Value, InfiNum.Divide(InfiNum.Subtract(Y.Value, lefty.Value), "2")); ; // the new point

        //                            //
        //                            //  3rd part
        //                            //
        //                            //

        //                            //InfiNum old = 0;//the  distance to the previous point on the oposite line segment
        //                            //InfiNum newpoint = 0;//to the new point after we have made a step

        //                            do
        //                            {
        //                                sqr.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(pn1[0], X.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(itY.Value, Y.Value)), "2")), "2");

        //                                if (sqr.Greater(fsqr.Value)) // if the distance to the current startx/starty point 
        //                                                             //is greater than to the previous, so going beyond this point is unnesessary
        //                                                             //so this is the limit point
        //                                                             //we moved too much or in the wrong direction
        //                                {
        //                                    if (Y.Smaller(prevY.Value))//if the new point's x coordinate 
        //                                                               //is to the left of the previous one
        //                                                               //so we set up the new left border 
        //                                    {
        //                                        left.Value = X.Value;  // set up the left border as the x coordinate of the current (new) point
        //                                        prevX.Value = X.Value;//saving the prev left border
        //                                        X.Value = InfiNum.Subtract(right.Value, InfiNum.Divide(InfiNum.Subtract(right.Value, left.Value), "2"));//make a step to the right, since left is greater now

        //                                        lefty.Value = Y.Value;//
        //                                        prevY.Value = Y.Value;//
        //                                        Y.Value = InfiNum.Subtract(righty.Value, InfiNum.Divide(InfiNum.Subtract(righty.Value, lefty.Value), "2"));
        //                                    }

        //                                    else//if the new point's x coordinate 
        //                                        //is to the right of the previous one
        //                                        //so we set up the new right border
        //                                    {
        //                                        right.Value = X.Value;  // set the left border as the x coordinate of the current point
        //                                        prevX.Value = X.Value;
        //                                        X.Value = InfiNum.Subtract(right.Value, InfiNum.Divide(InfiNum.Subtract(right.Value, left.Value), "2"));

        //                                        righty.Value = Y.Value;
        //                                        prevY.Value = Y.Value;
        //                                        Y.Value = InfiNum.Subtract(righty.Value, InfiNum.Divide(InfiNum.Subtract(righty.Value, lefty.Value), "2"));
        //                                    }
        //                                }

        //                                else
        //                                {
        //                                    if (sqr.Smaller(fsqr.Value))
        //                                    {
        //                                        fsqr = sqr;
        //                                        finalp[0].Value = X.Value;
        //                                        finalp[1].Value = Y.Value;

        //                                        //right = prevx;
        //                                        prevX.Value = X.Value;
        //                                        X.Value = InfiNum.Subtract(prevX.Value, InfiNum.Divide(InfiNum.Subtract(prevX.Value, left.Value), "2"));

        //                                        prevY.Value = Y.Value;
        //                                        //righty = prevy;
        //                                        Y.Value = InfiNum.Subtract(prevY.Value, InfiNum.Divide(InfiNum.Subtract(prevY.Value, left.Value), "2"));
        //                                    }

        //                                    else
        //                                    {
        //                                        if (sqr == fsqr)
        //                                        {
        //                                            break;
        //                                        }
        //                                    }
        //                                }
        //                            }/*the end of the loop*/
        //                            while (InfiNum.Greater(right.Subtract(left.Value), "0.000000000000000000000000000001"));

        //                            if (finalp[1].Greater(p.Value))
        //                            {
        //                                max.Value = itY.Value;
        //                            }

        //                            if (finalp[1].Smaller(p.Value))
        //                            {
        //                                min.Value = itY.Value;
        //                            }

        //                            if (finalp[1].Equals(p.Value))
        //                            {
        //                                break;
        //                            }

        //                            if (InfiNum.Greater(InfiNum.Abs(InfiNum.Subtract(p.Value, finalp[0].Value)), "0.000000000000000000000000000001"))
        //                            {
        //                                break;
        //                            }
        //                        } while (InfiNum.Greater(InfiNum.Abs(InfiNum.Subtract(p.Value, finalp[0].Value)), "0.000000000000000000000000000001"));

        //                        string[] points2 = new string[((string[])points[i]).Length + 1];
        //                        int t2 = 0;

        //                        InfiNum[] fp = new InfiNum[2];
        //                        fp[0] = new InfiNum(InfiNum.Divide(InfiNum.Add(InfiNum.Divide(InfiNum.Add(mp[0], mp2[0]), "2"), pn1[0]), "2"));
        //                        fp[1] = new InfiNum(InfiNum.Divide(InfiNum.Add(InfiNum.Divide(InfiNum.Add(mp[1], mp2[1]), "2"), itY.Value), "2"));

        //                        for (int l = 0; l < ((string[])points[i]).Length + 1; l++)
        //                        {
        //                            if (l == k + 1)
        //                            {
        //                                if (j == 0)
        //                                {
        //                                    points2[l] = fp[0].Value + " " + fp[1].Value;
        //                                }

        //                                else
        //                                {
        //                                    for (int m = 0; m < j + 1; m++)
        //                                    {
        //                                        fp[0].Value = InfiNum.Divide(InfiNum.Add(InfiNum.Divide(InfiNum.Add(mp[0], mp2[0]), "2"), fp[0].Value), "2");
        //                                        fp[1].Value = InfiNum.Divide(InfiNum.Add(InfiNum.Divide(InfiNum.Add(mp[1], mp2[1]), "2"), fp[1].Value), "2");
        //                                    }

        //                                    points2[l] = fp[0].Value + " " + fp[1].Value;
        //                                }
        //                            }

        //                            else
        //                            {
        //                                points2[l] = ((string[])points[i])[t2];
        //                                t2++;
        //                            }
        //                        }

        //                        points[i] = points2;
        //                        k++;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    int ee = 0;

        //    InfiNum circumference = new InfiNum();

        //    //for (int i = 0; i < points.Length; i++)
        //    //{
        //    //    for (int j = 0; j < ((string[])points[i]).Length - 1; j++)
        //    //    {
        //    //        sqr.Value = InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(itX.Value, X.Value)), "2"), InfiNum.Pow(InfiNum.Abs(InfiNum.Subtract(pn1[1], Y.Value)), "2")), "2");
        //    //    }
        //}
    }
}
