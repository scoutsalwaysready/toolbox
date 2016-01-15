// Question from: https://leetcode.com/problems/combination-sum/

public class Solution 
{
    Action<int[]> found;
    
    public void rec(int[] candidates, int target, int[] nums, int currentVal = 0, int i = 0)
    {
        if(currentVal > target) return;
        
        if(currentVal == target)
        {
            this.found(nums);
            return;
        }        
        
        if(i == nums.Length) return;
        
        int multiplicity = 0;
        while(currentVal + multiplicity*candidates[i] <= target)
        {
           currentVal += multiplicity*candidates[i];
           nums[i] += multiplicity;
           
           rec(candidates, target, nums, currentVal, i+1);
           
           currentVal -= multiplicity*candidates[i];
           nums[i] -= multiplicity;  
           
           multiplicity += 1;
        }
    }
    
    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        List<IList<int>> ll = new List<IList<int>>();
        int[] nums = new int[candidates.Length];
        
        this.found = (x) => 
        {
            // x is nums that must be expanded in sorted, multiplicity array
            List<int> ans = new List<int>();
            for(int i = 0; i < x.Length; ++i)
            {
                for(int j = 0; j < x[i]; ++j)
                {
                    ans.Add(candidates[i]);
                }
            }
            
            ans.Sort();
            ll.Add(ans);
        };
        
        rec(candidates, target, nums);
        return ll;
    }
}
