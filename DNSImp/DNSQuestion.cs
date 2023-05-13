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
            return BitUtils.GetBytes(Name)
                .Concat(BitUtils.GetBytes(Type))
                .Concat(BitUtils.GetBytes(Class))
                .ToArray();
        }
    }
}
