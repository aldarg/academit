using System;

namespace Vector
{
    class VectorHomework
    {
        static void Main(string[] args)
        {
            Vector test1 = new Vector(4);
            Vector test2 = new Vector(new double[] { 1, 2, 3, 4 });

            //TODO: уточнить про null

            double[] a = null;

            //Vector test3 = new Vector(a);
            Vector test4 = new Vector(6, new double[] { 7, 8, 5, 4 });

            Console.WriteLine(test1);
            Console.WriteLine(test2);
            //Console.WriteLine(test3);
            Console.WriteLine(test4);

            Console.WriteLine(test4.GetSize());


        }
    }
}
