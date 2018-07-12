using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lection19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(300);
            object myLock = new object();

            Thread t1 = new Thread(() =>
            {
                for (int i = 1; i <= 100; ++i)
                {
                    lock(myLock)
                    {
                        int index = list.Count;

                        list.Insert(index, i);
                        Console.WriteLine("Поток1: {0} at {1}", i, index);
                        Thread.Sleep(100);
                    }
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 1; i <= 100; ++i)
                {
                    lock(myLock)
                    {
                        int index = list.Count;

                        list.Insert(list.Count, i);
                        Console.WriteLine("Поток2: {0} at {1}", i, index);
                        Thread.Sleep(100);
                    }
                }
            });

            t1.Start();
            t2.Start();

            t2.Join();
            Console.WriteLine(list.Count);
        }
    }
}
