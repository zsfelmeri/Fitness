using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Data
{

    public class Gym
    {
        public string id { get; set; }
        public int isDeleted { get; set; }
        public string name { get; set; }
    }

    public class GymNeeded
    {
        public int isDeleted { get; set; }
        public string name { get; set; }
    }

}
