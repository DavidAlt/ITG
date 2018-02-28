using System;
using System.Text;

namespace DALT.ITG.Shared.Utilities
{
    public static class ByteArrayUtilities
    {
        // specifically for byte arrays
        public static string Print(this byte[] values)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < values.Length - 1; i++)
            {
                sb.Append(values[i].ToString() + " ");
            }
            sb.Append(values[values.Length - 1].ToString());
            return sb.ToString();
        }

        public static byte[] ReverseByteOrder(this byte[] bytes)
        {
            Array.Reverse(bytes);
            return bytes;
        }
    }
}
