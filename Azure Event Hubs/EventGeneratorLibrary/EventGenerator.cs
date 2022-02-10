using EventGeneratorLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGeneratorLibrary
{
    public static class EventGenerator
    {

        public static IEnumerable<Models.SensorEvent> GetSensorEvents(string sensorType, int events = 50)
        {
            int generatedEvents = 0;

            while (generatedEvents < events)
            {
                generatedEvents += 1;

                yield return new Models.SensorEvent(sensorType)
                {
                    Priority = 1,
                    AccountId = Guid.NewGuid(),
                    TimeStamp = DateTime.UtcNow,
                    SensorMessage = new string('*', 10000)

                };
            }
        }


       
    }
}
