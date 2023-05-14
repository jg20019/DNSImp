using System.Runtime.CompilerServices;
using System.Text;

namespace DNSImp
{
    public static class DNSQuery
    {
        public static ushort TYPE_A = 1;
        public static ushort CLASS_IN = 1;
        public static byte[] EncodeDNSName(string domainName)
        {
            var bytes = new List<byte>();
            foreach(var part in domainName.Split('.'))
            {
                bytes.Add((byte)part.Length);
                bytes.AddRange(BitUtils.GetBytes(part));
            }
            bytes.AddRange(BitUtils.GetBytes((ushort)0));
            return bytes.ToArray();
        }

        public static byte[] BuildQuery(string domainName, ushort recordType)
        {
            var name = DNSQuery.EncodeDNSName(domainName);
            var rnd = new Random();
            var id = rnd.Next(0, 65535);
            var RECURSION_DESIRED = 1 << 8;
            var header = new DNSHeader((ushort) id, (ushort) RECURSION_DESIRED, numQuestions: 1);
            var question = new DNSQuestion(name, recordType, CLASS_IN);
            var bytes = new List<byte>();
            bytes.AddRange(header.ToBytes());
            bytes.AddRange(question.ToBytes());
            return bytes.ToArray();
        }
    }
}
