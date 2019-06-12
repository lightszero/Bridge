using System;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// This test consists in ensuring the types' IsPrimitive property returns
    /// 'true' to the main primitive types, and 'false' to other types.
    /// </summary>
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#2522 - {0}")]
    public class Bridge2522
    {
        /// <summary>
        /// Just ensures
        /// </summary>
        [Test]
        public static void TestIsPrimitive()
        {
            Assert.True(typeof(Byte).IsPrimitive, "'Byte' is primitive.");
            Assert.True(typeof(SByte).IsPrimitive, "'SByte' is primitive.");
            Assert.True(typeof(Int16).IsPrimitive, "'Int16' is primitive.");
            Assert.True(typeof(UInt16).IsPrimitive, "'UInt16' is primitive.");
            Assert.True(typeof(Int32).IsPrimitive, "'Int32' is primitive.");
            Assert.True(typeof(UInt32).IsPrimitive, "'UInt32' is primitive.");
            Assert.True(typeof(Int64).IsPrimitive, "'Int64' is primitive.");
            Assert.True(typeof(UInt64).IsPrimitive, "'UInt64' is primitive.");
            Assert.True(typeof(Boolean).IsPrimitive, "'Boolean' is primitive.");
            Assert.True(typeof(Char).IsPrimitive, "'Char' is primitive.");
            Assert.True(typeof(Double).IsPrimitive, "'Double' is primitive.");
            Assert.True(typeof(Single).IsPrimitive, "'Single' is primitive.");

            Assert.False(typeof(Decimal).IsPrimitive, "'Decimal' is not primitive.");
            Assert.False(typeof(DateTime).IsPrimitive, "'DateTime' is not primitive.");
            Assert.False(typeof(String).IsPrimitive, "'String' is not primitive.");
        }
    }
}