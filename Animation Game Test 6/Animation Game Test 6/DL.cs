using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Animation_Game_Test_6
{
    class DL
    {
        public Bitmap DrawInfiLine(Bitmap bmp, InfiNum[] p1, InfiNum[] p2, Color c2)
        {
            InfiNum[] p_1 = new InfiNum[2] { p1[0], p1[1] };
            InfiNum[] p_2 = new InfiNum[2] { p2[0], p2[1] };

            if (p_1[0].Greater(p_2[0].Value))
            {
                InfiNum[] p3 = new InfiNum[p_1.Length];

                for (int i = 0; i < p3.Length;)
                {
                    p3[i].Value = p_1[i].Value;
                }

                for (int i = 0; i < p_1.Length;)
                {
                    p_1[i].Value = p_2[i].Value;
                }

                for (int i = 0; i < p_2.Length;)
                {
                    p_2[i].Value = p3[i].Value;
                }
            }

            Bitmap bmp_2 = bmp;

            InfiNum a = new InfiNum(InfiNum.Add(InfiNum.Abs((Math.Round(Convert.ToDecimal(p_2[0].Subtract(p_1[0].Value)))).ToString()), "1"));
            InfiNum b = new InfiNum(InfiNum.Add(InfiNum.Abs((Math.Round(Convert.ToDecimal(p_2[1].Subtract(p_1[1].Value)))).ToString()), "1"));

            bmp_2.SetPixel(Convert.ToInt32(p_1[0].Floor()), Convert.ToInt32(p_1[1].Floor()), c2);
            bmp_2.SetPixel(Convert.ToInt32(p_2[0].Floor()), Convert.ToInt32(p_2[1].Floor()), c2);

            if (a.Smaller(b.Value))
            {
                for (decimal i = 0; i < Convert.ToDecimal(b.Subtract("1")); i++)
                {
                    if (p_1[1].Smaller(p_2[1].Value))
                    {
                        p_1[1].Value = p_1[1].Add("1");
                        p_1[0].Value = p_1[0].Add(InfiNum.Divide((a.Subtract("1")), (b.Subtract("1"))));

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(Convert.ToDecimal(p_1[0].Value))), Convert.ToInt32(p_1[1].Floor()), c2);
                    }

                    else
                    {
                        p_1[1].Value = p_1[1].Subtract("1");
                        p_1[0].Value = p_1[0].Add(InfiNum.Divide((a.Subtract("1")), (b.Subtract("1"))));

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(Convert.ToDecimal(p_1[0].Value))), Convert.ToInt32(p_1[1].Floor()), c2);
                    }
                }
            }

            else
            {
                for (decimal i = 0; i < Convert.ToDecimal(a.Subtract("1")); i++)
                {
                    if (p_1[1].Smaller(p_2[1].Value))
                    {
                        p_1[0].Value = p_1[0].Add("1");
                        p_1[1].Value = p_1[1].Add(InfiNum.Divide((b.Subtract("1")), (a.Subtract("1"))));

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(Convert.ToDecimal(p_1[0].Value))), Convert.ToInt32(p_1[1].Floor()), c2);
                    }

                    else
                    {
                        p_1[0].Value = p_1[0].Add("1");
                        p_1[1].Value = p_1[1].Subtract(InfiNum.Divide((b.Subtract("1")), (a.Subtract("1"))));

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(Convert.ToDecimal(p_1[0].Value))), Convert.ToInt32(p_1[1].Floor()), c2);
                    }
                }
            }

            return bmp_2;
        }

        public Bitmap DrawLine(Bitmap bmp, decimal[] p1, decimal[] p2, Color c2)
        {
            decimal[] p_1 = new decimal[] { p1[0], p1[1] };
            decimal[] p_2 = new decimal[] { p2[0], p2[1] };

            if (p_1[0] > p_2[0])
            {
                decimal[] p3 = p_1;

                p_1 = p_2;

                p_2 = p3;
            }

            Bitmap bmp_2 = bmp;

            decimal a = Math.Round(Math.Abs(p_2[0] - p_1[0])) + 1;
            decimal b = Math.Round(Math.Abs(p_2[1] - p_1[1])) + 1;

            bmp_2.SetPixel(Convert.ToInt32(Math.Round(p_1[0])), Convert.ToInt32(Math.Round(p_1[1])), c2);
            bmp_2.SetPixel(Convert.ToInt32(Math.Round(p_2[0])), Convert.ToInt32(Math.Round(p_2[1])), c2);

            if (a < b)
            {
                for (decimal i = 0; i < b - 1; i++)
                {
                    if (p_1[1] < p_2[1])
                    {
                        p_1[1] = p_1[1] + 1;
                        p_1[0] = p_1[0] + (a - 1) / (b - 1);

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(p_1[0])), Convert.ToInt32(Math.Round(p_1[1])), c2);
                    }

                    else
                    {
                        p_1[1] = p_1[1] - 1;
                        p_1[0] = p_1[0] + (a - 1) / (b - 1);

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(p_1[0])), Convert.ToInt32(Math.Round(p_1[1])), c2);
                    }
                }
            }

            else
            {
                for (decimal i = 0; i < a - 1; i++)
                {
                    if (p_1[1] < p_2[1])
                    {
                        p_1[0] = p_1[0] + 1;
                        p_1[1] = p_1[1] + (b - 1) / (a - 1);

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(p_1[0])), Convert.ToInt32(Math.Round(p_1[1])), c2);
                    }

                    else
                    {
                        p_1[0] = p_1[0] + 1;
                        p_1[1] = p_1[1] - (b - 1) / (a - 1);

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(p_1[0])), Convert.ToInt32(Math.Round(p_1[1])), c2);
                    }
                }
            }

            return bmp_2;
        }

        public Bitmap DrawCircleLine(Bitmap bmp, decimal[] p1, decimal[] p2, Color c2, decimal[] center, decimal rad)
        {
            decimal[] p_1 = new decimal[] { p1[0], p1[1] };
            decimal[] p_2 = new decimal[] { p2[0], p2[1] };

            if (p_1[0] > p_2[0])
            {
                decimal[] p3 = p_1;

                p_1 = p_2;

                p_2 = p3;
            }

            Bitmap bmp_2 = bmp;

            decimal a = Math.Round(Math.Abs(p_2[0] - p_1[0])) + 1;
            decimal b = Math.Round(Math.Abs(p_2[1] - p_1[1])) + 1;

            bmp_2.SetPixel(Convert.ToInt32(Math.Round(p_1[0])), Convert.ToInt32(Math.Round(p_1[1])), c2);
            bmp_2.SetPixel(Convert.ToInt32(Math.Round(p_2[0])), Convert.ToInt32(Math.Round(p_2[1])), c2);

            if (a < b)
            {
                for (decimal i = 0; i < b - 1; i++)
                {
                    if (p_1[1] < p_2[1])
                    {
                        p_1[1] = p_1[1] + 1;
                        p_1[0] = p_1[0] + (a - 1) / (b - 1);

                        //decimal[] dis = new decimal[9] { Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - p_1[0]) + Math.Abs(center[1] - p_1[1])).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - (p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - (p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - p_1[0]) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - (p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad) };

                        //string[] p = new string[9] { p_1[0].ToString() + " " + p_1[1].ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + p_1[1].ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + p_1[1].ToString(),
                        //    p_1[0].ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    p_1[0].ToString() + " " + Math.Ceiling(p_1[1]).ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString()};

                        decimal[] dis = new decimal[3] { Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((p1[1] - center[1]) * (p1[1] - center[1]) - rad * rad).ToString()), "2")),
                            Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((Math.Floor(p1[1]) - center[1]) * (Math.Floor(p1[1]) - center[1]) - rad * rad).ToString()), "2")),
                            Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((Math.Ceiling(p1[1]) - center[1]) * (Math.Ceiling(p1[1]) - center[1]) - rad * rad).ToString()), "2")), };

                        string[] p = new string[3] { p_1[0].ToString() + " " + p_1[1].ToString(),
                            Math.Floor(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                            Math.Ceiling(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString() };

                        string[] p_ = new string[3] { p_1[0].ToString(),
                            Math.Floor(p_1[0]).ToString(),
                            Math.Ceiling(p_1[0]).ToString() };

                        decimal[] dif = new decimal[3] { Math.Abs(dis[0] - Convert.ToDecimal(p_[0])),
                            Math.Abs(dis[1] - Convert.ToDecimal(p_[1])),
                            Math.Abs(dis[2] - Convert.ToDecimal(p_[2])) };

                        decimal min = dif[0];
                        int ij = 0;

                        for (int j = 1; j < 3; j++)
                        {
                            if (min > dif[j]) //-----------------------------------------------------------------------------
                            {
                                min = dif[j];
                                ij = j;
                            }
                        }

                        string[] pij = p[ij].Split();

                        decimal[] fp = new decimal[2] { Convert.ToDecimal(pij[0]), Convert.ToDecimal(pij[1]) };

                        if (fp[0] == 497 && fp[1] == 508)
                        {
                            int fhfh = 0;
                        }

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(fp[0])), Convert.ToInt32(Math.Round(fp[1])), c2);
                    }

                    else
                    {
                        p_1[1] = p_1[1] - 1;
                        p_1[0] = p_1[0] + (a - 1) / (b - 1);

                        //decimal[] dis = new decimal[9] { Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - p_1[0]) + Math.Abs(center[1] - p_1[1])).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - (p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - (p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - p_1[0]) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - (p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad) };

                        //string[] p = new string[9] { p_1[0].ToString() + " " + p_1[1].ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + p_1[1].ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + p_1[1].ToString(),
                        //    p_1[0].ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    p_1[0].ToString() + " " + Math.Ceiling(p_1[1]).ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString()};

                        //decimal min = dis[0];
                        //int ij = 0;

                        //for (int j = 1; j < 9; j++)
                        //{
                        //    if (min > dis[j]) //-----------------------------------------------------------------------------
                        //    {
                        //        min = dis[j];
                        //        ij = j;
                        //    }
                        //}

                        decimal[] dis = new decimal[3] { Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((p_1[1] - center[1]) * (p_1[1] - center[1]) - rad * rad).ToString()), "2")),
                            Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((Math.Floor(p_1[1]) - center[1]) * (Math.Floor(p_1[1]) - center[1]) - rad * rad).ToString()), "2")),
                            Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((Math.Ceiling(p_1[1]) - center[1]) * (Math.Ceiling(p_1[1]) - center[1]) - rad * rad).ToString()), "2")), };

                        string[] p = new string[3] { p_1[0].ToString() + " " + p_1[1].ToString(),
                            Math.Floor(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                            Math.Ceiling(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString() };

                        string[] p_ = new string[3] { p_1[0].ToString(),
                            Math.Floor(p_1[0]).ToString(),
                            Math.Ceiling(p_1[0]).ToString() };

                        decimal[] dif = new decimal[3] { Math.Abs(dis[0] - Convert.ToDecimal(p_[0])),
                            Math.Abs(dis[1] - Convert.ToDecimal(p_[1])),
                            Math.Abs(dis[2] - Convert.ToDecimal(p_[2])) };

                        decimal min = dif[0];
                        int ij = 0;

                        for (int j = 1; j < 3; j++)
                        {
                            if (min > dif[j]) //-----------------------------------------------------------------------------
                            {
                                min = dif[j];
                                ij = j;
                            }
                        }

                        string[] pij = p[ij].Split();

                        decimal[] fp = new decimal[2] { Convert.ToDecimal(pij[0]), Convert.ToDecimal(pij[1]) };

                        if (fp[0] == 497 && fp[1] == 508)
                        {
                            int fhfh = 0;
                        }

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(fp[0])), Convert.ToInt32(Math.Round(fp[1])), c2);
                    }
                }
            }

            else
            {
                for (decimal i = 0; i < a - 1; i++)
                {
                    if (p_1[1] < p_2[1])
                    {
                        p_1[0] = p_1[0] + 1;
                        p_1[1] = p_1[1] + (b - 1) / (a - 1);

                        //decimal[] dis = new decimal[9] { Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - p_1[0]) + Math.Abs(center[1] - p_1[1])).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - (p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - (p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - p_1[0]) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - (p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad) };

                        //string[] p = new string[9] { p_1[0].ToString() + " " + p_1[1].ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + p_1[1].ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + p_1[1].ToString(),
                        //    p_1[0].ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    p_1[0].ToString() + " " + Math.Ceiling(p_1[1]).ToString(),//
                        //    Math.Floor(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString(),//
                        //    Math.Ceiling(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString()};//

                        //decimal min = dis[0];
                        //int ij = 0;

                        //for (int j = 1; j < 9; j++)
                        //{
                        //    if (min > dis[j]) //-----------------------------------------------------------------------------
                        //    {
                        //        min = dis[j];
                        //        ij = j;
                        //    }
                        //}

                        decimal[] dis = new decimal[3] { Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((p_1[1] - center[1]) * (p_1[1] - center[1]) - rad * rad).ToString()), "2")),
                            Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((Math.Floor(p_1[1]) - center[1]) * (Math.Floor(p_1[1]) - center[1]) - rad * rad).ToString()), "2")),
                            Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((Math.Ceiling(p_1[1]) - center[1]) * (Math.Ceiling(p_1[1]) - center[1]) - rad * rad).ToString()), "2")), };

                        string[] p = new string[3] { p_1[0].ToString() + " " + p_1[1].ToString(),
                            Math.Floor(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                            Math.Ceiling(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString() };

                        string[] p_ = new string[3] { p_1[0].ToString(),
                            Math.Floor(p_1[0]).ToString(),
                            Math.Ceiling(p_1[0]).ToString() };

                        decimal[] dif = new decimal[3] { Math.Abs(dis[0] - Convert.ToDecimal(p_[0])),
                            Math.Abs(dis[1] - Convert.ToDecimal(p_[1])),
                            Math.Abs(dis[2] - Convert.ToDecimal(p_[2])) };

                        decimal min = dif[0];
                        int ij = 0;

                        for (int j = 1; j < 3; j++)
                        {
                            if (min > dif[j]) //-----------------------------------------------------------------------------
                            {
                                min = dif[j];
                                ij = j;
                            }
                        }

                        string[] pij = p[ij].Split();

                        decimal[] fp = new decimal[2] { Convert.ToDecimal(pij[0]), Convert.ToDecimal(pij[1]) };

                        if (fp[0] == 497 && fp[1] == 508)
                        {
                            int fhfh = 0;
                        }

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(fp[0])), Convert.ToInt32(Math.Round(fp[1])), c2);
                    }

                    else
                    {
                        p_1[0] = p_1[0] + 1;
                        p_1[1] = p_1[1] - (b - 1) / (a - 1);

                        //decimal[] dis = new decimal[9] { Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - p_1[0]) + Math.Abs(center[1] - p_1[1])).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - (p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - (p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - p_1[0]) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - (p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Floor(p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - Math.Floor(p_1[1]))).ToString(), "2")) - rad),
                        //    Math.Abs(Convert.ToDecimal(InfiNum.Root((Math.Abs(center[0] - Math.Ceiling(p_1[0])) + Math.Abs(center[1] - Math.Ceiling(p_1[1]))).ToString(), "2")) - rad) };

                        //string[] p = new string[9] { p_1[0].ToString() + " " + p_1[1].ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + p_1[1].ToString(), Math.Ceiling(p_1[0]).ToString() + " " + p_1[1].ToString(),
                        //    p_1[0].ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    p_1[0].ToString() + " " + Math.Ceiling(p_1[1]).ToString(),
                        //    Math.Floor(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(), Math.Floor(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                        //    Math.Ceiling(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString()};

                        //decimal min = dis[0];
                        //int ij = 0;

                        //for (int j = 1; j < 9; j++)
                        //{
                        //    if (min > dis[j]) //-----------------------------------------------------------------------------
                        //    {
                        //        min = dis[j];
                        //        ij = j;
                        //    }
                        //}

                        decimal[] dis = new decimal[3] { Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((p_1[1] - center[1]) * (p_1[1] - center[1]) - rad * rad).ToString()), "2")),
                            Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((Math.Floor(p_1[1]) - center[1]) * (Math.Floor(p_1[1]) - center[1]) - rad * rad).ToString()), "2")),
                            Convert.ToDecimal(InfiNum.Root(InfiNum.Abs(((Math.Ceiling(p_1[1]) - center[1]) * (Math.Ceiling(p_1[1]) - center[1]) - rad * rad).ToString()), "2")), };

                        string[] p = new string[3] { p_1[0].ToString() + " " + p_1[1].ToString(),
                            Math.Floor(p_1[0]).ToString() + " " + Math.Floor(p_1[1]).ToString(),
                            Math.Ceiling(p_1[0]).ToString() + " " + Math.Ceiling(p_1[1]).ToString() };

                        string[] p_ = new string[3] { p_1[0].ToString(),
                            Math.Floor(p_1[0]).ToString(),
                            Math.Ceiling(p_1[0]).ToString() };

                        decimal[] dif = new decimal[3] { Math.Abs(dis[0] - Convert.ToDecimal(p_[0])),
                            Math.Abs(dis[1] - Convert.ToDecimal(p_[1])),
                            Math.Abs(dis[2] - Convert.ToDecimal(p_[2])) };

                        decimal min = dif[0];
                        int ij = 0;

                        for (int j = 1; j < 3; j++)
                        {
                            if (min > dif[j]) //-----------------------------------------------------------------------------
                            {
                                min = dif[j];
                                ij = j;
                            }
                        }

                        string[] pij = p[ij].Split();

                        decimal[] fp = new decimal[2] { Convert.ToDecimal(pij[0]), Convert.ToDecimal(pij[1]) };

                        if (fp[0] == 497 && fp[1] == 508)
                        {
                            int fhfh = 0;
                        }

                        bmp_2.SetPixel(Convert.ToInt32(Math.Round(fp[0])), Convert.ToInt32(Math.Round(fp[1])), c2);
                    }
                }
            }

            return bmp_2;
        }
    }
}
