using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1328 : IProblem
    {
        public void RunProblem()
        {
            var temp = BreakPalindrome("abccba");
            if (temp != "aaccba") throw new Exception();

            temp = BreakPalindrome("a");
            if (temp != "") throw new Exception();
        }

        public string BreakPalindrome(string palindrome)
        {
            var maxValue = palindrome.Length;
            for (int i = 0; i < maxValue / 2; i++)
            {
                if (palindrome[i] != 'a')
                {
                    var tempArray = palindrome.ToCharArray();
                    tempArray[i] = 'a';
                    return new string(tempArray);
                }
            }

            for(int j = maxValue/2;j < maxValue; j++)
            {
            }

            return "";
        }
    }
}
