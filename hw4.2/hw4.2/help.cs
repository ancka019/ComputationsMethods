using System;
using System.Collections.Generic;
using System.Text;

namespace hw4._2
{
    public class help
    {
        public double val0;
        public double val;
        public double vall;
        public double a;
        public double b;
        public int m;
        public int l;
        public double W;
        public double Q;
        public double Z;
        public double W1;
        public double Q1;
        public double Z1;
        public double J;

        public double f(double x)
        {
            return (double)-Math.Cos(x) + Math.Pow(Math.E, x);
            //return 5 ;//const
            //return 5 * x;//1 power
            //return 5 * Math.Pow(x, 3);//3 power
        }
        public double intf(double x)
        {
            return (double)(-Math.Sin(x) + Math.Pow(Math.E, x));
            //return 5 * x;//const
            //return 5 * Math.Pow(x, 2) / 2;//1 power
            //return 5 * Math.Pow(x, 4) / 4;//3 power
        }
        public void value()
        {
            val0 = (double)intf(b) - intf(a);
            Console.WriteLine("значение интеграла(J):" + val0);
        }

        public void left(double he, int ch)
        {
            Z = 0;
            W = 0;
            val = 0;
            for (int i = 1; i < m; i++)
            {
                double x = (double)a + he * i;
                //val = (double)val + f(x);
                W = (double)W + f(x);
            }
            Z += f(a);
            //val = (double)h * val;
            val = (double)he * (W + Z);
            if (ch == 1)
            {
                Z1 = 0;
                W1 = 0;
                vall = 0;
                for (int i = 1; i < m * l; i++)
                {
                    double x = (double)a + he / l * i;
                    //val = (double)val + f(x);
                    W1 = (double)W1 + f(x);
                }
                Z1 += f(a);
                vall = (double)he / l * (W1 + Z1);
                J = (Math.Pow(l, 1) * vall - val) / (Math.Pow(l, 1) - 1);
            }

            Console.WriteLine("значение интеграла по составной формуле левых прямоугольников(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
            Console.WriteLine("теоретическая погрешность:" + (double)0.5 * Math.Pow(Math.E, b) * (b - a) * he);
            if (ch == 1)
            {
                Console.WriteLine("!4.3! значение интеграла по составной формуле левых прямоугольников(J(h/l)):" + vall);
                Console.WriteLine("абсолютная фактическая погрешность |J-J(h/l)|:" + Math.Abs(val0 - vall));
                Console.WriteLine();
                Console.WriteLine("!4.3! уточненное значение интеграла по принципу Рунге(J~):" + J);
                Console.WriteLine("абсолютная фактическая погрешность |J-J~|:" + Math.Abs(val0 - J));
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void right(double he, int ch)
        {
            val = 0;
            //for (int i = 1; i < m+1; i++)
            //{
            //    val = (double)val + f(a + h * i);
            //}
            val = (double)he * (W + f(b));
            Z += f(b);
            if (ch == 1)
            {
                vall = 0;
                vall = (double)he / l * (W1 + f(b));
                Z1 += f(b);
                J = (Math.Pow(l, 1) * vall - val) / (Math.Pow(l, 1) - 1);
            }
            Console.WriteLine("значение интеграла по составной формуле правых прямоугольников(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
            Console.WriteLine("теоретическая погрешность:" + (double)0.5 * Math.Pow(Math.E, b) * (b - a) * he);
            if (ch == 1)
            {
                Console.WriteLine("!4.3! значение интеграла по составной формуле правых прямоугольников(J(h/l)):" + vall);
                Console.WriteLine("абсолютная фактическая погрешность |J-J(h/l)|:" + Math.Abs(val0 - vall));
                Console.WriteLine();
                Console.WriteLine("!4.3! уточненное значение интеграла по принципу Рунге(J~):" + J);
                Console.WriteLine("абсолютная фактическая погрешность |J-J~|:" + Math.Abs(val0 - J));
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void middle(double he, int ch)
        {
            Q = 0;
            val = 0;
            for (int i = 0; i < m; i++)
            {
                val = (double)val + f(a + he * i + he / 2);
            }
            Q = val;
            val = (double)he * val;
            if (ch == 1)
            {
                Q1 = 0;
                vall = 0;
                for (int i = 0; i < m * l; i++)
                {
                    vall = (double)vall + f(a + he / l * i + he / l / 2);
                }
                Q1 = vall;
                vall = (double)he / l * vall;
                J = (Math.Pow(l, 2) * vall - val) / (Math.Pow(l, 2) - 1);
            }
            Console.WriteLine("значение интеграла по составной формуле средних прямоугольников(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
            Console.WriteLine("теоретическая погрешность:" + (double)(1 / 24.0) * Math.Pow(Math.E, b) * (b - a) * Math.Pow(he, 2));
            if (ch == 1)
            {
                Console.WriteLine("!4.3! значение интеграла по составной формуле средних прямоугольников(J(h/l)):" + vall);
                Console.WriteLine("абсолютная фактическая погрешность |J-J(h/l)|:" + Math.Abs(val0 - vall));
                Console.WriteLine();
                Console.WriteLine("!4.3! уточненное значение интеграла по принципу Рунге(J~):" + J);
                Console.WriteLine("абсолютная фактическая погрешность |J-J~|:" + Math.Abs(val0 - J));
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void trap(double he, int ch)
        {
            val = 0;
            //val = val + f(a);
            //for (int i = 1; i < m; i++)
            //{
            //    val = (double)val + 2*f(a + h * i);
            //}
            //val = val + f(b);
            val = (double)(he / 2f) * (Z + 2 * W);
            if (ch == 1)
            {
                vall = 0;
                vall = (double)(he / l / 2f) * (Z1 + 2 * W1);
                J = (Math.Pow(l, 2) * vall - val) / (Math.Pow(l, 2) - 1);
            }
            Console.WriteLine("значение интеграла по составной формуле трапеций(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
            Console.WriteLine("теоретическая погрешность:" + (double)(1 / 12.0) * Math.Pow(Math.E, b) * (b - a) * Math.Pow(he, 2));
            if (ch == 1)
            {
                Console.WriteLine("!4.3! значение интеграла по составной формуле трапеций(J(h/l)):" + vall);
                Console.WriteLine("абсолютная фактическая погрешность |J-J(h/l)|:" + Math.Abs(val0 - vall));
                Console.WriteLine();
                Console.WriteLine("!4.3! уточненное значение интеграла по принципу Рунге(J~):" + J);
                Console.WriteLine("абсолютная фактическая погрешность |J-J~|:" + Math.Abs(val0 - J));
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public void simp(double he, int ch)
        {
            if (m % 2 == 1) m++;
            val = 0;
            //val = val + f(a);
            //for (int i = 1; i < m; i++)
            //{
            //    if (i % 2 == 1) { val = (double)val + 4 * f(a + h * i); } else
            //    { val = (double)val + 2 * f(a + h * i); }
            //}
            //val = val + f(b);
            val = (double)(he / 6.0) * (Z + 2 * W + 4 * Q);
            if (ch == 1)
            {
                vall = 0;
                vall = (double)(he / l / 6.0) * (Z1 + 2 * W1 + 4 * Q1);
                //J = (Math.Pow(l, 4) * vall - val) / (Math.Pow(l, 4) - 1);
                J = vall + (vall - val) / (Math.Pow(l, 4) - 1);
            }
            Console.WriteLine("значение интеграла по составной формуле Симпсона(J(h)):" + val);
            Console.WriteLine("абсолютная фактическая погрешность |J-J(h)|:" + Math.Abs(val0 - val));
            Console.WriteLine("теоретическая погрешность:" + (double)(1 / 2880.0) * Math.Pow(Math.E, b) * (b - a) * Math.Pow(he, 4));
            if (ch == 1)
            {
                Console.WriteLine("!4.3! значение интеграла по составной формуле Симпсона(J(h/l)):" + vall);
                Console.WriteLine("абсолютная фактическая погрешность |J-J(h/l)|:" + Math.Abs(val0 - vall));
                Console.WriteLine();
                Console.WriteLine("!4.3! уточненное значение интеграла по принципу Рунге(J~):" + J);
                Console.WriteLine("абсолютная фактическая погрешность |J-J~|:" + Math.Abs(val0 - J));
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
