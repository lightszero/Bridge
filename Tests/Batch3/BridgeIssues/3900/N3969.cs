using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Ensures char elements used as array indexes are consistently cast to
    /// integer indexes.
    /// </summary>
    [TestFixture(TestNameFormat = "#3969 - {0}")]
    public class Bridge3969
    {
        /// <summary>
        /// The test checks whether 'h' and (int)'h' indexes resolves to the
        /// same integer representation, thus the elements get replaced.
        /// </summary>
        [Test]
        public static void TestCharIndexer()
        {
            string[] testarr = new string[255];
            testarr['*'] = "works";
            testarr[(int)'h'] = "also works";
            testarr['h'] = "wait what?";

            Assert.AreEqual("works", testarr['*'], "Assigning array at integer position equivalent to the ASCII '*' character works.");
            Assert.AreEqual("works", testarr[(int)'*'], "Assigning array at integer position equivalent to the Int32 cast of the ASCII '*' character works.");

            Assert.AreEqual("wait what?", testarr[(int)'h'], "Assigning array at integer position equivalent to the ASCII 'h' 'character' works, replacing the previous assignment.");
            Assert.AreEqual("wait what?", testarr['h'], "Assigning array at integer position equivalent to the ASCII 'h' replaced its (int)'h' element.");
        }
    }
}