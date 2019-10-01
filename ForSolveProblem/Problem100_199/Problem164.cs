using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem164 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaximumGap(new int[] { 12115, 10639, 2351, 29639, 31300, 11245, 16323, 24899, 8043, 4076, 17583, 15872, 19443, 12887, 5286, 6836, 31052, 25648, 17584, 24599, 13787, 24727, 12414, 5098, 26096, 23020, 25338, 28472, 4345, 25144, 27939, 10716, 3830, 13001, 7960, 8003, 10797, 5917, 22386, 12403, 2335, 32514, 23767, 1868, 29882, 31738, 30157, 7950, 20176, 11748, 13003, 13852, 19656, 25305, 7830, 3328, 19092, 28245, 18635, 5806, 18915, 31639, 24247, 32269, 29079, 24394, 18031, 9395, 8569, 11364, 28701, 32496, 28203, 4175, 20889, 28943, 6495, 14919, 16441, 4568, 23111, 20995, 7401, 30298, 2636, 16791, 1662, 27367, 2563, 22169, 1607, 15711, 29277, 32386, 27365, 31922, 26142, 8792 });
        }

        public int MaximumGap(int[] nums)
        {
            /*
             * 思路：桶排序的思想
             * 解决的问题：比较序列的最大差值
             * 1.整数，其实是有范围的；
             * 2.范围内的数字多于范围本身，那么按照范围内的最大统数量来做；
             * 3.范围内的数字少于范围本身，那么单个木桶的容量就会更大一些；
             * 4.依次递增的木桶，反映了平均的趋势，因此桶内的序列差值不可能达到最大；
             * 5.最大差值，显然是在桶与桶之间存在的
             * 
             * 时间复杂度：O(n)，先把数字放在各自的桶中，再比较桶与桶之间的差值就好了，所以基本上只要遍历3次就知道答案了；
             * 空间复杂度：O(n)，需要把所有的数字放在各自的桶内，那么在最坏的情况下，桶的数量和数列大小就是一致的了；
             */


            int forReturn = 0;
            if (nums.Length < 2) return forReturn;

            int minNum = int.MaxValue;
            int maxNum = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < minNum) minNum = nums[i];
                if (nums[i] > maxNum) maxNum = nums[i];
            }

            int bucketSize = Math.Max(1, (maxNum - minNum) / (nums.Length - 1));
            int bucketCount = (maxNum - minNum) / bucketSize + 1;
            Bucket[] buckets = new Bucket[bucketCount];
            for (int j = 0; j < nums.Length; j++)
            {
                int bucketIndex = (nums[j] - minNum) / bucketSize;
                if (buckets[bucketIndex] == null) buckets[bucketIndex] = new Bucket();
                buckets[bucketIndex].minval = Math.Min(buckets[bucketIndex].minval, nums[j]);
                buckets[bucketIndex].maxval = Math.Max(buckets[bucketIndex].maxval, nums[j]);
            }

            int pre = 0;
            for (int k = 1; k < bucketCount; k++)
            {
                if (buckets[k] == null) continue;
                forReturn = Math.Max(forReturn, buckets[k].minval - buckets[pre].maxval);
                pre = k;
            }

            return forReturn;
        }

        public class Bucket
        {
            public int minval = int.MaxValue;
            public int maxval = int.MinValue;
        }

        public int MaximumGap3(int[] nums)
        {
            if (nums.Length < 2) return 0;

            int minNum = nums.Min(), maxNum = nums.Max();
            int bucketSize = Math.Max(1, (maxNum - minNum) / (nums.Length - 1));
            int bucketCount = (maxNum - minNum) / bucketSize + 1;
            Bucket[] buckets = new Bucket[bucketCount];
            for (int i = 0; i < nums.Length; i++)
            {
                int index = (nums[i] - minNum) / bucketSize;
                if (buckets[index] == null) buckets[index] = new Bucket();
                buckets[index].minval = Math.Min(buckets[index].minval, nums[i]);
                buckets[index].maxval = Math.Max(buckets[index].maxval, nums[i]);
            }

            int pre = 0, maxGap = 0;
            for (int i = 0; i < bucketCount; i++)
            {
                if (buckets[i] == null) continue;
                maxGap = Math.Max(maxGap, buckets[i].minval - buckets[pre].maxval);
                pre = i;
            }

            return maxGap;
        }

        public int MaximumGap2(int[] nums)
        {
            /*
             * 思路：借用key-value的方式，再结合有序字典
             */


            int forReturn = 0;
            if (nums.Length < 2) return forReturn;

            SortedDictionary<int, int> sortedDic = new SortedDictionary<int, int>();

            foreach (var numItem in nums)
                sortedDic[numItem] = 1;

            var keys = sortedDic.Keys.ToList();
            for (int i = 0; i < keys.Count - 1; i++)
                if (keys[i + 1] - keys[i] > forReturn) forReturn = keys[i + 1] - keys[i];

            return forReturn;
        }

        public int MaximumGap1(int[] nums)
        {
            /*
             * 思路：
             * 1.先对数组排序；
             * 2.然后比较相邻的数字的差值，取到最大值；
             * 
             * 时间复杂度：O(nlogn)
             * 空间复杂度: O(1)
             */

            if (nums.Length < 2) return 0;

            var orderedNums = nums.OrderBy(i => i).ToList();

            int maxGapTemp = 0;
            for (int i = 0; i < orderedNums.Count - 1; i++)
                if (orderedNums[i + 1] - orderedNums[i] > maxGapTemp) maxGapTemp = orderedNums[i + 1] - orderedNums[i];

            return maxGapTemp;
        }
    }
}
