using System;
namespace ForSolveProblem
{
    public class Problem1185 : IProblem
    {
        public string DayOfTheWeek(int day, int month, int year) => new DateTime(year, month, day).DayOfWeek.ToString("g");

        public void RunProblem()
        {
            var temp = DayOfTheWeek(31, 8, 2019);
            if (temp != "Saturday") throw new Exception();

            temp = DayOfTheWeek(18, 7, 1999);
            if (temp != "Sunday") throw new Exception();

            temp = DayOfTheWeek(15, 8, 1993);
            if (temp != "Sunday") throw new Exception();
        }
    }
}
