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
    public class ShoppingBagPage : BasePage
    {
        private const string PageAddress = "https://www.rimi.lt/e-parduotuve/lt/paieska";
        private IWebElement _AddToShoppingBag => Driver.FindElement(By.XPath("//*[@id='main']/section/div[1]/div/div[2]/div[1]/div/div[2]/ul/li[1]/div/div[2]/div/form[2]/button"));
      
        private IWebElement _Result => Driver.FindElement(By.CssSelector("#main > section > div.cart-layout__aside > div > aside > div.side-cart__content > div.side-card.js-product-container.js-side-cart-product-container > div.flex > div.side-card__details > a"));
        private IWebElement _ClickPlus => Driver.FindElement(By.XPath("//button[@name='increase']"));
        private IWebElement _Result2ItemsAreAdded => Driver.FindElement(By.CssSelector("#main > section > div.cart-layout__body > div > div.cart-layout__main > div.distill > div > div.distill__grid > ul > li:nth-child(1) > div > div.card__details > div > form.counter.js-counter.-visible > span"));
        private IWebElement _RemoveAllProducts => Driver.FindElement(By.CssSelector("#main > section > div.cart-layout__aside > div > aside > footer > div.side-cart__footer-actions > button.link-button.-with-left-icon.js-delete-products-modal"));
        private IWebElement _AreYouSureyouWantToDelete => Driver.FindElement(By.CssSelector("body > div.modal.open > div > div > form > button.button.-has-loader"));
        private IWebElement _EmptyShoppingBag => Driver.FindElement(By.CssSelector("#main > section > div.cart-layout__aside > div > aside > div.side-cart__content > div > p"));
        public ShoppingBagPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public ShoppingBagPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public ShoppingBagPage AcceptAllCookies()
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
        public ShoppingBagPage AddToShoppingBag()
        {
            _AddToShoppingBag.Click();
            return this;
        }
        public ShoppingBagPage CheckItemIsAdded(string itemTitle)
        {
            Assert.IsTrue(_Result.Text.Contains(itemTitle), $"Result is wrong, not {itemTitle}");
            return this;
        }
        public ShoppingBagPage AddOneMoreTheSameItem()
        {
            _ClickPlus.Click();
            return this;
        }
        public ShoppingBagPage CheckItemsAreAdded(string itemsCount)
        {
            Assert.IsTrue(_Result2ItemsAreAdded.Text.Contains(itemsCount), $"Result is wrong, not {itemsCount}");
            return this;
        }


        public ShoppingBagPage EmptyShoppingBag()
        { 
            if (_RemoveAllProducts.Enabled)
            _RemoveAllProducts.Click();
            return this;
        }
        
        public ShoppingBagPage ApproveEmptyShoppingBag()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(_AreYouSureyouWantToDelete));
            //Thread.Sleep(3000);
            _AreYouSureyouWantToDelete.Click();
            return this;
        }
        
        public ShoppingBagPage ShoppingBagIsEmpty(string text)
        {
            //GetWait().Until(ExpectedConditions.TextToBePresentInElementValue(_EmptyShoppingBag, text));
            Thread.Sleep(3000);
            Assert.IsTrue(_EmptyShoppingBag.Text.Equals(text), $"Result is wrong, not {text}");
            return this;
        }
        
    }
}
