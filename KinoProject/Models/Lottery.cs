using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Models
{
    class Lottery
    {
        //Properties
        private static Random _randLottery = new Random();       

        public static int _countLotId = 0;
        public int LotteryId { get; set; }
        public int[] LotteryNumbers { get; set; }

        //Constructors
        public Lottery()
        {
            _countLotId++;
            LotteryId = _countLotId;
            LotteryNumbers = GetLotteryNumbers();
        }
        public Lottery(int num)
        {
            _countLotId++;
            LotteryId = _countLotId;           
        }
        //Methods
        public int[] GetLotteryNumbers()
        {
            int[] nums = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int result = _randLottery.Next(1, 81);
                if (nums.Contains(result))
                    i--;
                else
                    nums[i] = result;             
            }
            return nums;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Lottery ID -#{LotteryId} ")
               .Append($" Lottery Numbers : ");
            for (int i = 0; i < LotteryNumbers.Length; i++)
            {
                if (LotteryNumbers[i] != 0)
                {
                    sb.Append($"{LotteryNumbers[i]} ");
                }
            }
            return sb.ToString();
        }
    }
}
