using System;
namespace ForSolveProblem
{
    public class Problem5371 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int FindGoodStrings(int n, string s1, string s2, string evil)
        {
            var constNum = (int)1e9 + 7;
            var levelArray = GetLevelArray(n, constNum);

            var sum = 0L;
            for (var i = n - 1; i >= 0; i--)
            {
                var subValue = s2[i] - s1[i];
                var subPos = n - 1 - i;

                sum += subValue * levelArray[subPos] % constNum;
                sum %= constNum;
            }

            var sub = 0L;
            for (var i = n - 1 - evil.Length + 1; i >= 0; i--)
            {
                if (IsMatch(s1, s2, evil, i))
                {
                    sub += levelArray[n - 1 - i - (evil.Length - 1)];
                    sub %= constNum;
                }
            }

            var remain = sum - sub;
            return (int)(remain < 0 ? remain + constNum : remain);
        }

        private int[] GetLevelArray(int n, int constNum)
        {
            var res = new int[n + 1];
            res[0] = 1;

            var curNum = 1L;
            for (var i = 1; i <= n; i++)
            {
                curNum *= 26;
                curNum %= constNum;

                res[i] = (int)curNum;
            }

            return res;
        }

        private bool IsMatch(string s1, string s2, string evil, int s)
        {
            var eIndex = 0;
            for (var i = s; i < s + evil.Length; i++)
            {
                if (evil[eIndex] >= s1[i] && evil[eIndex] <= s2[i])
                    eIndex++;
                else
                    return false;
            }

            return true;
        }
    }
}
