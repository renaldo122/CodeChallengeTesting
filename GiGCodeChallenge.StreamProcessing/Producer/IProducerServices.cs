using GiGCodeChallenge.Common.Models;
using KafkaNet;

namespace GiGCodeChallenge.StreamProcessing.Producers
{
    public interface IProducerServices
    {
        /// <summary>
        /// Send messages to Producer
        /// </summary>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        long SendProducerMessages(TopicModel topicModel);


        /// <summary>
        /// GetOffsetTopic
        /// </summary>
        /// <param name="topicName"></param>
        /// <returns></returns>
        long GetOffsetTopic( string topicName);
    }
}
