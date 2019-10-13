using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5222:IProblem
    {
        public int BalancedStringSplit(string s)
        {
            var forReturn = 0;
            var queue = new Queue<char>();

            foreach(var sItem in s)
            {
                if (!queue.Any()) queue.Enqueue(sItem);
                else
                {
                    if (queue.Peek() == sItem) queue.Enqueue(sItem);
                    else queue.Dequeue();
                }

                if (!queue.Any()) forReturn++;
            }

            return forReturn;
        }

        public void RunProblem()
        {
            var temp = BalancedStringSplit("RLRRLLRLRL");
            if (temp != 4) throw new Exception();

            temp = BalancedStringSplit("RLLLLRRRLR");
            if (temp != 3) throw new Exception();

            temp = BalancedStringSplit("LLLLRRRR");
            if (temp != 1) throw new Exception();
        }
    }
}
