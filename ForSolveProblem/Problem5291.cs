using System;
namespace ForSolveProblem
{
    public class Problem5291 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindNumbers(int[] nums)
        {
            var forReturn = 0;
            foreach (var numItem in nums)
                if (numItem.ToString().Length % 2 == 0) forReturn++;

            return forReturn;
        }
    }
}
