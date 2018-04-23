using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.MiddlePermutation
{
    class Kata
    {
        public string MiddlePermutation(string s)
        {
            var rec = new Recursion();
            rec.InputSet = rec.MakeCharArray(s);
            rec.CalcPermutation(0);
            var a = GeneratePermutations(s.ToCharArray());
            var permutations = rec.Result.OrderBy(r => r).ToList();
            var numberOfPermutations = permutations.Count;
            var result = permutations.Count == 0
                ? s
                : permutations.ElementAt(numberOfPermutations%2 == 0
                    ? numberOfPermutations/2 - 1
                    : (numberOfPermutations + 1)/2 - 1);
            return result;
        }

        private List<char[]> GeneratePermutations(char[] input)
        {
            var result = new List<char[]>();
            if (input.Length == 1)
            {
                
            }
        }

        /// <summary>
        /// Algorithm Source: A. Bogomolny, Counting And Listing 
        /// All Permutations from Interactive Mathematics Miscellany and Puzzles
        /// http://www.cut-the-knot.org/do_you_know/AllPerm.shtml, Accessed 11 June 2009
        /// </summary>
        internal class Recursion
        {
            private int _elementLevel = -1;
            private int _numberOfElements;
            private int[] _permutationValue = new int[0];
            private readonly List<string> _result = new List<string>();

            private char[] _inputSet;

            public char[] InputSet
            {
                get { return _inputSet; }
                set { _inputSet = value; }
            }

            public Recursion()
            {
                PermutationCount = 0;
            }

            public int PermutationCount { get; set; }

            public List<string> Result
            {
                get { return _result; }
            }

            public char[] MakeCharArray(string inputString)
            {
                var charString = inputString.ToCharArray();
                Array.Resize(ref _permutationValue, charString.Length);
                _numberOfElements = charString.Length;
                return charString;
            }

            public void CalcPermutation(int k)
            {
                _elementLevel++;
                _permutationValue.SetValue(_elementLevel, k);

                if (_elementLevel == _numberOfElements)
                {
                    OutputPermutation(_permutationValue);
                }
                else
                {
                    for (int i = 0; i < _numberOfElements; i++)
                    {
                        if (_permutationValue[i] == 0)
                        {
                            CalcPermutation(i);
                        }
                    }
                }
                _elementLevel--;
                _permutationValue.SetValue(0, k);
            }

            private void OutputPermutation(int[] value)
            {
                var resultCharList = value.Select(i => (char) _inputSet.GetValue(i - 1)).ToList();
                _result.Add(string.Join("", resultCharList));
                PermutationCount++;
            }
        }
    }
}
