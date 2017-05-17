using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClientToSOAP
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.webservicex.net/CurrencyConvertor.asmx");
            webRequest.Headers.Add("SOAPAction", "http://www.webservicex.net/CurrencyConvertor.asmx?op=ConversionRate");
            webRequest.ContentType = "text/xml";
            webRequest.Method = "POST";

            XmlDocument soapEnvelop = new XmlDocument();
            string xml = "<?xml version='1.0' encoding='utf - 8'?><soap:Envelope xmlns:xsi = 'http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd = 'http://www.w3.org/2001/XMLSchema' xmlns:soap = 'http://schemas.xmlsoap.org/soap/envelope/' ><soap:Body><ConversionRate xmlns = 'http://www.webserviceX.NET/' ><FromCurrency>USD</FromCurrency><ToCurrency>MXN</ToCurrency></ConversionRate></soap:Body></soap:Envelope>";
            webRequest.ContentLength = xml.Length;
            soapEnvelop.LoadXml(xml);

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());

            Console.WriteLine(responseStream.ReadToEnd());
            Console.ReadLine();

        }
    }
}
