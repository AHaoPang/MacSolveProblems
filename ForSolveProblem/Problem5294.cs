using System;
using System.Collections.Generic;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem5294 : IProblem
    {
        public void RunProblem()
        {
            var status = new int[] { 1, 0, 1, 0 };
            var candies = new int[] { 7, 5, 4, 100 };
            var keys = new int[][]
            {
                new int[]{},
                new int[]{},
                new int[]{1},
                new int[]{}
            };
            var containedBoxes = new int[][]
            {
                new int[]{1,2},
                new int[]{3},
                new int[]{},
                new int[]{},
            };
            var initialBoxes = new int[] { 0 };

            var temp = MaxCandies(status, candies, keys, containedBoxes, initialBoxes);
        }

        public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
        {
            totalcandies = 0;
            hasBox = new HashSet<int>();
            visited = new HashSet<int>();

            foreach (var initBoxId in initialBoxes)
                OperaBox(initBoxId, status, candies, keys, containedBoxes);

            return totalcandies;
        }

        private int totalcandies;
        private HashSet<int> hasBox;
        private HashSet<int> visited;

        private void OperaBox(int boxId, int[] status, int[] candies, int[][] keys, int[][] containedBoxes)
        {
            if (status[boxId] == 0)
            {
                hasBox.Add(boxId);
                return;
            }

            hasBox.Remove(boxId);

            if (visited.Contains(boxId)) return;
            visited.Add(boxId);

            totalcandies += candies[boxId];

            foreach (var keyItem in keys[boxId])
                status[keyItem] = 1;

            foreach (var boxTemp in containedBoxes[boxId])
                hasBox.Add(boxTemp);

            foreach (var boxIdItem in hasBox.ToList())
                OperaBox(boxIdItem, status, candies, keys, containedBoxes);
        }
    }
}
