namespace SmartClinicalSystem.Core.Helpers
{
    public static class DateFormatHelper
    {
        public static string ToStandardDateFormat(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static DateTime ParseToDateTime(string dateString)
        {
            var dateFormats = new[] { "dd-MM-yyyy", "dd/MM/yyyy", "yyyy-MM-dd" };

            if (DateTime.TryParseExact(
                    dateString,
                    dateFormats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out var parsedDate))
            {
                return parsedDate;
            }
            else
            {
                throw new FormatException(
                    $"Invalid date format: '{dateString}'. " +
                    "Use one of: dd-MM-yyyy, dd/MM/yyyy, yyyy-MM-dd.");
            }
        }
    }
}
