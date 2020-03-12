using System;
namespace ForSolveProblem
{
    public class Problem530 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int GetMinimumDifference(TreeNode root)
        {
            m_re = int.MaxValue;
            m_preNode = null;
            MidSearch(root);
            return m_re;
        }

        private int m_re;
        private TreeNode m_preNode;

        private void MidSearch(TreeNode root)
        {
            if (root == null) return;

            MidSearch(root.left);

            if (m_preNode != null)
                m_re = Math.Min(m_re, root.val - m_preNode.val);

            m_preNode = root;

            MidSearch(root.right);
        }

        public int GetMinimumDifference2(TreeNode root)
        {
            /*
             * ##### 1. 题目概述：树中任意两节点差值的最小值
             * 
             * ##### 2. 思路：
             *    - 特征：这是一颗二叉搜索树,若中序遍历,得到的结果就会是一个递增的序列;那么序列相邻元素的值就存在最小的可能性了;
             *    - 方案：递归,中序遍历,全局变量记录上一个值,以及目前得到的最小差值;
             *    - 结果：遍历一轮以后的结果
             *
             * ##### 3. 知识点：树 中序遍历 递归
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(h)
             */

            m_min = int.MaxValue;
            m_preValue = int.MinValue / 4;
            LeftRootRightRecursive(root);
            return m_min;
        }

        private int m_min;
        private int m_preValue;

        private void LeftRootRightRecursive(TreeNode root)
        {
            if (root == null) return;

            LeftRootRightRecursive(root.left);

            m_min = Math.Min(m_min, root.val - m_preValue);
            m_preValue = root.val;

            LeftRootRightRecursive(root.right);
        }

        public int GetMinimumDifference1(TreeNode root)
        {
            /*
             * ##### 1. 题目概述：二叉搜索树的最小绝对差
             * 
             * ##### 2. 思路：
             *    - 特征：树中任意两点的差,即节点与节点之间的路径;对于每个节点而言,它处理的事情是一样的,即计算上一个节点的值,和自己值的差距;
             *    - 方案：使用递归;对于当前节点而言,它负责计算自己与父节点的差值,然后再找到自己的子节点,并把自己的值传给它;特殊值使用了整数的最大值;
             *    - 结果：遍历的过程中,寻找到最小的差值;
             *
             * ##### 3. 知识点：树 递归
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(h)
             */

            m_forReturn = int.MaxValue;
            Recursive(root, int.MaxValue);
            return m_forReturn;
        }

        private int m_forReturn;

        private void Recursive(TreeNode root, int preValue)
        {
            if (root == null) return;

            m_forReturn = Math.Min(m_forReturn, Math.Abs(root.val - preValue));

            Recursive(root.left, root.val);
            Recursive(root.right, root.val);
        }
    }
}
