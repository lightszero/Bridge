using Bridge.Test.NUnit;
using System.Reflection;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring string values from the Decimal type
    /// are correct between conversions.
    /// </summary>
    [TestFixture(TestNameFormat = "#3887 - {0}")]
    public class Bridge3887
    {
        /// <summary>
        /// Tests various scenarios defining decimal constant numbers.
        /// </summary>
        [Test]
        public static void TestDecimalToString()
        {
            Assert.AreEqual("0", 0m.ToString(), "0m.ToString() is \"0\".");
            Assert.AreEqual("0.0", 0.0m.ToString(), "0.0m.ToString() is \"0.0\".");
            Assert.AreEqual("0.00", 0.00m.ToString(), "0.00m.ToString() is \"0.00\".");

            var d1 = 0.314m;
            var d2 = 0.0140m;
            Assert.AreEqual("0.3000", (d1 - d2).ToString(), "Subraction of 3 and 4 digits long decimal results in a 4-digit value.");

            d1 = 0.314m;
            d2 = 0.014m;
            Assert.AreEqual("0.300", (d1 - d2).ToString(), "Subtraction of two 3-digit-long decimal results in a 3-digit value.");

            d1 = 0.300m;
            d2 = 0.01m;
            Assert.AreEqual("0.310", (d1 + d2).ToString(), "Sum of 2 and 3 digits long decimal numbers results in a 3-digit value.");

            d1 = 0.06m;
            d2 = d1 / 4; // we don't care about the result here, we're checking if trailing zeroes are being cropped off the number.
            Assert.AreEqual("0.060", (d2 * 4).ToString(), "Multiplication of a 3-digitlong decimal numbers result in a 3-digit value.");
        }
    }
}