using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiGCodeChallenge.StreamProcessing.Consumers;
using GiGCodeChallenge.StreamProcessing.Producers;
using GiGCodeChallenge.Common.Models;

namespace GiGCodeChallenge.StreamProcessing.Tests.Base
{
    [TestClass]
    public abstract class BaseTestInitalizer
    {
        #region Fields

        public ConsumerServices _consumerServices;
        public ProducerServices _producerServices;

        #endregion

        #region Initialize

        [TestInitialize]
        public virtual void Initialize()
        {
            _consumerServices = new ConsumerServices();
            _producerServices = new ProducerServices();
        }

        #endregion

        #region Data
        /// <summary>
        /// Topic data model
        /// </summary>
        public readonly TopicModel topicModel = new TopicModel()
        {
            topicName = "cars",
            carDetailsModel = new List<CarDetailsModel>{
                   new CarDetailsModel{BrandName ="car1" , Model="model1",IsSport=false,NumberofDoors=4},
                   new CarDetailsModel{BrandName ="car2" , Model="model2",IsSport=false,NumberofDoors=4},
                   new CarDetailsModel{BrandName ="car3" , Model="model3",IsSport=true,NumberofDoors=4},
                }
        };
        #endregion
    }
}
