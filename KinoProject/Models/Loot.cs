using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Models
{
    class Loot
    {
        public double Total;
        public static double extraLoot;

        public Loot()
        {
            Total = 100000 + extraLoot;
        }
    }
}
