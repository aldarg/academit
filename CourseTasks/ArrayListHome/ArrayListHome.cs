using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            // задача 1
            Console.WriteLine("Задача 1");

            try
            {
                string fileName = args[0];

                using (StreamReader reader = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    List<string> fileText = new List<string>();

                    string newLine;

                    while ((newLine = reader.ReadLine()) != null) {
                        fileText.Add(newLine);
                    }

                    foreach (string s in fileText)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден.");
            }

            Console.WriteLine();

            // задача 2
            Console.WriteLine("Задача 2");

            List<int> list1 = new List<int> { 1, 2, 2, 4, 5, 6, 7 };

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] % 2 == 0)
                {
                    list1.RemoveAt(i);
                    i--;
                }
            }

            foreach (int number in list1)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            // задача 3
            Console.WriteLine("Задача 3");

            List<int> list2 = new List<int> { 1, 5, 2, 1, 3, 5 };

            List<int> list3 = new List<int>(list2.Count);

            foreach (int number in list2)
            {
                if (!list3.Contains(number))
                {
                    list3.Add(number);
                }
            }

            foreach (int number in list3)
            {
                Console.WriteLine(number);
            }
        }
    }
}
