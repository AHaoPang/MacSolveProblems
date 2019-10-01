using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem451 : IProblem
    {
        public void RunProblem()
        {
            var temp = FrequencySort("tree");

            temp = FrequencySort("cccaaa");

            temp = FrequencySort("Aabb");
        }

        public string FrequencySort(string s)
        {
            /*
             * 按照字符在字符串中出现的频率，来重塑字符串
             * 思路：
             *  1.遍历字符串，来统计出现频率-->交给Dictionary
             *  2.依据出现频率做桶排序
             *  3.逆序输出桶排序的结果，即重塑后的新字符串
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            //统计出现频率
            var charCountDic = new Dictionary<char, int>();
            foreach (var charItem in s)
            {
                if (!charCountDic.ContainsKey(charItem)) charCountDic[charItem] = 0;
                charCountDic[charItem]++;
            }

            //排序
            var buckets = new List<char>[s.Length + 1];
            foreach (var dicItem in charCountDic)
            {
                if (buckets[dicItem.Value] == null) buckets[dicItem.Value] = new List<char>();
                buckets[dicItem.Value].Add(dicItem.Key);
            }

            //逆序输出
            StringBuilder forReturn = new StringBuilder();
            for (int i = buckets.Length - 1; i > 0; i--)
            {
                if (buckets[i] == null) continue;

                foreach (var bucketItem in buckets[i])
                    for (int j = 0; j < i; j++) forReturn.Append(bucketItem);
            }

            return forReturn.ToString();
        }
    }
}
