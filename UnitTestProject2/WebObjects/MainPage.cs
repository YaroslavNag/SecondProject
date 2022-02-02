using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UnitTestProject2.WebObjects
{
    public class MainPage : BasePage
    {
        private static readonly By HomeLbl = By.XPath("//button[@data-testid='mailbox-create-link']");

        public MainPage() : base(HomeLbl, "Home Page") {}

        private readonly BaseElement _loginfield = new BaseElement(By.XPath("//input[@name='login']"));
        private readonly BaseElement _passwordbutton = new BaseElement(By.XPath("//button[@data-testid='enter-password']"));
        private readonly BaseElement _passwordfield = new BaseElement(By.XPath("//input[@name='password']"));
        private readonly BaseElement _logintomail = new BaseElement(By.XPath("//button[@data-testid='login-to-mail']"));

        public void LoginToMail(string login, string password)
        {       
            _loginfield.SendKeys(login);
            _passwordbutton.Click();
            _passwordfield.SendKeys(password);
            _logintomail.Click();
        }
    }
}
