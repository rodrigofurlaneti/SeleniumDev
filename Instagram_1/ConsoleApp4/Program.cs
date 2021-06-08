using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--disable-notifications");

            IWebDriver driver2 = new ChromeDriver(@"C:\Users", options);

            Time();
            
            driver2.Navigate().GoToUrl("https://www.instagram.com/");

            Time();

            driver2.Manage().Window.Maximize();

            Time();

            var entrar = driver2.FindElement(By.XPath("/html/body/div[1]/section/main/article/div[2]/div[1]/div/form/div/div[5]/button"));

            entrar.Click();

            Time();

            driver2.FindElement(By.Id("email")).SendKeys("usuario");

            driver2.FindElement(By.Id("pass")).SendKeys("senha");

            Time();

            driver2.FindElement(By.Id("loginbutton")).Click();

            Thread.Sleep(20000);

            driver2.FindElement(By.XPath("/html/body/div[1]/section/main/section/div[3]/div[1]/div/div/div[1]/div/span/img")).Click();

            Time();

            driver2.FindElement(By.XPath("/html/body/div[1]/section/div[1]/div/section/div/div[3]/div[2]/button/div/div/div/div[2]/span/img")).Click();

            Time();

            var AmountOfStories = driver2.FindElement(By.XPath("/html/body/div[1]/section/div[1]/div/section/div/div[3]/div[2]/button/div/span/span")).Text.Trim().ToString();

            Time();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver2;

            string title = (string)js.ExecuteScript("window.scrollBy(100, 0);");

            Time2();

            var EveryoneWhoVisualized = driver2.FindElement(By.XPath("/html/body/div[5]/div/div/div/div[2]/div/div")).Text.Trim().ToString();

            Time2();

            var txt = EveryoneWhoVisualized.Split("\r\n");

            Time2();

            void Time()
            {
                Thread.Sleep(4000);
            }

            void Time2()
            {
                Thread.Sleep(8000);
            }

            Boolean ExistsElement(String xpath)
            {
                try
                {
                    driver2.FindElement(By.XPath(xpath));
                }
                catch (NoSuchElementException e)
                {
                    return false;
                }
                return true;
            }
            //

        }
    }
}
