using System.IO;

namespace lection16
{
    class Task1
    {
        static void Main(string[] args)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream("hills.jpg", FileMode.Open, FileAccess.Read)))
            {
                using (BinaryWriter writer = new BinaryWriter(new FileStream("hills_copy.jpg", FileMode.Create, FileAccess.ReadWrite)))
                {
                    int read = 0;
                    byte[] bytes = new byte[10000];

                    while ((read = reader.Read(bytes, 0, bytes.Length)) > 0)
                    {
                        writer.Write(bytes, 0, read);
                    }
                }
            }
        }
    }
}
