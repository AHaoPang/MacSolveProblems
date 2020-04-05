using System;
namespace ForSolveProblem
{
    public class Problem868 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int BinaryGap(int N)
        {
            var res = 0;
            var firstIndex = -1;
            var i = 0;
            while (N != 0)
            {
                if ((N & 1) == 1)
                {
                    if (firstIndex != -1)
                        res = Math.Max(res, i - firstIndex);

                    firstIndex = i;
                }

                N >>= 1;
                i++;
            }

            return res;
        }

        public int BinaryGap1(int N)
        {
            var constChar = '1';
            var binStr = Convert.ToString(N, 2);
            var oneIndex = binStr.IndexOf(constChar);
            var nextIndex = binStr.IndexOf(constChar, oneIndex + 1);

            var res = 0;
            while (nextIndex != -1)
            {
                res = Math.Max(nextIndex - oneIndex, res);

                oneIndex = nextIndex;
                nextIndex = binStr.IndexOf(constChar, nextIndex + 1);
            }

            return res;
        }
    }
}
