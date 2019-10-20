using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5232 : IProblem
    {
        public void RunProblem()
        {
            var temp = BalancedString("QWER");
            if (temp != 0) throw new Exception();

            temp = BalancedString("QQWE");
            if (temp != 1) throw new Exception();

            temp = BalancedString("QQQW");
            if (temp != 2) throw new Exception();

            temp = BalancedString("QQQQ");
            if (temp != 3) throw new Exception();

            temp = BalancedString("WWEQERQWQWWRWWERQWEQ");
            if (temp != 4) throw new Exception();

            temp = BalancedString("WWWEQRQEWWQQQWQQQWEWEEWRRRRRWWQE");
            if (temp != 5) throw new Exception();
        }

        /// <summary>
        /// 统计实体
        /// </summary>
        class StatisticsEntity
        {
            /// <summary>
            /// 当前所在的索引位置
            /// </summary>
            public int CurIndex { get; set; }

            /// <summary>
            /// 当前的统计结果
            /// </summary>
            public IDictionary<char, int> CurComposed = new Dictionary<char, int>();
        }

        public int BalancedString(string s)
        {
            //平衡线
            var aimNum = s.Length / 4;

            //得到从右边开始的极限位置
            var rigthCountEntity = new StatisticsEntity();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                var curChar = s[i];

                if (!rigthCountEntity.CurComposed.ContainsKey(curChar)) rigthCountEntity.CurComposed[curChar] = 0;
                if (rigthCountEntity.CurComposed[curChar] == aimNum)
                {
                    rigthCountEntity.CurIndex = i + 1;
                    break;
                }

                rigthCountEntity.CurComposed[curChar]++;
            }

            //从左边开始,探索新的极限
            var forReturn = rigthCountEntity.CurIndex;
            var leftCountEntity = new StatisticsEntity();
            for (int j = 0; j < s.Length; j++)
            {
                var curChar = s[j];
                leftCountEntity.CurIndex = j;

                if (!leftCountEntity.CurComposed.ContainsKey(curChar)) leftCountEntity.CurComposed[curChar] = 0;
                if (leftCountEntity.CurComposed[curChar] == aimNum) break;

                leftCountEntity.CurComposed[curChar]++;
                VerifyAndChange(s, leftCountEntity, rigthCountEntity);

                forReturn = Math.Min(forReturn, rigthCountEntity.CurIndex - leftCountEntity.CurIndex - 1);
            }

            return forReturn;
        }

        /// <summary>
        /// 当左面的收集导致超限时,去右面去缩减
        /// </summary>
        private void VerifyAndChange(string s, StatisticsEntity leftEntity, StatisticsEntity rightEntity)
        {
            var aimNum = s.Length / 4;

            foreach (var leftValue in leftEntity.CurComposed)
            {
                if (!rightEntity.CurComposed.ContainsKey(leftValue.Key)) continue;

                var sumNum = leftValue.Value + rightEntity.CurComposed[leftValue.Key];
                while (sumNum > aimNum)
                {
                    var curChar = s[rightEntity.CurIndex];
                    rightEntity.CurIndex++;
                    rightEntity.CurComposed[curChar]--;

                    sumNum = leftValue.Value + rightEntity.CurComposed[leftValue.Key];
                }
            }
        }


        public int BalancedString2(string s)
        {
            var aimNum = s.Length / 4;

            var charCountDic = new Dictionary<char, int>();
            foreach (var sChar in s)
            {
                if (!charCountDic.ContainsKey(sChar)) charCountDic[sChar] = 0;
                charCountDic[sChar]++;
            }

            return charCountDic.Where(i => i.Value > aimNum).Sum(i => i.Value - aimNum);
        }

        public int BalancedString1(string s)
        {
            var charCountDic = new Dictionary<char, int>();

            var leftIndex = 0;
            for (; leftIndex < s.Length; leftIndex++)
                if (!ChangeArray(s, leftIndex, charCountDic)) break;

            var rightIndex = s.Length - 1;
            for (; rightIndex > leftIndex; rightIndex--)
                if (!ChangeArray(s, rightIndex, charCountDic)) break;

            var v1 = s.Length - charCountDic.Values.Sum();

            var charCountDic2 = new Dictionary<char, int>();

            rightIndex = s.Length - 1;
            for (; rightIndex >= 0; rightIndex--)
                if (!ChangeArray(s, rightIndex, charCountDic2)) break;

            leftIndex = 0;
            for (; leftIndex < rightIndex; leftIndex++)
                if (!ChangeArray(s, leftIndex, charCountDic2)) break;

            var v2 = s.Length - charCountDic2.Values.Sum();

            return Math.Min(v1, v2);
        }

        private bool ChangeArray(string s, int curIndex, IDictionary<char, int> charCountDic)
        {
            var aimNum = s.Length / 4;

            var curChar = s[curIndex];

            if (!charCountDic.ContainsKey(curChar)) charCountDic[curChar] = 0;
            if (charCountDic[curChar] == aimNum) return false;

            charCountDic[curChar]++;
            return true;
        }
    }
}
