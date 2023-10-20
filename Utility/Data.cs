using System.Net;

namespace Utility
{
    public static class Data
    {
        public const short Port = 6116;
        public const string Host = "127.0.0.1";
        public static readonly IPAddress HostIP = IPAddress.Parse(Host);
        public static readonly IPEndPoint IPEndPoint = new(HostIP, Port);
    }
}