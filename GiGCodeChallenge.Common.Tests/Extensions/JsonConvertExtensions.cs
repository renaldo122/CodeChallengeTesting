using GiGCodeChallenge.Common.Tests.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace GiGCodeChallenge.Common.Tests.Extensions
{
    public static class JsonConvertExtensions
    {
        /// <summary>
        /// Generic Extension Json to List
        /// Convert Request Body data in list of object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonResonse"></param>
        /// <returns></returns>
        public static List<T> ToObjectData<T>(this string jsonParams)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonParams)) return new List<T>();
                JObject userObject = JObject.Parse(jsonParams);
                JArray data = (JArray)userObject["data"];
                List<T> objectData = JsonConvert.DeserializeObject<List<T>>(data.ToString());
                return objectData;
            }
            catch (Exception)
            {
                throw new GiGCodeChallengeException("Can not convert Json Params in List of object");
            }
        }

        /// <summary>
        /// Generic Extension Json to single object
        /// Convert Request Body data in single model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonResonse"></param>
        /// <returns></returns>
        public static T ToSingleObjectDataToken<T>(this string jsonParams)
        {
            try
            {
                T objectData = JsonConvert.DeserializeObject<T>(jsonParams);
                return objectData;
            }
            catch (Exception)
            {
                throw new GiGCodeChallengeException("Can not convert Json Params to object");
            }
        }

        /// <summary>
        /// Convert Json to Dictionary
        /// </summary>
        /// <param name="jsonParams"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDictionary(this string jsonParams)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonParams)) return new Dictionary<string, object>();
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonParams);
            }
            catch (Exception)
            {
                throw new GiGCodeChallengeException("Can not convert Json Params to dictionary");
            }
        }

    }
}
