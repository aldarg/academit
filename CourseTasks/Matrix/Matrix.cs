using System;
using System.Text;

namespace Academits.DargeevAleksandr
{
    public class Matrix
    {
        private Vector[] rows;

        public int Width
        {
            get
            {
                return rows[0].Size;
            }
        }
        
        public int Height
        {
            get
            {
                return rows.Length;
            }
        }

        public Matrix(int n, int m)
        {
            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("Matrix: неверные размеры матрицы.");
            }

            rows = new Vector[n];

            for (int i = 0; i < n; i++)
            {
                rows[i] = new Vector(m);
            }
        }

        public Matrix(Matrix original)
        {
            rows = new Vector[original.Height];

            Array.Copy(original.rows, rows, original.Height);

            for (int i = 0; i < original.Height; i++)
            {
                rows[i] = new Vector(original.GetRow(i));
            }
        }

        public Matrix(double[,] a)
        {
            if (a.Length == 0)
            {
                throw new ArgumentException("Размерность параметра <массив> должна быть больше 1.");
            }

            rows = new Vector[a.GetLength(0)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                double[] temp = new double[a.GetLength(1)];

                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = a[i, j];
                }

                rows[i] = new Vector(temp);
            }
        }

        public Matrix(Vector[] vectors)
        {
            rows = new Vector[vectors.Length];

            int maxVectorSize = 0;

            foreach (Vector v in vectors)
            {
                if (maxVectorSize < v.Size)
                {
                    maxVectorSize = v.Size;
                }
            }

            for (int i = 0; i < vectors.Length; i++)
            {
                rows[i] = new Vector(vectors[i]);

                if (rows[i].Size < maxVectorSize)
                {
                    rows[i].Add(new Vector(maxVectorSize));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("{ ");

            for (int i = 0; i < Height; i++)
            {
                result.Append(rows[i]);

                if (i < Height - 1)
                {
                    result.Append(", ");
                }
            }

            return result.Append(" }").ToString();
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= Height)
            {
                throw new IndexOutOfRangeException("GetRow: Некорректный индекс.");
            }

            return rows[index];
        }

        public void SetRow(int index, Vector row)
        {
            if (index < 0 || index >= Height)
            {
                throw new IndexOutOfRangeException("SetRow: Некорректный индекс.");
            }

            if (row.Size != Width)
            {
                throw new ArgumentException("SetRow: размерность строки не подходит под размерность матрицы.");
            }

            rows[index] = new Vector(row);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= Width)
            {
                throw new IndexOutOfRangeException("GetColumn: Некорректный индекс.");
            }

            double[] temp = new double[Height];

            for (int i = 0; i < Height; i++)
            {
                temp[i] = rows[i].GetByIndex(index);
            }

            return new Vector(temp);
        }

        public void Transpose()
        {
            Vector[] temp = new Vector[Width];

            for (int i = 0; i < Width; i++)
            {
                temp[i] = GetColumn(i);
            }

            rows = temp;
        }

        public void Multiply(double scalar)
        {
            foreach(Vector row in rows)
            {
                row.Multiply(scalar);
            }
        }

        private static Matrix GetMinorMatrix(Matrix matrix, int i, int j)
        {
            int dimension = matrix.Height - 1;
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

                    temp[m] = matrix.rows[k + yOffset].GetByIndex(m + xOffset);
                }

                minorMatrix.SetRow(k, new Vector(temp));

                xOffset = 0;
            }

            return minorMatrix;
        }

        private static double GetMatrixDeterminant(Matrix matrix)
        {
            if (matrix.Height == 1)
            {
                return matrix.GetRow(0).GetByIndex(0);
            }

            if (matrix.Height == 2)
            {
                return matrix.GetRow(0).GetByIndex(0) * matrix.GetRow(1).GetByIndex(1) - matrix.GetRow(0).GetByIndex(1) * matrix.GetRow(1).GetByIndex(0);
            }

            double determinant = 0;

            for (int i = 0; i < matrix.Height; i++)
            {
                determinant += Math.Pow(-1, i) * matrix.GetRow(0).GetByIndex(i) * GetMatrixDeterminant(GetMinorMatrix(matrix, 0, i));
            }

            return determinant;
        }

        public double GetDeterminant()
        {
            if (Height != Width)
            {
                throw new ArgumentException("Определитель можно посчитать только для матриц N x N.");
            }

            Matrix temp = new Matrix(rows);

            return GetMatrixDeterminant(temp);
        }

        public Vector Multiply(Vector vector)
        {
            if (Width != vector.Size)
            {
                throw new ArgumentException("Неверная размерность вектора.");
            }

            Vector result = new Vector(Height);

            for (int i = 0; i < Height; i++)
            {
                result.SetByIndex(i, Vector.GetScalarProduct(rows[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (Height != matrix.Height || Width != matrix.Width)
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            for (int i = 0; i < Height; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (Height != matrix.Height || Width != matrix.Width)
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            for (int i = 0; i < Height; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Height != matrix2.Height || matrix1.Width != matrix2.Width)
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Height != matrix2.Height || matrix1.Width != matrix2.Width)
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        public static Matrix MultiplyMatrixes(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Width != matrix2.Height)
            {
                throw new ArgumentException("Умножение матриц невозможно - некорректные размеры.");
            }

            Matrix result = new Matrix(matrix1.Height, matrix2.Width);

            for (int i = 0; i < result.Height; i++)
            {
                double[] temp = new double[result.Width];

                for (int j = 0; j < result.Width; j++)
                {
                    temp[j] = Vector.GetScalarProduct(matrix1.GetRow(i), matrix2.GetColumn(j));
                }

                result.SetRow(i, new Vector(temp));
            }

            return result;
        }
    }
}