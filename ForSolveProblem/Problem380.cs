using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem380 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class RandomizedSet
        {
            private IDictionary<int,int> m_valDic;
            private IList<int> m_valList;

            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                m_valDic = new Dictionary<int, int>();
                m_valList = new List<int>();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                var forReturn = false;

                if (!m_valDic.ContainsKey(val))
                {
                    forReturn = true;
                    m_valList.Add(val);

                    m_valDic[val] = m_valList.Count - 1;
                }

                return forReturn;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                var forReturn = false;

                if (m_valDic.ContainsKey(val))
                {
                    forReturn = true;

                    int valIndex = m_valDic[val];
                    int lastValue = m_valList.Last();
                    m_valList[valIndex] = lastValue;
                    m_valDic[lastValue] = valIndex;

                    m_valDic.Remove(val);
                    m_valList.RemoveAt(m_valList.Count - 1);
                }

                return forReturn;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                Random r = new Random();
                var randomIndex = r.Next(0, m_valList.Count);

                return m_valList[randomIndex];
            }
        }
    }
}
