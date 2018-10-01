

namespace CodeWars.Reflection.CompleteInvoke
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    public static class Reflection
    {
        public static string InvokeMethod(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return typeName;
            var type = Type.GetType(typeName);
            if (type == null)
                return null;
            foreach (var constructorParameters in type.GetConstructors()
                .Select(constructorInfo => constructorInfo.GetParameters()))
            {
                var parameters = new List<object>();
                for (var i = 0; i < constructorParameters.Length; i++)
                {
                    parameters.Add(null);
                }
                var o = Activator.CreateInstance(type, parameters.ToArray());
                var methods =
                    type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                                    BindingFlags.Static | BindingFlags.DeclaredOnly);
                foreach (var methodInfo in methods)
                {
                    return (string)methodInfo.Invoke(o, null);
                }
            }
            return "";
        }
    }
}
