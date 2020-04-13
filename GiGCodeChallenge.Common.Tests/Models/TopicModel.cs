using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiGCodeChallenge.Common.Models
{
    public class TopicModel
    {
        public TopicModel(){
            carDetailsModel = new List<CarDetailsModel>();
        }
        public string topicName { get; set; }

        public List<CarDetailsModel> carDetailsModel { get; set; }

    }
    public class CarDetailsModel
    {
        public string BrandName { get; set; }

        public string Model { get; set; }

        public int NumberofDoors { get; set; }

        public bool IsSport { get; set; }
    }
  }
