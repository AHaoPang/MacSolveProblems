using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem696 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountBinarySubstrings("00110011");
            if (temp != 6) throw new Exception();

            temp = CountBinarySubstrings("10101");
            if (temp != 4) throw new Exception();
        }

        public int CountBinarySubstrings(string s)
        {
            /*
             * 计算特定样式子串的数量
             * 思路：
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            int forReturn = 0;

            int preCount = 0;
            int nextCount = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                    nextCount++;
                else
                {
                    preCount = nextCount;
                    nextCount = 1;
                }

                if (preCount >= nextCount) forReturn++;
            }

            return forReturn;
        }
    }
}
