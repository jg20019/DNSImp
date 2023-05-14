using System;
using System.Security.Cryptography;
using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DNSImp
{
    public class DNSHeader
    {
        // I made these ushorts because in the Python code when it encodes
        // the header it uses the capital H format which from the docs means
        // it should be a ushort: https://docs.python.org/3/library/struct.html#format-characters
        private ushort ID { get; set; }
        private ushort Flags { get; set; }
        private ushort NumQuestions { get; set; }
        private ushort NumAnswers { get; set; }
        private ushort NumAuthorities { get; set; }
        private ushort NumAdditionals { get; set; }

        public DNSHeader(ushort id, ushort flags, ushort numQuestions = 0, ushort numAnswers = 0, ushort numAuthorities = 0, ushort numAdditionals = 0)
        {
            this.ID = id;
            this.Flags = flags;
            this.NumQuestions = numQuestions;
            this.NumAnswers = numAnswers;
            this.NumAuthorities = numAuthorities;
            this.NumAdditionals = numAdditionals;
        }

        public byte[] ToBytes()
        {
            var bytes = new List<byte>();
            bytes.AddRange(BitUtils.GetBytes(ID));
            bytes.AddRange(BitUtils.GetBytes(this.Flags));
            bytes.AddRange(BitUtils.GetBytes(this.NumQuestions));
            bytes.AddRange(BitUtils.GetBytes(this.NumAnswers));
            bytes.AddRange(BitUtils.GetBytes(this.NumAuthorities));
            bytes.AddRange(BitUtils.GetBytes(this.NumAdditionals));
            return bytes.ToArray();
        }
    }
}
