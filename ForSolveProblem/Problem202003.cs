using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem202003 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int[] GetTriggerTime(int[][] increase, int[][] requirements)
        {
            var res = Enumerable.Repeat(-1, requirements.Length).ToArray();

            var oneDic = GetValueIndex(requirements, 0);
            var twoDic = GetValueIndex(requirements, 1);
            var threeDic = GetValueIndex(requirements, 2);
            
            var oneSum = 0;
            var twoSum = 0;
            var threeSum = 0;
            MatchOpera(oneDic, twoDic, threeDic, oneSum, twoSum, threeSum, -1, res);

            for (var i = 0; i < increase.Length; i++)
            {
                oneSum += increase[i][0];
                twoSum += increase[i][1];
                threeSum += increase[i][2];

                MatchOpera(oneDic, twoDic, threeDic, oneSum, twoSum, threeSum, i, res);
            }

            return res;
        }

        private void MatchOpera(SortedList<int, HashSet<int>> oneDic, SortedList<int, HashSet<int>> twoDic, SortedList<int, HashSet<int>> threeDic, int oneSum, int twoSum, int threeSum, int i, int[] res)
        {
            var m1 = GetMatchIndex(oneDic, oneSum);
            var m2 = GetMatchIndex(twoDic, twoSum);
            var m3 = GetMatchIndex(threeDic, threeSum);

            m1.IntersectWith(m2);
            m1.IntersectWith(m3);

            if (!m1.Any()) return;

            foreach (var indexItem in m1)
                res[indexItem] = i + 1;

            RemoveMatchIndex(oneDic, oneSum, m1);
            RemoveMatchIndex(twoDic, twoSum, m1);
            RemoveMatchIndex(threeDic, threeSum, m1);
        }

        private SortedList<int, HashSet<int>> GetValueIndex(int[][] requirements, int type)
        {
            var res = new SortedList<int, HashSet<int>>();

            for (var i = 0; i < requirements.Length; i++)
            {
                var curValue = requirements[i][type];

                if (!res.ContainsKey(curValue))
                    res[curValue] = new HashSet<int>();

                res[curValue].Add(i);
            }

            return res;
        }

        private ISet<int> GetMatchIndex(SortedList<int, HashSet<int>> dic, int curValue)
        {
            var res = new List<int>();
            foreach (var item in dic)
            {
                if (item.Key > curValue)
                    break;

                res.AddRange(item.Value);
            }

            return new HashSet<int>(res);
        }

        private void RemoveMatchIndex(SortedList<int, HashSet<int>> dic, int curValue, ISet<int> removeSets)
        {
            var removeKey = new List<int>();
            foreach (var item in dic)
            {
                if (item.Key > curValue)
                    break;

                item.Value.ExceptWith(removeSets);
                if (item.Value.Count == 0)
                    removeKey.Add(item.Key);
            }

            removeKey.ForEach(i => dic.Remove(i));
        }
    }
}
