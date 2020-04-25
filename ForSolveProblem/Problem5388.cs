using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5388 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string Reformat(string s)
        {
            var cQueue = new Queue<char>();
            var nQueue = new Queue<char>();

            foreach (var sItem in s)
            {
                if (char.IsLetter(sItem))
                    cQueue.Enqueue(sItem);
                else
                    nQueue.Enqueue(sItem);
            }

            if (Math.Abs(cQueue.Count - nQueue.Count) > 1) return "";

            var res = new StringBuilder();

            if(cQueue.Count >= nQueue.Count)
            {
                res.Append(cQueue.Dequeue());
                while (nQueue.Any())
                {
                    res.Append(nQueue.Dequeue());
                    if (cQueue.Any())
                        res.Append(cQueue.Dequeue());
                }
            }
            else
            {
                res.Append(nQueue.Dequeue());
                while (cQueue.Any())
                {
                    res.Append(cQueue.Dequeue());
                    res.Append(nQueue.Dequeue());
                }
            }

            return res.ToString();
        }
    }
}
