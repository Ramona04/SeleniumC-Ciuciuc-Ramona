using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2.Pages {
    class ProductsPage {
        private IWebDriver driver;

        public ProductsPage(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "head title")]
        private IWebElement selectedTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".breadCrumb span span a b")]
        private IList<IWebElement> pathList { get; set; }

        [FindsBy(How = How.Id, Using = "mesaj_custom")]
        private IWebElement popUp { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='close']/a[contains(@onclick,'modal_close();return false;')]")]
        private IWebElement closeButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".productTitle span")]
        private IList<IWebElement> itemList { get; set; }

        public String CheckTitle() {
            return selectedTitle.Text;
        }

        public string CheckPath() {
            string path = "";
            for (int i = 0; i < pathList.Count; i++) {
                path = path + " / "+pathList[i].Text;
            }
            return path.Remove(0,3);
        }

        public void Notification() {
            if (popUp.Displayed) {
                closeButton.Click();
            }
        }

        public void SelectItem(String name) {
            for(int i = 0; i<itemList.Count; i++) {
                if (itemList[i].Text.Contains(name))
                {
                    itemList[i].Click();
                    break;
                }
            }
        }
    }
}

