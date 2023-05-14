using DNSImp;

// From the example in Part 1
var header = new DNSHeader(0x1314, 0, 1, 0, 0, 0);
var bytes = header.ToBytes();
BitUtils.WriteBytes(bytes);
Console.WriteLine();

var question = new DNSQuestion("IN", 0x12, 0x0);
BitUtils.WriteBytes(question.ToBytes());
Console.WriteLine();

var query = new DNSQuery("google.com");
BitUtils.WriteBytes(query.Encode());
Console.WriteLine();

Console.WriteLine(query.Encode()[1]);
Console.ReadKey();