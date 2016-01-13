// https://leetcode.com/problems/coin-change/
// This is correct, splightly more complicated than the optimal solution.
// This builds the solution from ground-up (opposite of KnapSack).
// Would be interesting to check if KnapSack / SSum can be coded this way.

public class Solution 
{
    public int CoinChange(int[] coins, int amount) 
    {
        int[] dp = new int[Math.Max(amount+1,coins.Length)];
        dp[0] = 0;
        for(int i = 1; i < dp.Length; ++i) dp[i] = int.MaxValue;
        
        for(int i = 0; i <= amount; ++i)
        {
            if(dp[i] == int.MaxValue) continue;
            for(int j = 0; j < coins.Length; ++j)
            {
                int t = i + coins[j];
                if(t < dp.Length && dp[t] > dp[i] + 1)
                {
                    dp[t] = dp[i] + 1;
                }
            }
        }
        
        if(dp[amount] == int.MaxValue) return -1;
        return dp[amount];
    }
}
