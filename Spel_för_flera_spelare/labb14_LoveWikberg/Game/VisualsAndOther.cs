using labb14_LoveWikberg.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class UI
    {
        ListsAndArrays list = new ListsAndArrays();

        public void AddPlayer()
        {
            Console.Clear();
            Console.Write("Number of players: ");
            int numberOfPlayers;
            bool success = int.TryParse(Console.ReadLine(), out numberOfPlayers);
            ListsAndArrays.playerArray = new Player[numberOfPlayers];

            int playerNumber = 0;
            for (int i = 0; i < ListsAndArrays.playerArray.Length; i++)
            {
                Console.Clear();
                int player = playerNumber + 1;
                Console.Write("Enter player number " + player + "'s name: ");
                string name = Console.ReadLine();
                ListsAndArrays.playerArray[playerNumber] = new Player { SmartScale = 1, Name = name, Id = playerNumber };
                playerNumber++;
            }
        }

        public void ShowList()
        {
            IQuestions[] array = list.questionList.OfType<MathQuestion>().Where(math => int.Equals(math.Difficulty, 3)).ToArray();
            foreach (var item in array)
            {
                Console.WriteLine(item.Question);
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
            Console.WriteLine("\nMediocre:");
            delHandler.FilterPlayer(mediocre);
            Console.WriteLine("\nElite:");
            delHandler.FilterPlayer(elite);
            Console.WriteLine("\nThe Legend");
            delHandler.FilterPlayer(legend);
        }

    }
}
