using Automation.Framework.Core;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FasalEcommerceBDD.HelperUtils
{
    public static class Properties
    {
        public static string url = "http://automationpractice.com/";
        public static string URL = "";
        public static string testExecution = "";
        internal static void SetBaseUrl(Envirnoment testEnvironment = Envirnoment.SysTest)
        {
            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            var config = new ConfigurationBuilder().AddJsonFile(System.IO.Path.Combine(newPath, "AppConfig.json")).Build();

            if (testEnvironment == Envirnoment.SysTest)
            {
                URL = config["baseURLSysTest"];
                testExecution = config["testExecution"];
            }
            else if (testEnvironment == Envirnoment.Dev)
            {
                URL = config["baseURLDev"];
                testExecution = config["testExecution"];
            }
            else if (testEnvironment == Envirnoment.UAT)
            {
                URL = config["baseURLUAT"];
                testExecution = config["testExecution"];
            }
            else if (testEnvironment == Envirnoment.Staging)
            {
                URL = config["baseURLPreStaging"];
                testExecution = config["testExecution"];
            }
        }

        
    }
}