using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Data
{
    public class User
    {
        public string id { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public int role { get; set; }
        public string phoneNumber { get; set; }
    }

    public class UserNeeded
    {
        public string address { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public int role { get; set; }
        public string phoneNumber { get; set; }
    }
}
