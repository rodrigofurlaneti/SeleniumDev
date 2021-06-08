using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--disable-notifications");

            IWebDriver driver1 = new ChromeDriver(@"C:\Users", options);

            Time();

            driver1.Navigate().GoToUrl("https://theinnercircle.co/");

            Time();

            driver1.Manage().Window.Maximize();

            Time();

            var entrar = driver1.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[3]/a[1]"));

            entrar.Click();

            Time();

            driver1.FindElement(By.Id("email")).SendKeys("usuario");

            driver1.FindElement(By.Id("pass")).SendKeys("senha");

            Time();

            driver1.FindElement(By.Id("loginbutton")).Click();

            for (int i = 0; i < 9000; i++)
            {
                Boolean isPresent = ExistsElement("/html/body/div[5]/div/a[2]");

                Boolean isPresent1 = ExistsElement("/html/body/div[1]/div[8]/div[3]/div[1]/div/div[1]/a[3]");

                if (isPresent)
                {
                    var entrar3 = driver1.FindElement(By.XPath("/html/body/div[5]/div/a[2]"));

                    entrar3.Click();

                    Time();
                }
                if (isPresent1)
                {
                    var entrar2 = driver1.FindElement(By.XPath("/html/body/div[1]/div[8]/div[3]/div[1]/div/div[1]/a[3]"));

                    entrar2.Click();

                    Time();
                }
                else
                {
                    driver1.Navigate().Refresh();

                    Time();


                }
            }

            void Time()
            {
                Thread.Sleep(2000);
            }

            Boolean ExistsElement(String xpath)
            {
                try
                {
                    driver1.FindElement(By.XPath(xpath));
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
