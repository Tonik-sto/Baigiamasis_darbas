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

         [Test]
         public static void TestShoppingBag()
         {

         }
    }
}
