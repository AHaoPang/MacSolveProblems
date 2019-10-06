using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem638 : IProblem
    {
        public void RunProblem()
        {
            var temp = ShoppingOffers(new List<int>() { 2, 5 }, new List<IList<int>>() { new List<int>() { 3, 0, 5 }, new List<int>() { 1, 2, 10 } }, new List<int>() { 3, 2 });
            if (temp != 14) throw new Exception();

            temp = ShoppingOffers(new List<int>() { 2, 3, 4 }, new List<IList<int>> { new List<int> { 1, 1, 0, 4 }, new List<int> { 2, 2, 1, 9 } }, new List<int> { 1, 2, 1 });
            if (temp != 11) throw new Exception();

            temp = ShoppingOffers(new List<int>() { 9, 9 }, new List<IList<int>> { new List<int> { 1, 1, 1 } }, new List<int> { 6, 6 });
            if (temp != 6) throw new Exception();
        }

        public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            /*
             * 题目概述：以最少的钱购买到自己所需的产品
             * 
             * 思路：
             *  1. 产品分为单买和打包买两种方式
             *  2. 事实上，单买也可以看作是打包买，只是买的商品只有一件，且为原价而已
             *  3. 把单买和打包买都看成打包买以后，就可以把每种打包看成是不同阶段的选择，我可以选择买0个，也可以选择买6 个
             *  4. 以上其实就是一个回溯的过程了
             *
             * 关键点：
             *  1. 对于单个打包，用户可以选择买 0~6 件
             *  2. 可以做必要的剪枝，比如说，打包买的数量已经超过预期时，可以及时中止此种选择
             *  3. 回溯方法返回的是，剩余产品需要花费价格的最小值，若为-1 则说明无法做到
             *
             * 时间复杂度： O(6^106)
             * 空间复杂度： O(6^106)
             */

            var thingsCount = price.Count;

            //将物品本身也转换为礼包
            for (int i = 0; i < thingsCount; i++)
            {
                var newList = Enumerable.Repeat(0, thingsCount + 1).ToList();
                newList[i] = 1;
                newList[thingsCount] = price[i];
                special.Add(newList);
            }

            return BackTrace(special, 0, needs, new Dictionary<string, int>());
        }

        private int BackTrace(IList<IList<int>> special, int curSpecial, IList<int> needs, IDictionary<string, int> dic)
        {
            if (special.Count == curSpecial)
            {
                var sumTemp = needs.Sum();
                return sumTemp == 0 ? 0 : -1;
            }

            var keyTemp = $"{curSpecial}_{string.Join(',', needs)}";
            if (dic.ContainsKey(keyTemp)) return dic[keyTemp];

            var forReturn = new List<int>();
            var curSpecialType = special[curSpecial];
            var prices = curSpecialType.Last();
            for (int i = 0; i <= 6; i++)
            {
                var isOK = ChangeNeeds(needs, curSpecialType, i);

                if (isOK)
                {
                    var resultTemp = BackTrace(special, curSpecial + 1, needs, dic);
                    if (resultTemp != -1) forReturn.Add(resultTemp + i * prices);
                }

                ChangeNeeds(needs, curSpecialType, -i);

                if (!isOK) break;
            }

            var forReturnValue = forReturn.Count == 0 ? -1 : forReturn.Min();
            dic[keyTemp] = forReturnValue;
            return forReturnValue;
        }

        private bool ChangeNeeds(IList<int> needs, IList<int> special, int count)
        {
            var forReturn = true;

            for (int i = 0; i < needs.Count; i++)
            {
                needs[i] -= count * special[i];
                if (needs[i] < 0) forReturn = false;
            }

            return forReturn;
        }

        public int ShoppingOffers1(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            /*
             * 题目概述：依据商品单价，以及礼包优惠的价格，以最少的钱，买到自己期望数量的商品，同时不会被销售
             * 
             * 思路：
             *  1. 多维度动态规划的问题
             *  2. 商品本身也是可以看做为礼包的，只是价格没有那么实惠罢了
             *  3. 需要获知的信息有：多少种商品、多少种礼包
             *  4. 做迭代式的循环
             *
             * 关键点：
             *
             * 时间复杂度：O(abcdefnm) abcdef 代表 6 种商品，n 代表物品的数量，m 代表礼包的数量
             * 空间复杂度：O(abcdefnm)
             */

            var thingsCount = price.Count;
            var speCount = special.Count;

            //将物品本身也转换为礼包
            for (int i = 0; i < thingsCount; i++)
            {
                var newList = Enumerable.Repeat(0, thingsCount + 1).ToList();
                newList[i] = 1;
                newList[thingsCount] = price[i];
                special.Add(newList);
            }

            //开始进入层次循环中
            var dp = new int[thingsCount + speCount + 1, 7, 7, 7, 7, 7, 7];
            return Recursive(dp, special, needs);
        }

        private int Recursive(int[,,,,,,] dp, IList<IList<int>> special, IList<int> needs)
        {
            var aCount = needs.Count > 0 ? needs[0] : 0;
            var bCount = needs.Count > 1 ? needs[1] : 0;
            var cCount = needs.Count > 2 ? needs[2] : 0;
            var dCount = needs.Count > 3 ? needs[3] : 0;
            var eCount = needs.Count > 4 ? needs[4] : 0;
            var fCount = needs.Count > 5 ? needs[5] : 0;

            var forReturn = new List<int>();
            for (int i = 1; i <= special.Count; i++)
            {
                var oneGroup = special[i - 1];

                var aAdd = oneGroup.Count - 1 > 0 ? oneGroup[0] : 0;
                var bAdd = oneGroup.Count - 1 > 1 ? oneGroup[1] : 0;
                var cAdd = oneGroup.Count - 1 > 2 ? oneGroup[2] : 0;
                var dAdd = oneGroup.Count - 1 > 3 ? oneGroup[3] : 0;
                var eAdd = oneGroup.Count - 1 > 4 ? oneGroup[4] : 0;
                var fAdd = oneGroup.Count - 1 > 5 ? oneGroup[5] : 0;

                var price = oneGroup.Last();

                for (int a = 0; a <= aCount; a++)
                {
                    for (int b = 0; b <= bCount; b++)
                    {
                        for (int c = 0; c <= cCount; c++)
                        {
                            for (int d = 0; d <= dCount; d++)
                            {
                                for (int e = 0; e <= eCount; e++)
                                {
                                    for (int f = 0; f <= fCount; f++)
                                    {
                                        dp[i, a, b, c, d, e, f] += dp[i - 1, a, b, c, d, e, f];

                                        var aSub = a + aAdd;
                                        var bSub = b + bAdd;
                                        var cSub = c + cAdd;
                                        var dSub = d + dAdd;
                                        var eSub = e + eAdd;
                                        var fSub = f + fAdd;
                                        if (aSub <= aCount && bSub <= bCount && cSub <= cCount && dSub <= dCount && eSub <= eCount && fSub <= fCount)
                                            dp[i, aSub, bSub, cSub, dSub, eSub, fSub] += price;
                                    }
                                }
                            }
                        }
                    }
                }

                //从末尾的维度中，选择最合适的价格
                forReturn.Add(dp[i, aCount, bCount, cCount, dCount, eCount, fCount]);
            }

            return forReturn.First();
        }
    }
}
