using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Exam_59_II : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        /*
         * ##### 1. 题目概述：队列的最大值
         * 
         * ##### 2. 思路：
         *    - 特征：既是队列那么就满足队列的特性,即先进先出的特性;不同的点在于此队列还能直接告知当前队列中的最大值是多少,显然还需要维护额外的信息来达成这一目标;
         *    - 方案：除了队列自身的维护外,还需要再维护一个链表,填入的内容是一个降序的元素序列;若新加入元素比尾元素大,那么就将尾元素移除,然后将新元素加入尾部;若队列弹出元素是最大值,那么序列中也要相应移除第一个元素
         *    - 结果：数据的进和出,由队列负责,每时每刻的最大值,由链表负责
         *
         * ##### 3. 知识点：队列 链表
         * 
         * ##### 4. 复杂度分析: 
         *    - 时间复杂度：O(n)
         *    - 空间复杂度：O(n)
         */
        public class MaxQueue
        {
            private Queue<int> m_innerNumQueue;
            private LinkedList<int> m_maxLinked;

            public MaxQueue()
            {
                m_innerNumQueue = new Queue<int>();
                m_maxLinked = new LinkedList<int>();
            }

            public int Max_value()
            {
                if (!m_maxLinked.Any()) return -1;

                return m_maxLinked.First.Value;
            }

            public void Push_back(int value)
            {
                m_innerNumQueue.Enqueue(value);

                while (m_maxLinked.Any() && value > m_maxLinked.Last.Value)
                    m_maxLinked.RemoveLast();
                m_maxLinked.AddLast(value);
            }

            public int Pop_front()
            {
                if (!m_innerNumQueue.Any()) return -1;

                var forReturn = m_innerNumQueue.Dequeue();
                if (forReturn == Max_value())
                    m_maxLinked.RemoveFirst();

                return forReturn;
            }
        }
    }
}
