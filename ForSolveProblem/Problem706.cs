using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem706 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 考虑到此类的应用场景：
        ///     1.操作的值，在1~100万，那么使用Int类型足够了
        ///     2.操作的总数目，在1~1万
        /// 考虑实现
        ///     1.哈希的麻烦在于冲突处理
        ///     2.若一次分配足够的空间，就会简单很多很多
        ///     3.按照此类的使用场景，若给它分配足够的空间，则需要占用连续的40k内存空间，可以说是相当大了
        ///     4.但是借此，类的复杂度是大大降低的，可以一试
        /// </summary>
        public class MyHashMap
        {
            private int[] m_innerArray;
            private BitArray m_bitPos;

            /** Initialize your data structure here. */
            public MyHashMap()
            {
                var initLength = 10000;
                m_innerArray = new int[initLength];
                m_bitPos = new BitArray(initLength);
            }

            /** value will always be non-negative. */
            public void Put(int key, int value)
            {
                m_innerArray[key] = value;
                m_bitPos.Set(key, true);
            }

            /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
            public int Get(int key)
            {
                if (!m_bitPos.Get(key)) return -1;
                return m_innerArray[key];
            }

            /** Removes the mapping of the specified value key if this map contains a mapping for the key */
            public void Remove(int key)
            {
                m_bitPos.Set(key, false);
            }
        }
    }
}
