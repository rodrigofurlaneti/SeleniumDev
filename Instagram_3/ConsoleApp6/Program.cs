using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ConsoleApp6
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

            Thread.Sleep(30000);

            driver2.FindElement(By.XPath("/html/body/div[1]/section/main/section/div[3]/div[2]/div[1]/a")).Click();

            Time();

            for (int i = 0; i < 100; i++)
            {
                Time();

                Boolean isPresentFollow = ExistsElement("/html/body/div[1]/section/main/div/div[2]/div/div/div[" + i + "]/div[3]/button");

                if(isPresentFollow)
                {
                    driver2.FindElement(By.XPath("/html/body/div[1]/section/main/div/div[2]/div/div/div[" + i + "]/div[3]/button")).Click();
                }

                Time();
            }

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

        }
    }
}
