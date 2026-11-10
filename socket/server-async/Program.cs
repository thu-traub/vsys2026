using System.Net.Sockets;

const int Port = 12345;

run();
Console.ReadLine();

async void run()
{
    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
    socket.Listen(100);
    System.Console.WriteLine($"Server listening on port {Port}");
    while (true) {
        Socket client = await socket.AcceptAsync();
        _ = HandleClient(client);
    }
}

async Task HandleClient(Socket client)
{
    NetworkStream ns = new NetworkStream(client);
    StreamReader rd = new StreamReader(ns);
    StreamWriter wr = new StreamWriter(ns);

    string? line = await rd.ReadLineAsync();
    switch (line)
    {
        case "hello":
            System.Console.WriteLine("Client said hello "+line);
            break;
        case "time":
            //System.Console.WriteLine("Client asked for time "+line);
            await Task.Delay(1000);
            await wr.WriteLineAsync(DateTime.Now.ToString());
            await wr.FlushAsync();
            //System.Console.WriteLine("Sent current time to client");
            break;
        default:
            System.Console.WriteLine("Unknown message");
            break;
    }
    //System.Console.WriteLine($"Received message: {line}");

    client.Shutdown(SocketShutdown.Both);
    client.Close();
    
}
// socket.Close();