﻿using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem1022 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public int SumRootToLeaf(TreeNode root)
        {
            /*
             * 题目概述：从根到叶二叉树二进制之和
             * 
             * 思路：
             *  1.遍历二叉树,直到叶子节点,然后计算出叶子节点的值,求和;
             *  2.遍历使用的是"前序遍历";
             *  3.求和时注意要做模运算
             *
             * 知识点：二叉树遍历 取余 树 递归
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            m_total = 0;

            Recursive(root, new List<int>());

            return m_total;
        }

        private int m_total;
        private int m_constNum = (int)1e9 + 7;

        private void Recursive(TreeNode root, List<int> curList)
        {
            curList.Add(root.val);

            if (root.left == root.right && root.left == null)
            {
                m_total += GetIntNum(curList);
                m_total %= m_constNum;
            }
            else
            {
                if (root.left != null)
                    Recursive(root.left, curList);

                if (root.right != null)
                    Recursive(root.right, curList);
            }

            curList.RemoveAt(curList.Count - 1);
        }

        private int GetIntNum(List<int> curList)
        {
            long forReturn = 0;
            foreach (var item in curList)
            {
                forReturn <<= 1;
#pragma warning disable CS0675 // Bitwise-or operator used on a sign-extended operand
                forReturn |= item;
#pragma warning restore CS0675 // Bitwise-or operator used on a sign-extended operand
                forReturn %= m_constNum;
            }

            return (int)forReturn;
        }
    }
}
