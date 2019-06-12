// this is required in order to reproduce the issue (read below)
using Bridge.Html5;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Ensures that external referenced and related types' result from
    /// Type.IsAssignableFrom() works.
    /// </summary>
    /// <remarks>
    /// Just trying to define the class hierarchy (HTMLElement/HTMLDivElement)
    /// in a single-file class won't do to test against this scenario. This may
    /// require the code to sit in a different assembly!
    /// </remarks>
    [TestFixture(TestNameFormat = "#3809 - {0}")]
    public class Bridge3809
    {
        [Test]
        public static void TestIsAssignableFrom()
        {
            // The checked types must come from a different assembly!
            Assert.True(
                typeof(HTMLElement).IsAssignableFrom(typeof(HTMLDivElement)),
                "Type.IsAssignableFrom works with types from a different assembly.");
        }
    }
}