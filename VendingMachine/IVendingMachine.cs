namespace VendingMachine
{
    public interface IVendingMachine
    {
        List<int> GiveTheChange(int itemPrice, int[] givenCoinCombination);
    }
}
