using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem970 : IProblem
    {
        public void RunProblem()
        {
            var temp = PowerfulIntegers(2, 3, 10);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 2, 3, 4, 5, 7, 9, 10 })) throw new Exception();

            temp = PowerfulIntegers(3, 5, 15);
            if (!ProblemHelper.ArrayIsEqual(temp.ToArray(), new int[] { 2, 4, 6, 8, 10, 14 })) throw new Exception();

            temp = PowerfulIntegers(2, 1, 10);

        }

        public IList<int> PowerfulIntegers(int x, int y, int bound)
        {
            /*
             * 依据原始给出的数，拼接出满足条件的数字
             * 思路：
             *  1.其实就是相当于一个累积木的游戏
             *  2.首先要找好所有的积木，并存储起来，即X和Y各个满足要求的幂
             *  3.然后就是一个双重的循环了，将结果存储在一个Set中
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            var xDic = MadeList(x, bound);
            var yDic = MadeList(y, bound);

            var forReturn = new HashSet<int>();
            for (int i = 0; i < xDic.Count; i++)
            {
                for (int j = 0; j < yDic.Count; j++)
                {
                    var sumTemp = xDic[i] + yDic[j];
                    if (sumTemp <= bound) forReturn.Add(sumTemp);
                }
            }

            return forReturn.ToList();
        }

        private IList<int> MadeList(int i, int bound)
        {
            var forReturn = new List<int>() { 1 };
            if (i == 1) return forReturn;

            var sum = 1;
            while (sum <= bound)
            {
                sum *= i;
                forReturn.Add(sum);
            }

            return forReturn;
        }
    }
}
