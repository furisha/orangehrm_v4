using Allure.Net.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumNUnitOHRM.DataModel;
using System;
using System.IO;
using System.Text.Json;

namespace SeleniumNUnitOHRM.Base
{
    public class BaseClass
    {
        public IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            string readdatafromjson = File.ReadAllText(@"D:\Projects\Testing\SeleniumNUnit\SeleniumNUnitOHRM\TestData\environment_data.json");
            var data = JsonSerializer.Deserialize<EnvironmetDataModel>(readdatafromjson);

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(data.testUrl);
        }

        [TearDown]
        [Obsolete]
        public void AfterTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                byte[] content = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment("Failed Screenshot ", "image/png", content);
                driver.Close();
            }
            else
            {
                driver.Close();
            }

        }
    }
}
