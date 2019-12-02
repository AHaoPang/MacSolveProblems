using System;
namespace ForSolveProblem.Tools
{
    /// <summary>
    /// 并查集
    /// </summary>
    public class DisJointSet
    {
        /// <summary>
        /// 内部维护的数组
        /// </summary>
        private int[] m_parents;

        /// <summary>
        /// 初始化一个并查集
        /// </summary>
        public DisJointSet(int initCapacity)
        {
            m_parents = new int[initCapacity];

            for (int i = 0; i < initCapacity; i++)
                m_parents[i] = i;
        }

        /// <summary>
        /// 找到元素所在的团体
        /// </summary>
        public int Find(int i)
        {
            if (m_parents[i] != i)
                m_parents[i] = Find(m_parents[i]);

            return m_parents[i];
        }

        /// <summary>
        /// 合并两个团体
        /// </summary>
        public void Union(int i, int j)
        {
            m_parents[Find(i)] = Find(j);
        }
    }
}
