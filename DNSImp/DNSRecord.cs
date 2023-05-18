using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSImp
{
    public class DNSRecord
    {
        private byte[] Name { get; set; }
        private ushort Type {  get; set; }
        private ushort Class { get; set; }

        private uint TTL { get; set; }

        private byte[] Data { get; set; }

        public DNSRecord(byte[] name, ushort type, ushort @class, uint tTL, byte[] data)
        {
            Name = name;
            Type = type;
            Class = @class;
            TTL = tTL;
            Data = data;
        }

        public static DNSRecord FromReader(BinaryReader reader)
        {
            var name = DNSQuestion.DecodeNameSimple(reader);
            var type = BitUtils.ToUInt16(reader.ReadBytes(2));
            var class_ = BitUtils.ToUInt16(reader.ReadBytes(2));
            var ttl = BitUtils.ToUInt32(reader.ReadBytes(4));
            var data_len = BitUtils.ToUInt16(reader.ReadBytes(2));
            var data = reader.ReadBytes(data_len);
            return new DNSRecord(Encoding.ASCII.GetBytes(name), type, class_, ttl, data);
        }
    }
}
