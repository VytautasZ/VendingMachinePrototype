
using System.Collections.Generic;

public class CoinChangeProblem
{

    public static List<List<int>> GetAllCombinations(int amount, int[] denominations)
    {
        List<List<int>>[] dp = new List<List<int>>[amount + 1];
        dp[0] = new List<List<int>> { new List<int>() };

        for (int i = 1; i <= amount; i++)
        {
            dp[i] = new List<List<int>>();

            for (int j = 0; j < denominations.Length; j++)
            {
                int coinValue = denominations[j];

                if (coinValue <= i)
                {
                    int remainingAmount = i - coinValue;

                    foreach (var combination in dp[remainingAmount])
                    {
                        List<int> newCombination = new List<int>(combination);
                        newCombination.Add(coinValue);
                        newCombination.Sort(); // Sort the combination to ensure uniqueness
                        if (!dp[i].Any(c => c.SequenceEqual(newCombination))) // Check for duplicates
                            dp[i].Add(newCombination);
                    }
                }
            }
        }

        // Flatten the list of lists
        return dp[amount].ToList();
    }

    public static void Main(string[] args)
    {

        int[,] coinStorage = { { 1, 2, 5 }, { 8, 4, 2 } };

        PrintCoinStorage(coinStorage);

        int change = 5;
        int[] coinsForChange = CalculateCoinsForTheChange(coinStorage, change);
        
        Console.WriteLine(string.Join(", ", coinsForChange));

    }

    private static void PrintCoinStorage(int[,] coinStorage)
    {
        Console.WriteLine("Coin Storage:");
        for (int i = 0; i < coinStorage.GetLength(0); i++)
        {
            for (int j = 0; j < coinStorage.GetLength(1); j++)
            {
                Console.Write(coinStorage[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static int[] CalculateCoinsForTheChange(Dictionary<int, int> coinStorage, int change)
    {
        int[] C = new int[change + 1]; // Array to store minimum number of coins for each value
        int[] S = new int[change + 1]; // Array to store the last coin used for each value

        // Initialize C array
        for (int i = 1; i <= change; i++)
        {
            C[i] = int.MaxValue;
        }

        // Loop through each coin denomination
        for (int i = 0; i < coinValues.Length; i++)
        {
            int v = coinValues[i]; // Coin denomination
            int limit = coinLimits[i]; // Coin limit

            // Loop coinLimit[i] times
            for (int j = 1; j <= limit; j++)
            {
                // Loop through each value from v to amount
                for (int k = v; k <= change; k++)
                {
                    // If C[k] is not infinity and C[k] + 1 is less than C[k + v]
                    if (C[k] != int.MaxValue && C[k] + 1 < C[k + v])
                    {
                        // Update C[k + v] with C[k] + 1 and set S[k + v] to v
                        C[k + v] = C[k] + 1;
                        S[k + v] = v;
                    }
                }
            }
        }

        // Print the minimum number of coins required for each value
        Console.WriteLine("Minimum number of coins required for each value:");
        for (int i = 0; i <= change; i++)
        {
            Console.WriteLine($"Amount: {i}, Coins required: {(C[i] == int.MaxValue ? -1 : C[i])}");
        }
    }
}