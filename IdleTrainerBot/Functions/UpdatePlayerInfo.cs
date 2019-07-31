using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleTrainerBot.Constants;
using System.Threading;
namespace IdleTrainerBot.Functions
{
    class UpdatePlayerInfo
    {
        public static Boolean[] CheckMenu()
        {
            //Reset To Main Menu

            //Open Menu First
            MouseHandler.MoveCursor(LocationConstants.HOME_MENU_BUTTON, true);

            //Setting Up Boolean Var
            Boolean[] NotifAvailable = new Boolean[3];

            //Take New Screenshot
            WindowCapture.CaptureApplication(GlobalVariables.GLOBAL_PROC_NAME);


            //Training Center
            NotifAvailable[0] = false;

            //Friends
            NotifAvailable[1] = false;

            //Trainer
            NotifAvailable[2] = false;

            //Mail
            if (PixelChecker.CheckPixelValue(LocationConstants.MENU_MAIL_BUTTON, ColorConstants.MENU_MAIL_REDINFO_COLOR))
            {
                MouseHandler.MoveCursor(LocationConstants.MENU_MAIL_BUTTON, true);
                Thread.Sleep(500);
                MouseHandler.MoveCursor(LocationConstants.MAIL_CLAIMALL_BUTTON, true);

                while (PixelChecker.CheckPixelValue(LocationConstants.MAIL_DELETE_BUTTON, ColorConstants.MAIL_DELETE_COLOR))
                {
                    MouseHandler.MoveCursor(LocationConstants.MAIL_DELETE_BUTTON, true);
                }
            }
            else
            {
                //Console Log
            }




            Boolean[] B = new Boolean[3];

            B[0] = true;

            return B;
        }

        public static Boolean MailEmpty()
        {
            return true;
        }
    }
}
