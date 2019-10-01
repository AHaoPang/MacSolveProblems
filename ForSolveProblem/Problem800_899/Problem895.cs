using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem895 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class FreqStack
        {
            /// <summary>
            /// 依据输入，来做汇总统计（同一个输入值，汇总到一起）
            /// </summary>
            Dictionary<int, int> m_inputCount = new Dictionary<int, int>();

            /// <summary>
            /// 依据出现的次数，来做汇总统计（同一个出现数量，汇总到一起）
            /// </summary>
            Dictionary<int, Stack<int>> m_freqCount = new Dictionary<int, Stack<int>>();

            /// <summary>
            /// 目前维护的输入中，出现的最大次数
            /// </summary>
            int m_maxCount = 0;

            public FreqStack()
            {

            }

            public void Push(int x)
            {
                if (!m_inputCount.ContainsKey(x)) m_inputCount[x] = 0;
                m_inputCount[x]++;

                int freqAmount = m_inputCount[x];

                m_maxCount = Math.Max(m_maxCount, freqAmount);

                if (!m_freqCount.ContainsKey(freqAmount)) m_freqCount[freqAmount] = new Stack<int>();
                m_freqCount[freqAmount].Push(x);
            }

            public int Pop()
            {
                var forReturn = m_freqCount[m_maxCount].Pop();

                if (!m_freqCount[m_maxCount].Any()) m_maxCount--;

                m_inputCount[forReturn]--;
                if (m_inputCount[forReturn] == 0) m_inputCount.Remove(forReturn);

                return forReturn;
            }
        }
    }
}
