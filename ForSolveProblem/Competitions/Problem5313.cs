using System;
namespace ForSolveProblem
{
    public class Problem5313 : IProblem
    {
        public void RunProblem()
        {
            var temp = AngleClock(12, 30);

            temp = AngleClock(3, 30);

            temp = AngleClock(3, 15);

            temp = AngleClock(4, 50);

            temp = AngleClock(12, 0);
        }

        public double AngleClock(int hour, int minutes)
        {
            double hourMinuters = hour * 5;
            hourMinuters += 5 * (minutes / 60.0);

            var subValue = Math.Abs(hourMinuters - minutes);
            if (subValue > 30)
                subValue = 60 - subValue;

            return 1.0 * subValue / 60 * 360;
        }
    }
}
