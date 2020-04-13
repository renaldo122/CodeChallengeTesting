using GiGCodeChallenge.Common.Models;

namespace GiGCodeChallenge.StreamProcessing.Consumers
{
    public interface IConsumerServices
    {
        /// <summary>
        ///Get messages from Consumer
        /// </summary>
        /// <param name="topicName"></param>
        /// <returns></returns>
        TopicModel GetConsumerMessages(string topicName);
    }
}
