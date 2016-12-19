using labb14_LoveWikberg.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class Filter
    {
        public static bool Neewb(Player player)
        {
            return player.SmartScale <= 33;
        }

        public static bool Experienced(Player player)
        {
            return player.SmartScale > 33 && player.SmartScale <= 66;
        }

        public static bool Elite(Player player)
        {
            return player.SmartScale > 66 && player.SmartScale < 100;
        }

        public static bool TheLegend(Player player)
        {
            return player.SmartScale >= 100;
        }

    }
}
