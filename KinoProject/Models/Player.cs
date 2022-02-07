using KinoProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Models
{
    class Player
    {
        //Properties
        private static Random _rand = new Random();
        public int[] Numbers { get; set; }
        public static int _countId = 0;
        //private int _id;        
        //private double _amount;
        public int Id { get; set; }
        public int NumOfNums { get; set; } = _rand.Next(6, 8);
        //public double Amount { get; set; }

        //Constructors
        public Player()
        {
            _countId++;
            Id = _countId;
            Numbers = PlayerService.ChoosingNumbers();
        }
        //Methods
        public override string ToString()
        {
            Console.Clear();
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
