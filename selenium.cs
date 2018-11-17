using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Yahoo_Scrape
{
    class Program
    {
        static void Main(string[] args)
        {

            var driver = new ChromeDriver(Environment.CurrentDirectory);
            {
                //Console.WriteLine("TEST!");
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(3);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                driver.Navigate().GoToUrl("https://finance.yahoo.com/");
                wait.Until(ExpectedConditions.ElementExists(By.Id("uh-signedin")));

                try
                {
                    //driver.FindElement(By.XPath("//*[@id = 'uh-signin']/a")).Click();
                    driver.FindElement(By.XPath(".//a[@id = 'uh-signedin']")).Click();


                    Console.WriteLine("Email:");
                    var userName = Console.ReadLine();

                    driver.FindElement(By.XPath(".//input[@name = 'username']")).SendKeys(userName);

                    driver.FindElement(By.XPath(".//input[@id= 'login-signin']")).Click();

                    Console.WriteLine("Password:");
                    var passWord = Console.ReadLine();

                    driver.FindElement(By.XPath(".//input[@id = 'login-passwd']")).SendKeys(passWord);
                    driver.FindElement(By.XPath(".//button[@id = 'login-signin']")).Click();

                    driver.FindElement(By.XPath(".//a[@title = 'My Portfolio']")).Click();

                    driver.FindElement(By.XPath(".//a[@href='/portfolio/p_1']")).Click();

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.Read();

            }
        }
    }
}
