using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5341 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class ProductOfNumbers
        {
            private IList<int> m_innerResult;
            private IList<int> m_zeroPos;

            public ProductOfNumbers()
            {
                m_innerResult = new List<int>();
                m_zeroPos = new List<int>();
            }

            public void Add(int num)
            {
                if (m_innerResult.Count == 0 || m_innerResult.Last() == 0)
                    m_innerResult.Add(num);
                else
                    m_innerResult.Add(num * m_innerResult.Last());

                if (num == 0)
                    m_zeroPos.Add(m_innerResult.Count);
            }

            public int GetProduct(int k)
            {
                var isIncludeZero = false;
                var endPos = m_innerResult.Count;
                var startPos = endPos - k + 1;
                for (int i = m_zeroPos.Count - 1; i >= 0; i--)
                {
                    var curPos = m_zeroPos[i];

                    if (curPos < startPos) break;
                    if (curPos >= startPos && curPos <= endPos)
                    {
                        isIncludeZero = true;
                        break;
                    }
                }

                if (isIncludeZero) return 0;

                var startIndex = m_innerResult.Count - 1 - k;
                if (startIndex == -1 || m_innerResult[startIndex] == 0)
                    return m_innerResult.Last();

                return m_innerResult.Last() / m_innerResult[startIndex];
            }
        }
    }
}
