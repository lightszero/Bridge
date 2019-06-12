using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures enum emission rules obey the StringNameLowerCase
    /// setting when the enum is returned via a default function's value.
    /// </summary>
    [TestFixture(TestNameFormat = "#3958 - {0}")]
    public class Bridge3958
    {
        /// <summary>
        /// Tests the issue both for a case where it works (provided parameter)
        /// and where it used to break in 17.7, with default value assumed.
        /// </summary>
        [Test]
        public static void TestEnumStringOptional()
        {
            Assert.AreEqual("euclidean", GetOptions(MetricOptions.Euclidean), "Enum rule obeyed when value provided to method.");
            Assert.AreEqual("euclidean", GetOptions(), "Enum rule obeyed when value assumed from default method parameter.");
        }

        static object GetOptions(MetricOptions metric = MetricOptions.Euclidean) => metric;

        [Enum(Emit.StringNameLowerCase)]
        enum MetricOptions
        {
            Euclidean
        }
    }
}