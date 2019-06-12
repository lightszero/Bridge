using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures the ++ postfix operator is not double-evaluated
    /// in the involved scenario.
    /// </summary>
    [TestFixture(TestNameFormat = "#3905 - {0}")]
    public class Bridge3905
    {
        /// <summary>
        /// Tests whether the increment does not stack, resulting in the
        /// specified values from the same code run in native .NET.
        /// </summary>
        [Test]
        public static void TestArrayIncrement()
        {
            int[] a = new int[] { 3, 8 };
            int i = 0;
            a[i++]++;
            Assert.AreEqual(1, i, "i was incremented by 1 in a[i++]++;");
            Assert.AreEqual(4, a[0], "a[0] was incremented by 1 in a[i++]++;");
            Assert.AreEqual(8, a[1], "a[1] was not incremented at all in a[i++]++;");
        }
    }
}