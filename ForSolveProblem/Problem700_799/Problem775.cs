using System;
namespace ForSolveProblem
{
    public class Problem775 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsIdealPermutation(new int[] { 1, 0, 2 });
            if (temp != true) throw new Exception();

            temp = IsIdealPermutation(new int[] { 1, 2, 0 });
            if (temp != false) throw new Exception();
        }

        public bool IsIdealPermutation(int[] A)
        {
            var minArray = new int[A.Length];
            var curMin = int.MaxValue;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                curMin = Math.Min(A[i], curMin);
                minArray[i] = curMin;

                if (i + 2 < A.Length && minArray[i + 2] < A[i]) return false;
            }

            return true;
        }
    }
}
