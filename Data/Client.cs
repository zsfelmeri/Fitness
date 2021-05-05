using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Data
{

    public class Client
    {
        public string id { get; set; }
        public string address { get; set; }
        public string barCode { get; set; }
        public string[] comments { get; set; }
        public string email { get; set; }
        public string insertedDate { get; set; }
        public int isDeleted { get; set; }
        public string name { get; set; }
        public string personalIdentity { get; set; }
        public string photo { get; set; }
        public string telefon { get; set; }
    }

    public class ClientNeeded
    {
        public string address { get; set; }
        public string barCode { get; set; }
        public string[] comments { get; set; }
        public string email { get; set; }
        public string insertedDate { get; set; }
        public int isDeleted { get; set; }
        public string name { get; set; }
        public string personalIdentity { get; set; }
        public string photo { get; set; }
        public string telefon { get; set; }
    }
}
