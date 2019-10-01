using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem022 : IProblem
    {
        public void RunProblem()
        {
            var temp = GenerateParenthesis(3);
        }

        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> forReturn = new List<string>();
            Gen(forReturn, n, 0, 0, "");
            return forReturn;
        }

        private void Gen(IList<string> forReturn,int total,int left,int rigth,string str)
        {
            if(left == total && rigth == total)
            {
                forReturn.Add(str);
                return;
            }

            if(left < total)
                Gen(forReturn, total, left + 1, rigth, str + "(");

            if (rigth < left)
                Gen(forReturn, total, left, rigth + 1, str + ")");
        }
    }
}
