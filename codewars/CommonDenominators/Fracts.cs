

namespace CodeWars.CommonDenominators
{
    using System.Collections.Generic;
    public class Fracts
    {
        public static string convertFrac(long[,] lst)
        {
            if (lst.GetLength(0) == 0 || lst.GetLength(1) == 0)
                return "";

            var lcm = lst[0, 1];
            for (var i = 1; i < lst.GetLength(0); i++)
            {
                lcm = DetermineLcm(lcm, lst[i, 1]);
            }
            var resultList = new List<string>();
            for (int i = 0; i < lst.GetLength(0); i++)
            {
                var fraction = string.Format("({0},{1})", lst[i, 0]*lcm/lst[i,1], lcm);    
                resultList.Add(fraction);
            }
            return string.Join("",resultList);
        }

        private static long DetermineLcm(long a, long b)
        {
            long num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i < num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num1 * num2;
        }
    }
}
