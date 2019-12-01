using System;
namespace ForSolveProblem
{
    public class Problem5136 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public int CountShips(Sea sea, int[] topRight, int[] bottomLeft)
        {
            m_forReturn = 0;
            Devide(sea, topRight, bottomLeft);
            return m_forReturn;
        }

        private int m_forReturn;

        private void Devide(Sea sea, int[] topRight, int[] bottomLeft)
        {
            if (topRight[0] < bottomLeft[0] || topRight[1] < bottomLeft[1]) return;
            if (!sea.HasShips(topRight, bottomLeft)) return;

            if (topRight[0] == bottomLeft[0] && topRight[1] == bottomLeft[1])
            {
                m_forReturn++;
                return;
            }

            var width = topRight[0] - bottomLeft[0];
            var height = topRight[1] - bottomLeft[1];

            if (width >= height)
            {
                var middle = bottomLeft[0] + width / 2;
                Devide(sea, new int[] { middle, topRight[1] }, bottomLeft);
                Devide(sea, topRight, new int[] { middle + 1, bottomLeft[1] });
            }
            else
            {
                var middle = bottomLeft[1] + height / 2;
                Devide(sea, new int[] { topRight[0], middle }, bottomLeft);
                Devide(sea, topRight, new int[] { bottomLeft[0], middle + 1 });
            }
        }
    }

    public class Sea
    {
        public bool HasShips(int[] topRight, int[] bottomLeft) => true;
    }
}
