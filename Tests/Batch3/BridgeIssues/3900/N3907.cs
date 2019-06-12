using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The test here ensures the specific scenario involved is congruent with
    /// what happens in native .NET.
    /// </summary>
    [TestFixture(TestNameFormat = "#3907 - {0}")]
    public class Bridge3907
    {
        /// <summary>
        /// Interface requiring an unecessary declaration, which ultimately
        /// triggers the related issue.
        /// </summary>
        public interface I
        {
            string ToString();
        }

        /// <summary>
        /// Class implementing the above interface's method.
        /// </summary>
        public class A : I
        {
            public override string ToString()
            {
                return "A";
            }
        }

        /// <summary>
        /// Class inheriting from the class implementing the interface above,
        /// and also specifying it implements the same interface as the class
        /// it inherits from.
        /// </summary>
        public class B : A, I
        {
        }

        /// <summary>
        /// Tests by calling the interface-implemented method from the latter
        /// class.
        /// Consists in declaring a variable as the main interface, but
        /// instantiating the complexer class in it, yet calling the method
        /// guaranteed by the direct interface.
        /// </summary>
        [Test]
        public static void TestInterfaceToString()
        {
            I i = new B();

            Assert.AreEqual("A", i.ToString(), "Calling Interface.method() from class classB:classA,Interface, where classA implements the method, works.");
        }
    }
}