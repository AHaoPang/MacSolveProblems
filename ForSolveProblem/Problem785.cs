using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem785 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsBipartite(new int[][]
            {
                new int[]{1,3},
                new int[]{0,2},
                new int[]{1,3},
                new int[]{0,2},
            });
            if (temp != true) throw new Exception();

            temp = IsBipartite(new int[][]
            {
                new int[]{1,2,3},
                new int[]{0,2},
                new int[]{0,1,3},
                new int[]{0,2},
            });
            if (temp != false) throw new Exception();
        }

        public bool IsBipartite(int[][] graph)
        {
            /*
             * 问题:判断邻接表所表示的图,是否是二分图
             * 思路:
             *  1.是一种广度优先搜索
             *  2.可以做这样的想象:
             *      2.1 一共有2个互斥的阵营
             *      2.2 阵营里面有新兵报到的时候,会在本阵营登记备案,同时会交代对方阵营里面可能存在的人员
             *      2.3 若本阵营登记过这个人了,那么他就不用交代对方阵营里面可能存在的人员了,因为已经交代过了
             *      2.4 若交代对方阵营里面的人,其实是在己方的阵营里面,那么视为"奸细",系统直接返回false
             * 
             * 关键点:队列新数据的加入,以及已有数据的去重和检测
             * 
             * 时间复杂度:O(n)
             * 空间复杂度:O(n)
             */

            var hashSetLeft = new HashSet<int>();
            var hashSetRight = new HashSet<int>();
            var queueSearch = new Queue<int>();
            var count = 1;
            var boolBit = new bool[graph.Length];
            while (count <= graph.Length)
            {
                var hashSetCheck = (count & 1) == 1 ? hashSetLeft : hashSetRight;
                var hashSetAdd = (count & 1) == 1 ? hashSetRight : hashSetLeft;
                count++;

                if (!queueSearch.Any())
                {
                    for (int i = 0; i < boolBit.Length; i++)
                    {
                        if (boolBit[i]) continue;

                        boolBit[i] = true;
                        hashSetCheck.Add(i);
                        queueSearch.Enqueue(i);
                        break;
                    }
                }

                var newQueueAdd = new Queue<int>();
                while (queueSearch.Any())
                {
                    var loopArray = graph[queueSearch.Dequeue()];

                    for (int i = 0; i < loopArray.Length; i++)
                    {
                        var nextPoint = loopArray[i];
                        if (hashSetCheck.Contains(nextPoint)) return false;

                        if (!hashSetAdd.Contains(nextPoint))
                        {
                            boolBit[nextPoint] = true;
                            hashSetAdd.Add(nextPoint);
                            newQueueAdd.Enqueue(nextPoint);
                        }
                    }
                }

                queueSearch = newQueueAdd;
            }

            return true;
        }
    }
}
