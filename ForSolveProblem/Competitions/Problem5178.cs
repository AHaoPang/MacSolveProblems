using System;
namespace ForSolveProblem
{
    public class Problem5178 : IProblem
    {
        public void RunProblem()
        {
            var temp = SumFourDivisors(new int[] { 21, 4, 7 });
        }

        public int SumFourDivisors(int[] nums)
        {
            /*
             * ##### 1. 题目概述：四因数
             * 
             * ##### 2. 思路：
             *    - 特征：因数,就是乘积等于目标值的两个数;除了 1 和自身的乘积外,仅有一对因子时,才是满足条件的解;
             *    - 方案：依次去判断每个数字是否为四因数,将满足条件的数字的因子累加起来;
             *    - 结果：累加的结果
             *
             * ##### 3. 知识点：因数
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n * sqrt(1e5))
             *    - 空间复杂度：O(1)
             */

            var res = 0;
            foreach (var numItem in nums)
            {
                var maxNum = (int)Math.Sqrt(numItem);
                var count = 0;
                var sum = 0;
                for (var i = 1; i <= maxNum; i++)
                {
                    if (numItem % i == 0)
                    {
                        count++;
                        sum += i + numItem / i;
                    }

                    if (count > 2)
                        break;
                }

                if (count == 2 && maxNum * maxNum != numItem)
                    res += sum;
            }

            return res;
        }

        public int SumFourDivisors1(int[] nums)
        {
            if (m_CountArray == null)
            {
                m_prime = GetPrimeArray();
                m_CountArray = GetCountArray(m_prime);
            }

            var forReturn = 0;
            foreach (var n in nums)
            {
                if (m_CountArray[n] != 4)
                    continue;

                forReturn += 1 + n + m_prime[n] + (n / m_prime[n]);
            }

            return forReturn;
        }

        private static int[] m_prime;
        private static int[] m_CountArray;

        private int[] GetPrimeArray()
        {
            var constNum = (int)1e5 + 1;
            var forReturn = new int[constNum];
            forReturn[1] = 1;

            for (var i = 2; i * i < constNum; i++)
            {
                if (forReturn[i] != 0) continue;

                forReturn[i] = i;

                for (var j = i * 2; j < constNum; j += i)
                {
                    if (forReturn[j] != 0) continue;

                    forReturn[j] = i;
                }
            }

            for (var i = 2; i < constNum; i++)
                if (forReturn[i] == 0)
                    forReturn[i] = i;

            return forReturn;
        }

        private int[] GetCountArray(int[] primeArray)
        {
            var forReturn = new int[primeArray.Length];
            forReturn[1] = 1;
            for (var i = 2; i < primeArray.Length; i++)
            {
                var n = i;
                var c = 0;
                var p = primeArray[i];
                while (n % p == 0)
                {
                    c++;
                    n /= p;
                }

                forReturn[i] = forReturn[n] * (c + 1);
            }

            return forReturn;
        }
    }
}
