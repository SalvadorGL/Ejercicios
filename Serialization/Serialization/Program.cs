using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee employee = new Employee();
            //employee.ID = 826;
            //employee.Name = "Salvador";
            //employee.LastName = "Gonzalez";
            //employee.Age = 28;

            ////
            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);

            //formatter.Serialize(stream, employee);
            //stream.Close();

            //Console.WriteLine("Object Seralization!!");
            //Console.ReadLine();

            ////Deserialization
            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //Employee employee = (Employee)formatter.Deserialize(stream);
            //stream.Close();

            //Console.WriteLine("ID =>" + employee.ID);
            //Console.WriteLine("Name =>" + employee.Name);
            //Console.WriteLine("LastName =>" + employee.LastName);
            //Console.WriteLine("Age =>" + employee.Age);

            //Console.ReadLine();

            Serialize serialize = new Serialize();
            Deserialize deserialize = new Deserialize();
            //serialize.SOAP();
            //deserialize.SOAP();
            //serialize.JSON();
            //deserialize.JSON();
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    serialize.XML();
                    deserialize.XML();
                    break;
                case "2":
                    serialize.SOAP();
                    deserialize.SOAP();
                    break;
                default:
                    break;
            }
            

            Console.ReadLine();

        }
    }
}
