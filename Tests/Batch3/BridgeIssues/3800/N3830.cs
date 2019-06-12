using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3830 - {0}")]
    public class Bridge3830
    {
        [Test]
        public static void TestArrayResize()
        {
            String[] myArr = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            Assert.AreEqual(8, myArr.GetUpperBound(0), "Array initial upper boundary index is 8.");

            Array.Resize(ref myArr, myArr.Length + 5);
            Assert.AreEqual(13, myArr.GetUpperBound(0), "Array upper boundary index becomes 13 after change.");
            Assert.AreEqual("The", myArr[0], "Array element 0 is correct.");
            Assert.AreEqual("quick", myArr[1], "Array element index 1 is correct.");
            Assert.AreEqual("brown", myArr[2], "Array element index 2 is correct.");
            Assert.AreEqual("fox", myArr[3], "Array element index 3 is correct.");
            Assert.AreEqual("jumps", myArr[4], "Array element index 4 is correct.");
            Assert.AreEqual("over", myArr[5], "Array element index 5 is correct.");
            Assert.AreEqual("the", myArr[6], "Array element index 6 is correct.");
            Assert.AreEqual("lazy", myArr[7], "Array element index 7 is correct.");
            Assert.AreEqual("dog", myArr[8], "Array element index 8 is correct.");

            Assert.Null(myArr[9], "Array element index 9 is null.");
            Assert.Null(myArr[10], "Array element index 10 is null.");
            Assert.Null(myArr[11], "Array element index 11 is null.");
            Assert.Null(myArr[12], "Array element index 12 is null.");
            Assert.Null(myArr[13], "Array element index 13 is null.");

            Assert.Throws<IndexOutOfRangeException>(
                () => { var tmp = myArr[14]; },
                "Array element index 14 is out of the array's range.");

            Array.Resize(ref myArr, 4);
            Assert.AreEqual(3, myArr.GetUpperBound(0), "Array's upper bound is 3 after resized again.");
            Assert.AreEqual("The", myArr[0], "Array element index 0 is correct.");
            Assert.AreEqual("quick", myArr[1], "Array element index 1 is correct.");
            Assert.AreEqual("brown", myArr[2], "Array element index 2 is correct.");
            Assert.AreEqual("fox", myArr[3], "Array element index 3 is correct.");
            Assert.Throws<IndexOutOfRangeException>(
                () => { var tmp = myArr[4]; },
                "Array element index 4 became out of array range.");
        }

        [Test]
        public static void TestArrayCreateInstanceResize()
        {
            string[] Strings;

            Strings = (string[])Array.CreateInstance(typeof(string), new int[] { 0 });

            Array.Resize(ref Strings, Strings.Length + 1);
            Assert.AreEqual(1, Strings.Length, "Resized array has 1 element.");
            Assert.AreEqual(0, Strings.GetUpperBound(0), "Resized array's upper bound index is 0.");
        }
    }
}