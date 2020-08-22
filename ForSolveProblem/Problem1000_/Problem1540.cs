using System;
namespace ForSolveProblem
{
    public class Problem1540 : IProblem
    {
        public void RunProblem()
        {
            var temp = CanConvertString("input", "ouput", 9);
        }

        public bool CanConvertString(string s, string t, int k)
        {
            if (s.Length != t.Length) return false;

            var arr = new int[26];
            for (var i = 0; i < s.Length; i++)
            {
                var sub = (t[i] - s[i] + 26) % 26;
                arr[sub]++;
            }

            var c = k / 26;
            var m = k % 26;

            for (var i = 1; i < arr.Length; i++)
            {
                if (i <= m)
                {
                    if (arr[i] > c + 1)
                        return false;
                }
                else
                {
                    if (arr[i] > c)
                        return false;
                }
            }

            return true;
        }
    }
}
