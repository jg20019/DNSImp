using DNSImp;
using System.Net;
using System.Net.Sockets;

// var query = DNSQuery.BuildQuery("www.example.com", DNSQuery.TYPE_A);
// Console.WriteLine(Convert.ToHexString(query));

// Hex String representing a proper query
// This was done to test that the DNS code below is working correctly. 
// Verified that I get a correct response in Wireshark
var query = "82980100000100000000000003777777076578616d706c6503636f6d0000010001";
UdpClient udpClient = new UdpClient();
IPEndPoint ep = new IPEndPoint(IPAddress.Parse("8.8.8.8"), 53);
udpClient.Connect(ep);
udpClient.Send(Convert.FromHexString(query));
var response = udpClient.Receive(ref ep);
Console.WriteLine(Convert.ToHexString(response));
Console.Write("receive data from " + ep.ToString());
Console.WriteLine();

Console.ReadKey();