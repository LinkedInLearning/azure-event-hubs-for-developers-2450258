using Azure.Messaging.EventHubs.Producer;
using EventGeneratorLibrary;
using EventGeneratorLibrary.Enums;
using System.Text.Json;


await StartEventGenerating();


async Task StartEventGenerating()
{
    var connectionString = "";
    var eventHubName = "";

    await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
    {
       
    }
}
