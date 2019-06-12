using Bridge.Test.NUnit;
using System;
using System.Threading.Tasks;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The test here ensures 'await' calls in completed tasks won't abort
    /// async methods.
    /// </summary>
    [TestFixture(TestNameFormat = "#3951 - {0}")]
    public class Bridge3951
    {
        /// <summary>
        /// Checks whether the async counter caught up to the end of the method
        /// even though there's several await calls around the async task.
        /// </summary>
        [Test]
        public static void TestAwaitFinished()
        {
            int[] count = new int[1];
            Task t = TightLoop(count);
            Assert.AreEqual(10000, count[0], "Async method executed until completion.");
        }

        /// <summary>
        /// The TightLoop test below calls await every loop iteration, a
        /// scenario that would interrupt overall execution at some point in
        /// Bridge 17.7.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static async Task TightLoop(int[] count)
        {
            Task finished = Task.FromResult<String>(null);
            for (int i = 0; i < 10000; i++)
            {
                await finished;
                count[0]++;
            }
        }
    }
}