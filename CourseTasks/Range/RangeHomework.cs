using System;

namespace Academit.DargeevAleksandr
{
    class RangeHomework
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начало и конец первого интервала:");

            Console.Write("начало интервала = ");
            double from1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("конец интервала = ");
            double to1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Введите начало и конец второго интервала:");

            Console.Write("начало интервала = ");
            double from2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("конец интервала = ");
            double to2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Range interval1 = new Range(from1, to1);
            Range interval2 = new Range(from2, to2);

            Range intersection = interval1.GetIntersection(interval2);

            if (intersection != null)
            {
                Console.WriteLine("Пересечение интервалов:");
                Console.WriteLine("[{0}, {1}]", intersection.From, intersection.To);
            }
            else
            {
                Console.WriteLine("Пересечение отсутствует.");
            }

            Range[] intervalsSum = interval1.GetUnion(interval2);

            Console.WriteLine();
            Console.WriteLine("Объединение интервалов:");

            foreach (Range a in intervalsSum)
            {
                Console.WriteLine("[{0}, {1}]", a.From, a.To);
            }

            Range[] intervalsDifference = interval1.GetDifference(interval2);

            Console.WriteLine();
            Console.WriteLine("Разность интервалов:");

            foreach (Range a in intervalsDifference)
            {
                Console.WriteLine("[{0}, {1}]", a.From, a.To);
            }
        }
    }
}