using System;
using System.Linq;

namespace ForSolveProblem
{
    public class Problem914 : IProblem
    {
        public void RunProblem()
        {
            var temp = HasGroupsSizeX(new[] { 0, 0, 1, 1, 1, 1, 2, 2, 3, 4 });

        }

        public bool HasGroupsSizeX(int[] deck)
        {
            var list = deck
                .GroupBy(i => i)
                .Select(i => i.Count());

            var gcd = 0;
            foreach (var listItem in list)
            {
                gcd = Gcd(gcd, listItem);
                if (gcd == 1)
                    return false;
            }

            return gcd != 1;
        }

        public bool HasGroupsSizeX1(int[] deck)
        {
            var orderDeck = deck.OrderBy(i => i).ToArray();

            var curValue = orderDeck[0];
            var curCount = 1;
            var gcd = 0;
            for (var i = 1; i < orderDeck.Length; i++)
            {
                var deckItem = orderDeck[i];
                if (curValue != deckItem)
                {
                    gcd = Gcd(gcd, curCount);
                    if (gcd == 1) return false;

                    curValue = deckItem;
                    curCount = 1;
                    continue;
                }

                curCount++;
            }

            gcd = Gcd(gcd, curCount);
            return gcd != 1;
        }

        private int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
    }
}
