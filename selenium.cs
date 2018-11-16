using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
                driver.Navigate().GoToUrl("https://yahoo.com/");

                try
                {
                    //driver.FindElement(By.XPath("//*[@id = 'uh-signin']/a")).Click();
                    driver.FindElement(By.XPath(".//a[@id = 'uh-signin']")).Click();


                    Console.WriteLine("Email:");
                    var userName = Console.ReadLine();

                    driver.FindElement(By.XPath(".//input[@name = 'username']")).SendKeys(userName);

                    driver.FindElement(By.XPath(".//input[@id= 'login-signin']")).Click();

                    Console.WriteLine("Password:");
                    var passWord = Console.ReadLine();

                    driver.FindElement(By.XPath(".//input[@id = 'login-passwd']")).SendKeys(passWord);
                    driver.FindElement(By.XPath(".//button[@id = 'login-signin']")).Click();

                    driver.FindElement(By.XPath("./a[@href="https://finance.yahoo.com/"]")).Click();
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
