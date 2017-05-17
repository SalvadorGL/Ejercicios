using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class Company
    {
        public Company()
        {
            AssignedEmployees = new List<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public List<Employee> AssignedEmployees { get; set; }
    }
}