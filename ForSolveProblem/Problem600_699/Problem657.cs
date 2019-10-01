using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem657 : IProblem
    {
        public void RunProblem()
        {
            var temp = JudgeCircle("UD");
            if (temp != true) throw new Exception();

            temp = JudgeCircle("LL");
            if (temp != false) throw new Exception();
        }

        public bool JudgeCircle(string moves)
        {
            /*
             * 判断经过一系列移动之后，是否还会回到原点
             * 思路：
             *  1.只要是操作具有相互抵消的性质，那么最后就会回到原点
             *  2.比方说，左右操作会相互抵消，上下操作会相互抵消
             *  3.统计各个操作的数量，若可以完全抵消，那么就会回到原点了
             *  
             * 时间复杂度：O(n)，需要统计各个操作
             * 空间复杂度：O(1)，需要使用的额外空间是固定的
             */

            int[] directCountArray = new int[4];

            foreach(var moveItem in moves)
            {
                //R（右），L（左），U（上）和 D（下）
                switch (moveItem)
                {
                    case 'U':
                        directCountArray[0]++;
                        break;

                    case 'D':
                        directCountArray[1]++;
                        break;

                    case 'L':
                        directCountArray[2]++;
                        break;

                    case 'R':
                        directCountArray[3]++;
                        break;
                }
            }

            return directCountArray[0] == directCountArray[1] && directCountArray[2] == directCountArray[3];
        }
    }
}
