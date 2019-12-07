using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1157 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class MajorityChecker
        {
            private Dictionary<int, int>[] m_dicArray;

            public MajorityChecker(int[] arr)
            {
                m_dicArray = new Dictionary<int, int>[arr.Length];

                var startDic = new Dictionary<int, int>(arr.Length);
                for (int i = 0; i < arr.Length; i++)
                {
                    var arrItem = arr[i];
                    if (!startDic.ContainsKey(arrItem)) startDic[arrItem] = 0;

                    startDic[arrItem]++;

                    m_dicArray[i] = startDic.ToDictionary(keyItem => keyItem.Key, valueItem => valueItem.Value);
                }
            }

            public int Query(int left, int right, int threshold)
            {
                Dictionary<int, int> resultDic;
                var leftTemp = left - 1;
                if (leftTemp < 0)
                    resultDic = m_dicArray[right];
                else
                    resultDic = DicSub(m_dicArray[right], m_dicArray[leftTemp]);

                foreach (var resultItem in resultDic)
                    if (resultItem.Value >= threshold) return resultItem.Key;

                return -1;
            }

            private Dictionary<int, int> DicSub(Dictionary<int, int> bigger, Dictionary<int, int> smaller)
            {
                var forReturn = new Dictionary<int, int>(bigger.Count);
                foreach (var bigItem in bigger)
                {
                    if (!smaller.ContainsKey(bigItem.Key))
                        forReturn[bigItem.Key] = bigItem.Value;
                    else
                        forReturn[bigItem.Key] = bigItem.Value - smaller[bigItem.Key];
                }

                return forReturn;
            }
        }
    }
}
