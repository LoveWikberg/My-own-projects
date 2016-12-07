using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class Event
    {
        public static int NumberOfTurns;
        public static int Total;

        public event EventHandler PlayerWin;
        public event EventHandler MemoryEnd;
        public event EventHandler StartMemory;

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

        public void CheckMemory(int add)
        {
            Total += add;

            int i = 0;
            foreach (var node in ListsAndArrays.Grid)
            {
                if (node.Paired == true)
                    i++;
            }
            if (i == 36)
            { OnMemoryEnd(EventArgs.Empty); }

            else if (NumberOfTurns == Total)
            { OnMemoryEnd(EventArgs.Empty); }
        }

        public void OnMemoryEnd(EventArgs e)
        {
            MemoryEnd?.Invoke(this, e);
        }

        public void CheckStartMemory()
        {
            foreach (var player in ListsAndArrays.playerArray)
            {
                if (ListsAndArrays.playerArray[GameClient.playerTurn].MemoryPlayed == false &&
                    ListsAndArrays.playerArray[GameClient.playerTurn].SmartScale > 33)
                {
                    OnStartMemory(EventArgs.Empty);
                }
            }
        }

        public void OnStartMemory(EventArgs e)
        {
            StartMemory?.Invoke(this, e);
        }
    }
}
