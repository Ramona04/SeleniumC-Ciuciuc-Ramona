using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using UnitTestProject2.Pages;

namespace UnitTestProject2
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.cel.ro/");

            MainPage mainPage = new MainPage(driver);
            Assert.IsTrue(mainPage.CheckTitle().Contains("CEL"));
            Assert.IsTrue(mainPage.CheckLogoVisibility());
            mainPage.SelectItem(7);

            SubMenuPage subMenu = new SubMenuPage(driver);
            subMenu.SelectSubItem();

            ProductsPage selectedPage = new ProductsPage(driver);
            Assert.IsTrue(selectedPage.CheckTitle().Contains("Antivirus"));
            Assert.AreEqual("CEL.ro / Software / Antivirus", selectedPage.CheckPath());
            selectedPage.SelectItem("Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite");
            selectedPage.Notification();

            AntivirusPage antivirusPage = new AntivirusPage(driver);
            antivirusPage.CheckTitle().Contains("Kaspersky Anti-Virus 2017 5PC 1An+3luni");
            antivirusPage.AddToCart();
            antivirusPage.SeeCartContent();

            CartPage cartPage = new CartPage(driver);
            Assert.IsTrue(cartPage.CheckTitle().Contains("Continut"));
            cartPage.EditQuantity();
            Assert.AreEqual("300", cartPage.CheckFinalAmount());

            Console.WriteLine();
        }
    }
}
