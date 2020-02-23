using System;
namespace ForSolveProblem
{
    public class Problem5171 : IProblem
    {
        public void RunProblem()
        {
            var temp = ClosestDivisors(8);

            temp = ClosestDivisors(123);

            temp = ClosestDivisors(999);

            temp = ClosestDivisors(443795297);

            temp = ClosestDivisors(785270913);
        }

        public int[] ClosestDivisors(int num)
        {
            var r1 = GetTwoNum(num + 1);
            var r2 = GetTwoNum(num + 2);

            return r1[1] - r1[0] > r2[1] - r2[0] ? r2 : r1;
        }

        private int[] GetTwoNum(int num)
        {
            var midValue = (int)Math.Sqrt(num);

            long leftValue = midValue;
            long rightValue = midValue;
            while (leftValue >= 1 && rightValue <= num)
            {
                var mulValue = leftValue * rightValue;

                if (mulValue == num)
                    return new int[] { (int)leftValue, (int)rightValue };

                //if (leftValue == 1 || rightValue == num)
                //    return new int[] { 1, num };

                if (mulValue > num)
                    leftValue = num / rightValue == leftValue ? leftValue - 1 : num / rightValue;
                else
                    rightValue = num / leftValue == rightValue ? rightValue + 1 : num / leftValue;
            }

            return new int[] { 1, 1 };
        }
    }
}
