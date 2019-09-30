using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem292 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool CanWinNim(int n)
        {
            /*
             * 这样一个游戏，自己能否胜利
             * 思路：
             *  1.自己作为先手，对于随机分布的n，是有3/4的概率是可以赢的
             *  2.既然最后拿石头就算是胜利，那么我们只要让最后的石头数量为4个就好了，如此一来无论对方怎么操作，都会是自己赢了
             *  3.对于不是4个倍数的N,我们前面拿4的余数个石头，最后结果一定是4的倍数，所以就是我们赢
             *  4.反之则是对方赢
             *  5.当自己控制了局势，对方再聪明也是无法挽回的，而此游戏控制局势的方式居然是“先手”
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            return n % 4 != 0;
        }
    }
}
