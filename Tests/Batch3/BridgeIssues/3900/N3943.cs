using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// This test ensures initialization of static const members works
    /// correctly.
    /// </summary>
    [TestFixture(TestNameFormat = "#3943 - {0}")]
    public class Bridge3943
    {
        /// <summary>
        /// Check whether the property matches the value it is derifved from.
        /// </summary>
        [Test]
        public static void TestStaticInitialization()
        {
            Assert.AreEqual("A", c2.p2.p1, "Value is correctly initialized.");
        }

        /// <summary>
        /// A class implementing the indirect property that used not to have
        /// the correct value.
        /// </summary>
        public class c1
        {
            public string p1 { get; set; }
        }

        /// <summary>
        /// Class implementing members that references the c1 class above.
        /// </summary>
        public class c2
        {
            private static c1 _s = _init();

            private static c1 _init()
            {
                c1 o1 = new c1
                {
                    p1 = Z1
                };

                return o1;
            }

            public static c1 p2 { get { return _s; } }

            public string p3 { get; set; }

            public const string Z1 = "A";
        }
    }
}