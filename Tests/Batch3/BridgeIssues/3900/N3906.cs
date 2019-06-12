using Bridge.Test.NUnit;
using System.Collections.Generic;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring the += operator would behave
    /// congruently with native .NET.
    /// </summary>
    [TestFixture(TestNameFormat = "#3906 - {0}")]
    public class Bridge3906
    {
        /// <summary>
        /// A class exposing an integer without default value, to be incremented.
        /// </summary>
        public class X
        {
            public int v;
        }

        /// <summary>
        /// Tests the issue by queueing the same class in two instances into
        /// the queue, then dequeuing it once and in the same line mixing up a
        /// reference to the dequeued instance, a reference to one of its
        /// properties and += operator.
        /// </summary>
        [Test]
        public static void TestAssigmentIncrement()
        {
            Queue<X> q = new Queue<X>();
            q.Enqueue(new X());
            q.Enqueue(new X());
            q.Dequeue().v += 7;
            Assert.AreEqual(1, q.Count, "Queue size is correct when mixing up .Dequeue() with property reference and += operator.");
        }
    }
}