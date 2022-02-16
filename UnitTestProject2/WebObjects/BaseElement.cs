using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UnitTestProject2.WebDriver;

namespace UnitTestProject2.WebObjects
{
    public class BaseElement : IWebElement
    {
        private IWebDriver _driver = Browser.GetDriver();
        protected string _name;
        protected By _locator;
        protected IWebElement _element;

        public BaseElement(By locator, string name)
        {
            _locator = locator;
            _name = name ==  "" ? GetText() : name;
        }

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public string GetText()
        {
            WaitForIsVisible();
            return _element.Text;
        }

        public IWebElement GetElement()
        {
            try
            {
                _element = Browser.GetDriver().FindElement(_locator);
            }
            catch(Exception)
            {
                throw;
            }
            return _element;
        }

        public void WaitForIsVisible()
        {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Browser._timeoutForElement)).Until(ExpectedConditions.ElementIsVisible(_locator));
        }

        public IWebElement FindElement(By @by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException(); 
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Click();
        }

        public void JsCLick()
        {
            throw new NotImplementedException();    
        }

        public string GetAttribute(string attribute)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string domattribute)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string dompropertyName)
        {
            throw new NotImplementedException();
        }

        ISearchContext IWebElement.GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public string TagName { get; }
        public string Text { get; }
        public bool Enabled { get; }
        public bool Selected { get; }
        public Point Location { get; }
        public Size Size { get; }
        public bool Displayed
        {
            get
            {
                try
                {
                    Browser.GetDriver().FindElement(_locator);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
                } 
        }
    }
}
