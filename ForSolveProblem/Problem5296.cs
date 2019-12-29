using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5296 : IProblem
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

        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            var root1List = new List<int>();
            GetTreeNodeNum(root1, root1List);

            var root2List = new List<int>();
            GetTreeNodeNum(root2, root2List);

            var root1Index = 0;
            var root2Index = 0;
            var forReturn = new List<int>(root1List.Count + root2List.Count);
            while (root1Index < root1List.Count || root2Index < root2List.Count)
            {
                var oneNum = int.MaxValue;
                if (root1Index < root1List.Count)
                    oneNum = root1List[root1Index];

                var twoNum = int.MaxValue;
                if (root2Index < root2List.Count)
                    twoNum = root2List[root2Index];

                if (oneNum <= twoNum)
                {
                    forReturn.Add(oneNum);
                    root1Index++;
                }
                else
                {
                    forReturn.Add(twoNum);
                    root2Index++;
                }
            }

            return forReturn;
        }

        private void GetTreeNodeNum(TreeNode root, IList<int> innerList)
        {
            if (root == null) return;

            GetTreeNodeNum(root.left, innerList);
            innerList.Add(root.val);
            GetTreeNodeNum(root.right, innerList);
        }
    }
}
