using KinoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Services
{
    class PlayerService
    {
        //Properties
        private static Random _rand = new Random();

        public List<PlayerRnd> Players { get; set; }
        
        public int NumOfPlayers { get; set; }
        //Constructor
        public PlayerService(int numOfPlayers)
        {
            Players = new List<PlayerRnd>();
            GeneratePlayers(numOfPlayers);
        }
        //Methods
        public void GeneratePlayers(int num)
        {
            for (int i = 0; i < num; i++)
            {
                PlayerRnd player = new PlayerRnd();
                Players.Add(player);
            }
        }
        
        public static int[] GetPlayerNumbers(int num)
        {
            int[] nums = new int[7];

            for (int i = 0; i < num; i++)
            {
                int result = _rand.Next(1, 80);

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

        public static int[] ChoosingNumbers()
        {
            Console.Clear();
            string userInput = "";
            string[] stringResult = new string[7];
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine($"Choose a number between 1 and 80 as your No:{i + 1} number and press enter: ");
                userInput = Console.ReadLine();

                while (Validation.IsValidNum(userInput) || stringResult.Contains(userInput))
                {
                    if (Validation.IsValidNum(userInput))
                    {
                        Console.WriteLine("The number must be between 1 and 80, choose again: ");
                        userInput = Console.ReadLine();
                    }

                    if (stringResult.Contains(userInput))
                    {
                        Console.WriteLine("You have already chosen that number, choose again: ");
                        userInput = Console.ReadLine();
                    }
                }

                stringResult[i] = userInput;
            }

            string userBonusTrial = "";

            do
            {
                Console.WriteLine("Whould you like to add a Bonus Number? press \"y\" for yes or \"n\" for no");
                userBonusTrial = Console.ReadLine();

            } while (userBonusTrial != "y" && userBonusTrial != "Y" && userBonusTrial != "n" && userBonusTrial != "N");

            string userBonus = userBonusTrial.ToUpper();


            if (userBonus == "Y")
            {
                Console.WriteLine("Choose your unique Bonus Number: ");
                userInput = Console.ReadLine();

                while (Validation.IsValidNum(userInput) || stringResult.Contains(userInput))
                {
                    if (Validation.IsValidNum(userInput))
                    {
                        Console.WriteLine("The number must be between 1 and 80, choose again: ");
                        userInput = Console.ReadLine();
                    }

                    if (stringResult.Contains(userInput))
                    {
                        Console.WriteLine("You have already chosen that number, choose again: ");
                        userInput = Console.ReadLine();
                    }
                }

                stringResult[6] = userInput;
            }
            else
            {
                stringResult[6] = "0";
            }

            int[] result = Array.ConvertAll(stringResult, s => int.Parse(s));

            return result;
        }
    }
}
