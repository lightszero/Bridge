using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures conversion to hex values using ToString('X')
    /// format (or 'x') works for negative values on different non-floating
    /// point types.
    /// </summary>
    [TestFixture(TestNameFormat = "#3901 - {0}")]
    public class Bridge3901
    {
        /// <summary>
        /// Tests the hex number conversion for different types on their
        /// negative values.
        /// </summary>
        [Test]
        public static void TestToHexString()
        {
            sbyte b = -1;
            Assert.AreEqual("FF", b.ToString("X"), "Negative signed byte to string format 'X' works.");

            Int16 i16 = -1;
            Assert.AreEqual("FFFF", i16.ToString("X"), "Negative Int16 to string format 'X' works.");

            Int32 i32 = -1;
            Assert.AreEqual("FFFFFFFF", i32.ToString("X"), "Negative Int32 to string format 'X' works.");

            Int64 i64 = -1;
            Assert.AreEqual("FFFFFFFFFFFFFFFF", i64.ToString("X"), "Negative Int32 to string format 'X' works.");

            int i = -423433;
            Assert.AreEqual("fff989f7", i.ToString("x"), "Negative int to string format 'x' works.");
            Assert.AreEqual("FFF989F7", i.ToString("X"), "Negative int to string format 'X' works, and matches Int32 length.");
        }
    }
}