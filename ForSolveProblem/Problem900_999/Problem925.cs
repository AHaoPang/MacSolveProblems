using System;
namespace ForSolveProblem
{
    public class Problem925 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsLongPressedName("vtkgn", "vttkgnn");
        }

        public bool IsLongPressedName(string name, string typed)
        {
            var nIndex = 0;
            var tIndex = 0;
            while (nIndex < name.Length && tIndex < typed.Length)
            {
                var nPos = GetPos(name, nIndex, out int nNEndIndex);
                var tPos = GetPos(typed, tIndex, out int nTEndIndex);

                if (nPos.Item2 != tPos.Item2 || nPos.Item1 > tPos.Item1)
                    return false;

                nIndex = nNEndIndex;
                tIndex = nTEndIndex;
            }

            return nIndex == name.Length && tIndex == typed.Length;
        }

        private Tuple<int, char> GetPos(string s, int startIndex, out int endIndex)
        {
            var firstChar = s[startIndex];
            endIndex = startIndex + 1;
            for (; endIndex < s.Length; endIndex++)
                if (s[endIndex] != firstChar)
                    break;

            return Tuple.Create(endIndex - startIndex, firstChar);
        }
    }
}
