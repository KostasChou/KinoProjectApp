using KinoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Services
{
    class Statistics
    {
        //LotteryService LotteriesLists { get; set; }

        public Dictionary<int, int> Emergence { get; set; }
        public Dictionary<int, int> KinoEmergence { get; set; }

        public Statistics(List<Lottery> lst)
        {
            
            Emergence = CalculateEmergence(lst);
            KinoEmergence = CalculateKinoEmergence(lst);

        }

        public Dictionary<int, int> CalculateEmergence(List<Lottery> lst)
        {
            var dict = new Dictionary<int, int>();            
            for (int i = 1; i < 81; i++)
            {
                dict[i] = 0;
                
            }
            
            foreach(var lottery in lst)
            {            
                for (int i = 0; i < lottery.LotteryNumbers.Length - 1; i++)
                {
                    dict[lottery.LotteryNumbers[i]] += 1;                   
                }
                
             
            }
            return dict;
        }
        public Dictionary<int, int> CalculateKinoEmergence(List<Lottery> lst)
        {
            var dict = new Dictionary<int, int>();           
            for (int i = 1; i < 81; i++)
            {
                dict[i] = 0;               
            }

            foreach (var lottery in lst)
            {
              
                dict[lottery.LotteryNumbers[11]] ++;
            }
            return dict;
        }
            public void SortDictionary(Dictionary<int, int> dict, Dictionary<int, int> dict2)
        {
            var myList = dict.ToList();
            var myList2 = dict2.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            myList2.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            //foreach (var value in myList)
            //{
            //    Console.WriteLine(value);
            //}
            Console.WriteLine($"Lower Values {myList[0].Key}, {myList[1].Key}, {myList[2].Key}");
            Console.WriteLine($"Highest Values {myList[79].Key}, {myList[78].Key}, {myList[77].Key}");
            Console.WriteLine($"Lowest Kino values {myList2[0].Key}");
            Console.WriteLine($"Highest Values {myList2[79].Key}");

        }

   



        //public Dictionary<int[], int> NumberOfWinningNumbers(List<Result> allResults)
        //{
        //    Dictionary<int[], int> dict = new Dictionary<int[], int>();
        //    foreach (var result in allResults)
        //    {
        //        if (dict.ContainsKey(result.PlayerStatistics))
        //        {
        //            dict[result.PlayerStatistics] += 1;

        //        }
        //        else
        //        {
        //            dict.Add(result.PlayerStatistics, 1);
        //        }
        //    }
        //    return dict;
        //}
        //public void NumbersPlusKino(List<Result> allResults)
        //{
        //    Dictionary<Player, int[]> dict = new Dictionary<Player, int[]>;
        //}
    }
}
