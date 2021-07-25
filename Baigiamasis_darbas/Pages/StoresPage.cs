using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Baigiamasis_darbas.Pages
{
    public class StoresPage : BasePage
    {
        private const string PageAddress = "https://www.rimi.lt/parduotuves";

        private IWebElement _Filter => Driver.FindElement(By.XPath("/html/body/main/section/div/div[1]/form/div[3]/div[1]/div"));
        private IWebElement _ChooseCheckbox => Driver.FindElement(By.XPath("/html/body/main/section/div/div[1]/form/div[3]/div[2]/label[2]"));


        public StoresPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public StoresPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public StoresPage AcceptAllCookies()
        {
            Cookie myCookie = new Cookie("CookieConsent",
                "{stamp:%27KX5Xjx1acVT0sahG/A0GiC0lK/Py2kxasaeo0nJ/6Dp+/NmJbH/zkw==%27%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cver:5%2Cutc:1627115958304%2Cregion:%27lt%27}",
                "www.rimi.lt",
                "/",
                DateTime.Now.AddDays(5));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
            return this;
        }

        public StoresPage OpenFilter()
        {
            _Filter.Click();
            return this;
        }
        public StoresPage ChooseNVRimi()
        {
            _ChooseCheckbox.Click();
            return this;
        }
        
        public StoresPage StoresWithSIconsAreDisplayed()
        {
            Thread.SpinWait(5000);
            IReadOnlyCollection<IWebElement> _StoresList = Driver.FindElements(By.XPath("/html/body/main/section/div/div[2]/div[1]/div[3]/ul/li"));
            //GetWait().Until(ExpectedConditions.ElementExists(By.XPath("/html/body/main/section/div/div[2]/div[1]/div[3]/ul/li")));

            foreach (IWebElement element in _StoresList)
            {                
                Assert.DoesNotThrow(() => element.FindElement(By.XPath("//img[@class='shop__icon']")), "Not All Items contains S icon");
            }
            return this;
        }

    }
}
