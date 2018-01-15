using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.ValidParentheses
{
    public class Parentheses
    {
        public static bool ValidParentheses(string input)
        {
            if (input == "")
                return true;
            var listOfChars = input.ToCharArray();
            int countOfOpenParentheses = 0;
            int countOfCloseParentheses = 0;
            for (var i = 0; i < listOfChars.Length; i++)
            {
                var currentCharacter = listOfChars[i];
                if (currentCharacter == '(')
                    countOfOpenParentheses++;
                if (currentCharacter == ')')
                {
                    countOfCloseParentheses++;
                    if (countOfCloseParentheses > countOfOpenParentheses)
                        return false;
                }
             
            }
            return countOfOpenParentheses == countOfCloseParentheses && countOfOpenParentheses != 0;
        }
    }
}
