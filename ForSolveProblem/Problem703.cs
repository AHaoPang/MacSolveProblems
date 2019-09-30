using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem703 : IProblem
    {
        public void RunProblem()
        {
            /*
                int k = 3;
                int[] arr = [4,5,8,2];
                KthLargest kthLargest = new KthLargest(3, arr);
                kthLargest.add(3);   // returns 4
                kthLargest.add(5);   // returns 5
                kthLargest.add(10);  // returns 5
                kthLargest.add(9);   // returns 8
                kthLargest.add(4);   // returns 8
             */

            int k = 3;
            int[] arr = new int[] { 4, 5, 8, 2 };

            KthLargest kthLargest = new KthLargest(k, arr);

            int temp = 0;
            temp = kthLargest.Add(3);
            temp = kthLargest.Add(5);
            temp = kthLargest.Add(10);
            temp = kthLargest.Add(9);
            temp = kthLargest.Add(4);

        }

        public class KthLargest
        {
            int[] m_array;
            int m_k;

            public KthLargest(int k, int[] nums)
            {
                m_array = new int[k + 1];
                for (int i = 1; i <= k; i++)
                    m_array[i] = int.MinValue;

                m_k = k;

                foreach (var numItem in nums)
                    ArrayCompareAndAdd(numItem);
            }

            public int Add(int val)
            {
                return ArrayCompareAndAdd(val);
            }

            /// <summary>
            /// 比较后添加
            /// </summary>
            private int ArrayCompareAndAdd(int val)
            {
                var minTemp = m_array[1];

                if (minTemp > val) return minTemp;

                m_array[1] = val;
                UpdateArray(1);

                return m_array[1];
            }

            /// <summary>
            /// 开始从指定的索引处递归维护小顶堆
            /// </summary>
            private void UpdateArray(int rootIndex)
            {
                if (rootIndex > m_k) return;

                var leftChildIndex = rootIndex * 2;
                var rightChildIndex = rootIndex * 2 + 1;

                //判断交换的位置，即在3个位置中，将根与最小的位置做比较
                int minIndex = rootIndex;
                int minValue = m_array[rootIndex];
                if(leftChildIndex <= m_k && m_array[leftChildIndex] < minValue)
                {
                    minIndex = leftChildIndex;
                    minValue = m_array[leftChildIndex];
                }
                if(rightChildIndex <= m_k && m_array[rightChildIndex] < minValue)
                {
                    minIndex = rightChildIndex;
                    minValue = m_array[rightChildIndex];
                }

                //将最小的位置，与父节点做交换
                //父最小，那就中止好了
                if (minIndex == rootIndex)
                {
                    //若父就是最小的，那么就终止了
                    return;
                }
                else if(minIndex == leftChildIndex)
                {
                    //左子最小，与左子交换
                    var temp = m_array[rootIndex];
                    m_array[rootIndex] = m_array[leftChildIndex];
                    m_array[leftChildIndex] = temp;

                    UpdateArray(leftChildIndex);
                }
                else
                {
                    //右子最小，与右子交换
                    var temp = m_array[rootIndex];
                    m_array[rootIndex] = m_array[rightChildIndex];
                    m_array[rightChildIndex] = temp;

                    UpdateArray(rightChildIndex);
                }
            }
        }
    }
}
