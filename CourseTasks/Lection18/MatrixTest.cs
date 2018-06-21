using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Academits.DargeevAleksandr
{
    class MatrixTest
    {
        static void Main(string[] args)
        {
            Matrix test = new Matrix(1000);
            test.FillMatrix();
            /*for (int i = 0; i < test.Size; ++i)
            {
                for (int j = 0; j < test.Size; ++j)
                {
                    Console.Write("{0}\t", test.array[i, j]);
                }

                Console.WriteLine();
            }*/

            Console.WriteLine();
            Console.WriteLine("Восстанавливаем матрицу:");

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream writer = new FileStream("matrix2", FileMode.Create, FileAccess.ReadWrite))
            {
                formatter.Serialize(writer, test);
            }
            
            using (FileStream reader = new FileStream("matrix2", FileMode.Open, FileAccess.Read))
            {
                Matrix test2 = (Matrix)formatter.Deserialize(reader);

                /*for (int i = 0; i < test2.Size; ++i)
                {
                    for (int j = 0; j < test2.Size; ++j)
                    {
                        Console.Write("{0}\t", test2.array[i, j]);
                    }

                    Console.WriteLine();
                }*/
            }
        }
    }
}
