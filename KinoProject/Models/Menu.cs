using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Models
{
    class Menu
    {
        //Fields
        private string prompt;
        private string[] options;
        private int selectedIndex;

        //Constructor
        public Menu(string prompt, string[] options)
        {
            this.prompt = prompt;
            this.options = options;
            selectedIndex = 0;
        }
        //Methods
        private void DisplayOptions()
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < options.Length; i++)
            {
                string currentOption = options[i];
                string prefix;

                if (i == selectedIndex)
                {
                    prefix = "-->";
                }
                else
                {
                    prefix = " ";
                }

                Console.WriteLine($"{prefix}  << {currentOption} >>");
            }
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }


            } while (keyPressed != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}
