using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    /// <summary>
    /// 优先级队列
    /// </summary>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        #region private fields
        /// <summary>
        /// 内部维护的数组
        /// </summary>
        private IList<T> m_innerList;

        /// <summary>
        /// 大的优先,还是小的优先
        /// </summary>
        private bool m_isBigFirst;
        #endregion

        public PriorityQueue(bool isBigFirst, int capacity = 64)
        {
            m_innerList = new List<T>(capacity) { default(T) };
            m_isBigFirst = isBigFirst;
        }

        public void AddData(T t)
        {
            m_innerList.Add(t);
            var curIndex = m_innerList.Count - 1;

            DownToUp(m_innerList, curIndex);
        }

        public bool HasData() => m_innerList.Count > 1;

        public T GetData()
        {
            if (m_innerList.Count < 2) return default(T);

            var forReturn = m_innerList[1];

            m_innerList[1] = m_innerList[m_innerList.Count - 1];
            m_innerList.RemoveAt(m_innerList.Count - 1);
            UpToDown(m_innerList, 1);

            return forReturn;
        }

        #region private functions
        /// <summary>
        /// 自上至下的更新
        /// </summary>
        private void UpToDown(IList<T> innerList, int curIndex)
        {
            if (curIndex >= innerList.Count) return;

            var cur = innerList[curIndex];

            var sonLeft = default(T);
            var sonLeftIndex = curIndex * 2;
            if (sonLeftIndex <= innerList.Count - 1) sonLeft = innerList[sonLeftIndex];

            var sonRight = default(T);
            var sonRightIndex = curIndex * 2 + 1;
            if (sonRightIndex <= innerList.Count - 1) sonRight = innerList[sonRightIndex];

            var compareResult = CompareAndReturnPriority(sonLeft, sonRight);
            if (Equals(compareResult, default(T))) return;

            if (IsMove(compareResult, cur))
            {
                var moveIndex = -1;
                if (Equals(sonLeft, compareResult))
                    moveIndex = sonLeftIndex;
                else if (Equals(sonRight, compareResult))
                    moveIndex = sonRightIndex;

                if (moveIndex != -1)
                {
                    Swap(innerList, moveIndex, curIndex);
                    UpToDown(innerList, moveIndex);
                }
            }
        }

        /// <summary>
        /// 自下至上的更新
        /// </summary>
        private void DownToUp(IList<T> innerlist, int curIndex)
        {
            var fatherIndex = curIndex / 2;
            if (fatherIndex < 1) return;

            if (IsMove(innerlist[curIndex], innerlist[fatherIndex]))
            {
                Swap(innerlist, curIndex, fatherIndex);
                DownToUp(innerlist, fatherIndex);
            }
        }

        /// <summary>
        /// 交换列表中两个索引的位置
        /// </summary>
        private void Swap(IList<T> list, int oneIndex, int secondIndex)
        {
            var temp = list[oneIndex];
            list[oneIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        /// <summary>
        /// 判断是否要交换源和目标的位置
        /// </summary>
        private bool IsMove(T sourcePos, T targetPos)
        {
            var compareResult = sourcePos.CompareTo(targetPos);

            if (m_isBigFirst && compareResult > 0) return true;
            if (!m_isBigFirst && compareResult < 0) return true;

            return false;
        }

        /// <summary>
        /// 比较并返回优先级大的那个对象
        /// </summary>
        private T CompareAndReturnPriority(T oneT, T secondT)
        {
            var defaultValue = default(T);
            if (Equals(oneT, defaultValue) || Equals(secondT, defaultValue))
                return Equals(oneT, defaultValue) ? secondT : oneT;

            var compareResult = oneT.CompareTo(secondT);

            if (m_isBigFirst) return compareResult > 0 ? oneT : secondT;

            return compareResult < 0 ? oneT : secondT;
        }
        #endregion
    }
}
