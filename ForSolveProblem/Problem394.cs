using System;
using System.Text;

namespace ForSolveProblem
{
    public class Problem394 : IProblem
    {
        public void RunProblem()
        {
            var temp = DecodeString("3[a]2[bc]");
            if (temp != "aaabcbc") throw new Exception();

            temp = DecodeString("3[a2[c]]");
            if (temp != "accaccacc") throw new Exception();

            temp = DecodeString("2[abc]3[cd]ef");
            if (temp != "abcabccdcdcdef") throw new Exception();
        }

        public string DecodeString(string s)
        {
            return Dfs(s, 0).Item2;
        }

        private (int, string) Dfs(string s, int curPos)
        {
            var forReturn = new StringBuilder();
            var repeatTimes = 0;

            var i = curPos;
            for (; i < s.Length; i++)
            {
                var curChar = s[i];
                switch (curChar)
                {
                    case '[':
                        var tempStr = Dfs(s, i + 1);
                        while (repeatTimes > 0)
                        {
                            forReturn.Append(tempStr.Item2);
                            repeatTimes--;
                        }
                        i = tempStr.Item1;
                        break;

                    case ']':
                        return (i, forReturn.ToString());

                    case '0':case '1':case '2':case '3':case '4':case '5':
                    case '6':case '7':case '8':case '9':
                        while (i < s.Length)
                        {
                            if (int.TryParse(s[i].ToString(), out int parseInt))
                            {
                                repeatTimes = repeatTimes * 10 + parseInt;
                                i++;
                            }
                            else
                            {
                                i--;
                                break;
                            }
                        }
                        break;

                    default:
                        forReturn.Append(curChar);
                        break;
                }
            }

            return (i, forReturn.ToString());
        }
    }
}
