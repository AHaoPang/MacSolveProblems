using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem137 : IProblem
    {
        public void RunProblem()
        {
            var temp = SingleNumber(new int[] { 2, 2, 3, 2 });
            if (temp != 3) throw new Exception();

            temp = SingleNumber(new int[] { 0, 1, 0, 1, 0, 1, 99 });
            if (temp != 99) throw new Exception();
        }

        public int SingleNumber(int[] nums)
        {
            /*
             * 数组中，只有一个元素出现了1次，其余元素都出现了3次，那么，这个出现了1次的元素的值是多少
             * 思路：
             *  1.利用set的特性，可以给所有元素都增加3倍，再减去已有数组中的值，得到的结果，应该是目标值的2倍
             *  
             * 时间复杂度：O(n)，遍历一次找到不重复的元素
             * 空间复杂度：O(n)，需要额外的空间来存储元素
             */

            var newNums = nums.Select(i => (long)i).ToArray();

            HashSet<long> numSet = new HashSet<long>(newNums);
            return (int)((numSet.Sum() * 3 - newNums.Sum()) / 2);
        }
    }
}
