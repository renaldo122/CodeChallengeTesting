using KafkaNet;
using KafkaNet.Model;
using System;
using System.Configuration;

namespace GiGCodeChallenge.StreamProcessing
{
    public abstract class BaseService
    {

        /// <summary>
        /// Get Broker router
        /// </summary>
        /// <returns></returns>
        public BrokerRouter GetBrokerRouter()
        {
            Uri uri = new Uri(ConfigurationManager.AppSettings["ServerUrl"]);
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            return router;
        }
    }
}
