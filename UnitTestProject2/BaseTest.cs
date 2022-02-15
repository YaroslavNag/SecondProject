using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject2.WebDriver;

namespace UnitTestProject2
{
    public class BaseTest
    {
        protected static Browser Browser = Browser.Instance;

        public TestContext TestContext { get; set; }

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
