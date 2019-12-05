using System;
using System.Linq;

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
        /// 各团体人员数量
        /// </summary>
        private int[] m_size;

        /// <summary>
        /// 初始化一个并查集
        /// </summary>
        public DisJointSet(int initCapacity)
        {
            m_parents = new int[initCapacity];
            m_size = Enumerable.Repeat(1, initCapacity).ToArray();

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
        /// 合并两个团体,谁人多就合并到谁那里去,人数相同时,优先合并到 i 所在团体
        /// </summary>
        public void Union(int i, int j)
        {
            var iParent = Find(i);
            var jParent = Find(j);
            if (iParent == jParent) return;

            if (m_size[iParent] >= m_size[jParent])
            {
                m_parents[jParent] = iParent;
                m_size[iParent] += m_size[jParent];
            }
            else
            {
                m_parents[iParent] = jParent;
                m_size[jParent] += m_size[iParent];
            }
        }

        /// <summary>
        /// 将 from 团体的人合并到 to
        /// </summary>
        public void UnionToFrom(int to,int from)
        {
            var iParent = Find(to);
            var jParent = Find(from);
            if (iParent == jParent) return;

            m_parents[jParent] = iParent;
            m_size[iParent] += m_size[jParent];
        }

        /// <summary>
        /// 返回指定团体成员的数量
        /// </summary>
        public int GetCount(int num) => m_size[num];
    }
}
