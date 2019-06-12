using Bridge.Test.NUnit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures linq implementation of IEnumerable resolves to
    /// the right call given its underlying involved type.
    /// </summary>
    [TestFixture(TestNameFormat = "#3885 - {0}")]
    public class Bridge3885
    {
        /// <summary>
        /// This is the exact same scenario as reported in the issue.
        /// </summary>
        public class DoubleTest : IEnumerable<int>, IEnumerable<double>
        {
            public int Max { get; }

            public DoubleTest(int max)
            {
                Max = max;
            }

            public IEnumerator<int> GetEnumerator() => new IntEnumerator(this);

            IEnumerator<double> IEnumerable<double>.GetEnumerator() => new DoubleEnumerator(this);

            IEnumerator IEnumerable.GetEnumerator() => new IntEnumerator(this);

            class IntEnumerator : IEnumerator<int>
            {
                private readonly int _max;
                public IntEnumerator(DoubleTest test)
                {
                    _max = test.Max;
                    Current = -1;
                }

                public int Current { get; set; }
                object IEnumerator.Current => Current;

                public void Dispose() { }
                public void Reset() { Current = -1; }

                public bool MoveNext() => ++Current <= _max;
            }

            class DoubleEnumerator : IEnumerator<double>
            {
                private readonly int _max;
                public DoubleEnumerator(DoubleTest test)
                {
                    _max = test.Max;
                    Current = -.1;
                }

                public double Current { get; set; }
                object IEnumerator.Current => Current;

                public void Dispose() { }
                public void Reset() { Current = -.1; }

                public bool MoveNext() => (Current += .1) <= _max;
            }
        }

        /// <summary>
        /// Slightly changed scenario involving string instead.
        /// </summary>
        public class StringTest : IEnumerable<int>, IEnumerable<string>
        {
            public int Max { get; }

            public StringTest(int max)
            {
                Max = max;
            }

            public IEnumerator<int> GetEnumerator() => new IntEnumerator(this);

            IEnumerator<string> IEnumerable<string>.GetEnumerator() => new StringEnumerator(this);

            IEnumerator IEnumerable.GetEnumerator() => new IntEnumerator(this);

            class IntEnumerator : IEnumerator<int>
            {
                private readonly int _max;
                public IntEnumerator(StringTest test)
                {
                    _max = test.Max;
                    Current = -1;
                }

                public int Current { get; set; }
                object IEnumerator.Current => Current;

                public void Dispose() { }
                public void Reset() { Current = -1; }

                public bool MoveNext() => ++Current <= _max;
            }

            class StringEnumerator : IEnumerator<string>
            {
                private readonly int _max;
                private int _index;
                public StringEnumerator(StringTest test)
                {
                    _max = test.Max;
                    _index = -1;
                    Current = "";
                }

                public string Current { get; set; }
                object IEnumerator.Current => Current;

                public void Dispose() { }
                public void Reset() { Current = ""; _index = -1; }

                public bool MoveNext()
                {
                    Current = "s" + ++_index;
                    return _index < _max;
                }
            }
        }

        /// <summary>
        /// Tests the string variation by checking whether the resolved type
        /// is the correct one (string!).
        /// </summary>
        [Test]
        public static void TestLinqEnumerationOnString()
        {
            {
                var test = new StringTest(1);

                foreach (var i in test)
                {
                    Assert.True((object)i is int, "The resolved type is int.");
                }

                foreach (var i in (IEnumerable<string>)test)
                {
                    Assert.True((object)i is string, "The resolved type is string.");
                }

                foreach (var i in ((IEnumerable<string>)test).Select(d => d))
                {
                    Assert.True((object)i is string, "The resolved type is string.");
                }
            }

            {
                IEnumerable<string> test = new StringTest(1);
                foreach (var i in test)
                {
                    Assert.True((object)i is string, "The resolved type is string.");
                }
                foreach (var i in test.Select(d => d))
                {
                    Assert.True((object)i is string, "The resolved type is string.");
                }
            }
        }

        /// <summary>
        /// The original format of the test, counting whether the iteration
        /// amount is congruent with the step.
        /// </summary>
        [Test]
        public static void TestLinqEnumerationOnDouble()
        {
            {
                var test = new DoubleTest(1);

                var count = 0;
                foreach (var i in test)
                {
                    count++;
                }

                Assert.AreEqual(2, count, "0 - 1 in steps of 1 results in two iterations.");

                count = 0;
                foreach (var i in (IEnumerable<double>)test)
                {
                    count++;
                }
                Assert.AreEqual(11, count, "0 - 1 in steps of 0.1 results in eleven iterations.");

                count = 0;
                foreach (var i in ((IEnumerable<double>)test).Select(d => d))
                {
                    count++;
                }
                Assert.AreEqual(11, count, "0 - 1 in steps of 0.1 results in eleven iterations.");
            }

            {
                IEnumerable<double> test = new DoubleTest(1);
                var count = 0;

                foreach (var i in test)
                {
                    count++;
                }
                Assert.AreEqual(11, count, "0 - 1 in steps of 0.1 results in eleven iterations.");

                count = 0;
                foreach (var i in test.Select(d => d))
                {
                    count++;
                }
                Assert.AreEqual(11, count, "0 - 1 in steps of 0.1 results in eleven iterations.");

            }
        }
    }
}