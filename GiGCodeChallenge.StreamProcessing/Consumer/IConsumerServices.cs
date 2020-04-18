using GiGCodeChallenge.Common.Models;

namespace GiGCodeChallenge.StreamProcessing.Consumers
{
    public interface IConsumerServices
    {
        /// <summary>
        ///Get messages from Consumer
        /// </summary>
        /// <param name="topicName"></param>
        ///  <param name="topicOffset"></param>
        ///   <param name="topicOffset"></param>
        /// <returns></returns>
        TopicModel GetConsumerMessages(string topicName, int topicCount,long topicOffset);
    }
}
