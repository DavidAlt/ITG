using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALT.ITG.Models;

namespace DALT.ITG.Tests
{
    using NUnit.Framework;
    // initialize any test objects you need
    // execute the method you want to test
    // check the state of your test objects

    [TestFixture]
    public class ItemDataTests
    {
        [Test]
        public void FontOptionAcceptsString()
        {
            FontOption option = new FontOption("Arial");
            Assert.IsInstanceOf<string>(option.Value);
        }

        [Test]
        public void FontOptionReturnsSameString()
        {
            FontOption option = new FontOption("Arial");
            string actual = option.Value;
            string expected = "Arial";
            Assert.AreEqual(expected, actual);
        }

    }
}
