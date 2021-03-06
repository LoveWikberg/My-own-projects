﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveWithArrowKeys
{
    class Program
    {
        const ConsoleColor HERO_COLOR = ConsoleColor.DarkBlue;
        const ConsoleColor BACKGROUND_COLOR = ConsoleColor.Green;

        public static Coordinate Hero { get; set; } //Will represent our here that's moving around :P/>

        static void Main(string[] args)
        {
            InitGame();
            Pitch();
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveHero(0, -1);
                        break;

                    case ConsoleKey.RightArrow:
                        MoveHero(1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveHero(0, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveHero(-1, 0);
                        break;
                }
            }
        }

        static void Pitch()
        {
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("|                             |                             |");
            Console.WriteLine("|______                       |                       ______|");
            Console.WriteLine("|      |                      |                      |      |");
            Console.WriteLine("|_     |                      |                      |     _|");
            Console.WriteLine("| |    |                      |                      |    | |");
            Console.WriteLine("|_|    |                      |                      |    |_|");
            Console.WriteLine("|      |                      |                      |      |");
            Console.WriteLine("|______|                      |                      |______|");
            Console.WriteLine("|                             |                             |");
            Console.WriteLine("|_____________________________|_____________________________");
        }

        static void MoveHero(int x, int y)
        {
            Coordinate newHero = new Coordinate()
            {
                X = Hero.X + x,
                Y = Hero.Y + y
            };

            if (CanMove(newHero))
            {
                RemoveHero();
                Console.BackgroundColor = HERO_COLOR;
                Console.SetCursorPosition(newHero.X, newHero.Y);
                Console.Write(" ");
                Hero = newHero;
            }
        }

        static void RemoveHero()
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.Write(" ");
        }

        static bool CanMove(Coordinate c)

        {
            if (c.X < 0 || c.X >= Console.WindowWidth)
                return false;
            if (c.Y < 0 || c.Y >= Console.WindowHeight)

                return false;
            return true;
        }

        static void SetBackgroundColor()
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            Console.Clear(); //Important!
        }

        static void InitGame()
        {
            SetBackgroundColor();
            Hero = new Coordinate()
            {
                X = 0,
                Y = 0
            };
            MoveHero(0, 0);
        }
    }
}
