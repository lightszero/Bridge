using Bridge.Test.NUnit;
using System.Threading.Tasks;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3836 - {0}")]
    public class Bridge3836
    {
        static async Task TestAsync(EventHandlerAsync deleg)
        {
            await deleg();
        }


        delegate Task EventHandlerAsync();


#pragma warning disable CS1998
        static async Task Test()
#pragma warning restore CS1998
        {
            ready = true;
        }

        private static bool ready = false;

        [Test]
        public static async void TestAsyncLambda()
        {
            var done = Assert.Async();
            ready = false;
            await TestAsync(Test);
            Assert.True(ready, "Async delegate method works.");

            // Only this part was breaking in Bridge 17.6.0.
            ready = false;
            await TestAsync(async () => await Test());
            Assert.True(ready, "Async inline delegate method works.");

            done();
        }
    }
}