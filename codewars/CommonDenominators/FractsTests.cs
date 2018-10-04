namespace CodeWars.CommonDenominators
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class FractsTests
    {

        [Test]
        public void Test1()
        {

            long[,] lst = new long[,] { { 1, 2 }, { 1, 3 }, { 1, 4 } };
            Assert.AreEqual("(6,12)(4,12)(3,12)", Fracts.convertFrac(lst));

        }
    }
}
