using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem421 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindMaximumXOR(new int[] { 3, 10, 5, 25, 2, 8 });
            if (temp != 28) throw new Exception();
        }

        public int FindMaximumXOR(int[] nums)
        {
            /*
             * 使用前缀树的方式，来求得数组中，两数的最大异或值
             * 思路：
             *  1.使用输入数组来构造前缀树
             *  2.挨个遍历数组元素，用元素和游走在数的指针做最大组合，即可求得最大异或值
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(1)，数字最多32个位，每个位2种可能性，所以最多 2^32 次方种可能性
             */

            //1.构造前缀树
            Trie trie = new Trie();
            for (int i = 0; i < nums.Length; i++) trie.AddNum(nums[i]);

            //2.挨个遍历数字位
            int forReturn = 0;
            for (int j = 0; j < nums.Length; j++) forReturn = Math.Max(forReturn, GetMaxNum(trie, nums[j]));

            return forReturn;
        }

        private int GetMaxNum(Trie trie, int num)
        {
            int forReturn = 0;
            var trieTemp = trie.Root;

            for (int i = 31; i >= 0; i--)
            {
                var curValue = 1;
                if ((num & (1 << i)) == 0) curValue = 0;

                var reserveValue = 0;
                if (curValue == 0) reserveValue = 1;

                if (trieTemp.ZeroOne[reserveValue] != null)
                {
                    forReturn = forReturn | (1 << i);
                    trieTemp = trieTemp.ZeroOne[reserveValue];
                }
                else
                {
                    trieTemp = trieTemp.ZeroOne[curValue];
                }
            }

            return forReturn;
        }

        public class Trie
        {
            /// <summary>
            /// 定义前缀树的节点
            /// </summary>
            public class TrieNode
            {
                public TrieNode[] ZeroOne = new TrieNode[2] { null, null };
            }

            public TrieNode Root = new TrieNode();

            /// <summary>
            /// 为前缀树添加枝叶
            /// </summary>
            public void AddNum(int num)
            {
                var initRoot = Root;
                for (int i = 31; i >= 0; i--)
                {
                    int posValue = 1;
                    if ((num & (1 << i)) == 0) posValue = 0;

                    if (initRoot.ZeroOne[posValue] == null) initRoot.ZeroOne[posValue] = new TrieNode();

                    initRoot = initRoot.ZeroOne[posValue];
                }
            }
        }

        public int FindMaximumXOR1(int[] nums)
        {
            /*
             * 求解数组中，两数的最大异或值
             * 思路：
             *  1.异或运算满足交换律，所以可以通过结果和一个因子来推断出另一个因子
             *  2.所以，可以假设结果，若不成立，则是相反了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            int forReturn = 0;
            int maskTemp = 0;

            for (int i = 31; i >= 0; i--)
            {
                forReturn = forReturn | (1 << i);
                maskTemp = maskTemp | (1 << i);
                HashSet<int> resultSet = new HashSet<int>();
                bool isExist = false;

                for (int j = 0; j < nums.Length; j++)
                {
                    var maskResult = nums[j] & maskTemp;
                    if (resultSet.Contains(maskResult))
                    {
                        isExist = true;
                        break;
                    }

                    resultSet.Add(forReturn ^ maskResult);
                }

                if (!isExist) forReturn = forReturn ^ (1 << i);
            }

            return forReturn;
        }
    }
}
