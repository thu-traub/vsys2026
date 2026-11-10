using Azure.Identity;
using Azure.Storage.Queues;

var queueUri = new Uri("https://thuifistvsys.queue.core.windows.net/demo");

var credential = new AzureCliCredential();
var client = new QueueClient(queueUri, credential);
await client.SendMessageAsync("hello from windows");
Console.WriteLine("Message sent to the queue.");