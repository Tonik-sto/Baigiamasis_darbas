using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis_darbas.Pages
{
    public class ShoppingBagPage : BasePage
    {
        private const string PageAddress = "https://www.rimi.lt/e-parduotuve/lt/paieska";

        public ShoppingBagPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public ShoppingBagPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
    }
}
