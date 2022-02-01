using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string baseurl;

        [TestInitialize]
        public void SetupTest()
        {
            var service = ChromeDriverService.CreateDefaultService(@"D:\Automation\UnitTestProject1\UnitTestProject1\bin\Debug\netcoreapp2.1");
            this.driver = new ChromeDriver(service);
            this.baseurl = "https://mail.ru/";

            this.driver.Navigate().GoToUrl(this.baseurl);
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
