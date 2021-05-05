using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Data
{
    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string personalIdentity { get; set; }
        public string mobile { get; set; }
    }

    public class EmployeeNeeded
    {
        public string name { get; set; }
        public string address { get; set; }
        public string personalIdentity { get; set; }
        public string mobile { get; set; }
    }
}
