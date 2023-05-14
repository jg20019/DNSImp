using System.Text;

namespace DNSImp
{
    public class DNSQuery
    {
        private string DomainName { get; set; }

        public DNSQuery(string domainName)
        {
            DomainName = domainName; 
        }

        public byte[] Encode()
        {
            var bytes = new List<byte>();
            foreach(var part in DomainName.Split("."))
            {
                bytes.AddRange(BitUtils.GetBytes((ushort)part.Length));
                bytes.AddRange(BitUtils.GetBytes(part));
            }
            bytes.AddRange(BitUtils.GetBytes((ushort)0));
            return bytes.ToArray();
        }
    }
}
