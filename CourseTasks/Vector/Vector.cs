using System;

namespace Vector
{
    class Vector
    {
        public double[] Components
        {
            get;
            set;
        }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }

            Components = new double[n];
        }

        public Vector(Vector original)
        {
            if (original == null)
            {
                Components = null;
            }
            else
            {
                Components = new double[original.GetSize()];

                for (int i = 0; i < GetSize(); i++)
                {
                    Components[i] = original.Components[i];
                }
            }
        }

        public Vector(double[] a)
        {
            if (a == null)
            {
                Components = null;
            }
            else
            {
                Components = new double[a.Length];

                for (int i = 0; i < GetSize(); i++)
                {
                    Components[i] = a[i];
                }
            }
        }

        public Vector(int n, double[] a)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }

            Components = new double[n];

            for (int i = 0; i < n; i++)
            {
                Components[i] = (i < a.Length) ? a[i] : 0;
            }
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            string result = "{";

            int n = GetSize();

            for (int i = 0; i < n; i++)
            {
                result += (i < n - 1) ? String.Format(" {0},", Components[i]) : String.Format(" {0}{1}", Components[i], "}");
            }

            return result;
        }

        public void Add(Vector vector)
        {
            int n1 = GetSize();
            int n2 = vector.GetSize();

            for (int i = 0; i < n1; i++)
            {
                Components[i] += (i < n2) ? vector.Components[i] : 0;
            }
        }

        public void Subtract(Vector vector)
        {
            int n1 = GetSize();
            int n2 = vector.GetSize();

            for (int i = 0; i < n1; i++)
            {
                Components[i] -= (i < n2) ? vector.Components[i] : 0;
            }
        }

        public void Multiply(int scalar)
        {
            int n = GetSize();

            for (int i = 0; i < n; i++)
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

            for (int i = 0; i < GetSize(); i++)
            {
                result += Math.Pow(Components[i], 2);
            }

            return Math.Sqrt(result);
        }

        public void SetByIndex(int index, double x)
        {
            if (index < 0 || index >= GetSize())
            {
                throw new ArgumentOutOfRangeException();
            }

            Components[index] = x;
        }

        public double GetByIndex(int index)
        {
            if (index < 0 || index >= GetSize())
            {
                throw new ArgumentOutOfRangeException();
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

            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            for (int i = 0; i < GetSize(); i++)
            {
                if (Components[i] != vector.Components[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
