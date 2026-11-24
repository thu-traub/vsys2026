using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

const int Port = 12345;

X509Certificate2 crt = new X509Certificate2(@"server.pfx", Environment.GetEnvironmentVariable("CERT_PASSWORD"));
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
socket.Listen(5);
System.Console.WriteLine($"Server listening on port {Port}");
while (true) {
    Socket client = socket.Accept();
    System.Console.WriteLine("Client connected");

    NetworkStream ns = new NetworkStream(client);
    SslStream ssl = new SslStream(ns);
    ssl.AuthenticateAsServer(crt);
    StreamReader rd = new StreamReader(ssl);
    StreamWriter wr = new StreamWriter(ssl);

    string? line = rd.ReadLine();
    switch (line)
    {
        case "hello":
            System.Console.WriteLine("Client said hello "+line);
            break;
        case "time":
            System.Console.WriteLine("Client asked for time "+line);
            wr.WriteLine(DateTime.Now);
            wr.Flush();
            break;
        default:
            System.Console.WriteLine("Unknown message");
            break;
    }
    System.Console.WriteLine($"Received message: {line}");

    client.Shutdown(SocketShutdown.Both);
    client.Close();
}

// socket.Close();