using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem1145 : IProblem
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

        public bool BtreeGameWinningMove(TreeNode root, int n, int x)
        {
            /*
             * 题目概述：二叉树着色游戏,看谁着色最多
             * 
             * 思路：
             *  1.当对方做出选择以后,实际上是吧树分成了 3 个部分:父节点 左子节点 右子节点
             *  2.我方要获取最大的值,一定是从这 3 个部分中做选择
             *  3.当选择的区域节点个数超过一半的节点时,才是必胜的
             *  4.第一步,找到 x 所在树中的位置
             *  5.第二步,统计 x 左子节点的个数,统计 x 右子节点的个数,统计父节点及其个数
             *  6.第三步,选择最大的那部分
             *
             * 关键点：
             *
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)
             */

            var numList = new List<int>();
            var xRoot = SearchX(root, x);

            var leftNodeCount = 0;
            AcountNodes(xRoot.left, ref leftNodeCount);
            numList.Add(leftNodeCount);

            var rightNodeCount = 0;
            AcountNodes(xRoot.right, ref rightNodeCount);
            numList.Add(rightNodeCount);

            var remainNodes = n - 1 - leftNodeCount - rightNodeCount;
            numList.Add(remainNodes);

            return numList.Max() >= n / 2 + 1;
        }

        private TreeNode SearchX(TreeNode root, int x)
        {
            if (root == null) return null;
            if (root.val == x) return root;

            var leftPos = SearchX(root.left, x);
            if (leftPos != null) return leftPos;

            var rightPos = SearchX(root.right, x);
            if (rightPos != null) return rightPos;

            return null;
        }

        private void AcountNodes(TreeNode node, ref int countNum)
        {
            if (node == null) return;

            countNum++;
            AcountNodes(node.left, ref countNum);
            AcountNodes(node.right, ref countNum);
        }
    }
}
