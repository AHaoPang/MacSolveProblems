using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5381 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] ProcessQueries(int[] queries, int m)
        {
            var linklist = new LinkedList<int>(Enumerable.Range(1, m));

            var res = new List<int>(queries.Length);
            foreach (var querItem in queries)
            {
                var i = 0;
                var head = linklist.First;
                while (head.Value != querItem)
                {
                    i++;
                    head = head.Next;
                }

                linklist.Remove(head);
                linklist.AddFirst(head);

                res.Add(i);
            }

            return res.ToArray();
        }
    }
}
