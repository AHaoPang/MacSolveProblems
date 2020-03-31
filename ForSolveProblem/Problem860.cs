using System;
namespace ForSolveProblem
{
    public class Problem860 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool LemonadeChange(int[] bills)
        {
            var numCount = new int[2];
            foreach(var billItem in bills)
            {
                switch (billItem)
                {
                    case 5:
                        numCount[0]++;
                        break;

                    case 10:
                        if (numCount[0] == 0)
                            return false;

                        numCount[0]--;
                        numCount[1]++;
                        break;

                    case 20:
                        if (numCount[0] == 0)
                            return false;

                        if(numCount[1] > 0)
                        {
                            numCount[0]--;
                            numCount[1]--;
                        }
                        else
                        {
                            numCount[0] -= 3;

                            if (numCount[0] < 0)
                                return false;
                        }

                        break;
                }
            }

            return true;
        }
    }
}
