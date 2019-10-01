using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem241 : IProblem
    {
        public void RunProblem()
        {
            var temp = DiffWaysToCompute("2*3-4*5");
        }

        private Dictionary<string, IList<int>> memoResult = new Dictionary<string, IList<int>>();

        public IList<int> DiffWaysToCompute(string input)
        {
            /*
             * 思路：
             * 1.各种不同的优先级组合，得到各种不同的结果；
             * 2.可以借助循环，来依次得到所有的组合情况，一个数字+剩下的，二个数字+剩下的，三个数字+剩下的。。。-->目标是得到所有的可能性；
             * 3.借用分治的思想，可以层层借用循环来划分；
             * 4.每个子组合，都会得到一个结果集，然后充分组合两个结果集，得到不同的计算结果；
             * 
             * 优化：
             * 1.划分过程中，是会产生重复计算的，所以可以借助备忘录的方式，来简化计算过程，备忘录的键的话，就使用公式好了；
             * 
             * 时间复杂度：回溯的方法，不加备忘录，O(n^2)，加备忘录，O(n)
             */

            if (memoResult.ContainsKey(input)) return memoResult[input];

            IList<int> forReturn = new List<int>();

            //依次按照符号来划分组合
            for(int i = 0;i < input.Length; i++)
            {
                var curChar = input[i];
                if (curChar != '+' && curChar != '-' && curChar != '*') continue;

                var res1 = DiffWaysToCompute(input.Substring(0, i));
                var res2 = DiffWaysToCompute(input.Substring(i + 1));
                var calcTemp = 0;
                foreach(var res1Item in res1)
                {
                    foreach(var res2Item in res2)
                    {
                        switch (curChar)
                        {
                            case '+':
                                calcTemp = res1Item + res2Item;
                                break;

                            case '-':
                                calcTemp = res1Item - res2Item;
                                break;

                            case '*':
                                calcTemp = res1Item * res2Item;
                                break;
                        }

                        forReturn.Add(calcTemp);
                    }
                }
            }

            //传入的表达式，不包含任何运算符，那么就转换为数字，表示输入，就是结果了
            int intTemp = 0;
            if (!forReturn.Any() && int.TryParse(input, out intTemp))
                forReturn.Add(intTemp);

            memoResult[input] = forReturn;

            return forReturn;
        }
    }
}
