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
       
    }
}
