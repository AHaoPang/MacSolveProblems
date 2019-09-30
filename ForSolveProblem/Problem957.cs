using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem957 : IProblem
    {
        public void RunProblem()
        {
            var temp = PrisonAfterNDays(new int[] { 0, 1, 0, 1, 1, 0, 0, 1 }, 7);
            if (!ProblemHelper.ArrayIsEqual(new int[] { 0, 0, 1, 1, 0, 0, 0, 0 }, temp)) throw new Exception();

            temp = PrisonAfterNDays(new int[] { 1, 0, 0, 1, 0, 0, 1, 0 }, 1000000000);
            if (!ProblemHelper.ArrayIsEqual(new int[] { 0, 0, 1, 1, 1, 1, 1, 0 }, temp)) throw new Exception();
        }

        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            /*
             * 依据监狱当前的状态以及变化规则，推测出N天以后，监狱的状态
             * 思路：
             *  1.一共有8间房，每个房子有两种状态：空、满，所以8间房子，最多有256种情况
             *  2.如果N超过256，就一定够造成一个循环，循环有助于我们快速取值，而不用再一次推演了
             *  3.最多循环256次，最多存储256个状态，所以可以认为是常量的时间复杂度
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            var cellStatusDic = new Dictionary<int, int>();
            var initStatus = IntArrayToInt(cells);
            while (N > 0)
            {
                if (cellStatusDic.ContainsKey(initStatus))
                    N %= cellStatusDic[initStatus] - N;

                cellStatusDic[initStatus] = N;

                if(N >= 1)
                {
                    N--;
                    initStatus = StatusTransfer(initStatus);
                }
            }

            return IntToIntArray(initStatus);
        }

        /// <summary>
        /// 从当前状态过度到下一个状态
        /// </summary>
        private int StatusTransfer(int status)
        {
            var forReturn = 0;
            for (int i = 1; i <= 6; i++)
                if (((status >> i - 1) & 1) == ((status >> i + 1) & 1)) forReturn |= (1 << i);

            return forReturn;
        }

        /// <summary>
        /// 将Int数组转换为Int数字
        /// </summary>
        private int IntArrayToInt(int[] status)
        {
            var forReturn = 0;
            for (int i = 0; i < status.Length; i++)
                if (status[i] != 0) forReturn |= (1 << i);

            return forReturn;
        }

        /// <summary>
        /// 将Int数转换为Int数组
        /// </summary>
        private int[] IntToIntArray(int status)
        {
            var forReturn = new int[8];
            for (int i = 0; i < 8; i++)
            {
                if ((status & 1) == 1) forReturn[i] = 1;

                status >>= 1;
            }

            return forReturn;
        }
    }
}
