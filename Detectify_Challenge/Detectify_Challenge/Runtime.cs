using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Diagnostics;

namespace Detectify_Challenge
{
    class Runtime
    {
        URLOptions ui = new URLOptions();

        public void Start()
        {
            #region Read from file
            try
            {
                var directoryFile = Directory.GetCurrentDirectory() + "\\URL.json";
                if (SaveAndLoad.ReadFromJsonFile(directoryFile) != null)
                    Lists.URLList = SaveAndLoad.ReadFromJsonFile(directoryFile).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred, restarting application...");
                System.Threading.Thread.Sleep(2000);
                Process.Start(Application.ExecutablePath);
                Environment.Exit(-1);
                Application.Exit();
            }
            #endregion

            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("This program lets you add an unlimited number of URLs to a list. When you have added your");
                Console.WriteLine("URLs you have the option to get screenshots from every website.");
                Console.WriteLine("The screenshots will be saved and you can go back and inspect them whenever you wish to!");
                Console.WriteLine("You need to have Firefox installed on your computer to use this program.");
                Console.WriteLine("\nUse the number keys to navigate through the program.\n");
                Console.WriteLine("[1] URL options");
                Console.WriteLine("[2] Exit");
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ui.Menu();
                        break;

                    case ConsoleKey.D2:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
