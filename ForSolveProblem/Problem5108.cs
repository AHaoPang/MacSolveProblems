using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5108 : IProblem
    {
        public void RunProblem()
        {
            var temp = Encode(23);
            if (temp != "1000") throw new Exception();

            temp = Encode(107);
            if (temp != "101100") throw new Exception();

            temp = Encode(0);
            if (temp != "") throw new Exception();

            temp = Encode(1);
            if (temp != "0") throw new Exception();

            temp = Encode(3);
            if (temp != "00") throw new Exception();
        }

        public string Encode(int num)
        {
            if (num == 0) return "";

            var preValue = 1;
            var zeroCount = 1;
            while(preValue * 2 + 1 <= num)
            {
                preValue = preValue * 2 + 1;
                zeroCount++;
            }

            var subValue = num - preValue;

            var forReturn = "";
            while(subValue != 0)
            {
                if ((subValue & 1) == 1) forReturn += "1";
                else forReturn += "0";

                subValue >>= 1;
            }

            while (forReturn.Length < zeroCount) forReturn += "0";

            return new string(forReturn.Reverse().ToArray());
        }
    }
}
