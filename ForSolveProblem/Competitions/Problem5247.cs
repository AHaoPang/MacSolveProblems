using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5247 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinimumSwap("xx", "yy");
            if (temp != 1) throw new Exception();

            temp = MinimumSwap("xy", "yx");
            if (temp != 2) throw new Exception();

            temp = MinimumSwap("xx", "xy");
            if (temp != -1) throw new Exception();

            temp = MinimumSwap("xxyyxyxyxx", "xyyxyxxxyx");
            if (temp != 4) throw new Exception();
        }

        public int MinimumSwap(string s1, string s2)
        {
            var xTotal = 0;
            var yTotal = 0;

            foreach(var s1Item in s1)
            {
                if(s1Item == 'x')
                    xTotal++;
                else
                    yTotal++;
            }

            foreach(var s2Item in s2)
            {
                if(s2Item == 'x')
                    xTotal++;
                else
                    yTotal++;
            }

            if (xTotal % 2 != 0 || yTotal % 2 != 0) return -1;
            
            var s1X = 0;
            var s1Y = 0;
            for (int i = 0;i < s1.Length; i++)
            {
                if(s1[i] != s2[i])
                {
                    if (s1[i] == 'x') s1X++;
                    else s1Y++;
                }
            }

            var forReturn = s1X / 2 + s1Y / 2;

            if (s1X % 2 != 0) forReturn += 2;

            return forReturn;
        }
    }
}
