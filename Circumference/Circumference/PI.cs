using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circumference
{
    class PI
    {
        public void DrawCircle(InfiNum rad, int sides, out string[] points, out InfiNum ONEsegment, out InfiNum circumference, out InfiNum PI)
        {
            InfiNum[] O = new InfiNum[2];
            O[0] = new InfiNum("0");
            O[1] = new InfiNum("0");

            InfiNum[] p1 = new InfiNum[2];

            p1[0] = new InfiNum(O[0].Value);
            p1[1] = new InfiNum(O[1].Add(rad.Value));

            InfiNum[] p2 = new InfiNum[2];

            p2[0] = new InfiNum(O[0].Add(rad.Value));
            p2[1] = new InfiNum(O[1].Add(rad.Value));

            points = new string[2];

            points[0] = p1[0].Value + " " + p1[1].Value;
            points[1] = "";

            //: :   :   :   :   1ST STEP  :   :   :   :

            InfiNum OX = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Subtract(p2[0].Value, "0"), "2"), InfiNum.Pow(InfiNum.Subtract(p2[1].Value, "0"), "2")), "2"));


            //: :   :   :   :   2ND STEP  :   :   :   :

            InfiNum RADdivOX = new InfiNum(InfiNum.Divide(rad.Value, OX.Value));
            InfiNum RADdivOXtimesRAD = new InfiNum(InfiNum.Multiply(RADdivOX.Value, rad.Value)); // X of point 1
            InfiNum Yof1 = new InfiNum(RADdivOXtimesRAD.Value); // X OF point 1 is equal to Y of point 1

            points[1] = RADdivOXtimesRAD.Value + " " + Yof1.Value;


            if (sides != 2)
            {
                //: :   :   :   :   3RD STEP  :   :   :   :

                for (int i = 0; i < sides - 3; i++)
                {
                    string[] points2 = new string[points.Length + 1];
                    int temp = 0;

                    for (int j = 0; j < points.Length + 1; j++)
                    {
                        if (j != 1)
                        {
                            points2[j] = points[temp];
                            temp++;
                        }
                    }

                    points = points2;

                    string[] pt1 = points[0].Split();
                    string[] pt2 = points[2].Split();

                    InfiNum[] T = new InfiNum[2];
                    T[0] = new InfiNum(InfiNum.Divide(InfiNum.Add(pt1[0], pt2[0]), "2"));
                    T[1] = new InfiNum(InfiNum.Divide(InfiNum.Add(pt1[1], pt2[1]), "2"));

                    InfiNum OT = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Subtract(T[0].Value, "0"), "2"), InfiNum.Pow(InfiNum.Subtract(T[1].Value, "0"), "2")), "2")); //OT^2 = XofT^2 + YofT^2 => OT = sqrt(XofT^2 + YofT^2)

                    InfiNum YofTdivOT = new InfiNum(InfiNum.Divide(T[0].Value, OT.Value));  //  our S(slope)
                    InfiNum YofTdivOTtimesRAD = new InfiNum(InfiNum.Multiply(YofTdivOT.Value, rad.Value));  //X of point 2  (on the circle)


                    //: :   :   :   :   4TH STEP  :   :   :   :

                    //  Since r^2 = XofPT2^2 + YofPT2^2 => YofPT2^2 = r^2 - XofPT2^2 => YofPT2 = sqrt(r^2 - XofPT2^2)  (PT2 -- point 2)

                    InfiNum YofPT2 = new InfiNum(InfiNum.Root(InfiNum.Subtract(InfiNum.Pow(rad.Value, "2"), InfiNum.Pow(YofTdivOTtimesRAD.Value, "2")), "2"));

                    points[1] = YofTdivOTtimesRAD.Value + " " + YofPT2.Value;
                }
            }

            else
            {
                points[1] = O[0].Add(rad.Value) + " " + O[1].Value;
            }


            //: :   :   :   :   5TH STEP  :   :   :   :

            string[] pt_1 = points[0].Split();
            string[] pt_2 = points[1].Split();

            ONEsegment = new InfiNum(InfiNum.Root(InfiNum.Add(InfiNum.Pow(InfiNum.Subtract(pt_2[0], pt_1[0]), "2"), InfiNum.Pow(InfiNum.Subtract(pt_2[1], pt_1[1]), "2")), "2"));

            circumference = new InfiNum(InfiNum.Multiply(ONEsegment.Value, InfiNum.Pow("2", sides.ToString())));

            PI = new InfiNum(InfiNum.Divide(circumference.Value, InfiNum.Multiply(rad.Value, "2")));

            int dj_dhv_fxxjgvjgx_cg_cm_ct = 436672652;

            // _________--------------------________
        }
    }
}
