using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem438 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindAnagrams("cbaebabacd", "abc");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 0, 6 })) throw new Exception();

            temp = FindAnagrams("abab", "ab");
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 0, 1, 2 })) throw new Exception();
        }

        public IList<int> FindAnagrams(string s, string p)
        {
            /*
             * 在s中，找到p字符串异位词的位置
             * 思路：
             *  1.先去分析目标字符串的情况：长度、成分
             *  2.再去分析源字符串的情况：定长、成分
             *  3.同时维护一个字典，然后通过比较字典的方式来判断是否为字母异位词
             *  
             * 时间复杂度：O(m+n)
             * 空间复杂度：O(m)
             */

            //用一个字典来存储目标字符串的成分
            var sourceDic = new Dictionary<char, int>();
            foreach (var pItem in p)
            {
                if (!sourceDic.ContainsKey(pItem)) sourceDic[pItem] = 0;
                sourceDic[pItem]++;
            }

            //用另一个字典来存储源字符串的成分，循环比较，并收集返回结果
            var forReturn = new List<int>();
            var destDic = new Dictionary<char, int>();
            int j = 0;
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                if (j >= s.Length) break;

                while (j - i < p.Length)
                {
                    if (!destDic.ContainsKey(s[j])) destDic[s[j]] = 0;
                    destDic[s[j]]++;
                    j++;
                }

                if (i > 0)
                {
                    destDic[s[i - 1]]--;
                    if (destDic[s[i - 1]] == 0) destDic.Remove(s[i - 1]);
                }

                if (IsSameDic(sourceDic, destDic)) forReturn.Add(i);
            }

            return forReturn;
        }

        private bool IsSameDic(IDictionary<char, int> sourceDic, IDictionary<char, int> destDic)
        {
            if (sourceDic.Count != destDic.Count) return false;

            foreach (var sourceItem in sourceDic)
            {
                if (!destDic.ContainsKey(sourceItem.Key)) return false;
                if (destDic[sourceItem.Key] != sourceItem.Value) return false;
            }

            return true;
        }
    }
}
