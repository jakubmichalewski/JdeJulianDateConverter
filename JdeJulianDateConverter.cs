using System;

namespace JdeJulianDateConverter
{
    public static class ExtensionMethods
    {
        public static DateTime JdeJulianToDateTime(this int num)
        {
            var baseYear = (num.ToString().Substring(0, 1) == "0") ? 1900 : 2000;
            var year = baseYear + Convert.ToInt32(num.ToString().Substring(1, 2));
            var days = Convert.ToInt32(num.ToString().Substring(num.ToString().Length - 3));
            return new DateTime(year, 1, 1).AddDays(days - 1);
        }
    }
}