

using EventConsumerClient;

var processor = new EventProcessor();
await processor.StartEventProcessing(CancellationToken.None);
Console.WriteLine("Hello, World!");
