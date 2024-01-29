
namespace CoinDispenser
{
    public interface ICoinDispenserService
    {
        List<int> GetCoinChangeCombination(int targetChangeAmount, int[] coinDenominations, int[] coinAmounts, int maxCoinCount);
    }
}
