using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSImp
{
    public class DNSQuestion
    {
        private byte[] Name { get; set; }
        private ushort Type { get ; set; }
        private ushort Class { get; set; }

        public DNSQuestion(byte[] name, ushort type, ushort @class)
        {
            Name = name;
            Type = type;
            Class = @class;
        }

        public byte[] ToBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Name);
            bytes.AddRange(BitUtils.GetBytes(Type));
            bytes.AddRange(BitUtils.GetBytes(Class));
            return bytes.ToArray();
        }
    }
}
