using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring thrown exceptions by
    /// ClientWebSocket's ConnectAsync() when something goes wrong.
    /// </summary>
    [TestFixture(TestNameFormat = "#3821 - {0}")]
    public class Bridge3821
    {
        [Test(ExpectedCount = 1)]
        public async static void TestWebSocketError()
        {
            var done = Assert.Async();
            try
            {
                var sc = new System.Net.WebSockets.ClientWebSocket();
                await sc.ConnectAsync(new Uri("wss://NotExistServer/NotExist"), System.Threading.CancellationToken.None);
                Assert.Fail("ConnectAsync() to an invalid address didn't throw an exception.");
                done();
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex, "ConnectAsync() thrown an exception when trying to connect to an invalid address.");
                done();
            }
        }
    }
}