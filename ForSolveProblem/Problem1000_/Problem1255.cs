using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1255 : IProblem
    {
        public void RunProblem()
        {
            var temp = MaxScoreWords(new string[] { "dog", "cat", "dad", "good" }, new char[] { 'a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o' }, new int[] { 1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            if (temp != 23) throw new Exception();

            temp = MaxScoreWords(new string[] { "xxxz", "ax", "bx", "cx" }, new char[] { 'z', 'a', 'b', 'c', 'x', 'x', 'x' }, new int[] { 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 10 });
            if (temp != 27) throw new Exception();

            temp = MaxScoreWords(new string[] { "leetcode" }, new char[] { 'l', 'e', 't', 'c', 'o', 'd' }, new int[] { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 });
            if (temp != 0) throw new Exception();
        }

        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            /*
             * 问题:得分最高的单词集合
             * 思路:
             *  1.从数据的规模来看不是很大,考虑使用回溯的方法,再配合上一点简单的剪枝即可
             *  2.给定的字母,统计一下各个字符的个数是多少
             *  3.每个单词都有两种选择
             *      3.1 不加入已有单词集合,不为最后的总分做共享
             *      3.2 如果剩余字符足够拼出这个单词的话,那么加入已有单词的集合,为最后的总分做共享
             * 
             * 关键点:
             * 
             * 时间复杂度:O(2^14)
             * 空间复杂度:O(1)
             */

            var charCountArray = new int[26];
            foreach (var letterItem in letters)
                charCountArray[letterItem - 'a']++;

            m_maxScore = 0;
            BackTrace(words, 0, charCountArray, new int[26], score);

            return m_maxScore;
        }

        private int m_maxScore;

        private void BackTrace(string[] words, int level, int[] charCountArray, int[] increaseCharCountArray, int[] score)
        {
            if (level == words.Length)
            {
                var scoreTemp = CountScore(increaseCharCountArray, score);
                m_maxScore = Math.Max(scoreTemp, m_maxScore);
                return;
            }

            BackTrace(words, level + 1, charCountArray, increaseCharCountArray, score);

            if (JudgeCharCount(charCountArray, increaseCharCountArray, words[level]))
            {
                UpdateCharCount(increaseCharCountArray, words[level], true);
                BackTrace(words, level + 1, charCountArray, increaseCharCountArray, score);
                UpdateCharCount(increaseCharCountArray, words[level], false);
            }
        }

        private int[] GetCharCountArray(string word)
        {
            var charCountTemp = new int[26];
            foreach (var charItem in word)
                charCountTemp[charItem - 'a']++;

            return charCountTemp;
        }

        private int CountScore(int[] increaseCharCountArray, int[] score)
        {
            var forReturn = 0;

            for (int i = 0; i < increaseCharCountArray.Length; i++)
                forReturn += increaseCharCountArray[i] * score[i];

            return forReturn;
        }

        private bool JudgeCharCount(int[] charCountArray, int[] increaseCharCountArray, string word)
        {
            var charCountTemp = GetCharCountArray(word);

            for (int i = 0; i < charCountTemp.Length; i++)
                if (increaseCharCountArray[i] + charCountTemp[i] > charCountArray[i]) return false;

            return true;
        }

        private void UpdateCharCount(int[] increaseCharCountArray, string word, bool isAdd)
        {
            var charCountTemp = GetCharCountArray(word);

            for (int i = 0; i < increaseCharCountArray.Length; i++)
            {
                if (isAdd) increaseCharCountArray[i] += charCountTemp[i];
                else increaseCharCountArray[i] -= charCountTemp[i];
            }
        }
    }
}
