// https://leetcode.com/problems/coin-change/
// This is correct but TLE.
// Interesting `build the table` but far from optimal.

public class Solution 
{
    int maxMultp(int small, int big)
    {
        return big/small;
    }
    
    void Print(int[,] dp)
    {
        for(int i = 0; i < dp.GetLength(0); ++i)
        {
            for(int j = 0; j < dp.GetLength(1); ++j)
            {
                Console.Write(dp[i, j] + ", ");
            }
            
            Console.WriteLine();
        }
    }
    
    public int CoinChange(int[] coins, int amount) 
    {
        if(coins.Length == 0) return 0;
        
        // dp of cost
        int[,] dp = new int[coins.Length, amount+1];
        
        dp[0,0] = 0;
        for(int subAmount = 1; subAmount <= amount; ++subAmount)
        {
            dp[0, subAmount] = -1; // -1 = no way to get there.
            
            if(subAmount % coins[0] == 0)
            {
                dp[0, subAmount] = subAmount / coins[0];
            }
        }
        
        for(int i = 1; i < coins.Length; ++i)
        {
            for(int subAmount = 0; subAmount <= amount; ++subAmount)
            {
                dp[i, subAmount] = int.MaxValue/2; // -2 = non-initialized
            }
        }
        
        for(int i = 1; i < coins.Length; ++i)
        {
            for(int subAmount = 0; subAmount <= amount; ++subAmount)
            {
                for(int j = 0; j <= subAmount; ++j)
                {
                    if((subAmount - j) % coins[i] == 0)
                    {
                        // Previous cost plus number of times coins[i] needs to be added to obtain this solution.
                        int cost = (subAmount - j) / coins[i];
                        
                        if(i>0) 
                        {
                            cost += dp[i-1, j];
                        }
                        
                        if(dp[i-1, j] != -1 && cost < dp[i, subAmount])
                        {
                            dp[i, subAmount] = cost;
                        }
                    }
                }
            }
        }
        
        //Print(dp);
        
        return dp[dp.GetLength(0)-1, dp.GetLength(1)-1];
    }
}