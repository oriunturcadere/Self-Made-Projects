using System;
using System.Collections.Generic;
using System.Text;

namespace Physics
{
    class FromDistance
    {
        public void Calc(BigD[] fallprop, BigD titir, BigD g, BigD rad, out BigD[] fallp2, out string ans)
        {
            ans = "";
            fallp2 = new BigD[4];
            fallp2[0] = new BigD();
            fallp2[0].Value = fallprop[0].Value;
            fallp2[1] = new BigD();
            fallp2[1].Value = fallprop[1].Value;
            fallp2[2] = new BigD();
            fallp2[2].Value = fallprop[2].Value;
            fallp2[3] = new BigD();
            fallp2[3].Value = fallprop[3].Value;

            BigD acc = new BigD();//the current accelaration 

            BigD dis2 = new BigD();
            dis2.Value = fallp2[0].Value;// the distance remaining to the surface

            BigD h3 = new BigD();
            h3.Value = fallp2[0].ToString();

            do//until the disatnce dis2 is zero - the impact
            {
                BigD step1 = new BigD();
                step1.Value = rad.Divide(rad.Add(dis2.Value)); //the radius of the Earth ratio to the distance
                BigD step2 = new BigD();
                step2.Value = step1.Multiply(step1.Value); //the square of the ratio
                acc.Value = step2.Multiply(g.Value); //the current accelaration depending on the distance

                BigD h1 = new BigD();
                h1.Value = titir.Multiply(fallp2[3].Value);
                h1.Value = h1.Add(titir/*second*/.Multiply(acc.Divide("2")));

                BigD h2 = new BigD();
                h2.Value = fallp2[1].Value;
                BigD h5 = new BigD();
                h5.Value = fallp2[3].Value;

                if (h1.Greater(dis2.Value))//if the distance left is less than an objects falls in 1 second
                {
                    //the quadratic equation designing t2+at+b=0

                    BigD sp1 = new BigD();
                    sp1.Value = dis2.Multiply("2");//the remaining distance*2
                    BigD sp2 = new BigD();
                    sp2.Value = h5.Multiply("2");//the initial speed of the last iteration*2

                    BigD sp3_1 = new BigD();
                    sp3_1.Value = sp1.Divide(acc.Value);//
                    BigD sp3_2 = new BigD();
                    sp3_2.Value = sp2.Divide(acc.Value);
                    BigD sp3_3 = new BigD();
                    sp3_3.Value = "1";

                    BigD sp4 = new BigD();
                    sp4.Value = sp3_2.Divide("2");
                    BigD sp5 = new BigD();
                    sp5.Value = sp3_1.Add(sp4.Multiply(sp4.Value));

                    BigD sp6 = new BigD();
                    sp6.Value = sp5.Root("2");
                    BigD sp7 = new BigD();
                    sp7.Value = sp6.Subtract(sp4.Value);

                    fallp2[1].Value = sp7.Add(fallp2[1].Value);
                    fallp2[3].Value = h5.Add(acc.Multiply(sp7.Value));
                    dis2.Value = "0";

                    ans = "d = vₐ * t,\r\nd = (v₀ + v₁) / 2 * t,\r\n2d = (v₀ + v₁) * t,\r\nv₀ = v₁ + a₁ * t,\r\n2d = (v₁ + v₁ + a₁ * t) * t,\r\n2d = (2v₁ + a₁ * t) * t,\r\n2d = 2v₁t + a₁t²,\r\n2v₁t + a₁t² = 2d,\r\n2v₁t + a₁t² – 2d = 0,\r\na₁t² +2v₁t – 2d = 0,\r\n" + acc.Value + "t² + " + sp2.Value + "t - " + sp1.Value + " = 0,\r\n("+acc.Value +  "t² + " + sp2.Value + "t - " +sp1.Value + ") / " +acc.Value + " = 0,\r\nt² + " +sp3_2.Value + "t - " +sp3_1.Value + " = 0,\r\n\r\n" +               sp3_2.Value + "\r\n   _t_       _\r\nt | t² | +  | | t - " +sp3_1.Value + " = 0,\r\n   ⁻⁻⁻⁻     ––\r\n\r\n" +               sp3_2.Value + " / 2\r\n   _t_       _\r\nt | t² | +  || t - " +sp3_1.Value + " = 0,\r\n   ⁻⁻⁻⁻      ⁻\r\n    +\r\n  |⁻⁻⁻⁻| " +sp3_2.Value + " / 2\r\n   ⁻⁻⁻⁻\r\n     t\r\n\r\n(t + " +sp3_2.Value + " / 2) ^ 2 - (" +sp3_2.Value + " / 2) ^ 2 - " +sp3_1.Value + " = 0,\r\n(t + " +sp4.Value + ") ^ 2 - " +sp4.Value + " ^ 2 - " +sp3_1.Value + " = 0,\r\n(t + " +sp4.Value + ") ^ 2 = " +sp4.Value + " ^ 2 + " +sp3_1.Value + ",\r\nt + " +sp4.Value + " = √(" +sp4.Value + " ^ 2 + "  +sp3_1.Value + "),\r\nt = √(" +sp4.Value + " ^ 2 + "  +sp3_1.Value + ") - " +sp4.Value + ",\r\nt = √(" +sp5.Value + ") - " +sp4.Value + ",\r\nt = " + sp6.Value + " - " + sp4.Value + ",\r\n\r\nt = " + sp7.Value + ".\r\nAnswer: " + sp7.Value;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        //\-_-/
                }

                else
                {
                    BigD gig = new BigD();
                    gig.Value = titir.Multiply(h5.Add(titir.Multiply(acc.Divide("2"))));
                    dis2.Value = dis2.Subtract(titir.Multiply(h5.Add(titir.Multiply(acc.Divide("2")))));
                    fallp2[3].Value = h5.Add(acc.Multiply(titir.Value));

                    fallp2[1].Value = h2.Add(titir.Value);
                }
            } while (dis2.Greater("0"));

            fallp2[2].Value = fallp2[0].Divide(fallp2[1].Value);
        }

        //public void Calc(object[] fallprop, decimal titir, decimal g, decimal rad, out object[] fallp2, out string ans)
        //{
        //    ans = "";
        //    fallp2 = fallprop;

        //    decimal acc = 0;//the current accelaration 

        //    decimal dis2 = Convert.ToDecimal(fallp2[0]);// the distance remaining to the surface

        //    do//until the disatnce dis2 is zero - the impact
        //    {
        //        decimal step1 = rad / (rad + dis2); //the radius of the Earth ratio to the distance
        //        decimal step2 = step1 * step1; //the square of the ratio
        //        acc = step2 * g; //the current accelaration depending on the distance

        //        if (Convert.ToDecimal(fallp2[3]) * titir + acc / 2 * titir/*second*/ > dis2)//if the distance left is less than an objects falls in 1 second
        //        {
        //            //the quadratic equation designing t2+at+b=0

        //            decimal sp1 = 2 * dis2;//the remaining distance*2
        //            decimal sp2 = Convert.ToDecimal(fallp2[3]) * 2;//the initial speed of the last iteration*2

        //            decimal sp3_1 = sp1 / acc;//
        //            decimal sp3_2 = sp2 / acc;
        //            decimal sp3_3 = 1;

        //            decimal sp4 = sp3_2 / 2;
        //            decimal sp5 = sp4 * sp4 + sp3_1;

        //            Root n = new Root();
        //            n.Rt(sp5, 2, out decimal r);

        //            decimal sp6 = r;
        //            decimal sp7 = r - sp4;

        //            fallp2[1] = Convert.ToDecimal(fallp2[1]) + sp7;
        //            fallp2[3] = Convert.ToDecimal(fallp2[3]) + acc * sp7;
        //            dis2 = 0;

        //            ans = "d = vₐ * t,\r\nd = (v₀ + v₁) / 2 * t,\r\n2d = (v₀ + v₁) * t,\r\nv₀ = v₁ + a₁ * t,\r\n2d = (v₁ + v₁ + a₁ * t) * t,\r\n2d = (2v₁ + a₁ * t) * t,\r\n2d = 2v₁t + a₁t²,\r\n2v₁t + a₁t² = 2d,\r\n2v₁t + a₁t² – 2d = 0,\r\na₁t² +2v₁t – 2d = 0,\r\n" + acc.ToString() + "t² + " + sp2.ToString() + "t - " + sp1.ToString() + " = 0,\r\n(" + acc.ToString() + "t² + " + sp2.ToString() + "t - " + sp1.ToString() + ") / " + acc.ToString() + " = 0,\r\nt² + " + sp3_2.ToString() + "t - " + sp3_1.ToString() + " = 0,\r\n\r\n" + sp3_2.ToString() + "\r\n   _t_       _\r\nt | t² | +  | | t - " + sp3_1.ToString() + " = 0,\r\n   ⁻⁻⁻⁻     ––\r\n\r\n" + sp3_2.ToString() + " / 2\r\n   _t_       _\r\nt | t² | +  || t - " + sp3_1.ToString() + " = 0,\r\n   ⁻⁻⁻⁻      ⁻\r\n    +\r\n  |⁻⁻⁻⁻| " + sp3_2.ToString() + " / 2\r\n   ⁻⁻⁻⁻\r\n     t\r\n\r\n(t + " + sp3_2.ToString() + " / 2) ^ 2 - (" + sp3_2.ToString() + " / 2) ^ 2 - " + sp3_1.ToString() + " = 0,\r\n(t + " + sp4.ToString() + ") ^ 2 - " + sp4.ToString() + " ^ 2 - " + sp3_1.ToString() + " = 0,\r\n(t + " + sp4.ToString() + ") ^ 2 = " + sp4.ToString() + " ^ 2 + " + sp3_1.ToString() + ",\r\nt + " + sp4.ToString() + " = √(" + sp4.ToString() + " ^ 2 + " + sp3_1.ToString() + "),\r\nt = √(" + sp4.ToString() + " ^ 2 + " + sp3_1.ToString() + ") - " + sp4.ToString() + ",\r\nt = √(" + sp5.ToString() + ") - " + sp4.ToString() + ",\r\nt = " + sp6.ToString() + " - " + sp4.ToString() + ",\r\n\r\nt = " + sp7.ToString() + ".\r\nAnswer: " + sp7.ToString();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            //\-_-/
        //        }

        //        else
        //        {
        //            decimal gig = (Convert.ToDecimal(fallp2[3]) + acc / 2 * titir) * titir;
        //            dis2 = dis2 - gig;
        //            fallp2[3] = Convert.ToDecimal(fallp2[3]) + acc * titir;

        //            fallp2[1] = Convert.ToDecimal(fallp2[1]) + titir;
        //        }
        //    } while (dis2 > 0);

        //    fallp2[2] = Convert.ToDecimal(fallp2[0]) / Convert.ToDecimal(fallp2[1]);
        //}
    }
}
