using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem874 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int RobotSim(int[] commands, int[][] obstacles)
        {
            var posDic = obstacles.GroupBy(i => i[0], j => j[1]).ToDictionary(i => i.Key, j => j.ToHashSet());
            var arr = new int[][] { new[] { -1, 0 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { 0, 1 } };
            Func<int, int, int[]> GetPos = (curPos, com) =>
              {
                  if (com == -1)
                      curPos--;
                  else
                      curPos++;

                  if (curPos == 4)
                      curPos = 0;
                  else if (curPos < 0)
                      curPos = 3;

                  return arr[curPos];
              };

            var arrIndex = 0;
            var posArray = arr[arrIndex];
            var count = 0;
            var curPoint = new[] { 0, 0 };
            foreach (var commandItem in commands)
            {
                switch (commandItem)
                {
                    case -1:
                        posArray = GetPos(arrIndex, -1);
                        count = 0;
                        break;

                    case -2:
                        posArray = GetPos(arrIndex, -2);
                        count = 0;
                        break;

                    default:
                        count = commandItem;
                        break;
                }

                var newR = curPoint[0] + count * posArray[0];
                var newC = curPoint[1] + count * posArray[1];

                if (count != 0 && posDic.ContainsKey(newR) && posDic[newR].Contains(newC))
                {
                    newR = curPoint[0] + (count - 1) * posArray[0];
                    newC = curPoint[1] + (count - 1) * posArray[1];
                }

                curPoint[0] = newR;
                curPoint[1] = newC;
            }

            return curPoint[0] * curPoint[0] + curPoint[1] * curPoint[1];
        }
    }
}
