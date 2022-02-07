using KinoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Services
{
    class LotteryService
    {
        public List<Lottery> Lotteries;

        public LotteryService(int numOfLotteries)
        {
            Lotteries = new List<Lottery>();
            GenerateLotteries(numOfLotteries);
        }

        public void GenerateLotteries(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Lottery lott = new Lottery();
                Lotteries.Add(lott);
            }
            
        }
    }
}
