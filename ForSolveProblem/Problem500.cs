using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem500 : IProblem
    {
        public void RunProblem()
        {
            var temp = FindWords(new string[] { "Hello", "Alaska", "Dad", "Peace" });
            
        }

        public string[] FindWords(string[] words)
        {
            /*
             * 判断单词中的字符，是否为同一组
             * 思路：
             *  1.人为对字符做了分组
             *  2.遍历单词中的字符串，判断是否为一组
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            var hashOne = new HashSet<char>() { 'q', 'Q', 'w', 'W', 'e', 'E', 'r', 'R', 't', 'T', 'y', 'Y', 'u', 'U', 'i', 'I', 'o', 'O', 'p', 'P' };
            var hashTwo = new HashSet<char>() { 'a', 'A', 's', 'S', 'd', 'D', 'f', 'F', 'g', 'G', 'h', 'H', 'j', 'J', 'k', 'K', 'l', 'L' };
            var hashThree = new HashSet<char>() { 'z', 'Z', 'x', 'X', 'c', 'C', 'v', 'V', 'b', 'B', 'n', 'N', 'm', 'M' };

            var forReturn = new List<string>(words.Length);
            foreach (var wordItem in words)
            {
                HashSet<char> hashTemp = null;
                for (int i = 0; i < wordItem.Length; i++)
                {
                    if (hashTemp == null)
                    {
                        if (hashOne.Contains(wordItem[i])) hashTemp = hashOne;
                        else if (hashTwo.Contains(wordItem[i])) hashTemp = hashTwo;
                        else hashTemp = hashThree;
                    }

                    if (!hashTemp.Contains(wordItem[i])) break;

                    if (i == wordItem.Length - 1) forReturn.Add(wordItem);
                }
            }

            return forReturn.ToArray();
        }
    }
}
