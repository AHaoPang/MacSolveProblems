﻿using System;
namespace ForSolveProblem
{
    public class Problem521 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindLUSlength(string a, string b)
        {
            /*
             * ##### 1. 题目概述：最长特殊序列
             * 
             * ##### 2. 思路：
             *    - 特征：若一个字符串比另一个字符串长,那么显然长的是结果;若两个字符串一模一样,那么就是-1;不一样,那么结果一定是字符串本身的长度;
             *    - 方案：依据特征去做计算
             *    - 结果：满足不同的特征,得到不同的判定结果
             *
             * ##### 3. 知识点：字符串
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(1)
             *    - 空间复杂度：O(1)
             */

            return a == b ? -1 : Math.Max(a.Length, b.Length);
        }
    }
}
