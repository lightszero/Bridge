using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring unicode escaped characters matches
    /// their integer equivalents/cast as in native .NET.
    /// </summary>
    [TestFixture(TestNameFormat = "#3902 - {0}")]
    public class Bridge3902
    {
        /// <summary>
        /// Tests some char escapes against their expected integer values.
        /// </summary>
        [Test]
        public static void TestUnicodeEscapes()
        {
            string s = "\ud8a1\ud8a2\ue681";
            Assert.AreEqual(55457, (int)s[0], "Unicode U+D8A1 matches integer 55457.");
            Assert.AreEqual(55458, (int)s[1], "Unicode U+D8A2 matches integer 55458.");
            Assert.AreEqual(59009, (int)s[2], "Unicode U+E681 matches integer 59007.");
        }
    }
}