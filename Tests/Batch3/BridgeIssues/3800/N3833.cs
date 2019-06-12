using Bridge.Test.NUnit;
using System;
using System.Collections.Generic;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3833 - {0}")]
    public class Bridge3833
    {
        public class A
        {
            public bool Prop { get { throw new NotImplementedException(); } }
        }

        [Test]
        public static void TestTupleEquals()
        {
            Assert.False(new A().Equals(new A()), "Class.Equals works between two different instances of a class.");
            Assert.False(
                new Tuple<A>(new A()).Equals(new Tuple<A>(new A())),
                "Tuple<class> works between two different instances of Tuple<class>.");
        }
    }
}