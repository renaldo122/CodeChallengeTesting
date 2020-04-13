using GiGCodeChallenge.Common.Models;

namespace GiGCodeChallenge.StreamProcessing.Producers
{
    public interface IProducerServices
    {
        /// <summary>
        /// Send messages to Producer
        /// </summary>
        /// <param name="topicModel"></param>
        /// <returns></returns>
        int SendProducerMessages(TopicModel topicModel);
    }
}
