using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DALT.Utility.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ColorHelperTests
    {
        // common test data
        byte[] testBytesBGR = { 128, 255, 255 };
        byte[] testBytesRGB = { 255, 255, 128 };
        byte[] testBytesARGB = { 255, 255, 255, 128 };

        string testHexRGB = "FFFF80";
        string testHexARGB = "FFFFFF80";

        int testIntBGR = 8454143;
        int testIntRGB = 16777088;
        int testIntARGB = -128; // on repeat conversion comes out as -2130706433


        // performed once before all tests
        [TestFixtureSetUp] protected void InitFixture()
        { }

        // performed once after all tests
        [TestFixtureTearDown] protected void CleanUpFixture()
        { }

        // performed before each test
        [SetUp] protected void InitTest()
        { }

        // performed after each test
        [TearDown] protected void CleanUpTest()
        { }


        public class HexStringConverterTests : ColorHelperTests
        {
            public class ToIntBGRMethod : HexStringConverterTests
            {
                [Test] // must return void and have no parameters
                public void ProperTest()
                {
                    // initialize any test objects you need
                    string one = "one";
                    string onetwo = "onetwo";

                    // execute the method you want to test
                    string onetwoMod = onetwo.Substring(0,3);

                    // check the state of your test objects
                    Assert.AreEqual(one, onetwo);
                }

                [TestCase("same", "same", Result=true)]
                [TestCase("same", "different", Result=true)]
                [TestCase("same", "different", Result=false)]
                public bool TestMe(string first, string second)
                {
                    return (first == second);
                }
            }


        }


    }
}
