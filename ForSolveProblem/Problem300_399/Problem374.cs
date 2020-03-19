using System;
namespace ForSolveProblem
{
    public class Problem374 : GuessGame, IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int GuessNumber(int n)
        {
            var left = 1;
            var right = n;

            while (true)
            {
                var middle = left + (right - left) / 2;
                var r = guess(middle);
                if (r == 0)
                    return middle;

                if (r == -1)
                    right = middle - 1;
                else
                    left = middle + 1;
            }
        }
    }

    public class GuessGame
    {
        public int guess(int i) => 1;
    }
}
