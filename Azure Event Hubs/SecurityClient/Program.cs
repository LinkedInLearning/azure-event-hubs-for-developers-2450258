using Azure.Messaging.EventHubs.Producer;
using EventGeneratorLibrary;
using EventGeneratorLibrary.Enums;
using System.Text.Json;


await StartEventGenerating();


async Task StartEventGenerating()
{

    var connectionString = "Endpoint=sb://eventhubcourse.servicebus.windows.net/;SharedAccessKeyName=sensorloggenerator;SharedAccessKey=Gw54t2gyzr2Ya163Tma8ADbwvlQy2UPkXBMW2oAIblQ=";
    var eventHubName = "sensordata";

    await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
    {
        while (true)
        {
            using (var eventBatch = await producer.CreateBatchAsync())
            {
                var events = EventGenerator.GetSensorEvents(Sensors.DoorSensor, 20);
                foreach (var sensorEvent in events)
                {
                    eventBatch.TryAdd(new Azure.Messaging.EventHubs.EventData(JsonSerializer.Serialize(sensorEvent)));
                }
                await producer.SendAsync(eventBatch);
                Console.WriteLine("Batch data sent");
            }

            await Task.Delay(5000);
        }
    }
}
