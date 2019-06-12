using Bridge.Test.NUnit;
using System;
using System.Globalization;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures decimal separator character obeys current
    /// culture between string conversions.
    /// </summary>
    [TestFixture(TestNameFormat = "#3934 - {0}")]
    public class Bridge3934
    {
        /// <summary>
        /// Calls individual batches for each type to be tested.
        /// </summary>
        [Test]
        public static void TestConvert()
        {
            TestFloat();
            TestDouble();
            TestDecimal();
        }

        /// <summary>
        /// Tests single precision floating-point conversion with culture set as parameter or as current culture.
        /// Will trigger a failed assertion if an exception is thrown during either conversion test.
        /// </summary>
        public static void TestFloat()
        {
            var oldCulture = CultureInfo.CurrentCulture;

            float back;
            float input = 7.5f;
            string str;

            var convtype = "float";

            // WARNING: GetCultures() here is a stub and corresponds to
            //   .NET's GetCultures(CultureTypes.AllCultures)
            foreach (var culture in CultureInfo.GetCultures())
            {
                var cultureDesc = "\"" + culture.EnglishName + "\" (" + culture.Name + ")";
                try
                {
                    str = input.ToString(culture);
                    back = Convert.ToSingle(str, culture);
                    Assert.AreEqual(input, back,
                        "Decimal separator retained between " + convtype +
                        "-string conversion in specified " +
                        cultureDesc + ".");
                }
                catch (Exception exc)
                {
                    Assert.Fail("Exception thrown while converting between " +
                        convtype + "-string if specified culture is " +
                        cultureDesc + " in conversion calls: " + exc.Message);
                }

                try
                {
                    CultureInfo.CurrentCulture = culture;

                    str = input.ToString();
                    back = Convert.ToSingle(str);
                    Assert.AreEqual(input, back,
                        "Decimal separator retained between " + convtype + "-string conversion in " +
                        cultureDesc + " when set as current culture.");
                }
                catch (Exception exc)
                {
                    Assert.Fail("Exception thrown while converting between " +
                        convtype +
                        "-string when in conversion call if current culture set to " +
                        cultureDesc + ": " + exc.Message);
                }
                finally
                {
                    CultureInfo.CurrentCulture = oldCulture;
                }
            }
        }

        /// <summary>
        /// Tests double precision float-point conversion with culture set as parameter or as current culture.
        /// Will trigger a failed assertion if an exception is thrown during either conversion test.
        /// </summary>
        public static void TestDouble()
        {
            var oldCulture = CultureInfo.CurrentCulture;

            double back;
            double input = 7.5;
            string str;

            var convtype = "double";

            // WARNING: GetCultures() here is a stub and corresponds to
            //   .NET's GetCultures(CultureTypes.AllCultures)
            foreach (var culture in CultureInfo.GetCultures())
            {
                var cultureDesc = "\"" + culture.EnglishName + "\" (" + culture.Name + ")";
                try
                {
                    str = input.ToString(culture);
                    back = Convert.ToDouble(str, culture);
                    Assert.AreEqual(input, back,
                        "Decimal separator retained between " + convtype +
                        "-string conversion in specified " +
                        cultureDesc + ".");
                }
                catch (Exception exc)
                {
                    Assert.Fail("Exception thrown while converting between " +
                        convtype + "-string if specified culture is " +
                        cultureDesc + " in conversion calls: " + exc.Message);
                }

                try
                {
                    CultureInfo.CurrentCulture = culture;

                    str = input.ToString();
                    back = Convert.ToDouble(str);
                    Assert.AreEqual(input, back,
                        "Decimal separator retained between " + convtype + "-string conversion in " +
                        cultureDesc + " when set as current culture.");
                }
                catch (Exception exc)
                {
                    Assert.Fail("Exception thrown while converting between " +
                        convtype +
                        "-string when in conversion call if current culture set to " +
                        cultureDesc + ": " + exc.Message);
                }
                finally
                {
                    CultureInfo.CurrentCulture = oldCulture;
                }
            }
        }

        /// <summary>
        /// Tests decimal conversion with culture set as parameter or as current culture.
        /// Will trigger a failed assertion if an exception is thrown during either conversion test.
        /// </summary>
        public static void TestDecimal()
        {
            var oldCulture = CultureInfo.CurrentCulture;

            decimal back;
            decimal input = 7.5m;
            string str;

            var convtype = "decimal";

            // WARNING: GetCultures() here is a stub and corresponds to
            //   .NET's GetCultures(CultureTypes.AllCultures)
            foreach (var culture in CultureInfo.GetCultures())
            {
                var cultureDesc = "\"" + culture.EnglishName + "\" (" + culture.Name + ")";
                try
                {
                    str = input.ToString(culture);
                    back = Convert.ToDecimal(str, culture);
                    Assert.AreEqual(input, back,
                        "Decimal separator retained between " + convtype +
                        "-string conversion in specified " +
                        cultureDesc + ".");
                }
                catch (Exception exc)
                {
                    Assert.Fail("Exception thrown while converting between " +
                        convtype + "-string if specified culture is " +
                        cultureDesc + " in conversion calls: " + exc.Message);
                }

                try
                {
                    CultureInfo.CurrentCulture = culture;

                    str = input.ToString();
                    back = Convert.ToDecimal(str);
                    Assert.AreEqual(input, back,
                        "Decimal separator retained between " + convtype + "-string conversion in " +
                        cultureDesc + " when set as current culture.");
                }
                catch (Exception exc)
                {
                    Assert.Fail("Exception thrown while converting between " +
                        convtype +
                        "-string when in conversion call if current culture set to " +
                        cultureDesc + ": " + exc.Message);
                }
                finally
                {
                    CultureInfo.CurrentCulture = oldCulture;
                }
            }
        }
    }
}