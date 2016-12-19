using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detectify_Challenge
{
    class URLOptions
    {
        URLHandler urlHandler = new URLHandler();

        public void Menu()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("[1] Add URL");
                Console.WriteLine("[2] Take a screenshot of every website");
                Console.WriteLine("[3] Open the screenshot folder");
                Console.WriteLine("[4] Back");
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        urlHandler.AddURL();
                        break;

                    case ConsoleKey.D2:
                        urlHandler.TakeScreenshot();
                        break;

                    case ConsoleKey.D3:
                        urlHandler.OpenScreenshotFolder();
                        break;

                    case ConsoleKey.D4:
                        loop = false;
                        break;
                }
            }
        }
    }
}

