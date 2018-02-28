using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALT.Utility;
using DALT.Utility.Extensions;

namespace ColorTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // TEST DATA
            byte[] testBytesBGR = { 128, 255, 255 };
            byte[] testBytesRGB = { 255, 255, 128 };
            byte[] testBytesARGB = { 255, 255, 255, 128 };
            
            string testHexRGB = "FFFF80";
            string testHexARGB = "FFFFFF80";
            
            int testIntBGR = 8454143;
            int testIntRGB = 16777088;
            int testIntARGB = -128; // on repeat conversion comes out as -2130706433

            double dLower = 1;
            double dHigher = 7;
            double dMid = 4;
            double dMin = 3;
            double dMax = 5;

            Console.WriteLine("Constrain mid: {0}", dMid.Constrain(dMin, dMax));
            Console.WriteLine("Constrain lower: {0}", dLower.Constrain(dMin, dMax));
            Console.WriteLine("Constrain higher: {0}", dHigher.Constrain(dMin, dMax));

            /*
            // bytes.ToHex --> works
            Console.WriteLine("bytesToHex(RGB) 1: {0}", testBytesRGB.ToHex());
            Console.WriteLine("bytesToHex(RGB) 2: {0}", testBytesRGB.ToHex());
            Console.WriteLine("bytesToHex(ARGB) 1: {0}", testBytesARGB.ToHex());
            Console.WriteLine("bytesToHex(ARGB) 2: {0}", testBytesARGB.ToHex());
            Console.WriteLine();

            // bytes.ToInt --> CONSISTENT BUT ODD RESULTS
            Console.WriteLine("bytesToInt(ARGB) 1: {0}", testBytesARGB.ARGBToInt().ToString());
            Console.WriteLine("bytesToInt(ARGB) 2: {0}", testBytesARGB.ARGBToInt().ToString());
            Console.WriteLine("bytesToInt(ARGB) 3: {0}", testBytesARGB.ARGBToInt().ToString());
            Console.WriteLine("bytesToInt(ARGB) 4: {0}", testBytesARGB.ARGBToInt().ToString());
            Console.WriteLine("bytesToInt(BGR): {0}", testBytesBGR.ARGBToInt().ToString());
            Console.WriteLine();


            // hex.ToIntBGR --> works
            Console.WriteLine("hexToIntBGR (RGB) 1: {0}", testHexRGB.ToIntBGR());
            Console.WriteLine("hexToIntBGR (RGB) 2: {0}", testHexRGB.ToIntBGR());
            Console.WriteLine("hexToIntBGR (ARGB) 1: {0}", testHexARGB.ToIntBGR());
            Console.WriteLine("hexToIntBGR (ARGB) 2: {0}", testHexARGB.ToIntBGR());
            Console.WriteLine();
            Console.WriteLine("hexToIntRGB (RGB) 1: {0}", testHexRGB.ToIntRGB());
            Console.WriteLine("hexToIntRGB (RGB) 2: {0}", testHexRGB.ToIntRGB());
            Console.WriteLine("hexToIntARGB (ARGB) 1: {0}", testHexARGB.ToIntARGB());
            Console.WriteLine("hexToIntARGB (ARGB) 2: {0}", testHexARGB.ToIntARGB());
            Console.WriteLine();

            // hex.ToBytes --> works
            Console.WriteLine("hexToBytes(RGB) 1: {0}", testHexRGB.ToBytes().Print());
            Console.WriteLine("hexToBytes(RGB) 2: {0}", testHexRGB.ToBytes().Print());
            Console.WriteLine("hexToBytes(ARGB) 1: {0}", testHexARGB.ToBytes().Print());
            Console.WriteLine("hexToBytes(ARGB) 2: {0}", testHexARGB.ToBytes().Print());
            Console.WriteLine();


            // int.ToHex --> works
            Console.WriteLine("intToHex(BGR) 1: {0}", testIntBGR.BGRToHex());
            Console.WriteLine("intToHex(BGR) 2: {0}", testIntBGR.BGRToHex());
            Console.WriteLine("intToHex(ARGB) 1: {0}", testIntARGB.ARGBToHex());
            Console.WriteLine("intToHex(ARGB) 2: {0}", testIntARGB.ARGBToHex());
            Console.WriteLine();

            // int.ToBytes --> works
            Console.WriteLine("intToBytes(RGB) 1: {0}", testIntRGB.RGBToBytes().Print());
            Console.WriteLine("intToBytes(RGB) 2: {0}", testIntRGB.RGBToBytes().Print());
            Console.WriteLine("intToBytes(ARGB) 1: {0}", testIntARGB.ARGBToBytes().Print());
            Console.WriteLine("intToBytes(ARGB) 2: {0}", testIntARGB.ARGBToBytes().Print());
            Console.WriteLine("intToBytes(BGR) 1: {0}", testIntBGR.BGRToBytes().Print());
            Console.WriteLine("intToBytes(BGR) 2: {0}", testIntBGR.BGRToBytes().Print());
            Console.WriteLine();

             */

            Console.ReadKey();
        }
    }
}
