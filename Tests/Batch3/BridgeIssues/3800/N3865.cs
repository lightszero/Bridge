using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring reflection works over an array of
    /// arrays.
    /// </summary>
    [TestFixture(TestNameFormat = "#3865 - {0}")]
    public class Bridge3865
    {
        [Test]
        public static void TestArrayAssembly()
        {
            Assert.AreEqual(
                typeof(string).Assembly.FullName,
                typeof(string[][]).Assembly.FullName,
                "The type associated to an array of arrays has the Assembly property.");
        }
    }
}