using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem242 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsAnagram(string s, string t)
        {
            /*
             * 使用HashTable实现一个更加通用的方法
             */

            Dictionary<char, int> dicS = new Dictionary<char, int>();
            foreach(var sItem in s)
            {
                if (!dicS.ContainsKey(sItem)) dicS[sItem] = 0;
                dicS[sItem] += 1;
            }

            Dictionary<char, int> dicT = new Dictionary<char, int>();
            foreach(var tItem in t)
            {
                if (!dicT.ContainsKey(tItem)) dicT[tItem] = 0;
                dicT[tItem] += 1;
            }

            if(dicS.Count == dicT.Count)
            {
                foreach(var sKey in dicS)
                {
                    if (!dicT.ContainsKey(sKey.Key)) return false;
                    if (dicS[sKey.Key] != dicT[sKey.Key]) return false;
                }

                return true;
            }

            return false;
        }

        public bool IsAnagram2(string s, string t)
        {
            /*
             * key point：字符都是由小写字母构成的
             * 可以统计两个字符串中字符的个数，若个数一致，那么就是异位字符串
             * 时间复杂度：O(m+n);
             * 空间复杂度：O(1)
             * 
             * 以上依然是借用了“哈希表”的思想，先做统计，然后做对比
             */

            int[] sCount = new int[26];
            int[] tCount = new int[26];

            foreach (var sItem in s)
                sCount[sItem - 'a'] += 1;

            foreach (var tItem in t)
                tCount[tItem - 'a'] += 1;

            for (int i = 0; i < sCount.Length; i++)
                if (sCount[i] != tCount[i]) return false;

            return true;
        }
    }
}
