using System;
using NUnit.Framework;

[TestFixture]
public static class LongestConsecutivesTests
{
    private static void testing(string actual, string expected)
    {
        Assert.AreEqual(expected, actual);
    }
    [Test]
    public static void test1()
    {
        Console.WriteLine("Basic Tests");
        testing(LongestConsecutives.LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2), "abigailtheta");
        testing(LongestConsecutives.LongestConsec(new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }, 1), "oocccffuucccjjjkkkjyyyeehh");
        testing(LongestConsecutives.LongestConsec(new String[] { }, 3), "");
        testing(LongestConsecutives.LongestConsec(new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" }, 2), "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
        testing(LongestConsecutives.LongestConsec(new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }, 2), "wlwsasphmxxowiaxujylentrklctozmymu");
        testing(LongestConsecutives.LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas" }, -2), "");
        testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3), "ixoyx3452zzzzzzzzzzzz");
        testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 15), "");
        testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 0), "");
        testing(LongestConsecutives.LongestConsec(new String[] { }, 0), "");
    }

    [Test]
    public static void test2()
    {
        Console.WriteLine("Basic Tests");
        testing(LongestConsecutives.MyLongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2), "abigailtheta");
        testing(LongestConsecutives.MyLongestConsec(new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }, 1), "oocccffuucccjjjkkkjyyyeehh");
        testing(LongestConsecutives.MyLongestConsec(new String[] { }, 3), "");
        testing(LongestConsecutives.MyLongestConsec(new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" }, 2), "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
        testing(LongestConsecutives.MyLongestConsec(new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }, 2), "wlwsasphmxxowiaxujylentrklctozmymu");
        testing(LongestConsecutives.MyLongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas" }, -2), "");
        testing(LongestConsecutives.MyLongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3), "ixoyx3452zzzzzzzzzzzz");
        testing(LongestConsecutives.MyLongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 15), "");
        testing(LongestConsecutives.MyLongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 0), "");
        testing(LongestConsecutives.MyLongestConsec(new String[] { }, 0), "");
    }
}