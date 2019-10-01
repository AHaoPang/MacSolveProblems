using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem508 : IProblem
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

        public int[] FindFrequentTreeSum(TreeNode root)
        {
            /*
             * 寻找出现次数最多的子树和
             * 思路：
             *  1.子树和是要统计出来的，然后才会知道谁的出现次数最多
             *  2.通过后序遍历，将子树和与出现次数统计出来
             *  3.再遍历一次字典，将出现次数最多的拿出来
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            //遍历统计
            var sumCountDic = new Dictionary<int, int>();
            RecursiveSum(root, sumCountDic);

            //遍历查找
            var forReturn = new List<int>();
            var maxSumTemp = -1;
            foreach (var dicItem in sumCountDic)
            {
                if (maxSumTemp < dicItem.Value)
                {
                    forReturn.Clear();
                    maxSumTemp = dicItem.Value;
                    forReturn.Add(dicItem.Key);
                }
                else if (maxSumTemp == dicItem.Value)
                {
                    forReturn.Add(dicItem.Key);
                }
            }

            return forReturn.ToArray();
        }

        private int RecursiveSum(TreeNode root, IDictionary<int, int> sumCountDic)
        {
            if (root == null) return 0;

            int rootVal = root.val;
            int leftRootVal = RecursiveSum(root.left, sumCountDic);
            int rightRootVal = RecursiveSum(root.right, sumCountDic);

            int sumValTemp = rootVal + leftRootVal + rightRootVal;

            if (!sumCountDic.ContainsKey(sumValTemp)) sumCountDic[sumValTemp] = 0;
            sumCountDic[sumValTemp]++;

            return sumValTemp;
        }
    }
}
