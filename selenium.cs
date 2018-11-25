using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
                    driver.FindElement(By.XPath(".//a[@id = 'uh-signedin']")).Click();


                    Console.WriteLine("Email:");
                    var userName = Console.ReadLine();

                    driver.FindElement(By.XPath(".//input[@name = 'username']")).SendKeys(userName);

                    driver.FindElement(By.XPath(".//input[@id= 'login-signin']")).Click();

                    Console.WriteLine("Password:");
                    var passWord = Console.ReadLine();

                    driver.FindElement(By.XPath(".//input[@id = 'login-passwd']")).SendKeys(passWord);
                    driver.FindElement(By.XPath(".//button[@id = 'login-signin']")).Click();

                    // Navigate to My portfolio page
                    driver.FindElement(By.XPath(".//a[@title = 'My Portfolio']")).Click();

                    // Wit for pop up, then click 'x' to exit pop up
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//dialog[@id = '__dialog']/section/button")));
                    driver.FindElement(By.XPath("//dialog[@id = '__dialog']/section/button")).Click();

                    // Ready to scrape data to console


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
