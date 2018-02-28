using System;
using System.Text;
using System.Windows.Media;

namespace DALT.ITG.Shared.Utilities
{
    // The end result of every conversion in this class should be in the order A-R-G-B
    // I'm taking this as the "default" order for working with things
    // Hence, converting something from BGR -> int -> bytes will display the bytes in R-G-B order
    // Also, converting from RGB -> int -> bytes would display them in R-G-B order
    public static class ColorUtilities
    {
        /// <summary>
        /// Hex string lookup table.
        /// </summary>
        /// <source>
        /// http://blogs.msdn.com/b/blambert/archive/2009/02/22/blambert-codesnip-fast-byte-array-to-hex-string-conversion.aspx
        /// </source>
        private static readonly string[] HexStringTable = new string[]
        {
            "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D", "0E", "0F",
            "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "1A", "1B", "1C", "1D", "1E", "1F",
            "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "2A", "2B", "2C", "2D", "2E", "2F",
            "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "3A", "3B", "3C", "3D", "3E", "3F",
            "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F",
            "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5A", "5B", "5C", "5D", "5E", "5F",
            "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "6A", "6B", "6C", "6D", "6E", "6F",
            "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "7A", "7B", "7C", "7D", "7E", "7F",
            "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "8A", "8B", "8C", "8D", "8E", "8F",
            "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "9A", "9B", "9C", "9D", "9E", "9F",
            "A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "AA", "AB", "AC", "AD", "AE", "AF",
            "B0", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "BA", "BB", "BC", "BD", "BE", "BF",
            "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "CA", "CB", "CC", "CD", "CE", "CF",
            "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "DA", "DB", "DC", "DD", "DE", "DF",
            "E0", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "EA", "EB", "EC", "ED", "EE", "EF",
            "F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "FA", "FB", "FC", "FD", "FE", "FF"
        };

        #region BYTE[] CONVERTERS

        // byte[] --> hex string (works for both ARGB and RGB)
        public static string ToHex(this byte[] bytes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (bytes != null)
            {
                foreach (byte b in bytes)
                {
                    stringBuilder.Append(HexStringTable[b]);
                }
            }

            return stringBuilder.ToString();
        }

        // byte[] --> int (ARGB)
        public static int ARGBToInt(this byte[] bytes)
        {
            // PROBLEM: testBytes = {255, 255, 255, 128 }
            // When repeatedly run, result alternates between -128 and -2130706433
            // There is no integer overflow when checked()

            if (bytes.Length != 4) // invalid array size
                throw new ArgumentException("Requires a 4-byte array; actual length was " + bytes.Length.ToString());
            
            int result = 0;

            try
            {
                if (BitConverter.IsLittleEndian)
                    bytes.ReverseByteOrder();
                // should raise an exception if there is integer overflow
                result = checked(BitConverter.ToInt32(bytes, 0));
            }

            catch (System.OverflowException e)
            {
                Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
            }

            return result;
        }

        #endregion


        #region HEX STRING CONVERTERS

        // hex string --> int(BGR) (works for both ARGB and RGB)
        public static int ToIntBGR(this string hex)
        {
            string hexArgb, hexA, hexR, hexG, hexB;
            if (hex.Length < 6 || hex.Length == 7 || hex.Length > 8)
                throw new ArgumentException("Hex string must be 6 or 8 characters long (AaRrGgBb or RrGgBb).");

            if (hex.Length == 6)
                hexArgb = "FF" + hex;
            else // hex.Length == 8
                hexArgb = hex;

            // Parse the hex string
            hexA = hexArgb.Substring(0, 2);
            hexR = hexArgb.Substring(2, 2);
            hexG = hexArgb.Substring(4, 2);
            hexB = hexArgb.Substring(6, 2);

            // Reverse the order to BGR and discard alpha channel
            string hexBGR = hexB + hexG + hexR;

            // Convert to an integer
            int result = int.Parse(hexBGR, System.Globalization.NumberStyles.HexNumber);
            return result;
        }

        // hex string --> int(ARGB)
        public static int ToIntARGB(this string hex)
        {
            if (hex.Length != 8)
                throw new ArgumentException("Hex string must be 8 characters long (ARGB format).");
            else
            {
                int result = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                return result;
            }
        }

        // hex string --> int(RGB)
        public static int ToIntRGB(this string hex)
        {
            if (hex.Length != 6)
                throw new ArgumentException("Hex string must be 6 characters long (RGB format).");
            else
            {
                int result = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                return result;
            }
        }

        // hex string --> byte[] (works for both ARGB and RGB)
        public static byte[] ToBytes(this string hex)
        {
            // Works with both 6 and 8 char hex strings, returning 3 or 4 bytes respectively
            byte[] bytes = new byte[hex.Length / 2];

            int[] hexValue = new int[] { 
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < hex.Length; i += 2, x += 1)
            {
                bytes[x] = (byte)(hexValue[Char.ToUpper(hex[i + 0]) - '0'] << 4 |
                                 hexValue[Char.ToUpper(hex[i + 1]) - '0']);
            }

            return bytes;
        }

        #endregion


        #region INTEGER CONVERTERS

        // int(BGR) --> hex string
        public static string BGRToHex(this int value)
        {
            byte[] bytes = BGRToBytes(value);
            return bytes.ToHex();
        }

        // int(ARGB) --> hex string
        public static string ARGBToHex(this int value)
        {
            byte[] bytes = ARGBToBytes(value);
            return bytes.ToHex();
        }

        // int(BGR) --> byte[]
        public static byte[] BGRToBytes(this int value)
        {
            byte[] bytes = BitConverter.GetBytes(value); // returns { R, G, B, 0 }
            byte[] result = bytes.ExtractSubset(0, 3);
            return result;
        }

        // int(RGB) --> byte[]
        public static byte[] RGBToBytes(this int value)
        {
            byte[] bytes = BitConverter.GetBytes(value); // returns { B, G, R, 0 }
            byte[] result = bytes.ExtractSubset(0, 3); // returns { B, G, R }
            if (BitConverter.IsLittleEndian)
                result.ReverseByteOrder(); // returns { R, G, B }
            return result;
        }

        // int(ARGB) --> byte[]
        public static byte[] ARGBToBytes(this int value)
        {
            byte[] result = BitConverter.GetBytes(value); // returns { B, G, R, A }
            if (BitConverter.IsLittleEndian) // need to reverse the array
                result.ReverseByteOrder(); // returns { A, R, G, B }
            return result;
        }

        // int(BGR) --> SolidColorBrush
        public static SolidColorBrush BGRToSolidColorBrush(this int value)
        {
            byte[] RGB = value.BGRToBytes();
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromRgb(RGB[0], RGB[1], RGB[2]);
            return brush;
        }

        #endregion


        #region COLOR/BRUSH CONVERTERS

        // SolidColorBrush --> int(BGR)
        public static int ToIntBGR(this SolidColorBrush brush)
        {
            return brush.ToHex().ToIntBGR();
        }

        // SolidColorBrush --> hex string
        public static string ToHex(this SolidColorBrush brush)
        {
            return brush.ToString().Substring(1); // returns AARRGGBB
        }

        // Color --> int(BGR)
        public static int ToIntBGR(this Color color)
        {
            return color.ToHex().ToIntBGR();
        }

        // Color --> hex string
        public static string ToHex(this Color color)
        {
            byte[] ARGB = { color.A, color.R, color.B, color.G };
            return ARGB.ToHex();
        }

        #endregion
    }
}
