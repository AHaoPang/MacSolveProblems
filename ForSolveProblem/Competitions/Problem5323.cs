using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5323 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] SortByBits(int[] arr)
        {
            var bitDic = new Dictionary<int, List<int>>();
            foreach (var arrItem in arr)
            {
                var oneCount = GetOneCount(arrItem);

                if (!bitDic.ContainsKey(oneCount))
                    bitDic[oneCount] = new List<int>();

                bitDic[oneCount].Add(arrItem);
            }

            var forReturn = new List<int>();

            var orderBit = bitDic.OrderBy(i => i.Key);
            foreach (var orderList in orderBit)
            {
                var numArray = orderList.Value.OrderBy(i => i);
                forReturn.AddRange(numArray);
            }

            return forReturn.ToArray();
        }

        private int GetOneCount(int num)
        {
            var forReturn = 0;
            while (num != 0)
            {
                forReturn++;
                num &= num - 1;
            }

            return forReturn;
        }
    }
}
