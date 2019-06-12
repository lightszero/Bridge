using Bridge;
using System.Collections.Generic;

namespace Test.BridgeIssues.N3891
{
    using System;

    public class App
    {
        private readonly byte[] byteArray = new byte[8];

        // this should match something with 'List$1(Uint8Array))', like:
        // this.byteArrayList = new (System.Collections.Generic.List$1(Uint8Array)).ctor();
        private readonly List<byte[]> byteArrayList = new List<byte[]>();
        private readonly string comment = "The line above should contain 'List$1(Uint8Array))'.";
    }
}