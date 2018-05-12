using System;

namespace Academits.DargeevAleksandr
{
    public class Rectangle : Shapes
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
            SideA = a;
            SideB = b;
        }

        public override double GetWidth()
        {
            return SideA;
        }

        public override double GetHeight()
        {
            return SideB;
        }

        public override double GetArea()
        {
            return SideA * SideB;
        }

        public override double GetPerimeter()
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

            if (rectangle.SideA != SideA || rectangle.SideB != SideB)
            {
                return false;
            }

            return true;
        }
    }
}
