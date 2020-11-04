using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem1583 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int UnhappyFriends(int n, int[][] preferences, int[][] pairs)
        {
            var rows = preferences.Length;
            var cols = preferences[0].Length;

            var relationArray = new int[n, n];
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    var ct = preferences[r][c];
                    relationArray[r, ct] = c;
                }
            }

            var dic = new Dictionary<int, int>();
            foreach (var pairItem in pairs)
            {
                dic[pairItem[0]] = pairItem[1];
                dic[pairItem[1]] = pairItem[0];
            }

            var res = 0;
            foreach (var pairItem in pairs)
            {
                var leftNum = pairItem[0];
                var rightNum = pairItem[1];

                if (CompareRelation(leftNum, rightNum, relationArray, preferences, dic))
                    res++;
                if (CompareRelation(rightNum, leftNum, relationArray, preferences, dic))
                    res++;
            }

            return res;
        }

        private bool CompareRelation(int leftNum, int rightNum, int[,] relationArray, int[][] preferences, Dictionary<int, int> dic)
        {
            for (var i = 0; i < relationArray[leftNum, rightNum]; i++)
            {
                var oneMiddle = preferences[leftNum][i];
                var leftToOneMiddle = relationArray[oneMiddle, leftNum];

                var oneMiddleAndAnoter = dic[oneMiddle];
                var oneMiddleToAnother = relationArray[oneMiddle, oneMiddleAndAnoter];

                if (leftToOneMiddle < oneMiddleToAnother)
                    return true;
            }

            return false;
        }
    }
}
