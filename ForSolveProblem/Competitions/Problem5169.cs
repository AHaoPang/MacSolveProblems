using System;
namespace ForSolveProblem
{
    public class Problem5169 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int DaysBetweenDates(string date1, string date2)
        {
            return Math.Abs((int)(DateTime.Parse(date1) - DateTime.Parse(date2)).TotalDays);
        }
    }
}
