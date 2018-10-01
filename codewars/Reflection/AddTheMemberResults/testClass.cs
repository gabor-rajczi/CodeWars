namespace CodeWars.Reflection.AddTheMemberResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class testClass
    {
        public string Output1()
        {
            return "Output";
        }

        public string Output2()
        {
            return "It";
        }
    }

    public class Refl
    {
        //public string alma = "körte";
        //public string Alma {
        //    get { return "Körte"; }
        //}
        public string Output()
        {
            return "Test-Output";
        }

        public int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }

        public string TonysLastname()
        {
            return "Stark";
        }
    }

    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void NullTest()
        {
            Assert.AreEqual("", Reflection.ConcatStringMembers(null));
        }

        [Test]
        public void ObjectTest()
        {
            var testObject = new testClass();
            var concattedString = Reflection.ConcatStringMembers(testObject);
            Assert.AreEqual("OutputIt", concattedString);
        }

        [Test]
        public void ReflTest()
        {
            var testObject = new Refl();
            var concattedString = Reflection.ConcatStringMembers(testObject);
            Assert.AreEqual("Test-OutputStark", concattedString);
        }
    }
}
