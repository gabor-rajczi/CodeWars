namespace CodeWars.Reflection.AddTheMemberResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class Reflection
    {
        public static string ConcatStringMembers(object TestObject)
        {
            if(TestObject == null)
                return "";
            var results = new List<object>();
            foreach (var memberInfo in TestObject
                .GetType()
                .GetMembers(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance|BindingFlags.DeclaredOnly)
                .Where(mi => mi.MemberType == MemberTypes.Method || mi.MemberType == MemberTypes.Property || mi.MemberType == MemberTypes.Field))
            {
                if (memberInfo.MemberType == MemberTypes.Method)
                {
                    var method = TestObject.GetType().GetMethod(memberInfo.Name);
                    if(method == null)
                        continue;
                    if (method.ReturnType == typeof (string) && method.GetParameters().Length == 0 && !method.IsSpecialName)
                    {
                        var result = method.Invoke(TestObject, null);
                        results.Add(result);
                    }
                }
                if (memberInfo.MemberType == MemberTypes.Property)
                {
                    var property = TestObject.GetType().GetProperty(memberInfo.Name);
                    if(property == null)
                        continue;
                    if (property.PropertyType == typeof (string))
                    {
                        var result = property.GetValue(TestObject);
                        results.Add(result);
                    }
                        
                }
                if (memberInfo.MemberType == MemberTypes.Field)
                {
                    var field = TestObject.GetType().GetField(memberInfo.Name);
                    if (field == null)
                        continue;
                    if (field.FieldType == typeof(string))
                    {
                        var result = field.GetValue(TestObject);
                        results.Add(result);
                    }
                }
            }
            return string.Join("", results.Select(s => (string) s).OrderByDescending(s => s.Length).ThenBy(s => s));
        }
    }
}
