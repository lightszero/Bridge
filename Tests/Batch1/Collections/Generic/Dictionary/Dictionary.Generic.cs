using Bridge.Test.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bridge.ClientTest.Collections.Generic.Dictionary
{
    public partial class Dictionary_Generic_Tests_string_string
    {
        protected virtual IEnumerable<KeyValuePair<string, string>> InvalidValues => new KeyValuePair<string, string>[0];

        protected void AddToCollection(ICollection<KeyValuePair<string, string>> collection, int numberOfItemsToAdd)
        {
            int seed = 12353;
            IDictionary<string, string> casted = (IDictionary<string, string>)collection;
            int initialCount = casted.Count;
            while ((casted.Count - initialCount) < numberOfItemsToAdd)
            {
                KeyValuePair<string, string> toAdd = CreateT(seed++);
                while (casted.ContainsKey(toAdd.Key) || Enumerable.Contains(InvalidValues, toAdd))
                    toAdd = CreateT(seed++);
                collection.Add(toAdd);
            }
        }

        protected virtual IDictionary<string, string> GenericIDictionaryFactory(int count)
        {
            IDictionary<string, string> collection = GenericIDictionaryFactory();
            AddToCollection(collection, count);
            return collection;
        }

        public virtual IEqualityComparer<string> GetKeyIEqualityComparer()
        {
            return EqualityComparer<string>.Default;
        }

        #region IDictionary<string, string Helper Methods

        protected IDictionary<string, string> GenericIDictionaryFactory()
        {
            return new Dictionary<string, string>();
        }

        protected Type ICollection_Generic_CopyTo_IndexLargerThanArrayCount_ThrowType => typeof(ArgumentOutOfRangeException);

        #endregion

        #region Constructors

        [Test]
        public void Dictionary_Generic_Constructor_IDictionary()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IDictionary<string, string> source = GenericIDictionaryFactory(count);
                IDictionary<string, string> copied = new Dictionary<string, string>(source);
                Assert.AreEqual(source, copied);
            }
        }

        [Test]
        public void Dictionary_Generic_Constructor_IDictionary_IEqualityComparer()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IEqualityComparer<string> comparer = GetKeyIEqualityComparer();
                IDictionary<string, string> source = GenericIDictionaryFactory(count);
                Dictionary<string, string> copied = new Dictionary<string, string>(source, comparer);
                Assert.AreEqual(source, copied);
                Assert.AreEqual(comparer, copied.Comparer);
            }
        }

        [Test]
        public void Dictionary_Generic_Constructor_IEqualityComparer()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IEqualityComparer<string> comparer = GetKeyIEqualityComparer();
                IDictionary<string, string> source = GenericIDictionaryFactory(count);
                Dictionary<string, string> copied = new Dictionary<string, string>(source, comparer);
                Assert.AreEqual(source, copied);
                Assert.AreEqual(comparer, copied.Comparer);
            }
        }

        [Test]
        public void Dictionary_Generic_Constructor_int()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IDictionary<string, string> dictionary = new Dictionary<string, string>(count);
                Assert.AreEqual(0, dictionary.Count);
            }
        }

        [Test]
        public void Dictionary_Generic_Constructor_int_IEqualityComparer()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IEqualityComparer<string> comparer = GetKeyIEqualityComparer();
                Dictionary<string, string> dictionary = new Dictionary<string, string>(count, comparer);
                Assert.AreEqual(0, dictionary.Count);
                Assert.AreEqual(comparer, dictionary.Comparer);
            }
        }

        #endregion

        #region ContainsValue

        [Test]
        public void Dictionary_Generic_ContainsValue_NotPresent()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<string, string> dictionary = (Dictionary<string, string>)GenericIDictionaryFactory(count);
                int seed = 4315;
                string notPresent = CreateTValue(seed++);
                while (dictionary.Values.Contains(notPresent))
                    notPresent = CreateTValue(seed++);
                Assert.False(dictionary.ContainsValue(notPresent));
            }
        }

        [Test]
        public void Dictionary_Generic_ContainsValue_Present()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<string, string> dictionary = (Dictionary<string, string>)GenericIDictionaryFactory(count);
                int seed = 4315;
                KeyValuePair<string, string> notPresent = CreateT(seed++);
                while (dictionary.Contains(notPresent))
                    notPresent = CreateT(seed++);
                dictionary.Add(notPresent.Key, notPresent.Value);
                Assert.True(dictionary.ContainsValue(notPresent.Value));
            }
        }

        [Test]
        public void Dictionary_Generic_ContainsValue_DefaultValueNotPresent()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<string, string> dictionary = (Dictionary<string, string>)GenericIDictionaryFactory(count);
                Assert.False(dictionary.ContainsValue(default(string)));
            }
        }

        [Test]
        public void Dictionary_Generic_ContainsValue_DefaultValuePresent()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<string, string> dictionary = (Dictionary<string, string>)GenericIDictionaryFactory(count);
                int seed = 4315;
                string notPresent = CreateTKey(seed++);
                while (dictionary.ContainsKey(notPresent))
                    notPresent = CreateTKey(seed++);
                dictionary.Add(notPresent, default(string));
                Assert.True(dictionary.ContainsValue(default(string)));
            }
        }

        #endregion

        #region IReadOnlyDictionary<string, string>.Keys

        [Test]
        public void IReadOnlyDictionary_Generic_Keys_ContainsAllCorrectKeys()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IDictionary<string, string> dictionary = GenericIDictionaryFactory(count);
                IEnumerable<string> expected = dictionary.Select((pair) => pair.Key);
                IEnumerable<string> keys = ((IReadOnlyDictionary<string, string>)dictionary).Keys;
                Assert.True(expected.SequenceEqual(keys));
            }
        }

        [Test]
        public void IReadOnlyDictionary_Generic_Values_ContainsAllCorrectValues()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IDictionary<string, string> dictionary = GenericIDictionaryFactory(count);
                IEnumerable<string> expected = dictionary.Select((pair) => pair.Value);
                IEnumerable<string> values = ((IReadOnlyDictionary<string, string>)dictionary).Values;
                Assert.True(expected.SequenceEqual(values));
            }
        }

        #endregion

        protected KeyValuePair<string, string> CreateT(int seed)
        {
            return new KeyValuePair<string, string>(CreateTKey(seed), CreateTKey(seed + 500));
        }

        protected string CreateTKey(int seed)
        {
            int stringLength = seed % 10 + 5;
            Random rand = new Random(seed);
            byte[] bytes1 = new byte[stringLength];
            rand.NextBytes(bytes1);
            return Convert.ToBase64String(bytes1);
        }

        protected string CreateTValue(int seed) => CreateTKey(seed);
    }

    public class Dictionary_Generic_Tests_int_int
    {
        protected virtual IEnumerable<KeyValuePair<int, int>> InvalidValues => new KeyValuePair<int, int>[0];

        protected void AddToCollection(ICollection<KeyValuePair<int, int>> collection, int numberOfItemsToAdd)
        {
            int seed = 12353;
            IDictionary<int, int> casted = (IDictionary<int, int>)collection;
            int initialCount = casted.Count;
            while ((casted.Count - initialCount) < numberOfItemsToAdd)
            {
                KeyValuePair<int, int> toAdd = CreateT(seed++);
                while (casted.ContainsKey(toAdd.Key) || Enumerable.Contains(InvalidValues, toAdd))
                    toAdd = CreateT(seed++);
                collection.Add(toAdd);
            }
        }

        protected virtual IDictionary<int, int> GenericIDictionaryFactory(int count)
        {
            IDictionary<int, int> collection = GenericIDictionaryFactory();
            AddToCollection(collection, count);
            return collection;
        }

        public virtual IEqualityComparer<int> GetKeyIEqualityComparer()
        {
            return EqualityComparer<int>.Default;
        }

        #region IDictionary<int, int Helper Methods

        protected IDictionary<int, int> GenericIDictionaryFactory()
        {
            return new Dictionary<int, int>();
        }

        protected Type ICollection_Generic_CopyTo_IndexLargerThanArrayCount_ThrowType => typeof(ArgumentOutOfRangeException);

        #endregion

        #region Constructors

        [Test]
        public void Dictionary_Generic_Constructor_IDictionary()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IDictionary<int, int> source = GenericIDictionaryFactory(count);
                IDictionary<int, int> copied = new Dictionary<int, int>(source);
                Assert.AreEqual(source, copied);
            }
        }

        [Test]
        public void Dictionary_Generic_Constructor_IDictionary_IEqualityComparer()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IEqualityComparer<int> comparer = GetKeyIEqualityComparer();
                IDictionary<int, int> source = GenericIDictionaryFactory(count);
                Dictionary<int, int> copied = new Dictionary<int, int>(source, comparer);
                Assert.AreEqual(source, copied);
                Assert.AreEqual(comparer, copied.Comparer);
            }
        }

        [Test]
        public void Dictionary_Generic_Constructor_IEqualityComparer()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IEqualityComparer<int> comparer = GetKeyIEqualityComparer();
                IDictionary<int, int> source = GenericIDictionaryFactory(count);
                Dictionary<int, int> copied = new Dictionary<int, int>(source, comparer);
                Assert.AreEqual(source, copied);
                Assert.AreEqual(comparer, copied.Comparer);
            }
        }

        [Test]
        public void Dictionary_Generic_Constructor_int()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IDictionary<int, int> dictionary = new Dictionary<int, int>(count);
                Assert.AreEqual(0, dictionary.Count);
            }
        }

        [Test]
        public void Dictionary_Generic_Constructor_int_IEqualityComparer()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IEqualityComparer<int> comparer = GetKeyIEqualityComparer();
                Dictionary<int, int> dictionary = new Dictionary<int, int>(count, comparer);
                Assert.AreEqual(0, dictionary.Count);
                Assert.AreEqual(comparer, dictionary.Comparer);
            }
        }

        #endregion

        #region ContainsValue

        [Test]
        public void Dictionary_Generic_ContainsValue_NotPresent()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<int, int> dictionary = (Dictionary<int, int>)GenericIDictionaryFactory(count);
                int seed = 4315;
                int notPresent = CreateTValue(seed++);
                while (dictionary.Values.Contains(notPresent))
                    notPresent = CreateTValue(seed++);
                Assert.False(dictionary.ContainsValue(notPresent));
            }
        }

        [Test]
        public void Dictionary_Generic_ContainsValue_Present()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<int, int> dictionary = (Dictionary<int, int>)GenericIDictionaryFactory(count);
                int seed = 4315;
                KeyValuePair<int, int> notPresent = CreateT(seed++);
                while (dictionary.Contains(notPresent))
                    notPresent = CreateT(seed++);
                dictionary.Add(notPresent.Key, notPresent.Value);
                Assert.True(dictionary.ContainsValue(notPresent.Value));
            }
        }

        [Test]
        public void Dictionary_Generic_ContainsValue_DefaultValueNotPresent()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<int, int> dictionary = (Dictionary<int, int>)GenericIDictionaryFactory(count);
                Assert.False(dictionary.ContainsValue(default(int)));
            }
        }

        [Test]
        public void Dictionary_Generic_ContainsValue_DefaultValuePresent()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<int, int> dictionary = (Dictionary<int, int>)GenericIDictionaryFactory(count);
                int seed = 4315;
                int notPresent = CreateTKey(seed++);
                while (dictionary.ContainsKey(notPresent))
                    notPresent = CreateTKey(seed++);
                dictionary.Add(notPresent, default(int));
                Assert.True(dictionary.ContainsValue(default(int)));
            }
        }

        #endregion

        #region IReadOnlyDictionary<int, int>.Keys

        [Test]
        public void IReadOnlyDictionary_Generic_Keys_ContainsAllCorrectKeys()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IDictionary<int, int> dictionary = GenericIDictionaryFactory(count);
                IEnumerable<int> expected = dictionary.Select((pair) => pair.Key);
                IEnumerable<int> keys = ((IReadOnlyDictionary<int, int>)dictionary).Keys;
                Assert.True(expected.SequenceEqual(keys));
            }
        }

        [Test]
        public void IReadOnlyDictionary_Generic_Values_ContainsAllCorrectValues()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                IDictionary<int, int> dictionary = GenericIDictionaryFactory(count);
                IEnumerable<int> expected = dictionary.Select((pair) => pair.Value);
                IEnumerable<int> values = ((IReadOnlyDictionary<int, int>)dictionary).Values;
                Assert.True(expected.SequenceEqual(values));
            }
        }

        #endregion

        protected bool DefaultValueAllowed => true;

        protected KeyValuePair<int, int> CreateT(int seed)
        {
            Random rand = new Random(seed);
            return new KeyValuePair<int, int>(rand.Next(), rand.Next());
        }

        protected int CreateTKey(int seed)
        {
            Random rand = new Random(seed);
            return rand.Next();
        }

        protected int CreateTValue(int seed) => CreateTKey(seed);
    }
}
