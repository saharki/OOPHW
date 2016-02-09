using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_10_2014_1_sahar
{
    class Rational
    {
        private int sign;
        private int num, denom;
        public int Sign
        {
            get
            {
                return sign;
            }
        }
        public int Num
        {
            get
            {
                return num;
            }
        }
        public int Denom
        {
            get
            {
                return denom;
            }
        }

        private void reduce()
        {
            int n = gcd(num, denom);
            num /= n;
            denom /= n;
        }
        public static explicit operator Rational(double d)
        {
            Rational temp = new Rational();
            if (d == 0)
            {
                temp.sign = 0;
                temp.num = 0;
                temp.denom = 1;
            }
            else
            if (d > 0)
                temp.sign = 1;
            else
            {
                temp.sign = -1;
                d = -d;
            } // else
            temp.num = (int)(d * 100000);
            temp.denom = 100000;
            temp.reduce();
            return temp;
        }
        public static explicit operator Rational(int d)
        {
            Rational temp = new Rational();
            if (d == 0)
            {
                temp.sign = 0;
                temp.num = 0;
                temp.denom = 1;
            }
            else
            if (d > 0)
                temp.sign = 1;
            else
            {
                temp.sign = -1;
                d = -d;
            } // else
            temp.num = d;
            temp.denom = 1;
            return temp;
        }


        public static Rational operator +(Rational r1, Rational r2)
        {
            double d1, d2;
            d1 = (double)r1.num * r1.sign / r1.denom;
            d2 = (double)r2.num * r2.sign / r2.denom;
            d1 += d2;
            Rational temp;
            temp = (Rational)d1;
            return temp;
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            double d1, d2;
            d1 = (double)r1.num * r1.sign / r1.denom;
            d2 = (double)r2.num * r2.sign / r2.denom;
            d1 -= d2;
            Rational temp;
            temp = (Rational)d1;
            return temp;
        }
        public static Rational operator *(Rational r1, Rational r2)
        {
            double d1, d2;
            d1 = (double)r1.num * r1.sign / r1.denom;
            d2 = (double)r2.num * r2.sign / r2.denom;
            d1 *= d2;
            Rational temp;
            temp = (Rational)d1;
            return temp;
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            double d1, d2;
            d1 = (double)r1.num * r1.sign / r1.denom;
            d2 = (double)r2.num * r2.sign / r2.denom;
            return d1 > d2;
        }
        public static bool operator <(Rational r1, Rational r2)
        {
            double d1, d2;
            d1 = (double)r1.num * r1.sign / r1.denom;
            d2 = (double)r2.num * r2.sign / r2.denom;
            return d1 < d2;
        }
        public string show()
        {
            string str;
            str = (sign * num) + "/" + denom;
            return str;
        }

        static int gcd(int a, int b)
        {
            return b == 0 ? a : gcd(b, a % b);
        }
    }
}
