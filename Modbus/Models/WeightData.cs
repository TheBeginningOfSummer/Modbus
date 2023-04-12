using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus.Models
{
    public class WeightData
    {
        public string Weight { get; set; }
        public string WeighTime { get; set; }

        public WeightData(string weight, string weighTime)
        {
            Weight = weight;
            WeighTime = weighTime;
        }
    }
}
