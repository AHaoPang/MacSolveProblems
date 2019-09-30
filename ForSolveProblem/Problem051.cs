using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem051 : IProblem
    {
        public void RunProblem()
        {
            var temp = SolveNQueens(4);
        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> forReturn = new List<IList<string>>();

            IList<int> queenPos = new int[n];
            IList<bool> colArray = new bool[n];

            Way1(forReturn, 0, n, queenPos, colArray, new HashSet<int>(), new HashSet<int>());

            return forReturn;
        }

        /// <summary>
        /// 递归尝试所有的可能性，可以看做是一种回溯的解法
        /// </summary>
        /// <param name="forReturn">存储所有可能的情况</param>
        /// <param name="curPos">当前是第几行（从0开始）</param>
        /// <param name="totalRow">总共是多少行</param>
        /// <param name="queenPos">皇后都是在哪个位置，索引表示行，值表示列</param>
        /// <param name="colArray">竖行哪些位置都有皇后了</param>
        /// <param name="pie">撇，哪些位置有皇后了</param>
        /// <param name="na">纳，哪些位置有皇后了</param>
        private void Way1(IList<IList<string>> forReturn, int curPos, int totalRow, IList<int> queenPos, IList<bool> colArray, HashSet<int> pie, HashSet<int> na)
        {
            //中止条件
            if (curPos == totalRow)
            {
                forReturn.Add(MadeString(queenPos));
                return;
            }

            //递归条件（在每列做放置尝试）
            for(int i = 0;i < totalRow; i++)
            {
                //此行不满足条件
                if (colArray[i] || pie.Contains(curPos + i) || na.Contains(curPos - i)) continue;

                queenPos[curPos] = i;//确定了皇后的位置

                colArray[i] = true;
                pie.Add(curPos + i);
                na.Add(curPos - i);

                Way1(forReturn, curPos + 1, totalRow, queenPos, colArray, pie, na);

                colArray[i] = false;
                pie.Remove(curPos + i);
                na.Remove(curPos - i);
            }
        }

        /// <summary>
        /// 依据皇后的位置，构建期望的输出结果
        /// </summary>
        /// <param name="queenPos">皇后的位置</param>
        private IList<string> MadeString(IList<int> queenPos)
        {
            IList<string> forReturn = new List<string>();

            var totalRaw = queenPos.Count;

            for (int i = 0; i < totalRaw; i++)
            {
                string newLine = "";
                for (int j = 0; j < totalRaw; j++)
                {
                    if (queenPos[i] == j)
                        newLine += "Q";
                    else
                        newLine += ".";
                }
                forReturn.Add(newLine);
            }

            return forReturn;
        }
    }
}
