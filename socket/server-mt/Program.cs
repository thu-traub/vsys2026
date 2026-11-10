using System.Net.Sockets;

const int Port = 12345;

Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
socket.Listen(100);
System.Console.WriteLine($"Server listening on port {Port}");
while (true) {
    Socket client = socket.Accept();
    //System.Console.WriteLine("Client connected");
    new System.Threading.Thread(() => HandleClient(client)).Start();
    //HandleClient(client);
}

void HandleClient(Socket client)
{
    NetworkStream ns = new NetworkStream(client);
    StreamReader rd = new StreamReader(ns);
    StreamWriter wr = new StreamWriter(ns);

    string? line = rd.ReadLine();
    switch (line)
    {
        case "hello":
            System.Console.WriteLine("Client said hello "+line);
            break;
        case "time":
            //System.Console.WriteLine("Client asked for time "+line);
            Thread.Sleep(100);
            wr.WriteLine(DateTime.Now);
            wr.Flush();
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