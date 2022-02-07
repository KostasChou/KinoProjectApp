using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Models
{
    class PlayerRnd
    {
        //Properties
        private static Random _rand = new Random();
        public static int _countId = 0;
        private int[] _numbers;      
        public int Id { get; set; }
        public int NumOfNums { get; set; } = 7;
        public int[] Numbers
        {
            get
            {
                return _numbers;
            }
            set
            {
                _numbers = GetPlayerNumbers(NumOfNums);
            }
        }

        //private double _amount;
        //public double Amount { get; set; }

        //Constructors
        public PlayerRnd()
        {
            _countId++;
            Id = _countId;
            NumOfNums = NumOfNums;
            Numbers = GetPlayerNumbers(NumOfNums);
        }
        //Methods
        public int[] GetPlayerNumbers(int num)
        {
            int[] nums = new int[7];

            for (int i = 0; i < num; i++)
            {
                int result = _rand.Next(1, 81);

                if (nums.Contains(result))
                {
                    i--;
                }
                else
                {
                    nums[i] = result;
                }
            }
            return nums;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Player ID-#{Id}, ")
               .Append($" Player Numbers : ");

            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] != 0)
                {
                    sb.Append($"{Numbers[i]} ");
                }
            }
            return sb.ToString();
        }
    }
}
