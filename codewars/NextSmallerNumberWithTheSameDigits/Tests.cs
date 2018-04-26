namespace CodeWars.NextSmallerNumberWithTheSameDigits
{
    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [TestCase(21, ExpectedResult = 12)]
        [TestCase(907, ExpectedResult = 790)]
        [TestCase(531, ExpectedResult = 513)]
        [TestCase(1027, ExpectedResult = -1)]
        [TestCase(441, ExpectedResult = 414)]
        [TestCase(123456798, ExpectedResult = 123456789)]
        [TestCase(29009, ExpectedResult = 20990)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(11, ExpectedResult = -1)]
        public long FixedTests(long n)
        {
            return Kata.NextSmaller(n);
        }
    }
}
