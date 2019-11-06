using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem315 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountSmaller(new int[] { 5, 2, 6, 1 });
            if (!ProblemHelper.ArrayIsEqual(new int[] { 2, 1, 1, 0 }, temp.ToArray(), false)) throw new Exception();
        }

        public IList<int> CountSmaller(int[] nums)
        {
            /*
             * 问题:计算大于当前索引位置上,比当前数大的元素的个数
             * 思路:
             *  1.构造一颗线段树,树的节点包含如下属性
             *      1.1 节点表示的数值大小范围
             *      1.2 节点数值大小范围内数字的个数
             *      1.3 节点的左子节点
             *      1.4 节点的右子节点
             *  2.先遍历一遍数组,得到数组中元素的数值范围
             *  3.用数值范围去初始化线段树
             *  4.逆序遍历给定数组,先在线段树上搜索小于当前数子的元素个数,然后再把当前元素更新到线段树上
             * 
             * 关键点:
             * 
             * 假设用 NumRangeCount 表示数组中最大最小元素的范围内整数的个数
             * 时间复杂度:O(n*log(NumRangeCount))
             * 空间复杂度:O(NumRangeCount)
             */

            var minTemp = int.MaxValue;
            var maxTemp = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                minTemp = Math.Min(minTemp, nums[i]);
                maxTemp = Math.Max(maxTemp, nums[i]);
            }

            var treeTemp = new SegmentTree(minTemp, maxTemp);

            var forReturn = new List<int>(nums.Length);
            for (int j = nums.Length - 1; j >= 0; j--)
            {
                var curValue = nums[j];
                var countValue = treeTemp.SearchSegmentTree(minTemp, curValue - 1);
                forReturn.Add(countValue);

                treeTemp.UpdateSegmentTreeNode(curValue);
            }

            forReturn.Reverse();
            return forReturn;
        }

        class SegmentTreeNode
        {
            public int[] m_NumRange { get; set; }

            public int m_CurCount { get; set; }

            public SegmentTreeNode m_LeftRange { get; set; }

            public SegmentTreeNode m_RightRange { get; set; }
        }

        class SegmentTree
        {
            private SegmentTreeNode m_Root;

            /// <summary>
            /// 初始化一颗线段树
            /// </summary>
            public SegmentTree(int min, int max)
            {
                m_Root = new SegmentTreeNode();
                RecursiveInit(m_Root, min, max);
            }

            private void RecursiveInit(SegmentTreeNode root, int min, int max)
            {
                if (min > max) return;

                root.m_NumRange = new int[] { min, max };

                if (min == max) return;

                var middleTemp = min + (max - min) / 2;

                if (min <= middleTemp)
                {
                    root.m_LeftRange = new SegmentTreeNode();
                    RecursiveInit(root.m_LeftRange, min, middleTemp);
                }

                if (middleTemp + 1 <= max)
                {
                    root.m_RightRange = new SegmentTreeNode();
                    RecursiveInit(root.m_RightRange, middleTemp + 1, max);
                }
            }

            /// <summary>
            /// 更新一颗线段树的节点
            /// </summary>
            public void UpdateSegmentTreeNode(int value)
            {
                RecursiveUpdateNode(m_Root, value);
            }

            private void RecursiveUpdateNode(SegmentTreeNode root, int value)
            {
                if (root == null) return;

                if (value < root.m_NumRange[0] || value > root.m_NumRange[1]) return;

                root.m_CurCount++;

                RecursiveUpdateNode(root.m_LeftRange, value);
                RecursiveUpdateNode(root.m_RightRange, value);
            }

            /// <summary>
            /// 搜索一颗线段树范围内的节点
            /// </summary>
            public int SearchSegmentTree(int min, int max)
            {
                return RecursiveSearch(m_Root, min, max);
            }

            private int RecursiveSearch(SegmentTreeNode root, int min, int max)
            {
                if (min > max || root == null) return 0;

                if (root.m_NumRange[1] < min || root.m_NumRange[0] > max) return 0;

                if (root.m_NumRange[1] <= max && root.m_NumRange[0] >= min)
                    return root.m_CurCount;

                var leftValueTemp = RecursiveSearch(root.m_LeftRange, min, max);
                var rightValueTemp = RecursiveSearch(root.m_RightRange, min, max);

                return leftValueTemp + rightValueTemp;
            }
        }
    }
}
