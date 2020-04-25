using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem202002 : IProblem
    {
        public void RunProblem()
        {
            var arr = new int[][]
            {
                new[]{0,2},
                new[]{2,1},
                new[]{3,4},
                new[]{2,3},
                new[]{1,4},
                new[]{2,0},
                new[]{0,4}
            };

            var temp = NumWays(5, arr, 3);
        }

        public int NumWays(int n, int[][] relation, int k)
        {
            var res = 0;

            var dic = new Dictionary<int, List<int>>();
            for (var i = 0; i < relation.Length; i++)
            {
                var f = relation[i][0];
                var t = relation[i][1];
                if (!dic.ContainsKey(f))
                    dic[f] = new List<int>() { t };
                else
                    dic[f].Add(t);
            }

            var queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Any() && k >= 0)
            {
                var nextQueue = new Queue<int>();
                while (queue.Any())
                {
                    var curNum = queue.Dequeue();

                    if (k == 0)
                    {
                        if (curNum == n - 1)
                            res++;
                    }
                    else
                    {
                        if (dic.ContainsKey(curNum))
                            foreach (var numItem in dic[curNum])
                                nextQueue.Enqueue(numItem);
                    }
                }

                if (nextQueue.Any())
                    queue = nextQueue;

                k--;
            }

            return res;
        }
    }
}
