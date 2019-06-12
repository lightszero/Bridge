using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring that templates combined with object
    /// initializer syntax works right in different (but identical,
    /// technically) scenarios.
    /// </summary>
    [TestFixture(TestNameFormat = "#3886 - {0}")]
    public class Bridge3886
    {
        /// <summary>
        /// Bare minimum set up to reproduce the issue.
        /// </summary>
        public class TestBare
        {
            public int A
            {
                get;
                [Template("{this}.A = {value}")]
                set;
            }

            public string B
            {
                get;
                [Template("{this}.B = {value}")]
                set;
            }
        }

        /// <summary>
        /// Simpler approach than the reported one, still enough to reproduce
        /// the issue.
        /// </summary>
        public class TestSimpler
        {
            public TimeSpan One
            {
                get;
                [Template("{this}.One = Bridge.toString({value})")]
                set;
            }

            public TimeSpan Two
            {
                get;
                [Template("{this}.Two = Bridge.toString({value})")]
                set;
            }

            public TimeSpan Three
            {
                get;
                [Template("{this}.Three = Bridge.toString({value})")]
                set;
            }
        }

        /// <summary>
        /// Originally provided scenario to reproduce the issue.
        /// </summary>
        public class Test
        {
            public TimeSpan One
            {
                [Template("System.TimeSpan.parse({this}.One)")]
                get;
                [Template("{this}.One = Bridge.toString({value})")]
                set;
            }

            public TimeSpan Two
            {
                [Template("System.TimeSpan.parse({this}.Two)")]
                get;
                [Template("{this}.Two = Bridge.toString({value})")]
                set;
            }

            public TimeSpan Three
            {
                [Template("System.TimeSpan.parse({this}.Three)")]
                get;
                [Template("{this}.Three = Bridge.toString({value})")]
                set;
            }
        }

        /// <summary>
        /// Tests the different scenarios in order of complexity.
        /// </summary>
        [Test]
        public static void TestTemplateObjectInitializer()
        {
            var bare = new TestBare()
            {
                A = 5,
                B = "test"
            };

            Assert.AreEqual(5, bare.A, "Object initializer syntax works with template/bare 1/2.");
            Assert.AreEqual("test", bare.B, "Object initializer syntax works with template/bare 2/2.");

            var simpler = new TestSimpler()
            {
                One = TimeSpan.FromDays(1),
                Two = TimeSpan.FromDays(2),
                Three = TimeSpan.FromDays(3)
            };

            Assert.AreEqual("1.00:00:00", simpler.One, "Object initializer syntax works with template/simple 1/3.");
            Assert.AreEqual("2.00:00:00", simpler.Two, "Object initializer syntax works with template/simple 2/3.");
            Assert.AreEqual("3.00:00:00", simpler.Three, "Object initializer syntax works with template/simple 3/3.");

            var original = new Test()
            {
                One = TimeSpan.FromDays(1),
                Two = TimeSpan.FromDays(2),
                Three = TimeSpan.FromDays(3)
            };

            Assert.True(TimeSpan.FromDays(1) == original.One, "Object initializer syntax works with template/elaborate 1/3.");
            Assert.True(TimeSpan.FromDays(2) == original.Two, "Object initializer syntax works with template/elaborate 2/3.");
            Assert.True(TimeSpan.FromDays(3) == original.Three, "Object initializer syntax works with template/elaborate 3/3.");
        }
    }
}