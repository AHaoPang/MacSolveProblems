using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem698 : IProblem
    {
        public void RunProblem()
        {
            var nums = new int[] { 4, 3, 2, 3, 5, 2, 1 };
            int k = 4;
            var temp = CanPartitionKSubsets(nums, k);
        }

        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            /*
             * 思路：
             * 1.以桶为基准，放满一个再放另一个；
             * 2.这种思路可以遍历更少的可能性；因为放满一个桶的可能性是有限的，就能提前预知不可能的情况，进而提前剪枝
             * 
             * 注意：
             * 1.桶本身是无序的，但是我们可以让其有序，即让数组本身有序的前提下；
             * 
             * 时间复杂度：数组排序是O(nlogn) 递归满足要求是O(k*n)
             * 空间复杂度：O(n)，n个数字，都存在的字典中
             */

            int sumTemp = 0;
            int maxTemp = 0;
            Dictionary<int, int> numDic = new Dictionary<int, int>();

            foreach (var numsItem in nums)
            {
                sumTemp += numsItem;

                if (maxTemp < numsItem) maxTemp = numsItem;

                if (!numDic.ContainsKey(numsItem)) numDic[numsItem] = 0;
                numDic[numsItem]++;
            }

            if (sumTemp % k != 0) return false;

            preSum = sumTemp / k;
            if (maxTemp > preSum) return false;

            orderedNums = nums.OrderByDescending(i => i).ToArray();

            return Recursive2(numDic, k, preSum);
        }

        private int preSum = 0;
        private int[] orderedNums = null;

        private bool Recursive2(Dictionary<int, int> dic, int k, int restValue)
        {
            //end point其实是有两个的
            if (k == 0) return true;
            if (restValue == 0) return Recursive2(dic, k - 1, preSum);

            foreach (var dicItem in orderedNums)
            {
                if (dic[dicItem] == 0 || restValue - dicItem < 0) continue;

                dic[dicItem]--;
                if (Recursive2(dic, k, restValue - dicItem)) return true;
                dic[dicItem]++;
            }

            return false;
        }



        public bool CanPartitionKSubsets2(int[] nums, int k)
        {
            /*
             * 思路：回溯法
             * 1.序列中的每个数字，都有放在k个不同集的可能性；（假设集合有序，编号0~K-1）
             * 2.将各种不同的组合穷举出来，然后分别去验证是否满足要求
             * 3.若所有的组合都不满足要求，那么结果就是false
             * 
             * 时间复杂度：O(m^n) --> 指数级别的，复杂度异常的高了
             * 
             * 尝试使用剪枝的方式，来减少计算规模，即提前排除掉不可能的情况；
             */

            //校验可能性
            int sumTemp = 0;
            foreach (var numItem in nums) sumTemp += numItem;

            var eachGroupCount = sumTemp / k;
            if (eachGroupCount * k != sumTemp) return false;

            return Recursive(nums, k, 0, new int[k], eachGroupCount);
        }

        private bool Recursive(int[] nums, int k, int arrayIndex, int[] resultArray, int eachGroupCount)
        {
            if (arrayIndex == nums.Length) return true;

            for (int i = 0; i < k; i++)
            {
                if (resultArray[i] == eachGroupCount) break;

                resultArray[i] += nums[arrayIndex];

                //校验可能性
                bool isTrue = true;
                if (resultArray[i] > eachGroupCount) isTrue = false;

                if (isTrue && Recursive(nums, k, arrayIndex + 1, resultArray, eachGroupCount)) return true;

                resultArray[i] -= nums[arrayIndex];
            }

            //所有可能性都试过了，还没有满足要求的，那么就说明不可能了
            return false;
        }
    }
}
