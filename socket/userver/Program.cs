using System.Net;
using System.Net.Sockets;

const int Port = 12345;

Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, Port));
System.Console.WriteLine($"Server listening on port {Port}");

while (true) {
    byte[] buffer = new byte[1024];
    EndPoint clientEndPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);
    int received = socket.ReceiveFrom(buffer, ref clientEndPoint);
    string line = System.Text.Encoding.UTF8.GetString(buffer, 0, received);
    System.Console.WriteLine($"Received message: {line}");
}

// socket.Close();