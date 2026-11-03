using System.Net.Sockets;

const int Port = 12345;
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Connect("127.0.0.1", Port);
NetworkStream stream = new NetworkStream(socket);
StreamWriter writer = new StreamWriter(stream);
writer.WriteLine("Hello, server!");
writer.Flush();
writer.Close();
stream.Close();
socket.Close();
