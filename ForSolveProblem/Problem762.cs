using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem762 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountPrimeSetBits(6, 10);
            if (temp != 4) throw new Exception();

            temp = CountPrimeSetBits(10, 15);
            if (temp != 5) throw new Exception();
        }

        public int CountPrimeSetBits(int L, int R)
        {
            /*
             * 统计区间范围内，拥有质数个二进制1数字的个数
             * 思路：
             *  1.统计二进制位1个数的方法
             *  2.判断是否是质数
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            HashSet<int> primeNums = new HashSet<int>(new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19 });

            int forReturn = 0;
            for (int i = L; i <= R; i++)
                if (primeNums.Contains(OnePosCount(i))) forReturn++;

            return forReturn;
        }

        private int OnePosCount(int num)
        {
            int forReturn = 0;

            while (num != 0)
            {
                forReturn++;
                num = num & (num - 1);
            }

            return forReturn;
        }
    }
}
