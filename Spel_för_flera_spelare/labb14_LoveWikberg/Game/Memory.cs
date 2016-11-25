using labb14_LoveWikberg.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace labb14_LoveWikberg
{
    class Memory
    {
        int playerChallenged = 0;
        int playerChallengedPoints = 0;
        public static int playerChallenger = 0;
        int playerChallengerPoints = 0;

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
                    ListsAndArrays.Grid[i].YAxis = 1;
                    ListsAndArrays.Grid[i].XAxis = i;
                }
                else if (i > 5 && i < 12)
                {
                    ListsAndArrays.Grid[i].YAxis = 2;
                    ListsAndArrays.Grid[i].XAxis = yOne;
                    yOne++;
                }
                else if (i > 11 && i < 18)
                {
                    ListsAndArrays.Grid[i].YAxis = 3;
                    ListsAndArrays.Grid[i].XAxis = yTwo;
                    yTwo++;
                }
                else if (i > 17 && i < 24)
                {
                    ListsAndArrays.Grid[i].YAxis = 4;
                    ListsAndArrays.Grid[i].XAxis = yThree;
                    yThree++;
                }
                else if (i > 23 && i < 30)
                {
                    ListsAndArrays.Grid[i].YAxis = 5;
                    ListsAndArrays.Grid[i].XAxis = yFour;
                    yFour++;
                }
                else if (i > 29 && i < 36)
                {
                    ListsAndArrays.Grid[i].YAxis = 6;
                    ListsAndArrays.Grid[i].XAxis = yFive;
                    yFive++;
                }

            }

        }


        public void PickOponent()
        {
            Console.Clear();
            int i = 0;
            foreach (var player in ListsAndArrays.playerArray)
            {
                i++;
                Console.WriteLine(i + ". " + player.Name);
            }
            Console.Write("Mata in talet för spelaren som du vill utmana: ");
            int choice;
            bool success = int.TryParse(Console.ReadLine(), out choice);
            playerChallenged = ListsAndArrays.playerArray[choice - 1].Id;

            Console.WriteLine(ListsAndArrays.playerArray[choice - 1].Name + " var redo!!!");
            Console.ReadKey();

        }

        public void DisplayGameBoard()
        {
            for (int i = 35; i > -1; i--)
            {
                if (i == 35)
                    Console.Write("Y 6");

                Console.Write("|" + ListsAndArrays.Grid[i].NotTurned);


                if (i == 29)
                {
                    Console.Write("|");
                    Console.Write("\n  5");
                }
                if (i == 23)
                {
                    Console.Write("|");
                    Console.Write("\n  4");
                }

                if (i == 17)
                {
                    Console.Write("|");
                    Console.Write("\n  3");
                }

                if (i == 11)
                {
                    Console.Write("|");
                    Console.Write("\n  2");
                }

                if (i == 5)
                {
                    Console.Write("|");
                    Console.Write("\n  1");
                }

                if (i == 0)
                {
                    Console.Write("|");
                    Console.WriteLine("\n    1 2 3 4 5 6 X");
                }
            }
        }

        public void PlayerTurn()
        {
            bool loop = true;
            int turn = 1;
            while (loop)
            {
                if (turn == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Det är {0}s tur", ListsAndArrays.playerArray[playerChallenger].Name);
                    Console.ResetColor();
                    Console.ReadKey();
                    TurnCard(turn);
                    turn = 2;
                }
                else if (turn == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Det är {0}s tur", ListsAndArrays.playerArray[playerChallenged].Name);
                    Console.ResetColor();
                    Console.ReadKey();
                    TurnCard(turn);
                    turn = 1;
                }
            }
        }

        public void TurnCard(int playerPointGiven)
        {
            Console.Clear();
            DisplayGameBoard();
            Console.Write("X = ");
            int x;
            bool successOne = int.TryParse(Console.ReadLine(), out x);
            Console.Write("Y = ");
            int y;
            bool successTwo = int.TryParse(Console.ReadLine(), out y);
            x -= 1;
            y -= 1;
            char first = '%';
            int firstPlace = 0;
            int firstPlaceSave = 0;
            foreach (var node in ListsAndArrays.Grid)
            {
                if (node.XAxis == x && node.YAxis == y)
                {
                    node.NotTurned = node.Charachter;
                    first = node.Charachter;
                    firstPlaceSave = firstPlace;
                }
                firstPlace++;
            }

            Console.Clear();
            DisplayGameBoard();
            Console.Write("X = ");
            int xTwo;
            bool successThree = int.TryParse(Console.ReadLine(), out xTwo);
            Console.Write("Y = ");
            int yTwo;
            bool successFour = int.TryParse(Console.ReadLine(), out yTwo);
            char second = '%';
            int secondPlace = 0;
            int secondPlaceSave = 0;
            foreach (var node in ListsAndArrays.Grid)
            {
                if (node.XAxis == x && node.YAxis == y)
                {
                    node.NotTurned = node.Charachter;
                    second = node.Charachter;
                    secondPlaceSave = secondPlace;
                }
                secondPlace++;
            }

            if (second == first)
            {
                if (playerPointGiven == 1)
                { playerChallengerPoints += 1; }
                else if (playerPointGiven == 2)
                { playerChallengedPoints += 1; }
                ListsAndArrays.Grid[firstPlaceSave].Paired = true;
                ListsAndArrays.Grid[secondPlaceSave].Paired = true;
            }

            else if (second != first)
            {
                ListsAndArrays.Grid[firstPlaceSave].NotTurned = '?';
                ListsAndArrays.Grid[secondPlaceSave].NotTurned = '?';
            }

        }
    }
}
