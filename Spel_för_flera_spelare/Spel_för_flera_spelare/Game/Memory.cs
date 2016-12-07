using labb14_LoveWikberg.PropertyClasses;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace labb14_LoveWikberg
{
    class Memory
    {
        Event memoryEvent = new Event();

        int playerChallenged = 0;
        int playerChallengedPoints;
        int playerChallenger = 0;
        int playerChallengerPoints;
        int turn;

        public Memory()
        {
            #region set Node values
            ListsAndArrays.Grid = new Node[36];
            ListsAndArrays.Grid[0] = new Node { Charachter = 'Q', NotTurned = '?' };
            ListsAndArrays.Grid[1] = new Node { Charachter = 'A', NotTurned = '?' };
            ListsAndArrays.Grid[2] = new Node { Charachter = 'S', NotTurned = '?' };
            ListsAndArrays.Grid[3] = new Node { Charachter = 'K', NotTurned = '?' };
            ListsAndArrays.Grid[4] = new Node { Charachter = 'N', NotTurned = '?' };
            ListsAndArrays.Grid[5] = new Node { Charachter = 'M', NotTurned = '?' };
            ListsAndArrays.Grid[6] = new Node { Charachter = 'R', NotTurned = '?' };
            ListsAndArrays.Grid[7] = new Node { Charachter = 'Y', NotTurned = '?' };
            ListsAndArrays.Grid[8] = new Node { Charachter = 'Q', NotTurned = '?' };
            ListsAndArrays.Grid[9] = new Node { Charachter = 'N', NotTurned = '?' };
            ListsAndArrays.Grid[10] = new Node { Charachter = 'P', NotTurned = '?' };
            ListsAndArrays.Grid[11] = new Node { Charachter = 'Y', NotTurned = '?' };
            ListsAndArrays.Grid[12] = new Node { Charachter = 'Y', NotTurned = '?' };
            ListsAndArrays.Grid[13] = new Node { Charachter = 'P', NotTurned = '?' };
            ListsAndArrays.Grid[14] = new Node { Charachter = 'L', NotTurned = '?' };
            ListsAndArrays.Grid[15] = new Node { Charachter = 'X', NotTurned = '?' };
            ListsAndArrays.Grid[16] = new Node { Charachter = 'D', NotTurned = '?' };
            ListsAndArrays.Grid[17] = new Node { Charachter = 'W', NotTurned = '?' };
            ListsAndArrays.Grid[18] = new Node { Charachter = 'G', NotTurned = '?' };
            ListsAndArrays.Grid[19] = new Node { Charachter = 'S', NotTurned = '?' };
            ListsAndArrays.Grid[20] = new Node { Charachter = 'V', NotTurned = '?' };
            ListsAndArrays.Grid[21] = new Node { Charachter = 'H', NotTurned = '?' };
            ListsAndArrays.Grid[22] = new Node { Charachter = 'M', NotTurned = '?' };
            ListsAndArrays.Grid[23] = new Node { Charachter = 'V', NotTurned = '?' };
            ListsAndArrays.Grid[24] = new Node { Charachter = 'D', NotTurned = '?' };
            ListsAndArrays.Grid[25] = new Node { Charachter = 'C', NotTurned = '?' };
            ListsAndArrays.Grid[26] = new Node { Charachter = 'R', NotTurned = '?' };
            ListsAndArrays.Grid[27] = new Node { Charachter = 'Y', NotTurned = '?' };
            ListsAndArrays.Grid[28] = new Node { Charachter = 'Z', NotTurned = '?' };
            ListsAndArrays.Grid[29] = new Node { Charachter = 'H', NotTurned = '?' };
            ListsAndArrays.Grid[30] = new Node { Charachter = 'Z', NotTurned = '?' };
            ListsAndArrays.Grid[31] = new Node { Charachter = 'A', NotTurned = '?' };
            ListsAndArrays.Grid[32] = new Node { Charachter = 'C', NotTurned = '?' };
            ListsAndArrays.Grid[33] = new Node { Charachter = 'L', NotTurned = '?' };
            ListsAndArrays.Grid[34] = new Node { Charachter = 'X', NotTurned = '?' };
            ListsAndArrays.Grid[35] = new Node { Charachter = 'W', NotTurned = '?' };
            #endregion

            int yOne = 0;
            int yTwo = 0;
            int yThree = 0;
            int yFour = 0;
            int yFive = 0;
            for (int i = 0; i < 36; i++)
            {
                if (i < 6)
                {
                    ListsAndArrays.Grid[i].YAxis = 0;
                    ListsAndArrays.Grid[i].XAxis = i;
                }
                else if (i > 5 && i < 12)
                {
                    ListsAndArrays.Grid[i].YAxis = 1;
                    ListsAndArrays.Grid[i].XAxis = yOne;
                    yOne++;
                }
                else if (i > 11 && i < 18)
                {
                    ListsAndArrays.Grid[i].YAxis = 2;
                    ListsAndArrays.Grid[i].XAxis = yTwo;
                    yTwo++;
                }
                else if (i > 17 && i < 24)
                {
                    ListsAndArrays.Grid[i].YAxis = 3;
                    ListsAndArrays.Grid[i].XAxis = yThree;
                    yThree++;
                }
                    else if (i > 23 && i < 30)
                    {
                    ListsAndArrays.Grid[i].YAxis = 4;
                    ListsAndArrays.Grid[i].XAxis = yFour;
                    yFour++;
                }
                else if (i > 29 && i < 36)
                {
                    ListsAndArrays.Grid[i].YAxis = 5;
                    ListsAndArrays.Grid[i].XAxis = yFive;
                    yFive++;
                }
            }
        }


        public void MemoryGame()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                playerChallenger = ListsAndArrays.playerArray[GameClient.playerTurn].Id;
                Console.WriteLine("{0} får nu välja om hen vill möta valfri motståndare i ett memory-spel.\nOm hen vinner kommer hens motståndare att bli bestraffad med poängavdrag\nmotsvarande differensen mellan spelarnas poäng. Om den utmanade spelaren vinner kommer den att\nbli belönad med poäng motsvarande samma differens.\nVill du spela memory?", ListsAndArrays.playerArray[GameClient.playerTurn].Name);
                Console.WriteLine("[1] Ja");
                Console.WriteLine("[2] Nej");
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        PickOponent();
                        GameLoop();
                        loop = false;
                        break;

                    case ConsoleKey.D2:
                        loop = false;
                        break;
                }
            }
        }

        void PickOponent()
        {
            Console.Clear();
            Event.Total = 0;
            playerChallengedPoints = 0;
            playerChallengerPoints = 0;

            int i = 0;
            foreach (var player in ListsAndArrays.playerArray)
            {
                i++;
                Console.WriteLine(i + ". " + player.Name);
            }
            Console.Write("Mata in talet för spelaren som du vill utmana: ");
            int choice;
            bool successOne = int.TryParse(Console.ReadLine(), out choice);
            playerChallenged = ListsAndArrays.playerArray[choice - 1].Id;

            Console.Write("\nSkriv in antal försök varje spelare ska få: ");
            bool successTwo = int.TryParse(Console.ReadLine(), out Event.NumberOfTurns);
            Event.NumberOfTurns *= 2;
        }

        void DisplayGameBoard()
        {
            Console.WriteLine("Y ___  ___  ___  ___  ___  ___");
            Console.WriteLine(" |   ||   ||   ||   ||   ||   |");
            Console.WriteLine("6| " + ListsAndArrays.Grid[30].NotTurned + " || " + ListsAndArrays.Grid[31].NotTurned + " || " + ListsAndArrays.Grid[32].NotTurned + " || " + ListsAndArrays.Grid[33].NotTurned + " || " + ListsAndArrays.Grid[34].NotTurned + " || " + ListsAndArrays.Grid[35].NotTurned + " |");
            Console.WriteLine(" |___||___||___||___||___||___|");

            Console.WriteLine("  ___  ___  ___  ___  ___  ___");
            Console.WriteLine(" |   ||   ||   ||   ||   ||   |");
            Console.WriteLine("5| " + ListsAndArrays.Grid[24].NotTurned + " || " + ListsAndArrays.Grid[25].NotTurned + " || " + ListsAndArrays.Grid[26].NotTurned + " || " + ListsAndArrays.Grid[27].NotTurned + " || " + ListsAndArrays.Grid[28].NotTurned + " || " + ListsAndArrays.Grid[29].NotTurned + " |");
            Console.WriteLine(" |___||___||___||___||___||___|");

            Console.WriteLine("  ___  ___  ___  ___  ___  ___");
            Console.WriteLine(" |   ||   ||   ||   ||   ||   |");
            Console.WriteLine("4| " + ListsAndArrays.Grid[18].NotTurned + " || " + ListsAndArrays.Grid[19].NotTurned + " || " + ListsAndArrays.Grid[20].NotTurned + " || " + ListsAndArrays.Grid[21].NotTurned + " || " + ListsAndArrays.Grid[22].NotTurned + " || " + ListsAndArrays.Grid[23].NotTurned + " |");
            Console.WriteLine(" |___||___||___||___||___||___|");

            Console.WriteLine("  ___  ___  ___  ___  ___  ___");
            Console.WriteLine(" |   ||   ||   ||   ||   ||   |");
            Console.WriteLine("3| " + ListsAndArrays.Grid[12].NotTurned + " || " + ListsAndArrays.Grid[13].NotTurned + " || " + ListsAndArrays.Grid[14].NotTurned + " || " + ListsAndArrays.Grid[15].NotTurned + " || " + ListsAndArrays.Grid[16].NotTurned + " || " + ListsAndArrays.Grid[17].NotTurned + " |");
            Console.WriteLine(" |___||___||___||___||___||___|");

            Console.WriteLine("  ___  ___  ___  ___  ___  ___");
            Console.WriteLine(" |   ||   ||   ||   ||   ||   |");
            Console.WriteLine("2| " + ListsAndArrays.Grid[6].NotTurned + " || " + ListsAndArrays.Grid[7].NotTurned + " || " + ListsAndArrays.Grid[8].NotTurned + " || " + ListsAndArrays.Grid[9].NotTurned + " || " + ListsAndArrays.Grid[10].NotTurned + " || " + ListsAndArrays.Grid[11].NotTurned + " |");
            Console.WriteLine(" |___||___||___||___||___||___|");

            Console.WriteLine("  ___  ___  ___  ___  ___  ___");
            Console.WriteLine(" |   ||   ||   ||   ||   ||   |");
            Console.WriteLine("1| " + ListsAndArrays.Grid[0].NotTurned + " || " + ListsAndArrays.Grid[1].NotTurned + " || " + ListsAndArrays.Grid[2].NotTurned + " || " + ListsAndArrays.Grid[3].NotTurned + " || " + ListsAndArrays.Grid[4].NotTurned + " || " + ListsAndArrays.Grid[5].NotTurned + " |");
            Console.WriteLine(" |___||___||___||___||___||___|");
            Console.WriteLine("   1    2    3    4    5    6  X");

            if (turn == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n{0} poäng: " + playerChallengerPoints, ListsAndArrays.playerArray[playerChallenger].Name);
                Console.ResetColor();
                Console.Write("       {0} poäng: " + playerChallengedPoints, ListsAndArrays.playerArray[playerChallenged].Name);
            }
            else if (turn == 2)
            {
                Console.Write("\n{0} poäng: " + playerChallengerPoints, ListsAndArrays.playerArray[playerChallenger].Name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("       {0} poäng: " + playerChallengedPoints, ListsAndArrays.playerArray[playerChallenged].Name);
                Console.ResetColor();
            }
        }

        void GameLoop()
        {
            foreach (var node in ListsAndArrays.Grid)
            {
                node.NotTurned = '?';
                node.Paired = false;
            }

            bool loop = true;
            memoryEvent.MemoryEnd += (sender, e) =>
            {
                EndOfMemory();
                loop = false;
            };

            turn = 1;
            while (loop)
            {
                if (turn == 1)
                {
                    Console.Title = "Det är " + ListsAndArrays.playerArray[playerChallenger].Name + "s tur!";
                    PlayerTurn(turn);
                    turn = 2;
                }
                else if (turn == 2)
                {
                    Console.Title = "Det är " + ListsAndArrays.playerArray[playerChallenged].Name + "s tur!";
                    PlayerTurn(turn);
                    turn = 1;
                }
                memoryEvent.CheckMemory(1);
            }
        }

        int CheckNode()
        {
            bool loopOne = true;
            int saveIndex = 0;
            while (loopOne)
            {
                Console.Clear();
                DisplayGameBoard();
                Console.Write("\nX = ");
                int x;
                bool successOne = int.TryParse(Console.ReadLine(), out x);
                Console.Write("Y = ");
                int y;
                bool successTwo = int.TryParse(Console.ReadLine(), out y);
                x -= 1;
                y -= 1;

                char first = '%';
                int index = 0;

                foreach (var node in ListsAndArrays.Grid)
                {
                    if (node.XAxis == x && node.YAxis == y)
                    {
                        if (node.Paired == true)
                        {
                            Console.WriteLine("Kortet är redan vänt. Försök igen...");
                            Console.ReadKey();
                        }
                        else
                        {
                            node.Paired = true;
                            node.NotTurned = node.Charachter;
                            first = node.Charachter;
                            saveIndex = index;
                            loopOne = false;
                        }
                    }
                    index++;
                }
            }
            return saveIndex;
        }

        void PlayerTurn(int player)
        {
            int firstNode = 0;
            int secondNode = 0;

            firstNode = CheckNode();
            secondNode = CheckNode();


            if (ListsAndArrays.Grid[firstNode].Charachter == ListsAndArrays.Grid[secondNode].Charachter)
            {
                if (player == 1)
                { playerChallengerPoints += 1; }
                else if (player == 2)
                { playerChallengedPoints += 1; }
                ListsAndArrays.Grid[firstNode].Paired = true;
                ListsAndArrays.Grid[secondNode].Paired = true;

                Console.Clear();
                DisplayGameBoard();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nTryck på någon knapp för att fortsätta");
                Console.ResetColor();
                Console.ReadKey();
            }

            else
            {
                Console.Clear();
                DisplayGameBoard();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nTryck på någon knapp för att fortsätta");
                Console.ResetColor();
                Console.ReadKey();

                ListsAndArrays.Grid[firstNode].NotTurned = '?';
                ListsAndArrays.Grid[secondNode].NotTurned = '?';
                ListsAndArrays.Grid[firstNode].Paired = false;
                ListsAndArrays.Grid[secondNode].Paired = false;
            }
        }

        void EndOfMemory()
        {
            Console.Clear();
            if (playerChallengerPoints > playerChallengedPoints)
            {
                int difference = playerChallengerPoints - playerChallengedPoints;
                Console.WriteLine("{0} vann! {1} straffas därför med ett avdrag på {2} poäng..."
                    , ListsAndArrays.playerArray[playerChallenger].Name, ListsAndArrays.playerArray[playerChallenged].Name,
                      difference);
                ListsAndArrays.playerArray[playerChallenged].SmartScale -= difference;
                Console.ReadKey();
            }

            else if (playerChallengedPoints > playerChallengerPoints)
            {
                int difference = playerChallengedPoints - playerChallengerPoints;
                Console.WriteLine("{0} vann och belönas med {1} poäng!"
                    , ListsAndArrays.playerArray[playerChallenged].Name, difference);
                ListsAndArrays.playerArray[playerChallenged].SmartScale += difference;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Det blev oavgjort!");
                Console.ReadLine();
            }

            ListsAndArrays.playerArray[playerChallenger].MemoryPlayed = true;

            if (GameClient.playerTurn == ListsAndArrays.playerArray.Length - 1)
                GameClient.playerTurn = 0;
            else
                GameClient.playerTurn++;
        }
    }
}
