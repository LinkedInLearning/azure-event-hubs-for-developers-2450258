using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsumerClient
{
    public class EventProcessor
    {

        public async Task StartEventProcessing()
        {
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            var storageClient = new BlobContainerClient(
                "Stroage_Connection_String",
                "blob_container_name");

            var eventHubsConnectionString = "event_hub_connection_string";
            var eventHubName = "event_hub_name";

            var processor = new EventProcessorClient(storageClient,consumerGroup,eventHubsConnectionString,eventHubName);

        }
    }
}
