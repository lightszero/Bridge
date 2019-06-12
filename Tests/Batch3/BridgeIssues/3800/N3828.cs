using Bridge.Test.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{

    /// <summary>
    /// The test here consists in ensuring SortedList usage is compatible
    /// with Microsoft documentation on the class, and that the getter
    /// method work. It was resulting in recursive stack loop in modern
    /// browsers when used, and due to 'strict mode', Internet Explorer
    /// 11 refused to load the bridge.js file, as its client-side getter
    /// method was defined in duplicity.
    /// </summary>
    /// <remarks>
    /// Two github issues were created: #3827 related to IE11 issue, and
    /// #3828 related to the bracket-binding and exception thrown if getting
    /// non-existing element.
    /// </remarks>
    [TestFixture(TestNameFormat = "#3827, #3828 - {0}")]
    public class Bridge3828
    {
        /// <summary>
        /// Tests basic usage of the Sorted list and ensures it complies with
        /// the official documentation at
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=netframework-4.7.2
        /// </summary>
        [Test]
        public static void TestSortedList()
        {
            var list = new SortedList<int, string>();
            list[1] = "value1";
            list.Add(2, "value2");

            Assert.AreEqual(2, list.Count, "SortedList has two elements.");
            Assert.AreEqual(list[1], "value1", "SortedList's get method works for first element.");
            Assert.AreEqual(list[2], "value2", "SortedList's get method works for second element.");
            Assert.Throws<KeyNotFoundException>(() => {
                var z = list[4];
            }, "Fetching non-existing SortedList element throws System.KeyNotFoundException.");
        }
    }
}