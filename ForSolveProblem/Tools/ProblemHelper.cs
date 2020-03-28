using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    /// <summary>
    /// 解题辅助类的工具
    /// </summary>
    public static class ProblemHelper
    {
        #region Assert
        /// <summary>
        /// 断言两个类型是相等的
        /// </summary>
        public static void AEqual<T>(T t1, T t2)
        {
            if (!t1.Equals(t2))
                throw new Exception();
        }
        #endregion

        #region Gcd
        public static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
        #endregion

        #region Enumerable Equal
        /// <summary>
        /// 判断两个数组是相等的（内部的值一致）
        /// </summary>
        public static bool ArrayIsEqual<T>(T[] arr1, T[] arr2, bool needOrder = true)
        {
            if (arr1.Length != arr2.Length) return false;

            var arr1Temp = needOrder ? arr1.OrderBy(i => i).ToArray() : arr1;
            var arr2Temp = needOrder ? arr2.OrderBy(i => i).ToArray() : arr2;

            for (int i = 0; i < arr1Temp.Length; i++)
                if (!arr1Temp[i].Equals(arr2Temp[i])) return false;

            return true;
        }

        /// <summary>
        /// 判断两个数组是相等的
        /// </summary>
        public static bool ArrayEqual<T>(IEnumerable<T> a1, IEnumerable<T> a2, bool needOrder = true)
        {
            var orderA1 = needOrder ? a1.OrderBy(i => i) : a1;
            var orderA2 = needOrder ? a2.OrderBy(i => i) : a2;

            return orderA1.SequenceEqual(orderA2);
        }
        #endregion

        #region KMP
        /// <summary>
        /// 为字符串构造 next 数组
        /// 此数组是配合 KMP 算法来使用的,数组的索引和值,都表示字符串中对应字符的数组下标
        /// 使用了 DP 的算法原理,即后面的值是基于前面的值计算得到的
        /// </summary>
        public static int[] GetKMPNextArray(string s)
        {
            var forReturn = Enumerable.Repeat(-1, s.Length).ToArray();
            for (var i = 1; i < s.Length; i++)
            {
                var j = forReturn[i - 1];
                while (j >= 0 && s[j + 1] != s[i])
                    j = forReturn[j];

                if (s[j + 1] == s[i])
                    forReturn[i] = j + 1;
            }

            return forReturn;
        }
        #endregion

        #region MadeTree
        /// <summary>
        /// 将给定的数组转化为二叉树结构
        /// </summary>
        public static TreeNode MadeTree(int?[] numArray, int index)
        {
            var curIndex = index - 1;
            if (curIndex >= numArray.Length || !numArray[curIndex].HasValue)
                return null;

            return new TreeNode(numArray[curIndex].Value)
            {
                left = MadeTree(numArray, index * 2),
                right = MadeTree(numArray, index * 2 + 1)
            };
        }

        /// <summary>
        /// 将给定的数组转化为二叉树结构
        /// </summary>
        public static TreeNode MadeTreeV2(int?[] numArray)
        {
            if (!numArray.Any()) return null;

            var startIndex = 0;
            var root = new TreeNode(numArray[startIndex++].Value);

            var queueTemp = new Queue<TreeNode>();
            queueTemp.Enqueue(root);
            while (startIndex < numArray.Length)
            {
                var curNode = queueTemp.Dequeue();

                int? leftNode = numArray[startIndex++];
                if (leftNode.HasValue)
                {
                    curNode.left = new TreeNode(leftNode.Value);
                    queueTemp.Enqueue(curNode.left);
                }

                if (startIndex >= numArray.Length) break;

                int? rightNode = numArray[startIndex++];
                if (rightNode.HasValue)
                {
                    curNode.right = new TreeNode(rightNode.Value);
                    queueTemp.Enqueue(curNode.right);
                }
            }

            return root;
        }
        #endregion

        #region Prime

        /// <summary>
        /// 得到 2 ~ maxNum 间的所有素数
        /// </summary>
        public static ISet<int> GetPrimeSet(int maxNum)
        {
            /*
             * 过滤素数的思路说明:
             * 1.素数,只能被表示为 1 和自己的乘积;
             * 2.一旦一个数字确定为素数,那么它的所有倍数,一定为合数;
             * 3.循环的终止条件时 根号 maxNum
             * 4.循环过程中,发现的第一个不为 1 的数字,必然是素数
             * 5. 3 和 4 都可以通过数学的方法来证明
             *      先说 3,若数字为合数,则必然由比他小的数字构成,那么倍数设置的时候,它必然被设置为 1 了;所以第一个数字只能是素数;
             *      再说 4,最大数被表示为 2 个数字的乘积,若其为合数,那么其中一个数必然小于根号值,另一个数大于根号值,小于根号值的素数被找到了,它就一定会被标记了
             *
             * 从中体会"数学的证明过程"
             */

            var numArray = new int[maxNum + 1];

            for (var i = 2; i * i <= maxNum; i++)
            {
                if (numArray[i] == 1) continue;

                for (var j = i * 2; j <= maxNum; j += i)
                    numArray[j] = 1;
            }

            var forReturn = new HashSet<int>();
            for (var i = 2; i < numArray.Length; i++)
                if (numArray[i] == 0)
                    forReturn.Add(i);

            return forReturn;
        }

        #endregion
    }
}
