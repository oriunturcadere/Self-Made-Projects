using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Simple_Calc
{
    class GCDiv
    {
        public void GreatestCD(BigInteger c, BigInteger d, out BigInteger ans)
        {
            ans = 1;

            if (d > c)
            {
                for (BigInteger i = ans; i < c; i++)
                {
                    BigInteger h3 = d / i;

                    BigInteger h2 = c / i;

                    if (h3 != 0 && h2 != 0)
                    {
                        if (d == h3 * i && c == h2 * i)
                        {
                            ans = i;
                        }
                    }
                }
            }

            if (c > d)
            {
                for (BigInteger i = ans; i < d; i++)
                {
                    BigInteger h3 = d / i;

                    BigInteger h2 = c / i;

                    if (h3 != 0 && h2 != 0)
                    {
                        if (d == h3 * i && c == h2 * i)
                        {
                            ans = i;
                        }
                    }
                }
            }

            BigInteger h = 0;

            if (d > c)
            {
                h = d / c;
            }

            if (d < c)
            {
                h = c / d;
            }

            if (c > d)
            {
                if (c == d * h)
                {
                    ans = d;
                }
            }

            if (d > c)
            {
                if (d == c * h)
                {
                    ans = c;
                }
            }


            if (d == c)
            {
                ans = d;
            }
        }
    }
}
