using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumNUnitOHRM.Base;
using SeleniumNUnitOHRM.DataModel;
using SeleniumNUnitOHRM.PageObjects.LoginPage;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace SeleniumNUnitOHRM.TestCases
{
    [AllureNUnit]
    [TestFixture]
    public class LoginTest  : BaseClass
    {
        LoginPage loginPage;

        [Test]
        public void test_001_valid_login()
        {
            string readdatafromjson = File.ReadAllText(@"D:\Projects\Testing\SeleniumNUnit\SeleniumNUnitOHRM\TestData\users_data.json");
            var users_data = JsonSerializer.Deserialize<LoginDataModel>(readdatafromjson);

            loginPage = new LoginPage(driver);

            Assert.That(driver.Url, Is.EqualTo("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login"));
            Assert.That(driver.Title, Is.EqualTo("OrangeHRM"));

            bool loginLogo = loginPage.IsOhrmLoginPageLogoDisplayed();
            Assert.That(loginLogo, Is.True);

            loginPage.IsLoginPageUsernameInputDisplayed();
            loginPage.IsLoginPagePasswordInputDisplayed();

            loginPage.EnterUsername(users_data.adminUsername, "placeholder", "Username");
            loginPage.EnterPassword(users_data.adminPassword, "placeholder", "Password");
            loginPage.ClickLoginButton("Login");

            Assert.That(driver.Url, Is.EqualTo("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index"));
            Assert.That(driver.Title, Is.EqualTo("OrangeHRM"));

        }
    }
}
