using Bridge.ClientTestHelper;
using Bridge.Test.NUnit;
using System;
using System.Reflection;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures several Math.IEEERemainder() results are
    /// correct.
    /// </summary>
    [TestFixture(TestNameFormat = "#3899 - {0}")]
    public class Bridge3899
    {
        /// <summary>
        /// Tests in two batches, one using Math.Round to approximate the
        /// output, and another using NumberHelper like the original
        /// IEEERemainder tests in Batch1 project.
        /// </summary>
        [Test]
        public static void TestIEEERemainder()
        {
            // Originally as drawn by Vladimir, descriptions added by Fabricio
            Assert.AreEqual(-1, Math.Round(Math.IEEERemainder(3, 2), 1), "Math.IEEERemainder(3, 2) == -1");
            Assert.AreEqual(0, Math.Round(Math.IEEERemainder(4, 2), 1), "Math.IEEERemainder(4, 2) == 0");
            Assert.AreEqual(1, Math.Round(Math.IEEERemainder(10, 3), 1), "Math.IEEERemainder(10, 3) == 1");
            Assert.AreEqual(-1, Math.Round(Math.IEEERemainder(11, 3), 1), "Math.IEEERemainder(11, 3) == -1");
            Assert.AreEqual(-1, Math.Round(Math.IEEERemainder(27, 4), 1), "Math.IEEERemainder(27, 4) == -1");
            Assert.AreEqual(-2, Math.Round(Math.IEEERemainder(28, 5), 1), "Math.IEEERemainder(28, 5) == -2");
            Assert.AreEqual(1.8, Math.Round(Math.IEEERemainder(17.8, 4), 1), "Math.IEEERemainder(17.8, 4) == 1.8");
            Assert.AreEqual(1.4, Math.Round(Math.IEEERemainder(17.8, 4.1), 1), "Math.IEEERemainder(17.8, 4.1) == 1.4");
            Assert.AreEqual(0.1, Math.Round(Math.IEEERemainder(-16.3, 4.1), 1), "Math.IEEERemainder(-16.3, 4.1) == 0.1");
            Assert.AreEqual(1.4, Math.Round(Math.IEEERemainder(17.8, -4.1), 1), "Math.IEEERemainder(17.8, -4.1) == 1.4");
            Assert.AreEqual(-1.4, Math.Round(Math.IEEERemainder(-17.8, -4.1), 1), "Math.IEEERemainder(-17.8, -4.1) == -1.4");
            Assert.AreEqual(1, Math.Round(Math.IEEERemainder(-3, 2), 1), "Math.IEEERemainder(-3, 2) == 1");
            Assert.AreEqual(1, Math.Round(Math.IEEERemainder(5, 2), 1), "Math.IEEERemainder(5, 2) == 1");
            Assert.AreEqual(2, Math.Round(Math.IEEERemainder(2, Double.NegativeInfinity), 1), "Math.IEEERemainder(2, Double.NegativeInfinity) == 2");
            Assert.AreEqual(-4.3, Math.Round(Math.IEEERemainder(-4.3, Double.NegativeInfinity), 1), "Math.IEEERemainder(-4.3, Double.NegativeInfinity) == -4.3");

            // Tests in Batch1.Math.IEEERemainderWorks()
            NumberHelper.AssertDoubleWithEpsilon8(-1, Math.Round(Math.IEEERemainder(3, 2), 1));
            NumberHelper.AssertDoubleWithEpsilon8(0, Math.Round(Math.IEEERemainder(4, 2), 1));
            NumberHelper.AssertDoubleWithEpsilon8(1, Math.Round(Math.IEEERemainder(10, 3), 1));
            NumberHelper.AssertDoubleWithEpsilon8(-1, Math.Round(Math.IEEERemainder(11, 3), 1));
            NumberHelper.AssertDoubleWithEpsilon8(-1, Math.Round(Math.IEEERemainder(27, 4), 1));
            NumberHelper.AssertDoubleWithEpsilon8(-2, Math.Round(Math.IEEERemainder(28, 5), 1));
            NumberHelper.AssertDoubleWithEpsilon8(1.8, Math.Round(Math.IEEERemainder(17.8, 4), 1));
            NumberHelper.AssertDoubleWithEpsilon8(1.4, Math.Round(Math.IEEERemainder(17.8, 4.1), 1));
            NumberHelper.AssertDoubleWithEpsilon8(0.1, Math.Round(Math.IEEERemainder(-16.3, 4.1), 1));
            NumberHelper.AssertDoubleWithEpsilon8(1.4, Math.Round(Math.IEEERemainder(17.8, -4.1), 1));
            NumberHelper.AssertDoubleWithEpsilon8(-1.4, Math.Round(Math.IEEERemainder(-17.8, -4.1), 1));
            NumberHelper.AssertDoubleWithEpsilon8(1, Math.Round(Math.IEEERemainder(-3, 2), 1));
            NumberHelper.AssertDoubleWithEpsilon8(1, Math.Round(Math.IEEERemainder(5, 2), 1));
            NumberHelper.AssertDoubleWithEpsilon8(2, Math.Round(Math.IEEERemainder(2, Double.NegativeInfinity), 1));
            NumberHelper.AssertDoubleWithEpsilon8(-4.3, Math.Round(Math.IEEERemainder(-4.3, Double.NegativeInfinity), 1));
        }
    }
}