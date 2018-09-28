using System.Linq;

namespace CodeWars.Reflection.GiveMeTypes
{
    using System;
    using System.Collections.Generic;

    public static class Reflection
    {
        public static void GetTypes(List<Tuple<object, Type>> objectTypes)
        {
            objectTypes = objectTypes
                .Select(t => t.Item1 == null ? t : new Tuple<object, Type>(t.Item1, t.Item1.GetType()))
                .ToList();
        }


        public static void GetTypes2(List<Tuple<object, Type>> objectTypes)
        {
            for (int i = 0; i < objectTypes.Count; i++)
            {
                var t = objectTypes[i];
                if (t.Item1 != null)
                    objectTypes[i] = Tuple.Create(t.Item1, t.Item1.GetType());
            }
        }
    }
}
