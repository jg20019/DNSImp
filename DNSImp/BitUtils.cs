using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSImp
{
    internal class BitUtils
    {
        // Encode ushort data bytes in Network Order
        public static byte[] GetBytes(ushort data)
        {
            var bytes = BitConverter.GetBytes(data);
            if (BitConverter.IsLittleEndian)
            {
                bytes = bytes.Reverse().ToArray();
            }

            return bytes;
        }

        // Encode string as bytes in Network Order
        public static byte[] GetBytes(string data)
        {
            var bytes = Encoding.ASCII.GetBytes(data);
            if (BitConverter.IsLittleEndian)
            {
                bytes = bytes.Reverse().ToArray();
            }
            return bytes;
        }
    }
}
