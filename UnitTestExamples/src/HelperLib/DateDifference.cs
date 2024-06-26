namespace HelperLib
{
    public class DateDifference
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public override string ToString()
        {
            return $"{(this.Years > 0 ? $"{this.Years}il " : "")}{(this.Months > 0 ? $"{this.Months}ay " : "")}{(this.Days > 0 ? $"{this.Days}gün" : "")}".TrimEnd();
        }
    }
}
