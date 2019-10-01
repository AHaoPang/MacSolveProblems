using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem928 : IProblem
    {
        public void RunProblem()
        {
            //[[1,0,0,0,0,1,0],[0,1,1,0,0,0,0],[0,1,1,0,0,0,0],[0,0,0,1,0,0,0],[0,0,0,0,1,0,0],[1,0,0,0,0,1,0],[0,0,0,0,0,0,1]]
            int[][] graph = new int[][]
            {
                new int[]{1,1,0,0,0,0,0,0,0,0},
                new int[]{1,1,0,0,0,0,0,0,0,0},
                new int[]{0,0,1,0,0,0,0,0,0,0},
                new int[]{0,0,0,1,0,0,1,0,0,1},
                new int[]{0,0,0,0,1,0,0,0,0,0},
                new int[]{0,0,0,0,0,1,0,0,0,0},
                new int[]{0,0,0,1,0,0,1,0,0,0},
                new int[]{0,0,0,0,0,0,0,1,0,0},
                new int[]{0,0,0,0,0,0,0,0,1,0},
                new int[]{0,0,0,1,0,0,0,0,0,1},
            };
            int[] initial = new int[] { 2, 1, 9 };

            var temp = MinMalwareSpread(graph, initial);
        }

        public int MinMalwareSpread(int[][] graph, int[] initial)
        {
            /*
             * 处理思路：
             * 1.去掉哪个点，对感染的影响力最大；
             * 2.可以转换为，看看哪个点能感染别的点感染不到的点最多；
             * 
             * 1.可以先统计，一个点在不借助其它点的前提下能感染多少点；
             * 2.再统计这些被感染的点，谁只能被一个点给感染，最多的感染源，就是我们的目标；
             */

            initial = initial.OrderBy(i => i).ToArray();

            //统计各个点，能被哪个目标点单独感染
            Dictionary<int, HashSet<int>> numCalc = new Dictionary<int, HashSet<int>>();
            foreach (var initialItem in initial)
            {
                Queue<int> queueTemp = new Queue<int>();
                queueTemp.Enqueue(initialItem);
                List<int> visited = new List<int>();

                while (queueTemp.Count > 0)
                {
                    var nodeTemp = queueTemp.Dequeue();
                    for (int i = 0; i < graph[nodeTemp].Length; i++)
                    {
                        if (graph[nodeTemp][i] == 1 && !initial.Contains(i) && i != nodeTemp)
                        {
                            if (!numCalc.ContainsKey(i)) numCalc[i] = new HashSet<int>();

                            numCalc[i].Add(initialItem);

                            if (!visited.Contains(i))
                            {
                                visited.Add(i);
                                queueTemp.Enqueue(i);
                            }
                        }
                    }
                }
            }

            //只能被一个源感染的点，统计下是谁感染的
            Dictionary<int, int> dicInitial = new Dictionary<int, int>();
            foreach (var dicItem in numCalc)
            {
                if (dicItem.Value.Count != 1) continue;

                if (!dicInitial.ContainsKey(dicItem.Value.First())) dicInitial[dicItem.Value.First()] = 0;

                dicInitial[dicItem.Value.First()] += 1;
            }

            //循环遍历，找出最大的那一个感染源
            int forReturn = initial.First();
            int maxNum = -1;
            foreach (int iniItem in initial)
            {
                if (!dicInitial.ContainsKey(iniItem)) continue;

                if (dicInitial[iniItem] > maxNum)
                {
                    maxNum = dicInitial[iniItem];
                    forReturn = iniItem;
                }
            }

            return forReturn;
        }


    }
}
