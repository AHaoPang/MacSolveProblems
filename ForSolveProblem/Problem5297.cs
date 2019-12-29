using System;
namespace ForSolveProblem
{
    public class Problem5297 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool CanReach(int[] arr, int start)
        {
            return Recursive(arr, start, new bool[arr.Length]);
        }

        private bool Recursive(int[] arr, int curPos, bool[] visited)
        {
            if (arr[curPos] == 0) return true;

            if (visited[curPos]) return false;
            visited[curPos] = true;

            var curValue = arr[curPos];

            var leftIndex = curPos - curValue;
            if (leftIndex >= 0)
            {
                var resultTemp = Recursive(arr, leftIndex, visited);
                if (resultTemp) return true;
            }

            var rightIndex = curPos + curValue;
            if (rightIndex < arr.Length)
            {
                var resultTemp = Recursive(arr, rightIndex, visited);
                if (resultTemp) return true;
            }

            return false;
        }
    }
}
