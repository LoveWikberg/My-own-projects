using labb14_LoveWikberg.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class DelegateHandler
    {
        ListsAndArrays list = new ListsAndArrays();

        public void FilterPlayer(PlayerDelegate playerFilter)
        {
            foreach (var player in ListsAndArrays.playerArray)
            {
                if (playerFilter(player))
                {
                    Console.WriteLine(player.Name + " " + player.SmartScale);
                }
            }
        }
    }
}
