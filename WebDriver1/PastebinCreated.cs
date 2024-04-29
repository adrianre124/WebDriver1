using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver1
{
    public class PastebinCreated
    {
        private readonly IWebDriver driver;
        private WebDriverWait wait;
        private readonly string url = @"https://pastebin.com/";

        public PastebinCreated(IWebDriver browser, WebDriverWait wait)
        {
            this.driver = browser;
            this.wait = wait;
            PageFactory.InitElements(browser, this);
        }
    }
}
