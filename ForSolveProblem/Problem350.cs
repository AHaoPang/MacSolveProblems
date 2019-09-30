using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem350 : IProblem
    {
        public void RunProblem()
        {
            var temp = Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 2, 2 })) throw new Exception();

            temp = Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
            if (!ProblemHelper.ArrayIsEqual(temp, new int[] { 4, 9 })) throw new Exception();
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            /*
             * 求解两个集合的交集
             * 思路：
             *  1.基本思想是，分析一个集合的成分，然后去另一个集合匹配这些成分
             *  2.存在一些简单的优化点，虽然无法改变O(n+m)复杂度的本质
             *      2.1 优先分析小的集合
             *      2.2 匹配一个减少/删除一个，小集合元素被匹配光了，那么可以提前结束
             */

            List<int> forReturn = new List<int>();

            int[] analyzeArray = nums1.Length > nums2.Length ? nums2 : nums1;
            Dictionary<int, int> analyzedResultDic = new Dictionary<int, int>();
            foreach(var arrayItem in analyzeArray)
            {
                if (!analyzedResultDic.ContainsKey(arrayItem)) analyzedResultDic[arrayItem] = 0;

                analyzedResultDic[arrayItem]++;
            }

            int[] matchedArray = nums1.Length > nums2.Length ? nums1 : nums2;
            foreach(var matchItem in matchedArray)
            {
                if (!analyzedResultDic.ContainsKey(matchItem)) continue;

                forReturn.Add(matchItem);

                analyzedResultDic[matchItem]--;
                if (analyzedResultDic[matchItem] == 0) analyzedResultDic.Remove(matchItem);
                if (!analyzedResultDic.Any()) break;
            }

            return forReturn.ToArray();
        }
    }
}
