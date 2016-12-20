using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Detectify_Challenge
{
    class URLHandler
    {
        IWebDriver driver;

        public void TakeScreenshot()
        {
            var directory = Directory.GetCurrentDirectory();

            foreach (var url in Lists.URLList)
            {
                driver = new FirefoxDriver();

                try
                {
                    driver.Navigate().GoToUrl(url.URLLink);
                    Screenshot scrs = ((ITakesScreenshot)driver).GetScreenshot();
                    driver.Quit();
                    scrs.SaveAsFile(directory + "\\SavedScreenshots\\" + url.URLFileName + ".jpeg", ImageFormat.Jpeg);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        public void AddURL()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.Write("Enter URL (ie https://www.website.com): ");
                var url = Console.ReadLine();

                Console.Clear();
                Console.Write("Enter the name you want the screenshot file to have (only letters a-z): ");
                string urlName = Console.ReadLine();

                #region Error handling
                if (url.Contains(" "))
                {
                    Console.WriteLine("There can't be any spaces in the URL, press any key to try again...");
                    Console.ReadKey();
                }
                else if (!url.StartsWith("https://www."))
                {
                    Console.WriteLine("Don't forget the \"https://www.\" in the URL! Press any key to try again...");
                    Console.ReadKey();
                }
                else if (!Regex.IsMatch(urlName, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("File name can only contain letters a-z, press any key to try again...");
                    Console.ReadKey();
                }
                #endregion

                else
                {
                    Lists.URLList.Add(new URL { URLLink = url, URLFileName = urlName });
                    var directoryFile = Directory.GetCurrentDirectory() + "\\URL.json";
                    SaveAndLoad.WriteToJsonFile(directoryFile, Lists.URLList);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("URL succesfully added to list, press any key to continue...");
                    Console.ResetColor();
                    Console.ReadKey();
                    loop = false;
                }
            }
        }

        public void OpenScreenshotFolder()
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = "SavedScreenshots";
                process.EnableRaisingEvents = true;
                process.Start();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
