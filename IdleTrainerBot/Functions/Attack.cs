using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdleTrainerBot.Constants;

namespace IdleTrainerBot.Functions
{
    class Attack
    {


        public static void SkyPillarAttackHandler()
        {
            WindowCapture.CaptureApplication(GlobalVariables.GLOBAL_PROC_NAME);

            Main.ResetToHome();

            OpenObjects.OpenSkyPilar();

            AttackSkyPillar();
            
        }

        public static Boolean CheckWin()
        {
            if (PixelChecker.CheckPixelValue(LocationConstants.GLOBAL_BATTLE_CHECK_WIN, ColorConstants.GLOBAL_BATTLE_WON))
            {
                return true;
            }
            else if (PixelChecker.CheckPixelValue(LocationConstants.GLOBAL_BATTLE_CHECK_WIN, ColorConstants.GLOBAL_BATTLE_LOST))
            {
                return false;
            }
            else
            {
                return CheckWin();
            }
        }

        public static void AttackSkyPillar()
        {
            bool AttackingPillar = true;

            while (AttackingPillar)
            {
                for (int CurrentTry = 0; CurrentTry < OtherConstants.ATACK_RETRY_AMOUNT; CurrentTry++)
                {
                    Main.Sleep(1);
                    MouseHandler.MoveCursor(LocationConstants.SKYPILLAR_BATTLE_LOCATION, true);
                    Main.Sleep(1);
                    MouseHandler.MoveCursor(LocationConstants.SKYPILLAR_ENEMYINFO_BATTLE_CONFIRM, true);
                    Main.Sleep(1);
                    MouseHandler.MoveCursor(LocationConstants.SKYPILLAR_TEAM_BATTLE_CONFIRM, true);
                    Main.Sleep(1);

                    MouseHandler.MoveCursor(LocationConstants.GLOBAL_BATTLE_SKIP, true);
                    MouseHandler.MoveCursor(LocationConstants.GLOBAL_BATTLE_SKIP_CONFIRM, true);
                    bool BattleFinished = false;

                    while (!BattleFinished)
                    {
                        //Sleep for 2 seconds and then Check
                        Main.Sleep(2);

                        if (PixelChecker.CheckPixelValue(LocationConstants.GLOBAL_BATTLE_FINISHED, ColorConstants.GLOBAL_BATTLE_FINISHED))
                        {
                            BattleFinished = true;
                        }
                    }

                    bool BattleWon = CheckWin();

                    if (BattleWon)
                    {
                        Main.Sleep(1);
                        MouseHandler.MoveCursor(LocationConstants.GLOBAL_BATTLE_FINISHED, true);
                        break;
                    }
                    else
                    {
                        Main.Sleep(1);
                        MouseHandler.MoveCursor(LocationConstants.GLOBAL_BATTLE_FINISHED, true);
                        if (CurrentTry == 2)
                        {
                            AttackingPillar = false;
                        }
                    }

                }
            }
        }
    }
}
