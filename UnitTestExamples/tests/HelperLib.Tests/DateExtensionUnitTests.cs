using HelperLib.Extensions;

namespace HelperLib.Tests
{
    [TestFixture]
    public class DateExtensionUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("2024-06-25", "1gün")]
        [TestCase("2024-06-01", "25gün")]
        [TestCase("2024-02-26", "4ay")]
        [TestCase("2024-02-01", "4ay 25gün")]
        [TestCase("2021-06-26", "3il")]
        [TestCase("2021-06-15", "3il 11gün")]
        [TestCase("2021-02-15", "3il 4ay 11gün")]
        [TestCase("2024-08-13", "")]
        public void Test_Experience_Calculation(DateTime date, string expectedResult)
        {
            //Arrange
            DateTime dateTo = new DateTime(2024, 06, 25);

            // Act & Assertion
            if (date > dateTo)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    string actualResult = Extension.CalculateExperience(date, dateTo).ToString();
                });
            }
            else
            {
                Assert.DoesNotThrow(() =>
                {
                    string actualResult = Extension.CalculateExperience(date, dateTo).ToString();
                    Assert.That(actualResult, Is.EqualTo(expectedResult));
                });
            }
        }
    }
}