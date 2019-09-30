using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem105 : IProblem
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
            int[] preorder = new int[] { 3, 9, 20, 15, 7 };
            int[] inorder = new int[] { 9, 3, 15, 20, 7 };

            var temp = BuildTree(preorder, inorder);
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            /*
             * 依据前序遍历和中序遍历的结果来还原一个二叉树，有点儿像求解线性方程
             * 思路：
             *  1.前序遍历，就是一个依次给出“根”的序列
             *  2.中序遍历，可以依据根把子序列依次拆分成“左子树”和“右子树”
             *  3.那么这就是一个递归的问题了，不断的给出根，然后不断的依据根来拆分出子串
             *  
             * 时间复杂度：O(nlogn)，遍历整个序列的过程，有点儿像归并排序的前一个阶段
             * 空间复杂度：O(nlogn)
             * 
             * 关于职责的思考：
             *  1.前序遍历的结果，其实就是一个根依次输出的结果，顺序是先左后右
             *  2.中序遍历的结果，其实是一个递归的不断切割的过程，不断的分成了“左子树”“根”“右子树”
             *  3.以上两个结合，是可以得到唯一解的
             *  4.后序遍历 与 中序遍历 结合也是可以的 思路是一样的，但若是 前序遍历和中序遍历搭配，则无法达到同样的效果，无法准确定位解，或者说解是有多个的
             */

            return Recursive(new Queue<int>(preorder), inorder);
        }

        private TreeNode Recursive(Queue<int> queueTemp, int[] childOrder)
        {
            if (!queueTemp.Any() || !childOrder.Any()) return null;

            var rootTemp = queueTemp.Dequeue();
            TreeNode root = new TreeNode(rootTemp);

            var valPos = Array.IndexOf(childOrder, rootTemp);

            root.left = Recursive(queueTemp, childOrder.Take(valPos).ToArray());
            root.right = Recursive(queueTemp, childOrder.Skip(valPos + 1).Take(childOrder.Count() - valPos - 1).ToArray());

            return root;
        }
    }
}
