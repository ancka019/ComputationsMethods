using System;

namespace HW4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //число промежутков деления [A,B]
            int m = 1000;
            //точка интерполирования, значение в которой хотим найти
            double X = 0.35;
            //начало и конец отрезка
            double A = 0, B = 5;

            double h = (B - A) / m;


            double f(double x)
            {
                return Math.Cos(x) + Math.Exp(x) * 2.85 + 1;
            }

            double J = 0.919535764538226226129431973912;
            //J = 5;
            //J = 12.5;
            //J = 156.25;

            double F(double x)
            {
                return Math.Sin(x) + Math.Exp(x) * 2.85 + x;
            }

            Console.WriteLine("Приближённое вычисление интеграла по квадратурным формулам");
            Console.WriteLine("A = {0}, B = {1}, m = {2}, h = {3}", A, B, m, h);
            Console.WriteLine("Хотите изменить параметры задачи?");
            string answ = Console.ReadLine();
            if (answ == "y")
            {
                Console.WriteLine("Введите параметр A:");
                A = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите параметр B:");
                B = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите параметр m:");
                m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Успешно изменёны!\n");
                Console.WriteLine("A = {0}, B = {1}, m = {2}, h = {3}", A, B, m, h);
            }
            J = F(B) - F(A);

            //Console.WriteLine("f(x) = sin(2x)");

            Console.WriteLine("J = {0}", J);
            //Console.WriteLine(F(B) - F(A));

            double[] x = new double[m + 1];
            double[] fx = new double[m + 1];


            for (int i = 0; i <= m; i++)
            {
                x[i] = A + i * Math.Abs(B - A) / m;
                fx[i] = f(x[i]);
            }

            h = (B - A) / m;

            double y = 0;
            double p = f((x[0] + x[1]) / 2);
            for (int i = 1; i < m; i++)
            {
                y += fx[i];
                p += f((x[i] + x[i + 1]) / 2);
            }

            Console.WriteLine("\nФормула левых прямоугольников");
            double left = leftQuadrature(fx, A, B);
            Console.WriteLine("J(h) = {0}", left);
            Console.WriteLine("│J − J(h)│ = {0}", Math.Abs(left - J));
            double leftError = TheoreticalError(fx, left, A);
            Console.WriteLine("Теоретическая погрешность: {0}", leftError);
            //Console.WriteLine("Разность погрешностей: {0}", leftError - Math.Abs(left - J));

            Console.WriteLine("\nФормула правых прямоугольников");
            double right = rightQuadrature(fx, A, B);
            Console.WriteLine("J(h) = {0}", right);
            Console.WriteLine("│J − J(h)│ = {0}", Math.Abs(right - J));
            double rightError = TheoreticalError(fx, right, A);
            Console.WriteLine("Теоретическая погрешность: {0}", rightError);
            //Console.WriteLine("Разность погрешностей: {0}", rightError - Math.Abs(right - J));

            Console.WriteLine("\nФормула средних прямоугольников");
            double mid = midQuadrature(A, B);
            Console.WriteLine("J(h) = {0}", mid);
            Console.WriteLine("│J − J(h)│ = {0}", Math.Abs(mid - J));
            double midError = TheoreticalError(fx, mid, A);
            Console.WriteLine("Теоретическая погрешность: {0}", midError);
            //Console.WriteLine("Разность погрешностей: {0}", midError - Math.Abs(mid - J));

            Console.WriteLine("\nФормула трапеции");
            double trapezoid = trapezoidQuadrature(fx, A, B);
            Console.WriteLine("J(h) = {0}", trapezoid);
            Console.WriteLine("│J − J(h)│ = {0}", Math.Abs(trapezoid - J));
            double trapError = TheoreticalError(fx, trapezoid, A);
            Console.WriteLine("Теоретическая погрешность: {0}", trapError);
            //Console.WriteLine("Разность погрешностей: {0}", trapError - Math.Abs(trapezoid - J));

            Console.WriteLine("\nСимпсон");
            double Simpson = SimpsonQuadrature(fx, A, B);
            Console.WriteLine("J(h) = {0}", Simpson);
            Console.WriteLine("│J − J(h)│ = {0}", Math.Abs(Simpson - J));
            double SimpsonError = TheoreticalError(fx, Simpson, A);
            Console.WriteLine("Теоретическая погрешность D'OH: {0}", SimpsonError);
            //Console.WriteLine("Разность погрешностей: {0}", SimpsonError - Math.Abs(Simpson - J));


            Console.WriteLine("\n3/8");
            double F3 = F3_8(fx, A, B);
            Console.WriteLine("J(h) = {0}", Simpson);
            Console.WriteLine("│J − J(h)│ = {0}", Math.Abs(Simpson - J));
            double F3Error = TheoreticalError(fx, F3,A);
            Console.WriteLine("Теоретическая погрешность D'OH: {0}", F3Error);

            double leftQuadrature(double[] fx, double a, double b)
            {
                return (b - a) * f(a);
            }

            double rightQuadrature(double[] fx, double a, double b)
            {
                
                return (b - a) * f(b);
            }

            double midQuadrature(double a, double b)
            {
                return (b - a) * f((a + b) / 2);
            }

            double trapezoidQuadrature(double[] fx, double a, double b)
            {
                return (b - a) *(f(a) + f(b)) / 2;
            }

            //D'OH
            double SimpsonQuadrature(double[] fx, double a, double b)
            {
                return (b - a) * (f(a) + 4 * f((a + b) / 2) + f(b)) / 6;
            }

            double F3_8(double[] fx, double a, double b)
            {
                h = (b - a) / 3;
                return (b - a) * (f(a) + 3 * f(a + h) + 3 * f(a + 2 * h) + f(b)) / 8;
            }

            double TheoreticalError(double[] fx, double formula, double a)
            {
                return Math.Abs(formula - f(a));
            }
        }
    }
}