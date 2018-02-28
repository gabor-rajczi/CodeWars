using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CodeWars.LeastCommonMultiple
{
    [TestFixture]
    public class LeastCommonMultipleTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(2, LeastCommonMultiple.Calculate(1, 2));
            Assert.AreEqual(6, LeastCommonMultiple.Calculate(2, 3));
            Assert.AreEqual(12, LeastCommonMultiple.Calculate(3, 4));
            Assert.AreEqual(18, LeastCommonMultiple.Calculate(2, 9));
        }

        [Test]
        public void BasicArrayTests()
        {
            Assert.AreEqual(2, LeastCommonMultiple.Calculate(new [] {1, 2}));
            Assert.AreEqual(6, LeastCommonMultiple.Calculate(new [] {2, 3}));
            Assert.AreEqual(12, LeastCommonMultiple.Calculate(new [] {3, 4}));
            Assert.AreEqual(18, LeastCommonMultiple.Calculate(new [] {2, 9}));
        }

        [Test]
        public void ArrayTests()
        {
            Assert.AreEqual(6, LeastCommonMultiple.Calculate(new[] { 1, 2, 3 }));
            Assert.AreEqual(12, LeastCommonMultiple.Calculate(new[] { 2, 3, 4 }));
            Assert.AreEqual(12, LeastCommonMultiple.Calculate(new[] { 3, 4, 4 }));
            Assert.AreEqual(18, LeastCommonMultiple.Calculate(new[] { 2, 9, 3 }));
        }

        [Test]
        public void LongArrayTests()
        {
            Assert.AreEqual(8*9, LeastCommonMultiple.Calculate(new[] {3, 9, 8, 2, 6, 12}));
        }

        [Test]
        public void ExceptionArrayTests()
        {
            var array = new[] {3};
            ActualValueDelegate<int> testDelegate = () => LeastCommonMultiple.Calculate(array);
            Assert.That(testDelegate, Throws.TypeOf<ArgumentException>());
            array = new int[0];
            Assert.That(testDelegate, Throws.TypeOf<ArgumentException>());
        }
    }
}
