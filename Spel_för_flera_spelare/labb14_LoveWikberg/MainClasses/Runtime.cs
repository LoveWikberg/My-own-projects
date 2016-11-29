using labb14_LoveWikberg.UI_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class Runtime
    {
        Memory mem = new Memory();
        GameClient gameClient = new GameClient();
        public void Start()
        {
            //mem.DisplayGameBoard();
            //Console.ReadKey();
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("[1] Starta spelet");
                Console.WriteLine("[2] Regler");
                Console.WriteLine("[3] Avsluta");

                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        gameClient.GameStart();
                        break;

                    case ConsoleKey.D2:
                        break;

                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
