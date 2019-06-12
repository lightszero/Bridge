using Bridge.Contract;
using System.Collections.Generic;

namespace Bridge.Translator
{
    public class JsDoc : IJsDoc
    {
        public JsDoc()
        {
            this.Init();
        }

        public List<string> Namespaces
        {
            get;
            set;
        }

        public void Init()
        {
            this.Namespaces = new List<string>();
            this.Callbacks = new List<string>();
        }

        public List<string> Callbacks
        {
            get;
            set;
        }
    }
}