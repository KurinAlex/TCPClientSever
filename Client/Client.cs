using System.Net.Sockets;

using Utility;

try
{
    Console.Write("Enter your name: ");
    string? name = Console.ReadLine();

    using var client = new TcpClient(Data.Host, Data.Port);
    using NetworkStream stream = client.GetStream();
    using var reader = new StreamReader(stream);
    using var writer = new StreamWriter(stream);

    writer.WriteLine(name);
    writer.Flush();

    string? answer = reader.ReadLine();
    Console.WriteLine(answer);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
