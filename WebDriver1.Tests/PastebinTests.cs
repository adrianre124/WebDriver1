using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriver1.Tests
{
    public class PastebinTests
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        [SetUp]
        public void Setup()
        {
            this.Driver = new ChromeDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
            this.Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }

        [Test]
        public void Pastebin_CreateNewPaste()
        {
            Pastebin pastebin = new Pastebin(this.Driver);
            pastebin.Navigate();
            pastebin.CreateNewPaste("Hello from WebDriver", "10 Minutes", "helloweb");
            Assert.IsTrue(true);
        }
    }
}