using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The test here consists of ensuring the call count for the Create()
    /// method from the Fac class is one and only one if the return type
    /// is generic type 'out'.
    /// </summary>
    [TestFixture(TestNameFormat = "#3876 - {0}")]
    public class Bridge3876
    {
        public interface IAbstr<out T>
        {
            int SomeProperty { get; }
        }

        class Impl : IAbstr<string>
        {
            public int SomeProperty { get; set; }
        }

        public class Fac
        {
            public static int CreateCalledCount = 0;

            public IAbstr<string> Create()
            {
                CreateCalledCount++;
                return new Impl();
            }
        }

        [Test]
        public static void TestOutGenerics()
        {
            var fac = new Fac();
            int a = fac.Create().SomeProperty;
            Assert.AreEqual(1, Fac.CreateCalledCount, "Call count for initialization is 1.");
        }
    }
}