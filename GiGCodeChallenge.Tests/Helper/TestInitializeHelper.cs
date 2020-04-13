using TechTalk.SpecFlow;

namespace GiGCodeChallenge.Tests.Helper
{
    [Binding]
   public class TestInitializeHelper
    {
        private readonly ScenarioContext _scenarioContext;
        public TestInitializeHelper( ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        /// <summary>
        /// BeforeTestRun
        /// Get configuration befor Test Run
        /// </summary>
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
           ConfigurationHelper.BuildConfiguration();
        }
    }
}
