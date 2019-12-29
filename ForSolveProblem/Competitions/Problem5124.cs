using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5124 : IProblem
    {
        public void RunProblem()
        {
            var temp = SequentialDigits(100, 300);

            temp = SequentialDigits(1000, 13000);
        }

        public IList<int> SequentialDigits(int low, int high)
        {
            var forReturn = new List<int>();

            var lowCount = low.ToString().Length;
            var highCount = high.ToString().Length;

            for(int i = lowCount;i <= highCount; i++)
            {
                for(int k = 1;k <= 9 - i + 1; k++)
                {
                    var sumNum = 0;
                    var initNum = k;
                    for(int j = 1;j <= i; j++)
                    {
                        sumNum = sumNum * 10 + (initNum++);
                    }
                    if (sumNum >= low && sumNum <= high) forReturn.Add(sumNum);
                }
            }

            return forReturn;
        }
    }
}
