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
            return (x >= From && x <= To);
        }

        public Range GetIntersection(Range interval)
        {
            if (From < interval.To && To > interval.From)
            {
                double newFrom = (From > interval.From) ? From : interval.From;
                double newTo = (To > interval.To) ? interval.To : To;

                return new Range(newFrom, newTo);
            }
            else
            {
                return null;
            }
        }

        public Range[] GetUnion(Range interval)
        {
            if (From > interval.To || To < interval.From)
            {
                return new Range[] { new Range(From, To), new Range(interval.From, interval.To) };
            }
            else
            {
                double newFrom = (From > interval.From) ? interval.From : From;
                double newTo = (To > interval.To) ? To : interval.To;

                return new Range[] { new Range(newFrom, newTo) };
            }
        }

        public Range[] GetDifference(Range interval)
        {
            if (From < interval.To && To > interval.From)
            {
                if (From > interval.From && To > interval.To)
                {
                    return new Range[] { new Range(interval.To, To) };
                }
                else if (From < interval.From && To < interval.To)
                {
                    return new Range[] { new Range(From, interval.From) };
                }
                else
                {
                    return new Range[] { new Range(From, interval.From), new Range(interval.To, To) };
                }
            }
            else
            {
                return new Range[] { new Range(From, To) };
            }
        }
    }
}