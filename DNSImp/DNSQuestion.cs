using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSImp
{
    public class DNSQuestion
    {
        private string Name { get; set; }
        private ushort Type { get ; set; }
        private ushort Class { get; set; }

        public DNSQuestion(string name, ushort type, ushort @class)
        {
            Name = name;
            Type = type;
            Class = @class;
        }

        public byte[] ToBytes()
        {
            var builder = new StringBuilder();
            var bytes = new List<byte>();
            bytes.AddRange(BitUtils.GetBytes(Name));
            bytes.AddRange(BitUtils.GetBytes(Type));
            bytes.AddRange(BitUtils.GetBytes(Class));
            return bytes.ToArray();
        }
    }
}
