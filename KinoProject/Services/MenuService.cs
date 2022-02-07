using KinoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Services
{
    class MenuService
    {
        //Methods
        public static void ManyPlayersDraw()
        {
            Console.Clear();
            Console.WriteLine("How many players do you want?");
            string answer = Console.ReadLine();
            while (Validation.IsValid(answer))
            {
                if (Validation.IsValid(answer))
                {
                    Console.WriteLine("Please choose a number!");
                    answer = Console.ReadLine();
                }
            }
            int num = Int32.Parse(answer);
            PlayerService ps = new PlayerService(num);

            Console.WriteLine("How many lotteries do you want?");
            string answer2 = Console.ReadLine();
            while (Validation.IsValid(answer2))
            {
                if (Validation.IsValid(answer2))
                {
                    Console.WriteLine("Please choose a number!");
                    answer2 = Console.ReadLine();
                }
            }
            int num2 = Int32.Parse(answer2);

            LotteryService ls = new LotteryService(num2);
            StatisticsHelper.LotteriesHistory2 = ls.Lotteries;
            Console.Clear();
            foreach (var item in ls.Lotteries)
            {
                Loot loot = new Loot();
                Result result1 = new Result(ps.Players, item, loot);
                
                Result.PrintAllResults(Result.ReturnStatisticsMethod(result1.ManyPlayerStats));                
            }
            
            Console.ReadKey();
        }
        public static void SinglePlayerDraw()
        {
            Player player1 = new Player();
            Console.WriteLine(player1);
            Lottery lottery1 = new Lottery();
            Console.WriteLine(lottery1);
            Result result1 = new Result(player1, lottery1);
            result1.PrintPlayerResult();
            Console.ReadKey();
        }

        public static void GetStatistics()
        {
            Console.Clear();
            var stats = new StatisticsHelper();
            var stat = new Statistics(stats.LotteriesHistory);
            stat.SortDictionary(stat.Emergence, stat.KinoEmergence);
        }

    }
}
