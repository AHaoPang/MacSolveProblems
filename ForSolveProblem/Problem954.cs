using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem954 : IProblem
    {
        public void RunProblem()
        {
            var temp = CanReorderDoubled(new int[] { 3, 1, 3, 6 });
            if (temp != false) throw new Exception();

            temp = CanReorderDoubled(new int[] { 2, 1, 2, 6 });
            if (temp != false) throw new Exception();

            temp = CanReorderDoubled(new int[] { 4, -2, 2, -4 });
            if (temp != true) throw new Exception();

            temp = CanReorderDoubled(new int[] { 1, 2, 4, 16, 8, 4 });
            if (temp != false) throw new Exception();
        }

        public bool CanReorderDoubled(int[] A)
        {
            /*
             * 判断给定的数组能否构造成特定顺序的数组
             * 思路
             *  1.数组的元素总数是偶数
             *  2.数组的奇数项总是比他前面的偶数项大2倍
             *  3.只有小的数字，才有可能存在2倍的大的数字，所以最好能从小的数字开始访问
             *  4.也需要统计各个数字的个数，以便快速判断2倍数
             *  
             * 时间复杂度：O(nlogn)，主要是排序的耗时
             * 空间复杂度：O(n)，用于存储元素和个数
             */

            var numCountDic = new Dictionary<int, int>(A.Length);
            foreach (var aItem in A)
            {
                var val = Math.Abs(aItem);

                if (!numCountDic.ContainsKey(val)) numCountDic[val] = 0;
                numCountDic[val]++;
            }

            var B = A.Select(i=>Math.Abs(i)).OrderBy(i => i).ToArray();
            foreach (var bItem in B)
            {
                if (numCountDic[bItem] == 0) continue;
                if (!numCountDic.ContainsKey(bItem * 2) || numCountDic[bItem * 2] == 0) return false;

                numCountDic[bItem]--;
                numCountDic[bItem * 2]--;
            }

            return true;
        }
    }
}
