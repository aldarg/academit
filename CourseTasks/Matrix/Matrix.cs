using System;
using System.Text;

namespace Academits.DargeevAleksandr
{
    public class Matrix
    {
        public Vector[] Rows
        {
            private get
            {
                return Rows;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Некорректный параметр - массив длины 0.");
                }

                Rows = value;
            }
        }

        public Matrix(int n, int m)
        {
            if (n <= 0 || m <= 0 || (n == 1 && m == 1))
            {
                throw new ArgumentException("Matrix: неверные размеры матрицы.");
            }

            Rows = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                Rows[i] = new Vector(m);
            }
        }

        public Matrix(Matrix original)
        {
            Rows = new Vector[original.GetSize(0)];

            Array.Copy(original.Rows, Rows, original.GetSize(0));
        }

        public Matrix(double[,] a)
        {
            if (a.Length <= 1)
            {
                throw new ArgumentException("Размерность параметра <массив> должна быть больше 1.");
            }

            Rows = new Vector[a.GetLength(0)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                double[] temp = new double[a.GetLength(1)];

                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = a[i, j];
                }

                Rows[i] = new Vector(temp);
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length == 1 && vectors[0].Size == 1)
            {
                throw new ArgumentException("Некорректный размер матрицы - 1 х 1");
            }

            Rows = new Vector[vectors.Length];

            int m = 0;

            foreach (Vector v in vectors)
            {
                if (m < v.Size)
                {
                    m = v.Size;
                }
            }

            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Size == m)
                {
                    Rows[i] = vectors[i];
                }
                else
                {
                    Rows[i] = Vector.GetSum(vectors[i], new Vector(m));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("{ ");

            for (int i = 0; i < GetSize(0) - 1; i++)
            {
                result.Append(Rows[i]).Append(", ");
            }

            result.Append(Rows[GetSize(0) - 1]);
            result.Append(" }");

            return result.ToString();
        }

        public int GetSize(int dimension)
        {
            if (dimension == 0)
            {
                return Rows.Length;
            }
            else if (dimension == 1)
            {
                return Rows[0].Size;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Неверный параметр размерности.");
            }
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= GetSize(0))
            {
                throw new ArgumentException("GetRow: Некорректный индекс.");
            }

            return Rows[index];
        }

        public void SetRow(Vector row, int index)
        {
            if (index < 0 || index >= GetSize(0))
            {
                throw new ArgumentException("SetRow: Некорректный индекс.");
            }

            if (row.Size != GetSize(1))
            {
                throw new ArgumentException("SetRow: размерность строки не подходит под размерность матрицы.");
            }

            Rows[index] = new Vector(row);
        }

        public void SetRow(double[] a, int index)
        {
            if (index < 0 || index >= GetSize(0))
            {
                throw new ArgumentException("SetRow: Некорректный индекс.");
            }

            if (a.Length != GetSize(1))
            {
                throw new ArgumentException("SetRow: размерность строки не подходит под размерность матрицы.");
            }

            Rows[index] = new Vector(a);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= GetSize(1))
            {
                throw new ArgumentException("GetColumn: Некорректный индекс.");
            }

            double[] temp = new double[GetSize(0)];

            for (int i = 0; i < GetSize(0); i++)
            {
                temp[i] = Rows[i].GetByIndex(index);
            }

            return new Vector(temp);
        }

        public void Transpose()
        {
            Vector[] temp = new Vector[GetSize(1)];

            for (int i = 0; i < GetSize(1); i++)
            {
                temp[i] = GetColumn(i);
            }

            Rows = temp;
        }

        public void Multiply(double scalar)
        {
            for (int i = 0; i < GetSize(0); i++)
            {
                Rows[i].Multiply(scalar);
            }
        }

        private static Matrix GetMinorMatrix(Matrix matrix, int i, int j)
        {
            int dimension = matrix.GetSize(0) - 1;
            Matrix minorMatrix = new Matrix(dimension, dimension);

            int xOffset = 0;
            int yOffset = 0;

            for (int k = 0; k < dimension; k++)
            {
                if (k == i)
                {
                    yOffset = 1;
                }

                double[] temp = new double[dimension];

                for (int m = 0; m < dimension; m++)
                {
                    if (m == j)
                    {
                        xOffset = 1;
                    }

                    temp[m] = matrix.Rows[k + yOffset].GetByIndex(m + xOffset);
                }

                minorMatrix.SetRow(temp, k);

                xOffset = 0;
            }

            return minorMatrix;
        }

        private static double GetDeterminantStatic(Matrix matrix)
        {
            if (matrix.GetSize(0) == 1)
            {
                return matrix.GetRow(0).GetByIndex(0);
            }

            if (matrix.GetSize(0) == 2)
            {
                return matrix.GetRow(0).GetByIndex(0) * matrix.GetRow(1).GetByIndex(1) - matrix.GetRow(0).GetByIndex(1) * matrix.GetRow(1).GetByIndex(0);
            }

            double determinant = 0;

            for (int i = 0; i < matrix.GetSize(0); i++)
            {
                determinant += Math.Pow(-1, i) * matrix.GetRow(0).GetByIndex(i) * GetDeterminantStatic(GetMinorMatrix(matrix, 0, i));
            }

            return determinant;
        }

        public double GetDeterminant()
        {
            if (GetSize(0) != GetSize(1))
            {
                throw new Exception("Неверная размерность матрицы для вычисления определителя.");
            }

            Matrix temp = new Matrix(Rows);

            return GetDeterminantStatic(temp);
        }

        public void Multiply(Vector vector)
        {
            if (GetSize(1) != vector.Size)
            {
                throw new ArgumentException("Неверная размерность вектора.");
            }

            Matrix result = new Matrix(GetSize(0), 1);

            for (int i = 0; i < GetSize(0); i++)
            {
                double[] temp = new double[1];
                temp[0] = Vector.GetScalarProduct(Rows[i], vector);

                result.Rows[i] = new Vector(temp);
            }

            Rows = result.Rows;
        }

        public void Add(Matrix matrix)
        {
            if (GetSize(0) != matrix.GetSize(0) || GetSize(1) != matrix.GetSize(1))
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            for (int i = 0; i < GetSize(0); i++)
            {
                Rows[i].Add(matrix.Rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (GetSize(0) != matrix.GetSize(0) || GetSize(1) != matrix.GetSize(1))
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            Matrix temp = new Matrix(matrix);

            temp.Multiply(-1);
            Add(temp);
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetSize(0) != matrix2.GetSize(0) || matrix1.GetSize(1) != matrix2.GetSize(1))
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetSize(0) != matrix2.GetSize(0) || matrix1.GetSize(1) != matrix2.GetSize(1))
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        public static Matrix MultiplyMatrixes(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetSize(1) != matrix2.GetSize(0))
            {
                throw new ArgumentException("Умножение матриц невозможно - некорректные размеры.");
            }

            Matrix result = new Matrix(matrix2.GetSize(1), matrix1.GetSize(0));

            for (int i = 0; i < matrix1.GetSize(0); i++)
            {
                Matrix temp = new Matrix(matrix1);

                temp.Multiply(matrix2.GetColumn(i));
                temp.Transpose();
                result.SetRow(temp.Rows[0], i);
            }

            result.Transpose();

            return result;
        }
    }
}