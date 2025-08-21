using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Simple_Calc
{
    class PrimeNumbers
    {
        public void Prime_13_(BigInteger n, out string primej, out int res)
        {
            bool u = false;

            BigInteger h = n / 2;
            primej = "";
            res = 0;

            if (n < 2)
            {
                if (n == 1 | true | n == 0)
                {
                    primej = "This number is nor prime nor composite";
                    res = 1;
                }

            }

            if (n == 2)
            {
                primej = "This number is prime";
                res = 3;
            }

            if (n > 2)
            {
                BigInteger x = h * 2;

                if (x == n)
                {
                    primej = "This number is composite. The smallest divisor, greater than 1 is 2";
                    res = 2;
                }

                if (x != n) // there's been a BigInteger part in the quotient
                {
                    BigInteger k = 3;
                    BigInteger y = k;

                    BigInteger w = n / y;

                    //if (checkBox1.Checked == true)
                    //{
                    for (k = 3; k <= w; k = k + 2)
                    {
                        BigInteger qu = k / 3;   //   for big prime numbers
                        BigInteger g = k / 5;    // 

                        if (((k != qu * 3) | true | (k == 3)) && ((k != g * 5 && g != 0) | true | (k == 5)))
                        {
                            BigInteger i = n / k;
                            BigInteger t = k * i;

                            if (t == n)
                            {
                                primej = "This number is composite. The smallest divisor, greater than 1 is " + k.ToString();
                                res = 2;
                                u = true;
                                break;
                            }

                            if (t != n)
                            {
                                y = k;
                                w = n / y;
                            }
                        }
                        //}
                        //} // end of the faster loop

                        //else
                        //{
                        //    for (k = 3; k <= w; k = k + 2)
                        //    {
                        //        BigInteger i = n / k;
                        //        BigInteger t = (Math.Floor(i));

                        //        if (t == i)
                        //        {
                        //            primej = "This number is composite. The smallest divisor, greater than 1 is " + k.ToString();
                        //            u = true;
                        //            break;
                        //        }

                        //        if (t != i)
                        //        {
                        //            y = k;
                        //            w = (Math.Floor(n / y));
                        //        }
                        //    }
                        //}

                    }

                    if (u == false)
                    {
                        primej = "This number is prime.";
                        res = 3;
                    }
                }
            }
        }
    }
}
