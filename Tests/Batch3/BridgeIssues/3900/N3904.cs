using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring array checks involving 'object'
    /// works as in native .NET.
    /// </summary>
    [TestFixture(TestNameFormat = "#3904 - {0}")]
    public class Bridge3904
    {
        /// <summary>
        /// Tests several scenarios including some that were failing in Bridge
        /// 17.7.0.
        /// </summary>
        [Test]
        public static void TestArrayCovariance()
        {
            object ao1 = new int[1];
            Assert.False(ao1 is object[], "(object => int[1]) is not object[]");

            var ao = new int[][] { new int[1] };
            Assert.True(ao is object[], "(int[][] => int[1]) is object[]");

            object a = new int[][][] { new int[][] { new int[1] } };
            Assert.True(a is object[], "(int[][][] => int[][] => int[1]) is object[]");
            Assert.True(a is object[][], "(int[][][] => int[][] => int[1]) is object[][]");
            Assert.False(a is object[][][], "(int[][][] => int[][] => int[1]) is not object[][][]");

            object b = new string[][] { new string[] { "hi" } };
            Assert.True(b is string[][], "(object => string[][] => string[] => \"hi\") is string[][]");
            Assert.True(b is object[], "(object => string[][] => string[] => \"hi\") is object[]");
            Assert.True(b is object[][], "(object => string[][] => string[] => \"hi\") is object[][]");
            Assert.False(b is object[][][], "(object => string[][] => string[] => \"hi\") is not object[][][]");
        }

        public class c1
        {
        }

        public class c2 : c1
        {
        }

        public struct s1 { }

        /// <summary>
        /// Tests involving classes and inheritance.
        /// </summary>
        [Test]
        public static void TestArrayCovariance2()
        {
            c2[] i2 = new c2[1];
            Assert.True(i2 is object[], "(c2[] => c2[1]) is object[]");
            Assert.True(i2 is c1[], "(c2[] => c2[1]) is c1[], where c2:c1");

            object ao = new s1[1];
            Assert.False(ao is object[], "(object => s1[1]) is object[]");

            ao = new string[1];
            Assert.True(ao is object[], "(object => string[1]) is object[]");

            ao = new int[1];
            Assert.False(ao is object[], "(object => int[1]) is object[]");

            Assert.False(typeof(object[]).IsAssignableFrom(typeof(int[])), "object[] is not assignable from int[]");
            Assert.True(typeof(object[]).IsAssignableFrom(typeof(int[][])), "object[] is assignable from int[][]");
        }

        /// <summary>
        /// Tests in the format originally reported.
        /// </summary>
        [Test]
        public static void TestArrayCovarianceReported()
        {
            object a = new int[][][] { new int[][] { new int[1] } };
            Assert.True(a is object[], "(object => int[][][] => int[][] => int[1]) is object[]");
            Assert.True(a is object[][], "(object => int[][][] => int[][] => int[1]) is object[][]");
            Assert.False(a is object[][][], "(object => int[][][] => int[][] => int[1]) is not object[][][]");

            object b = new string[][] { new string[] { "hi" } };
            Assert.True(b is string[][], "(object => string[][] => string[] => \"hi\") is string[][]");
            Assert.True(b is object[], "(object => string[][] => string[] => \"hi\") is object[]");
            Assert.True(b is object[][], "(object => string[][] => string[] => \"hi\") is objectg[][]");
            Assert.False(b is object[][][], "(object => string[][] => string[] => \"hi\") is not object[]][][]");
        }
    }
}