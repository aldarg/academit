using System;
using System.Text;

namespace Academits.DargeevAleksandr
{
    public class Vector
    {
        private double[] components;

        public int Size
        {
            get
            {
                return components.Length;
            }
        }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля.");
            }

            components = new double[n];
        }

        public Vector(Vector original)
        {
            components = new double[original.Size];

            Array.Copy(original.components, components, original.Size);
        }

        public Vector(double[] a)
        {
            if (a.Length == 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля.");
            }

            components = new double[a.Length];

            Array.Copy(a, components, a.Length);
        }

        public Vector(int n, double[] a)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля.");
            }

            components = new double[a.Length];

            Array.Copy(a, components, a.Length);

            if (a.Length != n)
            {
                Array.Resize(ref components, n);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("{");

            int n = Size;

            for (int i = 0; i < n; i++)
            {
                result.Append(" ").Append(components[i]);

                if (i < n - 1)
                {
                    result.Append(",");
                }
                else
                {
                    result.Append(" }");
                }
            }

            return result.ToString();
        }

        public void Add(Vector vector)
        {
            int n1 = Size;
            int n2 = vector.Size;

            if (n1 < n2)
            {
                Array.Resize(ref components, n2);
            }

            for (int i = 0; i < n2; i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            int n1 = Size;
            int n2 = vector.Size;

            if (n1 < n2)
            {
                Array.Resize(ref components, n2);
            }

            for (int i = 0; i < n2; i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void Multiply(double scalar)
        {
            for (int i = 0; i < Size; i++)
            {
                components[i] *= scalar;
            }
        }

        public void Reverse()
        {
            Multiply(-1);
        }

        public double GetLength()
        {
            double result = 0;

            for (int i = 0; i < Size; i++)
            {
                result += Math.Pow(components[i], 2);
            }

            return Math.Sqrt(result);
        }

        public void SetByIndex(int index, double x)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException("SetByIndex: некорректный параметр индекса.");
            }

            components[index] = x;
        }

        public double GetByIndex(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException("SetByIndex: некорректный параметр индекса.");
            }

            return components[index];
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

            Vector vector = (Vector)obj;

            if (Size != vector.Size)
            {
                return false;
            }

            for (int i = 0; i < Size; i++)
            {
                if (components[i] != vector.components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;

            foreach (double x in components)
            {
                hashCode += x.GetHashCode();
            }

            return hashCode;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);
            result.Add(vector2);

            return result;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);
            result.Subtract(vector2);

            return result;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            double result = 0;
            int n = Math.Min(vector1.Size, vector2.Size);

            for (int i = 0; i < n; i++)
            {
                result += vector1.components[i] * vector2.components[i];
            }

            return result;
        }
    }
}
