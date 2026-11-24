using System.Net.Security;
using System.Net.Sockets;

const int Port = 12345;
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Connect("localhost", Port);
NetworkStream stream = new NetworkStream(socket);
SslStream ssl = new SslStream(stream);
ssl.AuthenticateAsClient("localhost");
StreamWriter writer = new StreamWriter(ssl);
StreamReader reader = new StreamReader(ssl);
writer.WriteLine("time");
writer.Flush();
string? response = reader.ReadLine();
System.Console.WriteLine($"Server response: {response}");
reader.Close();
writer.Close();
stream.Close();
socket.Close();
