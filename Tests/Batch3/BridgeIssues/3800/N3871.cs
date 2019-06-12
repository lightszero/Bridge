using Bridge.Test.NUnit;
using System.Threading.Tasks;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The test here consists in ensuring local async functions are run
    /// obeying assynchronous execution and order.
    /// </summary>
    [TestFixture(TestNameFormat = "#3871 - {0}")]
    public class Bridge3871
    {
        static Task<bool> something()
        {
            return Task.FromResult(true);
        }

        [Test]
        public static void TestAsyncLocalFunction()
        {
            var done = Assert.Async();
            async void fct()
            {
                var r = await something();
                Assert.True(r, "Local async function is awaited before next instruction is run.");
                done();
            }
            fct();
        }
    }
}