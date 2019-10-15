using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5224 : IProblem
    {
        /// <summary>
        /// 计算实体
        /// </summary>
        public class CalcEntity
        {
            public CalcEntity(long initValue)
            {
                this.totalNum = initValue;
                queueMem = new Queue<long>();
                queueMem.Enqueue(initValue);
            }

            /// <summary>
            /// 当前总和
            /// </summary>
            public long totalNum;

            /// <summary>
            /// 新加入的数值
            /// </summary>
            public long newNum;

            /// <summary>
            /// 刚退出的数值
            /// </summary>
            public long subNum;

            /// <summary>
            /// 当前全部在队的数值
            /// </summary>
            public Queue<long> queueMem;
        }

        public int DieSimulator(int n, int[] rollMax)
        {
            /*
             * 想象成一个快递排队的过程,具体过程如下
             * 1.一共有6个队伍可以放快递
             * 2.第1轮每个队伍放1个快递
             * 3.下一轮,当前队伍上放的快递,一定是拷贝自其它队伍,然后再打包得来的
             * 4.不同的队伍,长度不同,当超长时,最先入队伍的快递是要被拿掉的
             * 
             * 时间复杂度:O(n*6*6)
             * 空间复杂度:O(1)
             */

            var constNum = unchecked((int)(1E9 + 7));

            var numQueueArray = new List<CalcEntity>();
            for (int i = 0; i < 6; i++)
                numQueueArray.Add(new CalcEntity(1));

            for (int i = 1; i < n; i++)
            {
                //最新一轮的更新
                for (int a = 0; a < 6; a++)
                {
                    //新加入的数字
                    var sumTemp = 0L;
                    for (int b = 0; b < 6; b++)
                    {
                        if (a == b) continue;

                        sumTemp += numQueueArray[b].totalNum;
                        sumTemp %= constNum;
                    }

                    numQueueArray[a].queueMem.Enqueue(sumTemp);
                    numQueueArray[a].newNum = sumTemp;

                    //退出的数字
                    if (numQueueArray[a].queueMem.Count > rollMax[a])
                    {
                        var v = numQueueArray[a].queueMem.Dequeue();
                        numQueueArray[a].subNum = v;
                    }
                }

                //对本轮的结果做更新
                for (int c = 0; c < 6; c++)
                {
                    numQueueArray[c].totalNum += numQueueArray[c].newNum;
                    numQueueArray[c].totalNum -= numQueueArray[c].subNum;
                    numQueueArray[c].subNum = 0;
                }
            }

            var forReturn = 0L;
            foreach (var arrayItem in numQueueArray)
            {
                var tempValue = 0L;
                while (arrayItem.queueMem.Any())
                {
                    tempValue += arrayItem.queueMem.Dequeue();
                    tempValue %= constNum;
                }

                forReturn += tempValue;
                forReturn %= constNum;
            }

            return (int)forReturn;
        }

        public int DieSimulator1(int n, int[] rollMax)
        {
            var constNum = unchecked((int)(1E9 + 7));
            var countArray = new int[] { 1, 1, 1, 1, 1, 1 };

            var totalArray = new long[] { 1, 1, 1, 1, 1, 1 };

            for (int i = 1; i < n; i++)
            {
                var newArray = new long[6];

                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (j == k) countArray[j]++;

                        if (countArray[j] > rollMax[j])
                        {
                            countArray[j] = 1;
                            continue;
                        }

                        newArray[j] += totalArray[k];
                        newArray[j] %= constNum;
                    }
                }

                totalArray = newArray;
            }

            long forReturn = 0;
            for (int i = 0; i < totalArray.Length; i++)
            {
                forReturn += totalArray[i];
                forReturn %= constNum;
            }

            return (int)forReturn;
        }

        public void RunProblem()
        {
            var temp = DieSimulator(2, new int[] { 1, 1, 2, 2, 2, 3 });
            if (temp != 34) throw new Exception();

            temp = DieSimulator(2, new int[] { 1, 1, 1, 1, 1, 1 });
            if (temp != 30) throw new Exception();

            temp = DieSimulator(3, new int[] { 1, 1, 1, 2, 2, 3 });
            if (temp != 181) throw new Exception();
        }
    }
}
