﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebService.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}