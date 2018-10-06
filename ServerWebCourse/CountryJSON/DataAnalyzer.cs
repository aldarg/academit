using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CountryJSON
{
    public class DataAnalyzer
    {
        public static void Main(string[] args)
        {
            var wc = new WebClient();
            try
            {
                wc.DownloadFile("https://restcountries.eu/rest/v2/region/americas", "countries.json");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не получается скачать файл с данными. Ошибка: {e.Message}.");
            }

            var parsedJson = JArray.Parse(File.ReadAllText("countries.json"));
            var populationTotal = parsedJson.Select(x => (int) x["population"]).Sum();

            Console.WriteLine($"Общая численность населения всех стран: {populationTotal} человек.");

            var currencyJson = parsedJson.Select(x => x["currencies"]).Children();
            var currencyList = currencyJson.GroupBy(x => x["code"]).Select(x => x.FirstOrDefault());
            var currencyNameList = currencyList.Select(x => (string) x["name"]).OrderBy(x => x).ToList();

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Список всех используемых валют:");

            foreach (var currency in currencyNameList)
            {
                Console.WriteLine(currency);
            }
        }
    }
}
