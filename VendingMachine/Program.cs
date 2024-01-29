using CoinDispenser;
using VendingMachine;

CoinDispenserService coinDispenserService = new CoinDispenserService();
int[] coinDenominations = { 1, 2, 5 };
int[] coinDenominationAmount = { 8, 4, 2 };
int maxCoinAmountForChange = 3;

int itemPrice = 2;
int[] givenCoinCombination = { 5, 5 };

VendingMachinePrototype vendingMachine = new VendingMachinePrototype(coinDispenserService, coinDenominations, coinDenominationAmount, maxCoinAmountForChange);

List<int> changeCoinCombination = vendingMachine.GiveTheChange(itemPrice, givenCoinCombination);

Console.WriteLine($"Channge coin combination: {string.Join(", ", changeCoinCombination)}");
Console.ReadLine();