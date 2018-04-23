using NUnit.Framework;
using System;

namespace CodeWars.MiddlePermutation
{
    [TestFixture]
    public class Myjinxin
    {

        [Test]
        public void BasicTests()
        {
            var kata = new Kata();

            Assert.AreEqual("bac", kata.MiddlePermutation("abc"));

            Assert.AreEqual("bdca", kata.MiddlePermutation("abcd"));

            Assert.AreEqual("cbxda", kata.MiddlePermutation("abcdx"));

            Assert.AreEqual("cxgdba", kata.MiddlePermutation("abcdxg"));

            Assert.AreEqual("dczxgba", kata.MiddlePermutation("abcdxgz"));

        }

    }
}
