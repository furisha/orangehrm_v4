using OpenQA.Selenium;
using System;

namespace SeleniumNUnitOHRM.Extensions
{
    public static class Extensions
    {
        public static void Click(this IWebDriver driver, By locator)
        {
            IWebElement ele = driver.FindElement(locator);
            if (ele.Displayed && ele.Enabled)
            {
                ele.Click();
            }
        }

        public static void EnterText(this IWebDriver driver, By locator, String value)
        {
            IWebElement ele = driver.FindElement(locator);
            if (ele.Displayed && ele.Enabled)
            {
                ele.Click();
            }
        }

        public static bool IsElementDisplayed(this IWebDriver driver, By locator)
        {
            try
            {
                IWebElement ele = driver.FindElement(locator);
                return ele.Displayed;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
