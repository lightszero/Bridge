using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Ensures 'ref returns' C#7.2 syntax works in some additional scenarios.
    /// </summary>
    [TestFixture(TestNameFormat = "#3820 - {0}")]
    public class Bridge3820
    {
        class Score
        {
            public int value = 5;

            public ref int Get()
            {
                return ref this.value;
            }
        }

        public delegate ref result GetRef<result>();
        public static c1 a = new c1();

        public class c1
        {
            public string[] a = new string[] { "a", "b" };
        }

        public static void Set(ref int m)
        {
            m = 11;
        }

        public static void Set1(int m)
        {
            m = 11;
        }

        /// <summary>
        /// Explores the scenarios prepared by the code above.
        /// </summary>
        [Test]
        public static void TestRefReturn()
        {
            GetRef<c1> refa = () => ref a;
            refa().a[0] = "c";

            Assert.AreEqual("c", refa().a[0], "Changing array elements' values works.");

            var score = new Score();
            score.Get() = 10;
            Assert.AreEqual(10, score.Get(), "Changing value of reference to variable returned by ref method works.");

            var s = score.Get();

            int i = 1;
            Set(ref i);
            Assert.AreEqual(11, i, "Ref method can change the value of the target pointed by a reference passed in.");

            Set(ref s);
            Assert.AreEqual(11, s, "Ref method can change the value of an indirect target reference passed in.");
            Assert.AreEqual(10, score.Get(), "Changing the value of a variable which reference has been replaced does not affect the value of the former reference.");

            Set(ref score.Get());
            Assert.AreEqual(11, score.Get(), "Passing a reference to a ref return method to another ref return method works as expected.");

            score.Get() = 10;
            Set1(score.Get());
            Assert.AreEqual(10, score.Get(), "Non-ref method will not change the passed value outside its scope.");
        }
    }
}