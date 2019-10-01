using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem220 : IProblem
    {
        public void RunProblem()
        {
            int[] nums = new int[] { 1, 2, 3, 1 };
            int k = 3;
            int t = 0;

            var temp = ContainsNearbyAlmostDuplicate(nums, k, t);
            if (temp != true) throw new Exception();

            nums = new int[] { 1, 0, 1, 1 };
            k = 1;
            t = 2;
            temp = ContainsNearbyAlmostDuplicate(nums, k, t);
            if (temp != true) throw new Exception();

            nums = new int[] { 1, 5, 9, 1, 5, 9 };
            k = 2;
            t = 3;
            temp = ContainsNearbyAlmostDuplicate(nums, k, t);
            if (temp != false) throw new Exception();

            nums = new int[] { -1, 2147483647 };
            k = 1;
            t = 2147483647;
            temp = ContainsNearbyAlmostDuplicate(nums, k, t);
            if (temp != false) throw new Exception();
        }

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            /*
             * 在K的窗口内，查找两个距离小于t的元素
             * 思路：
             *  1.将题目转换为本质上的理解，是第一关
             *  2.基于上面的理解，考虑使用桶排序的方法
             *  3.对于k范围内的元素，要加入到桶中，超出k范围的元素，要移除
             *  4.以t为桶的大小
             *      4.1 桶内有元素了，那么条件满足
             *      4.2 相邻桶比较，存在则满足条件
             *  5.把元素放入正确的桶内，即映射是比较容易的~，但是元素的数据范围是整数，因此我们要考虑到负数放入哪个桶
             *      5.1 正数，只需要 和 t+1 取余就可以了
             *      5.2 负数，则需要矫正两次才行，先把元素+1，然后再取余，结果再做个偏移，就是桶的编号了（代入到现实的场景中，会更好理解一些）~~我大概理解了够10分钟
             *      
             * 时间复杂度：O(n)
             * 空间复杂度：O(min(n,k))
             */

            if (t < 0) return false;

            //作为容器桶，key是桶的编号，存放的内容是k窗口内的数
            Dictionary<long, long> bucketDic = new Dictionary<long, long>();

            long w = (long)t + 1;

            for (int i = 0; i < nums.Length; i++)
            {
                var bucketID = GetBucketID(nums[i], w);

                if (bucketDic.ContainsKey(bucketID)) return true;

                bucketDic[bucketID] = nums[i];

                if (bucketDic.ContainsKey(bucketID + 1)) if (bucketDic[bucketID + 1] - nums[i] <= t) return true;
                if (bucketDic.ContainsKey(bucketID - 1)) if (nums[i] - bucketDic[bucketID - 1] <= t) return true;

                if (i >= k) bucketDic.Remove(GetBucketID(nums[i - k], w));
            }

            return false;
        }

        private long GetBucketID(long v, long w)
        {
            if (v >= 0) return v / w;

            return (v + 1) / w - 1;
        }
    }
}
