using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5377 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumSteps(string s)
        {
            var sArray = s.ToCharArray().Select(i => int.Parse(i.ToString())).ToList();

            var res = 0;
            while (sArray.Count != 1)
            {
                switch (sArray.Last())
                {
                    case 1:
                        var one = 1;
                        for (var j = sArray.Count - 1; j >= 0; j--)
                        {
                            var sumTemp = one + sArray[j];
                            sArray[j] = sumTemp % 2;
                            one = sumTemp / 2;

                            if (one != 1)
                                break;
                        }

                        if (one == 1)
                            sArray.Insert(0, 1);

                        break;

                    case 0:
                        sArray.RemoveAt(sArray.Count - 1);
                        break;
                }

                res++;
            }

            return res;
        }
    }
}
