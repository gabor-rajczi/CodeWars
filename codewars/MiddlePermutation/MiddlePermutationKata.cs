using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodeWars.MiddlePermutation
{
    public class MiddlePermutationKata
    {

        /// <summary>
        /// forrás: https://codereview.stackexchange.com/questions/163292/finding-the-middle-permutation?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        /// Calculating every permutation is very expensive so you want to avoid doing that. There are some ways to handle this:
        /// 1) Sort the characters before you run your algorithm. That way you are sorting a few characters not billions of permutations.
        /// 2) If the string has an even number of characters (say abcd) remove the almost middle character (b) and rewrite as something like 'b' + 'acd'.reverse
        /// 3) If the string has an odd number of characters (say abcde) you can remove the middle character (c) leaving abde and simplify the result as 'c' + middle_permutation('abde')
        /// (3) Will always be followed by (2)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MiddlePermutation(string s)
        {
            s = string.Join("", s.ToCharArray().OrderBy(c => c));
            if (s.Length <= 2)
                return s;
            if (s.Length%2 == 0)
            {
                var middle = s.Length/2 - 1;
                var remainder = s.Substring(0, middle) + s.Substring(middle + 1);
                return string.Format("{0}{1}", string.Join("", s.ToCharArray(middle, 1)) , string.Join("", remainder.Reverse()));
            }
            else
            {
                var middle = s.Length/2;
                var remainder = s.Substring(0, middle-1) + s.Substring(middle + 1);
                return string.Format("{0}{1}{2}", string.Join("", s.ToCharArray(middle, 1)),string.Join("", s.ToCharArray(middle-1, 1)), string.Join("", remainder.Reverse()));
            }
        }


        // Túl lassú minden permutáció kiszámolása
        private string _input;
        private List<string> _permutations;
        public string MiddlePermutation2(string s)
        {
            _permutations = new List<string>();
            _input = s;
            var n = _input.Length;
            GeneratePermutations(n);
            var permutations = _permutations.OrderBy(p => p).ToList();
            var numberOfPermutations = permutations.Count;
            var result = permutations.Count == 0
                ? s
                : permutations.ElementAt(numberOfPermutations % 2 == 0
                    ? numberOfPermutations / 2 - 1
                    : (numberOfPermutations + 1) / 2 - 1);
            return result;
        }

        private void GeneratePermutations(int n)
        {
            var indexes = Enumerable.Range(0, n).Select(r => 0).ToArray();
            _permutations.Add(_input);
            int i = 0;
            while (i < n)
            {
                if (indexes[i] < i)
                {
                    Swap(i%2 == 0 ? 0 : indexes[i], i);
                    _permutations.Add(_input);
                    indexes[i] += 1;
                    i = 0;
                }
                else
                {
                    indexes[i] = 0;
                    i += 1;
                }
            }
        }

        private void Swap(int pos1, int pos2)
        {
            Debug.Assert(true,DateTime.Now.ToLongTimeString());
            var resultArray = _input.ToCharArray();
            var temp = resultArray[pos1];
            resultArray[pos1] = resultArray[pos2];
            resultArray[pos2] = temp;
            _input = string.Join("", resultArray);
            Debug.Assert(true, DateTime.Now.ToLongTimeString());
        }
        private void GeneratePermutations2(int n)
        {
            if (n == 1)
            {
                _permutations.Add(_input);
            }
            else
            {
                for (var i = 0; i < n; i++)
                {
                    GeneratePermutations(n - 1);
                    Swap(n % 2 == 1 ? 0 : i, n - 1);
                }
            }
        }

        private void Swap2(int pos1, int pos2)
        {
            var resultArray = _input.ToCharArray();
            var char1 = resultArray[pos1];
            var char2 = resultArray[pos2];
            var result = "";
            for (var i = 0; i < resultArray.Length; i++)
            {
                if (i == pos1)
                {
                    result += char2;
                }
                else if (i == pos2)
                {
                    result += char1;
                }
                else
                {
                    result += resultArray[i];
                }
            }
            _input = result;
        }
    }
}
