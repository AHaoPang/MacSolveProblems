using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem207 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var pointToOthersDic = new Dictionary<int, HashSet<int>>(numCourses);
            var othersToPointDic = new Dictionary<int, int>(numCourses);

            foreach (var item in prerequisites)
            {
                var f = item[0];
                var t = item[1];

                if (!pointToOthersDic.ContainsKey(f))
                    pointToOthersDic[f] = new HashSet<int>();
                pointToOthersDic[f].Add(t);

                if (!othersToPointDic.ContainsKey(t))
                    othersToPointDic[t] = 0;
                othersToPointDic[t]++;
            }

            var queue = new Queue<int>();
            for (var i = 0; i < numCourses; i++)
                if (!othersToPointDic.ContainsKey(i))
                    queue.Enqueue(i);

            var count = 0;
            while (queue.Any())
            {
                var curPoint = queue.Dequeue();
                count++;

                if (!pointToOthersDic.ContainsKey(curPoint)) continue;

                foreach (var toPoint in pointToOthersDic[curPoint])
                    if (--othersToPointDic[toPoint] == 0)
                        queue.Enqueue(toPoint);
            }

            return count == numCourses;
        }
    }
}
