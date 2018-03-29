namespace CodeWars.SimplePigLatin
{
    using System;
    using NUnit.Framework;
    using Kata = SimplePigLatin;

    [TestFixture]
    class SimplePigLatinTest
    {
        [Test]
        public void KataTests()
        {
            Assert.AreEqual("igPay atinlay siay oolcay", Kata.PigIt("Pig latin is cool"));
            Assert.AreEqual("hisTay siay ymay tringsay", Kata.PigIt("This is my string"));
            Assert.AreEqual("elloHay orldWay !", Kata.PigIt("Hello World !"));
        }
    }
}
