using System;
using System.Collections.Generic;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1323 : IProblem
    {
        public void RunProblem()
        {
            var temp = Maximum69Number(9669);
            if (temp != 9969) throw new Exception();

            temp = Maximum69Number(9996);
            if (temp != 9999) throw new Exception();

            temp = Maximum69Number(9999);
            if (temp != 9999) throw new Exception();
        }

        public int Maximum69Number(int num)
        {
            var numStrArray = num.ToString().ToCharArray();

            for (int i = 0; i < numStrArray.Length; i++)
            {
                if (numStrArray[i] == '6')
                {
                    numStrArray[i] = '9';
                    break;
                }
            }

            return int.Parse(new string(numStrArray));
        }
    }
}
