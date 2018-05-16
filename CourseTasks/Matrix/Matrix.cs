using System;
using System.Text;

namespace Academits.DargeevAleksandr
{
    public class Matrix
    {
        private Vector[] rows;

        public int ColumnsCount
        {
            get
            {
                return rows[0].Size;
            }
        }
        
        public int RowsCount
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
            rows = new Vector[original.RowsCount];

            for (int i = 0; i < original.RowsCount; i++)
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

            if (maxVectorSize == 0)
            {
                throw new ArgumentException("Все векторы массива - нулевой длины.");
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

            for (int i = 0; i < RowsCount; i++)
            {
                result.Append(rows[i]);

                if (i < RowsCount - 1)
                {
                    result.Append(", ");
                }
            }

            return result.Append(" }").ToString();
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= RowsCount)
            {
                throw new IndexOutOfRangeException("GetRow: Некорректный индекс.");
            }

            return new Vector(rows[index]);
        }

        public void SetRow(int index, Vector row)
        {
            if (index < 0 || index >= RowsCount)
            {
                throw new IndexOutOfRangeException("SetRow: Некорректный индекс.");
            }

            if (row.Size != ColumnsCount)
            {
                throw new ArgumentException("SetRow: размерность строки не подходит под размерность матрицы.");
            }

            rows[index] = new Vector(row);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= ColumnsCount)
            {
                throw new IndexOutOfRangeException("GetColumn: Некорректный индекс.");
            }

            double[] temp = new double[RowsCount];

            for (int i = 0; i < RowsCount; i++)
            {
                temp[i] = rows[i].GetByIndex(index);
            }

            return new Vector(temp);
        }

        public void Transpose()
        {
            Vector[] temp = new Vector[ColumnsCount];

            for (int i = 0; i < ColumnsCount; i++)
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
            int dimension = matrix.RowsCount - 1;
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
            if (matrix.RowsCount == 1)
            {
                return matrix.GetRow(0).GetByIndex(0);
            }

            if (matrix.RowsCount == 2)
            {
                return matrix.GetRow(0).GetByIndex(0) * matrix.GetRow(1).GetByIndex(1) - matrix.GetRow(0).GetByIndex(1) * matrix.GetRow(1).GetByIndex(0);
            }

            double determinant = 0;

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                determinant += Math.Pow(-1, i) * matrix.GetRow(0).GetByIndex(i) * GetMatrixDeterminant(GetMinorMatrix(matrix, 0, i));
            }

            return determinant;
        }

        public double GetDeterminant()
        {
            if (RowsCount != ColumnsCount)
            {
                throw new ArgumentException("Определитель можно посчитать только для матриц N x N.");
            }

            Matrix temp = new Matrix(rows);

            return GetMatrixDeterminant(temp);
        }

        public Vector Multiply(Vector vector)
        {
            if (ColumnsCount != vector.Size)
            {
                throw new ArgumentException("Неверная размерность вектора.");
            }

            Vector result = new Vector(RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                result.SetByIndex(i, Vector.GetScalarProduct(rows[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (RowsCount != matrix.RowsCount || ColumnsCount != matrix.ColumnsCount)
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            for (int i = 0; i < RowsCount; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (RowsCount != matrix.RowsCount || ColumnsCount != matrix.ColumnsCount)
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            for (int i = 0; i < RowsCount; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowsCount != matrix2.RowsCount || matrix1.ColumnsCount != matrix2.ColumnsCount)
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowsCount != matrix2.RowsCount || matrix1.ColumnsCount != matrix2.ColumnsCount)
            {
                throw new ArgumentException("Операции сложения и вычитания матриц возможны только для матриц одного размера.");
            }

            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        public static Matrix MultiplyMatrixes(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException("Умножение матриц невозможно - некорректные размеры.");
            }

            Matrix result = new Matrix(matrix1.RowsCount, matrix2.ColumnsCount);

            for (int i = 0; i < result.RowsCount; i++)
            {
                double[] temp = new double[result.ColumnsCount];

                for (int j = 0; j < result.ColumnsCount; j++)
                {
                    temp[j] = Vector.GetScalarProduct(matrix1.GetRow(i), matrix2.GetColumn(j));
                }

                result.SetRow(i, new Vector(temp));
            }

            return result;
        }
    }
}