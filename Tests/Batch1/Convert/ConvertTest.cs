// The source is licensed to the .NET Foundation under the MIT license:
// https://github.com/dotnet/corefx/blob/master/src/System.Runtime.Extensions/tests/System/Convert.ToDouble.cs
// https://github.com/dotnet/corefx/blob/master/LICENSE

using Bridge.Test.NUnit;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bridge.ClientTest.ConvertTests
{
    [Category(Constants.MODULE_CONVERT)]
    [TestFixture(TestNameFormat = "Convert.ToDouble - {0}")]
    public class ConvertTest
    {
        public class Temperature : IConvertible
        {
            private decimal m_Temp;

            public Temperature(decimal temperature)
            {
                this.m_Temp = temperature;
            }

            public decimal Celsius
            {
                get { return this.m_Temp; }
            }

            public decimal Kelvin
            {
                get { return this.m_Temp + 273.15m; }
            }

            public decimal Fahrenheit
            {
                get { return Math.Round((decimal)(this.m_Temp * 9 / 5 + 32), 2); }
            }

            public override string ToString()
            {
                return m_Temp.ToString("N2") + "°C";
            }

            // IConvertible implementations.
            public TypeCode GetTypeCode()
            {
                return TypeCode.Object;
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                if (m_Temp == 0)
                    return false;
                else
                    return true;
            }

            public byte ToByte(IFormatProvider provider)
            {
                if (m_Temp < Byte.MinValue || m_Temp > Byte.MaxValue)
                    throw new OverflowException(String.Format("{0} is out of range of the Byte type.",
                                                              this.m_Temp));
                else
                    return Decimal.ToByte(this.m_Temp);
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new InvalidCastException("Temperature to Char conversion is not supported.");
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new InvalidCastException("Temperature to DateTime conversion is not supported.");
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                return this.m_Temp;
            }

            public double ToDouble(IFormatProvider provider)
            {
                return Decimal.ToDouble(this.m_Temp);
            }

            public short ToInt16(IFormatProvider provider)
            {
                if (this.m_Temp < Int16.MinValue || this.m_Temp > Int16.MaxValue)
                    throw new OverflowException(String.Format("{0} is out of range of the Int16 type.",
                                                              this.m_Temp));
                else
                    return Decimal.ToInt16(this.m_Temp);
            }

            public int ToInt32(IFormatProvider provider)
            {
                if (this.m_Temp < Int32.MinValue || this.m_Temp > Int32.MaxValue)
                    throw new OverflowException(String.Format("{0} is out of range of the Int32 type.",
                                                              this.m_Temp));
                else
                    return Decimal.ToInt32(this.m_Temp);
            }

            public long ToInt64(IFormatProvider provider)
            {
                if (this.m_Temp < Int64.MinValue || this.m_Temp > Int64.MaxValue)
                    throw new OverflowException(String.Format("{0} is out of range of the Int64 type.",
                                                              this.m_Temp));
                else
                    return Decimal.ToInt64(this.m_Temp);
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                if (this.m_Temp < SByte.MinValue || this.m_Temp > SByte.MaxValue)
                    throw new OverflowException(String.Format("{0} is out of range of the SByte type.",
                                                              this.m_Temp));
                else
                    return Decimal.ToSByte(this.m_Temp);
            }

            public float ToSingle(IFormatProvider provider)
            {
                return Decimal.ToSingle(this.m_Temp);
            }

            public string ToString(IFormatProvider provider)
            {
                return m_Temp.ToString("N2", provider) + "°C";
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                switch (Type.GetTypeCode(conversionType))
                {
                    case TypeCode.Boolean:
                        return this.ToBoolean(null);
                    case TypeCode.Byte:
                        return this.ToByte(null);
                    case TypeCode.Char:
                        return this.ToChar(null);
                    case TypeCode.DateTime:
                        return this.ToDateTime(null);
                    case TypeCode.Decimal:
                        return this.ToDecimal(null);
                    case TypeCode.Double:
                        return this.ToDouble(null);
                    case TypeCode.Int16:
                        return this.ToInt16(null);
                    case TypeCode.Int32:
                        return this.ToInt32(null);
                    case TypeCode.Int64:
                        return this.ToInt64(null);
                    case TypeCode.Object:
                        if (typeof(Temperature).Equals(conversionType))
                            return this;
                        else
                            throw new InvalidCastException(String.Format("Conversion to a {0} is not supported.",
                                                                         conversionType.Name));
                    case TypeCode.SByte:
                        return this.ToSByte(null);
                    case TypeCode.Single:
                        return this.ToSingle(null);
                    case TypeCode.String:
                        return this.ToString(provider);
                    case TypeCode.UInt16:
                        return this.ToUInt16(null);
                    case TypeCode.UInt32:
                        return this.ToUInt32(null);
                    case TypeCode.UInt64:
                        return this.ToUInt64(null);
                    default:
                        throw new InvalidCastException(String.Format("Conversion to {0} is not supported.", conversionType.Name));
                }
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                if (this.m_Temp < UInt16.MinValue || this.m_Temp > UInt16.MaxValue)
                    throw new OverflowException(String.Format("{0} is out of range of the UInt16 type.",
                                                              this.m_Temp));
                else
                    return Decimal.ToUInt16(this.m_Temp);
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                if (this.m_Temp < UInt32.MinValue || this.m_Temp > UInt32.MaxValue)
                    throw new OverflowException(String.Format("{0} is out of range of the UInt32 type.",
                                                              this.m_Temp));
                else
                    return Decimal.ToUInt32(this.m_Temp);
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                if (this.m_Temp < UInt64.MinValue || this.m_Temp > UInt64.MaxValue)
                    throw new OverflowException(String.Format("{0} is out of range of the UInt64 type.",
                                                              this.m_Temp));
                else
                    return Decimal.ToUInt64(this.m_Temp);
            }
        }

        [Test]
        public static void TestBase()
        {
            Double d = -2.345;
            int i = (int)Convert.ChangeType(d, typeof(int));

            Assert.AreEqual(-2, i, "Double -2.345 ChangeType(int) truncated as -2.");

            string s = "12/12/98";
            DateTime dt = (DateTime)Convert.ChangeType(s, typeof(DateTime));

            Assert.AreEqual(new DateTime(1998, 12, 12), dt, "String date ChangeType(DateTime) works.");
        }

        [Test]
        public static void TestTemperature()
        {
            Temperature cool = new Temperature(5);
            Type[] targetTypes = { typeof(SByte), typeof(Int16), typeof(Int32),
                             typeof(Int64), typeof(Byte), typeof(UInt16),
                             typeof(UInt32), typeof(UInt64), typeof(Decimal),
                             typeof(Single), typeof(Double), typeof(String) };
            CultureInfo provider = CultureInfo.CurrentCulture;

            Assert.AreEqual(5, Convert.ChangeType(cool, targetTypes[0], provider),
                "Type change between " + targetTypes[0].ToString() + " and Temperature works.");
            Assert.AreEqual(5, Convert.ChangeType(cool, targetTypes[1], provider),
                "Type change between " + targetTypes[1].ToString() + " and Temperature works.");
            Assert.AreEqual(5, Convert.ChangeType(cool, targetTypes[2], provider),
                "Type change between " + targetTypes[2].ToString() + " and Temperature works.");
            Assert.True(5L == (long)Convert.ChangeType(cool, targetTypes[3], provider),
                "Type change between " + targetTypes[3].ToString() + " and Temperature works.");
            Assert.AreEqual(5, Convert.ChangeType(cool, targetTypes[4], provider),
                "Type change between " + targetTypes[4].ToString() + " and Temperature works.");
            Assert.AreEqual(5, Convert.ChangeType(cool, targetTypes[5], provider),
                "Type change between " + targetTypes[5].ToString() + " and Temperature works.");
            Assert.AreEqual(5, Convert.ChangeType(cool, targetTypes[6], provider),
                "Type change between " + targetTypes[6].ToString() + " and Temperature works.");
            Assert.True(5UL == (ulong)Convert.ChangeType(cool, targetTypes[7], provider),
                "Type change between " + targetTypes[7].ToString() + " and Temperature works.");
            Assert.True(5m == (decimal)Convert.ChangeType(cool, targetTypes[8], provider),
                "Type change between " + targetTypes[8].ToString() + " and Temperature works.");
            Assert.AreEqual(5, Convert.ChangeType(cool, targetTypes[9], provider),
                "Type change between " + targetTypes[9].ToString() + " and Temperature works.");
            Assert.AreEqual(5, Convert.ChangeType(cool, targetTypes[10], provider),
                "Type change between " + targetTypes[10].ToString() + " and Temperature works.");
            Assert.AreEqual("5.00°C", Convert.ChangeType(cool, targetTypes[11], provider),
                "Type change between " + targetTypes[11].ToString() + " and Temperature works.");
        }

        [Test]
        public static void ChangeTypeTest()
        {
            var testValue = 0;
            bool expectedValue = false;
            Assert.AreEqual(expectedValue, Convert.ChangeType(testValue, TypeCode.Boolean), "Convert.ChangeType works between bool and int.");
        }

        public static IEnumerable<object[]> DefaultToTypeValues()
        {
            yield return new object[] { true };
            yield return new object[] { false };
            yield return new object[] { Byte.MinValue };
            yield return new object[] { Byte.MaxValue };
            yield return new object[] { SByte.MinValue };
            yield return new object[] { SByte.MaxValue };
            yield return new object[] { (SByte)0 };
            yield return new object[] { Int16.MinValue };
            yield return new object[] { Int16.MaxValue };
            yield return new object[] { (Int16)0 };
            yield return new object[] { UInt16.MinValue };
            yield return new object[] { UInt16.MaxValue };
            yield return new object[] { Int32.MinValue };
            yield return new object[] { Int32.MaxValue };
            yield return new object[] { (Int32)0 };
            yield return new object[] { UInt32.MinValue };
            yield return new object[] { UInt32.MaxValue };
            yield return new object[] { Int64.MinValue };
            yield return new object[] { Int64.MaxValue };
            yield return new object[] { (Int64)0 };
            yield return new object[] { UInt64.MinValue };
            yield return new object[] { UInt64.MaxValue };
            yield return new object[] { Char.MinValue };
            yield return new object[] { Char.MaxValue };
            yield return new object[] { (Char)0 };
            yield return new object[] { Double.MinValue };
            yield return new object[] { Double.MaxValue };
            yield return new object[] { (Double)0 };
            yield return new object[] { Single.MinValue };
            yield return new object[] { Single.MaxValue };
            yield return new object[] { (Single)0 };
            yield return new object[] { Decimal.MinValue };
            yield return new object[] { Decimal.MaxValue };
            yield return new object[] { (Decimal)0 };
            yield return new object[] { DateTime.MinValue };
            yield return new object[] { DateTime.Now };
            yield return new object[] { DateTime.MaxValue };
        }

        [Test]
        public static void ChangeTypeIdentity()
        {
            foreach (var item in DefaultToTypeValues())
            {
                object testValue = item[0];
                object copy = GetBoxedCopy(testValue);
                Assert.AreEqual(testValue, copy, "Type identity change works.");
            }
        }

        public static object GetBoxedCopy(object obj)
        {
            Type type = obj.GetType();
            if (type == typeof(Boolean))
                return Convert.ChangeType(obj, typeof(Boolean));
            else if (type == typeof(Byte))
                return Convert.ChangeType(obj, typeof(Byte));
            else if (type == typeof(SByte))
                return Convert.ChangeType(obj, typeof(SByte));
            else if (type == typeof(Int16))
                return Convert.ChangeType(obj, typeof(Int16));
            else if (type == typeof(Int32))
                return Convert.ChangeType(obj, typeof(Int32));
            else if (type == typeof(Int64))
                return Convert.ChangeType(obj, typeof(Int64));
            else if (type == typeof(UInt16))
                return Convert.ChangeType(obj, typeof(UInt16));
            else if (type == typeof(UInt32))
                return Convert.ChangeType(obj, typeof(UInt32));
            else if (type == typeof(UInt64))
                return Convert.ChangeType(obj, typeof(UInt64));
            else if (type == typeof(Char))
                return Convert.ChangeType(obj, typeof(Char));
            else if (type == typeof(Double))
                return Convert.ChangeType(obj, typeof(Double));
            else if (type == typeof(Single))
                return Convert.ChangeType(obj, typeof(Single));
            else if (type == typeof(Decimal))
                return Convert.ChangeType(obj, typeof(Decimal));
            else
                return obj;
        }
    }
}