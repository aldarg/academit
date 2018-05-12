using System;

namespace Academits.DargeevAleksandr
{
    public class Triangle : Shapes
    {
        double X1
        {
            get;
            set;
        }

        double Y1
        {
            get;
            set;
        }

        double X2
        {
            get;
            set;
        }

        double Y2
        {
            get;
            set;
        }

        double X3
        {
            get;
            set;
        }

        double Y3
        {
            get;
            set;
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public override double GetWidth()
        {
            return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Max(X2, X3));
        }

        public override double GetHeight()
        {
            return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Max(Y2, Y3));
        }

        public override double GetArea()
        {
            return Math.Abs(((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3)) / 2);
        }

        public override double GetPerimeter()
        {
            double x1x2 = Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));
            double x1x3 = Math.Sqrt((X3 - X1) * (X3 - X1) + (Y3 - Y1) * (Y3 - Y1));
            double x3x2 = Math.Sqrt((X2 - X3) * (X2 - X3) + (Y2 - Y3) * (Y2 - Y3));

            return x1x2 + x1x3 + x3x2;
        }

        public override string ToString()
        {
            return String.Format($"Треугольник с координатами углов: ({X1}; {Y1}), ({X2}; {Y2}), ({X3}; {Y3}).");
        }

        public override int GetHashCode()
        {
            return X1.GetHashCode() + X2.GetHashCode() + X3.GetHashCode() + Y1.GetHashCode() + Y2.GetHashCode() + Y3.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            if (triangle.X1 != X1 || triangle.X2 != X2 || triangle.X3 != X3 || triangle.Y1 != Y1 || triangle.Y2 != Y2 || triangle.Y3 != Y3)
            {
                return false;
            }

            return true;
        }
    }
}
