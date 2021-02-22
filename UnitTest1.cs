using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Prometheus
{
    class Prometheus_login
    {
        String test_url = "https://prometheus-dap-webspa-cd.azurewebsites.net/";
        string username_clinician = "clinician@smedix.com";
        string password = "Pass@word1";
        string v = "instead of LOG IN";
        IWebDriver driver;

        [SetUp]
        public void start_Browser()
        {
            // Local Selenium WebDriver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            driver = new ChromeDriver(chromeOptions);
            //driver.Manage().Window.Maximize();
        }

        [Test]
        //fore more information visit https://www.guru99.com/selenium-csharp-tutorial.html
        public void Login()
        {

            driver.Url = test_url;

            System.Threading.Thread.Sleep(2000);

            IWebElement email = driver.FindElement(By.Id("Email"));

            email.SendKeys(username_clinician);

            IWebElement pwd = driver.FindElement(By.Id("Password"));

            pwd.SendKeys(password);

            IWebElement login = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/section/form/div[5]/button"));
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/section/form/div[5]/button"));
            
            String text = element.Text;

            Console.WriteLine(text);

            if (text.Contains("LOG IN"))



                { 
                    Console.WriteLine("name is ' LOG IN!'"); 
                }
            

            else
            {
                
                Console.WriteLine($"Name is not OK!, it should be: {text}");


            }

            login.Click();

            System.Threading.Thread.Sleep(6000);
            Assert.That(text, Does.Contain("LOG IN"));
            //https://www.lambdatest.com/blog/asserts-in-nunit/
            Console.WriteLine("Test Passed");
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}