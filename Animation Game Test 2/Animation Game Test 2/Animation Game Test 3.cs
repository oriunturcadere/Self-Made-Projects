using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Animation_Game_Test_2
{
    class Animation_Game_Test_3
    {
        public bool asyncstop = false;

        string[] perc2 = new string[0];
        int[] r2 = new int[0];

        public Bitmap game2 = new Bitmap(200, 200);

        public int l;

        int num = 0;

        public async void NewGenPic(Bitmap game, bool normal, int x2, int y2, string[] colors, string[] ht, string[] perc, int[] r)
        {
            asyncstop = true;

            perc2 = perc;
            r2 = r;
            game2 = game;

            Stopwatch t = new Stopwatch();
            t.Start();
            l = 0;
            for (l = 1; t.ElapsedTicks <= Convert.ToInt32(ht[1]); l++)
            {
                if (l < r.Length)
                {
                    num = l;
                }

                else
                {
                    num = l - l / r.Length * r.Length;
                }
            }

            t.Stop();
            t.Reset();

            string[] rgb = colors[r[num]].Split();

            if (normal == true)
            {
                game2.SetPixel(x2, y2, Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2])));
            }

            else
            {
                game2.SetPixel(y2, x2, Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2])));
            }

            asyncstop = false;
        }

        private async Task GetPixel()
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            int l;
            for (l = 1; t.ElapsedTicks <= 1000; l++)
            {
                if (l < r2.Length)
                {
                    num = l;
                }

                else
                {
                    num = l - l / r2.Length * r2.Length;
                }
            }

            t.Stop();
            t.Reset();
        }
    }
}
