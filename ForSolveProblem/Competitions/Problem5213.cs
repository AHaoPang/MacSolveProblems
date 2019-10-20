using System;
namespace ForSolveProblem
{
    public class Problem5213:IProblem
    {
        public int MinCostToMoveChips(int[] chips)
        {
            var evenCount = 0;
            var oddCount = 0;
            for(int i = 0;i < chips.Length; i++)
            {
                if ((chips[i] & 1) == 1) oddCount++;
                else evenCount++;
            }

            return evenCount < oddCount ? evenCount : oddCount;
        }

        public void RunProblem()
        {
            var temp = MinCostToMoveChips(new int[] { 1, 2, 3 });
            if (temp != 1) throw new Exception();

            temp = MinCostToMoveChips(new int[] { 2, 2, 2, 3, 3 });
            if (temp != 2) throw new Exception();

            temp = MinCostToMoveChips(new int[] { 1, 2, 2, 2, 2 });
            if (temp != 1) throw new Exception();
        }
    }
}
