using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject2.WebDriver
{
    class Configuration
    {
        public static string GetEnviromentVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnviromentVar("ElementTimeout", "10");

        public static string Browser => GetEnviromentVar("Browser", "Chrome");

        public static string StartUrl => GetEnviromentVar("StartUrl", "https://mail.ru/");
    }
}
