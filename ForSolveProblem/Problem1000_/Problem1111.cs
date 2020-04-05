using System;
namespace ForSolveProblem
{
    public class Problem1111 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] MaxDepthAfterSplit(string seq)
        {
            var res = new int[seq.Length];

            var depth = 0;
            for(var i = 0;i < seq.Length; i++)
            {
                if (seq[i] == '(')
                {
                    depth++;
                    res[i] = (depth & 1) == 1 ? 0 : 1;
                }
                else
                {
                    res[i] = (depth & 1) == 1 ? 0 : 1;
                    depth--;
                }
            }

            return res;
        }
    }
}
