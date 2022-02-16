using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Collections;
using System.IO;
using CsvHelper;
using UnitTestProject2.WebObjects;
using System.Web;
using UnitTestProject2.WebDriver;
using System.Collections.Generic;
using System.Globalization;
using OpenQA.Selenium;
using System.Threading;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {     
        private MainPage _mainpage;
        private MailBoxPage _mailboxpage;
        private string _login = ConfigurationManager.AppSettings["email"].ToString();
        private string _password = ConfigurationManager.AppSettings["password"].ToString();

        [DeploymentItem(@"Resources")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Mess.csv","Mess#csv",DataAccessMethod.Sequential)]
        [TestMethod]
        public void LoginAndCreatLetter()
        {
            _mainpage = new MainPage();
            _mainpage.LoginButton();
            _mainpage.LoginToMail(_login, _password);
            _mailboxpage = new MailBoxPage();
            var address = TestContext.DataRow["address"].ToString();
            var subject = TestContext.DataRow["subject"].ToString();
            var text = TestContext.DataRow["text"].ToString();
            _mailboxpage.CreateAndSaveLetter(address, subject, text);
            _mailboxpage.Logout();
        }

        [DeploymentItem(@"Resources")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Mess.csv","Mess#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void LoginAndDeleteLetter()
        {
            _mainpage = new MainPage();
            _mainpage.LoginButton();
            _mainpage.LoginToMail(_login, _password);
            _mailboxpage = new MailBoxPage();
            var subject = TestContext.DataRow["subject"].ToString();
            _mailboxpage.DeleteDraftLetter(subject);
            _mailboxpage.Logout();
        }


        [DeploymentItem(@"Resources")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Subject.csv", "Subject#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void SendMessageAndCheckIt()
        {
            _mainpage = new MainPage();
            _mainpage.LoginButton();
            _mainpage.LoginToMail(_login, _password);
            _mailboxpage = new MailBoxPage();
            var subject = TestContext.DataRow["subject"].ToString();
            int number = Int32.Parse(TestContext.DataRow["number"].ToString());
            number += 1;
            _mailboxpage.SendLetter(_login, subject, "texttext", number);
            CsvWrite(subject, number);
            _mailboxpage.SendedMessages(subject, number);
            _mailboxpage.InboxMessages(subject, number);
            _mailboxpage.Logout();
        }


        public void CsvWrite(string sub,int num)
        {
            var records = new List<Foo>
            {
            new Foo { subject = sub, number = num },
            };
            //Ќе смог сделать неполный путь тк он посто€нно лезит в папку TestResults которую € не могу отключить, чтобы она вообще не создавалась
            using (var writer = new StreamWriter(@"D:\Automation\UnitTestProject2\UnitTestProject2\Resources\Subject.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        public class Foo
        {
            public string subject { get; set; }
            public int number { get; set; }
        }
    }
}
