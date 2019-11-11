using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem1042 : IProblem
    {
        public void RunProblem()
        {
            int N = 3;
            int[][] paths = new int[][]
            {
                new int[]{1,2},
                new int[]{2,3},
                new int[]{3,1},
            };

            var temp = GardenNoAdj(N, paths);
            if (!IsEqual(temp, new int[] { 1, 2, 3 })) throw new Exception();

            N = 4;
            paths = new int[][]
            {
                new int[]{1,2},
                new int[]{3,4},
            };

            temp = GardenNoAdj(N, paths);
            if (!IsEqual(temp, new int[] { 1, 2, 1, 2 })) throw new Exception();

            N = 4;
            paths = new int[][]
            {
                new int[]{1,2},
                new int[]{2,3},
                new int[]{3,4},
                new int[]{4,1},
                new int[]{1,3},
                new int[]{2,4},
            };

            temp = GardenNoAdj(N, paths);
            if (!IsEqual(temp, new int[] { 1, 2, 3, 4 })) throw new Exception();
        }

        private bool IsEqual(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;

            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != arr2[i]) return false;

            return true;
        }

        public int[] GardenNoAdj(int N, int[][] paths)
        {
            /*
             * 为花园选择颜色，相连的花园颜色不同
             * 思路：
             *  1.按照一个顺序，依次赋予颜色-->就按照花园编号的顺序好了
             *  2.建立花园的联通关系，便于在颜色选择时，估计到其他花园的颜色
             *  
             * 时间复杂度：O(n)
             * 空间复杂度：O(n)
             */

            //建立花园直接的连接关系
            Dictionary<int, List<int>> gardenToGardens = new Dictionary<int, List<int>>();
            for (int r = 0; r < paths.GetLength(0); r++)
            {
                for (int c = 0; c < paths[r].Length - 1; c++)
                {
                    if (!gardenToGardens.ContainsKey(paths[r][c]))
                        gardenToGardens[paths[r][c]] = new List<int>();

                    gardenToGardens[paths[r][c]].Add(paths[r][c + 1]);

                    if (!gardenToGardens.ContainsKey(paths[r][c + 1]))
                        gardenToGardens[paths[r][c + 1]] = new List<int>();

                    gardenToGardens[paths[r][c + 1]].Add(paths[r][c]);
                }
            }

            //依次为花园选择颜色
            int[] forReturn = new int[N];
            for (int i = 0; i < N; i++)
            {
                //收集关联花园使用的颜色
                HashSet<int> alreadyUsedColor = new HashSet<int>();
                if (gardenToGardens.ContainsKey(i + 1))
                    foreach (var connectedGarden in gardenToGardens[i + 1])
                        alreadyUsedColor.Add(forReturn[connectedGarden - 1]);

                //开始在自己的花园上使用颜色
                for (int color = 1; color <= 4; color++)
                {
                    if (alreadyUsedColor.Contains(color)) continue;

                    forReturn[i] = color;
                    break;
                }
            }

            return forReturn;
        }
    }
}
