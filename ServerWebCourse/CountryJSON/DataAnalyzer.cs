using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

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

            dynamic countries = JsonConvert.DeserializeObject(File.ReadAllText("countries.json"));

            Console.WriteLine("Список используемых валют:");

            var populationTotal = 0;
            foreach (var country in countries)
            {
                int.TryParse(country.population.ToString(), out int population);
                populationTotal += population;

                foreach (var currency in country.currencies)
                {
                    if (currency.name.ToString() != string.Empty)
                    {
                        Console.WriteLine($"- {currency.name.ToString()}");
                    }
                }
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Общая численность населения всех стран: {populationTotal} человек.");
        }
    }
}
