using System;

namespace Academit.DargeevAleksandr
{
    class Range
    {
        public double From
        {
            get;
            set;
        }

        public double To
        {
            get;
            set;
        }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double x)
        {
            double epsilon = 1.0e-10;

            return (x - From >= -epsilon && x - To <= epsilon);
        }
    }

    class RangeHomework
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начало и конец интервала:");

            Console.Write("начало интервала = ");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.Write("конец интервала = ");
            double to = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Range interval = new Range(from, to);

            Console.WriteLine($"Длина введенного интервала = {interval.GetLength():f2}");
            Console.WriteLine();

            Console.Write("Введите число для проверки на вхождение в заданный интервал: ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            if (interval.IsInside(x))
            {
                Console.Write("Введенное число входит в интервал.");
            }
            else
            {
                Console.Write("Введенное число не входит в интервал.");
            }

            Console.WriteLine();
        }
    }
}
