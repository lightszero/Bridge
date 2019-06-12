using Bridge.Test.NUnit;
using System.Reflection;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The test here ensures a '-0.0' literal is treated as negative.
    /// </summary>
    [TestFixture(TestNameFormat = "#3898 - {0}")]
    public class Bridge3898
    {
        /// <summary>
        /// Ensures the zero literal is negative by the math 1/0 being negative
        /// infinity.
        /// </summary>
        [Test]
        public static void TestNegativeZero()
        {
            double negativezero = -0.0;
            Assert.True(double.IsNegativeInfinity(1 / negativezero), "1/(-0) is -∞.");
        }
    }
}