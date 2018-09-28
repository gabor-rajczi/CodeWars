namespace CodeWars.Reflection.GiveMeAllMethods
{
    using System;

public class Refl 
{
  static void Main(string[] args) 
  { 
    Console.WriteLine(new Refl().Output());
    Console.WriteLine(new Refl().AddInts1(1,2));
  } 

  public string Output()
  {
    return "Test-Output";
  }

  public int AddInts1(int i1, int i2) 
  {
    return i1 + i2;
  }
}
}
