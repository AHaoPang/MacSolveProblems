using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem692 : IProblem
    {
        public void RunProblem()
        {
            var temp = TopKFrequent(new string[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is", "apple" }, 4);
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {
            /*
             * 使用哈希表来统计，然后分别依据两个条件来排序（注意：先按照字母来排序，然后再按照统计值来排序）
             * 时间复杂度：遍历一遍，然后排序了两次，所以是 O(nlogn)
             * 空间复杂度：额外使用了HashTable，因此，是O(n)
             */

            Dictionary<string, int> dicWords = new Dictionary<string, int>();
            foreach(var wordItem in words)
            {
                if (!dicWords.ContainsKey(wordItem)) dicWords[wordItem] = 0;
                dicWords[wordItem] += 1;
            }

            var orderedDic = dicWords.OrderBy(i => i.Key).OrderByDescending(i => i.Value);
            return orderedDic.Take(k).Select(i => i.Key).ToList();
        }
    }
}
