using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem010 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsMatch("aa", "a");
            if (temp == true) throw new Exception();

            temp = IsMatch("aa", "a*");
            if (temp == false) throw new Exception();

            temp = IsMatch("ab", ".*");
            if (temp == false) throw new Exception();

            temp = IsMatch("aab", "c*a*b");
            if (temp == false) throw new Exception();

            temp = IsMatch("mississippi", "mis*is*p*.");
            if (temp == true) throw new Exception();

            temp = IsMatch("a", "ab*");
            if (temp == false) throw new Exception();

            temp = IsMatch("ab", ".*c");
            if (temp == true) throw new Exception();
        }

        public bool IsMatch(string s, string p)
        {
            /*
             * 实现一种模式匹配的效果
             * 思路：
             *  1.这是一种典型的“回溯法”思想，即没走一步，接下来就会有多步的选择，而正确的选择通常只有其中的一步
             *  2.两个指针分别遍历各自的字符串，然后会出现集中结束的情况：
             *      2.1 若它们都指向了字符串的结束，匹配成功了
             *      2.2 一个位置结束了，另一个还没有，匹配失败了
             *  3.串指针只负责依次遍历自己的串
             *  4.匹配指针不光要关注当前指向，还要看当前指向的后一个指向
             *      4.1 后一个没啥特殊的
             *          4.1.1 字符相同，则均指向下一个
             *          4.1.2 字符不同
             *                 4.1.2.1 非“.” false
             *                 4.1.2.2 “.” 均指向下一个
             *      4.2 后一个是“*”
             *          4.2.1 串不移，模式移动2次
             *          4.2.2 串移1，模式不移动
             *          4.2.3 串移1，模式移动2次
             *  5.建立以上的递归过程，就是回溯了，因为每移动一次，面临的问题都是相同的，所以需要展开相同的思考
             *  
             * 时间复杂度：O(n*m)，主要看待匹配字符串的长度了
             * 空间复杂度：O(n*m)，主要是递归过程中，数据的存储
             * 
             * 考察点：
             *  1.各种情况的分析
             *  2.回溯法的应用
             */

            if (string.IsNullOrWhiteSpace(s) && string.IsNullOrWhiteSpace(p)) return true;

            return MatchResult(s, 0, p, 0);
        }

        private Dictionary<string, bool> matchR = new Dictionary<string, bool>();

        private bool MatchResult(string s, int sIndex, string p, int pIndex)
        {
            bool forReturn = false;

            var key = $"{sIndex}-{pIndex}";
            try
            {
                if (s.Length == sIndex && p.Length == pIndex) return forReturn = true;

                if (sIndex > s.Length || p.Length <= pIndex) return forReturn;

                if (matchR.ContainsKey(key)) return matchR[key];

                char sChar = ' ';
                if (sIndex < s.Length) sChar = s[sIndex];

                var pChar = p[pIndex];

                if (pIndex < p.Length - 1 && p[pIndex + 1] == '*')
                {
                    if (pChar == sChar || pChar == '.')
                    {
                        //下一个字符是“*”的情况
                        if (MatchResult(s, sIndex, p, pIndex + 2) ||
                            MatchResult(s, sIndex + 1, p, pIndex + 2) ||
                            MatchResult(s, sIndex + 1, p, pIndex))
                            return forReturn = true;
                    }
                    else //字符不匹配，那么就直接让模式串后移好了
                        return forReturn = MatchResult(s, sIndex, p, pIndex + 2);
                }
                else
                {
                    //下一个字符串不是“*”的情况
                    if (pChar == '.' || sChar == pChar)
                        return forReturn = MatchResult(s, sIndex + 1, p, pIndex + 1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                matchR[key] = forReturn;
            }

            return false;
        }
    }
}
