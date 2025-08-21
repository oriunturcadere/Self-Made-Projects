using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace My_paint
{
    class DrawBMP
    {
        public Bitmap DrawLine(Bitmap bmp, int[] p1, int[] p2)
        {
            if (p1[0] > p1[0])
            {
                int[] p3 = p1;
                p1 = p2;
                p2 = p3;
            }

            int a = Math.Abs(p2[0] - p1[0]) + 1;
            int b = Math.Abs(p2[1] - p1[1]) + 1;

            if (a < b)
            {

            }

            else
            {

            }

            return bmp;
        }
    }
}
