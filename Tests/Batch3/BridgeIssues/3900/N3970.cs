using Bridge.Test.NUnit;
using System;

/// <summary>
/// The tests here ensures that Bridge supports translating a namespace where
/// it has a class with the same name of the namespace, and a funcion call
/// using named parameters somewhere else in the namespace.
/// </summary>
namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3970 - {0}")]
    public class Bridge3970
    {        
        [Test]
        public static void TestNamespaceAndClassSameName()
        {
            Assert.NotNull(NameBridge3970.App.Run(), "The scenario can be translated correctly.");
        }
    }
}

/// <summary>
/// Basically what's required here is the empty (or not) class with the same
/// name as the namespace, and also the call to Specialist.Update(updater: fn).
/// Either dropping the repeated class name or the explicit parameter name
/// ("updater: " in the call), the issue vanishes.
/// </summary>
namespace NameBridge3970
{
    public sealed class NameBridge3970 { }

    public sealed class App
    {
        // This is one of the items that triggered the issue.
        public static SpecialList<CategorySetGroup> Run()
        {
            return SpecialList<CategorySetGroup>.Empty.Update(
                // This named argument does not affect the issue at all.
                updater: pcs => pcs.With(
                    _ => _.CategorySets,

                    pcs.CategorySets.Update(
                        // "updater: " below is another item that. combined
                        // with the class/namespace name match, makes the
                        // scenario break.
                        updater: cs => cs
                    )
                )
            );
        }
    }

    public sealed class CategorySetGroup
    {
        public SpecialList<CategorySet> CategorySets { get; }

        public CategorySetGroup With<TProp>(Func<CategorySetGroup, TProp> propIdentifier, TProp newValue) { return this; }
    }

    public sealed class CategorySet
    {
        public SpecialList<Category> Categories { get; }

        public CategorySet With<TProp>(Func<CategorySet, TProp> propIdentifier, TProp newValue) { return this; }
    }

    public sealed class Category { }

    public sealed class SpecialList<T>
    {
        public static SpecialList<T> Empty { get; } = new SpecialList<T>();

        public SpecialList<T> Update(Func<T, T> updater)
        {
            return this;
        }
    }
}
