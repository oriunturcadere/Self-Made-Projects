using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Physics
{
    class BigD
    {
        private string val = "0.000000000000000000000000000000";

        public Int64? point = null;
        public bool Negative = false;

        public bool _0 = true;

        public BigD(string v)
        {
            Value = v;
        }

        public BigD()
        {
            Value = val;
            _0 = true;
        }

        public string Value
        {
            get
            {
                return val;
            }

            set
            {
                char[] c = value.ToCharArray();
                bool b = false;
                Int64? po = null;

                for (Int64 i = 0; i < c.Length; i++)
                {
                    if (i == 0)
                    {
                        if (c[i] != '-' && c[i] != '0' && c[i] != '1' && c[i] != '2' && c[i] != '3' && c[i] != '4' && c[i] != '5' && c[i] != '6' && c[i] != '7' && c[i] != '8' && c[i] != '9')
                        {
                            b = true;
                            break;
                        }
                    }

                    else
                    {
                        if (c[i] != '0' && c[i] != '1' && c[i] != '2' && c[i] != '3' && c[i] != '4' && c[i] != '5' && c[i] != '6' && c[i] != '7' && c[i] != '8' && c[i] != '9' && c[i] != '.')
                        {
                            b = true;
                            break;
                        }

                        else
                        {
                            if (c[i] == '.')
                            {
                                po = i;
                            }
                        }
                    }
                }

                if (b)
                {
                    _0 = true;
                    value = val;
                }

                else
                {
                    _0 = false;

                    if (c[0] == '-')
                    {
                        Negative = true;
                    }

                    else
                    {
                        Negative = false;
                    }

                    point = po;

                    bool notdone = true;

                    if (notdone)
                    {
                        bool firstime = true;
                        if (point == null)
                        {
                            val = "";

                            for (Int64 i = 0; i < c.Length - 1 + 32; i++)
                            {
                                if (i < c.Length)
                                {
                                    val = val + c[i];
                                }

                                else
                                {
                                    if (firstime)
                                    {
                                        val = val + ".";
                                        firstime = false;
                                    }

                                    else
                                    {
                                        val = val + "0";
                                    }
                                }
                            }
                        }

                        else
                        {
                            val = "";

                            if (c.Length - 1 - point < 30)
                            {
                                for (Int64 i = 0; i < c.Length + 30 - (c.Length - 1 - point); i++)
                                {
                                    if (i < c.Length)
                                    {
                                        val = val + c[i];
                                    }

                                    else
                                    {
                                        val = val + "0";
                                    }
                                }
                            }

                            else
                            {
                                for (Int64 i = 0; i < point + 31; i++)
                                {
                                    if (i < c.Length)
                                    {
                                        val = val + c[i];
                                    }

                                    else
                                    {
                                        val = val + "0";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public string Add(string V2)
        {
            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";//30 places
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            BigInteger add2 = BigInteger.Parse(a) + BigInteger.Parse(b);
            string s1 = add2.ToString();
            char[] c3 = s1.ToCharArray();
            char[] c3b = new char[s1.Length + 1];
            bool stop = false;

            if (c3.Length <= 30)
            {
                int j = 31 - c3.Length;//and 3..1 here
                for (int i = 0; i < j + 1; i++)
                {
                    if (i == 0)
                    {
                        ans = "0.";
                    }

                    else if (i != j)//so no 1 here
                    {
                        bool alone = true;
                        if (alone)
                        {
                            bool behappy_on = true;
                        }

                        ans = ans + "0";
                    }

                    if (i == j)
                    {
                        ans = ans + s1;
                    }
                }
            }

            else
            {
                for (int i = c3.Length - 1; i >= 0; i--)
                {
                    if (c3.Length - i - 1 == 30)
                    {
                        ans = c3[i] + "." + ans;
                    }

                    else
                    {
                        ans = c3[i] + ans;
                    }
                }
            }

            return ans;
        }

        public string Subtract(string V2)
        {
            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            BigInteger sub2 = BigInteger.Parse(a) - BigInteger.Parse(b);
            string s1 = sub2.ToString();
            char[] c3 = s1.ToCharArray();
            char[] c3b = new char[s1.Length + 1];

            if (c3.Length <= 30)
            {
                int j = 31 - c3.Length;//and 3..1 here
                for (int i = 0; i < j + 1; i++)
                {
                    if (i == 0)
                    {
                        ans = "0.";
                    }

                    else if (i != j)//so no 1 here
                    {
                        bool alone = true;
                        if (alone)
                        {
                            bool behappy_on = true;
                        }

                        ans = ans + "0";
                    }

                    if (i == j)
                    {
                        ans = ans + s1;
                    }
                }
            }

            else
            {
                for (int i = c3.Length - 1; i >= 0; i--)
                {
                    if (c3.Length - i - 1 == 30)
                    {
                        ans = c3[i] + "." + ans;
                    }

                    else
                    {
                        ans = c3[i] + ans;
                    }
                }
            }

            return ans;
        }

        public string Multiply(string V2)
        {
            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            BigInteger sub2 = BigInteger.Parse(a) * BigInteger.Parse(b);
            string s1 = sub2.ToString();
            char[] c3 = s1.ToCharArray();

            if (s1.Length <= 30)
            {
                if (sub2 != 0)
                {
                    ans = "0.000000000000000000000000000001";
                }

                else
                {
                    ans = "0.000000000000000000000000000000";
                }
            }

            else
            {
                char[] c3b = new char[s1.Length - 30];

                if (c3.Length <= 60)
                {
                    s1 = "";
                    for (int i = 0; i < c3b.Length; i++)
                    {
                        s1 = s1 + c3[i].ToString();
                    }

                    int j = 30 - (c3.Length - 30);//30andno1
                    for (int i = 0; i < j + 1; i++)
                    {
                        if (i == 0)
                        {
                            ans = "0.";
                        }

                        else if (i != j + 1)//that's why 1 here
                        {
                            ans = ans + "0";
                        }

                        if (i == j)
                        {
                            ans = ans + s1;
                        }
                    }
                }

                else
                {
                    for (int i = c3.Length - 1 - 30; i >= 0; i--)
                    {
                        if (c3.Length - i - 1 == 60)
                        {
                            ans = c3[i] + "." + ans;
                        }

                        else
                        {
                            ans = c3[i] + ans;
                        }
                    }
                }
            }

            return ans;
        }

        public string Divide(string V2)
        {
            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            a = a + "000000000000000000000000000000";

            BigInteger sub2 = BigInteger.Parse(a) / BigInteger.Parse(b);
            string s1 = sub2.ToString();
            char[] c3 = s1.ToCharArray();
            char[] c3b = new char[s1.Length + 1];

            if (c3.Length <= 30)
            {
                int j = 31 - c3.Length;//and 3..1 here
                for (int i = 0; i < j + 1; i++)
                {
                    if (i == 0)
                    {
                        ans = "0.";
                    }

                    else if (i != j)//so no 1 here
                    {
                        bool alone = true;
                        if (alone)
                        {
                            bool behappy_on = true;
                        }

                        ans = ans + "0";
                    }

                    if (i == j)
                    {
                        ans = ans + s1;
                    }
                }
            }

            else
            {
                for (int i = c3.Length - 1; i >= 0; i--)
                {
                    if (c3.Length - i - 1 == 30)
                    {
                        ans = c3[i] + "." + ans;
                    }

                    else
                    {
                        ans = c3[i] + ans;
                    }
                }
            }

            if (rt == false)
            {
                if (ans == "0.000000000000000000000000000000")
                {
                    ans = "0.000000000000000000000000000001";
                }
            }

            return ans;
        }

        static bool rt = false;

        public string Root(string rot)
        {
            rt = true;
            string ans = "";
            BigD r = new BigD();
            BigD v = new BigD();
            BigD rot2 = new BigD();

            v.Value = Value;
            rot2.Value = rot;

            r.Value = v.Divide(rot2.Value);  //the first approximation

            BigD m1 = new BigD(), m2 = new BigD();//the initial limits
            m2.Value = v.Value;

            BigD u = new BigD();

            if (v.SmallerEquals("1") && v.Greater("0"))
            {
                m2.Value = "1";
            }

            do
            {
                u.Value = r.Value;
                BigD i = new BigD();
                for (i.Value = "1"; i.Smaller(rot2.Value); i.Value = i.Add("1"))
                {
                    u.Value = u.Multiply(r.Value);
                }

                if (v.Equals(u.Value))
                {
                    break;
                }

                if (v.Smaller(u.Value))//the product is greater than the number 
                {
                    m2.Value = r.Value;//the new upper limit

                    BigD h1 = new BigD();
                    h1.Value = m2.Subtract(m1.Value);
                    h1.Value = h1.Divide("2.000000000000000000000000000000");

                    if (m2.Value == m2.Subtract(h1.Value))
                    {
                        break;
                    }

                    r.Value = m2.Subtract(h1.Value);//the new r value
                }

                if (v.Greater(u.Value))//the product is less than the number 
                {
                    m1.Value = r.Value;

                    BigD h1 = new BigD();
                    h1.Value = m2.Subtract(m1.Value);
                    h1.Value = h1.Divide("2.000000000000000000000000000000");

                    if (m1.Value == m1.Add(h1.Value))
                    {
                        break;
                    }

                    r.Value = m1.Add(h1.Value);
                }
            }
            while (m2.Value != m1.Value);

            ans = r.Value;

            rt = false;
            return ans;
        }

        public bool Greater(string V2)
        {
            bool tf = false;

            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";//30 places
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = BigInteger.Parse(b);

            if (aa > bb)
            {
                tf = true;
            }

            else
            {
                tf = false;
            }

            return tf;
        }

        public bool Smaller(string V2)
        {
            bool tf = false;

            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";//30 places
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = BigInteger.Parse(b);

            if (aa < bb)
            {
                tf = true;
            }

            else
            {
                tf = false;
            }

            return tf;
        }

        public bool Equals(string V2)
        {
            bool tf = false;

            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";//30 places
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = BigInteger.Parse(b);

            if (aa == bb)
            {
                tf = true;
            }

            else
            {
                tf = false;
            }

            return tf;
        }

        public bool GreaterEquals(string V2)
        {
            bool tf = false;

            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";//30 places
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = BigInteger.Parse(b);

            if (aa >= bb)
            {
                tf = true;
            }

            else
            {
                tf = false;
            }

            return tf;
        }

        public bool SmallerEquals(string V2)
        {
            bool tf = false;

            string ans = "";

            char[] c1 = Value.ToCharArray();
            string a = "";
            bool nopoint = true;

            char[] c2 = V2.ToCharArray();
            string b = "";
            bool nocap = true;

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != '.')
                {
                    a = a + c1[i];
                }

                else
                {
                    nopoint = false;
                }
            }

            if (nopoint)
            {
                bool tisend = true;
                a = a + "000000000000000000000000000000";//30 places
            }

            for (int i = 0; i < c2.Length; i++)
            {
                if (c2[i] != '.')
                {
                    b = b + c2[i];
                }

                else
                {
                    nocap = false;
                }
            }

            if (nocap)
            {
                bool fact = true;
                b = b + "000000000000000000000000000000";
            }

            BigInteger aa = BigInteger.Parse(a);
            BigInteger bb = BigInteger.Parse(b);

            if (aa <= bb)
            {
                tf = true;
            }

            else
            {
                tf = false;
            }

            return tf;
        }

        public string FormatN()
        {
            string a = Value;
            char[] c = a.ToCharArray();
            string ans = "";

            int p = -1;

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == '.')
                {
                    p = i;
                    break;
                }
            }

            if (p == -1)
            {
                if (c.Length > 3)
                {
                    for (int i = c.Length - 3; i > -3; i = i - 3)
                    {
                        if (i > 0)
                        {
                            ans = "," + c[i].ToString() + c[i + 1].ToString() + c[i + 2].ToString() + ans;
                        }

                        if (i == 0)
                        {
                            ans = c[i].ToString() + c[i + 1].ToString() + c[i + 2].ToString() + ans;
                        }

                        if (i == -2)
                        {
                            ans = c[0].ToString() + ans;
                        }

                        if (i == -1)
                        {
                            ans = c[0].ToString() + c[1].ToString() + ans;
                        }
                    }
                }

                else
                {
                    ans = a;
                }
            }

            else
            {
                if (c.Length - (c.Length - (p + 1)) >= 3)
                {
                    for (int i = p; i < c.Length; i++)
                    {
                        ans = ans + c[i].ToString();
                    }

                    for (int i = (c.Length - (c.Length - (p))) - 3; i > -3; i = i - 3)
                    {
                        if (i > 0)
                        {
                            ans = "," + c[i].ToString() + c[i + 1].ToString() + c[i + 2].ToString() + ans;
                        }

                        if (i == 0)
                        {
                            ans = c[i].ToString() + c[i + 1].ToString() + c[i + 2].ToString() + ans;
                        }

                        if (i == -2)
                        {
                            ans = c[0].ToString() + ans;
                        }

                        if (i == -1)
                        {
                            ans = c[0].ToString() + c[1].ToString() + ans;
                        }
                    }
                }

                else
                {
                    ans = a;
                }
            }

            return ans;
        }
        public static BigD ReverseN(string d)
        {
            BigD unf = new BigD("0");

            string h = "";
            char[] c = d.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != ',')
                {
                    h = h + c[i].ToString();
                }
            }

            unf.Value = h;

            return unf;
        }
    }
}
