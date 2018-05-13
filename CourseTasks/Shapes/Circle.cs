using System;

namespace Academits.DargeevAleksandr
{
    public class Circle : IShape
    {
        double Radius
        {
            get;
            set;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetWidth()
        {
            return 2 * Radius;
        }

        public override double GetHeight()
        {
            return 2 * Radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return String.Format($"Круг с радиусом {Radius}.");
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Circle circle = (Circle)obj;

            if (circle.Radius != Radius)
            {
                return false;
            }

            return true;
        }
    }
}
