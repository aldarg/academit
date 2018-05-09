using System;

namespace Academit.DargeevAleksandr
{
    class RangePlus
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

        public RangePlus(double from, double to)
        {
            From = from;
            To = to;
        }

        public static double GetLength(RangePlus interval)
        {
            return interval.To - interval.From;
        }

        public bool IsInside(double x)
        {
            double epsilon = 1.0e-10;

            return (x - From >= -epsilon && x - To <= epsilon);
        }

        public static RangePlus GetIntersection(RangePlus interval1, RangePlus interval2)
        {
            if (interval1.From < interval2.To && interval1.To > interval2.From)
            {
                double from = (interval1.From > interval2.From) ? interval1.From : interval2.From;
                double to = (interval1.To > interval2.To) ? interval2.To : interval1.To;

                return new RangePlus(from, to);
            }
            else
            {
                return null;
            }
        }

        public static RangePlus[] GetUnion(RangePlus interval1, RangePlus interval2)
        {
            if (interval1.From > interval2.To || interval1.To < interval2.From)
            {
                return new RangePlus[] { interval1, interval2 };
            }
            else
            {
                double from = (interval1.From > interval2.From) ? interval2.From : interval1.From;
                double to = (interval1.To > interval2.To) ? interval1.To : interval2.To;

                return new RangePlus[] { new RangePlus(from, to) };
            }
        }

        public static RangePlus[] GetDifference(RangePlus interval1, RangePlus interval2)
        {
            if (interval1.From < interval2.To && interval1.To > interval2.From)
            {
                if (interval1.From > interval2.From && interval1.To > interval2.To)
                {
                    return new RangePlus[] { new RangePlus(interval2.To, interval1.To) };
                }
                else if (interval1.From < interval2.From && interval1.To < interval2.To)
                {
                    return new RangePlus[] { new RangePlus(interval1.From, interval2.From) };
                }
                else
                {
                    return new RangePlus[] { new RangePlus(interval1.From, interval2.From), new RangePlus(interval2.To, interval1.To) };
                }
            }
            else
            {
                return new RangePlus[] { interval1 };
            }
        }
    }

    class RangePlusHomework
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

            RangePlus interval1 = new RangePlus(from1, to1);
            RangePlus interval2 = new RangePlus(from2, to2);

            RangePlus intersection = RangePlus.GetIntersection(interval1, interval2);

            if (intersection != null)
            {
                Console.WriteLine("Пересечение интервалов:");
                Console.WriteLine("[{0}, {1}]", intersection.From, intersection.To);
            }
            else
            {
                Console.WriteLine("Пересечение отсутствует.");
            }

            RangePlus[] intervalsSum = RangePlus.GetUnion(interval1, interval2);

            Console.WriteLine();
            Console.WriteLine("Объединение интервалов:");

            foreach (RangePlus a in intervalsSum)
            {
                Console.WriteLine("[{0}, {1}]", a.From, a.To);
            }

            RangePlus[] intervalsDifference = RangePlus.GetDifference(interval1, interval2);

            Console.WriteLine();
            Console.WriteLine("Разность интервалов:");

            foreach (RangePlus a in intervalsDifference)
            {
                Console.WriteLine("[{0}, {1}]", a.From, a.To);
            }
        }
    }
}
