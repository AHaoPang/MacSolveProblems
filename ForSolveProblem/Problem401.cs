using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem401 : IProblem
    {
        public void RunProblem()
        {
            var temp = ReadBinaryWatch(1);
        }

        public IList<string> ReadBinaryWatch(int num)
        {
            /*
             * 二进制手表亮灯读数可能性穷举
             * 思路：
             *  1.其实输入的数字是有限的 0~10,逻辑上也不可能全部亮灯的，全部灭灯倒是有可能，哈哈
             *  2.可以去按照亮灯的数量去拼组合，然后判断逻辑合理性
             *  3.也可以去依据合理性，判断亮灯的数量是否满足要求
             *  4.两种方式都还好，第二种会简单粗暴一些，但是考虑到整体的可能性规模 24*60=1440，这个循环的量并不大
             *  5.再加上一些剪枝的处理，效率显然会有提升
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            if (num < 0 || num >= 10) throw new Exception("传入的参数不合理");

            var forReturn = new List<string>();

            for (int h = 0; h < 12; h++)
            {
                var hOneAmount = CountOneAmount(h);
                if (hOneAmount > num) continue;

                for (int m = 0; m < 60; m++)
                {
                    if (hOneAmount + CountOneAmount(m) == num)
                    {
                        var mStr = m.ToString().Length == 1 ? '0' + m.ToString() : m.ToString();
                        forReturn.Add($"{h,1}:{mStr}");
                    }
                }
            }

            return forReturn;
        }

        private int CountOneAmount(int num)
        {
            int forReturn = 0;

            while (num != 0)
            {
                forReturn++;
                num = (num & num - 1);
            }

            return forReturn;
        }
    }
}
