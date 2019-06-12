Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";

    Bridge.define("Test.BridgeIssues.N783.App", {
        $metadata : function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Main1","is":true,"t":8,"sn":"Main1","rt":System.Void}]}; },
        statics: {
            methods: {
                Main1: function () {
                    var base1 = new Test.BridgeIssues.N783.Base();
                    var base2 = new Test.BridgeIssues.N783.Base();

                    // Casting will be ignored
                    var ignore = base1;

                    // Default casting operation
                    var dontIgnore = Bridge.cast(base2, Test.BridgeIssues.N783.DontIgnore);
                }
            }
        }
    });

    Bridge.define("Test.BridgeIssues.N783.Base", {
        $metadata : function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"}]}; }
    });

    Bridge.define("Test.BridgeIssues.N783.DontIgnore", {
        inherits: [Test.BridgeIssues.N783.Base],
        $metadata : function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"}]}; }
    });

    Bridge.define("Test.BridgeIssues.N783.Ignore", {
        inherits: [Test.BridgeIssues.N783.Base],
        $metadata : function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"}]}; }
    });
});

//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAiZmlsZSI6ICJ0ZXN0LmJyaWRnZUlzc3Vlcy5uNzgzLmpzIiwKICAic291cmNlUm9vdCI6ICIiLAogICJzb3VyY2VzIjogWyJCcmlkZ2VJc3N1ZXMvTjc4My5jcyJdLAogICJuYW1lcyI6IFsiIl0sCiAgIm1hcHBpbmdzIjogIjs7Ozs7Ozs7b0JBUVlBLFlBQVlBLElBQUlBO29CQUNoQkEsWUFBWUEsSUFBSUE7OztvQkFHaEJBLGFBQWFBLEFBQVFBOzs7b0JBR3JCQSxpQkFBaUJBLFlBQVlBIiwKICAic291cmNlc0NvbnRlbnQiOiBbInVzaW5nIEJyaWRnZTtcclxuXHJcbm5hbWVzcGFjZSBUZXN0LkJyaWRnZUlzc3Vlcy5ONzgzXHJcbntcclxuICAgIHB1YmxpYyBjbGFzcyBBcHBcclxuICAgIHtcclxuICAgICAgICBwdWJsaWMgc3RhdGljIHZvaWQgTWFpbjEoKVxyXG4gICAgICAgIHtcclxuICAgICAgICAgICAgdmFyIGJhc2UxID0gbmV3IEJhc2UoKTtcclxuICAgICAgICAgICAgdmFyIGJhc2UyID0gbmV3IEJhc2UoKTtcclxuXHJcbiAgICAgICAgICAgIC8vIENhc3Rpbmcgd2lsbCBiZSBpZ25vcmVkXHJcbiAgICAgICAgICAgIHZhciBpZ25vcmUgPSAoSWdub3JlKWJhc2UxO1xyXG5cclxuICAgICAgICAgICAgLy8gRGVmYXVsdCBjYXN0aW5nIG9wZXJhdGlvblxyXG4gICAgICAgICAgICB2YXIgZG9udElnbm9yZSA9IChEb250SWdub3JlKWJhc2UyO1xyXG4gICAgICAgIH1cclxuICAgIH1cclxuXHJcbiAgICBwdWJsaWMgY2xhc3MgQmFzZSB7IH1cclxuXHJcbiAgICBbSWdub3JlQ2FzdF1cclxuICAgIHB1YmxpYyBjbGFzcyBJZ25vcmUgOiBCYXNlIHsgfVxyXG5cclxuICAgIHB1YmxpYyBjbGFzcyBEb250SWdub3JlIDogQmFzZSB7IH1cclxufSJdCn0K
