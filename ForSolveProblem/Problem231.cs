using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem231 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsPowerOfTwo(int n)
        {
            return n != 0 && (n & (n - 1)) == 0;
        }
    }
}
