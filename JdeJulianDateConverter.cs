using System;

namespace JdeJulianDateConverter
{
    public static class ExtensionMethods
    {
        public static DateTime JdeJulianToDateTime(this int num)
        {
            var stringifiedJulianDate = num.ToString();
            if (stringifiedJulianDate.Length != 6) throw new Exception("Can't convert Julian Date to Date time, invalid format");
            var baseYear = (stringifiedJulianDate.Substring(0, 1) == "0") ? 1900 : 2000;
            var year = baseYear + Convert.ToInt32(stringifiedJulianDate.Substring(1, 2));
            var days = Convert.ToInt32(stringifiedJulianDate.Substring(stringifiedJulianDate.Length - 3));
            return new DateTime(year, 1, 1).AddDays(days - 1);
        }
    }
}