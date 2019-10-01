using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem423 : IProblem
    {
        public void RunProblem()
        {
            var temp = OriginalDigits("owoztneoer");
            if (temp != "012") throw new Exception();

            temp = OriginalDigits("fviefuro");
            if (temp != "45") throw new Exception();

            temp = OriginalDigits("nnei");
            if (temp != "9") throw new Exception();
        }

        /// <summary>
        /// 数字单词字母统计详情
        /// </summary>
        class NumWordInfo
        {
            public NumWordInfo(int curInteger, IDictionary<char, int> wordComposedCharDic)
            {
                CurInterger = curInteger;
                WordComposedCharDic = wordComposedCharDic;
            }

            /// <summary>
            /// 当前的数字
            /// </summary>
            public int CurInterger { get; set; }

            /// <summary>
            /// 数字的字母表示成分
            /// </summary>
            public IDictionary<char, int> WordComposedCharDic { get; set; }
        }

        public string OriginalDigits(string s)
        {
            /*
             * 从英文中还原数字
             * 思路：
             *  1.数字转英文，有独特的特性
             *      1.1 偶数都有独特的标识，即可以被唯一确定 z-->0 w-->2 u-->4 x-->6 g-->8
             *      1.2 在排除偶数的前提下，其它数字就可以被唯一确定：h-->3 f-->5 s-->7
             *      1.3 在排除以上的各种情况下，最后的数字可以被唯一确定：o-->1 n-->9
             *  2.基于以上的分析结果，我们只需要分析字符串中各个字符的个数，就可以转换为数字了
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var numArray = new int[10];

            var charCountDic = new Dictionary<char, int>();
            foreach (var sItem in s)
            {
                if (!charCountDic.ContainsKey(sItem)) charCountDic[sItem] = 0;
                charCountDic[sItem]++;
            }

            var charDicArray = new Dictionary<char, NumWordInfo>(10)
            {
                {'z',new NumWordInfo(0,new Dictionary<char,int>(){ {'z',1 },{'e',1 },{'r',1 },{'o',1 } }) },
                {'w',new NumWordInfo(2,new Dictionary<char,int>(){ {'t',1 },{'w',1 },{'o',1 } }) },
                {'u',new NumWordInfo(4,new Dictionary<char,int>(){ {'f',1 },{'o',1 },{'u',1 },{'r',1 } }) },
                {'x',new NumWordInfo(6,new Dictionary<char,int>(){ {'s',1 },{'i',1 },{'x',1 } }) },
                {'g',new NumWordInfo(8,new Dictionary<char,int>(){ {'e',1 },{'i',1 },{'g',1 },{'h',1 },{'t',1 } }) },

                {'h',new NumWordInfo(3,new Dictionary<char,int>(){ {'t',1 },{'h',1 },{'r',1 },{'e',2 } }) },
                {'f',new NumWordInfo(5,new Dictionary<char,int>(){ {'f',1 },{'i',1 },{'v',1 },{'e',1 } }) },
                {'s',new NumWordInfo(7,new Dictionary<char,int>(){ {'s',1 },{'e',2 },{'v',1 },{'n',1 } }) },

                {'o',new NumWordInfo(1,new Dictionary<char,int>(){ {'o',1 },{'n',1 },{'e',1 } }) } ,
                {'i',new NumWordInfo(9,new Dictionary<char,int>(){ {'n',2 },{'i',1 },{'e',1 } }) }
            };
            LoopAndSub(charCountDic, charDicArray, numArray);

            var forReturn = new StringBuilder();
            for (int i = 0; i < numArray.Length; i++)
                forReturn.Append(new string(Enumerable.Repeat(i.ToString()[0], numArray[i]).ToArray()));

            return forReturn.ToString();
        }

        /// <summary>
        /// 循环扣减字母统计值
        /// </summary>
        private void LoopAndSub(IDictionary<char, int> charCountDic, IDictionary<char, NumWordInfo> charDicArray, int[] numArray)
        {
            foreach (var charDicItem in charDicArray)
            {
                if (!charCountDic.ContainsKey(charDicItem.Key)) continue;

                var wordCount = charCountDic[charDicItem.Key];
                foreach (var charChildDicItem in charDicItem.Value.WordComposedCharDic)
                {
                    charCountDic[charChildDicItem.Key] -= charChildDicItem.Value * wordCount;
                    if (charCountDic[charChildDicItem.Key] == 0) charCountDic.Remove(charChildDicItem.Key);
                }

                numArray[charDicItem.Value.CurInterger] = wordCount;
            }
        }
    }
}
