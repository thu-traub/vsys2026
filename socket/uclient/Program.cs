using System.Net.Sockets;

const int Port = 12345;
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
byte[] message = System.Text.Encoding.UTF8.GetBytes("hello from windows");
socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
socket.SendTo(message, new System.Net.IPEndPoint(System.Net.IPAddress.Broadcast, Port));
socket.Close();
