using labb14_LoveWikberg.UI_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace labb14_LoveWikberg
{
    class Runtime
    {
        GameClient gameClient = new GameClient();
        VisualsAndOther vis = new VisualsAndOther();

        public void Start()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("***********************");
                Console.WriteLine("| [1] Starta spelet   |");
                Console.WriteLine("| [2] Regler och info |");
                Console.WriteLine("| [3] Avsluta         |");
                Console.WriteLine("***********************");

                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        gameClient.GameStart();
                        break;

                    case ConsoleKey.D2:
                        vis.Rules();
                        break;

                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}

