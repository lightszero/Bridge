using System;
using System.Threading.Tasks;

namespace Test.BridgeIssues.N3745
{
    /// <summary>
    /// #3745 ensure an extra variable definition line is not output when using
    /// implicit functions code (not confirmed) C#7 syntax.
    /// </summary>
    public class N3745
    {
        public static Action<Task<object>> f3(Func<Task<object>> f1)
        {
            //@ // p1 below shouldn't show in both function argument
            //@ // and variables declaration.
            return async p1 =>
            {
                p1 = null;

                await f1();
                return;
            };
        }
    }
}
