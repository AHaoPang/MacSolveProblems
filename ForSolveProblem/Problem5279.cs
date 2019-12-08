using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5279 : IProblem
    {
        public void RunProblem()
        {
            var temp = SubtractProductAndSum(234);
            if (temp != 15) throw new Exception();

            temp = SubtractProductAndSum(4421);
            if (temp != 21) throw new Exception();
        }

        public int SubtractProductAndSum(int n)
        {
            var numList = new List<int>();
            while (n > 0)
            {
                numList.Add(n % 10);
                n /= 10;
            }

            var sumTemp = 0;
            var chenTemp = 1;
            for (int i = 0; i < numList.Count; i++)
            {
                sumTemp += numList[i];
                chenTemp *= numList[i];
            }

            return chenTemp - sumTemp;
        }
    }
}
