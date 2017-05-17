using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientToREST
{
    class Program
    {
        static void Main(string[] args)
        {
            Request request = new Request();
            request.GetCompanies();
            Console.ReadLine();
        }
    }
}
