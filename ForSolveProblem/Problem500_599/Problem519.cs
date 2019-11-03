using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem519 : IProblem
    {
        public void RunProblem()
        {
            Solution obj = new Solution(2, 3);
            int[] param_1 = obj.Flip();
            obj.Reset();
        }

        public class Solution2
        {

            Dictionary<int, int> dic;
            int total;
            int row;
            int col;

            public Solution2(int n_rows, int n_cols)
            {
                dic = new Dictionary<int, int>();
                row = n_rows;
                col = n_cols;
                total = n_rows * n_cols;
            }

            public int[] Flip()
            {
                Random rand = new Random();
                int r = rand.Next(0, total);

                int val = 0;
                if (dic.ContainsKey(r))
                {
                    val = dic[r];
                }
                else
                {
                    val = r;
                }

                total--;
                if (dic.ContainsKey(total))
                {
                    dic[r] = dic[total];
                }
                else
                {
                    dic[r] = total;
                }

                int[] res = new int[2] { val / col, val % col };
                return res;
            }

            public void Reset()
            {
                dic.Clear();
                total = row * col;
            }
        }

        /// <summary>
        /// 思路要点
        /// 1. 用Hash来存储已经翻转过的位置
        /// 2. 当翻转的位置冲突的时候,随机的向上或向下顺延继续找未翻转的
        /// 3. 需要清空的时候,只用清空Hash就好了
        /// 
        /// 相比于数据的规模1E8,总的操作次数1E3是很小的,所以可以考虑存储已翻转结果的方式
        /// </summary>
        public class Solution
        {
            /// <summary>
            /// 标记已经翻转的位置
            /// </summary>
            private ISet<string> m_Filped;

            /// <summary>
            /// 总的行数
            /// </summary>
            private int m_Rows;

            /// <summary>
            /// 总的列数
            /// </summary>
            private int m_Cols;

            /// <summary>
            /// 随机数生成器
            /// </summary>
            private Random m_R;

            public Solution(int n_rows, int n_cols)
            {
                m_Filped = new HashSet<string>(1000);
                m_Rows = n_rows;
                m_Cols = n_cols;
                m_R = new Random();
            }

            public int[] Flip()
            {
                var randomR = m_R.Next(0, m_Rows);
                var randomC = m_R.Next(0, m_Cols);
                var flipStr = $"{randomR}_{randomC}";

                //之前此位置没有被翻转过
                if (!m_Filped.Contains(flipStr))
                {
                    m_Filped.Add(flipStr);
                    return new int[] { randomR, randomC };
                }

                //之前此位置被翻转过,因此要随机的向左边/右边继续找,类似于处理哈希冲突的方式
                var randomUpDown = m_R.Next(0, 2);
                var cIncrease = 1;
                var rIncrease = 1;
                if (randomUpDown == 0)
                {
                    cIncrease = -1;
                    rIncrease = -1;
                }

                do
                {
                    randomC += cIncrease;
                    if (randomC < 0)
                    {
                        //超出了左边界则向上换行
                        randomC = m_Cols - 1;
                        randomR += rIncrease;
                        if (randomR < 0) randomR = m_Rows - 1;
                    }
                    else if (randomC > m_Cols - 1)
                    {
                        //超出了右边界则向下换行
                        randomC = 0;
                        randomR += rIncrease;
                        if (randomR > m_Rows - 1) randomR = 0;
                    }

                    flipStr = $"{randomR}_{randomC}";
                }
                while (m_Filped.Contains(flipStr));

                m_Filped.Add($"{randomR}_{randomC}");
                return new int[] { randomR, randomC };
            }

            public void Reset()
            {
                m_Filped.Clear();
            }
        }
    }
}
