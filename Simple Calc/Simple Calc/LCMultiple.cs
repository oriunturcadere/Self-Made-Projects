using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Simple_Calc
{
    class LCMultiple
    {
        public void LeastCM(BigInteger c, BigInteger d, out BigInteger ans)
        {
            ans = c * d;

            if (d > c)
            {
                for (BigInteger i = ans; i > d; i--)
                {
                    BigInteger h3 = i / d;

                    BigInteger h2 = i / c;

                    if (h3 != 0 && h2 != 0)
                    {
                        if (i == h3 * d && i == h2 * c)
                        {
                            ans = i;
                        }
                    }
                }
            }

            if (c > d)
            {
                for (BigInteger i = ans; i > c; i--)
                {
                    BigInteger h3 = i / d;

                    BigInteger h2 = i / c;

                    if (h3 != 0 && h2 != 0)
                    {
                        if (i == h3 * d && i == h2 * c)
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
                    ans = c;
                }
            }

            if (d > c)
            {
                if (d == c * h)
                {
                    ans = d;
                }
            }
        }
    }
}
