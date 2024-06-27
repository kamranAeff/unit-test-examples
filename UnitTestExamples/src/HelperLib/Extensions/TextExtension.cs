using System.Text.RegularExpressions;

namespace HelperLib.Extensions
{
    public static partial class Extension
    {
        public static string ToSlug(this string context)
        {
            if (string.IsNullOrWhiteSpace(context))
                throw new ArgumentNullException(nameof(context));

            var replaceSet = new Dictionary<string, string>() {
                {"Ü|ü", "u"},
                {"İ|I|ı", "i"},
                {"Ş|ş", "s"},
                {"Ö|ö", "o"},
                {"Ç|ç", "c"},
                {"Ğ|ğ", "g"},
                {"Ə|ə", "e"},
                {"#+", "sharp"},
                {@"(\?|/|\|\.|'|`|%|\*|!|@|\+)+", ""},
                {@"\&+", "and"},
                {@"[^a-z0-9]+", "-"},
                };

            return replaceSet.Aggregate(context, (i, m) => Regex.Replace(i, m.Key, m.Value, RegexOptions.IgnoreCase))
                .ToLower();
        }

        public static bool IsEmail(this string value)
        {
            return Regex.IsMatch(value, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsMobilePhone(this string value)
        {
            return Regex.IsMatch(value, @"^(\+994|0)(50|51|55|70|77|99|10)((-\d{3}-\d{2}-\d{2})|(\d{7}))$");
        }
    }
}
