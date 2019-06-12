using Bridge.Test.NUnit;
using System;
using System.Reflection;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring non-nullable types receives their
    /// default values whenever assigned 'null' from reflection's SetValue().
    /// </summary>
    [TestFixture(TestNameFormat = "#3939 - {0}")]
    public class Bridge3939
    {
        /// <summary>
        /// Defines a class with different types of non-nullable variables
        /// through properties and fields.
        /// </summary>
        [Reflectable]
        public class Test
        {
            public int Int32Prop { get; set; } = 1;
            public int Int32Field = 2;
            public long Int64Prop { get; set; } = 3L;
            public long Int64Field = 4L;
            public float SingleProp { get; set; } = 5.1f;
            public float SingleField = 5.2f;
            public double DoubleProp { get; set; } = 6.1f;
            public double DoubleField = 6.2f;
            public decimal DecimalProp { get; set; } = 7.1m;
            public decimal DecimalField = 7.2m;
        }

        /// <summary>
        /// Tests by just inline-binding null to the variables and then
        /// checking the result against the type's default() value.
        /// </summary>
        [Test]
        public static void TestReflectionSetValue()
        {
            Test test = new Test();

            test.GetType().GetProperty("Int32Prop").SetValue(test, null);
            Assert.AreEqual(default(int), test.Int32Prop, "Int32 property gets default(int) when assigned \"null\" with reflection.");
            test.GetType().GetProperty("Int64Prop").SetValue(test, null);
            Assert.AreEqual(default(long), test.Int64Prop, "Int64 property gets default(long) when assigned \"null\" with reflection.");
            test.GetType().GetProperty("SingleProp").SetValue(test, null);
            Assert.AreEqual(default(float), test.SingleProp, "Single property gets default(float) when assigned \"null\" with reflection.");
            test.GetType().GetProperty("DoubleProp").SetValue(test, null);
            Assert.AreEqual(default(double), test.DoubleProp, "Double property gets default(double) when assigned \"null\" with reflection.");
            test.GetType().GetProperty("DecimalProp").SetValue(test, null);
            Assert.AreEqual(default(decimal), test.DecimalProp, "Decimal property gets default(decimal) when assigned \"null\" with reflection.");
        }
    }
}