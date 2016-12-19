using labb14_LoveWikberg.UI_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class GameClient : Quiz
    {
        VisualsAndOther ui = new VisualsAndOther();
        Event eventObject = new Event();
        Memory mem = new Memory();
        public static int playerTurn = 0;

        public void GameStart()
        {
            if (ListsAndArrays.playerArray == null)
                ui.AddPlayer();

            bool loop = true;

            eventObject.StartMemory += (sender, e) =>
            {
                mem.MemoryGame();
            };

            eventObject.PlayerWin += (sender, e) =>
            {
                foreach (var player in ListsAndArrays.playerArray)
                {
                    if (player.SmartScale >= 100)
                    {
                        Console.WriteLine(player.Name + "vann! Du är en legend!");
                        Console.ReadKey();
                        loop = false;
                    }
                }
            };

            while (loop)
            {
                eventObject.CheckStartMemory();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Det är " + ListsAndArrays.playerArray[playerTurn].Name + "s tur");
                Console.ResetColor();
                Console.WriteLine("[1] Matematikfrågor");
                Console.WriteLine("[2] Allmänbildningsfrågor");
                Console.WriteLine("[3] Språkfrågor");
                Console.WriteLine("[4] Påstående - sant eller falskt");
                Console.WriteLine("[5] Tillbaka");
                ui.SeeScore();
                eventObject.CheckWin();

                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        QuestionMenu(() => GenerateQuestion(1, "math"), () => GenerateQuestion(2, "math"), () => GenerateQuestion(3, "math"), "Matematik");
                        break;

                    case ConsoleKey.D2:
                        QuestionMenu(() => GenerateQuestion(1, "general"), () => GenerateQuestion(2, "general"), () => GenerateQuestion(3, "general"), "Allmänbildning");
                        break;

                    case ConsoleKey.D3:
                        QuestionMenu(() => GenerateQuestion(1, "language"), () => GenerateQuestion(2, "language"), () => GenerateQuestion(3, "language"), "Språk");
                        break;

                    case ConsoleKey.D4:
                        QuestionMenu(() => GenerateQuestion(1, "trueorfalse"), () => GenerateQuestion(2, "trueorfalse"), () => GenerateQuestion(3, "trueorfalse"), "Sant eller falskt");
                        break;

                    case ConsoleKey.D5:
                        loop = false;
                        break;
                }
            }
        }
    }
}
