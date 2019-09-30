using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem202 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsHappy(19);
            if (temp != true) throw new Exception();

            temp = IsHappy(14);
            if (temp != false) throw new Exception();

            temp = IsHappy(80);
            if (temp != false) throw new Exception();
        }

        public bool IsHappy(int n)
        {
            /*
             * 判断一个数字是否是快乐数
             * 思路：
             *  1.题目给出的运算规则是：每个位置上的数字平方和，如此往复；
             *  2.那么依据提供的规律发现，所有的数字，都一定会落在 0~243 这个范围
             *  3.提供定义了，结果为1的数，就是快乐数，那么其实就是 0~243 这个范围中的特定数，即 1，10，100，那么可以转换为这3个数的也是快乐数
             *  4.很显然，这个范围是有限的，一定可以找出所有能计算得到快乐数的数字，这个可以视为一种解法
             *  5.但是还可以是另一种解法：就是记录历史数据，若发现进入一个循环，那么显然这个数字就不会是快乐数字了；
             *  6.毕竟数据范围是有限的，那么不断计算下去，就不可能是无限不循环的，那么就一定是无限循环的，那么我们只需要知道它在循环，就说明不是快乐数字了
             * 
             * 规律总结过程：
             *  1.每个位置上的数字范围：0~9
             *  2.那么平方后的数字范围：0~81
             *  3.因此对于1位数，会变到 :0~81
             *  4.对于2位数，会变到：0~162
             *  5.对于3为数，会变到：0~243
             *  6.int 类型的数，最多是 2147483647 也就是10位数，那么会变成：0~810，那么就变成了3位数字
             *  7.综上，任何整数，在做位的平方和以后，都会进入 0~243的范围内
             *  
             * 时间复杂度：O(1)，循环的次数是有限的，即，有上限
             * 空间复杂度：O(1)，不使用可变的额外空间大小
             */

            if (n <= 0) return false;

            HashSet<int> sumHistory = new HashSet<int>();
            while (n != 1)
            {
                if (sumHistory.Contains(n)) return false;
                else sumHistory.Add(n);

                int sumTemp = 0;
                while (n != 0)
                {
                    var singleNum = n % 10;
                    sumTemp += singleNum * singleNum;
                    n /= 10;
                }

                n = sumTemp;
            }

            return true;
        }
    }
}
