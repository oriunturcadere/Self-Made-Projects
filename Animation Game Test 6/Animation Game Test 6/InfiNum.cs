using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.CodeDom;

namespace Animation_Game_Test_6
{
    class InfiNum
    {
        private string val = "0" + zeroAFTp;

        public Int64? point = null;
        public bool Negative = false;

        public bool _0 = true;

        public static string zeroAFTp = "0000000000";//000000000000000000000000000000

        public InfiNum InfiNum_Value
        {
            get
            {
                return new InfiNum(val);
            }

            set { }
        }

        public static InfiNum num (decimal n) // instead of declaring 'new InfiNum("1")' every time
        {
            return new InfiNum(n.ToString());
        }

        public InfiNum(string v)
        {
            Value = v;
        }

        public InfiNum()
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

                if (value != "")
                {


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
                }

                else
                {
                    b = true;
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

                            for (Int64 i = 0; i < c.Length - 1 + zeroAFTp.Length + 2; i++)
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

                            if (c.Length - 1 - point < zeroAFTp.Length)
                            {
                                for (Int64 i = 0; i < c.Length + zeroAFTp.Length - (c.Length - 1 - point); i++)
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
                                for (Int64 i = 0; i < point + zeroAFTp.Length + 1; i++)
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
                a = a + zeroAFTp;//zeroAFTp.Length places
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
                b = b + zeroAFTp;
            }

            BigInteger add2 = BigInteger.Parse(a) + BigInteger.Parse(b);
            string s1 = add2.ToString();
            char[] c3 = s1.ToCharArray();

            if (c3.Length <= zeroAFTp.Length || (c3.Length == zeroAFTp.Length + 1 && c3[0] == '-'))
            {
                int j = zeroAFTp.Length - c3.Length;//and 3..1 here

                if (c3[0] == '-')
                {
                    j++;

                    ans = ans + "-";

                    s1 = "";

                    for (int i = 1; i < c3.Length; i++)
                    {
                        s1 = s1 + c3[i].ToString();
                    }
                }

                ans = ans + "0.";

                for (int i = 0; i < j + 1; i++)
                {
                    if (i != j)//so no 1 here
                    {
                        bool alone = true;
                        if (alone)
                        {
                            bool behappy_on = true;
                        }

                        ans = ans + "0";
                    }
                }

                ans = ans + s1;
            }

            else
            {
                for (int i = c3.Length - 1; i >= 0; i--)
                {
                    if (c3.Length - i - 1 == zeroAFTp.Length)
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
                a = a + zeroAFTp;
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
                b = b + zeroAFTp;
            }

            BigInteger sub2 = BigInteger.Parse(a) - BigInteger.Parse(b);
            string s1 = sub2.ToString();
            char[] c3 = s1.ToCharArray();

            if (c3.Length <= zeroAFTp.Length || (c3.Length == zeroAFTp.Length + 1 && c3[0] == '-'))
            {
                int j = zeroAFTp.Length - c3.Length;//and 3..1 here

                if (c3[0] == '-')
                {
                    j++;

                    ans = ans + "-";

                    s1 = "";

                    for (int i = 1; i < c3.Length; i++)
                    {
                        s1 = s1 + c3[i].ToString();
                    }
                }

                ans = ans + "0.";

                for (int i = 0; i < j + 1; i++)
                {
                    if (i != j)//so no 1 here
                    {
                        bool alone = true;
                        if (alone)
                        {
                            bool behappy_on = true;
                        }

                        ans = ans + "0";
                    }
                }

                ans = ans + s1;
            }

            else
            {
                for (int i = c3.Length - 1; i >= 0; i--)
                {
                    if (c3.Length - i - 1 == zeroAFTp.Length)
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
                a = a + zeroAFTp;
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
                b = b + zeroAFTp;
            }

            BigInteger sub2 = BigInteger.Parse(a) * BigInteger.Parse(b);
            string s1 = sub2.ToString();
            char[] c3 = s1.ToCharArray();

            if (s1.Length <= zeroAFTp.Length)
            {
                if (sub2 != 0)
                {
                    ans = "0." + zeroAFTp.Substring(0, zeroAFTp.Length - 2) + "1";
                }

                else
                {
                    ans = "0." + zeroAFTp;
                }
            }

            else
            {
                if (c3.Length <= zeroAFTp.Length * 2 || (c3.Length == zeroAFTp.Length * 2 + 1 && c3[0] == '-'))
                {
                    int j = zeroAFTp.Length - (c3.Length - zeroAFTp.Length);//zeroAFTp.Lengthandno1

                    if (c3[0] == '-')
                    {
                        j++;

                        ans = ans + "-";

                        s1 = "";

                        for (int i = 1; i < c3.Length; i++)
                        {
                            s1 = s1 + c3[i].ToString();
                        }
                    }

                    ans = ans + "0.";

                    for (int i = 0; i < j + 1; i++)
                    {
                        if (i != j)//that's why 1 here
                        {
                            ans = ans + "0";
                        }
                    }

                    ans = ans + s1;
                }

                else
                {
                    for (int i = c3.Length - 1 - zeroAFTp.Length; i >= 0; i--)
                    {
                        if (c3.Length - i - 1 == zeroAFTp.Length * 2)
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
                a = a + zeroAFTp;
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
                b = b + zeroAFTp;
            }

            a = a + zeroAFTp;

            BigInteger sub2 = BigInteger.Parse(a) / BigInteger.Parse(b);
            string s1 = sub2.ToString();
            char[] c3 = s1.ToCharArray();

            if (c3.Length <= zeroAFTp.Length || (c3.Length == zeroAFTp.Length + 1 && c3[0] == '-'))
            {
                int j = zeroAFTp.Length - c3.Length;//and 3..1 here //j is how many zeros to add
                if (c3[0] == '-')
                {
                    j++;

                    ans = ans + "-";

                    s1 = "";

                    for (int i = 1; i < c3.Length; i++)
                    {
                        s1 = s1 + c3[i].ToString();
                    }
                }

                ans = ans + "0.";

                for (int i = 0; i < j + 1; i++)
                {
                    if (i != j)//so no 1 here
                    {
                        bool alone = true;
                        if (alone)
                        {
                            bool behappy_on = true;
                        }

                        ans = ans + "0";
                    }
                }

                ans = ans + s1;
            }

            else
            {
                for (int i = c3.Length - 1; i >= 0; i--)
                {
                    if (c3.Length - i - 1 == zeroAFTp.Length)
                    {
                        ans = c3[i] + "." + ans;
                    }

                    else
                    {
                        ans = c3[i] + ans;
                    }
                }
            }

            if (ans == "0." + zeroAFTp && InfiNum_Value != new InfiNum("0"))
            {
                string t = "";

                for (int i = 0; i < ans.Length - 1; i++)
                {
                    t += ans[i];
                }

                t += "1";

                ans = t;
            }

            return ans;
        }

        public string Root(string rot)
        {
            string ans = "";
            InfiNum r = new InfiNum();
            InfiNum v = new InfiNum();
            InfiNum rot2 = new InfiNum();

            v.Value = Value;
            rot2.Value = rot;

            r.Value = v.Divide(rot2.Value);  //the first approximation

            InfiNum m1 = new InfiNum(), m2 = new InfiNum();//the initial limits
            m2.Value = v.Value;

            InfiNum u = new InfiNum();

            if (v.SmallerEquals("1") && v.Greater("0"))
            {
                m2.Value = "1";
            }

            do
            {
                u.Value = r.Value;
                InfiNum i = new InfiNum();
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

                    InfiNum h1 = new InfiNum(((m1 + m2) / new InfiNum("2")).Value);

                    if (m2.Value == h1.Value)
                    {
                        break;
                    }

                    r.Value = h1.Value;//the new r value
                }

                if (v.Greater(u.Value))//the product is less than the number 
                {
                    m1.Value = r.Value;

                    InfiNum h1 = new InfiNum(((m1 + m2) / new InfiNum("2")).Value);

                    if (m1.Value == h1.Value)
                    {
                        break;
                    }

                    r.Value = h1.Value;
                }
            }
            while (m2.Value != m1.Value);

            ans = r.Value;

            return ans;
        }

        public string Pow(string p)
        {
            string ans = "";

            InfiNum a = new InfiNum(Value);
            InfiNum b = new InfiNum(p);

            if (b.Smaller("1"))
            {
                if (b.Value == "0")
                {
                    ans = "1";
                }

                else
                {
                    ans = a.Value;

                    InfiNum t = new InfiNum();
                    t.Value = a.Value;

                    InfiNum i1 = new InfiNum();

                    InfiNum absh1 = new InfiNum();
                    absh1.Value = i1.Subtract(b.Value);

                    for (i1.Value = "1"; i1.Smaller(absh1.Value); i1.Value = i1.Add("1"))
                    {
                        t.Value = t.Multiply(a.Value);
                    }

                    ans = a.Divide(t.Value);
                }
            }

            else
            {
                ans = a.Value;

                InfiNum i1 = new InfiNum();

                for (i1.Value = "1"; i1.Smaller(b.Value); i1.Value = i1.Add("1"))
                {
                    InfiNum a2 = new InfiNum();
                    a2.Value = ans;
                    ans = a2.Multiply(a.Value);
                }
            }

            return ans;
        }

        public static string Pow(string V, string p)
        {
            string ans = "";

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(p);
            ans = a.Pow(b.Value);

            return ans;
        }

        public static string Add(string V, string V2)
        {
            string ans = "";

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.Add(b.Value);

            return ans;
        }

        public static string Subtract(string V, string V2)
        {
            string ans = "";

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.Subtract(b.Value);

            return ans;
        }

        public static string Multiply(string V, string V2)
        {
            string ans = "";

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.Multiply(b.Value);

            return ans;
        }

        public static string Divide(string V, string V2)
        {
            string ans = "";

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.Divide(b.Value);

            return ans;
        }

        public static string Root(string V, string rot)
        {
            string ans = "";

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(rot);
            ans = a.Root(b.Value);

            return ans;
        }

        public static bool Greater(string V, string V2)
        {
            bool ans = false;

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.Greater(b.Value);

            return ans;
        }

        public static bool Smaller(string V, string V2)
        {
            bool ans = false;

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.Smaller(b.Value);

            return ans;
        }

        public static bool Equals(string V, string V2)
        {
            bool ans = false;

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.Equals(b.Value);

            return ans;
        }

        public static bool GreaterEquals(string V, string V2)
        {
            bool ans = false;

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.GreaterEquals(b.Value);

            return ans;
        }

        public static bool SmallerEquals(string V, string V2)
        {
            bool ans = false;

            InfiNum a = new InfiNum(V);
            InfiNum b = new InfiNum(V2);
            ans = a.SmallerEquals(b.Value);

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
                a = a + zeroAFTp;//zeroAFTp.Length places
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
                b = b + zeroAFTp;
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
                a = a + zeroAFTp;//zeroAFTp.Length places
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
                b = b + zeroAFTp;
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
                a = a + zeroAFTp;//zeroAFTp.Length places
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
                b = b + zeroAFTp;
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
                a = a + zeroAFTp;//zeroAFTp.Length places
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
                b = b + zeroAFTp;
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
                a = a + zeroAFTp;//zeroAFTp.Length places
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
                b = b + zeroAFTp;
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

        public string Abs()
        {
            if (Negative)
            {
                return Multiply("-1");
            }

            else
            {
                return Value;
            }
        }

        public static string Abs(string V)
        {
            string ans = "";

            InfiNum a = new InfiNum(V);
            ans = a.Abs();

            return ans;
        }

        public static InfiNum Abs(InfiNum V)
        {
            return new InfiNum(V.Abs());
        }

        public InfiNum Floor()
        {
            string temp = "";

            char[] c = Value.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != '.')
                {
                    temp = temp + c[i].ToString();
                }

                else
                {
                    break;
                }
            }

            return new InfiNum(temp);
        }

        public static string Floor(string a)
        {
            string temp = "";

            InfiNum a2 = new InfiNum(a);

            char[] c = a.ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != '.')
                {
                    temp = temp + c[i].ToString();
                }

                else
                {
                    break;
                }
            }

            return temp;
        }

        public static InfiNum Floor(InfiNum a)
        {
            return a.Floor();
        }

        public static InfiNum operator +(InfiNum a, InfiNum b)
        {
            return new InfiNum(a.Add(b.Value));
        }

        public static InfiNum operator -(InfiNum a, InfiNum b)
        {
            return new InfiNum(a.Subtract(b.Value));
        }
        public static InfiNum operator -(InfiNum a)
        {
            return new InfiNum(a.Multiply("-1"));
        }

        public static InfiNum operator *(InfiNum a, InfiNum b)
        {
            return new InfiNum(a.Multiply(b.Value));
        }

        public static InfiNum operator /(InfiNum a, InfiNum b)
        {
            return new InfiNum(a.Divide(b.Value));
        }

        public static InfiNum operator ^(InfiNum a, InfiNum b) // power -- (x ^ 2) + 1 is not the same as x ^ 2 + 1 ... sadly
        {
            return new InfiNum(a.Pow(b.Value));
        }

        public static InfiNum operator &(InfiNum a, InfiNum b) // root -- (x & 2) + 1 is not the same as x & 2 + 1 ... sadly
        {
            return new InfiNum(a.Root(b.Value));
        }

        public static bool operator >(InfiNum a, InfiNum b)
        {
            return a.Greater(b.Value);
        }

        public static bool operator <(InfiNum a, InfiNum b)
        {

            return a.Smaller(b.Value);
        }

        public static bool operator ==(InfiNum a, InfiNum b)
        {
            return a.Equals(b.Value);
        }

        public static bool operator !=(InfiNum a, InfiNum b)
        {
            return !a.Equals(b.Value);
        }

        public static bool operator >=(InfiNum a, InfiNum b)
        {
            return a.GreaterEquals(b.Value);
        }

        public static bool operator <=(InfiNum a, InfiNum b)
        {
            return a.SmallerEquals(b.Value);
        }

        public InfiNum Round(int precision)
        {
            return Round(InfiNum_Value, precision);
        }

        public static InfiNum Round(InfiNum num, int precision) // precision after decimal point
        {
            precision -= 1;

            string ans = "";

            string a = "";
            string b = "";
            string c = "";

            for (int i = 0; i < num.Value.Length; i++)
            {
                if (num.Value[i..(i + 1)] != ".")
                {
                    a += num.Value[i..(i+1)];
                }
            }

            b = a[(a.Length - (zeroAFTp.Length - precision) + 1)..(a.Length)];

            for (int i = a.Length - (zeroAFTp.Length - precision) + 1; i < a.Length; i++)
            {
                if (i == a.Length - (zeroAFTp.Length - precision) + 1)
                {
                    c = "5";
                }

                else
                {
                    c += "0";
                }
            }

            if (new InfiNum(b) <= new InfiNum(c))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    string add = "";

                    if (i == (a.Length - (zeroAFTp.Length - precision)))
                    {
                        add = (Convert.ToInt32(a[(a.Length - (zeroAFTp.Length - precision))..(a.Length - (zeroAFTp.Length - precision) + 1)]) + 0).ToString();
                    }

                    if (i < (a.Length - (zeroAFTp.Length - precision)))
                    {
                        add = a[i..(i + 1)];
                    }

                    if (i > (a.Length - (zeroAFTp.Length - precision)))
                    {
                        add = "0";
                    }

                    if (i == a.Length - zeroAFTp.Length)
                    {
                        ans += "." + add;
                    }

                    else
                    {
                        ans += add;
                    }
                }
            }

            if (new InfiNum(b) > new InfiNum(c))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    string add = "";

                    if (i == (a.Length - (zeroAFTp.Length - precision)))
                    {
                        add = (Convert.ToInt32(a[(a.Length - (zeroAFTp.Length - precision))..(a.Length - (zeroAFTp.Length - precision) + 1)]) + 1).ToString();
                    }

                    if (i < (a.Length - (zeroAFTp.Length - precision)))
                    {
                        add = a[i..(i + 1)];
                    }

                    if (i > (a.Length - (zeroAFTp.Length - precision)))
                    {
                        add = "0";
                    }

                    if (i == a.Length - zeroAFTp.Length)
                    {
                        ans += "." + add;
                    }

                    else
                    {
                        ans += add;
                    }
                }
            }

            return new InfiNum(ans);
        }
    }
}

