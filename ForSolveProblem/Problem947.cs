using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem947 : IProblem
    {
        public void RunProblem()
        {
            var arr = new int[][]
            {
                new[]{3, 3 },
                new[]{4,4},
                new[]{1,4},
                new[]{1,5},
                new[]{2,3},
                new[]{4,3},
                new[]{2,4}
            };
            var temp = RemoveStones(arr);

        }

        public int RemoveStones(int[][] stones)
        {
            /*
             * ##### 1. 题目概述：
             * 
             * ##### 2. 思路：
             *    - 特征：
             *    - 方案：
             *    - 结果：
             *
             * ##### 3. 知识点：
             * 
             * ##### 4. 复杂度分析: 
             *    - 时间复杂度：
             *    - 空间复杂度：
             */

            var rowDic = new Dictionary<int, string>();
            var colDic = new Dictionary<int, string>();

            var js = new JointSet();
            for (var i = 0; i < stones.Length; i++)
            {
                var r = stones[i][0];
                var c = stones[i][1];
                var s = js.GetKeyStr(r, c);

                var rt = string.Empty;
                if (rowDic.ContainsKey(r)) rt = rowDic[r];
                rowDic[r] = s;

                var ct = string.Empty;
                if (colDic.ContainsKey(c)) ct = colDic[c];
                colDic[c] = s;

                if (!string.IsNullOrEmpty(rt) && !string.IsNullOrEmpty(ct))
                {
                    js.Merge(rt, ct);
                    js.Follow(rt, s);
                }
                else if (!string.IsNullOrEmpty(rt))
                {
                    js.Follow(rt, s);
                }
                else if (!string.IsNullOrEmpty(ct))
                {
                    js.Follow(ct, s);
                }
                else
                {
                    js.AddNew(s);
                }
            }

            return stones.Length - js.GetValueSetCount();
        }


        class JointSet
        {
            private Dictionary<string, string> _arr = new Dictionary<string, string>();

            private string GetFather(string s)
            {
                if (_arr[s] != s)
                    _arr[s] = GetFather(_arr[s]);

                return _arr[s];
            }

            public string GetKeyStr(int r, int c) => $"{r}_{c}";

            public void AddNew(string s) => _arr[s] = s;

            public void Follow(string s1, string s2) => _arr[s2] = GetFather(s1);

            public void Merge(string s1, string s2) => _arr[GetFather(s1)] = GetFather(s2);

            public int GetValueSetCount() => _arr.Count(i => i.Key == i.Value);
        }
    }
}
