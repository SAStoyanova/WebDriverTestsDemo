using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverCalculatorTests
{
    public class CalculatorTests
    {
        private ChromeDriver driver;
        IWebElement field1;
        IWebElement field2;
        IWebElement operation1;
        IWebElement calculate;
        IWebElement resultField;
        IWebElement clearField;

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
            field1 = driver.FindElement(By.Id("number1"));
            field2 = driver.FindElement(By.Id("number2"));
            operation1 = driver.FindElement(By.Id("operation"));
            calculate = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            clearField = driver.FindElement(By.Id("resetButton"));
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [TestCase("7", "5", "-", "Result: 2")]
        [TestCase("8", "3", "+", "Result: 11")]
        [TestCase("8.55", "3.47", "+", "Result: 12.02")]
        [TestCase("2", "6", "*", "Result: 12")]
        [TestCase("10", "2", "/", "Result: 5")]
        [TestCase("10.258", "10.258", "*", "Result: 105.226564")]
        [TestCase("", "", "+", "Result: invalid input")]
        [TestCase("5", "5", "", "Result: invalid operation")]

        public void Test_Calculator(string num1, string num2, string operation, string result)
        {
            field1.SendKeys(num1);
            operation1.SendKeys(operation);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultField.Text));

            clearField.Click();
        }
    }
}