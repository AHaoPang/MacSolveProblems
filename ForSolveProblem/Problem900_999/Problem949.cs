using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem949 : IProblem
    {
        public void RunProblem()
        {
            var temp = LargestTimeFromDigits(new[] { 1, 2, 3, 4 });
        }

        public string LargestTimeFromDigits(int[] A)
        {
            var res = -1;

            for (var i = 0; i < A.Length; i++)
            {
                for (var j = 0; j < A.Length; j++) if (j != i)
                    {
                        for (var k = 0; k < A.Length; k++) if (k != i && k != j)
                            {
                                var l = 6 - i - j - k;
                                var h = A[i] * 10 + A[j];
                                var m = A[k] * 10 + A[l];
                                if (h < 24 && m < 60)
                                    res = Math.Max(res, h * 60 + m);
                            }
                    }
            }

            if (res < 0) return "";

            var hour = (res / 60).ToString();
            if (hour.Length == 1)
                hour = "0" + hour;

            var min = (res % 60).ToString();
            if (min.Length == 1)
                min = "0" + min;

            return $"{hour}:{min}";
        }

        public string LargestTimeFromDigits3(int[] A)
        {
            var arr = new int[] { -1, 1, -1, 1 };

            for (var i = 0; i < A.Length; i++)
            {
                for (var j = 0; j < A.Length; j++)
                {
                    if (j == i) continue;

                    for (var k = 0; k < A.Length; k++)
                    {
                        if (k == i || k == j) continue;

                        for (var l = 0; l < A.Length; l++)
                        {
                            if (l == i || l == j || l == k) continue;

                            var iN = A[i];
                            var jN = A[j];
                            var kN = A[k];
                            var lN = A[l];
                            if (iN * 10 + jN < 24 && kN * 10 + lN < 60)
                            {
                                if (iN * 10 + jN < arr[0] * 10 + arr[1]) continue;

                                if (iN * 10 + jN > arr[0] * 10 + arr[1] || kN * 10 + lN > arr[2] * 10 + arr[3])
                                {
                                    arr[0] = iN;
                                    arr[1] = jN;
                                    arr[2] = kN;
                                    arr[3] = lN;
                                }
                            }
                        }
                    }
                }
            }

            return arr[0] * arr[1] < 0 ? "" : $"{arr[0]}{arr[1]}:{arr[2]}{arr[3]}";
        }

        public string LargestTimeFromDigits2(int[] A)
        {
            var orderList = A.OrderBy(i => i).Select(i => new NumEntity() { Num = i }).ToList();
            if (orderList.First().Num > 2) return "";

            if (orderList.Count(i => i.Num == 2) >= 1 && orderList.Count(i => i.Num <= 3) >= 2 && orderList.Count(i => i.Num <= 5) >= 3)
            {
                var one = orderList.First(i => i.Num == 2);
                one.IsChoosed = true;
                var two = orderList.Last(i => i.Num <= 3 && !i.IsChoosed);
                two.IsChoosed = true;
                var three = orderList.Last(i => i.Num <= 5 && !i.IsChoosed);
                three.IsChoosed = true;

                return $"{one.Num}{two.Num}:{three.Num}{orderList.First(i => !i.IsChoosed).Num}";
            }

            if (orderList.Count(i => i.Num <= 1) >= 1)
            {
                var count = orderList.Count(i => i.Num <= 5);
                if (count == 2)
                {
                    var one = orderList.LastOrDefault(i => i.Num <= 1);
                    one.IsChoosed = true;
                    var three = orderList.LastOrDefault(i => i.Num <= 5 && !i.IsChoosed);
                    three.IsChoosed = true;
                    var two = orderList.LastOrDefault(i => !i.IsChoosed);
                    two.IsChoosed = true;

                    return $"{one.Num}{two.Num}:{three.Num}{orderList.First(i => !i.IsChoosed).Num}";
                }
                else if (count > 2)
                {
                    var one = orderList.LastOrDefault(i => i.Num <= 1);
                    one.IsChoosed = true;
                    var two = orderList.LastOrDefault(i => !i.IsChoosed);
                    two.IsChoosed = true;
                    var three = orderList.LastOrDefault(i => i.Num <= 5 && !i.IsChoosed);
                    three.IsChoosed = true;

                    return $"{one.Num}{two.Num}:{three.Num}{orderList.First(i => !i.IsChoosed).Num}";
                }
            }

            return "";
        }

        public string LargestTimeFromDigits1(int[] A)
        {
            var orderList = A.OrderBy(i => i).Select(i => new NumEntity() { Num = i }).ToList();
            if (orderList.First().Num > 2) return "";

            var oneEntity = orderList.LastOrDefault(i => i.Num <= 2);
            if (oneEntity.Num == 2)
            {
                oneEntity.IsChoosed = true;

                var twoEntity = orderList.LastOrDefault(i => i.Num <= 3 && !i.IsChoosed);
                if (twoEntity != null)
                {
                    twoEntity.IsChoosed = true;
                    var threeEntity = orderList.LastOrDefault(i => i.Num <= 5 && !i.IsChoosed);
                    if (threeEntity != null)
                    {
                        threeEntity.IsChoosed = true;
                        return $"{oneEntity.Num}{twoEntity.Num}:{threeEntity.Num}{orderList.First(i => !i.IsChoosed).Num}";
                    }

                    twoEntity.IsChoosed = false;
                }

                oneEntity.IsChoosed = false;
            }

            oneEntity = orderList.LastOrDefault(i => i.Num <= 1);
            if (oneEntity != null)
            {
                oneEntity.IsChoosed = true;

                var countTemp = orderList.Count(i => i.Num <= 5 && !i.IsChoosed);
                if (countTemp == 1)
                {
                    var threeEntity = orderList.LastOrDefault(i => i.Num <= 5 && !i.IsChoosed);
                    if (threeEntity != null)
                    {
                        threeEntity.IsChoosed = true;

                        var twoEntity = orderList.Last(i => !i.IsChoosed);
                        return $"{oneEntity.Num}{twoEntity.Num}:{threeEntity.Num}{orderList.First(i => !i.IsChoosed).Num}";
                    }
                }
                else if (countTemp > 1)
                {
                    var twoEntity = orderList.Last(i => !i.IsChoosed);
                    twoEntity.IsChoosed = true;

                    var threeEntity = orderList.LastOrDefault(i => i.Num <= 5 && !i.IsChoosed);
                    threeEntity.IsChoosed = true;

                    return $"{oneEntity.Num}{twoEntity.Num}:{threeEntity.Num}{orderList.First(i => !i.IsChoosed).Num}";
                }
            }

            return "";
        }

        class NumEntity
        {
            public int Num { get; set; }
            public bool IsChoosed { get; set; }
        }
    }
}
