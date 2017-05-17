using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public class Deserialize
    {
        public void SOAP()
        {
            //Deserialization
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream("MySoap.soap", FileMode.Open, FileAccess.Read, FileShare.Read);
            Employee employee = (Employee)formatter.Deserialize(stream);
            stream.Close();

            Console.WriteLine("SOAP Deserialization done!!");
            Console.WriteLine("ID =>" + employee.ID);
            Console.WriteLine("Name =>" + employee.Name);
            Console.WriteLine("LastName =>" + employee.LastName);
            Console.WriteLine("Age =>" + employee.Age);

            Console.ReadLine();
        }

        public void JSON()
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Employee));
            Stream stream = new FileStream("MyJson.json", FileMode.Open, FileAccess.Read, FileShare.Read);
            Employee employee = (Employee)formatter.ReadObject(stream);

            Console.WriteLine("JSON Deserialization done!!");
            Console.WriteLine("ID =>" + employee.ID);
            Console.WriteLine("Name =>" + employee.Name);
            Console.WriteLine("LastName =>" + employee.LastName);
            Console.WriteLine("Age =>" + employee.Age);
        }

        public void XML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Employee));
            Stream stream = new FileStream("MyXml.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            Employee employee = (Employee)formatter.Deserialize(stream);

            Console.WriteLine("XML Deserialization done!!");
            Console.WriteLine("ID =>" + employee.ID);
            Console.WriteLine("Name =>" + employee.Name);
            Console.WriteLine("LastName =>" + employee.LastName);
            Console.WriteLine("Age =>" + employee.Age);
        }
    }
}
