using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using UnitTestProject2.WebObjects;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        private MainPage _mainpage;
        private MailBoxPage _mailboxpage;
        private const string _letterto = "test";
        private const string _lettersubject = "test";
        private const string _lettertext = "test";
        private const string _login = "ddr_s8";
        private const string _password = "mimoza35";

        [TestMethod]
        public void LoginAndCreatLetter()
        {
            _mainpage = new MainPage();
            _mainpage.LoginToMail(_login, _password);
            _mailboxpage = new MailBoxPage();
            _mailboxpage.CreateAndSaveLetter(_letterto, _lettersubject, _lettertext);
            _mailboxpage.Logout();
        }

        [TestMethod]
        public void LoginAndDeleteLetter()
        {
            _mainpage = new MainPage();
            _mainpage.LoginToMail(_login, _password);
            _mailboxpage = new MailBoxPage();
            _mailboxpage.DeleteDraftLetter(_lettersubject);
            _mailboxpage.Logout();
        }

    }
}
