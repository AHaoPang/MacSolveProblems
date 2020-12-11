using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5499 : IProblem
    {
        public void RunProblem()
        {
            /*
             []
2
2
             */

            var t = ContainsPattern(new[] { 2, 2 }, 1, 2);
            if (t != true) throw new Exception();

            t = ContainsPattern(new[] { 2, 2, 1, 2, 2, 1, 1, 1, 2, 1 }, 2, 2);
            if (t != false) throw new Exception();
        }

        public bool ContainsPattern2(int[] arr, int m, int k)
        {
            if (arr.Length < m) return false;

            var dic = new Dictionary<string, Tuple<int, int>>();

            var queue = new Queue<int>(arr.Take(m));
            var keyTemp = string.Join(',', queue);
            dic[keyTemp] = Tuple.Create(0, 1);

            for (var i = m; i <= arr.Length - m; i++)
            {
                queue.Enqueue(arr[i]);
                if (queue.Count > m)
                    queue.Dequeue();

                if (queue.Count == m)
                {
                    var key = string.Join(',', queue);
                    if (dic.ContainsKey(key))
                    {
                        if (dic[key].Item1 + m - 1 >= i)
                            continue;

                        dic[key] = Tuple.Create(i, dic[key].Item2 + 1);
                    }
                    else
                    {
                        dic[key] = Tuple.Create(i, 1);
                    }
                }
            }

            foreach (var dicItem in dic)
                if (dicItem.Value.Item2 >= k) return true;

            return false;
        }

        public bool ContainsPattern(int[] arr, int m, int k)
        {
            var totalLength = m * k;
            for (var i = 0; i <= arr.Length - totalLength; i++)
            {
                var kt = 1;
                var needStop = false;
                while (true)
                {
                    var it = i;
                    for (var j = i + m * kt; j < i + m * kt + m; j++)
                    {
                        if (arr[it++] != arr[j])
                        {
                            needStop = true;
                            break;
                        }
                    }

                    if (needStop) break;

                    kt++;
                    if (kt >= k) return true;
                }

            }

            return false;
        }
    }
}
