using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        public static object SystemSettings { get; private set; }

        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--disable-notifications");

            IWebDriver driver = new ChromeDriver(@"C:\Users", options);

            Time();

            driver.Navigate().GoToUrl("https://tinder.com/app/recs");

            Time();

            driver.Manage().Window.Maximize();

            Time();

            var entrar = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div/div[1]/button"));

            entrar.Click();

            Time();

            var entrar2 = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/main/div[1]/div/div/div/div/header/div/div[2]/div[2]/a"));

            entrar2.Click();

            Time();

            var entrar3 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/span/div[2]/button"));

            entrar3.Click();

            Time();

            string originalWindow = driver.CurrentWindowHandle;

            Time();

            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);

                    Time();

                    driver.FindElement(By.Id("email")).SendKeys("usuario");

                    driver.FindElement(By.Id("pass")).SendKeys("senha");

                    Time();

                    var entrar4 = driver.FindElement(By.XPath("/html/body/div/div[2]/div[1]/form/div/div[3]/label[2]/input"));

                    entrar4.Click();

                    Time();

                    break;
                }
            }

            Time();

            foreach (var handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
            }

            Time();

            driver.SwitchTo().Window(driver.WindowHandles[0]);

            Time();

            Thread.Sleep(10000);


            for (int i = 0; i < 3000; i++)
            {
                Boolean isPresent1 = ExistsElement("/html/body/div[2]/div/div/button[2]");

                Boolean isPresent2 = ExistsElement("html/body/div[2]/div/div/div[2]/button[2]");

                Boolean isPresent3 = ExistsElement("/html/body/div[1]/div/div[1]/div/main/div[2]/div/div/div[1]/div/div[4]/button");

                Boolean isPresent4 = ExistsElement("/html/body/div[2]/div/div/div[2]/button");

                Time();

                if (isPresent1)
                {
                    var entrar6 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/button[2]"));

                    entrar6.Click();

                    Time();
                }
                if (isPresent2)
                {
                    var entrar7 = driver.FindElement(By.XPath("html/body/div[2]/div/div/div[2]/button[2]"));

                    entrar7.Click();

                    Time();
                }
                if (isPresent3)
                {
                    var entrar8 = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/main/div[2]/div/div/div[1]/div/div[4]/button"));

                    entrar8.Click();

                    Time();
                }
                if (isPresent4)
                {
                    var entrar9 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/button"));

                    entrar9.Click();

                    Time();
                }
                else
                {
                    var entrar5 = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/main/div[1]/div/div/div[1]/div/div[2]/div[4]/button"));

                    entrar5.Click();

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
                    driver.FindElement(By.XPath(xpath));
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