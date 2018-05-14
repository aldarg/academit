using System;

namespace Academits.DargeevAleksandr
{
    public class Circle : IShape
    {
        public double Radius
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
            return ($"Круг с радиусом {Radius}.");
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
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

            Circle circle = (Circle)obj;

            return circle.Radius == Radius;
        }
    }
}
