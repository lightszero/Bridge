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
    public class Dictionary_Generic_Tests_Values
    {
        protected bool DefaultValueAllowed => true;
        protected bool DuplicateValuesAllowed => true;
        protected bool IsReadOnly => true;

        protected ICollection<string> GenericICollectionFactory()
        {
            return new Dictionary<string, string>().Values;
        }

        protected ICollection<string> GenericICollectionFactory(int count)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            int seed = 13453;
            for (int i = 0; i < count; i++)
                list.Add(CreateT(seed++), CreateT(seed++));
            return list.Values;
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
        public void Dictionary_Generic_ValueCollection_Constructor_NullDictionary()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Assert.Throws<ArgumentNullException>(() => new Dictionary<string, string>.ValueCollection(null));
            }
        }

        [Test]
        public void Dictionary_Generic_ValueCollection_GetEnumerator()
        {
            var data = new int[] { 0, 1, 75 };
            foreach (int count in data)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                int seed = 13453;
                while (dictionary.Count < count)
                    dictionary.Add(CreateT(seed++), CreateT(seed++));
                dictionary.Values.GetEnumerator();
            }
        }
    }

    public class Dictionary_Generic_Tests_Values_AsICollection
    {
        protected bool NullAllowed => true;
        protected bool DuplicateValuesAllowed => true;
        protected bool IsReadOnly => true;
        protected bool Enumerator_Current_UndefinedOperation_Throws => true;
        protected Type ICollection_NonGeneric_CopyTo_ArrayOfEnumType_ThrowType => typeof(ArgumentException);
        protected bool SupportsSerialization => false;

        protected Type ICollection_NonGeneric_CopyTo_IndexLargerThanArrayCount_ThrowType => typeof(ArgumentOutOfRangeException);

        protected ICollection NonGenericICollectionFactory()
        {
            return new Dictionary<string, string>().Values;
        }

        protected ICollection NonGenericICollectionFactory(int count)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            int seed = 13453;
            for (int i = 0; i < count; i++)
                list.Add(CreateT(seed++), CreateT(seed++));
            return list.Values;
        }

        private string CreateT(int seed)
        {
            int stringLength = seed % 10 + 5;
            Random rand = new Random(seed);
            byte[] bytes = new byte[stringLength];
            rand.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        [Test]
        public void Dictionary_Generic_ValueCollection_CopyTo_ExactlyEnoughSpaceInTypeCorrectArray()
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
