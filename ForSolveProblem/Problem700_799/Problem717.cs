using System;
namespace ForSolveProblem
{
    public class Problem717 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public bool IsOneBitCharacter(int[] bits)
        {
            var i = 0;
            while (i < bits.Length)
            {
                if (i == bits.Length - 1) return true;

                if (bits[i] == 1)
                    i += 2;
                else
                    i += 1;
            }

            return false;
        }

        public bool IsOneBitCharacter1(int[] bits)
        {
            for (var i = 0; i < bits.Length; i++)
            {
                if (i == bits.Length - 1) return true;

                if (bits[i] == 1) i++;
            }

            return false;
        }
    }
}
