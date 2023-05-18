using DNSImp;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Sockets;

var query = DNSQuery.BuildQuery("www.example.com", DNSQuery.TYPE_A);
//var query = Convert.FromHexString("82980100000100000000000003777777076578616d706c6503636f6d0000010001");

UdpClient udpClient = new UdpClient();
IPEndPoint ep = new IPEndPoint(IPAddress.Parse("8.8.8.8"), 53);
udpClient.Connect(ep);
udpClient.Send(query);
var response = udpClient.Receive(ref ep);
Console.WriteLine(Convert.ToHexString(response));
Console.Write("receive data from " + ep.ToString());
var stream = new MemoryStream(response);
var reader = new BinaryReader(stream);
var header = DNSHeader.FromReader(reader);
Console.WriteLine();
Console.WriteLine("Press any key to continue...");
Console.ReadKey();