using System;
using System.Linq;

public class LongestConsecutives
{

    public static String MyLongestConsec(string[] strarr, int k)
    {
        var n = strarr.Length;
        if (n == 0 || k > n || k <= 0)
            return "";
        var result = "";
        for (var i = 0; i <= n - k; i++)
        {
            var currentString = string.Join("", strarr.Skip(i).Take(k));
            if (result.Length < currentString.Length)
                result = currentString;
        }
        return result;
    }

    public static string LongestConsec(string[] strarr, int k)
    {
        var count = strarr.Length - k + 1;
        return Enumerable.Range(0, count > 0 ? count : 0)
            .Select(i => string.Join("", strarr.Skip(i).Take(k)))
            .Aggregate(string.Empty, (max, current) => current.Length > max.Length ? current : max);
    }
}