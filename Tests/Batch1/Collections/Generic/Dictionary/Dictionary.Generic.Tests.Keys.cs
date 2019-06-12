// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Collections.Generic.Dictionary
{
    public class Dictionary_Generic_Tests_Keys
    {
        protected bool DefaultValueAllowed => false;
        protected bool DuplicateValuesAllowed => false;
        protected bool IsReadOnly => true;
        protected ICollection<string> GenericICollectionFactory()
        {
            return new Dictionary<string, string>().Keys;
        }

        protected ICollection<string> GenericICollectionFactory(int count)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            int seed = 13453;
            for (int i = 0; i < count; i++)
                list.Add(CreateT(seed++), CreateT(seed++));
            return list.Keys;
        }

        protected string CreateT(int seed)
        {
            int stringLength = seed % 10 + 5;
            Random rand = new Random(seed);
            byte[] bytes = new byte[stringLength];
            rand.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        protected Type ICollection_Generic_CopyTo_IndexLargerThanArrayCount_ThrowType => typeof(ArgumentOutOfRangeException);

        [Test]
        public void Dictionary_Generic_KeyCollection_Constructor_NullDictionary()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Assert.Throws<ArgumentNullException>(() => new Dictionary<string, string>.KeyCollection(null));
            }
        }

        [Test]
        public void Dictionary_Generic_KeyCollection_GetEnumerator()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                int seed = 13453;
                while (dictionary.Count < count)
                    dictionary.Add(CreateT(seed++), CreateT(seed++));
                dictionary.Keys.GetEnumerator();
            }
        }
    }

    public class Dictionary_Generic_Tests_Keys_AsICollection
    {
        protected bool NullAllowed => false;
        protected bool DuplicateValuesAllowed => false;
        protected bool IsReadOnly => true;
        protected bool Enumerator_Current_UndefinedOperation_Throws => true;
        protected Type ICollection_NonGeneric_CopyTo_ArrayOfEnumType_ThrowType => typeof(ArgumentException);
        protected bool SupportsSerialization => false;

        protected Type ICollection_NonGeneric_CopyTo_IndexLargerThanArrayCount_ThrowType => typeof(ArgumentOutOfRangeException);

        protected ICollection NonGenericICollectionFactory()
        {
            return new Dictionary<string, string>().Keys;
        }

        protected ICollection NonGenericICollectionFactory(int count)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            int seed = 13453;
            for (int i = 0; i < count; i++)
                list.Add(CreateT(seed++), CreateT(seed++));
            return list.Keys;
        }

        private string CreateT(int seed)
        {
            int stringLength = seed % 10 + 5;
            Random rand = new Random(seed);
            byte[] bytes = new byte[stringLength];
            rand.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        protected void AddToCollection(ICollection collection, int numberOfItemsToAdd)
        {
            Debug.Assert(false);
        }

        [Test]
        public void Dictionary_Generic_KeyCollection_CopyTo_ExactlyEnoughSpaceInTypeCorrectArray()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                ICollection collection = NonGenericICollectionFactory(count);
                string[] array = new string[count];
                collection.CopyTo(array, 0);
                int i = 0;
                foreach (object obj in collection)
                    Assert.AreEqual(array[i++], obj);
            }
        }
    }
}
