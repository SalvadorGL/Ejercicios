using RESTWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTWebService.Controllers
{
    public class EmployeeController : ApiController
    {
        Employee employee = new Employee { ID=20, Name="Salvador", LastName="Gonzalez", Age=28 };
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(employee);
            employeeList.Add(new Employee { ID = 882, Name = "Alma", LastName = "Cervantes", Age = 33 });
            return employeeList;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            employee.ID=id;
            return employee;
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
