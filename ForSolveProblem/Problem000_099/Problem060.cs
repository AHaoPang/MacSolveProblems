using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem060 : IProblem
    {
        public void RunProblem()
        {
            var temp = GetPermutation(4, 9);
            if (temp != "2314") throw new Exception();

            temp = GetPermutation(3, 3);
            if (temp != "213") throw new Exception();
        }

        public string GetPermutation(int n, int k)
        {
            /*
             * 获取n!中的第k个排列结果
             * 问题梳理：
             *  1. 一个集合，有N个数,从1~n
             *  2.全排列的话，一共有n!种情况
             *  3.为了有序，就按照自小到大的顺序来标识
             *  4.如果要遍历得到所有的排列，那么回溯法是相当不错的！它的按序遍历结果和数字的增长过程是一致的
             *  5.如果只是依次遍历和统计的话，那么时间复杂度很高，是O(n!)
             *  6.其实，把回溯看成是树，每个结果其实是一个叶子节点，那一个分支下有多少叶子节点是确定的，很显然是没有必要深入去数数的，如此一来实现一种剪枝的效果
             *  7.其实，从数学的意义上来讲，也是有规律可循的，基本上及时依次计算每一位的过程
             *  8.以n = 4 k = 9为例 k = k - 1
             *      8.1 第一个位是 8/(3!) = 1，即偏移量为1的数 = 2, k = 8 % 6 = 2
             *      8.2 第二个位是 2/2! = 1，即偏移量为1的数 = 3 ,k = 2 % 2 = 0
             *      8.3 第三个位是 0/1! = 0，即偏移量为0的数 = 1, k = 0%1 = 0
             *      8.4 第四个位是 0/0! = 0, 即偏移量为0的数 = 4
             */

            //1.得到一个整数数组，里面是n个元素

            //2.开始循环得到每个位置上的数字

            //3.每次移动，都意味着局部的整体移动-->最好使用列表~

            List<int> numArray = new List<int>(n);
            for (int i = 1; i <= n; i++) numArray.Add(i);

            int kTemp = k - 1;
            int nTemp = n - 1;
            StringBuilder forReturn = new StringBuilder();
            for (int j = 1; j <= n; j++)
            {
                var factorTemp = Factor(nTemp);

                int posTemp = kTemp / factorTemp;

                forReturn.Append($"{numArray[posTemp]}");
                numArray.RemoveAt(posTemp);

                kTemp = kTemp % factorTemp;
                nTemp--;
            }

            return forReturn.ToString();
        }

        private int Factor(int x)
        {
            int forReturn = 1;

            while (x >= 1)
            {
                forReturn *= x;
                x--;
            }

            return forReturn;
        }
    }
}
