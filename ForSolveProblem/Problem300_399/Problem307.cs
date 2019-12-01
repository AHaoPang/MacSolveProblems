using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem307 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class NumArray
        {
            private SegmentTree m_tree;
            private int[] m_nums;

            public NumArray(int[] nums)
            {
                m_tree = new SegmentTree(nums);
                m_nums = nums;
            }

            public void Update(int i, int val)
            {
                var oldValue = m_nums[i];
                m_nums[i] = val;

                var addValue = val - oldValue;
                m_tree.UpdateTree(i, addValue);
            }

            public int SumRange(int i, int j) => m_tree.SumTree(i, j);
        }

        class SegmentTreeNode
        {
            public SegmentTreeNode(int min, int max)
            {
                MinIndex = min;
                MaxIndex = max;
            }

            public int MinIndex { get; }

            public int MaxIndex { get; }

            public int SumValue { get; set; }

            public SegmentTreeNode LeftNode { get; set; }

            public SegmentTreeNode RightNode { get; set; }
        }

        class SegmentTree
        {
            private SegmentTreeNode m_rootNode;

            public SegmentTree(int[] nums)
            {
                if (!nums.Any()) return;

                m_rootNode = new SegmentTreeNode(0, nums.Length - 1);

                Recursion(m_rootNode);

                GetNodeRangeSum(m_rootNode, nums);
            }

            private void Recursion(SegmentTreeNode root)
            {
                if (root.MinIndex == root.MaxIndex) return;

                var middle = root.MinIndex + (root.MaxIndex - root.MinIndex) / 2;

                root.LeftNode = new SegmentTreeNode(root.MinIndex, middle);
                root.RightNode = new SegmentTreeNode(middle + 1, root.MaxIndex);

                Recursion(root.LeftNode);
                Recursion(root.RightNode);
            }

            private int GetNodeRangeSum(SegmentTreeNode root, int[] nums)
            {
                root.SumValue = root.MinIndex == root.MaxIndex ?
                    nums[root.MinIndex] :
                    GetNodeRangeSum(root.LeftNode, nums) + GetNodeRangeSum(root.RightNode, nums);

                return root.SumValue;
            }

            public void UpdateTree(int i, int addValue) => UpdateTreeRecursion(m_rootNode, i, addValue);

            private void UpdateTreeRecursion(SegmentTreeNode root, int i, int addValue)
            {
                if (root == null || i < root.MinIndex || i > root.MaxIndex) return;

                root.SumValue += addValue;

                UpdateTreeRecursion(root.LeftNode, i, addValue);
                UpdateTreeRecursion(root.RightNode, i, addValue);
            }

            public int SumTree(int i, int j) => SumTreeRecursion(m_rootNode, i, j);

            private int SumTreeRecursion(SegmentTreeNode root, int i, int j)
            {
                if (root == null || root.MinIndex > j || root.MaxIndex < i) return 0;

                if (root.MinIndex >= i && root.MaxIndex <= j) return root.SumValue;

                return SumTreeRecursion(root.LeftNode, i, j) + SumTreeRecursion(root.RightNode, i, j);
            }
        }
    }
}
