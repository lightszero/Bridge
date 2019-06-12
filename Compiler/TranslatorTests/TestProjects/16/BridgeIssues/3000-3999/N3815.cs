using Bridge;
using System;

namespace Test.BridgeIssues.N3815
{
    /// <summary>
    /// #3815 Ensures multiple ModuleDependency attributes works.
    /// </summary>
    /// <remarks>
    /// If this is working the output in TestProject.js file should contain a
    /// line with:
    /// define("Module1", ["Module2", "Module3", "Module4"], function (Module2, Module3, Module4) {
    /// </remarks>
    public class N3815
    {
        [Module(ModuleType.AMD, "Module1", true, ExportAsNamespace = "Mod1")]
        [Name("Module1")]
        [ModuleDependency("Module2")]
        [ModuleDependency("Module3")]
        [ModuleDependency("Module4")]
        public static class Module1
        {
            public extern static void Test1();
        }
    }
}
