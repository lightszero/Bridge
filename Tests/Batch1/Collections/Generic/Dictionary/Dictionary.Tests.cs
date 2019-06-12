using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Collections.Generic.Dictionary
{
    public class Dictionary_Tests
    {
        [Test]
        public void CopyConstructorExceptions()
        {
            Assert.Throws<ArgumentNullException>(() => new Dictionary<int, int>((IDictionary<int, int>)null));
            Assert.Throws<ArgumentNullException>(() => new Dictionary<int, int>((IDictionary<int, int>)null, null));
            Assert.Throws<ArgumentNullException>(() => new Dictionary<int, int>((IDictionary<int, int>)null, EqualityComparer<int>.Default));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Dictionary<int, int>(new NegativeCountDictionary<int, int>()));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Dictionary<int, int>(new NegativeCountDictionary<int, int>(), null));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Dictionary<int, int>(new NegativeCountDictionary<int, int>(), EqualityComparer<int>.Default));
        }

        [Test]
        public void ICollection_NonGeneric_CopyTo_NonContiguousDictionary()
        {
            int[] data = new int[] { 0, 1, 101};
            foreach (var count in data)
            {
                ICollection collection = (ICollection)CreateDictionary(count, k => k.ToString());
                KeyValuePair<string, string>[] array = new KeyValuePair<string, string>[count];
                collection.CopyTo(array, 0);
                int i = 0;
                foreach (object obj in collection)
                    Assert.AreEqual(array[i++], obj);
            }
        }

        [Test]
        public void ICollection_Generic_CopyTo_NonContiguousDictionary()
        {
            int[] data = new int[] { 0, 1, 101 };

            foreach (var count in data)
            {
                ICollection<KeyValuePair<string, string>> collection = CreateDictionary(count, k => k.ToString());
                KeyValuePair<string, string>[] array = new KeyValuePair<string, string>[count];
                collection.CopyTo(array, 0);
                int i = 0;
                foreach (KeyValuePair<string, string> obj in collection)
                    Assert.AreEqual(array[i++], obj);
            }
        }

        [Test]
        public void IDictionary_Generic_CopyTo_NonContiguousDictionary()
        {
            int[] data = new int[] { 0, 1, 101 };

            foreach (var count in data)
            {
                IDictionary<string, string> collection = CreateDictionary(count, k => k.ToString());
                KeyValuePair<string, string>[] array = new KeyValuePair<string, string>[count];
                collection.CopyTo(array, 0);
                int i = 0;
                foreach (KeyValuePair<string, string> obj in collection)
                    Assert.AreEqual(array[i++], obj);
            }
        }

        [Test]
        public void CopyTo_NonContiguousDictionary()
        {
            int[] data = new int[] { 0, 1, 101 };

            foreach (var count in data)
            {
                Dictionary<string, string> collection = (Dictionary<string, string>)CreateDictionary(count, k => k.ToString());
                string[] array = new string[count];
                collection.Keys.CopyTo(array, 0);
                int i = 0;
                foreach (KeyValuePair<string, string> obj in collection)
                    Assert.AreEqual(array[i++], obj.Key);

                collection.Values.CopyTo(array, 0);
                i = 0;
                foreach (KeyValuePair<string, string> obj in collection)
                    Assert.AreEqual(array[i++], obj.Key);
            }
        }

        [Test]
        public void Remove_NonExistentEntries_DoesNotPreventEnumeration()
        {
            const string SubKey = "-sub-key";
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("a", "b");
            dictionary.Add("c", "d");
            foreach (string key in dictionary.Keys)
            {
                if (dictionary.Remove(key + SubKey))
                    break;
            }

            dictionary.Add("c" + SubKey, "d");
            foreach (string key in dictionary.Keys)
            {
                if (dictionary.Remove(key + SubKey))
                    break;
            }
        }

        [Test]
        public void TryAdd_ItemAlreadyExists_DoesNotInvalidateEnumerator()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("a", "b");

            IEnumerator valuesEnum = dictionary.GetEnumerator();
            Assert.False(dictionary.TryAdd("a", "c"));

            Assert.True(valuesEnum.MoveNext());
        }

        [Test]
        public void CopyConstructorInt32()
        {
            foreach (var item in CopyConstructorInt32Data)
            {
                int size = (int)item[0];
                Func<int, int> keyValueSelector = (Func<int, int>)item[1];
                Func<IDictionary<int, int>, IDictionary<int, int>> dictionarySelector = (Func<IDictionary<int, int>, IDictionary<int, int>>)item[2];

                TestCopyConstructor(size, keyValueSelector, dictionarySelector);
            }
        }

        public static IEnumerable<object[]> CopyConstructorInt32Data
        {
            get { return GetCopyConstructorData(i => i); }
        }

        [Test]
        public void CopyConstructorString()
        {
            foreach (var item in CopyConstructorStringData)
            {
                int size = (int)item[0];
                Func<int, string> keyValueSelector = (Func<int, string>)item[1];
                Func<IDictionary<string, string>, IDictionary<string, string>> dictionarySelector = (Func<IDictionary<string, string>, IDictionary<string, string>>)item[2];

                TestCopyConstructor(size, keyValueSelector, dictionarySelector);
            }
        }

        public static IEnumerable<object[]> CopyConstructorStringData
        {
            get { return GetCopyConstructorData(i => i.ToString()); }
        }

        private static void TestCopyConstructor<T>(int size, Func<int, T> keyValueSelector, Func<IDictionary<T, T>, IDictionary<T, T>> dictionarySelector)
        {
            IDictionary<T, T> expected = CreateDictionary(size, keyValueSelector);
            IDictionary<T, T> input = dictionarySelector(CreateDictionary(size, keyValueSelector));

            Assert.AreEqual(expected, new Dictionary<T, T>(input));
        }

        [Test]
        public void CopyConstructorInt32Comparer()
        {
            foreach (var item in CopyConstructorInt32ComparerData)
            {
                int size = (int)item[0];
                Func<int, int> keyValueSelector = (Func<int, int>)item[1];
                Func<IDictionary<int, int>, IDictionary<int, int>> dictionarySelector = (Func<IDictionary<int, int>, IDictionary<int, int>>)item[2];
                IEqualityComparer<int> comparer = (IEqualityComparer<int>)item[3];

                TestCopyConstructor(size, keyValueSelector, dictionarySelector, comparer);
            }
        }

        public static IEnumerable<object[]> CopyConstructorInt32ComparerData
        {
            get
            {
                var comparers = new IEqualityComparer<int>[]
                {
                    null,
                    EqualityComparer<int>.Default
                };

                return GetCopyConstructorData(i => i, comparers);
            }
        }

        [Test]
        public void CopyConstructorStringComparer()
        {
            foreach (var item in CopyConstructorStringComparerData)
            {
                int size = (int)item[0];
                Func<int, string> keyValueSelector = (Func<int, string>)item[1];
                Func<IDictionary<string, string>, IDictionary<string, string>> dictionarySelector = (Func<IDictionary<string, string>, IDictionary<string, string>>)item[2];
                IEqualityComparer<string> comparer = (IEqualityComparer<string>)item[3];

                TestCopyConstructor(size, keyValueSelector, dictionarySelector, comparer);
            }
        }

        [Test]
        public void CantAcceptDuplicateKeysFromSourceDictionary()
        {
            Dictionary<string, int> source = new Dictionary<string, int> { { "a", 1 }, { "A", 1 } };
            Assert.Throws<ArgumentException>(() => new Dictionary<string, int>(source, StringComparer.OrdinalIgnoreCase));
        }

        public static IEnumerable<object[]> CopyConstructorStringComparerData
        {
            get
            {
                var comparers = new IEqualityComparer<string>[]
                {
                    null,
                    EqualityComparer<string>.Default,
                    StringComparer.Ordinal,
                    StringComparer.OrdinalIgnoreCase
                };

                return GetCopyConstructorData(i => i.ToString(), comparers);
            }
        }

        private static void TestCopyConstructor<T>(int size, Func<int, T> keyValueSelector, Func<IDictionary<T, T>, IDictionary<T, T>> dictionarySelector, IEqualityComparer<T> comparer)
        {
            IDictionary<T, T> expected = CreateDictionary(size, keyValueSelector, comparer);
            IDictionary<T, T> input = dictionarySelector(CreateDictionary(size, keyValueSelector, comparer));

            Assert.AreEqual(expected, new Dictionary<T, T>(input, comparer));
        }

        private static IEnumerable<object[]> GetCopyConstructorData<T>(Func<int, T> keyValueSelector, IEqualityComparer<T>[] comparers = null)
        {
            var dictionarySelectors = new Func<IDictionary<T, T>, IDictionary<T, T>>[]
            {
                d => d,
                d => new DictionarySubclass<T, T>(d),
                d => new ReadOnlyDictionary<T, T>(d)
            };

            var sizes = new int[] { 0, 1, 2, 3 };

            foreach (Func<IDictionary<T, T>, IDictionary<T, T>> dictionarySelector in dictionarySelectors)
            {
                foreach (int size in sizes)
                {
                    if (comparers != null)
                    {
                        foreach (IEqualityComparer<T> comparer in comparers)
                        {
                            yield return new object[] { size, keyValueSelector, dictionarySelector, comparer };
                        }
                    }
                    else
                    {
                        yield return new object[] { size, keyValueSelector, dictionarySelector };
                    }
                }
            }
        }

        private static IDictionary<T, T> CreateDictionary<T>(int size, Func<int, T> keyValueSelector, IEqualityComparer<T> comparer = null)
        {
            Dictionary<T, T> dict = Enumerable.Range(0, size + 1).ToDictionary(keyValueSelector, keyValueSelector, comparer);
            // Remove first item to reduce Count to size and alter the contiguity of the dictionary
            dict.Remove(keyValueSelector(0));
            return dict;
        }

        private sealed class DictionarySubclass<TKey, TValue> : Dictionary<TKey, TValue>
        {
            public DictionarySubclass(IDictionary<TKey, TValue> dictionary)
            {
                foreach (var pair in dictionary)
                {
                    Add(pair.Key, pair.Value);
                }
            }
        }

        /// <summary>
        /// An incorrectly implemented dictionary that returns -1 from Count.
        /// </summary>
        private sealed class NegativeCountDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        {
            public int Count { get { return -1; } }

            public TValue this[TKey key] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool IsReadOnly { get { throw new NotImplementedException(); } }
            public ICollection<TKey> Keys { get { throw new NotImplementedException(); } }
            public ICollection<TValue> Values { get { throw new NotImplementedException(); } }
            public void Add(KeyValuePair<TKey, TValue> item) { throw new NotImplementedException(); }
            public void Add(TKey key, TValue value) { throw new NotImplementedException(); }
            public void Clear() { throw new NotImplementedException(); }
            public bool Contains(KeyValuePair<TKey, TValue> item) { throw new NotImplementedException(); }
            public bool ContainsKey(TKey key) { throw new NotImplementedException(); }
            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { throw new NotImplementedException(); }
            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() { throw new NotImplementedException(); }
            public bool Remove(KeyValuePair<TKey, TValue> item) { throw new NotImplementedException(); }
            public bool Remove(TKey key) { throw new NotImplementedException(); }
            public bool TryGetValue(TKey key, out TValue value) { throw new NotImplementedException(); }
            IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
        }
    }
}
