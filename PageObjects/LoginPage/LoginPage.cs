using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumNUnitOHRM.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumNUnitOHRM.PageObjects.LoginPage
{
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static readonly By ohrmLoginPageLogo = By.XPath("//img[@alt='company-branding']");

        public static readonly By usernameInput = By.Name("username");
        public static readonly By passwordInput = By.Name("password");

        public static readonly By loginButton = By.ClassName("orangehrm-login-button");

        public static readonly By validation_message = By.XPath("//p[@class='oxd-text oxd-text--p oxd-alert-content-text']");

        public static readonly By dropdownMenu = By.ClassName("oxd-userdropdown");
        public static readonly By logoutButton = By.XPath("//a[normalize-space()='Logout']");

        public static readonly By result = By.XPath("//p[@class='oxd-text oxd-text--p oxd-alert-content-text']");

        public bool IsOhrmLoginPageLogoDisplayed()
        {
            return driver.IsElementDisplayed(ohrmLoginPageLogo);
        }

        public bool IsLoginPageUsernameInputDisplayed()
        {
            return driver.IsElementDisplayed(usernameInput);
        }

        public bool IsLoginPagePasswordInputDisplayed()
        {
            return driver.IsElementDisplayed(passwordInput);
        }

        public void EnterUsername(String value, String attribute, String text)
        {
            IWebElement UsernameInputElement = driver.FindElement(usernameInput);

            if (UsernameInputElement.Displayed && UsernameInputElement.Enabled)
            {
                String UsernameInputText = UsernameInputElement.GetAttribute(attribute);
                Assert.That(UsernameInputText, Is.EqualTo(text));
                UsernameInputElement.SendKeys(value);
            }
        }

        public void EnterPassword(String value, String attribute, String text)
        {
            IWebElement PasswordInputElement = driver.FindElement(passwordInput);

            if (PasswordInputElement.Displayed && PasswordInputElement.Enabled)
            {
                String PasswordInputText = PasswordInputElement.GetAttribute(attribute);
                Assert.That(PasswordInputText, Is.EqualTo(text));
                PasswordInputElement.SendKeys(value);
            }
        }

        public void ClickLoginButton(String text)
        {
            IWebElement loginButtonElement = driver.FindElement(loginButton);

            if (loginButtonElement.Displayed && loginButtonElement.Enabled)
            {
                String loginButtonText = loginButtonElement.Text;
                Assert.That(loginButtonText, Is.EqualTo(text));
                loginButtonElement.Click();
            }
        }

        public void ClickDropDownMenu()
        {
            driver.FindElement(dropdownMenu).Click();
        }
        public void ClickLogoutButton()
        {
            driver.FindElement(logoutButton).Click();
        }
    }
}
