using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem5195 : IProblem
    {
        public void RunProblem()
        {
            var temp = LongestDiverseString(1, 1, 7);
            if (temp.Length != 8)
                throw new Exception();

            temp = LongestDiverseString(2, 2, 1);
            if (temp.Length != 5)
                throw new Exception();

            temp = LongestDiverseString(7, 1, 0);
            if (temp.Length != 5)
                throw new Exception();

            temp = LongestDiverseString(1, 4, 5);
            if (temp.Length != 10)
                throw new Exception();

            temp = LongestDiverseString(2, 4, 1);
            if (temp.Length != 7)
                throw new Exception();

            temp = LongestDiverseString(4, 4, 3);
            if (temp.Length != 11)
                throw new Exception();
        }

        public string LongestDiverseString(int a, int b, int c)
        {
            var arr = new (char charC, int charCount)[]
            {
                ('a',a),
                ('b',b),
                ('c',c)
            };

            var res = new List<char>();
            while (true)
            {
                Array.Sort(arr, (x, y) => x.charCount.CompareTo(y.charCount));

                if (arr[2].charCount == 0)
                    break;

                if (res.LastOrDefault() != arr[2].charC)
                {
                    res.Add(arr[2].charC);
                    arr[2].charCount -= 1;

                    if (arr[2].charCount >= 1)
                    {
                        res.Add(arr[2].charC);
                        arr[2].charCount -= 1;
                    }
                }
                else
                {
                    if (arr[1].charCount == 0)
                        break;

                    res.Add(arr[1].charC);
                    arr[1].charCount -= 1;
                }
            }

            return new string(res.ToArray());
        }

        public string LongestDiverseString1(int a, int b, int c)
        {
            var arr = new (char charC, int charCount)[]
            {
                ('a',a),
                ('b',b),
                ('c',c)
            };

            var descArra = arr.OrderByDescending(i => i.charCount).ToArray();
            return Recursive(descArra, new StringBuilder());
        }

        private string Recursive((char charC, int charCount)[] arr, StringBuilder res)
        {
            if (arr.All(i => i.charCount == 0))
                return res.ToString();

            if (res.Length > 0 && res.ToString().Last() == arr.First().charC)
                return res.ToString();

            for (var i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (arr[i].charCount >= 2)
                        {
                            res.Append(arr[i].charC);
                            res.Append(arr[i].charC);
                            arr[i].charCount -= 2;
                        }
                        else
                        {
                            res.Append(arr[i].charC);
                            arr[i].charCount -= 1;
                        }
                        break;

                    case 1:
                        if (arr[i].charCount >= 1)
                        {
                            if (arr[i].charCount >= 2 && arr[i].charCount > arr[0].charCount)
                            {
                                res.Append(arr[i].charC);
                                res.Append(arr[i].charC);
                                arr[i].charCount -= 2;
                            }
                            else
                            {
                                res.Append(arr[i].charC);
                                arr[i].charCount -= 1;
                            }
                        }
                        break;

                    case 2:
                        if (arr[i].charCount >= 1)
                        {
                            if (arr[i].charCount > arr[0].charCount)
                            {
                                if (arr[i].charCount >= 2)
                                {
                                    res.Append(arr[i].charC);
                                    res.Append(arr[i].charC);
                                    arr[i].charCount -= 2;
                                }
                                else
                                {
                                    res.Append(arr[i].charC);
                                    arr[i].charCount -= 1;
                                }
                            }
                        }

                        break;
                }
            }

            var newArr = arr.OrderByDescending(i => i.charCount).ToArray();
            return Recursive(newArr, res);
        }
    }
}
