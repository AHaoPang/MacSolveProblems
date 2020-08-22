using System;
namespace ForSolveProblem
{
    public class Problem5412 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            var res = 0;
            for (var i = 0; i < startTime.Length; i++)
                if (startTime[i] <= queryTime && endTime[i] >= queryTime)
                    res++;

            return res;
        }
    }
}
