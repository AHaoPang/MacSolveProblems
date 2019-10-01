using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem219 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            /*
             * 若数组中存在重复的元素，那么重复的元素的距离，是否存在最大为K的情况
             * 思路：
             *  1.此判断分为两个部分
             *      1.1 是否存在重复的元素
             *      1.2 若存在重复元素，那么位置的差异是多少呢
             *      
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             * 
             * 关于题目的理解过程：位置差的绝对值，最大为K，那么
             *  1.包含多个元素时，主要部分元素位置的差 <= k，即可
             *  2.差  <= k
             *  
             * 这个题目很容易引起歧义，不太好啊
             */

            Dictionary<int, List<int>> numPosCount = new Dictionary<int, List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!numPosCount.ContainsKey(nums[i])) numPosCount[nums[i]] = new List<int>();

                if (numPosCount[nums[i]].Any())
                    foreach (var dicItem in numPosCount[nums[i]]) if (i - dicItem <= k) return true;

                numPosCount[nums[i]].Add(i);
            }

            return false;
        }
    }
}
