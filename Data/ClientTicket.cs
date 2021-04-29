using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Data
{

    public class ClientTicket
    {
        public string id { get; set; }
        public string barCode { get; set; }
        public string clientId { get; set; }
        public string firstUsageDate { get; set; }
        public string gymId { get; set; }
        public int numberOfPreviouslyAccess { get; set; }
        public string purchaseDate { get; set; }
        public double sellingPrice { get; set; }
        public string ticketId { get; set; }
        public int valid { get; set; }
    }

    public class ClientTicketNeeded
    {
        public string barCode { get; set; }
        public string clientId { get; set; }
        public string firstUsageDate { get; set; }
        public string gymId { get; set; }
        public int numberOfPreviouslyAccess { get; set; }
        public string purchaseDate { get; set; }
        public double sellingPrice { get; set; }
        public string ticketId { get; set; }
        public int valid { get; set; }
    }

}
