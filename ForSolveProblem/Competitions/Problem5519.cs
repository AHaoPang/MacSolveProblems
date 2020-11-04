using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5519 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string ReorderSpaces(string text)
        {
            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var blankCount = text.Count(i => i == ' ');

            if (words.Length != 1)
            {
                var perCount = blankCount / (words.Length - 1);
                var restCount = blankCount % (words.Length - 1);

                var str = new string(Enumerable.Repeat(' ', perCount).ToArray());
                var restStr = new string(Enumerable.Repeat(' ', restCount).ToArray());

                return string.Join(str, words) + restStr;
            }
            else
            {
                var restStr = new string(Enumerable.Repeat(' ', blankCount).ToArray());

                return words[0] + restStr;
            }
        }
    }
}
