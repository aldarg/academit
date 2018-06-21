using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Academits.DargeevAleksandr
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle test = new Rectangle(4, 5);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream writer = new FileStream("save", FileMode.Create, FileAccess.ReadWrite))
            {
                formatter.Serialize(writer, test);
            }

            using (FileStream reader = new FileStream("save", FileMode.Open, FileAccess.Read))
            {
                Rectangle test2 = (Rectangle)formatter.Deserialize(reader);

                Console.WriteLine(test2.Width);
                Console.WriteLine(test2.Height);
                Console.WriteLine(test2.Area);
            }
        }
    }
}
