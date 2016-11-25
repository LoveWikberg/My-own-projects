using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class Event
    {
        public event EventHandler PlayerWin;

        public void CheckWin()
        {
            foreach (var player in ListsAndArrays.playerArray)
            {
                if (player.SmartScale >= 100)
                    OnPlayerWin(EventArgs.Empty);
            }
        }

        public void OnPlayerWin(EventArgs e)
        {
            PlayerWin?.Invoke(this, e);
        }
    }
}
