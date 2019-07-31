using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleTrainerBot.Constants;

namespace IdleTrainerBot.Functions
{
    class Main
    {
        public static void IdleClick()
        {
            //Add in code to hold down left click
        }

        /// <summary>
        /// Function that resets the game back to the main Menu
        /// </summary>
        /// <returns></returns>

        public static Boolean ResetToHome()
        {
            WindowCapture.CaptureApplication(GlobalVariables.GLOBAL_PROC_NAME);
            //Force Back To Main Menu && Collect any gold (Thats why its ran 10 times)
            for (int i = 0; i < 10; i++)
            {
                MouseHandler.MoveCursor(LocationConstants.HOME_BOTTOM_BATTLE, true);
            }

            //Check if Menu is Open And Close it if it is

            //Check if Battle Menu is Active and Returns true
            if (isHome())
            {
                Console.WriteLine("Is Home");
                return true;
            }

            /* Going to Do this bit later since i need to find a place where the above will not return True
             * What i need to check ofr is 
             * If Not At Home check for X Button and Click
             * Multiple Close Button Locations
             */
            //Do Comment Above Here


            //ReCheck If Home
            if (isHome())
            {
                Console.WriteLine("Is Home");
                return true;
            }

            Console.WriteLine("Is Not Home");
            return false;
        }

        public static bool ResetToHomePage(int ClicksUntilHome)
        {
            for (int i = 0; i < ClicksUntilHome; i++)
            {
                MouseHandler.MoveCursor(LocationConstants.HOME_BOTTOM_BATTLE, true);
            }

            return true;
        }


        public static void Sleep(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        public static Boolean isHome()
        {
            if (PixelChecker.CheckPixelValue(LocationConstants.HOME_BOTTOM_BATTLE_ACTIVE, ColorConstants.HOME_BOTTOM_BATTLE_ACTIVE_COLOR))
            {
                return true;
            }

            return false;
        }

    }
}
