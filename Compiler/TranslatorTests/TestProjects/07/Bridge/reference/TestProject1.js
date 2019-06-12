Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";

    define("MyModule", function () {
        var MyModule = { };
        /** @namespace TestProject1 */

        /**
         * @class MyModule.TestProject1.TestClassA
         */
        Bridge.define("TestProject1.TestClassA", {
            $metadata : function () { return {"att":1048576,"a":4,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"GetMyValue","t":8,"pi":[{"n":"i","pt":System.Int32,"ps":0}],"sn":"GetMyValue","rt":System.String,"p":[System.Int32]},{"a":2,"n":"Value1","t":16,"rt":System.Int32,"g":{"a":2,"n":"get_Value1","t":8,"rt":System.Int32,"fg":"Value1","box":function ($v) { return Bridge.box($v, System.Int32);}},"s":{"a":2,"n":"set_Value1","t":8,"p":[System.Int32],"rt":System.Void,"fs":"Value1"},"fn":"Value1"},{"a":1,"backing":true,"n":"<Value1>k__BackingField","t":4,"rt":System.Int32,"sn":"Value1","box":function ($v) { return Bridge.box($v, System.Int32);}}]}; },
            $scope: MyModule,
            $module: "MyModule",
            props: {
                /**
                 * Some property
                 *
                 * @instance
                 * @public
                 * @memberof MyModule.TestProject1.TestClassA
                 * @function Value1
                 * @type number
                 */
                Value1: 0
            },
            methods: {
                /**
                 * GetMyValue method
                 *
                 * @instance
                 * @public
                 * @this MyModule.TestProject1.TestClassA
                 * @memberof MyModule.TestProject1.TestClassA
                 * @param   {number}    i    Number of somethng
                 * @return  {string}         A good string
                 */
                GetMyValue: function (i) {
                    return "";
                }
            }
        });
        Bridge.init();
        return MyModule;
    });

});
