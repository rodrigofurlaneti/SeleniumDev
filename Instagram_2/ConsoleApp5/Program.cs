using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--disable-notifications");

            IWebDriver driver = new ChromeDriver(@"C:\Users", options);

            Time();

            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Time();

            driver.Manage().Window.Maximize();

            Time();

            var entrar = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div[2]/div[1]/div/form/div/div[5]/button"));

            entrar.Click();

            Time();

            driver.FindElement(By.Id("email")).SendKeys("usuario");

            driver.FindElement(By.Id("pass")).SendKeys("senha");

            Time();

            driver.FindElement(By.Id("loginbutton")).Click();

            Thread.Sleep(20000);

            driver.FindElement(By.XPath("/html/body/div[1]/section/main/section/div[3]/div[2]/div[1]/a")).Click();

            Time();

            for (int x = 1; x < 2; x++)
            {
                for (int i = 1; i < 43; i++)
                {
                    Boolean isPresent = ExistsElement("/html/body/div[1]/section/main/div/div[2]/div/div/div[" + i + "]/div[3]/button");

                    if (isPresent)
                    {
                        Boolean isPresentOk = ExistsElement("/html/body/div[5]/div/div/div/div[2]/button[2]");
                        
                        if(isPresentOk)
                        {
                            driver.FindElement(By.XPath("/html/body/div[5]/div/div/div/div[2]/button[2]")).Click();
                        }

                        driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/div[2]/div/div/div[" + i + "]/div[3]/button")).Click();

                        Time();

                        for (int j = 0; j < 1; j++)
                        {
                            driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/div[2]/div/div/div[" + i + "]/div[3]/button")).SendKeys(Keys.ArrowDown);
                        }
                    }
                }

                Time();
                
                driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/div[2]/div/div/div[" + x + "]/div[3]/button")).SendKeys(Keys.F5);

                Time();
            }


            #region Methods

            void Time()
            {
                Thread.Sleep(6000);
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

            #endregion
        }
    }
}
