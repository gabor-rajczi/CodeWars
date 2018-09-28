using System.Reflection;

namespace CodeWars.Reflection.GiveMeAllMethods
{
    using System;
    using System.Linq;
    public static class Reflection
    {
        public static string[] GetMethodNames(object TestObject)
        {
            if (TestObject == null)
                return new string[] { };
            return TestObject
                .GetType()
                .GetMethods(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Static)
                .Select(mi => mi.Name)
                .ToArray();
        }
    }
}
