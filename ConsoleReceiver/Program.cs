using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient(24000);
IPEndPoint? endPoint = null;

Console.WriteLine("Started");
while (true)
{
    var data = client.Receive(ref endPoint);
    Console.WriteLine(Encoding.ASCII.GetString(data));
}