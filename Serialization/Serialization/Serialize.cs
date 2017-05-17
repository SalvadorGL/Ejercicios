using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Serialization
{
    public class Serialize
    {
        Employee employee = new Employee();
        public Serialize()
        {
            employee.ID = 826;
            employee.Name = "Salvador";
            employee.LastName = "Gonzalez";
            employee.Age = 28;
        }

        public void SOAP()
        {
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream("MySoap.soap", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, employee);
            stream.Close();

            Console.WriteLine("Object Seralization To SOAP!!");
            Console.ReadLine();
        }

        public void JSON()
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Employee));
            Stream stream = new FileStream("MyJson.json", FileMode.Create,FileAccess.Write,FileShare.Write);
            formatter.WriteObject(stream, employee);
            stream.Close();

            Console.WriteLine("Object Seralization To JSON!!");
            Console.ReadLine();
        }
        
        public void XML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Employee));
            Stream stream = new FileStream("MyXml.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, employee);
            stream.Close();

            Console.WriteLine("Object Seralization To XML!!");
            Console.ReadLine();
        }
    }
}
