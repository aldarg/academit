using System;
using System.Configuration;

namespace Academits.DargeevAleksandr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var siteUrl = ConfigurationManager.AppSettings["SiteUrl"];
            Console.WriteLine(siteUrl);
        }
    }
}
