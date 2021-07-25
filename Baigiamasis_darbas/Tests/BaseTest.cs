using Baigiamasis_darbas.Drivers;
using Baigiamasis_darbas.Pages;
using Baigiamasis_darbas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis_darbas.Tests
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static LogInPage _logInPage;
        public static ShoppingBagPage _shoppingBagPage;
        public static StoresPage _storePage;


        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _logInPage = new LogInPage(driver);
            _shoppingBagPage = new ShoppingBagPage(driver);
            _storePage = new StoresPage(driver);

        }
        
        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }
        
        [OneTimeTearDown]

        public static void TearDown()
        {
            driver.Quit(); 
        }
    }
}
