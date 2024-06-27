namespace HelperLib.Models
{
    public class DateDifference
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public override string ToString()
        {
            return $"{(Years > 0 ? $"{Years}il " : "")}{(Months > 0 ? $"{Months}ay " : "")}{(Days > 0 ? $"{Days}gün" : "")}".TrimEnd();
        }
    }
}
