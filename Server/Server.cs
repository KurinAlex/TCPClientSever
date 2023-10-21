using System.Net.Sockets;

using Utility;

var listener = new TcpListener(Data.IPEndPoint);

try
{
    listener.Start(16);
    Console.WriteLine("Server started, listening for connections...");
    while (true)
    {
        await ProcessClient();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    listener.Stop();
}

async Task ProcessClient()
{
    try
    {
        using TcpClient client = await listener.AcceptTcpClientAsync();
        using NetworkStream stream = client.GetStream();
        using var reader = new StreamReader(stream);
        using var writer = new StreamWriter(stream);

        string? name = await reader.ReadLineAsync();
        Console.WriteLine($"{name} joined the server");

        await writer.WriteLineAsync($"Welcome to the server, {name}");
        await writer.FlushAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}