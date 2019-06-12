using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#1468 - {0}")]
    public class Bridge1468
    {
        [Test]
        public static void TestArrayConcat()
        {
            IEnumerable<string> array = new[] { "h" }.Concat(new[] { "h" });
            Assert.AreEqual(2, array.Count());

            var stringEnumerable = new string[] { "_" }.Concat(new[] { "h" });
            var stringArray = stringEnumerable.ToArray();
            Assert.AreEqual(2, stringArray.Length);
        }
    }
}