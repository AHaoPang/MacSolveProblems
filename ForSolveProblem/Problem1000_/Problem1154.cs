using System;
namespace ForSolveProblem
{
    public class Problem1154 : IProblem
    {
        public void RunProblem()
        {
            var temp = DayOfYear("2019-01-09");
            if (temp != 9) throw new Exception();

            temp = DayOfYear("2019-02-10");
            if (temp != 41) throw new Exception();

            temp = DayOfYear("2003-03-01");
            if (temp != 60) throw new Exception();

            temp = DayOfYear("2004-03-01");
            if (temp != 61) throw new Exception();
        }

        public int DayOfYear(string date)
        {
            return DateTime.Parse(date).DayOfYear;
        }
    }
}
