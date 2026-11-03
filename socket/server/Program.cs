using System.Net.Sockets;

const int Port = 12345;

Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
socket.Listen(5);
System.Console.WriteLine($"Server listening on port {Port}");
while (true) {
    Socket client = socket.Accept();
    System.Console.WriteLine("Client connected");

    NetworkStream ns = new NetworkStream(client);
    StreamReader rd = new StreamReader(ns);

    string? line = rd.ReadLine();
    System.Console.WriteLine($"Received message: {line}");

    client.Shutdown(SocketShutdown.Both);
    client.Close();
}

// socket.Close();