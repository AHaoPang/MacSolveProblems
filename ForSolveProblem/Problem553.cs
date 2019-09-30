using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem553 : IProblem
    {
        public void RunProblem()
        {
            var temp = OptimalDivision(new int[] { 1000, 100, 10, 2 });
            if (temp != "1000/(100/10/2)") throw new Exception();
        }

        public string OptimalDivision(int[] nums)
        {
            /*
             * 最优除法
             * 思路：
             *  1.给定的数字都是正整数
             *  2.为了让结果最大，那么肯定要让 除数尽可能大 被除数尽可能小
             *  3.因此，结论就是比较简单的了，把第二个及以后的数字，加上括号即可
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var forReturn = string.Join("/", nums);

            if (nums.Length <= 2) return forReturn;

            return forReturn.Insert(forReturn.IndexOf('/') + 1, "(") + ")";
        }
    }
}
