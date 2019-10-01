using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem781 : IProblem
    {
        public void RunProblem()
        {
            var temp = NumRabbits(new int[] { 1, 1, 2 });
            if (temp != 5) throw new Exception();

            temp = NumRabbits(new int[] { 10, 10, 10 });
            if (temp != 11) throw new Exception();

            temp = NumRabbits(new int[] { });
            if (temp != 0) throw new Exception();

            temp = NumRabbits(new int[] { 1, 0, 1, 0, 0 });
            if (temp != 5) throw new Exception();
        }

        public int NumRabbits(int[] answers)
        {
            /*
             * 依据诚实的兔子们的回答，推断出最少有多少只兔子
             * 思路：
             *  1.每个回答都是诚实的，那么回答数量相同的，一定满足下面的推断
             *      1.1 回答的数量+1=此种颜色兔子的数量
             *      1.2 答案相同的兔子数量 > 此种颜色兔子的数量，那么说明有多个颜色的兔子数量相同
             *  2.所以需要先对兔子的回答做汇总，然后对每种答案求解
             *      2.1 (答案相同的兔子数量 / 此种颜色兔子的数量)向上取整，然后乘以此种颜色兔子的数量
             *  
             * 时间复杂度：O(n)，遍历数组的每一项
             * 空间复杂度：O(n)，最坏情况下，每个兔子的回答都不同
             */

            var colorGroupDic = new Dictionary<int, int>(answers.Length);
            foreach(var answerItem in answers)
            {
                if (!colorGroupDic.ContainsKey(answerItem)) colorGroupDic[answerItem] = 0;
                colorGroupDic[answerItem]++;
            }

            var forReturn = 0;
            foreach (var colorItem in colorGroupDic)
            {
                var colorTotalNum = colorItem.Key + 1;
                forReturn += (int)Math.Ceiling(1.0 * colorItem.Value / colorTotalNum) * colorTotalNum;
            }

            return forReturn;
        }
    }
}
