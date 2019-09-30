using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem961 : IProblem
    {
        public void RunProblem()
        {
            var temp = RepeatedNTimes(new int[] { 1, 2, 3, 3 });
            if (temp != 3) throw new Exception();

            temp = RepeatedNTimes(new int[] { 2, 1, 2, 5, 3, 2 });
            if (temp != 2) throw new Exception();

            temp = RepeatedNTimes(new int[] { 5, 1, 5, 2, 5, 3, 5, 4 });
            if (temp != 5) throw new Exception();

            temp = RepeatedNTimes(new int[] { 5, 1, 2, 1 });
            if (temp != 1) throw new Exception();
        }

        public int RepeatedNTimes(int[] A)
        {
            /*
             * 查找重复出现了N次的元素
             * 思路：
             *  1.数组总长为2N，一共有N+1个元素，那么一个元素重复N次后，其它元素一定都只有一个
             *  2.如果N个元素与重复的元素交叉排列，那么，要么奇数位相同，要么偶数位相同
             *  3.如果不是交叉排列的话，就一定存在相邻元素重复的情况
             *  
             * 时间复杂度：O(n)，最坏情况是把数组都遍历一次
             * 空间复杂度：O(1)，不使用额外的可变空间
             */

            if (A[1] == A[3]) return A[1];

            for (int i = 0; i < A.Length - 1; i++)
                if (A[i] == A[i + 1]) return A[i];

            return A[0];
        }

        public int RepeatedNTimes2(int[] A)
        {
            /*
             * 查找重复出现了N次的元素
             * 思路：
             *  1.元素长度为2N，一共有N+1种不同的元素，一个元素出现了N次，那么显然其它元素只出现了一次
             *  2.那么就遍历统计这个数组好了，发现第一个重复的元素，那么就是它了
             *  
             * 时间复杂度：O(n)，最坏情况下，需要遍历N+2个元素才知道
             * 空间复杂度：O(n)，最坏情况下，需要存储N+1个元素
             * 
             * 考察点：空间换时间
             */

            HashSet<int> elements = new HashSet<int>();
            foreach (var item in A)
            {
                if (elements.Contains(item)) return item;

                elements.Add(item);
            }

            throw new Exception();
        }
    }
}
