using System;
using System.Collections.Generic;
using System.Text;

namespace Physics
{
    class Root
    {
        public void Rt(decimal w, decimal rot, out decimal r)
        {
            r = w / rot;  //the first approximation

            decimal m1 = 0, m2 = w;//the initial limits
            decimal u = 0;

            if (w <= 1 && w > 0)
            {
                m2 = 1;
            }

            do
            {
                u = r;
                for (int i = 1; i < rot; i++)
                {
                    u = u * r;
                }

                if (w == u)
                {
                    break;
                }

                if (w < u)//the product is greater than the number 
                {
                    m2 = r;//the new upper limit

                    if (m2 == m2 - ((m2 - m1) / 2))
                    {
                        break;
                    }

                    r = m2 - ((m2 - m1) / 2);//the new r value
                }

                if (w > u)//the product is less than the number 
                {
                    m1 = r;

                    if (m1 == m1 + ((m2 - m1) / 2))
                    {
                        break;
                    }

                    r = m1 + ((m2 - m1) / 2);
                }
            }
            while (m2 != m1);
        }
    }
}
