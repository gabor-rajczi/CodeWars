using System.Collections.Generic;

namespace CodeWars.Reflection.GiveMeTypes
{
    using NUnit.Framework;
    using System;

    // TODO: Replace examples and use TDD development by writing your own tests

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void MyTest()
        {
            var actual = new List<Tuple<object, Type>>();
            var expected = new List<Tuple<object, Type>>();
            var o1 = new TestObject1();
            actual.Add(new Tuple<object, Type>(o1, o1.GetType()));
            expected.Add(new Tuple<object, Type>(o1, o1.GetType()));
            Reflection.GetTypes(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyTest2()
        {
            var actual = new List<Tuple<object, Type>>();
            var expected = new List<Tuple<object, Type>>();
            var o1Type = typeof (TestObject1);
            actual.Add(new Tuple<object, Type>(null, o1Type));
            expected.Add(new Tuple<object, Type>(null, o1Type));
            Reflection.GetTypes(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyTest3()
        {
            var actual = new List<Tuple<object, Type>>();
            var expected = new List<Tuple<object, Type>>();
            var o1Type = typeof(TestObject1);
            actual.Add(new Tuple<object, Type>(null, o1Type));
            expected.Add(new Tuple<object, Type>(null, o1Type));
            Reflection.GetTypes2(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MyTest4()
        {
            var actual = (List<Tuple<object, Type>>) null;
            Reflection.GetTypes2(actual);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void MyTest5()
        {
            var actual = (List<Tuple<object, Type>>)null;
            Reflection.GetTypes(actual);
            Assert.AreEqual(null, actual);
        }
    }

    public class TestObject1
    {
        
    }

    public class TestObject2
    {

    }

    public class TestObject3
    {

    }
}
