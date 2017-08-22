using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject2.Pages
{
    class SubMenuPage
    {
        private IWebDriver driver;

        public SubMenuPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//a[contains(@href,'http://www.cel.ro/antivirus/')]")]
        private IWebElement menuSubItems { get; set; }

        public void SelectSubItem(){
            menuSubItems.Click();
        }
    }
}
