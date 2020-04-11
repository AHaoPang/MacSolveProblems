using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem022 : IProblem
    {
        public void RunProblem()
        {
            var temp = GenerateParenthesis(3);
        }

        public IList<string> GenerateParenthesis(int n)
        {
            m_visited = new Dictionary<int, List<string>>();
            m_visited[0] = new List<string>() { "" };
            return Recursive(n, "", "");
        }

        private Dictionary<int, List<string>> m_visited;

        private List<string> Recursive(int n, string l, string r)
        {
            if (m_visited.ContainsKey(n))
                return m_visited[n].Select(i => $"{l}{i}{r}").ToList();

            var res = new List<string>();
            for (var i = 1; i <= n; i++)
            {
                var lefts = Recursive(i - 1, "(", ")");
                var rights = Recursive(n - i, "", "");
                res.AddRange(lefts.SelectMany(le => rights.Select(ri => $"{l}{le}{ri}{r}")));
            }

            m_visited[n] = res.Select(i => i).ToList();
            return res;
        }

        public IList<string> GenerateParenthesis1(int n)
        {
            IList<string> forReturn = new List<string>();
            Gen(forReturn, n, 0, 0, "");
            return forReturn;
        }

        private void Gen(IList<string> forReturn, int total, int left, int rigth, string str)
        {
            if (left == total && rigth == total)
            {
                forReturn.Add(str);
                return;
            }

            if (left < total)
                Gen(forReturn, total, left + 1, rigth, str + "(");

            if (rigth < left)
                Gen(forReturn, total, left, rigth + 1, str + ")");
        }
    }
}
