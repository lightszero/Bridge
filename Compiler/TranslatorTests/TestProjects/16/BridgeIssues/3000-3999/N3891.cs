using Bridge;
using System.Collections.Generic;

namespace Test.BridgeIssues.N3891
{
    using System;

    public class App
    {
        private readonly byte[] byteArray = new byte[8];

        // this should match something with 'type(System.Byte)', like:
        // this.byteArrayList = new (System.Collections.Generic.List$1(System.Array.type(System.Byte))).ctor();
        private readonly List<byte[]> byteArrayList = new List<byte[]>();
        private readonly string comment = "The line above should contain 'type(System.Byte)'.";
    }
}