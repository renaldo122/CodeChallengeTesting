using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GiGCodeChallenge.Tests.BaseSteps
{
    public abstract class StepBase 
    {
        /// <summary>
        /// Request Url
        /// </summary>
        protected string RequestUrl
        {
            get { return ScenarioContext.Current.Get<string>("RequestUrl"); }
            set { ScenarioContext.Current.Set<string>(value, "RequestUrl"); }
        }

        /// <summary>
        /// Request Headers
        /// </summary>
        protected Dictionary<string, string> RequestHeaders
        {
            get { return ScenarioContext.Current.Get<Dictionary<string, string>>("RequestHeaders"); }
            set { ScenarioContext.Current.Set<Dictionary<string, string>>(value, "RequestHeaders"); }
        }

        /// <summary>
        /// Request Body Properties
        /// </summary>
        protected Dictionary<string, object> RequestBodyProperties
        {
            get { return ScenarioContext.Current.Get<Dictionary<string, object>>("RequestBodyProperties"); }
            set { ScenarioContext.Current.Set<Dictionary<string, object>>(value, "RequestBodyProperties"); }
        }

        /// <summary>
        /// Response Message
        /// </summary>
        protected HttpResponseMessage ResponseMessage
        {
            get { return ScenarioContext.Current.Get<HttpResponseMessage>("ResponseMessage"); }
            set { ScenarioContext.Current.Set<HttpResponseMessage>(value, "ResponseMessage"); }
        }

        /// <summary>
        /// Response Body
        /// </summary>
        protected string ResponseBody
        {
            get { return ScenarioContext.Current.Get<string>("ResponseBody"); }
            set { ScenarioContext.Current.Set<string>(value, "ResponseBody"); }
        }

        /// <summary>
        /// Response
        /// </summary>
        protected dynamic Response
        {
            get { return ScenarioContext.Current.Get<dynamic>("Response"); }
            set { ScenarioContext.Current.Set<dynamic>(value, "Response"); }
        }

        /// <summary>
        /// Get Response
        /// </summary>
        protected void GetResponse()
        {
            Action<HttpClient> setup = x =>
            {
                foreach (var header in RequestHeaders)
                {
                    x.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            };
            SendRequest(x => x.GetAsync(RequestUrl), setup).Wait();
        }

        /// <summary>
        /// Post Request
        /// </summary>
        protected void PostRequest()
        {
            var json = JsonConvert.SerializeObject(RequestBodyProperties);
            
            var content = new StringContent(json, Encoding.UTF8, "application/json");
          
            SendRequest(x => x.PostAsync(RequestUrl, content)).Wait();
        }

        /// <summary>
        /// Send Request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="setup"></param>
        /// <returns></returns>
        protected async Task SendRequest(Func<HttpClient, Task<HttpResponseMessage>> request, Action<HttpClient> setup = null)
        {
            ResponseMessage = null;
            ResponseBody = null;
            Response = null;
            using (var client = new HttpClient())
            {
                ResponseMessage = await request(client);
                ResponseBody = await ResponseMessage.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(ResponseBody))
                {
                    Response = JsonConvert.DeserializeObject<dynamic>(ResponseBody);
                }
            }
        }
    }
}
