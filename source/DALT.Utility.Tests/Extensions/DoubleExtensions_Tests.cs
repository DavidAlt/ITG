using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALT.Utility.Tests.Extensions
{
    using NUnit.Framework;
    using FluentAssertions;
    using DALT.Utility.Extensions;

    [TestFixture]
    public class DoubleExtensions_Tests
    {
        //[TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        //[TestCase(6)]
        public void Constrain_IgnoresValues_InsideConstraints(double before)
        {
            double after;
            double min = 1;
            double max = 5;

            after = before.Constrain(min, max);

            Assert.AreEqual(before, after);
        }

        [TestCase(0)]
        //[TestCase(1)]
        //[TestCase(3)]
        //[TestCase(5)]
        [TestCase(6)]
        public void Constrain_ChangesValues_OutsideConstraints(double before)
        {
            double after;
            double min = 1;
            double max = 5;

            after = before.Constrain(min, max);

            Assert.AreNotEqual(before, after);
        }
        
    }
}
