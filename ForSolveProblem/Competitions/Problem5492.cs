using System;
namespace ForSolveProblem
{
    public class Problem5492 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int NumWays(string s)
        {
            var constNum = (int)(1e9 + 7);

            var oneCount = 0;
            foreach (var c in s)
                if (c == '1')
                    oneCount++;

            if (oneCount % 3 != 0)
                return 0;

            var perCount = oneCount / 3;
            if (perCount == 0)
                return zeroCount(s.Length);

            var res = 1L;

            var firstLastIndex = FindIndex(s, 0, perCount);
            var secondFirstIndex = FindNextOneIndex(s, firstLastIndex + 1);
            res *= secondFirstIndex - firstLastIndex;
            res %= constNum;

            var secondLastIndex = FindIndex(s, firstLastIndex + 1, perCount);
            var thirdFirstIndex = FindNextOneIndex(s, secondLastIndex + 1);
            res *= thirdFirstIndex - secondLastIndex;
            res %= constNum;

            return (int)res;
        }

        public int zeroCount(long n)
        {
            var constNum = (int)(1e9 + 7);

            var res = 0;
            for (var i = 1; i <= n - 2; i++)
            {
                res += i;
                res %= constNum;
            }

            return res;
        }

        public int FindIndex(string s, int startIndex, int count)
        {
            var c = 0;
            for (var i = startIndex; i < s.Length; i++)
            {
                if (s[i] == '1')
                    c++;

                if (c == count)
                    return i;
            }

            return -1;
        }

        public int FindNextOneIndex(string s, int startIndex)
        {
            while (s[startIndex] != '1')
                startIndex++;

            return startIndex;
        }
    }
}
