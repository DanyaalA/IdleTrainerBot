using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleTrainerBot.Constants
{
    class TextConstants
    {
        public static Point LEVEL_START = new Point(100, 204);
        public static Point GEM_START = new Point(294, 11);
        public static Point GOLD_START = new Point(432, 12);
        public static Point HOME_BOSS_START = new Point(202, 159);
        public static Point GYM_BATTLE_START = new Point(366, 552);

        public static Size LEVEL_START_SIZE = new Size(27, 20);
        public static Size GEM_START_SIZE = new Size(63, 23);
        public static Size GOLD_START_SIZE = new Size(67,22);
        public static Size HOME_BOSS_SIZE = new Size(137, 47);
        public static Size GYM_BATTLE_SIZE = new Size(86, 34);


        //Battle League Stuff (Alot of them So i made a section for it)
        public static Point LEAGUE_PLAYER_CE_START = new Point(198, 359);
        public static Point LEAGUE_ENEMY_CE_START = new Point(200, 505);
        public static Point ENEMY_PROFILE_CE_START = new Point(433, 300);

        public static Size LEAGUE_PLAYER_CE_SIZE = new Size(88, 28);
        public static Size LEAGUE_ENEMY_CE_SIZE = new Size(91, 28);
        public static Size ENEMY_PROFILE_CE_SIZE = new Size(77, 22);

    }
}
