using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem036 : IProblem
    {
        public void RunProblem()
        {
            char[,] eg = new char[9, 9]
            {
              {'5','3','.','.','7','.','.','.','.'},
              {'6','.','.','1','9','5','.','.','.'},
              {'.','9','8','.','.','.','.','6','.'},
              {'8','.','.','.','6','.','.','.','3'},
              {'4','.','.','8','.','3','.','.','1'},
              {'7','.','.','.','2','.','.','.','6'},
              {'.','6','.','.','.','.','2','8','.'},
              {'.','.','.','4','1','9','.','.','5'},
              {'.','.','.','.','8','.','.','7','9'}
            };

            char[,] eg2 = new char[9, 9]
            {
              {'8','3','.','.','7','.','.','.','.'},
              {'6','.','.','1','9','5','.','.','.'},
              {'.','9','8','.','.','.','.','6','.'},
              {'8','.','.','.','6','.','.','.','3'},
              {'4','.','.','8','.','3','.','.','1'},
              {'7','.','.','.','2','.','.','.','6'},
              {'.','6','.','.','.','.','2','8','.'},
              {'.','.','.','4','1','9','.','.','5'},
              {'.','.','.','.','8','.','.','7','9'}
            };

            var temp = IsValidSudoku(eg);
        }

        public bool IsValidSudoku(char[,] board)
        {
            /*
             * 1.巧用基础结构初始化
             * 2.了解数组的逻辑意义，而不限制自己的思维与物理意义，基于此，能更好的理解多维数组的本质意义，而不用思考物理外观
             * 3.字符转换为索引的有趣推测是实战
             */

            int length = 9;

            //集合的初始化
            bool[,] raw = new bool[9, 9];
            bool[,] col = new bool[9, 9];
            bool[,,] uni = new bool[3, 3, 9];

            //有序遍历整个数组中的每个元素
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //搜集并验证数据，有问题则直接中断（失败了就没有继续遍历的必要了）
                    var temp = board[i, j];
                    if (temp == '.') continue;

                    int indexTemp = temp - '1';

                    if (raw[i, indexTemp] || col[j, indexTemp] || uni[i / 3, j / 3, indexTemp])
                        return false;
                    else
                    {
                        raw[i, indexTemp] = true;
                        col[j, indexTemp] = true;
                        uni[i / 3, j / 3, indexTemp] = true;
                    }
                }
            }

            return true;
        }

        public bool Way1(char[,] board)
        {
            int length = 9;

            //集合的初始化
            HashSet<int>[] raw = new HashSet<int>[9];
            HashSet<int>[] col = new HashSet<int>[9];
            HashSet<int>[,] uni = new HashSet<int>[3, 3];
            for (int k = 0; k < length; k++)
            {
                raw[k] = new HashSet<int>();
                col[k] = new HashSet<int>();
            }
            for (int l = 0; l < 3; l++)
            {
                for (int m = 0; m < 3; m++)
                {
                    uni[l, m] = new HashSet<int>();
                }
            }

            //有序遍历整个数组中的每个元素
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    //搜集并验证数据，有问题则直接中断（失败了就没有继续遍历的必要了）
                    var temp = board[i, j];
                    if (temp == '.') continue;

                    if (raw[i].Contains(temp) || col[j].Contains(temp) || uni[i / 3, j / 3].Contains(temp))
                        return false;
                    else
                    {
                        raw[i].Add(temp);
                        col[j].Add(temp);
                        uni[i / 3, j / 3].Add(temp);
                    }
                }
            }

            return true;
        }

    }
}
