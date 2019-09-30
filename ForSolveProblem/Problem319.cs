using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem319 : IProblem
    {
        public void RunProblem()
        {
            var temp = BulbSwitch(3);
            if (temp != 1) throw new Exception();
        }

        public int BulbSwitch(int n)
        {
            /*
             * 判断n个灯泡在特定的规律开关下，最后会有多少个灯泡保持明亮状态
             * 思路：
             *  1.判断一个位置，最后是什么状态，就是看他开关了多少次
             *  2.以 36为例：1、2、3、4、6、9、12、13、36，明显是奇数次，因此最后是“开状态”
             *  3.以 18为例：1、2、3、6、9、18，明细是偶数次，因此最后是“关状态”
             *  4.再看规律，能得到奇数次的，其实都是“完全平方数”
             *  5.由此推断出，只有n中的完全平方数才可以在最后保持“开状态”
             *  
             * 时间复杂度：O(1)
             * 空间复杂度：O(1)
             */

            return (int)Math.Sqrt(n);
        }
    }
}
