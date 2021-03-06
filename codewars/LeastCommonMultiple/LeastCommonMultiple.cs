﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.LeastCommonMultiple
{
    public class LeastCommonMultiple
    {
        public static int Calculate(int num1, int num2)
        {
            int lcm = 0;
            var x = num1;
            var y = num2;
            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    num1 = num1 - num2;
                }
                else
                {
                    num2 = num2 - num1;
                }
            }
            lcm = (x * y) / num1;
            return lcm;
        }

        public static int Calculate2(int[] numbers)
        {
            if(numbers.Length<2) throw new ArgumentException("Too short input array!");
            while (true)
            {
                if (numbers.Length <= 2) return Calculate(numbers[0], numbers[1]);
                var lcm = Calculate(numbers[0], numbers[1]);
                numbers = numbers.Where((value, index) => index != 0).ToArray();
                numbers[0] = lcm;
            }
        }

        public static int Calculate(int[] numbers)
        {
            if (numbers.Length < 2) throw new ArgumentException("Too short input array!");
            return numbers.Aggregate(Calculate);
        }


        /*
         * https://stackoverflow.com/questions/147515/least-common-multiple-for-3-or-more-numbers/29717490#29717490
         */
         static long LCM(long[] numbers)
            {
                return numbers.Aggregate(lcm);
            }
            static long lcm(long a, long b)
            {
                return Math.Abs(a * b) / GCD(a, b);
            }
            static long GCD(long a, long b)
            {
                return b == 0 ? a : GCD(b, a % b);
            }
         
    }
}
