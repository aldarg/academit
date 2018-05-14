using System;

namespace Academits.DargeevAleksandr
{
    public class Triangle : IShape
    {
        public double X1
        {
            get;
            set;
        }

        public double Y1
        {
            get;
            set;
        }

        public double X2
        {
            get;
            set;
        }

        public double Y2
        {
            get;
            set;
        }

        public double X3
        {
            get;
            set;
        }

        public double Y3
        {
            get;
            set;
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double epsilon = 1.0e-10;
            bool lineCheck = Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1)) <= epsilon;
            if (lineCheck)
            {
                throw new ArgumentException("Вершины треугольника не могут лежать на одной прямой.");
            }

            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3));
        }

        public double GetHeight()
        {
            return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
        }

        public double GetArea()
        {
            return Math.Abs(((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3)) / 2);
        }

        private double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public double GetPerimeter()
        {
            double side12 = GetSideLength(X1, Y1, X2, Y2);
            double side13 = GetSideLength(X1, Y1, X3, Y3);
            double side23 = GetSideLength(X2, Y2, X3, Y3);

            return side12 + side13 + side23;
        }

        public override string ToString()
        {
            return ($"Треугольник с координатами углов: ({X1}; {Y1}), ({X2}; {Y2}), ({X3}; {Y3}).");
        }

        public override int GetHashCode()
        {
            return X1.GetHashCode() + X2.GetHashCode() + X3.GetHashCode() + Y1.GetHashCode() + Y2.GetHashCode() + Y3.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return triangle.X1 == X1 && triangle.X2 == X2 && triangle.X3 == X3 && triangle.Y1 == Y1 && triangle.Y2 == Y2 && triangle.Y3 == Y3;
        }
    }
}
