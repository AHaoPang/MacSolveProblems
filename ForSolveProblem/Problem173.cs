using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem173 : IProblem
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

        /*
         * 题目概述：二叉搜索树迭代器
         * 
         * 思路：既是迭代器,那么目标就是按照一定的顺序依次遍历集合中的全部数据,还有一个对应名称的设计模式,接口要求遍历集合中的全部数据,而无需理会具体的遍历思路和实现
         *  1.二叉搜索树,是用来做数据搜索的
         *  2.从示例的输出结果来看,其实是希望自小向大遍历数据的
         *  3.将二叉搜索树转换为一个顺序序列,只需要实现 中序遍历即可
         *  4.类的初始化,负责将树转换为顺序数组
         *  5.类内部维护一个指针,标记当前遍历到的位置
         *
         * 关键点：
         *
         * 时间复杂度：O(n)
         * 空间复杂度：O(n)
         */
        public class BSTIterator1
        {
            private IList<int> m_innerList;
            private int m_curIndex;

            public BSTIterator1(TreeNode root)
            {
                m_innerList = new List<int>();
                m_curIndex = 0;

                RecursiveTree(root);
            }

            private void RecursiveTree(TreeNode root)
            {
                if (root == null) return;

                RecursiveTree(root.left);
                m_innerList.Add(root.val);
                RecursiveTree(root.right);
            }

            /** @return the next smallest number */
            public int Next()
            {
                return m_innerList[m_curIndex++];
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return m_curIndex < m_innerList.Count;
            }
        }

        /*
         * 题目概述：
         * 
         * 思路：
         *  1.树本身的结构,是有章可循的,搜索二叉树更是如此
         *  2.大脑中思索树的 中序遍历 就可以发现规律
         *  3.因此,无需事先遍历得到一个中序的数组,而是在需要的时候依据结构去遍历就好了
         *  4.这是一个栈输出的过程
         *      4.1 栈中存储的值,是一个输出的先后顺序
         *      4.2 当前值,是一定要输出的
         *      4.3 当前值输出后,倘若有右子节点,那么是要继续递归下去的,即栈会变长,可以认为是某种有趣的有生力量
         *
         * 关键点：
         *
         * 每次最多遍历树的高度,因此也只存储树的高度
         * 时间复杂度：O(h)
         * 空间复杂度：O(h)
         */
        public class BSTIterator
        {
            private Stack<TreeNode> m_innerStack;

            public BSTIterator(TreeNode root)
            {
                m_innerStack = new Stack<TreeNode>();
                LoopAdd(m_innerStack, root);
            }

            private void LoopAdd(Stack<TreeNode> stack, TreeNode root)
            {
                var curNode = root;
                while (curNode != null)
                {
                    stack.Push(curNode);
                    curNode = curNode.left;
                }
            }

            /** @return the next smallest number */
            public int Next()
            {
                var forReturn = m_innerStack.Pop();
                LoopAdd(m_innerStack, forReturn.right);
                return forReturn.val;
            }

            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return m_innerStack.Any();
            }
        }
    }
}
