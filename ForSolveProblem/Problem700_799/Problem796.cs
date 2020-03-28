using System;
namespace ForSolveProblem
{
    public class Problem796 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool RotateString(string A, string B)
        {
            if (A.Length != B.Length) return false;

            return (B + B).IndexOf(A) != -1;
        }
    }
}
