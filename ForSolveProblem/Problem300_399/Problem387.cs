using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem387 : IProblem
    {
        public void RunProblem()
        {
            var temp = FirstUniqChar("leetcode");
            if (temp != 0) throw new Exception();

            temp = FirstUniqChar("loveleetcode");
            if (temp != 2) throw new Exception();
        }

        public int FirstUniqChar1(string s)
        {
            /*
             * 寻找字符串中首次出现的唯一的一个字符
             * 思路：
             *  1.要遍历过整个字符串，才能知道哪些字符出现过，哪些字符没出现过
             *  2.可以考虑记录下每个字符出现的次数
             *  3.然后只要统计那些字符谁只出现过一次，且位置最靠前，就是谁
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            Dictionary<char, int> charDic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!charDic.ContainsKey(s[i])) charDic[s[i]] = i;
                else charDic[s[i]] = -1;
            }

            int forReturn = -2;
            foreach (var charItem in charDic) if (charItem.Value != -1 && (forReturn > charItem.Value || forReturn == -2)) forReturn = charItem.Value;

            return forReturn == -2 ? -1 : forReturn;
        }

        public int FirstUniqChar(string s)
        {
            var numArr = Enumerable.Repeat(-1, 26).ToArray();

            for (var i = 0; i < s.Length; i++)
            {
                var index = s[i] - 'a';
                numArr[index] = numArr[index] == -1 ? i : -2;
            }

            var newArr = numArr.Where(i => i != -1 && i != -2).ToArray();
            return newArr.Length == 0 ? -1 : newArr.Min();
        }
    }
}
