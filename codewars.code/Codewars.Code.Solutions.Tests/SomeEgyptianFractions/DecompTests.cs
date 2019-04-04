using System;
using NUnit.Framework;

[TestFixture]
public static class DecompTests 
{
    private static void testing(string actual, string expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
// [Ignore("There are better tests")]
    public static void test() 
    {        
        Console.WriteLine("Fixed Tests");
        testing(Decomp.Decompose("3", "4"), "[1/2, 1/4]");
        testing(Decomp.Decompose("12", "4"), "[3]");
        testing(Decomp.Decompose("0", "2"), "[]"); 
        testing(Decomp.Decompose("9", "10"), "[1/2, 1/3, 1/15]");     
    }

    [TestCase("3", "4", "[1/2, 1/4]")]
    [TestCase("12", "4", "[3]")]
    [TestCase("0", "2", "[]")]
    [TestCase("9", "10", "[1/2, 1/3, 1/15]")]
    [TestCase("7", "15", "[1/3, 1/8, 1/120]")]
    [TestCase("16233000", "1359351420", "[1/84, 1/27055, 1/1359351420]")]
    public static void test(string numerator, string denominator, string exceptedResult)
    {
        testing(Decomp.Decompose(numerator, denominator), exceptedResult);
    }
}