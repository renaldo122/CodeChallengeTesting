using GiGCodeChallenge.StreamProcessing.Tests.Base;
using GiGCodeChallenge.StreamProcessing.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GiGCodeChallenge.StreamProcessing.Tests
{

    [TestClass]
    public class StreamProcessingTests : BaseTestInitalizer
    {

        /// <summary>
        /// Send messages to producer and get from consumer
        /// </summary>
        [TestMethod]
        public void ProducerToConsumerMessagesTest()
        {
          ProducerMessagesTest();

          GetConsumerMessagesTest();
        }

        /// <summary>
        /// Send messages to Producer
        /// </summary>
        public void ProducerMessagesTest()
        {
            topicModel.topicOffset = _producerServices.GetOffsetTopic(topicModel.topicName);
            var producerMessages = _producerServices.SendProducerMessages(topicModel);
            producerMessages.ShouldBeEqual((long)topicModel.carDetailsModel.Count());
        }

        /// <summary>
        /// Get messages from Consumer
        /// </summary>
        public void GetConsumerMessagesTest()
        {
            var consumerTopicModel = _consumerServices.GetConsumerMessages(topicModel.topicName, 
                            topicModel.carDetailsModel.Count(),topicModel.topicOffset);

            consumerTopicModel.ShouldBeEqualObj(topicModel);
        }

    }
}
