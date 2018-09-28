namespace CodeWars.Reflection.GiveMeAllMethods
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
            Assert.AreEqual(0, Reflection.GetMethodNames(null).Length);
        }

        [Test]
        public void NewObjectTest()
        {
            var testObject = new object();
            var methodNameArray = Reflection.GetMethodNames(testObject);
            Assert.IsTrue(methodNameArray.Contains("ToString"));
        }

        [Test]
        public void ReflObjectTest()
        {
            var testObject = new Refl();
            var methodNameArray = Reflection.GetMethodNames(testObject);
            Assert.IsTrue(methodNameArray.Contains("Output"));
            Assert.IsTrue(methodNameArray.Contains("AddInts1"));
            foreach (var s in methodNameArray)
            {
                Console.WriteLine(s);
            }
        }

        [Test]
        public void ExampleClassObjectTest()
        {
            var testObject = new ExampleClass();
            var methodNameArray = Reflection.GetMethodNames(testObject);
            Console.WriteLine("methodNameArray:");
            foreach (var s in methodNameArray)
            {
                Console.WriteLine(s);
            }
        }
    }
}
