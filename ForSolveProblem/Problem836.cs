using System;
namespace ForSolveProblem
{
    public class Problem836 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            return rec1[0] < rec2[2] && rec1[2] > rec2[0] && rec1[1] < rec2[3] && rec1[3] > rec2[1];
        }
    }
}
