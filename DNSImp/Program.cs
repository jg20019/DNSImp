using DNSImp;

// From the example in Part 1
var header = new DNSHeader(0x1314, 0, 1, 0, 0, 0);
var bytes = header.ToBytes();
for(int i = 0; i < bytes.Length; i++)
{
    Console.Write($"\\x{bytes[i]:x2}");
}
Console.WriteLine();

// Is this how I encode byte strings? 
bytes = BitUtils.GetBytes("hello");
for (int i = 0; i < bytes.Length; i++)
{
    // Or is the x prefix needed? 
    Console.Write($"\\x{bytes[i]:x2}");
}

Console.WriteLine();
Console.ReadKey();