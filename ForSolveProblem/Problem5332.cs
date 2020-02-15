using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5332 : IProblem
    {
        public void RunProblem()
        {
            var temp = CheckIfExist(new int[] { 10, 2, 5, 3 });
            if (temp != true) throw new Exception();

            temp = CheckIfExist(new int[] { 7, 1, 14, 11 });
            if (temp != true) throw new Exception();

            temp = CheckIfExist(new int[] { 3, 1, 7, 11 });
            if (temp != false) throw new Exception();

            temp = CheckIfExist(new int[] { 4, -7, 11, 4, 18 });
            if (temp != false) throw new Exception();

            temp = CheckIfExist(new int[] { -2, 0, 10, -19, 4, 6, -8 });
            if (temp != false) throw new Exception();
        }

        public bool CheckIfExist(int[] arr)
        {
            var zeroCount = 0;
            var targetValueSet = new HashSet<int>();
            foreach (var arrItem in arr)
            {
                if (arrItem == 0) zeroCount++;

                if (targetValueSet.Contains(arrItem)) return true;

                targetValueSet.Add(arrItem * 2);
            }

            foreach (var arrItem in arr)
            {
                if (arrItem == 0 && zeroCount == 1) continue;
                if (targetValueSet.Contains(arrItem)) return true;
            }

            return false;
        }
    }
}
