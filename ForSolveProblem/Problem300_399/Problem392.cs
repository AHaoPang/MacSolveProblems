using System;
namespace ForSolveProblem
{
    public class Problem392 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsSubsequence("abc", "ahbgdc");
            if (temp != true) throw new Exception();

            temp = IsSubsequence("axc", "ahbgdc");
            if (temp != false) throw new Exception();
        }

        public bool IsSubsequence(string s, string t)
        {
            /*
             * 题目概述：判断 s 是否为 t 的子序列
             * 
             * 思路：
             *  1.考虑使用双指针的方式
             *  2.一个指针是指向 s 的，另一个指针指向 t，当 s 遍历到了尽头，就说明是满足题目要求的
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var sIndex = 0;
            var tIndex = 0;

            while (true)
            {
                if (sIndex == s.Length) return true;
                if (tIndex == t.Length) break;

                if (s[sIndex] == t[tIndex]) sIndex++;
                tIndex++;
            }

            return false;
        }
    }
}
