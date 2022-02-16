using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using UnitTestProject2.WebDriver;

namespace UnitTestProject2.WebObjects
{
    public class MailBoxPage : BasePage
    {
        private static readonly By HomeLbl = By.XPath("//a[@href='/compose/']");

        public MailBoxPage() : base(HomeLbl, "MailBox page") { }

        private IWebDriver driver = Browser.GetDriver();
        private readonly BaseElement _newletterbutton = new BaseElement(By.XPath("//a[@href='/compose/']"));
        private readonly BaseElement _lettertofield = new BaseElement(By.XPath("//div[@data-type='to']//input"));
        private readonly BaseElement _lettersubjectfield = new BaseElement(By.XPath("//input[@name='Subject']"));
        private readonly BaseElement _lettertextfield = new BaseElement(By.XPath("//div[@role='textbox']"));
        private readonly BaseElement _lettersavebutton = new BaseElement(By.XPath("//span[@title='Сохранить']"));
        private readonly BaseElement _accountbutton = new BaseElement(By.XPath("//div[@data-testid='whiteline-account']"));
        private readonly BaseElement _logoutbutton = new BaseElement(By.XPath("//a[@href='//auth.mail.ru/cgi-bin/logout?next=1&lang=ru_RU&page=https%3A%2F%2Fmail.ru%2F%3Ffrom%3Dlogout']"));
        private readonly BaseElement _draftletters = new BaseElement(By.XPath("//a[@href='/drafts/']"));
        private readonly BaseElement _draftletterdelete = new BaseElement(By.XPath("//span[@class='button2__txt'][text()='Удалить']"));

        private readonly BaseElement _closeaftersend = new BaseElement(By.XPath("//a[@class='ph-project svelte-jq5qv5 ph-project_current']/span"));
        private readonly BaseElement _waitforcontainer = new BaseElement(By.XPath("//div[@class='layer-sent-page']"));
        private readonly BaseElement _sendbutton = new BaseElement(By.XPath("//span[@title='Отправить']"));
        private readonly BaseElement _sendedmessages = new BaseElement(By.XPath("//a[@href='/sent/']/div"));
        private readonly BaseElement _inboxmessages = new BaseElement(By.XPath("//a[@href='/inbox/']/div"));

        public void Logout()
        {
            _accountbutton.Click();
            _logoutbutton.Click();
        }

        public void CreateAndSaveLetter(string letterto, string lettersubject, string lettertext)
        {
            _newletterbutton.Click();
            _lettertofield.SendKeys(letterto);
            _lettersubjectfield.SendKeys(lettersubject);
            _lettertextfield.SendKeys(lettertext);
            _lettersavebutton.Click();
        }

        public void DeleteDraftLetter(string lettersubject)
        {
            _draftletters.Click();
            BaseElement draftlettersellection = new BaseElement(By.XPath("//span[@class='ll-sj__normal'][text()='" + lettersubject + "']/../../../../../../div[@class='llc__avatar']/div"));           
            draftlettersellection.Click();            
            _draftletterdelete.Click();               
        }

        public void SendLetter(string email, string lettersubject, string lettertext, int num)
        {
            _newletterbutton.Click();
            _lettertofield.SendKeys(email);
            _lettersubjectfield.SendKeys(lettersubject+num);
            _lettertextfield.SendKeys(lettertext);
            _sendbutton.Click();
            _waitforcontainer.WaitForIsVisible();
            _closeaftersend.Click();       
        }

        public void SendedMessages(string lettersubject, int num)
        {
            _sendedmessages.Click();
            BaseElement sended = new BaseElement(By.XPath("//span[text()='Self: " + lettersubject + num + "']"));
            Thread.Sleep(3000);
            Assert.IsTrue(sended.Displayed);
        }

        public void InboxMessages(string lettersubject, int num)
        {
            _inboxmessages.Click();
            BaseElement inbox = new BaseElement(By.XPath("//span[text()='" + lettersubject + num + "']"));
            Thread.Sleep(3000);
            Assert.IsTrue(inbox.Displayed);
        }
    }
}
