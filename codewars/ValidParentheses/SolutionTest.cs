namespace CodeWars.ValidParentheses
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest1()
        {
            Assert.AreEqual(true, Parentheses.ValidParentheses("()"));
        }

        [Test]
        public void SampleTest2()
        {
            Assert.AreEqual(false, Parentheses.ValidParentheses(")(((("));
        }

        [Test]
        public void SampleTest3()
        {
            Assert.AreEqual(false, Parentheses.ValidParentheses("("));
        }

        [Test]
        public void SampleTest4()
        {
            Assert.AreEqual(true, Parentheses.ValidParentheses("(())((()())())"));
        }
        [Test]
        public void SampleTest5()
        {
            Assert.AreEqual(false, Parentheses.ValidParentheses("())("));
        }

        [Test]
        public void SampleTest6()
        {
            Assert.AreEqual(true, Parentheses.ValidParentheses(" (ff(gg)df)f((()())())"));
        }
    }
}