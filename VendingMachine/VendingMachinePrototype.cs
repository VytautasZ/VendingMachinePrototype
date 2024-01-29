using CoinDispenser;

namespace VendingMachine
{
    public class VendingMachinePrototype : IVendingMachine
    {
        private int[] _coinDenominations { get; }
        private int[] _coinDenominationAmount { get; }
        private int _maxCoinCountForChange { get; }

        private CoinDispenserService CoinDispenserService { get; }

        public VendingMachinePrototype(CoinDispenserService coinDispenser, int[] coinDenominations, int[] coinDenominationAmoutn, int maxCoinCountForChange)
        {
            CoinDispenserService = coinDispenser;
            _coinDenominationAmount = coinDenominationAmoutn;
            _coinDenominations = coinDenominations;
            _maxCoinCountForChange = maxCoinCountForChange;
        }


        public List<int> GiveTheChange(int itemPrice, int[] givenCoinCombination)
        {
            PrintCoinDenominationsAmount();
            int givenAmount = givenCoinCombination.Sum(coin => coin);

            if (itemPrice > givenAmount)
                throw NotEnoughMoneyGivenException();

            int requiredChangeAmount = CalculateRequiredAmount(givenAmount, itemPrice);

            AddCoinsToCoinAmount(givenCoinCombination);
            PrintCoinDenominationsAmount();

            if (requiredChangeAmount == 0)
                return new List<int>();

            List<int> changeCoinCombination = CoinDispenserService.GetCoinChangeCombination(requiredChangeAmount, _coinDenominations, _coinDenominationAmount, _maxCoinCountForChange);

            if (changeCoinCombination.Count > 0)
                RemoveCoinsFromCoinAmount(changeCoinCombination.ToArray());

            PrintCoinDenominationsAmount();

            return changeCoinCombination;
        }

        private Exception NotEnoughMoneyGivenException()
            => throw new Exception("Not enough money.");

        private int CalculateRequiredAmount(int givenAmount, int itemPrice)
            => givenAmount - itemPrice;

        private void AddCoinsToCoinAmount(int[] coinCombination)
        {
            foreach (int coin in coinCombination)
            {
                int coinIndex = Array.IndexOf(_coinDenominations, coin);
                _coinDenominationAmount[coinIndex]++;
            }
        }

        private void RemoveCoinsFromCoinAmount(int[] coinCombination)
        {
            foreach (int coin in coinCombination)
            {
                int coinIndex = Array.IndexOf(_coinDenominations, coin);
                _coinDenominationAmount[coinIndex]--;
            }
        }


        private void PrintCoinDenominationsAmount()
        {
            for (int i = 0; i < _coinDenominations.Length; i++)
            {
                Console.WriteLine($"Coin denomination: {_coinDenominations[i]}, Amount: {_coinDenominationAmount[i]}");
            }
        }
    }
}

