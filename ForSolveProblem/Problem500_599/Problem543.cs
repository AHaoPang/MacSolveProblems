﻿using System;
namespace ForSolveProblem
{
    public class Problem543 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            m_res = 0;
            Dfs(root);

            return m_res;
        }

        private int m_res;

        private int Dfs(TreeNode root)
        {
            if (root == null) return 0;

            var lV = Dfs(root.left);
            var rV = Dfs(root.right);

            m_res = Math.Max(m_res, lV + rV);

            return Math.Max(lV, rV) + 1;
        }

        public int DiameterOfBinaryTree1(TreeNode root)
        {
            /*
             * ##### 1. 题目概述：二叉树的直径
             * 
             * ##### 2. 思路：
             *    - 特征：最终的结果,一定是父节点到两个子节点的距离之和;那么只要获取到这些和,取得最大值即可;
             *    - 方案：后序遍历的方案;递归方法返回的是一个节点到最远叶子节点的距离,而方法内部会判断到两个子节点的距离和是否为最大;
             *    - 结果：递归过程中获取到的最大值
             *
             * ##### 3. 知识点：树 后序遍历
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：O(n)
             *    - 空间复杂度：O(h)
             */

            m_maxDistance = 0;
            Recursive(root);
            return m_maxDistance;
        }

        private int m_maxDistance;

        private int Recursive(TreeNode root)
        {
            if (root == null) return -1;

            var leftDistance = Recursive(root.left) + 1;
            var rightDistance = Recursive(root.right) + 1;
            m_maxDistance = Math.Max(leftDistance + rightDistance, m_maxDistance);

            return Math.Max(leftDistance, rightDistance);
        }
    }
}
