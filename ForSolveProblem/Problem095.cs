using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem095 : IProblem
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
            var temp = GenerateTrees(3);
        }

        public IList<TreeNode> GenerateTrees(int n)
        {
            /*
             * 依据一个有序的排列，来构造出所有可能的二叉搜索树
             * 思路：
             *  1.考虑将一个大问题，逐渐分解为一个小问题-->递归的思路
             *  2.对于每个子问题，考虑的事情都是：谁要作为根，谁要作为左子树，谁要作为右子树
             *  3.当一个子问题仅有根，而没有子树的时候，就说明当前讨论的是叶子了
             *  
             * 时间复杂度：O(n!),每个序列元素都可以作为根存在，那么第一层的可能性有n种，第二层的可能性有n-1种，依次类推，毕竟要遍历出所有的可能性
             * 空间复杂度：O(n!),要将所有的可能性存储起来
             * 这种复杂度会急剧增加的算法，输入的n不宜太大，或者说，可以考虑使用并行运算
             * 
             * 考察点：
             *  1.回溯法
             *  2.对搜索二叉树的理解
             */

            if (n <= 0) return new List<TreeNode>();

            return Recursive(1, n);
        }

        private IList<TreeNode> Recursive(int start, int end)
        {
            IList<TreeNode> forReturn = new List<TreeNode>();

            if (start > end)
            {
                forReturn.Add(null);

                return forReturn;
            }

            for (int i = start; i <= end; i++)
            {
                var leftNode = Recursive(start, i - 1);
                var rigthNode = Recursive(i + 1, end);

                if (leftNode.Any() && rigthNode.Any())
                {
                    foreach (var leftItem in leftNode)
                    {
                        foreach (var rightItem in rigthNode)
                        {
                            var rootNode = new TreeNode(i);
                            rootNode.left = leftItem;
                            rootNode.right = rightItem;

                            forReturn.Add(rootNode);
                        }
                    }
                }
            }

            return forReturn;
        }
    }
}
