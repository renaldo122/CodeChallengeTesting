using GiGCodeChallenge.Common.Models;
using GiGCodeChallenge.Common.Tests.Extensions;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System.Text;

namespace GiGCodeChallenge.StreamProcessing.Consumers
{
    public class ConsumerServices :BaseService, IConsumerServices
    {

        #region Methods
        
        /// <inheritdoc />
        public TopicModel GetConsumerMessages(string topicName)
        {
            var topicModel = new TopicModel { topicName = topicName };

            var consumer = new Consumer(new ConsumerOptions(topicName, GetBrokerRouter()));
            try
            {
                foreach (var message in consumer.Consume())
                {
                    var carDetails = Encoding.UTF8.GetString(message.Value).ToSingleObjectDataToken<CarDetailsModel>();
                    topicModel.carDetailsModel.Add(carDetails);
                }
                return topicModel;
            }
            catch (KafkaApplicationException ex)
            {
                throw new KafkaApplicationException(ex.Message);
            }

        }

        #endregion


    }
}
