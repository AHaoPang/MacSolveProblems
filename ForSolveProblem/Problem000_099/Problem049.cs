using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem049 : IProblem
    {
        public void RunProblem()
        {
            var temp = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        }

        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            //wrong ans.
            Dictionary<int, IList<string>> forReturn = new Dictionary<int, IList<string>>();

            foreach (var strItem in strs)
            {
                int keyValue = 0;
                for (int i = 0; i < strItem.Length; i++)
                {
                    if (i == 0)
                        keyValue = strItem[i];
                    else
                        keyValue ^= strItem[i];
                }

                if (!forReturn.ContainsKey(keyValue)) forReturn[keyValue] = new List<string>();
                forReturn[keyValue].Add(strItem);
            }

            return forReturn.Values.ToList();
        }

        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            /*
             * 按照“字母异位”的规律，来将给定的字符串分组
             * 思路：
             *  1.最后是能分析一个字符串，然后得个一个解决，通过这个结果能快速判断出是否存在相同结果的数字
             *  2.对字符串分析的都一个字母个数的统计，在按照字母大小序构造一个字符串
             *  3.若两个字符串的分析结果一样，那么就是同一类了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            Dictionary<string, IList<string>> forReturn = new Dictionary<string, IList<string>>();

            foreach (var strItem in strs)
            {
                //对字符串做分析和统计
                SortedDictionary<int, int> sortedDic = new SortedDictionary<int, int>();
                foreach (var cItem in strItem)
                {
                    if (!sortedDic.ContainsKey(cItem)) sortedDic[cItem] = 0;

                    sortedDic[cItem]++;
                }

                //构造特殊的字符串，用于标识字母异位词
                StringBuilder sbFormat = new StringBuilder();
                foreach (var dicItem in sortedDic)
                    sbFormat.Append($"{dicItem.Key}_{dicItem.Value},");

                string patternStr = sbFormat.ToString();

                if (!forReturn.ContainsKey(patternStr)) forReturn[patternStr] = new List<string>();
                forReturn[patternStr].Add(strItem);
            }

            return forReturn.Values.ToList();
        }

        public IList<IList<string>> GroupAnagrams3(string[] strs)
        {
            //wrong ans.
            var dic = new Dictionary<char, IList<string>>();
            foreach (var item in strs)
            {
                var curChar = (char)0;
                for (var i = 0; i < item.Length; i++)
                    curChar ^= item[i];

                if (!dic.ContainsKey(curChar))
                    dic[curChar] = new List<string>();

                dic[curChar].Add(item);
            }

            return dic.Select(i => i.Value).ToList();
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();
            foreach (var strItem in strs)
            {
                var key = GetKeyStr(strItem);
                if (!dic.ContainsKey(key))
                    dic[key] = new List<string>();

                dic[key].Add(strItem);
            }

            return dic.Values.ToList();
        }

        private string GetKeyStr(string str)
        {
            var intArr = new int[26];
            foreach (var charItem in str)
                intArr[charItem - 'a']++;

            return string.Join(',', intArr);
        }
    }
}
