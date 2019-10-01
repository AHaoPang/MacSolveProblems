using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem096 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumTrees(3);
        }

        public int NumTrees(int n)
        {
            /*
             * 题目大意：
             *  含有n个节点的搜索二叉树的可能组成情况有多少种？
             * 思路：
             *  1.依据规律可知 Count(n) = Count(0)Count(n-1) + Count(1)Count(n-2) + ... + Count(n-1)Count(0)
             *  2.当没有节点时，Count(0) = 1
             *  3.当有一个节点时，Count(1) = 1
             *  3.举例，当有两个节点时，Count(2) = Count(0)Count(1) + Count(1)Count(0) = 1 + 1 = 2
             *  
             *  以上便是递推方程，因此可以考虑使用“动态规划”来解决，相当于是一个从0开始，依次计算一维数组各元素存储数据的问题
             *  
             *  时间复杂度：O(n) -->遍历一维数组的n个值
             *  空间复杂度：O(n) -->需要一维数组来存储数据
             *  
             * 考察点：
             *  1.对二叉搜索树本身的了解，才能做出正确的统计；
             *  2.动态规划
             */

            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    dp[i] += dp[j] * dp[i - 1 - j];
                }
            }

            return dp[n];
        }
    }
}
