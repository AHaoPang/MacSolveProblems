using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5276 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumOfBurgers(16, 7);

            temp = NumOfBurgers(17, 4);

            temp = NumOfBurgers(4, 17);

            temp = NumOfBurgers(0, 0);

            temp = NumOfBurgers(2, 1);

            temp = NumOfBurgers(2385088, 164763);
        }

        public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
        {
            var forReturn = new List<int>();

            if (tomatoSlices < 2 * cheeseSlices || tomatoSlices > 4 * cheeseSlices) return forReturn;

            var subValue = tomatoSlices - 2 * cheeseSlices;
            if (subValue % 2 == 1) return forReturn;

            var juCount = subValue / 2;
            var smCount = cheeseSlices - juCount;
            forReturn.Add(juCount);
            forReturn.Add(smCount);

            return forReturn;
        }
    }
}
