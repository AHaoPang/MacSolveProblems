using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem135 : IProblem
    {
        public void RunProblem()
        {
            var temp = Candy(new[] { 1, 0, 2 });
            if (temp != 5) throw new Exception();

            temp = Candy(new[] { 1, 2, 2 });
            if (temp != 4) throw new Exception();
        }

        public int Candy(int[] ratings)
        {
            var sToEArr = Enumerable.Repeat(1, ratings.Length).ToArray();
            for (var i = 1; i < ratings.Length; i++)
                if (ratings[i] > ratings[i - 1])
                    sToEArr[i] = sToEArr[i - 1] + 1;

            var eToSArr = Enumerable.Repeat(1, ratings.Length).ToArray();
            for (var i = ratings.Length - 2; i >= 0; i--)
                if (ratings[i] > ratings[i + 1])
                    eToSArr[i] = eToSArr[i + 1] + 1;

            var res = 0;
            for (var i = 0; i < ratings.Length; i++)
                res += Math.Max(sToEArr[i], eToSArr[i]);

            return res;
        }
    }
}
