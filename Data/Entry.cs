using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Data
{

    public class Entry
    {
        public string id { get; set; }
        public string barCode { get; set; }
        public string clientId { get; set; }
        public string date { get; set; }
        public string gymId { get; set; }
        public string insertedbyUid { get; set; }
        public string ticketId { get; set; }
    }

    public class EntryNeeded
    {
        public string barCode { get; set; }
        public string clientId { get; set; }
        public string date { get; set; }
        public string gymId { get; set; }
        public string insertedbyUid { get; set; }
        public string ticketId { get; set; }
    }

}
