using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSImp
{
    internal class BitUtils
    {
        // Encode ushort data bytes in network order
        public static byte[] GetBytes(ushort data)
        {
            var bytes = BitConverter.GetBytes(data);
            if (BitConverter.IsLittleEndian)
            {
               Array.Reverse(bytes);
            }

            return bytes;
        }

        // Convert data to unsigned 16-bit int. Read the bytes in network order.
        // data should be a two byte array.
        public static ushort ToUInt16(byte[] data)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }
            return BitConverter.ToUInt16(data);
        }

        // Convert data to unsigned 32 bit int. Read the bytes in network order.
        // data should be a two byte array.
        public static uint ToUInt32(byte[] data)
        {
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }
            return BitConverter.ToUInt32(data);
        }

        // Encode string as bytes in Network Order
        public static byte[] GetBytes(string data)
        {
            var bytes = Encoding.ASCII.GetBytes(data);
            if (BitConverter.IsLittleEndian)
            {
               Array.Reverse(bytes);
            }
            return bytes;
        }

        public static void WriteBytes(byte[] bytes)
        {
            foreach(var b in bytes)
            {
                Console.Write($"{b:x2} "); 
            }
        }
    }
}
