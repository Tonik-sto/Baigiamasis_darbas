using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis_darbas.Pages
{
    public class LogInPage : BasePage
    {
        private const string PageAddress = "https://www.rimi.lt/e-parduotuve";
        private const string ResultText = "Sveiki, ";
        private IWebElement _CokkiesInMain => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement _CookiesInForm => Driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept"));
        private IWebElement _LoginButton => Driver.FindElement(By.CssSelector("body > header > div.container.header__top > div.header__profile > a"));
        private IWebElement _EmailField => Driver.FindElement(By.Id("inputPhoneOrEmail"));
        private IWebElement _PasswordField => Driver.FindElement(By.Id("inputPassword"));
        private IWebElement _Login => Driver.FindElement(By.Id("loginButton"));
        private IWebElement _Result => Driver.FindElement(By.Id("user-logged-in"));

        public LogInPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public LogInPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
       
        public LogInPage ClickAcceptAllCookies()
        {
            _CokkiesInMain.Click();
            return this;
        }

        
        public LogInPage ClickLoginButton()
        {
            _LoginButton.Click();
            return this;
        }
        
        public LogInPage InsertEmail(string email)
        {
            _EmailField.Clear();
            _EmailField.SendKeys(email);
            return this;
        }
        public LogInPage InsertPassword(string password)
        {
            _PasswordField.Clear();
            _PasswordField.SendKeys(password);
            return this;
        }
        
        public LogInPage Cookies()
        {
            _CookiesInForm.Click();
            return this;
        }
        
        public LogInPage ClickLogin()
        {
            _Login.Click();
            return this;
        }

        public LogInPage CheckResult(string name)
        {
            Assert.IsTrue(_Result.Text.Equals(ResultText + name), $"Result is wrong, not {name}");
            return this;
        }
    }
}
