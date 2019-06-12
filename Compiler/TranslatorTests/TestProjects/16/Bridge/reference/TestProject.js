Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";

    Bridge.define("Bridge644_With_Name_Attribute", {
        $metadata : function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"DoSomething1","t":8,"sn":"DoSomething1","rt":System.Void},{"a":2,"n":"DoSomething2","t":8,"sn":"DoSomething2","rt":System.Void}]}; },
        methods: {
            DoSomething2: function () { },
            DoSomething1: function () { }
        }
    });

    define("Module1", ["Module2", "Module3", "Module4"], function (Module2, Module3, Module4) {
        var Module1 = { };
        Bridge.define("Module1", {
            $kind: "nested class",
            $metadata : function () { return {"td":Test.BridgeIssues.N3815.N3815,"att":1048962,"a":2,"s":true,"m":[{"a":2,"n":"Test1","is":true,"t":8,"sn":"Test1","rt":System.Void}]}; },
            $scope: Module1,
            $module: "Module1"
        });
        Bridge.init();
        return Module1;
    });

});
