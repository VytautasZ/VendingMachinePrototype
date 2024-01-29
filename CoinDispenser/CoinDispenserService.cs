namespace CoinDispenser
{
    public sealed class CoinDispenserService : ICoinDispenserService
    {
        public List<int> GetCoinChangeCombination(int targetChangeAmount, int[] coinDenominations, int[] coinAmounts, int maxCoinCount)
        {
            List<int>[] combination = InitialiseCombinationList(targetChangeAmount);

            for (int coinIndex = 0; coinIndex < coinDenominations.Length; coinIndex++)
            {
                int coinDenomination = coinDenominations[coinIndex];

                if (coinAmounts[coinIndex] == 0)
                    continue;

                for (int amount = coinDenomination; amount <= targetChangeAmount; amount++)
                {
                    if (IsPossibleToCombneCoins(combination, amount, coinDenomination, maxCoinCount))
                    {
                        List<int> newCombination = new List<int>(combination[amount - coinDenomination]);
                        newCombination.Add(coinDenomination);
                        combination[amount] = newCombination;
                    }
                }
            }

            return combination[targetChangeAmount];
        }


        private static List<int>[] InitialiseCombinationList(int targetChangeAmount)
        {
            List<int>[] combination = new List<int>[targetChangeAmount + 1];

            for (int i = 0; i <= targetChangeAmount; i++)
            {
                combination[i] = new List<int>();
            }

            return combination;
        }

        private static bool IsPossibleToCombneCoins(List<int>[] combination, int amount, int coinDenomination, int maxCoinCount)
            => (combination[amount - coinDenomination].Count < maxCoinCount) && (combination[amount - coinDenomination].Count > 0 || amount == coinDenomination);
    }
}
