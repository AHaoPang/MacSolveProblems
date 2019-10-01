using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem050 : IProblem
    {
        public void RunProblem()
        {
            int i = -2147483648;

            int j = i * -1;

            var temp = MyPow(1.00000, -2147483648);
        }

        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;

            if (n < 0 && n * -1 < 0) return MyPow(x * x, n / 2);
            if (n < 0) return 1.0 / MyPow(x, -1 * n);

            if (n % 2 == 1)
                return x * MyPow(x * x, n / 2);
            else
                return MyPow(x * x, n / 2);
        }

        private double MyPow(double x,long n)
        {
            if (n == 0) return 1;

            if (n < 0 && n * -1 < 0) return MyPow(x * x, n / 2);
            if (n < 0) return 1.0 / MyPow(x, -1 * n);

            if (n % 2 == 1)
                return x * MyPow(x * x, n / 2);
            else
                return MyPow(x * x, n / 2);
        }

        public double Way1(double x,int n)
        {
            return Math.Pow(x, n);
        }

        public double Way2(double x,int n)
        {
            if (n == 0) return 1;

            var isNegative = n < 0;
            double increValue = 1;
            int increCount = n;

            if (isNegative) increCount *= -1;
            for (int i = 1; i <= increCount; i++)
                increValue *= x;

            return isNegative ? 1.0 / increValue : increValue;
        }

        public double Way3(double x,int n)
        {
            var isNegative = n < 0;

            var increCount = n;
            if (isNegative) increCount *= -1;

            if (increCount == 0) return 1;

            double forReturn = 0;
            if (increCount % 2 == 0)
                forReturn = MyPow(x * x, increCount / 2);
            else
                forReturn = MyPow(x * x, increCount / 2) * x;

            return isNegative ? 1.0 / forReturn : forReturn;
        }
    }
}
