using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace UnitTestProject2.Pages
{
    class MainPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement title { get; set; }

        [FindsBy(How = How.Id, Using = "logo_head")]
        private IWebElement logo { get; set; }

        [FindsBy(How = How.ClassName, Using = "grpue")]
        private IWebElement subCategory { get; set; }

        [FindsBy(How = How.ClassName, Using = "categ_name")]
        private IList<IWebElement> menuItems { get; set; }

        public MainPage(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public String CheckTitle() {
            return title.Text; 
        }

        public Boolean CheckLogoVisibility() {
            return logo.Displayed;
        }

        public void SelectItem(int i) {
            Actions action = new Actions(driver);
            action.MoveToElement(menuItems[i]).Perform();
            Thread.Sleep(3000);
        }


    }
}
