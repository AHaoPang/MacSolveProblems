using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem365 : IProblem
    {
        public void RunProblem()
        {
            var temp = CanMeasureWater(3, 5, 4);
            if (temp != true) throw new Exception();

            temp = CanMeasureWater(2, 6, 5);
            if (temp != false) throw new Exception();

            temp = CanMeasureWater(0, 0, 1);
            if (temp != false) throw new Exception();

            temp = CanMeasureWater(0, 2, 1);
        }

        private int GetGcd(int x, int y)
        {
            /* 要考虑一个为0，以及两个都为0的情况 */

            int a = Math.Max(x, y);
            int b = Math.Min(x, y);

            while (a != b && b > 0)
            {
                var t = a - b;

                a = Math.Max(t, b);
                b = Math.Min(t, b);
            }

            return a;
        }

        public bool CanMeasureWater(int x, int y, int z)
        {
            /*
             * 这道题还真是波折啊
             * 1.出题时，z居然还大于x和y之和
             * 2.求最大公约数时，没想到的
             *      2.1 求差以后，得到的值，可能依然很大，需要放在减数的位置
             *      2.2 被减数可能是 0，导致陷入死循环，细想下，被减数是0时，那么减数就是最大公约数了
             *      2.3 减数和被减数都是0，那么导致死循环
             * 3.z可能是0，那么就是一定可以满足的
             */

            if (x + y < z) return false;

            var gcd = GetGcd(x, y);
            return z == 0 || (gcd != 0 && z % gcd == 0);
        }

        public bool CanMeasureWater1(int x, int y, int z)
        {
            /*
             * 两个数字x和y，是否可以在n次相互操作后，得到z
             * 思路：
             *  1.试图用x和y得到所有的可能性，然后验证z是否在可能性里面
             *  2.z大于x+y时，取余即可。即，z的范围会被限制在0<=z<=x+y
             *  3.x和y互操作，可以得到新的数字，x和y再与新的数字互操作，期望再产生新的数字
             *  
             * 时间复杂度：O(x+y)
             * 空间复杂度：O(x+y)
             */

            var totalPossibityNums = new HashSet<int>() { 0 };
            var numQueue = new Queue<int>();

            var xySub = Math.Abs(x - y);
            numQueue.Enqueue(xySub);
            totalPossibityNums.Add(xySub);

            var limit = x + y;
            while (numQueue.Any())
            {
                var curValue = numQueue.Dequeue();

                AddNumsToHashAndQueue(totalPossibityNums, numQueue, limit, x, curValue);
                AddNumsToHashAndQueue(totalPossibityNums, numQueue, limit, x, -curValue);
                AddNumsToHashAndQueue(totalPossibityNums, numQueue, limit, y, curValue);
                AddNumsToHashAndQueue(totalPossibityNums, numQueue, limit, y, -curValue);
            }

            return totalPossibityNums.Contains(z);
        }

        public void AddNumsToHashAndQueue(ISet<int> sets, Queue<int> queue, int limit, int firstNum, int secondNum)
        {
            var num = Math.Abs(firstNum - secondNum);
            if (sets.Contains(num) || num > limit) return;

            sets.Add(num);
            queue.Enqueue(num);
        }
    }
}
