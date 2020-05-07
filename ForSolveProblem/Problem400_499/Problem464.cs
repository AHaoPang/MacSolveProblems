using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem464 : IProblem
    {
        public void RunProblem()
        {
            var temp = CanIWin(10, 11);
            if (temp != false) throw new Exception();

            temp = CanIWin(10, 40);
            if (temp != false) throw new Exception();

            temp = CanIWin(4, 6);
            if (temp != true) throw new Exception();

            temp = CanIWin(20, 210);
        }

        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            var totalSum = (1 + maxChoosableInteger) * maxChoosableInteger / 2;
            if (desiredTotal > totalSum) return false;

            return Win(maxChoosableInteger, desiredTotal, 0, new byte[1 << maxChoosableInteger]);
        }

        private bool Win(int maxInterger, int desiredNum, int curState, byte[] visited)
        {
            if (visited[curState] != 0)
                return visited[curState] == 1;

            var res = false;
            for (var i = 1; i <= maxInterger; i++)
            {
                var curValue = 1 << (i - 1);
                if ((curState & curValue) != 0)
                    continue;

                if (desiredNum <= i || !Win(maxInterger, desiredNum - i, curState | curValue, visited))
                {
                    res = true;
                    break;
                }
            }

            visited[curState] = (byte)(res ? 1 : 2);
            return res;
        }

        public bool CanIWin1(int maxChoosableInteger, int desiredTotal)
        {
            /*
             * 题目概述：给定可选择数字的范围，以及目标值，判断先手放，是否稳赢
             * 
             * 思路：
             *  1. 对弈的两个人都是高手，所以他俩的思考方式一定是一样的，因此对弈的过程，也可以看作是递归的过程，每次走步都为了更接近让自己赢得胜利的目标
             *  2. 对于先手的人，稳赢的思考过程如下:
             *      2.1 在可选的数字中，我用最大的数字可以触及目标，那么自己就赢了
             *      2.2 自己怎么选都不可能触及目标的话，那么就寄希望于自己选择一个对方无法赢的数字，只要对方赢不了，那么就是自己赢了
             *
             * 关键点：
             *
             * 时间复杂度： O(n)，因为可选择的数字是有限的，n 个，所以肯定是在 n 轮之内结束的
             * 空间复杂度： O(n)
             */

            //若所有可能性的总和都无法触及目标值的话，先手也是不可能赢的了
            var sumTemp = (1 + maxChoosableInteger) * maxChoosableInteger / 2;
            if (sumTemp < desiredTotal) return false;

            return Recursive(0, maxChoosableInteger, desiredTotal, new Dictionary<int, bool>());
        }

        private bool Recursive(int status, int maxChoosableInteger, int desiredTotal, IDictionary<int, bool> dic)
        {
            if (dic.ContainsKey(status)) return dic[status];

            var forReturn = false;

            for (int i = maxChoosableInteger; i >= 1; i--)
            {
                if (((status >> i) & 1) == 1) continue;

                if (i >= desiredTotal) forReturn = true;
                else
                {
                    var newSatus = status | (1 << i);
                    forReturn = !Recursive(newSatus, maxChoosableInteger, desiredTotal - i, dic);
                }

                if (forReturn) break;
            }

            dic[status] = forReturn;
            return forReturn;
        }
    }
}
