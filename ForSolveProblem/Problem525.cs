using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem525 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindMaxLength(new int[] { 0, 1 });
            if (temp != 2) throw new Exception();

            temp = FindMaxLength(new int[] { 0, 1, 0 });
            if (temp != 2) throw new Exception();
        }

        public int FindMaxLength(int[] nums)
        {
            /*
             * 从给定的0和1二进制表示中，统计出具有相同0和1个数子序列的最大长度
             * 思路：
             *  1.若建立一个基准值，0减少基准值1，1增加基准值1
             *  2.从第1个元素开始遍历，一直到最后一个元素，基准值会是一个上下波动的折线图
             *  3.在折线图上，具有相同基准值的两个索引位置之间的0和1的个数就是相同的
             *  4.基于以上的定理和推论，得到以下解法
             *      4.1 按照基准值结果来建立字典，存储的值是首次得到基准值的元素索引位置
             *      4.2 再次出现相同基准值时，当前元素索引位置到字典记录索引位置的距离，就是子串的长度
             *      
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var forReturn = 0;
            var baseValueDic = new Dictionary<int, int>() { { 0, -1 } };
            var baseSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                baseSum += (nums[i] == 1 ? 1 : -1);

                if (!baseValueDic.ContainsKey(baseSum)) baseValueDic[baseSum] = i;
                else
                {
                    var subValueTemp = i - baseValueDic[baseSum];
                    forReturn = Math.Max(forReturn, subValueTemp);
                }
            }

            return forReturn;
        }
    }
}
