using Azure.Identity;
using Azure.Storage.Queues;

var queueUri = new Uri("https://thuifistvsys.queue.core.windows.net/demo");

var credential = new AzureCliCredential();
var client = new QueueClient(queueUri, credential);
var messages = await client.ReceiveMessagesAsync();
foreach (var message in messages.Value)
{
    Console.WriteLine($"Received message: {message.MessageText}");
    await client.DeleteMessageAsync(message.MessageId, message.PopReceipt);
}
Console.WriteLine("Finished processing messages.");