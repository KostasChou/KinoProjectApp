using KinoProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Models
{
    class Application
    {
        public void Start()
        {
            RunMainMenu();
        }
        //Main menu
        private void RunMainMenu()
        {
            string prompt = @"      :::    :::       :::::::::::       ::::    :::       :::::::: 
     :+:   :+:            :+:           :+:+:   :+:      :+:    :+: 
    +:+  +:+             +:+           :+:+:+  +:+      +:+    +:+  
   +#++:++              +#+           +#+ +:+ +#+      +#+    +:+   
  +#+  +#+             +#+           +#+  +#+#+#      +#+    +#+    
 #+#   #+#            #+#           #+#   #+#+#      #+#    #+#     
###    ###       ###########       ###    ####       ########       

BIG MONEY AWAITS YOU
(Use the ARROW KEYS to cycle through options and press ENTER to select an option)

";
            string[] options = { "Make a single draw", "Make multiple draws","Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    MenuService.SinglePlayerDraw();
                    RunMainMenu();
                    break;
                case 1:
                    RunSecondaryMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        //Secondary menu
        private void RunSecondaryMenu()
        {
            string prompt = @"      :::    :::       :::::::::::       ::::    :::       :::::::: 
     :+:   :+:            :+:           :+:+:   :+:      :+:    :+: 
    +:+  +:+             +:+           :+:+:+  +:+      +:+    +:+  
   +#++:++              +#+           +#+ +:+ +#+      +#+    +:+   
  +#+  +#+             +#+           +#+  +#+#+#      +#+    +#+    
 #+#   #+#            #+#           #+#   #+#+#      #+#    #+#     
###    ###       ###########       ###    ####       ########       

BIG MONEY AWAITS YOU
(Use the ARROW KEYS to cycle through options and press ENTER to select an option)

";
            string[] options = { "Make multiple draws for many players", "Statistics","Back to previous Menu" };
            Menu secondaryMenu = new Menu(prompt, options);
            int selectedIndex = secondaryMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    MenuService.ManyPlayersDraw();
                    RunMainMenu();
                    break;
                case 1:                    
                    MenuService.GetStatistics();
                    Console.ReadKey();
                    RunMainMenu();
                    break;
                case 2:
                    RunMainMenu();
                    break;
            }
        }
        

    }
}
