using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The test here ensures a javascript-created number will have its
    /// bridge-interfaced helpers when cast.
    /// </summary>
    [TestFixture(TestNameFormat = "#3883 - {0}")]
    public class Bridge3883
    {
        /// <summary>
        /// Creates a int64 fitting (yet, too big for int32) constant from
        /// javascript side and cast it into long and checks whether it gets
        /// the required Bridge extensions working.
        /// </summary>
        [Test]
        public static void TestPlain64()
        {
            ulong ul = Script.Write<ulong>("9223372036854775808");
            long l = (long)ul;

            Assert.True(l == long.MinValue, "Native cast into long works.");
        }
    }
}