using System.Text;

namespace HelperLib
{
    public static class Helper
    {
        public static string Calculate(this DateTime date, DateTime? dateTo = null)
        {
            date = date.Date;
            DateTime now = (dateTo.HasValue ? dateTo.Value.Date : DateTime.Today).AddDays(1);

            if (date > now)
                throw new ArgumentException(nameof(date));

            int years = now.Year - date.Year,
                months = now.Month - date.Month,
                days = now.Day - date.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(date.Year, date.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            var sb = new StringBuilder();

            if (years > 0) sb.AppendFormat("{0}il ", years);
            if (months > 0) sb.AppendFormat("{0}ay ", months);
            if (days > 0) sb.AppendFormat("{0}gün ", days);

            return sb.ToString().TrimEnd();
        }
    }
}
