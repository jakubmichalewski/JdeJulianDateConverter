using System;

namespace JdeJulianDateConverter
{
    public static class ExtensionMethods
    {
        public static DateTime JdeJulianToDateTime(this int num)
        {
            var stringifiedJulianDate = num.ToString();
            if (stringifiedJulianDate.Length != 6) 
                throw new Exception("Can't convert Julian Date to Date time, invalid format");

            var baseYear = 1900 + Convert.ToInt32(stringifiedJulianDate.Substring(0, 1)) * 100;
            var year = baseYear + Convert.ToInt32(stringifiedJulianDate.Substring(1, 2));
            var days = Convert.ToInt32(stringifiedJulianDate.Substring(stringifiedJulianDate.Length - 3));
            return new DateTime(year, 1, 1).AddDays(days - 1);
        }
    }
    
    public static string DateTimeToJdeJulian(this DateTime date)
		{
			var stringifiedDate = date.ToString("yyyy-MM-dd");
			var jdeCentury = Convert.ToInt32(stringifiedDate.Substring(0, 2)) - 19;
			string days;
			if (date.DayOfYear < 10)
			{
				days = $"00{date.DayOfYear}";
			}
			else if (date.DayOfYear < 100)
			{
				days = $"0{date.DayOfYear}";
			}
			else
			{
				days = date.DayOfYear.ToString();
			}

			return jdeCentury + stringifiedDate.Substring(2, 2) + days;
		}

}
