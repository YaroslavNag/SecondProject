using OpenQA.Selenium;

namespace UnitTestProject2.WebObjects
{
    class BasePage
    {
        protected By _titlelocator;
        protected string _title;
        public static string _titleform;

        protected BasePage(By TitleLocator, string title)
        {
            _titlelocator = TitleLocator;
            _title = _titleform = title;
            AssertIsOpen();
        }

        public void AssertIsOpen()
        {
            var label = new BaseElement(_titlelocator, _title);
            label.WaitForIsVisible();
        }
    }
}
