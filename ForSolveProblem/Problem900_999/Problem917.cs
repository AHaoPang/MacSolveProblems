using System;
namespace ForSolveProblem
{
    public class Problem917 : IProblem
    {
        public void RunProblem()
        {
            throw new NotImplementedException();
        }

        public string ReverseOnlyLetters(string S)
        {
            var resArray = S.ToCharArray();
            var leftIndex = 0;
            var rightIndex = S.Length - 1;
            while (true)
            {
                while (leftIndex < S.Length && !char.IsLetter(resArray[leftIndex]))
                    leftIndex++;

                while (rightIndex >= 0 && !char.IsLetter(resArray[rightIndex]))
                    rightIndex--;

                if (leftIndex >= rightIndex)
                    break;

                var c = resArray[leftIndex];
                resArray[leftIndex] = resArray[rightIndex];
                resArray[rightIndex] = c;

                leftIndex++;
                rightIndex--;
            }

            return new string(resArray);
        }
    }
}
