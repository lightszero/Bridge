using Bridge.Test.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3823 - {0}")]
    public class Bridge3823
    {
        [Test]
        public static void TestIsPattern()
        {
            string s = "";
            object o = s;

            if (o is decimal d)
            {
                Assert.Fail("Non-decimal type resolves as decimal at run-time.");
            }
            else
            {
                Assert.NotNull(o, "Non-decimal type does not resolve as decimal at run-time.");
            }
        }
    }
}