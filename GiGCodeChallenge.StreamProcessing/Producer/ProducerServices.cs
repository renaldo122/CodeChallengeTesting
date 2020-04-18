using GiGCodeChallenge.Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using KafkaNet;
using KafkaNet.Protocol;
using System.Linq;

namespace GiGCodeChallenge.StreamProcessing.Producers
{
    public class ProducerServices : BaseService, IProducerServices
    {

        #region Methods

        /// <inheritdoc />
        public long SendProducerMessages(TopicModel topicModel)
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
                
                var offsetsAfterMessage = GetOffsetTopic(topicModel.topicName);

                return (offsetsAfterMessage- topicModel.topicOffset);
            }
            catch (KafkaApplicationException ex)
            {
                throw new KafkaApplicationException(ex.Message);
            }
        }

        /// <inheritdoc />
        public long GetOffsetTopic(string topicName)
        {
            var producer = new Producer(GetBrokerRouter());
            return  producer.GetTopicOffsetAsync(topicName).Result
                    .Select(x => new OffsetPosition(x.PartitionId, x.Offsets.Max())).FirstOrDefault().Offset;
        }
        #endregion

        }
}
