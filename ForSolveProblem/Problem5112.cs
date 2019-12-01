using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5112 : IProblem
    {
        public void RunProblem()
        {
            var temp = ToHexspeak("257");
            if (temp != "IOI") throw new Exception();

            temp = ToHexspeak("3");
            if (temp != "ERROR") throw new Exception();

            temp = ToHexspeak("747823223228");
            if (temp != "AEIDBCDIBC") throw new Exception();
        }

        public string ToHexspeak(string num)
        {
            var numInt = Int64.Parse(num);

            var hexStr = Convert.ToString(numInt, 16).ToUpper();

            var newStr = hexStr.Replace('0', 'O').Replace('1', 'I');

            var charSets = new HashSet<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'I', 'O' };

            foreach (var strItem in newStr)
                if (!charSets.Contains(strItem)) return "ERROR";

            return newStr;
        }
    }
}
