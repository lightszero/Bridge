using System;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring the exception thrown when an async
    /// task is cancelled at run-time.
    /// </summary>
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#2405 - {0}")]
    public class Bridge2405
    {
        /// <summary>
        /// Tests by calling an async task, cancelling it, then checking the
        /// thrown exception in the end.
        /// </summary>
        [Test]
        public static void TestDelayWithCancelation()
        {
            var done = Assert.Async();
            CancellationTokenSource source = new CancellationTokenSource();

            var t = Task.Run(async delegate
            {
                // Support required for .Delay with Token
                await Task.Delay(100, source.Token);

                return 42;
            });

            source.Cancel();

            try
            {
                // Support required for .Wait
                t.Wait();
            }
            catch (AggregateException ae)
            {
                Assert.True(ae.InnerException is TaskCanceledException, "Canceled task's exception is TaskCanceledException.");
            }

            Assert.AreEqual(TaskStatus.Canceled, t.Status, "Canceled task has the 'Canceled' status.");

            source.Dispose();
            done();
        }

        /// <summary>
        /// Ensures exception won't be thrown if the cancellation is attempted
        /// after the async task has completed.
        /// </summary>
        [Test]
        public static void TestDelayWithCancelation2()
        {
            var done = Assert.Async();
            CancellationTokenSource source = new CancellationTokenSource();

            var t = Task.Run(async delegate
            {
                // Support required for .Delay with Token
                await Task.Delay(100, source.Token);

                return 42;
            });

            try
            {
                t.Wait(200);
                source.Cancel();
            }
            catch (AggregateException)
            {
                Assert.Fail("Should not be an exception");
            }

            Assert.AreEqual(TaskStatus.RanToCompletion, t.Status, "Late-canceled task's status is 'RanToCompletion'.");
            Assert.AreEqual(42, t.Result, "Late-canceled task result matches the expected value bound at the task's end.");

            source.Dispose();
            done();
        }
    }
}