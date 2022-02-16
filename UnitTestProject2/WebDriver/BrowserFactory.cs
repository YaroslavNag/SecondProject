using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject2.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch(type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService(@"D:\Automation\UnitTestProject2\UnitTestProject2\bin\Debug\net47");
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddExcludedArgument("enable-automation");
                        option.AddAdditionalOption("useAutomationExtension", false);
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService(@"D:\Automation\UnitTestProject2\UnitTestProject2\bin\Debug\net47");
                        var option = new FirefoxOptions();
                        driver = new FirefoxDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
            }
            return driver;
        }
    }
}
