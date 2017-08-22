using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject2.Pages
{
    class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement selectedTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cantitate input[name='cart_quantity[]']")]
        private IWebElement quantity { get; set; }

        [FindsBy(How = How.ClassName, Using = "pret_total_final")]
        private IWebElement finalAmount { get; set; }

        public String CheckTitle()
        {
            Thread.Sleep(2000);
            return selectedTitle.Text;
        }

        public void EditQuantity() {
            quantity.SendKeys(Keys.Control + "a");
            quantity.SendKeys(Keys.Delete);
            quantity.SendKeys("3");
            quantity.Submit();
            Thread.Sleep(3000);

        }

        public String CheckFinalAmount() {
            return finalAmount.Text;
        }
    }
}
