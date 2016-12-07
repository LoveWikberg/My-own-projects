using labb14_LoveWikberg.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class VisualsAndOther
    {
        ListsAndArrays list = new ListsAndArrays();

        public void AddPlayer()
        {
            Console.Clear();
            Console.Write("Antal spelare: ");
            int numberOfPlayers;
            bool success = int.TryParse(Console.ReadLine(), out numberOfPlayers);
            ListsAndArrays.playerArray = new Player[numberOfPlayers];

            int playerNumber = 0;
            for (int i = 0; i < ListsAndArrays.playerArray.Length; i++)
            {
                Console.Clear();
                int player = playerNumber + 1;
                Console.Write("Mata in spelare nummer " + player + "'s namn: ");
                string name = Console.ReadLine();
                ListsAndArrays.playerArray[playerNumber] = new Player { SmartScale = 0, Name = name, Id = playerNumber };
                playerNumber++;
            }
        }

        public void SeeScore()
        {
            DelegateHandler delHandler = new DelegateHandler();
            PlayerDelegate neewb = Filter.Neewb;
            PlayerDelegate mediocre = Filter.Experienced;
            PlayerDelegate elite = Filter.Elite;
            PlayerDelegate legend = Filter.TheLegend;


            Console.WriteLine("\nNeewb:");
            delHandler.FilterPlayer(neewb);
            Console.WriteLine("\nHyffsad:");
            delHandler.FilterPlayer(mediocre);
            Console.WriteLine("\n1337:");
            delHandler.FilterPlayer(elite);
            Console.WriteLine("\nBäst i världen");
            delHandler.FilterPlayer(legend);
        }

        public void Rules()
        {
            Console.Clear();
            Console.WriteLine("Det här är ett (o)vanligt Quiz med en twist!\n");
            Console.WriteLine("* Spelaren vars tur det är får välja en kategori samt svårighetsgrad.");
            Console.WriteLine("* När frågan visas - skriv in siffran till det alternativ du tror är rätt och tryck ENTER:");
            Console.WriteLine("* Frågorna går på tid");
            Console.WriteLine("   - Lätt fråga = 10 sekunder");
            Console.WriteLine("   - Medelsvår fråga = 20 sekunder");
            Console.WriteLine("   - Svår fråga = 30 sekunder");
            Console.WriteLine("* Vid rätt svar tilldelas spelaren poäng.");
            Console.WriteLine("* När en spelare når en viss poäng kommer denne att få välja om denne vill utmana en annan\nspelare i ett mini-spel.");
            Console.ReadKey();
        }

        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

    }
}
