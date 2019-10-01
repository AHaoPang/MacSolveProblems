using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem299 : IProblem
    {
        public void RunProblem()
        {
            var temp = GetHint("1122", "2211");
            if (temp != "0A4B") throw new Exception();

            temp = GetHint("1807", "7810");
            if (temp != "1A3B") throw new Exception();

            temp = GetHint("1123", "0111");
            if (temp != "1A1B") throw new Exception();
        }

        public string GetHint(string secret, string guess)
        {
            /*
             * 猜数字游戏
             * 思路：
             *  1.我告诉你有几位数，且每一位都是0~9的数字
             *  2.你来告诉我猜测结果
             *  3.我在告诉你，哪些位置上的数字是对的，哪些数字是存在的但是位置不对
             *  
             *  4.依次遍历秘密数字和猜测数字的每一位
             *  5.若相同，那么就记录“bull”
             *  6.若不同，则分别放在秘密数字集合字典，与猜测数字集合里
             *  
             * 时间复杂度：O(n) ，遍历数字串2次
             * 空间复杂度：O(n) ，用额外的空间记录可能性集合
             */

            int bulls = 0;
            int cows = 0;
            Dictionary<char, int> secretChar = new Dictionary<char, int>();
            List<char> guessChar = new List<char>();
            for(int i = 0;i < secret.Length; i++)
            {
                if(secret[i] == guess[i])
                {
                    bulls++;
                    continue;
                }

                if (!secretChar.ContainsKey(secret[i])) secretChar[secret[i]] = 0;

                secretChar[secret[i]]++;
                guessChar.Add(guess[i]);
            }

            foreach(var guessCharItem in guessChar)
            {
                if(secretChar.ContainsKey(guessCharItem) && secretChar[guessCharItem] > 0)
                {
                    cows++;
                    secretChar[guessCharItem]--;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}
