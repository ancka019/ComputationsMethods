using System;

namespace hw1
{
    internal class Program
    {
        public static void Main()
        {
            int A = -8;
            int B = 2;
            double EPS = 0.00001;
            int N = 10;

            double f(double x)
            {
                double res = 10 * Math.Cos(x) - Math.Pow(x, 2)* 0.1;
                return res;
            }

            double df(double x)
            {
                double res = - 10* Math.Sin(x) - x / 5;
                return res;
            }

            Console.WriteLine("ЧИСЛЕННЫЕ МЕТОДЫ РЕШЕНИЯ НЕЛИНЕЙНЫХ УРАВНЕНИЙ");
            Console.WriteLine("Исходные параметры задачи:");
            Console.WriteLine("A = -8 \nB = 2 \nf(x) = 10cos(x) - x^(2)* 0.1 \nEPS = {2}\nN = {3}\n", A, B, EPS, N);
            Console.WriteLine("Изменить параметры задачи? 1 - нет 2 - да");
            string answ = Console.ReadLine();
            if (answ == "2")
            {
                Console.WriteLine("Введите параметр A");
                A = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите параметр B");
                B = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите параметр N"); // КОЛИЧЕСТВО ОТРЕЗКОВ ДЛЯ ОТДЕЛЕНИЯ КОРНЕЙ
                N = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите параметр EPS");
                EPS = Convert.ToInt32(Console.ReadLine());
            }
            RootSep(A, B, N);

            void RootSep(int a, int b, int n)
            {
                int counter = 0;
                double H = (double)(b - a) / n;
                double x1 = a;
                double x2 = x1 + H;
                double y1 = f(x1);
                int check = 0;
                Console.WriteLine("Выберите метод:\n1 - Биссекция\n2 - Метод Ньютона\n3 - Модифицированный метод Ньютона\n4 - Метод секущих\n5 - Все\n");
                check = Convert.ToInt32(Console.ReadLine());
                while (x2 <= b)
                {
                    double y2 = f(x2);
                    if (y1 * y2 <= 0)
                    {
                        counter++;
                        Console.WriteLine("({0}; {1})", x1, x2);
                        if (check == 1)
                        {
                            Bisection(x1, x2, EPS);
                        }
                        else if (check == 2)
                        {
                            Newton(x1, x2, EPS);
                        }
                        else if (check == 3)
                        {
                            ModNewton(x1, x2, EPS);
                        }
                        else if (check == 4)
                        {
                            Secant(x1, x2, EPS);
                        }
                        else if (check == 5)
                        {
                            Bisection(x1, x2, EPS);
                            Newton(x1, x2, EPS);
                            ModNewton(x1, x2, EPS);
                            Secant(x1, x2, EPS);
                        }
                    }

                    x1 = x2;
                    x2 = x1 + H;
                    y1 = y2;
                }
                Console.WriteLine("Количества отрезков перемены знака функции: {0}", counter);

            }

            
            void Bisection(double a, double b, double eps)
            {
                double c = 0;
                double X = 0, delta = 0;
                int count = 0;
                if (eps > 0)
                {
                    while (b - a > 2 * eps)
                    {
                        c = (b + a) / 2;
                        if (f(a) * f(c) <= 0)
                        {
                            b = c;
                        }
                        else
                        {
                            a = c;
                        }

                        count++;
                    }
                    X = (a + b) / 2;
                    delta = (b - a) / 2;
                }
                Console.WriteLine("Метод бисекции");
                Console.WriteLine("Начальное приближение: {0}", a);
                Console.WriteLine("x = {0}    delta = {1}    |f(x) - 0| = {2}", X, delta, Math.Abs(f(X)));
                Console.WriteLine("Число шагов: {0}\n", count);
            }

            void Newton(double a, double b, double eps)
            {
                double X1 = (a + b) / 2, delta = 0;
                int count = 1, p = 1;
                double X2 = X1 - f(X1) / df(X1);

                while (Math.Abs(X1 - X2) > eps)
                {
                    if (df(X1) != 0)
                    {
                        X1 = X2;
                        X2 = X1 - p * f(X1) / df(X1);
                        count++;
                    }
                    else
                    {
                        count = 1;
                        p += 2;
                        X1 = (a + b) / 2;
                        X2 = X1 - p * f(X1) / df(X1);
                    }

                }
                delta = Math.Abs(X1 - X2);

                Console.WriteLine("Метод Ньютона");
                Console.WriteLine("Начальное приближение: {0}", a);
                Console.WriteLine("x = {0}    delta = {1}    |f(x)| = {2}", X2, delta, Math.Abs(f(X2)));
                Console.WriteLine("Число шагов: {0}\n", count);
            }

            void ModNewton(double A, double B, double eps)
            {
                int count = 0;
                double X0 = (A + B) / 2;
                double X1 = B;
                double X2 = X0;
                double fstDrvX0 = df(X0);
               
                while (Math.Abs(X2 - X1) > eps)
                {
                    X1 = X2;
                    X2 = X1 - f(X1) / fstDrvX0;
                    count++;
                }

                double X = (X1 + X2) / 2;

                double delta = (Math.Abs(X2 - X1)) / 2;
                Console.WriteLine("Модифицированный метод Ньютона");
                Console.WriteLine("Начальное приближение: {0}", A);
                Console.WriteLine("x = {0}    delta = {1}    |f(x)| = {2}", X, delta, Math.Abs(f(X)));
                Console.WriteLine("Число шагов: {0}\n", count);
            }

            void Secant(double a, double b, double eps)
            {
                double X0 = a, delta = 0;
                double X1 = b;
                int count = 2;
                double X2 = X1 - f(X1) / df(X0);

                while (Math.Abs(X1 - X2) > eps)
                {
                    X0 = X1;
                    X1 = X2;
                    X2 = X1 - f(X1) * (X1 - X0) / (f(X1) - f(X0));
                    count++;
                }
                delta = Math.Abs(X1 - X2);

                Console.WriteLine("Метод секущих");
                Console.WriteLine("Начальное приближение: {0}", a);
                Console.WriteLine("x = {0}    delta = {1}    |f(x)| = {2}", X2, delta, Math.Abs(f(X2)));
                Console.WriteLine("Число шагов: {0}\n", count);
            }
        }
    }
}