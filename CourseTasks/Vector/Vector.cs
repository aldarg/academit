using System;
using System.Text;

namespace Academits.DargeevAleksandr
{
    class Vector
    {
        public double[] Components
        {
            private get;
            set;
        }

        public int Size
        {
            get
            {
                return Components.Length;
            }
        }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля.");
            }

            Components = new double[n];
        }

        public Vector(Vector original)
        {
            Components = new double[original.Size];

            Array.Copy(original.Components, Components, Size);
        }

        public Vector(double[] a)
        {
            if (a.Length == 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля.");
            }

            Components = new double[a.Length];

            Array.Copy(a, Components, Size);
        }

        public Vector(int n, double[] a)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше нуля.");
            }

            Components = new double[n];

            for (int i = 0; i < Math.Min(n, a.Length); i++)
            {
                Components[i] = a[i];
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("{");

            int n = Size;

            for (int i = 0; i < n - 1; i++)
            {
                result.Append(string.Format(" {0},", Components[i]));
            }

            result.Append(string.Format(" {0} }}", Components[n - 1]));
            return result.ToString();
        }

        public void Add(Vector vector)
        {
            int n1 = Size;
            int n2 = vector.Size;

            if (n1 < n2)
            {
                double[] temp = Components;
                Array.Resize(ref temp, n2);
                Components = temp;
            }

            for (int i = 0; i < n2; i++)
            {
                Components[i] += vector.Components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            int n1 = Size;
            int n2 = vector.Size;

            if (n1 < n2)
            {
                double[] temp = Components;
                Array.Resize(ref temp, n2);
                Components = temp;
            }

            for (int i = 0; i < n2; i++)
            {
                Components[i] -= vector.Components[i];
            }
        }

        public void Multiply(double scalar)
        {
            for (int i = 0; i < Size; i++)
            {
                Components[i] *= scalar;
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
                result += Math.Pow(Components[i], 2);
            }

            return Math.Sqrt(result);
        }

        public void SetByIndex(int index, double x)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException("SetByIndex: некорректный параметр индекса.");
            }

            Components[index] = x;
        }

        public double GetByIndex(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException("SetByIndex: некорректный параметр индекса.");
            }

            return Components[index];
        }

        public override bool Equals(object obj)
        {
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
                if (Components[i] != vector.Components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;

            foreach (double x in Components)
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
                result += vector1.Components[i] * vector2.Components[i];
            }

            return result;
        }
    }
}
