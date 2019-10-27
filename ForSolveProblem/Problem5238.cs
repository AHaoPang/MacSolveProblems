using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class CustomFunction
    {
        // Returns f(x, y) for any given positive integers x and y.
        // Note that f(x, y) is increasing with respect to both x and y.
        // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
        public int f(int x, int y) { return 1; }
    };

    public class Problem5238 : CustomFunction, IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            var forReturn = new List<IList<int>>();
            for (int x = 1; x <= 1000; x++)
            {
                for (int y = 1; y <= 1000; y++)
                {
                    var tempValue = customfunction.f(x, y);
                    if (tempValue > z) break;

                    if (tempValue == z)
                    {
                        forReturn.Add(new List<int>() { x, y });
                        break;
                    }
                }
            }

            return forReturn;
        }
    }
}
