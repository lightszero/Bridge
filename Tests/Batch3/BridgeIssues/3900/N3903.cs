using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring the XOR result involving boolean
    /// values is sane and matches native .NET's.
    /// </summary>
    [TestFixture(TestNameFormat = "#3903 - {0}")]
    public class Bridge3903
    {
        /// <summary>
        /// Simply define some boolean values and subject them to XOR tests
        /// with the "^" (circumflex) operator.
        /// </summary>
        [Test]
        public static void TestBooleanXor()
        {
            var t = true;
            var f = false;
            var a = t ^ f;
            var b = t;
            b ^= t;

            Assert.True(a == true, "true ^ false evaluates to true.");
            Assert.True(b == false, "true ^= true gets assigned to false.");
        }
    }
}