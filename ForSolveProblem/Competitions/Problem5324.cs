using System;
using System.Collections.Generic;

namespace ForSolveProblem
{
    public class Problem5324 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public class Cashier
        {
            private int m_n;
            private int m_discount;

            private Dictionary<int, int> m_productPriceDic;
            private int m_innerCount;

            public Cashier(int n, int discount, int[] products, int[] prices)
            {
                m_n = n;
                m_discount = discount;

                m_productPriceDic = new Dictionary<int, int>();
                for (var i = 0; i < products.Length; i++)
                    m_productPriceDic[products[i]] = prices[i];

                m_innerCount = 0;
            }

            public double GetBill(int[] product, int[] amount)
            {
                m_innerCount++;

                long sum = 0;
                for (var i = 0; i < product.Length; i++)
                    sum += m_productPriceDic[product[i]] * amount[i];

                var forReturn = sum * 1.0;

                if (m_innerCount % m_n == 0)
                    forReturn = sum - sum * m_discount / 100.0;

                return forReturn;
            }
        }
    }
}
