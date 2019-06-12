using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3855 - {0}")]
    public class Bridge3855
    {
        [Test]
        public static void TestTypeName()
        {
            Assert.AreEqual("System.Type", typeof(Type).FullName, "typeof(Type).FullName is 'System.Type'.");
            Assert.AreEqual("Type", typeof(Type).Name, "typeof(Type).Name is 'Type'");

            Assert.AreEqual("System.Boolean", typeof(Boolean).FullName, "typeof(Boolean).FullName is 'System.Boolean'");
            Assert.AreEqual("Boolean", typeof(Boolean).Name, "typeof(Boolean).Name is 'Boolean'");

            Assert.AreEqual("System.String", typeof(String).FullName, "typeof(String).FullName is 'System.String'");
            Assert.AreEqual("String", typeof(String).Name, "typeof(String).Name is 'String'");

            Assert.AreEqual("System.DateTime", typeof(DateTime).FullName, "typeof(DateTime).FullName is 'System.DateTime'");
            Assert.AreEqual("DateTime", typeof(DateTime).Name, "typeof(DateTime).Name is 'DateTime'");
        }
    }
}