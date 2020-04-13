using GiGCodeChallenge.Common.Tests.Extensions;
using GiGCodeChallenge.Common.Tests.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace GiGCodeChallenge.Tests.Transformation
{
    [Binding]
    public class CustomTransforms
    {
        /// <summary>
        /// GetRequestBodyProperties
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [StepArgumentTransformation(@"email (.*) and password (.*)")]
        public Dictionary<string, object> GetRequestBodyProperties(string email, string password)
        {
            var registrationModel = new RegistrationModel {
                Email = email,
                Password = password
            };
            var jsonContent = JsonConvert.SerializeObject(registrationModel);

            return jsonContent.ToDictionary();
        }


        /// <summary>
        /// GetRequestBodyProperties
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [StepArgumentTransformation(@"email (.*)")]
        public Dictionary<string, object> GetRequestBodyProperties(string email)
        {
            var registrationModel = new RegistrationModel{
                Email = email,
            };
            var jsonContent = JsonConvert.SerializeObject(registrationModel);

            return jsonContent.ToDictionary();
        }
    }
}
