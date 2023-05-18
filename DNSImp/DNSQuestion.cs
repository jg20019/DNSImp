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

        public DNSQuestion(string name, ushort type, ushort @class) 
            : this(Encoding.ASCII.GetBytes(name), type, @class)
        {}

        public static string DecodeNameSimple(BinaryReader reader)
        {
            var length = (int)reader.ReadByte();
            var parts = new List<string>();
            var sb = new StringBuilder();
            while (length != 0)
            {
                parts.Add(Encoding.ASCII.GetString(reader.ReadBytes(length)));
                length = (int)reader.ReadByte();
            }

            return sb.AppendJoin(".", parts.ToArray()).ToString();
        }
        public static DNSQuestion FromReader(BinaryReader reader)
        {
            var name = DecodeNameSimple(reader);
            var type = BitUtils.ToUInt16(reader.ReadBytes(2));
            var class_ = BitUtils.ToUInt16(reader.ReadBytes(2));
            return new DNSQuestion(name, type, class_);
            
        }

        public byte[] ToBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Name);
            bytes.AddRange(BitUtils.GetBytes(Type));
            bytes.AddRange(BitUtils.GetBytes(Class));
            return bytes.ToArray();
        }

        public override string ToString()
        {
            var name = Encoding.ASCII.GetString(Name);
            return $"DNSQuestion(name={name}, type={Type}, class={Class})";
        }
    }
}
