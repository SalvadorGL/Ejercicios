using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientToREST
{
    public class EmployeeReceived
    {
        [JsonProperty("ID")]
        public int id { get; set; }
        [JsonProperty("Name")]
        public string name { get; set; }
        [JsonProperty("LastName")]
        public string lastName { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
    }
}
