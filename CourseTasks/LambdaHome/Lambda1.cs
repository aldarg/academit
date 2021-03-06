﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Academits.DargeevAleksandr
{
    class Lambda1
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>(6)
            {
                new Person("Василий", 16),
                new Person("Петр", 20),
                new Person("Петр", 10),
                new Person("Василиса", 25),
                new Person("Екатерина Михайловна", 60),
                new Person("Шурик", 37)
            };

            // А) получить список уникальных имен
            var names = persons
                .Select(x => x.Name)
                .Distinct();

            // Б) вывести список уникальных имен
            Console.WriteLine("Имена: " + string.Join(", ", names));

            // В) получить список людей младше 18, посчитать для них средний возраст
            var teens = persons
                .Where(x => x.Age < 18);
            Console.WriteLine(teens.Average(x => x.Age));

            // Г) при помощи группировки получить Map, в котором ключи – имена, а значения – средний возраст
            Dictionary<string, double> map = persons
                .GroupBy(x => x.Name)
                .ToDictionary(x => x.Key, x => x.Average(y => y.Age));

            // Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста

            var adultsNames = persons
                .Where(x => (x.Age >= 20 && x.Age <= 45))
                .Select(x => x.Name)
                .OrderByDescending(x => x);

            Console.WriteLine("Взрослые: " + string.Join(", ", adultsNames));

            Console.WriteLine();
        }
    }
}
