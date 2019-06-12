using Bridge.Test.NUnit;
using System;
using System.Diagnostics;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures the performance between resize and allocation
    /// for primitive and reference types are within an acceptable threshold of
    /// 50ms or 1.5 times.
    /// </summary>
    [TestFixture(TestNameFormat = "#3930 - {0}")]
    public class Bridge3930
    {
        // a minimumal value to ensure at least a couple milisseconds are spent in both operations
        private static int iterations = 1000;

        // number of samples to iterate per test
        private static int samples = 10000;

        /// <summary>
        /// Coordinate the calls to the allocation/resize tests and checks
        /// whether they are within the expected threshold.
        /// </summary>
        [Test]
        public static void TestGenericArrayAllocPerformance()
        {
            var thresms = 50;
            var threstimes = 1.5;

            // Firefox requires a much more "relaxed" threshold. It was not
            // much affected by the issue, but the timings go wild depending
            // on the performance of the tested system.
            if (Browser.FirefoxVersion > 0)
            {
                thresms = 200;

                // Locally on a 4790K, it does not hit 2x ratio, but in the
                // saucelabs hosts, it can go as high as 4.5x!
                threstimes = 5;
            }

            var tialloc = probePerformance(false, false); // int alloc
            var tiresiz = probePerformance(false, true); // int resize
            Assert.True(
                ((tialloc - thresms) < tiresiz) ||
                (tialloc < (tiresiz * threstimes)),
                "The performance ratio alloc:resize for int is within an acceptable threshold (" + tialloc + ":" + tiresiz + ")."
            );

            var tsalloc = probePerformance(true, false); // string alloc
            var tsresiz = probePerformance(true, true); // string resize
            Assert.True(
                ((tsalloc - thresms) < tsresiz) ||
                (tsalloc < (tsresiz * threstimes)),
                "The performance ratio alloc:resize for string is within an acceptable threshold (" + tsalloc + ":" + tsresiz + ")."
            );
        }

        /// <summary>
        /// Coordinates the allocation given the reftype or resize conditions
        /// to switch the test performed.
        /// </summary>
        /// <param name="reftype"></param>
        /// <param name="resize"></param>
        /// <returns>A delay of at least 1, in milliseconds.</returns>
        private static long probePerformance(bool reftype, bool resize)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                if (reftype) Alloc<string>(samples, resize);
                else Alloc<int>(samples, resize);
            }
            sw.Stop();
            return sw.ElapsedMilliseconds > 1 ? sw.ElapsedMilliseconds : 1;
        }

        private static T[] Alloc<T>(int len, bool resize)
        {
            if (resize)
            {
                T[] a = new T[0];
                Array.Resize(ref a, len);
                return a;
            }
            return new T[len];
        }
    }
}