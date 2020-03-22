using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem728 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<int> SelfDividingNumbers(int left, int right)
        {
            var constNum = (int)1e5;
            var forReturn = new List<int>(constNum / 2);

            for (var i = left; i <= right; i++)
            {
                var isOk = true;
                var num = i;
                while (num > 0)
                {
                    var n = num % 10;
                    if (n == 0 || i % n != 0)
                    {
                        isOk = false;
                        break;
                    }

                    num /= 10;
                }

                if (isOk) forReturn.Add(i);
            }

            return forReturn;
        }

        public IList<int> SelfDividingNumbers1(int left, int right)
        {
            if (m_innerArray == null)
                m_innerArray = GetRangeNum();

            return m_innerArray.Where(i => i >= left && i <= right).ToList();
        }

        private static ISet<int> m_innerArray;

        private ISet<int> GetRangeNum()
        {
            var constNum = (int)1e5;
            var forReturn = new HashSet<int>(constNum / 2);

            var flagArray = new bool[constNum + 1, 10];
            for (var i = 1; i <= 9; i++)
                for (var j = i; j <= constNum; j += i)
                    flagArray[j, i] = true;

            for (var i = 1; i <= constNum; i++)
            {
                var isTrue = true;
                var num = i;
                while (num > 0)
                {
                    var n = num % 10;
                    if (n == 0 || !flagArray[i, n])
                    {
                        isTrue = false;
                        break;
                    }

                    num /= 10;
                }

                if (isTrue)
                    forReturn.Add(i);
            }

            return forReturn;
        }
    }
}
