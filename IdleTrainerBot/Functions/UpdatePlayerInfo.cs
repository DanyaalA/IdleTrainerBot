﻿using System;
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
            Boolean[] NotifAvailable = new Boolean[5];

            //Take New Screenshot
            WindowCapture.CaptureApplication(GlobalVariables.GLOBAL_PROC_NAME);


            //Training Center
            NotifAvailable[0] = false;

            //Friends
            NotifAvailable[1] = false;

            //Trainer
            NotifAvailable[2] = false;

            //Mail
            NotifAvailable[3] = MailCheck();

            //Claim Daily Bonus
            NotifAvailable[4] = ClaimDailyBonuses();

            // Check For Shards
            NotifAvailable[5] = CheckShards();

            Boolean[] B = new Boolean[3];

            B[0] = true;

            return B;
        }

        public static Boolean MailCheck()
        {
            if (PixelChecker.CheckPixelValue(LocationConstants.MENU_MAIL_BUTTON, ColorConstants.MENU_MAIL_REDINFO_COLOR))
            {
                MouseHandler.MoveCursor(LocationConstants.MENU_MAIL_BUTTON, true);
                Thread.Sleep(500);
                MouseHandler.MoveCursor(LocationConstants.MAIL_CLAIMALL_BUTTON, true);
                Thread.Sleep(500);
                MouseHandler.MoveCursor(LocationConstants.MAIL_CLAIM_BUTTON, true);

                while (PixelChecker.CheckPixelValue(LocationConstants.MAIL_DELETE_BUTTON, ColorConstants.MAIL_DELETE_COLOR))
                {
                    MouseHandler.MoveCursor(LocationConstants.MAIL_DELETE_BUTTON, true);
                }
            }
            else
            {
                // Console Log
            }

            return true;
        }

        public static Boolean ClaimDailyBonuses()
        {
            // Add: Check time before doing this

            MouseHandler.MoveCursor(LocationConstants.HOME_DAILYBONUS_BUTTON, true); 
            Thread.Sleep(500);
            MouseHandler.MoveCursor(LocationConstants.DAILYBONUS_CHECKIN_BUTTON, true);
            Thread.Sleep(500);
            MouseHandler.MoveCursor(LocationConstants.DAILYBONUS_EXIT_BUTTON, true);

            // Claim Daily Money Bonus
            MouseHandler.MoveCursor(LocationConstants.HOME_MONEYBONUS_BUTTON, true);
            Thread.Sleep(500);
            MouseHandler.MoveCursor(LocationConstants.MONEYBONUS_FREE_BUTTON, true);
            Thread.Sleep(500);
            MouseHandler.MoveCursor(LocationConstants.MONEYBONUS_EXIT_BUTTON, true);

            return true;
        }

        public static Boolean CheckShards()
        {
            if (PixelChecker.CheckPixelValue(LocationConstants.HOME_BAG_BUTTON, ColorConstants.HOME_BAG_REDINFO_COLOR))
            {
                MouseHandler.MoveCursor(LocationConstants.HOME_BAG_BUTTON, true);
                Thread.Sleep(500);
                if (PixelChecker.CheckPixelValue(LocationConstants.BAG_SHARDS_BUTTON, ColorConstants.BAG_SHARDS_REDINFO_COLOR))
                {
                    MouseHandler.MoveCursor(LocationConstants.BAG_SHARDS_BUTTON, true);
                    Thread.Sleep(500);
                }
                else
                {
                    MouseHandler.MoveCursor(LocationConstants.BAG_EXIT_BUTTON, true);
                }
            }
            else
            {
                // Console Log
            }

            return true;
        }
    }
}