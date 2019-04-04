using System;
using System.Collections.Generic;
using System.Linq;

public class Decomp 
{

  public static string Decompose(string nrStr, string drStr) 
  {
      var fractions = new EgyptianFractions(nrStr, drStr);
      return fractions.Calculate().ToString();
  }
}
public class EgyptianFractions
  {
    private long numerator;
    private long denominator;
    public EgyptianFractions(string nrStr, string drStr)
    {
        if(!long.TryParse(nrStr, out numerator))
        {
          throw new ArgumentException(nameof(nrStr));
        }
        if(!long.TryParse(drStr, out denominator))
        {
          throw new ArgumentException(nameof(drStr));
        }
    }

    private EgyptianFractions(long numerator, long denominator)
    {
      this.numerator = numerator;
      this.denominator = denominator;
    }

    public EgyptianFractions Calculate()
    {
      if(numerator == 0)
        return this;
      AddFraction(NextFraction);
      if(Value < (double)numerator/denominator)
      {
        var remaining = new EgyptianFractions(RemainingNumerator, RemainingDenominator);
        remaining.Calculate();
        Fractions.AddRange(remaining.Fractions);
      }
      return this;
    }
    private long RemainingNumerator 
    { 
      get
      {
        return numerator + (-1 * denominator) % numerator;
      } 
    }
    private long RemainingDenominator
    { 
      get
      {
        return denominator * NextFraction.Denominator;
      } 
    }

    private Fraction NextFraction
    {
        get
        {
          var nextDenominator = (double)denominator / numerator;
          if(nextDenominator < 1)
          {
            return new Fraction((long)(1/nextDenominator), 1);
          }
          return new UnitFraction((long)Math.Ceiling(nextDenominator));
        }
    }

    private readonly List<Fraction> Fractions = new List<Fraction>();

    private void AddFraction(Fraction fraction)
    {
      Fractions.Add(fraction);
    }

    public double Value { 
      get
      {
        return Fractions.Sum(f => f.Value);
      } 
    }

    public override string ToString(){
      return "["+string.Join(", ", Fractions)+"]";
    }
  }

  public class Fraction
  {
        private readonly long numerator;
        private readonly long denominator;

        public double Value { 
          get
          {
            return (double)numerator / denominator;
          } 
        }

        public long Denominator
        {
          get
          {
            return denominator;
          }
        }

        public long Numerator
        {
          get
          {
            return numerator;
          }
        }

        public Fraction(long numerator, long denominator)
        {
            if(denominator == 0)
              throw new ArgumentOutOfRangeException(nameof(denominator));
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override string ToString(){
          if(Value == Math.Ceiling((double)numerator/denominator))
            return string.Format("{0}", (long)Value);
          return string.Format($"{numerator}/{denominator}");
        }
  }
    public class UnitFraction : Fraction
    {
        public UnitFraction(long denominator) : base(1, denominator)
        {
        }
    }