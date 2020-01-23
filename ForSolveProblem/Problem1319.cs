using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1319 : IProblem
    {
        public void RunProblem()
        {
            var intArray = Newtonsoft.Json.JsonConvert.DeserializeObject<int[][]>(File.ReadAllText(@"D:\MSCode\TEXT\TEXT.txt"));
            var t = MakeConnected(100, intArray);
            if (t != 11) throw new Exception();

            var temp = MakeConnected(6, new int[][]
            {
                new int[]{0,1},
                new int[]{0,2},
                new int[]{0,3},
                new int[]{1,2},
                new int[]{1,3},
            });
            if (temp != 2) throw new Exception();

            temp = MakeConnected(4, new int[][]
            {
                new int[]{0,1},
                new int[]{0,2},
                new int[]{1,2},
            });
            if (temp != 1) throw new Exception();

            temp = MakeConnected(6, new int[][]
            {
                new int[]{0,1},
                new int[]{0,2},
                new int[]{0,3},
                new int[]{1,2},
            });
            if (temp != -1) throw new Exception();

            temp = MakeConnected(5, new int[][]
            {
                new int[]{0,1},
                new int[]{0,2},
                new int[]{3,4},
                new int[]{2,3},
            });
            if (temp != 0) throw new Exception();
        }

        public int MakeConnected(int n, int[][] connections)
        {
            var forReturn = 0;

            var conDic = new Dictionary<int, HashSet<int>>();
            foreach (var conItem in connections)
            {
                var point1 = conItem[0];
                var point2 = conItem[1];

                if (!conDic.ContainsKey(point1))
                    conDic[point1] = new HashSet<int>();
                if (!conDic.ContainsKey(point2))
                    conDic[point2] = new HashSet<int>();

                conDic[point1].Add(point2);
                conDic[point2].Add(point1);
            }

            var visitedSet = new HashSet<int>();
            var dupCount = 1;
            forReturn = -1;
            for (int i = 0; i < n; i++)
            {
                if (visitedSet.Contains(i)) continue;

                forReturn++;
                dupCount--;

                var queueTemp = new Queue<int>();
                visitedSet.Add(i);
                queueTemp.Enqueue(i);

                while (queueTemp.Any())
                {
                    var curNode = queueTemp.Dequeue();
                    if (!conDic.ContainsKey(curNode)) continue;

                    var curSet = conDic[curNode];
                    foreach (var connectedItem in curSet)
                    {
                        if (conDic.ContainsKey(connectedItem))
                            conDic[connectedItem].Remove(curNode);

                        if (visitedSet.Contains(connectedItem))
                        {
                            dupCount++;
                            continue;
                        }

                        visitedSet.Add(connectedItem);
                        queueTemp.Enqueue(connectedItem);
                    }
                }
            }

            if (dupCount < 0)
                return -1;

            return forReturn;
        }
    }
}
