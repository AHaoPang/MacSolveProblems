using System;
namespace ForSolveProblem
{
    public class Problem331 : IProblem
    {
        public void RunProblem()
        {
            var temp = IsValidSerialization("9,3,4,#,#,1,#,#,2,#,6,#,#");
            if (temp != true) throw new Exception();

            temp = IsValidSerialization("1,#");
            if (temp != false) throw new Exception();

            temp = IsValidSerialization("9,#,#,1");
            if (temp != false) throw new Exception();
        }

        public bool IsValidSerialization(string preorder)
        {
            if (string.IsNullOrWhiteSpace(preorder))
                return true;

            var strArr = preorder.Split(",", StringSplitOptions.RemoveEmptyEntries);
            return Dfs(strArr) && m_index == strArr.Length;
        }

        private int m_index;

        private bool Dfs(string[] strArr)
        {
            if (strArr.Length <= m_index)
                return true;

            if (strArr[m_index] == "#")
            {
                m_index++;
                return true;
            }

            m_index++;
            if (m_index + 1 >= strArr.Length)
                return false;

            return Dfs(strArr) && Dfs(strArr);
        }
    }
}
