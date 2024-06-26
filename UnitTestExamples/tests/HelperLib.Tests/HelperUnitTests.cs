namespace HelperLib.Tests
{
    [TestFixture]
    public class HelperUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("2024-06-25", "1g�n")]
        [TestCase("2024-06-01", "25g�n")]
        [TestCase("2024-02-26", "4ay")]
        [TestCase("2024-02-01", "4ay 25g�n")]
        [TestCase("2021-06-26", "3il")]
        [TestCase("2021-06-15", "3il 11g�n")]
        [TestCase("2021-02-15", "3il 4ay 11g�n")]
        [TestCase("2024-08-13", "")]
        public void Test_Experience_Calculation(DateTime date, string expectedResult)
        {
            //Arrange
            DateTime dateTo = new DateTime(2024, 06, 25);

            // Act & Assertion
            if (date > DateTime.Today)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    string actualResult = Helper.Calculate(date, dateTo);
                });
            }
            else
            {
                Assert.DoesNotThrow(() =>
                {
                    string actualResult = Helper.Calculate(date, dateTo);
                    Assert.That(actualResult, Is.EqualTo(expectedResult));
                });
            }
        }
    }
}