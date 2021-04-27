using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Data
{
    public class Gym
    {
        public Gymid gymId { get; set; }
    }

    public class Gymid
    {
        public int isDeleted { get; set; }
        public string name { get; set; }
    }

}
