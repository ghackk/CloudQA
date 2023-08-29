using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestinUnit
{
    [TestFixture]
    internal class Program
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp() {
            driver = new ChromeDriver();
            Console.WriteLine("The Webpage opened here");
        }
        [Test]
        public void FirstName()
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2.5));
            IWebElement inputField = driver.FindElement(By.Id("fname"));
            inputField.Clear();
            inputField.SendKeys("Gyanesh");
            Assert.AreEqual("Gyanesh", inputField.GetAttribute("value"));
            Console.WriteLine("FirstName Matched");
        }
        [Test]
        public void LastName()
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            IWebElement inputField = driver.FindElement(By.Id("lname"));
            inputField.Clear();
            inputField.SendKeys("Kumar");
            Assert.AreEqual("Kumar", inputField.GetAttribute("value"));
            Console.WriteLine("LastName Matched");
        }
        [Test]
        public void StateCheck()
        {
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");    
            IWebElement dropDown = driver.FindElement(By.Id("state"));
            SelectElement select = new SelectElement(dropDown);
            select.SelectByValue("India");
            string selectedOption = select.SelectedOption.Text;
            Assert.AreEqual("India", selectedOption);
            Console.WriteLine("State Matched");
        }

        [TearDown]
        public void TearDown() {
            driver.Quit();
        }

    }
}
