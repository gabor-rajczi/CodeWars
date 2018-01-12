namespace CodeWars.FindTheParityOutlier
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class Kata
    {
        public static int Find(int[] integers)
        {
            return integers.First(i => Outliner(IsFindEven(integers), i.IsEven()));
        }

        private static bool Outliner(bool isFindEven, bool isCurrentlyEven)
        {
            return isFindEven && isCurrentlyEven || !isFindEven && !isCurrentlyEven;
        }

        private static bool IsFindEven(int[] integers)
        {
            return integers.Take(3).Count(i => i.IsEven()) == 1;
        }

    }
}
