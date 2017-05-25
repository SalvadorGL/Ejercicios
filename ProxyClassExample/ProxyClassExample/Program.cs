using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProxyClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyConvertor webService = new CurrencyConvertor();

            Console.WriteLine("USD to MXN: " + webService.ConversionRate(Currency.USD, Currency.MXN).ToString());
            Console.ReadLine();
        }
    }
}
