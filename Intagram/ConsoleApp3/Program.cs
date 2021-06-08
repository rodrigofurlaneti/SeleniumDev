using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace ConsoleApp3
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

            driver.FindElement(By.XPath("/html/body/div[1]/section/nav/div[2]/div/div/div[2]/input")).SendKeys("#nature" + Keys.ArrowDown + Keys.Enter) ;

            Time();

            driver.FindElement(By.XPath("/html/body/div[1]/section/nav/div[2]/div/div/div[2]/div[3]/div/div[2]/div/div[1]/a/div")).Click();

            Time();

            driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div[1]/div/div/div[1]/div[1]/a/div/div[2]")).Click();

            Time();

            var like = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button/div/span")).GetAttribute("innerHTML");

            var arrayLike = like.Split(" ");

            if (arrayLike[4] != "fill=\"#ed4956\"")
            {
                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button")).Click();
            }

            Time();

            Boolean isPresentComment = ExistsElement("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea");

            if (isPresentComment)
            {
                Time();

                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea")).Clear();

                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea")).Click();

                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea")).SendKeys("Boa foto!");

                Time();

                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/button[2]")).Click();
            }

            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/header/div[2]/div[1]/div/span/a")).Click();

            Time();

            Boolean isPresentFollow = ExistsElement("/html/body/div[1]/section/main/div/header/section/div[1]/div[1]/div/div/div/span/span[1]/button");

            if (isPresentFollow)
            {
                driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/header/section/div[1]/div[1]/div/div/div/span/span[1]/button")).Click();
            }

            Time();

            driver.Navigate().Back();

            Time();

            driver.Navigate().Back();

            Time();

            int line = 1;

            int column = 1;

            for (int i = 1; i < 1000; i++)
            {
                Boolean isPresentTop = ExistsElement("/html/body/div[1]/section/main/article/div[1]/div/div/div[" + line + "]/div[" + column + "]/a/div");

                if(isPresentTop)
                {
                    driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div[1]/div/div/div[" + line + "]/div[" + column + "]/a/div")).Click();

                    ProcessLike();
                }
                else
                {
                    Boolean isPresentMost = ExistsElement("/html/body/div[1]/section/main/article/div[2]/div/div[" + line + "]/div[" + column + "]/a/div");
                                                          
                    if (isPresentMost)
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div[2]/div/div[" + line + "]/div[" + column + "]/a/div")).Click();

                        ProcessLike();
                    }

                }

                

            }

            void Process()
            {
                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button")).Click();

                Time();

                driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/a[2]")).Click();

                Time();

                Boolean isPresent = ExistsElement("/html/body/div[6]/div/div/div/div[3]/button[2]");

                if (isPresent)
                {
                    driver.FindElement(By.XPath("/html/body/div[6]/div/div/div/div[3]/button[2]")).Click();
                }

                Time();

            }

            void Time()
            {
                Thread.Sleep(8000);
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

            void ProcessLike()
            {
                Boolean isPresentComment2 = ExistsElement("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea");

                if(isPresentComment2)
                {
                    Time();

                    driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea")).Clear();

                    driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea")).Click();

                    driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/textarea")).SendKeys("Boa foto!");

                    Time();

                    driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[3]/div/form/button[2]")).Click();
                }

                Time();

                Boolean isPresentLikee = ExistsElement("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button/div/span");

                if(isPresentLikee)
                {
                    var likee = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button/div/span")).GetAttribute("innerHTML");

                    var arrayLikee = likee.Split(" ");

                    if (arrayLikee[4] != "fill=\"#ed4956\"")
                    {
                        driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/div[3]/section[1]/span[1]/button")).Click();
                    }

                    driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/article/header/div[2]/div[1]/div/span/a")).Click();

                    Time();
                }

                Boolean isPresentFolloww = ExistsElement("/html/body/div[1]/section/main/div/header/section/div[1]/div[1]/div/div/div/span/span[1]/button");

                if (isPresentFolloww)
                {
                    driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/header/section/div[1]/div[1]/div/div/div/span/span[1]/button")).Click();
                }

                Time();

                driver.Navigate().Back();

                Time();

                driver.Navigate().Back();

                Time();

                column++;

                if (column == 4)
                {
                    column = 1;
                    line++;
                };

                driver.FindElement(By.XPath("/html/body/div[1]/section/main/header/div[2]/div/button")).SendKeys(Keys.ArrowDown);
            }
        }
    }
}
