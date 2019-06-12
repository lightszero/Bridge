using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Ensures String.IndexOfAny results matches native .NET's.
    /// </summary>
    [TestFixture(TestNameFormat = "#3964 - {0}")]
    public class Bridge3964
    {
        /// <summary>
        /// Tests some scenarios, including the one originally reported
        /// in the github issue (the first assertion below).
        /// </summary>
        [Test]
        public static void TestIndexOfAny()
        {
            char[] test = { 'd', 'H' };
            var msg = "Hello, World!";

            Assert.AreEqual(0, msg.IndexOfAny(test), "Index of any of { 'd', 'H' } in \"Hello, World!\" is 0.");

            char[] chars = { 'a', 'e', 'i', 'o', 'u', 'y',
                       'A', 'E', 'I', 'O', 'U', 'Y' };
            var s = "The long and winding road...";
            Assert.AreEqual(2, s.IndexOfAny(chars), "Index of any of { 'a', 'e', 'i', ... } in \"The long and...\" string is 2.");

            var str = "Now is the time for all good men to come to the aid of their party.";
            string target = "is";
            char[] anyOf = target.ToCharArray();
            int  start = str.Length / 2;
            Assert.AreEqual(49, str.IndexOfAny(anyOf, start), "Specifying a starting index in the string works.");

            target = "aid";
            anyOf = target.ToCharArray();
            start = (str.Length - 1) / 3;
            var count = (str.Length - 1) / 4;
            Assert.AreEqual(27, str.IndexOfAny(anyOf, start, count), "Specifying an interval index in the string works.");
        }
    }
}