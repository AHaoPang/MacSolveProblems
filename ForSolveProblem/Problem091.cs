using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem091 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumDecodings("12");
            if (temp != 2) throw new Exception();

            temp = NumDecodings("226");
            if (temp != 3) throw new Exception();

            temp = NumDecodings("0");
            if (temp != 0) throw new Exception();

            temp = NumDecodings("00");
            if (temp != 0) throw new Exception();

            temp = NumDecodings("01");
            if (temp != 0) throw new Exception();

            temp = NumDecodings("101");
            if (temp != 1) throw new Exception();
        }

        public int NumDecodings(string s)
        {
            /*
             * 数字解码，所有可能性计算
             * 思路：
             *  1.可以将大问题拆成小问题的，即，我可以解码1个字符，也可以解码2个字符，然后分别加上子字符串的可能性即可；
             *  2.定义状态dp[i]，表示截止到当前这个字符串，一共有多少种解码的方法；
             *  3.dp[i] = dp[i-1] + dp[i-2]
             *  4.这是一个斐波那契数列的问题，但是还有些逻辑上的限制条件
             *      4.1 如果单个字符是“0”，那么显然是不可能的
             *      4.2 如果两个字符是大于“26”，那么显然也是不可能的
             *      
             *  时间复杂度：O(n)，n是字符串的长度
             *  空间复杂度：O(1)，可以使用固定大小的空间，因为dp[i]仅和前面的两位数有关
             *  
             * 考察点：
             *  1.动态规划    
             *  2.相当多的临界条件
             */

            int[] dp = new int[s.Length + 1];

            dp[0] = 1;
            if (s.Length > 0 && s[0] == '0') dp[0] = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int v1 = int.Parse(s[i].ToString());
                if (v1 > 0) dp[i + 1] += dp[i];

                if (i - 1 >= 0)
                {
                    int v2 = int.Parse(s.Substring(i - 1, 2));
                    if (v2 <= 26 && v2 > 9) dp[i + 1] += dp[i - 1];
                }
            }

            return dp[s.Length];
        }
    }
}
