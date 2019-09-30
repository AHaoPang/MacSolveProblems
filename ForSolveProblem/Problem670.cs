using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem670 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaximumSwap(2736);
            if (temp != 7236) throw new Exception();

            temp = MaximumSwap(9973);
            if (temp != 9973) throw new Exception();

            temp = MaximumSwap(1993);
            if (temp != 9913) throw new Exception();
        }

        public int MaximumSwap(int num)
        {
            /*
             * 交换两个数的位置，来得到一个最大的数
             * 思路：
             *  1.若各数字可自由排序的话，最大的数一定是各个数字的倒叙排列
             *  2.现在要求只能交换两个数字，那么可以将现有数字与倒叙排列数字比较
             *      2.1 若两个数字排列相同，那么本身就是最大的数字了，不需要交换数字了
             *      2.2 有一个位置上的数字不同了，当前位置上是其它的数字，那么就应该把应该放的数字，与当前位置的数字交换
             *      
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            var numStr = num.ToString();
            var maxNumStr = numStr.OrderByDescending(i => i).ToArray();
            var rawNumStr = numStr.Select(i => i).ToArray();
            for (int i = 0; i < rawNumStr.Length; i++)
            {
                if (maxNumStr[i] != rawNumStr[i])
                {
                    for (int j = rawNumStr.Length - 1; j > i; j--)
                    {
                        if (rawNumStr[j] == maxNumStr[i])
                        {
                            var temp = rawNumStr[i];
                            rawNumStr[i] = rawNumStr[j];
                            rawNumStr[j] = temp;
                            break;
                        }
                    }
                    break;
                }
            }

            return int.Parse(new string(rawNumStr));
        }
    }
}
