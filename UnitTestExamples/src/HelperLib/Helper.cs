using System.Text;

namespace HelperLib
{
    public static class Helper
    {
        public static DateDifference Calculate(this DateTime date, DateTime? dateTo = null)
        {
            date = date.Date;
            DateTime now = (dateTo.HasValue ? dateTo.Value.Date : DateTime.Today).AddDays(1);

            if (date > now)
                throw new ArgumentException(nameof(date));

            var result = new DateDifference
            {
                Years = now.Year - date.Year,
                Months = now.Month - date.Month,
                Days = now.Day - date.Day
            };

            if (result.Days < 0)
            {
                result.Months--;
                result.Days += DateTime.DaysInMonth(date.Year, date.Month);
            }

            if (result.Months < 0)
            {
                result.Years--;
                result.Months += 12;
            }
            return result;
        }
    }
}
