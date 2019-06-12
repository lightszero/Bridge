using Bridge.Test.NUnit;
using System.Linq;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3875 - {0}")]
    public class Bridge3875
    {
        [Test]
        public static void TestToArray()
        {
            var bytes = new byte[] { 1, 2, 3, 4 };
            Assert.AreEqual("Byte[]", bytes.ToArray().GetType().Name, "Byte array type from linq's ToArray() is 'Byte[]'.");
            Assert.AreEqual("Byte[]", bytes.GetType().Name, "Byte array's type is 'Byte[]'.");

            var ints = new int[] { 1, 2, 3, 4 };
            Assert.AreEqual("Int32[]", ints.ToArray().GetType().Name, "Int array type from linq's ToArray() is 'Int32[]'.");
            Assert.AreEqual("Int32[]", ints.GetType().Name, "Int array's type is 'Int32[]'.");

            var strings = new string[] { "1", "2", "3", "4" };
            Assert.AreEqual("String[]", strings.ToArray().GetType().Name, "String array type from linq's ToArray() is 'String[]'.");
            Assert.AreEqual("String[]", strings.GetType().Name, "String array's type is 'String[]'.");

            var floats = new float[] { 1, 2, 3, 4 };
            Assert.AreEqual("Single[]", floats.ToArray().GetType().Name, "Float array type from linq's ToArray() is 'Single[]'.");
            Assert.AreEqual("Single[]", floats.GetType().Name, "Single array's type is 'Single[]'.");

            var doubles = new double[] { 1.8, 2.2, 3.6, 4.1 };
            Assert.AreEqual("Double[]", doubles.ToArray().GetType().Name, "Double array type from linq's ToArray() is 'Double[]'.");
            Assert.AreEqual("Double[]", doubles.GetType().Name, "Double array's type is 'Double[]'.");
        }
    }
}