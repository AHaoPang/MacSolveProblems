using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem338 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] CountBits(int num)
        {
            int[] forReturn = new int[num + 1];

            forReturn[0] = 0;
            for (int i = 1; i <= num; i++)
                forReturn[i] = forReturn[i & (i - 1)] + 1;

            return forReturn;
        }
    }
}
