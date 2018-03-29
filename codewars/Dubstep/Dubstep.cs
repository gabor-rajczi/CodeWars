using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeWars.Dubstep
{
    public class Dubstep
    {
        public static string SongDecoder2(string input)
        {
            if (input.StartsWith("WUB"))
            {
                return SongDecoder(input.Substring(3));
            }
            for (var i = 0; i < input.Length; i++)
            {
                if (input.Substring(i).StartsWith("WUB"))
                {
                    return (input.Substring(0, i) + " " + SongDecoder(input.Substring(i))).Trim();
                }
            }
            return input.Trim();
        }

        public static string SongDecoder3(string input)
        {
            var result = input.Split(new string[]{"WUB"}, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", result);
        }

        public static string SongDecoder(string input)
        {
            return Regex.Replace(input, "(WUB)+", " ").Trim();
        }
    }
}
