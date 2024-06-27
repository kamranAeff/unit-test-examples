using HelperLib.Extensions;

namespace HelperLib.Tests
{
    [TestFixture]
    public class TextExtensionUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("c# &&&&& sql", "csharp-and-sql")]
        [TestCase("mongodb &&& express &&&& node.js", "mongodb-and-express-and-node-js")]
        [TestCase("", "")]
        public void Test_ToSlug(string input, string expectedResult)
        {
            // Act & Assertion
            if (string.IsNullOrWhiteSpace(input))
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    string actualResult = input.ToSlug();
                });
            }
            else
            {
                Assert.DoesNotThrow(() =>
                {
                    string actualResult = input.ToSlug();
                    Assert.That(actualResult, Is.EqualTo(expectedResult));
                });
            }
        }

        [TestCase("demo", false)]
        [TestCase("", false)]
        [TestCase("test@", false)]
        [TestCase("test@mail", false)]
        [TestCase("demo@gmail.com", true)]
        [TestCase("test@mail.ru", true)]
        public void Test_IsEmail(string input, bool expectedResult)
        {
            // Act & Assertion
            bool actualResult = input.IsEmail();
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [TestCase("demo", false)]
        [TestCase("0238311111", false)]
        [TestCase("055-831-11-11", true)]
        [TestCase("+99455-831-11-11", true)]
        [TestCase("0558311111", true)]
        [TestCase("+994518311111", true)]
        public void Test_IsMobilePhone(string input, bool expectedResult)
        {
            // Act & Assertion
            bool actualResult = input.IsMobilePhone();
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}