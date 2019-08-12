﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;
using System.Drawing;
using IdleTrainerBot.Constants;

namespace IdleTrainerBot.Functions
{
    class ImageToText
    {
        public static String ImageText(Point Location, Size SizeOfRec, bool EnhanceContrast = true, bool EnchanceResolution = true, bool Advanced = true, bool RotateStraight = false)
        {
            Rectangle section = new Rectangle(Location, SizeOfRec);

            Bitmap ScreenCap = WindowCapture.CaptureApplication("Nox");
            Bitmap ExtractedPart = new Bitmap(section.Width, section.Height);

            Graphics G = Graphics.FromImage(ExtractedPart);

            G.DrawImage(ScreenCap, 0, 0, section, GraphicsUnit.Pixel);

            AdvancedOcr.OcrStrategy StratType = AdvancedOcr.OcrStrategy.Fast;

            if (Advanced)
            {
                StratType = AdvancedOcr.OcrStrategy.Advanced;
            }

            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = EnhanceContrast,
                EnhanceResolution = EnchanceResolution,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = StratType,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = true,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = RotateStraight,
                ReadBarCodes = false,
                ColorDepth = 24
            };
            var Results = Ocr.Read(ExtractedPart);

            ExtractedPart.Save("Test.bmp");

            return Results.Text;
        }

        public static String GymBattleCheck(int Multiplier = 0)
        {
            /*
             * 1. Read Text From Bottom To Top (Only Reads Text From A Sepcific Box Size on the right hand side)
             * 2. If Text = Battle Save Position && Colour
             * 3. Return Colour && / || Battle
             * 4. Use Colour / Battle In Parent Function To Click The Button
             */

            //Requires ColourSpace == GrayScale

            if (Multiplier == 3) //Check to make sure Function doesn't keep recalling it self
            {
                return "Invalid";
            }

            int x = TextConstants.GYM_BATTLE_START.X;
            int y = TextConstants.GYM_BATTLE_START.Y;

            //x = x * Multiplier; No Need to Change X
            y = y - (254 * Multiplier);

            Point NewPoint = new Point(x, y);

            string boxText = ImageText(NewPoint, TextConstants.GYM_BATTLE_SIZE, true, true, false, false);

            if (boxText != "Battle")
            {
                return GymBattleCheck(Multiplier + 1);
            }
            return boxText;
        }


        public static String HomeBoss()
        {
            WindowCapture.CaptureApplication(GlobalVariables.GLOBAL_PROC_NAME);
            string BossStatus = ImageText(TextConstants.HOME_BOSS_START, TextConstants.HOME_BOSS_SIZE, false, true, true, true);
            BossStatus = BossStatus.ToLower();

            MessageBox.Show(BossStatus);
            if (BossStatus.EndsWith("battle"))
            {
                BossStatus = "battle";
            }

            if ((BossStatus != "battle") && (BossStatus != "next"))
            {
                Console.WriteLine(BossStatus);
                Console.WriteLine("Problem Recalling Function");
                HomeBoss(); //Sometimes The Animation on the Boss Button makes the text unreadable // Incorrect
            }
            Console.WriteLine("Returning");
            return BossStatus;
        }

        /// <summary>
        /// Gets Level
        /// </summary>
        /// <returns></returns>
        public static String GetPlayerLevel()
        {
            //Requires Colour Space == Color
            WindowCapture.CaptureApplication(GlobalVariables.GLOBAL_PROC_NAME);
            Main.Sleep(1);
            MouseHandler.MoveCursor(LocationConstants.GLOBAL_LEVEL_BAR, true);
            Main.Sleep(1);
            string playerLevel = ImageText(TextConstants.LEVEL_START, TextConstants.LEVEL_START_SIZE, false, true, false, false);
            MessageBox.Show(playerLevel);

            return playerLevel;
        }

        public static int GetGemAmount()
        {
            //Requires ColorSpace == GrayScale
            string GemAmount = ImageText(TextConstants.GEM_START, TextConstants.GEM_START_SIZE, false, true, false, false);
            MessageBox.Show(GemAmount);
            try
            {
                return Convert.ToInt32(GemAmount);
            }
            catch
            {
                return -1;
            }
        }

        public static int GetGoldAmount()
        {
            //Requires ColorSpace == GrayScale || Color (This Means a check needs to be added to see if the value is -1 retry with ColorSpace == Color.
            string MoneyText = ImageText(TextConstants.GOLD_START, TextConstants.GOLD_START_SIZE, false, true, false, false);
            MoneyText = MoneyText.ToLower();
            MessageBox.Show(MoneyText);

            int MoneyValue;

            if (MoneyText.EndsWith("k"))
            {
                MoneyValue = MultiplyValue(MoneyText, 1000);
            }
            else if (MoneyText.EndsWith("m"))
            {
                MoneyValue = MultiplyValue(MoneyText, 1000000);
            }
            else
            {
                MoneyValue = StringToInt(MoneyText);
            }
            MessageBox.Show(MoneyValue.ToString());
            return MoneyValue;
        }

        public static int StringToInt(string value)
        {
            try
            {
                return Convert.ToInt32(value.Substring(0, value.Length));
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int MultiplyValue(string ValToMultiply, int Amount)
        {
            try
            {
                return Convert.ToInt32(ValToMultiply.Substring(0, ValToMultiply.Length - 1)) * Amount;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}