using System;
namespace ForSolveProblem
{
    public class Problem5311:IProblem
    {
        public void RunProblem()
        {
            var temp = NumberOfSteps(14);
            if (temp != 6) throw new Exception();

            temp = NumberOfSteps(8);
            if (temp != 4) throw new Exception();

            temp = NumberOfSteps(123);
            if (temp != 12) throw new Exception();
        }

        public int NumberOfSteps(int num)
        {
            var forReturn = 0;

            while(num != 0)
            {
                if((num & 1) == 1)
                    num--;
                else
                    num >>= 1;

                forReturn++;
            }

            return forReturn;
        }
    }
}
