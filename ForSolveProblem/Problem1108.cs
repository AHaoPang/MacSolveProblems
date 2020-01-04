using System;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1108 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string DefangIPaddr(string address)
        {
            var forReturn = new StringBuilder(address.Length);
            foreach (var addChar in address)
            {
                if (addChar == '.')
                    forReturn.Append("[.]");
                else
                    forReturn.Append(addChar);
            }

            return forReturn.ToString();
        }

        public string DefangIPaddr2(string address)
        {
            return address.Replace(".", "[.]");
        }
    }
}
