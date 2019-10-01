using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem047 : IProblem
    {
        public void RunProblem()
        {
            var temp = PermuteUnique(new int[] { 0, 1, 0, 0, 9});
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            /*
             * 返回一个序列的不重复的全排列，因为给定的序列，可能会有重复的数字
             * 思路：
             *  1.这种全排列问题，可以在“原地”来操作
             *  2.每递归到一层，就要考虑把后面的哪个数字放到特定的位置
             *  3.把所有的位置都放好了，那么这就是所求全排列的一个结果
             *  
             * 时间复杂度：O(n!)，每一次循环的嵌套，都意味着一种结果
             * 空间复杂度：O(n!)，因为要存储全排列的结果
             *  
             * 考察点：
             *  1.回溯、递归
             *  2.排列组合相关
             *  
             * 提示：
             *  1.对于去重，目前想到两个方法
             *      1.1 方法1：就是依然做全排列，但是会在最后校验排列是否重复，用HashTable给序列构造唯一的key即可做判断
             *      1.2 方法2：就是通过剪枝的方法，即不要让一个节点长出两个相同的叶子即可，此种方式，需要对给出的序列做排序
             */

            IList<IList<int>> forReturn = new List<IList<int>>();

            BackTrace(nums, 0, forReturn);

            return forReturn;
        }

        private void BackTrace(int[] nums, int level, IList<IList<int>> forReturn)
        {
            if (level == nums.Length)
            {
                forReturn.Add(nums.ToList());
                return;
            }

            HashSet<int> alreadyTry = new HashSet<int>();
            for (int i = level; i < nums.Length; i++)
            {
                //同一个位置，没必要放两个可选项里面相同的数
                if (alreadyTry.Contains(nums[i])) continue;

                alreadyTry.Add(nums[i]);

                Swap(nums, level, i);
                BackTrace(nums, level + 1, forReturn);
                Swap(nums, level, i);
            }
        }

        private void Swap(int[] nums, int index1, int index2)
        {
            var temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
    }
}
