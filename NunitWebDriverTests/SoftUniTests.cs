using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;
        
        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }

        [Test]
        public void Test_AssertAboutUsTitle()
        {
            var zaNasElement = driver.FindElement(By.XPath("//nav[@id='header-nav']/div/ul/li/a/span"));
            zaNasElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }

    }
}