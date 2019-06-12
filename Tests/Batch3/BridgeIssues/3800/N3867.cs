using Bridge.Test.NUnit;
using System.Reflection;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3867 - {0}")]
    public class Bridge3867
    {
        [Reflectable]
        public class MyModel
        {
            public int Prop { get; set; }
        }

        [Test]
        public static void TestBackingField()
        {
            var c = new MyModel { Prop = 1 };
            var t = typeof(MyModel);
            var fields = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.AreEqual(1, fields.Length, "fields length is right: 1");

            var field = fields[0];
            Assert.AreEqual("<Prop>k__BackingField", field.Name, "field.Name is '<Prop>k__BackingField'");
            Assert.AreEqual(1, field.GetValue(c), "field.GetValue() fetches the correct value: 1");

            field.SetValue(c, 2);
            Assert.AreEqual(2, field.GetValue(c), "Afted field.SetValue(2), field.GetValue() returns the expected value: 2");
            Assert.AreEqual(2, c.Prop, "After field.SetValue(2), the target variable's respective property is changed accordingly");
        }
    }
}