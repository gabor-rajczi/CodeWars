namespace CodeWars.Reflection.CompleteInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void NullTest()
        {
            Assert.AreEqual(null, Reflection.InvokeMethod(null));
        }

        [Test]
        public void EmptyTest()
        {
            Assert.AreEqual("", Reflection.InvokeMethod(""));
        }

        [Test]
        public void UnknownTypeTest()
        {
            Assert.AreEqual(null, Reflection.InvokeMethod("unknownType"));
        }

        [Test]
        public void SmallObjectTest()
        {
            var returnValue = Reflection.InvokeMethod("testClass");
            //Assert.AreEqual(Helper.returnvalue, returnValue);
        }
    }
}
