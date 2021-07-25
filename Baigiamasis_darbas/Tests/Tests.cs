using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis_darbas.Tests
{
    public class Tests : BaseTest
    {
        [Order(1)]
        [Test]
         public static void TestLogIn()
         {
            _logInPage.NavigateToDefaultPage()
                .ClickAcceptAllCookies()
                .ClickLoginButton()
                .InsertEmail("aaa@bbb.ccc")
                .InsertPassword("Password1")
                .Cookies()
                .ClickLogin()
                .CheckResult("Abc");
         }
        [Order(2)]
        [Test]
         public static void TestItemAddingToShoppingBag()
         {
            _shoppingBagPage.NavigateToDefaultPage()
                .AcceptAllCookies()
                .AddToShoppingBag()
                .CheckItemIsAdded("ROKIŠKIO NAMINIS");
         }
        [Order(3)]
        [Test]
        public static void TestItemAddingViaPlusButton()
        {
            _shoppingBagPage.AddOneMoreTheSameItem()
                .CheckItemsAreAdded("2");
        }

        [Order(4)]
        [Test]
        public static void TestEmptyShoppingBag()
        {
            _shoppingBagPage.EmptyShoppingBag()
                .ApproveEmptyShoppingBag()
                .ShoppingBagIsEmpty("Jūsų krepšelis tuščias");
        }

        [Order(5)]
        [Test]
        public static void TestFilter()
        {
            _storePage.NavigateToDefaultPage()
                .AcceptAllCookies()
                .OpenFilter()
                .ChooseNVRimi()
                .StoresWithSIconsAreDisplayed();
        }

    }
}
