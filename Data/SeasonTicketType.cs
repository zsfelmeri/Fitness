using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Data
{

    public class Ticket
    {
        public string id { get; set; }
        public int deleted { get; set; }
        public string denomination { get; set; }
        public string fromHour { get; set; }
        public string gymId { get; set; }
        public int numberOfValidDays { get; set; }
        public int numberOfValidEntry { get; set; }
        public double price { get; set; }
        public string toHour { get; set; }
        public int usageForDay { get; set; }
    }

    public class TicketNeeded
    {
        public int deleted { get; set; }
        public string denomination { get; set; }
        public string fromHour { get; set; }
        public string gymId { get; set; }
        public int numberOfValidDays { get; set; }
        public int numberOfValidEntry { get; set; }
        public double price { get; set; }
        public string toHour { get; set; }
        public int usageForDay { get; set; }
    }

}
