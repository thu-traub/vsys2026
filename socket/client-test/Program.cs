using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
const int Port = 12345;
const int N = 50;

Stopwatch sw = Stopwatch.StartNew();
List<Thread> threads = new List<Thread>();
int[] reqtime = new int[N];
for (int i = 0; i < N; i++)
{
    Int32 iteration = i;
    Thread t = new Thread(() => 
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //System.Console.WriteLine($"Connecting to server, iteration {iteration}");
        socket.Connect("127.0.0.1", Port);
        //System.Console.WriteLine($"Connected to server, iteration {iteration}");
        NetworkStream stream = new NetworkStream(socket);
        StreamWriter writer = new StreamWriter(stream);
        StreamReader reader = new StreamReader(stream);
        Stopwatch reqSw = Stopwatch.StartNew();
        writer.WriteLine("time");
        writer.Flush();
        string? response = reader.ReadLine();
        reqSw.Stop();
        reqtime[iteration] = (int)reqSw.ElapsedMilliseconds;
        //System.Console.WriteLine($"Server response: {response}");
        reader.Close();
        writer.Close();
        stream.Close();
        socket.Close();
    });
    threads.Add(t);
    t.Start();
}

threads.ForEach(t => t.Join());
sw.Stop();
System.Console.WriteLine($"Total time: {sw.ElapsedMilliseconds} ms");
System.Console.WriteLine($"Request times: {string.Join(", ", reqtime)}");
