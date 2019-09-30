using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem347 : IProblem
    {
        public void RunProblem()
        {
            var temp = TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 1, 2 })) throw new Exception();

            temp = TopKFrequent(new int[] { 1 }, 1);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 1 })) throw new Exception();

            temp = TopKFrequent(new int[] { -1, -1 }, 1);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { -1 })) throw new Exception();
        }

        public IList<int> TopKFrequent(int[] nums, int k)
        {
            /*
             * 找到集合中，出现频率前K高的元素
             * 思路：
             *  1.遍历一遍，分析元素出现的频率是毫无疑问的
             *  2.借用桶排序的思想，按照出现评率来分桶
             *  3.从桶中拿元素，从高到底，拿K个
             *  
             * 时间复杂度：O(n)，可以粗略的认为是遍历了3次
             * 空间复杂度：O(n)，统计频率，以及分桶，本身都是要占用空间的
             */

            var forReturn = new List<int>(k);

            Dictionary<int, int> elementCountDic = new Dictionary<int, int>();
            foreach(var numItem in nums)
            {
                if (!elementCountDic.ContainsKey(numItem)) elementCountDic[numItem] = 0;
                elementCountDic[numItem]++;
            }

            List<int>[] bucket = new List<int>[nums.Length + 1];
            foreach(var dicItem in elementCountDic)
            {
                if (bucket[dicItem.Value] == null) bucket[dicItem.Value] = new List<int>();

                bucket[dicItem.Value].Add(dicItem.Key);
            }

            for(int i = nums.Length; i > 0; i--)
            {
                if (bucket[i] == null) continue;

                forReturn.AddRange(bucket[i]);
                if (forReturn.Count == k) break;
            }

            return forReturn;
        }
    }
}
