using System;
namespace ForSolveProblem
{
    public class Problem5114 : IProblem
    {
        public void RunProblem()
        {
            var temp = DeleteTreeNodes(7, new int[] { -1, 0, 0, 1, 2, 2, 2 }, new int[] { 1, -2, 4, 0, -2, -1, -1 });
            if (temp != 2) throw new Exception();
        }

        public int DeleteTreeNodes(int nodes, int[] parent, int[] value)
        {
            var v = Recursion(nodes, 0, parent, value);
            return v.Item1 == 0 ? 0 : v.Item2;
        }

        private Tuple<int, int> Recursion(int nodes, int curNode, int[] parent, int[] value)
        {
            if (curNode == nodes) return Tuple.Create(0, 0);

            var curNodeValue = value[curNode];
            var count = 1;
            for (int i = curNode; i < nodes; i++)
            {
                if (parent[i] == curNode)
                {
                    var v1 = Recursion(nodes, i, parent, value);
                    if (v1.Item1 == 0) continue;

                    curNodeValue += v1.Item1;
                    count += v1.Item2;
                }
            }

            return Tuple.Create(curNodeValue, count);
        }
    }
}
