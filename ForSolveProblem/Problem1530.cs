using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1530 : IProblem
    {
        public void RunProblem()
        {
            var root = new TreeNode(1);
            var two = new TreeNode(2);
            var three = new TreeNode(3);
            root.left = two;
            root.right = three;
            var four = new TreeNode(4);
            two.right = four;

            var temp = CountPairs(root, 3);
        }

        public int CountPairs(TreeNode root, int distance)
        {
            m_count = 0;
            LeftRightRoot(root, distance);
            return m_count;
        }

        private int m_count;

        private List<int> LeftRightRoot(TreeNode root, int distance)
        {
            if (root == null) return new List<int>();
            if (root.right == null && root.left == null)
                return new List<int>() { 1 };

            var leftLists = LeftRightRoot(root.left, distance);
            var rightLists = LeftRightRoot(root.right, distance);

            var res = new List<int>();
            foreach (var leftItem in leftLists)
                if (leftItem + 1 < distance)
                    res.Add(leftItem + 1);

            foreach (var rightItem in rightLists)
                if (rightItem + 1 < distance)
                    res.Add(rightItem + 1);

            if (leftLists.Any() && rightLists.Any())
                foreach (var leftItem in leftLists)
                    foreach (var rightItem in rightLists)
                        if (leftItem + rightItem <= distance)
                            m_count++;

            return res;
        }
    }
}
