using IdleTrainerBot.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleTrainerBot.Functions
{
    class OpenObjects
    {
        public static void OpenCity()
        {
            WindowCapture.CaptureApplication(GlobalVariables.GLOBAL_PROC_NAME);
            for (int i = 0; i < 5; i++)
            {
                MouseHandler.MoveCursor(LocationConstants.HOME_BOTTOM_CITY, true);
            }

            MouseHandler.MoveCursor(LocationConstants.CITY_CURSOR_SCROLL);
            MouseHandler.ResetCity();
            Main.Sleep(2);
        }

        public static void OpenItemCenter()
        {
            OpenCity();

            if (PixelChecker.CheckPixelValue(LocationConstants.CITY_ITEMCENTER_BUTTON, ColorConstants.CITY_ITEMCENTER_COLOR))
            {
                MouseHandler.MoveCursor(LocationConstants.CITY_ITEMCENTER_BUTTON);
            }
            {
                //TODO: Max 3 retries before giving up || calling a different function
                OpenItemCenter();
            }
        }
    }
}
