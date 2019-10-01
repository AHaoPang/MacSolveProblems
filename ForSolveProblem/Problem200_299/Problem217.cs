using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem217 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool ContainsDuplicate(int[] nums)
        {
            /*
             * 判断一个数组中，是否包含重复的元素
             * 思路：
             *  1.遍历元素的时候，知道是否有过这个元素，作为判断的主要思想
             *  2.需要一个HashTable来存储已知存在的元素，进而去判断新遍历到的元素是否存在
             *  
             * 时间复杂度：O(n)，最坏情况是把数组完全遍历一遍，发现并没有重复
             * 空间复杂度：O(n)
             */

            HashSet<int> hasNums = new HashSet<int>();

            foreach (var numItem in nums)
            {
                if (hasNums.Contains(numItem)) return true;
                hasNums.Add(numItem);
            }

            return false;
        }
    }
}
