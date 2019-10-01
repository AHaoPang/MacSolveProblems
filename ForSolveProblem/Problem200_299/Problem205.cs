using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem205 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsIsomorphic("egg", "add");
            if (temp != true) throw new Exception();

            temp = IsIsomorphic("foo", "bar");
            if (temp != false) throw new Exception();

            temp = IsIsomorphic("paper", "title");
            if (temp != true) throw new Exception();

            temp = IsIsomorphic("ab", "aa");
            if (temp != false) throw new Exception();
        }

        public bool IsIsomorphic(string s, string t)
        {
            /*
             * 同构字符串判断
             * 思路：
             *  1.两个字符串特定位置的字符串，在字符串中首次出现的位置一样
             *  2.需要两个dic，来记录字符首次出现的位置-->然后是用到了两个dic
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            Dictionary<char, int> sPosDic = new Dictionary<char, int>();
            Dictionary<char, int> tPosDic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!sPosDic.ContainsKey(s[i])) sPosDic[s[i]] = i;
                if (!tPosDic.ContainsKey(t[i])) tPosDic[t[i]] = i;

                if (sPosDic[s[i]] != tPosDic[t[i]]) return false;
            }

            return true;
        }

        public bool IsIsomorphic2(string s, string t)
        {
            /*
             * 同构字符串校验
             * 思路：
             *  1.建立两个字符串的映射关系
             *  2.未建立映射的，则新建；已建立映射的，则判断，不一致，则非同构
             *  
             * 时间复杂度：O(n)，双指针法，依次遍历各自的字符串
             * 空间复杂度：O(n)，最坏情况是，字符串长度为n，且n个字符都不相同，且为同构
             */

            Dictionary<char, char> sTot = new Dictionary<char, char>();
            Dictionary<char, char> tTos = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (sTot.ContainsKey(s[i]) && sTot[s[i]] != t[i]) return false;
                if (tTos.ContainsKey(t[i]) && tTos[t[i]] != s[i]) return false;

                sTot[s[i]] = t[i];
                tTos[t[i]] = s[i];
            }

            return true;
        }
    }
}
