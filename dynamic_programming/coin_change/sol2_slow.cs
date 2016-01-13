// https://leetcode.com/problems/coin-change/
// This is correct but TLE.
// Better than slow1, use a different `knapsack-like` approach.

public class Solution 
{
    public int rec(int[] coins, int amount, int[] dp, int i, int lastCost)
    {
        if(amount<0) return -1;
        if(amount==0) return lastCost;
        if(i<0) return -1;
        
        int mnCost = int.MaxValue;

        int t = 0;
        while(t<= amount)
        {
            int cost;
            
            if(dp[amount-t] != -1)
            {
                cost = dp[amount-t];
            }
            else
            {
                cost = rec(coins, amount - t, dp, i-1, lastCost + t/coins[i]);    
            }
            
            if(cost != -1 && cost < mnCost)
            {
                mnCost = cost;
            }
            
            t += coins[i];
        }
        
        if(mnCost == int.MaxValue)
        {
            dp[i] = -1;
        }
        else
        {
            dp[i] = mnCost;
        }
        
        return dp[i];
    }
    
    public int CoinChange(int[] coins, int amount) 
    {
        int[] dp = new int[Math.Max(amount+1, coins.Length)];
        for(int i = 1; i < dp.Length; ++i) dp[i] = -1;
        dp[0] = 0;
        int v = rec(coins, amount, dp, coins.Length-1, 0);
        return v;
    }
}
