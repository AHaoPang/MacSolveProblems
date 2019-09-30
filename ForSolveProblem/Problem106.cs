using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem106 : IProblem
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public void RunProblem()
        {
            int[] inorder = new int[] { 9, 3, 15, 20, 7 };
            int[] postorder = new int[] { 9, 15, 7, 20, 3 };

            var temp = BuildTree(inorder, postorder);
        }

        private int[] m_inorder;
        private Dictionary<int, int> m_inorderDic;//记录值对应的索引位置

        private int[] m_postorder;
        private int m_postIndex;//记录当前要输出的位置

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            /*
             * 依据中序和后序树遍历结果来唯一确定一个树
             * 思路：
             *  1.后序遍历，可通过逆序的方式来提供自上到下的根节点
             *  2.中序遍历，可提供树的边界范围
             *  3.本次使用数组指针的方式来处理，因为指针的移动是有规律的
             *  
             * 时间复杂度：O(n)，把所有节点过一遍
             * 空间复杂度：O(n)，额外使用了字典存储值与索引的对应关系
             */

            m_inorder = inorder;
            m_postorder = postorder;
            m_postIndex = postorder.Length - 1;

            m_inorderDic = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
                m_inorderDic[inorder[i]] = i;

            return Recursive(0, postorder.Length);
        }

        private TreeNode Recursive(int leftIndex, int rigthIndex)
        {
            if (leftIndex == rigthIndex) return null;

            var nodeValue = m_postorder[m_postIndex--];
            var nodePos = m_inorderDic[nodeValue];

            TreeNode root = new TreeNode(nodeValue);

            root.right = Recursive(nodePos + 1, rigthIndex);
            root.left = Recursive(leftIndex, nodePos);

            return root;
        }
    }
}
