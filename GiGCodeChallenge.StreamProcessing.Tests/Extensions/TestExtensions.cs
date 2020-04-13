using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GiGCodeChallenge.StreamProcessing.Tests.Extensions
{
    public static class TestExtensions
    {
        /// <summary>
        /// Compare varibale are equal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static T ShouldBeEqual<T>(this T actual, object expected)
        {
            Assert.AreEqual(expected, actual);
            return actual;
        }

        /// <summary>
        /// Compare two objects are equal
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static T ShouldBeEqualObj<T>(this T actual, object expected)
        {
            Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(expected));
            return actual;
        }
       
    }
}
