using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Excercise2
{

    public class UnitTest1
    {

        private IWebDriver chromeDriver;

        private string filepath = (@"C:\ChromeDriver");

        [Test]
        public void VerifyHomePage()
        {

            chromeDriver = new ChromeDriver(filepath);
            string wwTile = "WW (Weight Watchers): Weight Loss & Wellness Help";
            chromeDriver.Navigate().GoToUrl("https://www.weightwatchers.com/us/");
            string testtitle = chromeDriver.Title;
            NUnit.Framework.Assert.AreEqual(wwTile, testtitle);
        }



        [Test]
        public void VerifyFindStudio()
        {
            chromeDriver = new ChromeDriver(filepath);
            string wwstudiopageTile = "Find WW Studios & Meetings Near You | WW USA";
            chromeDriver.Navigate().GoToUrl("https://www.weightwatchers.com/us/");
            chromeDriver.FindElement(By.ClassName("find-a-meeting")).Click();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string testtitle = chromeDriver.Title;
            NUnit.Framework.Assert.AreEqual(testtitle, wwstudiopageTile);
        }
        [Test]
        public void StudioSearch10011()
        {
            chromeDriver = new ChromeDriver(filepath);
            chromeDriver.Navigate().GoToUrl("https://www.weightwatchers.com/us/");
            chromeDriver.FindElement(By.ClassName("find-a-meeting")).Click();
            chromeDriver.FindElement(By.Id("meetingSearch")).SendKeys("10011");
            chromeDriver.FindElement(By.ClassName("btn spice-translated")).Click();
            string firstresulTitle = chromeDriver.FindElement(By.XPath(@"//*[@id=""ml - 1180510""]/result-location/div/div[1]/a/location-address/div/div/div[1]/div[1]/span")).Text;
            string firstresultDistance = chromeDriver.FindElement(By.XPath(@"//*[@id=""ml-1180510""]/result-location/div/div[1]/a/location-address/div/div/div[1]/div[2]")).Text;
            Console.WriteLine("This is the 1st Resutlt: {firstresultTitle} {firstresultdistance}");
        }

    }
}