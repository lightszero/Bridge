using System;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// This test consists in running async tasks and calling the task's Wait()
    /// method to wait for the tast execution to finish. At each step, a string
    /// buffer is padded with a number indicating the expected order, which is
    /// then checked at the end of the execution, to ensure every call ran in
    /// the expected order.
    /// </summary>
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#2406 - {0}")]
    public class Bridge2406
    {
        [Test]
        public static void TestTaskWait()
        {
            var done = Assert.Async();

            string buffer = "";
            var result = Task.Run(() =>
            {
                buffer += "1";
            });

            result.ContinueWith(
                (test) =>
                {
                    buffer += "2";
                }).Wait();

            buffer += "3";

            Assert.AreEqual("123", buffer, "The response buffer was filled in the correct order.");
            done();
        }

        [Test]
        public async static void TestTaskWaitWithDelay()
        {
            var done = Assert.Async();
            string buffer = "";

            var result = Task.Run(() =>
            {
                buffer += "1";
            });

            result.ContinueWith(
                (test) =>
                {
                    buffer += "2";
                }).Wait();

            buffer += "3";

            buffer += "4";
            await Task.Delay(100);
            buffer += "5";

            result = Task.Run(() =>
            {
                buffer += "6";
            });

            buffer += "7";
            await Task.Delay(100);
            buffer += "8";

            result.ContinueWith(
                (test) =>
                {
                    buffer += "9";
                }).Wait();

            buffer += "10";
            await Task.Delay(100);
            buffer += "11";

            buffer += "12";

            Assert.AreEqual("123457689101112", buffer, "The result buffer was filled up in the correct order.");

            done();
        }

        [Test]
        public static void TestTaskWaitDelayInlineFn()
        {
            var done = Assert.Async();
            string buffer = "";

            Task t = Task.Run(async () =>
            {
                buffer += "1";
                await Task.Delay(1000);
                buffer += "2";
                Assert.AreEqual("132", buffer, "The result buffer was filled up in the correct order.");
                done();
            });

            TimeSpan ts = TimeSpan.FromMilliseconds(150);

            if (!t.Wait(ts))
            {
                buffer += "3";
            }

            Assert.AreEqual("13", buffer, "The result buffer had the correct state during execution (before slower task finishes).");
        }

        [Test]
        public static async void TestTaskDelayAndWait()
        {
            var done = Assert.Async();
            string buffer = "";

            CancellationTokenSource ts = new CancellationTokenSource();

            Task t = Task.Run(() => {
                buffer += "2";
                ts.Cancel();
                Task.Delay(50).Wait();
                buffer += "4";
            });
            try
            {
                buffer += "1";
                t.Wait(ts.Token);
            }
            catch (OperationCanceledException)
            {
                buffer += "3";
                await Task.Delay(100);
                buffer += "5";
                Assert.AreEqual("12345", buffer, "The result buffer was filled up in the correct order.");
            }
            ts.Dispose();

            done();
        }
    }
}