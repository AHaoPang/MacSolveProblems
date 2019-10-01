using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem318 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int MaxProduct(string[] words)
        {
            /*
             * 判断由不同成分组成的单词，乘积的最大值
             * 思路：
             *  1.首先要分析出单词的成分
             *  2.然后每两个单词比较，就能确定成分是否一致，以及获取到最大值了
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            //遍历单词，构造二进制标识
            int[] wordPos = new int[words.Length];
            for(int i = 0;i < words.Length; i++)
                for(int j = 0;j < words[i].Length; j++)
                    wordPos[i] |= (1 << (words[i][j] - 'a'));


            //二进制标识位运算，求得最大值
            int forReturn = 0;
            for(int k = 0;k < words.Length - 1; k++)
            {
                for(int l = k + 1;l < words.Length; l++)
                {
                    if((wordPos[k] & wordPos[l]) == 0)
                    {
                        int maxTemp = words[k].Length * words[l].Length;

                        if (maxTemp > forReturn) forReturn = maxTemp;
                    }
                }
            }

            return forReturn;
        }
    }
}
