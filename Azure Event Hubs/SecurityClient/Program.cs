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
            var eventBatch = await producer.CreateBatchAsync();
            var events = EventGenerator.GetSensorEvents(Sensors.DoorSensor, 900);
            foreach (var sensorEvent in events)
            {
                var isSuccessfullyAdded = eventBatch.TryAdd(new Azure.Messaging.EventHubs.EventData(JsonSerializer.Serialize(sensorEvent)));
                if (!isSuccessfullyAdded)
                {
                    if (eventBatch.Count > 0)
                    {
                        await producer.SendAsync(eventBatch);
                        Console.WriteLine($"Batch data sent with total batch amount of {eventBatch.Count}");
                        eventBatch = await producer.CreateBatchAsync();
                    }
                    else
                    {
                        //log event that failed
                    }
                }
            }

            if (eventBatch.Count > 0)
            {
                await producer.SendAsync(eventBatch);
            }

            eventBatch.Dispose();


            await Task.Delay(5000);
        }
    }
}
