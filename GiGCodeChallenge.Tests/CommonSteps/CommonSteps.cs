using GiGCodeChallenge.Tests.BaseSteps;
using GiGCodeChallenge.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GiGCodeChallenge.Tests.CommonSteps
{
    [Binding]
    public class UnsuccessfulRegistration : StepBase
    {

        [Scope(Feature = "Successful Registration")]
        [Scope(Feature = "Unsuccessful Registration")]
        [Given(@"I have a POST API End Point '(.*)'")]
        public void GivenIHaveAPOSTAPIEndPoint(string apiEndPoint)
        {
            RequestUrl = string.Format(ConfigurationHelper.TestProvidedAPI + "{0}", apiEndPoint);
        }


       
        [Scope(Feature = "Get Users")]
        [Scope(Feature = "Successful Registration")]
        [Scope(Feature = "Unsuccessful Registration")]
        [Then(@"I expect response status code '(.*)'")]
        public void ThenIExpectResponseStatusCode(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)ResponseMessage.StatusCode);
        }
    }
}
