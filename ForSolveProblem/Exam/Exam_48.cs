using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Exam_48 : IProblem
    {
        public void RunProblem()
        {
            var temp = LengthOfLongestSubstring("abcabcbb");
            if (temp != 3) throw new Exception();

            temp = LengthOfLongestSubstring("bbbbb");
            if (temp != 1) throw new Exception();

            temp = LengthOfLongestSubstring("pwwkew");
            if (temp != 3) throw new Exception();
        }

        public int LengthOfLongestSubstring(string s)
        {
            var dic = new Dictionary<char, int>();

            var res = 0;
            var l = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (dic.ContainsKey(c) && dic[c] >= l)
                    l = dic[c] + 1;

                res = Math.Max(res, i - l + 1);
                dic[c] = i;
            }

            return res;
        }
    }
}
