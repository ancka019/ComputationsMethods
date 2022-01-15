using System;

namespace hw4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            help cl = new help();
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №4: Приближённое вычисление интеграла по составным квадратурным формулам");
            Console.WriteLine("f(x)=- cos(x) + e^x    на отрезке [0,5]");
        Start:
            Console.WriteLine("ВВЕДИТЕ НАЧАЛО ОТРЕЗКА:");
            cl.a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("ВВЕДИТЕ КОНЕЦ ОТРЕЗКА:");
            cl.b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("ВВЕДИТЕ ЧИСЛО ПРОМЕЖУТКОВ ДЕЛЕНИЯ [a,b] В СОСТАВНОЙ КФ:");
            cl.m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Хотите выполнить 4.3? (1/0)");
            string ynt;
            ynt = Console.ReadLine();
            int ch = Convert.ToInt32(ynt);
            if (ch == 1)
            {
                Console.WriteLine("ВВЕДИТЕ ЧИСЛО ПАРАМЕТР l:");
                cl.l = Convert.ToInt32(Console.ReadLine());
                double hl = (cl.b - cl.a) / (cl.m * cl.l);
            }
            double h = (cl.b - cl.a) / cl.m;

            Console.WriteLine("ДЛИНА ПРОМЕЖУТКА h:" + h);
            if (ch == 1) { Console.WriteLine("ДЛИНА ПРОМЕЖУТКА h/l:" + h / cl.l); }
            cl.value();
            Console.WriteLine();
            cl.left(h, ch);
            cl.right(h, ch);
            cl.middle(h, ch);
            cl.trap(h, ch);
            cl.simp(h, ch);


            Console.WriteLine("Хотите ввести новые значения a, b, m? (y/n)");
            string yn;
            yn = Console.ReadLine();
            if (yn == "y") goto Start;

        }
    }
}
