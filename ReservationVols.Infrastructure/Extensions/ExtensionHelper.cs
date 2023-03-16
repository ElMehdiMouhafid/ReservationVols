using System;
using System.Globalization;

namespace ReservationVols.Infrastructure.Extensions
{
    public static class ExtensionHelper
    {
        public static DateTime ToDateTime(this string value)
            => DateTime.Parse(value, null, DateTimeStyles.AdjustToUniversal);

        public static string ToString(this DateTime? dt, string format)
            => dt is null ? null : ((DateTime)dt).ToString(format);
    }
}
