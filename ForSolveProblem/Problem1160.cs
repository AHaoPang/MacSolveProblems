using System;
namespace ForSolveProblem
{
    public class Problem1160 : IProblem
    {
        public void RunProblem()
        {
            var temp = CountCharacters(new string[]
            {
                "cat",
                "bt",
                "hat",
                "tree"
            }, "atach");
            if (temp != 6) throw new Exception();

            temp = CountCharacters(new string[]
            {
                "hello",
                "world",
                "leetcode"
            }, "welldonehoneyr");
            if (temp != 10) throw new Exception();
        }

        public int CountCharacters(string[] words, string chars)
        {
            var forReturn = 0;

            var total = GetCharCount(chars);
            for (int i = 0; i < words.Length; i++)
                if (IsOK(total, GetCharCount(words[i]))) forReturn += words[i].Length;

            return forReturn;
        }

        private int[] GetCharCount(string s)
        {
            var forReturn = new int[26];

            foreach (var sItem in s)
                forReturn[sItem - 'a']++;

            return forReturn;
        }

        private bool IsOK(int[] total,int[] need)
        {
            for(int i = 0;i < total.Length; i++)
                if (total[i] < need[i]) return false;

            return true;
        }
    }
}
