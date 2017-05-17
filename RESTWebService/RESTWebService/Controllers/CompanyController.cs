using RESTWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTWebService.Controllers
{
    public class CompanyController : ApiController
    {
        Company company = new Company();
        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            List<Company> companies = new List<Company>();
            
            company.Id = 863;
            company.Name = "Softtek";
            company.RFC = "SFTK9293JS";
            company.AssignedEmployees = new List<Employee> {
                new Employee() { ID = 456, Name = "Jose", LastName = "Perez", Age = 24 },
                new Employee() { ID = 221, Name = "Valeria", LastName = "Castro", Age = 22 },
                new Employee() { ID = 930, Name = "Yonathan", LastName = "Mendoza", Age = 32 }
            };
            companies.Add(company);
            Company company2 = new Company();
            company2.Id = 2;
            company2.Name = "Advancio";
            company2.RFC = "ADV2828WJS";
            companies.Add(company2);
            return companies;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Company/5
        public Company Get(int id)
        {
            company.Id = 2231;
            company.Name = "Softtek" + id;
            company.RFC = "SFTK9293JS";
            company.AssignedEmployees = new List<Employee> {
                new Employee() { ID = 456, Name = "Jose", LastName = "Perez", Age = 24 },
                new Employee() { ID = 221, Name = "Valeria", LastName = "Castro", Age = 22 },
                new Employee() { ID = 930, Name = "Yonathan", LastName = "Mendoza", Age = 32 }
            };

            return company;
            //return "value";
        }

        // POST: api/Company
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}
