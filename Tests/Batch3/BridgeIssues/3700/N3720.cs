using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3720 - {0}")]
    public class Bridge3720
    {
        [Flags]
        enum Test
        {
            A = 1 << 0,
            B = 1 << 1
        }

        /// <summary>
        /// Checks whether enum's ToObject() produces consistent results.
        /// </summary>
        [Test]
        public static void TestEnumToObject()
        {
            ulong v = 3;

            Test test = (Test)Enum.ToObject(typeof(Test), v);

            Assert.True(test.HasFlag(Test.A), "enum's ToObject works and retains enum data.");
            Assert.True(test.HasFlag(Test.B), "enum's ToObject works and retains all enum data.");
        }
    }
}