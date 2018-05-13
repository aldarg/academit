using System;

namespace Academits.DargeevAleksandr
{
    public class Rectangle : IShape
    {
        double SideA
        {
            get;
            set;
        }

        double SideB
        {
            get;
            set;
        }

        public Rectangle(double a, double b)
        {
            double epsilon = 1.0e-10;

            if (a <= epsilon || b <= epsilon)
            {
                throw new ArgumentException("Все стороны прямоугольника должны быть больше нуля.");
            }

            SideA = a;
            SideB = b;
        }

        public double GetWidth()
        {
            return SideA;
        }

        public double GetHeight()
        {
            return SideB;
        }

        public double GetArea()
        {
            return SideA * SideB;
        }

        public double GetPerimeter()
        {
            return 2 * (SideA + SideB);
        }

        public override string ToString()
        {
            return String.Format($"Прямоугольник со сторонами {SideA} и {SideB}.");
        }

        public override int GetHashCode()
        {
            return SideA.GetHashCode() + SideB.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Rectangle rectangle = (Rectangle)obj;

            double epsilon = 1.0e-10;

            if (Math.Abs(rectangle.SideA - SideA) > epsilon || Math.Abs(rectangle.SideB - SideB) > epsilon)
            {
                return false;
            }

            return true;
        }
    }
}
