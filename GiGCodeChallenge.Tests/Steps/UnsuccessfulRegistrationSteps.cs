using System.Collections.Generic;
using TechTalk.SpecFlow;
using GiGCodeChallenge.Tests.BaseSteps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GiGCodeChallenge.Common.Tests.Models;
using GiGCodeChallenge.Common.Tests.Extensions;

namespace GiGCodeChallenge.Tests.Steps
{
    [Binding]
    public class UnsuccessfulRegistration : StepBase
    {

        [When(@"the client makes a POST request with the following data (email .*)")]
        public void WhenTheClientMakesAPOSTRequestWithTheFollowingDataEmail(Dictionary<string, object> requestBody)
        {
            RequestBodyProperties = requestBody;
            PostRequest();
        }

        [Then(@"I verify json response body to have an error message")]
        public void ThenIVerifyJsonResponseBodyToHaveAnErrorMessage()
        {
            ResponseModel responseModel = ResponseBody.ToSingleObjectDataToken<ResponseModel>();
            Assert.IsTrue(!string.IsNullOrEmpty(responseModel.Error));
        }

    }
}
