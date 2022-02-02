using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using UnitTestProject2.WebDriver;

namespace UnitTestProject2
{
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance;

        [TestInitialize]
        public virtual void InitTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TestCleanup]
        public virtual void CleanTest()
        {
            Browser.Quit();
        }
    }
}
