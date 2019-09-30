using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem313 : IProblem
    {
        public void RunProblem()
        {
            var temp = NthSuperUglyNumber(12, new int[] { 2, 7, 13, 19 });
            if (temp != 32) throw new Exception();
        }

        public int NthSuperUglyNumber(int n, int[] primes)
        {
            /*
             * 依据给定的数去依次生成逐渐增大的数
             * 思路：
             *  1.依据已有的链数据，去生成新链的节点
             *  
             * 时间复杂度：O(n*m)
             * 空间复杂度：O(m)
             */

            var posIndexDic = new Dictionary<int, (int, int)>(primes.Length);
            var resArray = new int[n];
            resArray[0] = 1;

            for (int i = 0; i < primes.Length; i++)
                posIndexDic[primes[i]] = (primes[i], 0);

            for (int i = 1; i < n; i++)
            {
                int minValue = int.MaxValue;

                for (int j = 0; j < primes.Length; j++)
                    minValue = Math.Min(minValue, posIndexDic[primes[j]].Item1);

                resArray[i] = minValue;

                for (int j = 0; j < primes.Length; j++)
                {
                    if (minValue != posIndexDic[primes[j]].Item1) continue;

                    int newIndex = posIndexDic[primes[j]].Item2 + 1;
                    int newValue = resArray[newIndex] * primes[j];
                    posIndexDic[primes[j]] = (newValue, newIndex);
                }
            }

            return resArray[n - 1];

            /*
            var posIndexArray = new int[primes.Length];
            var resArray = new int[n];
            resArray[0] = 1;
            for (int i = 1; i < n; i++)
            {
                int minValue = int.MaxValue;

                for (int j = 0; j < primes.Length; j++)
                    minValue = Math.Min(minValue, resArray[posIndexArray[j]] * primes[j]);

                for (int j = 0; j < primes.Length; j++)
                    if (resArray[posIndexArray[j]] * primes[j] == minValue) posIndexArray[j]++;

                resArray[i] = minValue;
            }

            return resArray[n - 1];
            */
        }
    }
}
