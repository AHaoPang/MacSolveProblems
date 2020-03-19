using System;
namespace ForSolveProblem
{
    public class Problem680 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool ValidPalindrome(string s)
        {
            return Recursive(s, 0, s.Length - 1, 1);
        }

        private bool Recursive(string s, int start, int end, int count)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    if (count == 0) return false;

                    return Recursive(s, start + 1, end, count - 1) || Recursive(s, start, end - 1, count - 1);
                }

                start++;
                end--;
            }

            return true;
        }
    }
}
