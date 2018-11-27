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

                    // Click on watch list under Portfolio
                    driver.FindElement(By.XPath("//*[@id=\"main\"]/section/section/div[2]/table/tbody/tr[1]/td[1]/a")).Click();


                    // Ready to scrape data to console
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("//html[1]/body[1]/div[2]/div[3]/section[1]/section[2]/div[2]/table[1]/tbody[1]")));
                    var table = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[3]/section[1]/section[2]/div[2]/table[1]/tbody[1]"));
                    var children = table.FindElements(By.XPath(".//*"));
                    Console.WriteLine(table);
                    Console.WriteLine(children[0].GetAttribute("data-key"));


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
