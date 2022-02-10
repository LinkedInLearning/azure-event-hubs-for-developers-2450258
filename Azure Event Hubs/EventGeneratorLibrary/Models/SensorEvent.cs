using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGeneratorLibrary.Models
{
    public  class SensorEvent
    {
        public SensorEvent(string sensorType)
        {
            this.SensorType = sensorType;
        }
        public string SensorType { get; private set; }

        public DateTime TimeStamp { get; set; }

        public Guid AccountId { get; set; }
        public int Priority { get; set; }
        public string SensorMessage { get; set; }
    }
}
