using GiGCodeChallenge.Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using KafkaNet;
using KafkaNet.Protocol;

namespace GiGCodeChallenge.StreamProcessing.Producers
{
    public class ProducerServices : BaseService, IProducerServices
    {

        #region Methods

        /// <inheritdoc />
        public int SendProducerMessages(TopicModel topicModel)
        {
            var producer = new Producer(GetBrokerRouter());

            try
            {
                var messages = new List<Message>();
                foreach (var itemcarDetails in topicModel.carDetailsModel)
                {
                    messages.Add(new Message(JsonConvert.SerializeObject(itemcarDetails)));
                }
                var response = producer.SendMessageAsync(topicModel.topicName, messages).Result;

                return response.Count;
            }
            catch (KafkaApplicationException ex)
            {
                throw new KafkaApplicationException(ex.Message);
            }
        }

        #endregion
    }
}
