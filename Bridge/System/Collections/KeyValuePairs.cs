namespace System.Collections
{
    internal class KeyValuePairs
    {
        private object key;
        private object value;

        public KeyValuePairs(object key, object value)
        {
            this.value = value;
            this.key = key;
        }

        public object Key
        {
            get { return key; }
        }

        public object Value
        {
            get { return value; }
        }
    }
}