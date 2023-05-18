﻿using DNSImp;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Sockets;

var query = DNSQuery.BuildQuery("www.example.com", DNSQuery.TYPE_A);

UdpClient udpClient = new UdpClient();
IPEndPoint ep = new IPEndPoint(IPAddress.Parse("8.8.8.8"), 53);
udpClient.Connect(ep);
udpClient.Send(query);
var response = udpClient.Receive(ref ep);

using (var stream = new MemoryStream(response))
{
    using (var reader = new BinaryReader(stream))
    {
        var header = DNSHeader.FromReader(reader);
        var question = DNSQuestion.FromReader(reader);
        var record = DNSRecord.FromReader(reader);
    }
}


Console.WriteLine("Press any key to continue...");
Console.ReadKey();