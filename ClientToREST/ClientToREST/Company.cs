using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientToREST
{
    public class Company
    {
        public Company()
        {
            //employeeList = new List<Employee>();
        }

        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("RFC")]
        public string RFC { get; set; }
        [JsonProperty("AssignedEmployees")]
        public List<EmployeeReceived> employeeList;
    }
}
