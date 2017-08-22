using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    class AntivirusPage
    {
        private IWebDriver driver;

        public AntivirusPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement selectedTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".buttons form .btn")]
        private IWebElement addButton { get; set; }

        [FindsBy(How = How.Id, Using = "btngocart")]
        private IWebElement goToCart { get; set; }

        public String CheckTitle() {
            Thread.Sleep(2000);
            return selectedTitle.Text;
        }

        public void AddToCart() {
            Thread.Sleep(2000);
            addButton.Click();
        }

        public void SeeCartContent()
        {
            Thread.Sleep(2000);
            goToCart.Click();
        }
    }
}
