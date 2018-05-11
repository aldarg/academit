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

        public double Length
        {
            get
            {
                return To - From;
            }
        }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public bool IsInside(double x)
        {
            return (x >= From && x <= To);
        }

        public Range GetIntersection(Range interval)
        {
            if (From >= interval.To || To <= interval.From)
            {
                return null;
            }
            else
            {
                double newFrom = Math.Max(From, interval.From);
                double newTo = Math.Min(To, interval.To);

                return new Range(newFrom, newTo);
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
                double newFrom = Math.Min(From, interval.From);
                double newTo = Math.Max(To, interval.To);

                return new Range[] { new Range(newFrom, newTo) };
            }
        }

        public Range[] GetDifference(Range interval)
        {
            if (From >= interval.To || To <= interval.From)
            {
                return new Range[] { new Range(From, To) };
            }
            else if (From >= interval.From && To <= interval.To)
            {
                return new Range[] { };
            }
            else
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
        }
    }
}