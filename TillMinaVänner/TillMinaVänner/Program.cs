using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;

namespace TillMinaVänner
{
    class Program
    {
        static IWebDriver driver;
        static WebDriverWait wait;

        static void Main(string[] args)
        {
          

            driver = new ChromeDriver();
           

            driver.Navigate().GoToUrl("https://sv.wikipedia.org/wiki/Portal:Huvudsida");
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.Id("searchInput"))));
            driver.FindElement(By.Id("searchInput")).SendKeys("internettroll");
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.Id("searchInput"))));
            driver.FindElement(By.Id("searchButton")).Click();
            System.Threading.Thread.Sleep(2000);
            SendKeys.SendWait("{F10}");
            System.Threading.Thread.Sleep(2000);
            SendKeys.SendWait("{ENTER}");
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait("{DOWN}");
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait("{DOWN}");
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait("{DOWN}");
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait("{RIGHT}");
            System.Threading.Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            System.Threading.Thread.Sleep(3000);
            SendKeys.SendWait("{P}");
            SendKeys.SendWait("{O}");
            SendKeys.SendWait("{R}");
            SendKeys.SendWait("{N}");
            System.Threading.Thread.Sleep(2000);
            
            SendKeys.SendWait("{PRTSC}");
            System.Threading.Thread.Sleep(2000);

            Process firstProc = new Process();
            firstProc.StartInfo.FileName = "mspaint.exe";
            firstProc.EnableRaisingEvents = true;

            firstProc.Start();

            System.Threading.Thread.Sleep(5000);
            SendKeys.SendWait("^{v}");
            System.Threading.Thread.Sleep(3000);
            firstProc.Kill();
            driver.Quit();

            MessageBox.Show("HEHEHEHEHE");

        }
    }
}
