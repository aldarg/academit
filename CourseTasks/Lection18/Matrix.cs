using System;
using System.Runtime.Serialization;

namespace Academits.DargeevAleksandr
{
    [Serializable]
    class Matrix : ISerializable
    //class Matrix
    {
        public int[,] array;
        public int Size;

        public Matrix(int dimension)
        {
            array = new int[dimension, dimension];
            Size = dimension;
        }

        public void FillMatrix()
        {
            Random random = new Random();

            int off = 0;

            for (int i = 0; i < Size; ++i)
            {
                for (int j = off; j < Size; ++j)
                {
                    int value = random.Next(100);

                    array[i, j] = value;
                    array[j, i] = value;
                }

                ++off;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Size", Size);

            int off = 0;

            for (int i = 0; i < Size; ++i)
            {
                for (int j = off; j < Size; ++j)
                {
                    string prop = string.Format("value[{0}, {1}]", i, j);

                    info.AddValue(prop, array[i, j]);
                }

                ++off;
            }
        }

        protected Matrix(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            Size = (int)info.GetValue("Size", typeof(int));
            array = new int[Size, Size];

            int off = 0;

            for (int i = 0; i < Size; ++i)
            {
                for (int j = off; j < Size; ++j)
                {
                    string prop = string.Format("value[{0}, {1}]", i, j);
                    int value = (int)info.GetValue(prop, typeof(int));

                    array[i, j] = value;
                    array[j, i] = value;
                }

                ++off;
            }
        }*/
    }
}
