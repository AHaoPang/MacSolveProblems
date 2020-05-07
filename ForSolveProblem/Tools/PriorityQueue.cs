using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    /// <summary>
    /// 优先级队列
    /// 
    /// 使用说明:
    /// 1.内部使用了IList来存储数据,所以是支持动态扩容的
    /// 2.可以指定大的值优先,还是小的值优先
    /// 
    /// 对外保留3个接口:
    /// 1.AddData 为优先级队列添加数据
    /// 2.HasData 判断队列中是否有数据
    /// 3.GetData 若队列中有数据,则移除优先级最大的数据并返回
    /// 4.PeekData 若队列中有数据,则返回优先级最大的数据
    ///
    /// 5.Count 数据个数统计
    /// 
    /// </summary>
    public class PriorityQueue<T>
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

        /// <summary>
        /// 比较器
        /// </summary>
        private IComparer<T> m_innerComparer;
        #endregion

        public PriorityQueue(bool isBigFirst, int capacity = 64, IComparer<T> comparer = null)
        {
            m_innerComparer = comparer == null ? Comparer<T>.Default : comparer;
            m_innerList = new List<T>(capacity) { default(T) };
            m_isBigFirst = isBigFirst;
        }

        /// <summary>
        /// 数据个数
        /// </summary>
        public int Count { get => m_innerList.Count - 1; }

        /// <summary>
        /// 添加数据
        /// </summary>
        public void AddData(T t)
        {
            if (m_innerList.Contains(t))
                return;

            m_innerList.Add(t);
            var curIndex = m_innerList.Count - 1;

            DownToUp(m_innerList, curIndex);
        }

        /// <summary>
        /// 判断是否有数据
        /// </summary>
        public bool HasData() => m_innerList.Count > 1;

        /// <summary>
        /// 获取数据
        /// </summary>
        public T GetData()
        {
            if (m_innerList.Count < 2) throw new OverflowException("PriorityQueue empty");

            var forReturn = m_innerList[1];

            var lastIndex = m_innerList.Count - 1;
            m_innerList[1] = m_innerList[lastIndex];
            m_innerList.RemoveAt(lastIndex);
            UpToDown(m_innerList, 1);

            return forReturn;
        }

        /// <summary>
        /// 检查端点的数据
        /// </summary>
        public T PeekData()
        {
            if (m_innerList.Count < 2) throw new OverflowException("PriorityQueue empty");

            return m_innerList[1];
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
            var hasSonLeft = false;
            var sonLeftIndex = curIndex * 2;
            if (sonLeftIndex <= innerList.Count - 1)
            {
                hasSonLeft = true;
                sonLeft = innerList[sonLeftIndex];
            }

            var sonRight = default(T);
            var hasSonRight = false;
            var sonRightIndex = curIndex * 2 + 1;
            if (sonRightIndex <= innerList.Count - 1)
            {
                hasSonRight = true;
                sonRight = innerList[sonRightIndex];
            }

            if (hasSonLeft || hasSonRight)
            {
                var tempIndex = -1;

                if (hasSonLeft && hasSonRight)
                {
                    var compareResult = IsMove(sonLeft, sonRight);
                    if (compareResult && IsMove(sonLeft, cur))
                        tempIndex = sonLeftIndex;
                    else if (!compareResult && IsMove(sonRight, cur))
                        tempIndex = sonRightIndex;
                }
                else if (hasSonLeft && IsMove(sonLeft, cur))
                    tempIndex = sonLeftIndex;
                else if (hasSonRight && IsMove(sonRight, cur))
                    tempIndex = sonRightIndex;

                if (tempIndex != -1)
                {
                    Swap(innerList, tempIndex, curIndex);
                    UpToDown(innerList, tempIndex);
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
            var compareResult = m_innerComparer.Compare(sourcePos, targetPos);

            if (m_isBigFirst && compareResult > 0) return true;
            if (!m_isBigFirst && compareResult < 0) return true;

            return false;
        }
        #endregion
    }
}
