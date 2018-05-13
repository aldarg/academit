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
            double epsilon = 1.0e-10;

            if (radius <= epsilon)
            {
                throw new ArgumentException("Радиус круга должен быть больше нуля.");
            }

            Radius = radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
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

            double epsilon = 1.0e-10;

            if (Math.Abs(circle.Radius - Radius) > epsilon)
            {
                return false;
            }

            return true;
        }
    }
}
