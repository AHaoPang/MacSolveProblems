using System;
namespace ForSolveProblem
{
    public class Problem5369 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumTeams(int[] rating)
        {
            var res = 0;
            for(var i = 0;i < rating.Length - 2; i++)
            {
                for(var j = i+1;j < rating.Length - 1; j++)
                {
                    for(var k = j+1;k < rating.Length; k++)
                    {
                        if (rating[i] < rating[j] && rating[j] < rating[k])
                            res++;
                        else if (rating[i] > rating[j] && rating[j] > rating[k])
                            res++;
                    }
                }
            }

            return res;
        }
    }
}
