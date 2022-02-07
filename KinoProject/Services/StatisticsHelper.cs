using KinoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Services
{
    class StatisticsHelper
    {
        public List<Lottery> LotteriesHistory { get; set; }
        public static List<Lottery> LotteriesHistory2 { get; set; }

        public StatisticsHelper()
        {
            LotteriesHistory = LotteriesHistory2;
        }
        

    }
}
