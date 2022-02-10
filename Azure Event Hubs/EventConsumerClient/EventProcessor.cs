using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsumerClient
{
    public class EventProcessor
    {
        ConcurrentDictionary<string, int> partitionEventCount = new ConcurrentDictionary<string, int>();
        public async Task StartEventProcessing(CancellationToken cToken)
        {
            string consumerGroup = "archiving";
            var storageClient = new BlobContainerClient(
                "DefaultEndpointsProtocol=https;AccountName=checkpointstorecourse;AccountKey=i5wNbxBTSXyVnvBZRvCTajDlpdKnCNiEZl2p6UlrjbdicRBC/AVsiNW1mdQEo+4iwbscemSUEh1y+ASt0+PW/w==;EndpointSuffix=core.windows.net",
                "sensorlogcheckpoint");

            var eventHubsConnectionString = "Endpoint=sb://eventhubcourse.servicebus.windows.net/;SharedAccessKeyName=sensorloglistener;SharedAccessKey=JSmXqQYhecKPZIIZgqYUvMQaxFPozmBEwLj4YyJw9+s=";
            var eventHubName = "sensordata";

            var processor = new EventProcessorClient(storageClient,consumerGroup,eventHubsConnectionString,eventHubName);

            processor.ProcessEventAsync += HandleEventProcessing;
            processor.ProcessErrorAsync += HandleEventError;

            try
            {
                await processor.StartProcessingAsync(cToken);
                await Task.Delay(Timeout.Infinite, cToken);
            }
            catch
            {
                //log errors
            }
            finally
            {
                await processor.StopProcessingAsync();
                processor.ProcessEventAsync -= HandleEventProcessing;
                processor.ProcessErrorAsync -= HandleEventError;
            }

        }
        async Task HandleEventProcessing(ProcessEventArgs args)
        {
            try
            {
                if (args.CancellationToken.IsCancellationRequested)
                {
                    return;
                }

                string partition = args.Partition.PartitionId;
                byte[] eventBody = args.Data.EventBody.ToArray();

               
               
                int eventsSinceLastCheckpoint = partitionEventCount.AddOrUpdate(
                   key: partition,
                   addValue: 1,
                   updateValueFactory: (_, currentCount) => currentCount + 1);
                Console.WriteLine($"Events since last checkpoint: {eventsSinceLastCheckpoint}");
                await args.UpdateCheckpointAsync();

            }
            catch
            {

            }
        }

        Task HandleEventError(ProcessErrorEventArgs args)
        {
            Console.WriteLine("Error in the EventProcessorClient");
            Console.WriteLine($"\tOperation: { args.Operation }");
            Console.WriteLine($"\tException: { args.Exception }");
            Console.WriteLine("");
            return Task.CompletedTask;
        }
    }
}
