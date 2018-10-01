

namespace CodeWars.Reflection.CallMeBack
{
    using System;
    using System.Reflection;
    using System.Diagnostics;

    public static class Reflection
    {
        public static void Activator()
        {
            var stackTrace = new StackTrace();
            var type = stackTrace.GetFrame(1).GetMethod().ReflectedType;
            if(type == null)
                return;
            var staticMethods = type.GetMethods(BindingFlags.Static|BindingFlags.Public);
            if(staticMethods.Length != 1)
                return;
            staticMethods[0].Invoke(null, null);
        }
    }
}
