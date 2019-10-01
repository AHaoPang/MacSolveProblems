using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem372 : IProblem
    {
        public void RunProblem()
        {
            var temp = SuperPow(2, new int[] { 3 });
            if (temp != 8) throw new Exception();

            temp = SuperPow(2, new int[] { 1, 0 });
            if (temp != 1024) throw new Exception();
        }

        private static int m_num = 1337;

        public int SuperPow(int a, int[] b)
        {
            /*
             * 求得一个数字的大数次方与一个数取余后的结果，此数为1337
             * 思路：
             *  1.本题是对次方与取余运算规则的一次演绎
             */

            var forReturn = 1;
            a = a % m_num;

            for (int i = 0; i < b.Length; i++)
            {
                forReturn = NPower(forReturn, 10) % m_num;
                var newNum = NPower(a, b[i]) % m_num;

                forReturn = forReturn * newNum % m_num;
            }

            return forReturn;
        }

        private int NPower(int x, int y)
        {
            var forReturn = 1;

            while (y > 0)
            {
                if ((y & 1) == 1)
                {
                    forReturn = forReturn * x % m_num;
                    y--;
                }

                x = x * x % m_num;
                y >>= 1;
            }

            return forReturn;
        }
    }
}
