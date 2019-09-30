using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSolveProblem
{
    public class Problem554 : IProblem
    {
        public void RunProblem()
        {
            var temp = LeastBricks(new List<IList<int>>()
            {
                new List<int>(){1,2,2,1},
                new List<int>(){3,1,2},
                new List<int>(){1,3,2},
                new List<int>(){2,4},
                new List<int>(){3,1,2},
                new List<int>(){1,3,1,1},
            });
            if (temp != 2) throw new Exception();
        }

        public int LeastBricks(IList<IList<int>> wall)
        {
            /*
             * 自顶向下画条线，要求穿过的砖块儿数最少
             * 思路：
             *  0.可以将问题转化为，穿过最多的缝隙
             *  1.遍历每一行砖块，记录缝隙的横向位置
             *  2.拥有最多相同的缝隙位置时，穿过砖块儿的数量就是最少的
             *  
             * 时间复杂度：O(n - m)，n表示砖块的数量，m表示行数，每行最后一块儿砖是不遍历的
             * 空间复杂度：O(n - m)，n - m块儿砖，最多可以构造出 n - m个横向位置
             */

            var posCountDic = new Dictionary<int, int>();
            for (int i = 0; i < wall.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < wall[i].Count - 1; j++)
                {
                    sum += wall[i][j];

                    if (!posCountDic.ContainsKey(sum)) posCountDic[sum] = 0;
                    posCountDic[sum]++;
                }
            }

            int maxPos = int.MinValue;
            foreach (var dicItem in posCountDic) maxPos = Math.Max(dicItem.Value, maxPos);

            return maxPos == int.MinValue ? wall.Count : wall.Count - maxPos;
        }
    }
}
