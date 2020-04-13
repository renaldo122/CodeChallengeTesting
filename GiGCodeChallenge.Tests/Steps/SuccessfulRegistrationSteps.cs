using System.Collections.Generic;
using TechTalk.SpecFlow;
using GiGCodeChallenge.Tests.BaseSteps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GiGCodeChallenge.Common.Tests.Models;
using GiGCodeChallenge.Common.Tests.Extensions;

namespace GiGCodeChallenge.Tests.Steps
{
    [Binding]
    public class SuccessfulRegistrationSteps : StepBase
    {


        [When(@"the client makes a POST request with the following data (email .* and password .*)")]
        [Scope(Feature = "Successful Registration")]
        public void WhenTheClientMakesAPOSTRequestWithTheFollowingDataEmailAndPassword(Dictionary<string, object> requestBody)
        {
            RequestBodyProperties = requestBody;
            PostRequest();
        }


        [Then(@"I verify json response body to have a token")]
        public void ThenIVerifyJsonResponseBodyToHaveAToken()
        {
            ResponseModel responseModel = ResponseBody.ToSingleObjectDataToken<ResponseModel>();
            Assert.IsTrue(!string.IsNullOrEmpty(responseModel.Token));
        }

    }
}
