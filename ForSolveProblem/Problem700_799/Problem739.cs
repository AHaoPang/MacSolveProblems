using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem739 : IProblem
    {
        public void RunProblem()
        {
            var temp = DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
        }

        public int[] DailyTemperatures(int[] T)
        {
            /*
             * 对一个序列做处理，判断未来第一个比他大的数的位置
             * 思路：
             *  1.有种追溯的感觉
             *  2.一开始并不知道未来那个位置比他大，于是就留下来等待
             *  3.下一个比他小，就和他一起等待，前者有优先返还的权利
             *  4.知道后面没人了，等待的人无果而返
             *  5.栈内，其实是按照自大向小来排列的
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            int[] forReturn = new int[T.Length];
            Stack<int> waiters = new Stack<int>();

            for (int i = 0; i < T.Length; i++)
            {
                //到栈中去匹配
                while (waiters.Any() && T[waiters.Peek()] < T[i])
                {
                    forReturn[waiters.Peek()] = i - waiters.Peek();
                    waiters.Pop();
                }

                //把元素入栈
                waiters.Push(i);
            }

            //没有等到的，无果而返，数组什么都不用操作

            return forReturn;
        }
    }
}
