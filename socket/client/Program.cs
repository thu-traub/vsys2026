using System.Net.Sockets;

const int Port = 12345;
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Connect("vsys.dila.thu.de", Port);
NetworkStream stream = new NetworkStream(socket);
StreamWriter writer = new StreamWriter(stream);
StreamReader reader = new StreamReader(stream);
writer.WriteLine("hello from windows");
writer.Flush();
string? response = reader.ReadLine();
System.Console.WriteLine($"Server response: {response}");
reader.Close();
writer.Close();
stream.Close();
socket.Close();
