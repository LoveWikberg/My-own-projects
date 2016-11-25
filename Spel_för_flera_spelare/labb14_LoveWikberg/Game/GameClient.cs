using labb14_LoveWikberg.UI_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labb14_LoveWikberg
{
    class GameClient : GameUI
    {
        UI ui = new UI();
        Event win = new Event();
        Memory mem = new Memory();

        public void GameStart()
        {
            if (ListsAndArrays.playerArray == null)
                ui.AddPlayer();
            Memory.playerChallenger = ListsAndArrays.playerArray[0].Id;
            mem.PickOponent();
            mem.PlayerTurn();

            bool loop = true;
            win.PlayerWin += (sender, e) =>
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
                win.CheckWin();

                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        QuestionMenu(() => MathQuestion(1), () => MathQuestion(2), () => MathQuestion(3), "math");
                        break;

                    case ConsoleKey.D2:
                        QuestionMenu(() => GeneralKnowledgeQuestion(1), () => GeneralKnowledgeQuestion(2), () => GeneralKnowledgeQuestion(3), "general");
                        break;

                    case ConsoleKey.D3:
                        QuestionMenu(() => LanguageQuestion(1), () => LanguageQuestion(2), () => LanguageQuestion(3), "language");
                        break;

                    case ConsoleKey.D4:
                        QuestionMenu(() => TrueOrFalseQuestion(1), () => TrueOrFalseQuestion(2), () => TrueOrFalseQuestion(3), "truefalse");
                        break;

                    case ConsoleKey.D5:
                        loop = false;
                        break;
                }
            }
        }
    }
}
