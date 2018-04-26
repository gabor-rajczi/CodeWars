using System.Linq;


namespace CodeWars.NextSmallerNumberWithTheSameDigits
{
    class Kata
    {

        // Strategy = go from right to left and find the first digit with a number greater to the left
        // eg 285123 - find the '1' because there's a greater number beside
        // Find the biggest number to the right, and switch the two
        // eg 285123 - switch the 5 and the 3 = 283125
        // Then, sort everything to the right of the index in descending order
        // eg 283125 -> 283521
        public static long NextSmaller(long n)
        {
            if (n <= 10)
                return -1;
            var digits = n.ToString().ToCharArray();
            if (digits.Length == 2)
                return digits[0] > digits[1] ? long.Parse(string.Join("", digits.Reverse())) : -1;
            var l = digits.Length - 1;
            var i = l;
            while (i > 0 && digits[i-1]<=digits[i])
                i--;
            
            if (i <= 0)
                return -1;

            var j = i - 1;

            while (j + 1 <= l && digits[j + 1] < digits[i - 1])
                j++;

            var temp = digits[i-1];
            digits[i-1] = digits[j];
            digits[j] = temp;

            var numberString = string.Join("", digits);
            if (numberString.ToCharArray()[0] == '0')
                return -1;

            numberString = numberString.Substring(0, i) + string.Join("", numberString.Substring(i).Reverse());

            n = long.Parse(numberString);
            return n;
        }

    }
}
