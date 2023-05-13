

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
            var encoded = new List<byte>();
            foreach(var part in DomainName.Split("."))
            {
                // Right now I am encoding the domain as one large byte array? 
                // Is this the same as the Python code or am I making things too complicated?
                var length = BitUtils.GetBytes((ushort)part.Length);
                var bytes = BitUtils.GetBytes(part);
                foreach(var b in length)
                {
                    encoded.Add(b);
                }
                foreach(var b in bytes)
                {
                    encoded.Add(b);
                }
            }
            return encoded.ToArray();
        }
    }
}
