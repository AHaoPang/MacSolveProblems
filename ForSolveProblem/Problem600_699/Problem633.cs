using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem633 : IProblem
    {
        public void RunProblem()
        {
            var temp = JudgeSquareSum(5);
            if (temp != true) throw new Exception();

            temp = JudgeSquareSum(3);
            if (temp != false) throw new Exception();

            temp = JudgeSquareSum(4);
            if (temp != true) throw new Exception();

            temp = JudgeSquareSum(2);
            if (temp != true) throw new Exception();
        }

        public bool JudgeSquareSum(int c)
        {
            var maxInt = (int)Math.Sqrt(c);
            var minInt = 0;

            while(minInt <= maxInt)
            {
                var sumInt = minInt * minInt + maxInt * maxInt;

                if (sumInt == c) return true;

                if (sumInt > c) maxInt--;
                else minInt++;
            }

            return false;
        }

        public bool JudgeSquareSum1(int c)
        {
            /*
             * 判断给定的正整数是否是两个平方数的和
             * 思路：
             *  1.从1开始，n^2增长的速度是很快的，所以可以考虑使用循环的方式，渐进增大
             *  2.上限值就是 c 开方后的结果
             *  3.循环的过程中，不断产生目标值，一旦有一个目标值被命中了，那么就正常c是是满足要求的整数
             *  
             * 时间复杂度：O(c 开方)
             * 空间复杂度：O(c 开方)
             */

            var maxInt = (int)Math.Sqrt(c);
            var resultHashSet = new HashSet<int>(maxInt);

            for(int i = 0;i <= maxInt; i++)
            {
                var resultTemp = i * i;
                resultHashSet.Add(c - resultTemp);

                if (resultHashSet.Contains(resultTemp)) return true;
            }

            return false;
        }
    }
}
