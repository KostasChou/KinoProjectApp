using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Models
{
    class Result
    {
        //Properties
        public Player Player { get; set; }
        public Lottery Lottery { get; set; }
        public int[] PlayerStatistics { get; set; }
        public List<PlayerRnd> PlayersList { get; set; }
        public List<int[]> ManyPlayerStats;

        public static double newLoot = 100000;
        public static double[] MoneyPerCategory;
        //Constructors
        public Result(Player player, Lottery lottery)
        {
            Player = player;
            Lottery = lottery;
            PlayerStatistics = PlayerResults(player, lottery);
        }
        public Result(List<PlayerRnd> list, Lottery lott, Loot loot)
        {
            PlayersList = list;
            Lottery = lott;
            ManyPlayerStats = ManyPlayersResults(list, lott);
            newLoot = loot.Total;
            MoneyPerCategory = new double[14] {newLoot * 0, newLoot * 0.002, newLoot * 0.006, newLoot * 0.01, newLoot * 0.03, newLoot * 0.07,
            newLoot * 0.23, newLoot * 0, newLoot * 0.004, newLoot * 0.008, newLoot * 0.02, newLoot * 0.05, newLoot * 0.15, newLoot * 0.35 };
        }
        //Methods
        public int[] PlayerResults(Player player, Lottery lottery)
        {
            int[] PlayerStatistics = new int[2];
            var drawNumbers = lottery.LotteryNumbers;
            int winningNumbers = 0;
            for (int i = 0; i < player.Numbers.Length - 1; i++)
            {
                if (drawNumbers.Contains(player.Numbers[i]))
                {
                    winningNumbers++;
                    PlayerStatistics[0] = winningNumbers;
                    PlayerStatistics[1] = 0;
                }
            }
            if (player.Numbers[6] == drawNumbers[11])
            {
                PlayerStatistics[1] = 1;
            }
            return PlayerStatistics;
        }
        public List<int[]> ManyPlayersResults(List<PlayerRnd> list, Lottery lottery)
        {
            var result = new List<int[]>();
            foreach (var player in list)
            {
                int[] PlayerStatistics = new int[2];
                var drawNumbers = lottery.LotteryNumbers;               
                int winningNumbers = 0;
                for (int i = 0; i < player.Numbers.Length - 1; i++)
                {
                    if (drawNumbers.Contains(player.Numbers[i]))
                    {
                        winningNumbers++;
                        PlayerStatistics[0] = winningNumbers;
                        PlayerStatistics[1] = 0;
                    }
                }
                if (player.Numbers[6] == drawNumbers[11])
                {
                    PlayerStatistics[1] = 1;
                }
                result.Add(PlayerStatistics);
            }
            return result;
        }
        public static int[] ReturnStatisticsMethod(List<int[]> resultObject)
        {
            int[] statisticsArray = new int[14];

            for (int j = 0; j < resultObject.Count; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (resultObject[j][0] == i)
                    {
                        if (resultObject[j][1] == 0)
                        {
                            statisticsArray[i]++;
                        }
                        else
                        {
                            statisticsArray[i + 7]++;
                        }
                    }
                }
            }
            return statisticsArray;
        }
        //Printing Methods
        public void PrintPlayerResult()
        {

            Console.WriteLine($"Player ID {Player.Id} - Number of winning numbers {PlayerStatistics[0]}+{PlayerStatistics[1]}");
        }
        public static void PrintAllResults(int[] arr)
        {
            double sum = 0;
            for (int i = 0; i < MoneyPerCategory.Length; i++)
            {
                sum += MoneyPerCategory[i];
            }
            Console.WriteLine($"Total money to share: {sum} euros");
            double extraLoot1 = 0;
            for (int x = 6; x >= 0; x--)
            {
                for (int y = 1; y >= 0; y--)
                {
                    if (y == 1)
                    {
                        if (arr[x + 7] == 0)
                        {
                            Console.WriteLine($"{arr[x + 7]} players got {x} numbers + bonus.");
                            extraLoot1 += Math.Round(MoneyPerCategory[x + 7] / 1, 2);
                        }
                        else
                        {
                            Console.WriteLine($"{arr[x + 7]} players got {x} numbers + bonus. Each gets {Math.Round(MoneyPerCategory[x + 7] / arr[x + 7], 2)} euros");
                        }
                    }
                    else
                    {
                        if (arr[x] == 0)
                        {
                            Console.WriteLine($"{arr[x]} players got {x} numbers and no bonus.");
                            extraLoot1 += Math.Round(MoneyPerCategory[x] / 1, 2);
                        }
                        else
                        {
                            Console.WriteLine($"{arr[x]} players got {x} numbers and no bonus. Each gets {Math.Round(MoneyPerCategory[x] / arr[x], 2)} euros");
                        }
                    }                    
                }
            }
            Loot.extraLoot = extraLoot1;
            Console.WriteLine("------------------------------");
        }
        
    }   
}
