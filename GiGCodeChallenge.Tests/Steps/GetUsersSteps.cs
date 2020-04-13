using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using GiGCodeChallenge.Tests.BaseSteps;
using GiGCodeChallenge.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GiGCodeChallenge.Common.Tests.Models;
using GiGCodeChallenge.Common.Tests.Extensions;

namespace GiGCodeChallenge.Tests.Steps
{
    [Binding]
    public class GetUsersSteps : StepBase
    {

        [Given(@"I have a GET API End Point '(.*)'")]
        public void GivenIHaveAGETAPIEndPoint(string apiEndPoint)
        {
            RequestUrl = string.Format(ConfigurationHelper.TestProvidedAPI + "{0}", apiEndPoint);
        }

        [When(@"the client makes a get request")]
        public void WhenAClientMakesAGetRequest()
        {
            GetResponse();
        }

        [Then(@"Then I verify json response data to have list of users")]
        public void ThenThenIVerifyJsonResponseDataToHaveListOfUsers()
        {
            List<UserModel> userModel = ResponseBody.ToObjectData<UserModel>();
            Assert.IsTrue(userModel.Any());
        }
    }
}