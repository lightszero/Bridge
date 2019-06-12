Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";

    Bridge.define("Test.BridgeIssues.N3891.App", {
        $metadata : function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":1,"n":"byteArray","t":4,"rt":System.Array.type(System.Byte),"sn":"byteArray","ro":true},{"a":1,"n":"byteArrayList","t":4,"rt":System.Collections.Generic.List$1(System.Array.type(System.Byte)),"sn":"byteArrayList","ro":true},{"a":1,"n":"comment","t":4,"rt":System.String,"sn":"comment","ro":true}]}; },
        fields: {
            byteArray: null,
            byteArrayList: null,
            comment: null
        },
        ctors: {
            init: function () {
                this.byteArray = System.Array.init(8, 0, System.Byte);
                this.byteArrayList = new (System.Collections.Generic.List$1(System.Array.type(System.Byte))).ctor();
                this.comment = "The line above should contain 'type(System.Byte)'.";
            }
        }
    });
});
