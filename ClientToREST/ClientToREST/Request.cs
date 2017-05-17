using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientToREST
{
    public class Request
    {
        public void Get()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:49829/api/Employee");
            webRequest.Method = "GET";
            webRequest.ContentType = "text/xml";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());
            Console.WriteLine(responseStream.ReadToEnd());
            webResponse.Close();
            Console.ReadLine();
        }

        public void GetWithParams()
        {
            string endPoint = "http://localhost:49829/api/Employee/6234";
            string method = "GET";
            string contentType = "tex/xml";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            webRequest.Method = method;
            webRequest.ContentType = contentType;
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());
            string response = responseStream.ReadToEnd();
            Console.WriteLine(response);
            webResponse.Close();
            Console.ReadLine();
            Console.WriteLine("Deserializing obtained JSON Response...");
            Employee employee = JsonConvert.DeserializeObject<Employee>(response);
            Console.WriteLine("ID =>" + employee.id);
            Console.WriteLine("Name =>" + employee.name);
            Console.WriteLine("LastName =>" + employee.lastName);
            Console.WriteLine("Age =>" + employee.age);
            Console.ReadLine();
        }

        public void GetEmployeeList()
        {
            string endPoint = "http://localhost:49829/api/Employee/";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            webRequest.Method = "GET";
            webRequest.ContentType = "tex/xml";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());
            string response = responseStream.ReadToEnd();
            Console.WriteLine(response);
            Console.WriteLine("");
            Console.ReadLine();

            List<Employee> employeeList = new List<Employee>();
            employeeList = JsonConvert.DeserializeObject<List<Employee>>(response);

            foreach (var item in employeeList)
            {
                Console.WriteLine("============================");
                Console.WriteLine("ID : " + item.id);
                Console.WriteLine("Name : " + item.name);
                Console.WriteLine("Last Name : " + item.lastName);
                Console.WriteLine("Age : " + item.age);
            }

            Console.ReadLine();
            
        }

        public void GetCompanies()
        {
            string endPoint = "http://localhost:49829/api/Company/";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            webRequest.Method = "GET";
            webRequest.ContentType = "tex/xml";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());
            string response = responseStream.ReadToEnd();
            Console.WriteLine(response);
            Console.WriteLine("");
            Console.ReadLine();

            //Company company = JsonConvert.DeserializeObject<Company>(response);

            List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(response);

            Console.WriteLine("================================");
            Console.WriteLine("======Deserialized Result=======");

            Console.WriteLine("COM");

            foreach (var item in companies)
            {
                Console.WriteLine("======COMPANY=====");
                Console.WriteLine("ID : " + item.Id);
                Console.WriteLine("Name : " + item.Name);
                Console.WriteLine("RFC : " + item.RFC);
                foreach (var employee in item.employeeList)
                {
                    Console.WriteLine("=============EMPLOYEES IN COMPANY============");
                    Console.WriteLine("=====>ID: " + employee.id);
                    Console.WriteLine("=====>Name: " + employee.name);
                    Console.WriteLine("=====>LastName: " + employee.lastName);
                    Console.WriteLine("=====>Age: " + employee.Age);
                }
            }


        }

        public void GetCompany()
        {
            string endPoint = "http://localhost:49829/api/Company/3";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            webRequest.Method = "GET";
            webRequest.ContentType = "tex/xml";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());
            string response = responseStream.ReadToEnd();
            Console.WriteLine(response);
            Console.WriteLine("");
            Console.ReadLine();

            Company company = JsonConvert.DeserializeObject<Company>(response);

            //List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(response);

            //Console.WriteLine("Company ID: " + companies.Id);
            //Console.WriteLine("Company Name: " + company.Name);
            //Console.WriteLine("Company RFC: " + company.RFC);

            //foreach (var item in company.employeeList)
            //{
            //    Console.WriteLine("======EMPLOYEE=====");
            //    Console.WriteLine("ID : " + item.id);
            //    Console.WriteLine("Name : " + item.name);
            //    Console.WriteLine("Last Name : " + item.lastName);
            //    Console.WriteLine("Age : " + item.age);
            //}


        }

    }
}
