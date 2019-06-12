using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Ensures Math.Sign works with infinity
    /// </summary>
    [TestFixture(TestNameFormat = "#3900 - {0}")]
    public class Bridge3900
    {
        /// <summary>
        /// Checks whether the result matches native .NET.
        /// </summary>
        [Test]
        public static void TestInfinitySign()
        {
            Assert.AreEqual(1, Math.Sign(Double.PositiveInfinity), "Math.Sign(Double.PositiveInfinity) is 1");
            Assert.AreEqual(-1, Math.Sign(Double.NegativeInfinity), "Math.Sign(Double.NegativeInfinity) is -1");
            Assert.AreEqual(1, Math.Sign(float.PositiveInfinity), "Math.Sign(float.PositiveInfinity) is 1");
            Assert.AreEqual(-1, Math.Sign(float.NegativeInfinity), "Math.Sign(float.NegativeInfinity) is -1");
        }
    }
}