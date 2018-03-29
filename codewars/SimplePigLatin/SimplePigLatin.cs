


using System.Text.RegularExpressions;

namespace CodeWars.SimplePigLatin
{
    using System.Collections.Generic;
    using System.Linq;

    class SimplePigLatin
    {
        public static string PigIt2(string str)
        {
            var wordList = str.Split(' ').ToList();
            var newWordList = new List<string>();
            foreach (var word in wordList)
            {
                var newWord = word;
                var punctuationMark = "";
                if (char.IsPunctuation(word, word.Length - 1))
                {
                    punctuationMark = word.ToCharArray().Last().ToString();
                    newWord = word.Length - 2>=0 ? word.Substring(0, word.Length - 2) : punctuationMark;
                }
                newWord = newWord.Length>1 ? newWord.Substring(1, newWord.Length - 1) + newWord.Substring(0, 1) + "ay" + punctuationMark : newWord;
                newWordList.Add(newWord);
            }
            return string.Join(" ", newWordList);
        }

        public static string PigIt(string str)
        {
            //solution 1:
            //return string.Join(" ", str.Split().Select(x => x.Substring(1) + x[0] + "ay")); //fail with punktuation
            //solution 2:
            //return Regex.Replace(str, "(?<=^| )(\\w)(\\w+)", m => m.Groups[2].Value + m.Groups[1].Value + "ay");
            return Regex.Replace(str, @"(\w)(\w+)", @"$2$1ay");
        }
    }
}