Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";

    require(["Module1"], function (Mod1) {
        /** @namespace Test.BridgeIssues.N3815 */
    
        /**
         * #3815 Ensures multiple ModuleDependency attributes works.
         *
         * @public
         * @class Test.BridgeIssues.N3815.N3815
         */
        Bridge.define("Test.BridgeIssues.N3815.N3815", {
            $metadata : function () { return {"nested":[Module1],"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"}]}; }
        });
        Bridge.init();
    });
});
