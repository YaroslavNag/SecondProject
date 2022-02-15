using UnitTestProject2.WebDriver;
using System;
using OpenQA.Selenium;


namespace UnitTestProject2.WebObjects
{
    public class MainPage : BasePage
    {
        private static readonly By HomeLbl = By.XPath("//button[@class='ph-login svelte-1hiqrvn']");

        public MainPage() : base(HomeLbl, "Home Page") {}

        private readonly BaseElement _loginbutton = new BaseElement(By.XPath("//button[@class='ph-login svelte-1hiqrvn']"));
        private readonly BaseElement _loginfield = new BaseElement(By.XPath("//input[@name='username']"));
        private readonly BaseElement _getiframe = new BaseElement(By.XPath("//iframe[@class='ag-popup__frame__layout__iframe']"));
        private readonly BaseElement _passwordbutton = new BaseElement(By.XPath("//button[@data-test-id='next-button']"));
        private readonly BaseElement _passwordfield = new BaseElement(By.XPath("//input[@name='password']"));
        private readonly BaseElement _logintomail = new BaseElement(By.XPath("//button[@data-test-id='submit-button']"));

        public void LoginButton()
        {
            _loginbutton.Click();
        }

        public void LoginToMail(string login, string password)
        {
           Browser.GetDriver().SwitchTo().Frame(_getiframe.GetElement());
            _loginfield.SendKeys(login);
            _passwordbutton.Click();
            _passwordfield.SendKeys(password);   
            _logintomail.Click();
           Browser.GetDriver().SwitchTo().DefaultContent();
        }
    }
}
