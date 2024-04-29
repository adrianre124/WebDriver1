using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V122.DOMSnapshot;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver1
{
    public class Pastebin
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://pastebin.com/";

        public Pastebin(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "postform-text")]
        public IWebElement Post { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"w0\"]/div[5]/div[1]/div[4]/div/span")]
        public IWebElement Select { get; set; }

        [FindsBy(How = How.Id, Using = "postform-name")]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.TagName, Using = "button")]
        public IWebElement Submit { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void CreateNewPaste(string message, string expirationValue, string title)
        {
            // Initiate JavaScriptExecutor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Enter text into 'New Paste' textarea
            this.Post.Clear();
            this.Post.SendKeys(message);

            // Scroll to see 'Create New Paste' button
            js.ExecuteScript("arguments[0].scrollIntoView();", Submit);

            // Select 'Paste Expiration' value from select 
            Select.Click();
            var dropdownOptions = driver.FindElements(By.CssSelector("li[class *= 'select2-results__option'"));
            dropdownOptions.FirstOrDefault(x => x.Text.Equals(expirationValue))?.Click();

            // Enter text into 'Paste Nmae / Title' input field
            this.Title.Clear();
            this.Title.SendKeys(title);

            // Submit form by clicking 'Create New Paste' button
            this.Submit.Click();
        }
    }
}
