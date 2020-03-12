using System;
namespace ForSolveProblem
{
    public class Problem537 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string ComplexNumberMultiply(string a, string b)
        {
            var aArray = ParseStrToArray(a);
            var bArray = ParseStrToArray(b);

            var resultArray = new int[2];
            resultArray[0] = aArray[0] * bArray[0] + aArray[1] * bArray[1] * -1;
            resultArray[1] = aArray[0] * bArray[1] + aArray[1] * bArray[0];

            return $"{resultArray[0]}+{resultArray[1]}i";
        }

        private int[] ParseStrToArray(string s)
        {
            var splitArray = s.TrimEnd('i').Split('+');
            return new int[] { int.Parse(splitArray[0]), int.Parse(splitArray[1]) };
        }
    }
}
