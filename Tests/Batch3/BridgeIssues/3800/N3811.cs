using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Ensures long.MinValue and long.MaxValue matches native .NET values and
    /// whether the value matches and is preserved when specified as a
    /// constant build-time value.
    /// </summary>
    [TestFixture(TestNameFormat = "#3811 - {0}")]
    public class Bridge3811
    {
        public class Settings
        {
            public const long DefaultMinValue1 = long.MinValue;
            public const long DefaultMinValue2 = -9223372036854775808L;
            public const long DefaultMaxValue1 = long.MaxValue;
            public const long DefaultMaxValue2 = 9223372036854775807L;
        }

        /// <summary>
        /// Checks whether the
        /// </summary>
        [Test]
        public static void TestLongMinValue()
        {
            var min = -9223372036854775808L;
            var max = 9223372036854775807L;
            Assert.AreEqual(min, Settings.DefaultMinValue1, "'min' matches long.MinValue when defined as a const variable.");
            Assert.AreEqual(min, Settings.DefaultMinValue2, "'min' matches constant value defined as a const variable.");

            Assert.AreEqual(max, Settings.DefaultMaxValue1, "'max' matches long.MaxValue when defined as a const variable.");
            Assert.AreEqual(max, Settings.DefaultMaxValue2, "'max' matches constant value defined as a const variable.");
        }
    }
}